using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Presentation;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using UiPath.Wizard.Activities.Design.Properties;

namespace UiPath.Wizard.Activities.Design
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Wizard : WorkflowElementDialog
	{
		Dictionary<string,string> _itemList = new Dictionary<string, string>();
        ComboBoxItem _nothingLoaded = new ComboBoxItem
        {
            Content = Properties.Resources.NothingLoaded, 
            IsEnabled =false,
            IsSelected = true,
            
            
        };
        ComboBoxItem _selectItem = new ComboBoxItem
        {
            Content = Properties.Resources.SelectValue,
            IsSelected = true,
            IsEnabled = false,
            
            
        };
        /**
		 * constructor takes modelItem to connect the values changed to the activity, 
		 * this is the only way to affect the activity's values.
		 */
        public Wizard(ModelItem modelItem)
		{
			InitializeComponent();
			this.ModelItem = modelItem;
            this.Context = modelItem.GetEditingContext();

            loadedValues.Items.Add(_nothingLoaded);
            //loadedValues.Items.Add(_nothingLoaded);
            //defaultItem.IsSelected = true;
            //defaultItem.IsEnabled = true;
            //loadedValues.SelectedValue = _nothingLoaded.Value;
        }

		/**C:\Users\Jacob\source\repos\Wizard\Wizard\UiPath.Wizard.Activities.Design\bin\Debug
		 * Called when load button is clicked. Usually this populates the drop-down menu
		 */
		private async void Load_Click(object sender, RoutedEventArgs e)
		{
			string _password = Convert(ModelItem.Properties["Password"].Value);
			string _username = Convert(ModelItem.Properties["Username"].Value);
			string _url = Convert(ModelItem.Properties["Endpoint"].Value);
			LoadButton.IsEnabled = false; //Disable button while loading
			WizardBackend _wiz = new WizardBackend(_username,_password,_url);
			_itemList = await _wiz.LoadValues();	//generic function to populate drop-down
			loadedValues.Items.Clear();
            _selectItem.IsSelected = true;
            loadedValues.Items.Add(_selectItem);
			foreach (KeyValuePair<string,string> item in _itemList) {
                loadedValues.Items.Add(new ComboBoxItem() { Content = item.Key,  Tag=item });
			}
			LoadButton.IsEnabled = true;//re-enable button afterwards. Note that if unhandled exceptions are thrown, the button will not be re-enabled
		}

		/**
		 * Called whenever you select a value from the wizard drop-down
		 * populate any necessary variables here
		 */
		private async void LoadedValues_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//key is selected in drop-down, value is added to properties panei
			try
			{
                KeyValuePair<string,string> selectedProperty=(KeyValuePair<string, string>)((ComboBoxItem)loadedValues.SelectedItem).Tag;
				ModelItem.Properties["SelectedValue"].SetValue(new InArgument<string>(selectedProperty.Value));
			}
            catch (InvalidCastException)
            {
                ModelItem?.Properties["SelectedValue"]?.ClearValue();
            }
			catch(NullReferenceException)
			{
				ModelItem?.Properties["SelectedValue"]?.ClearValue();
			}

		}

		/**
		 * extracts value from modelitem, returns null if there is no value
		 */
		public string Convert(ModelItem modelItem) 
		{
			var currentValue = modelItem?.GetCurrentValue() as InArgument<string>;
			Literal<string> literal = currentValue?.Expression as Literal<string>;
			return literal?.Value;
		}
	}
}
