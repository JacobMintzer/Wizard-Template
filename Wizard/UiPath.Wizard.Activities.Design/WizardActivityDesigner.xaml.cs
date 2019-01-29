using System;
using System.Activities.Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiPath.Wizard.Activities.Design.Properties;

namespace UiPath.Wizard.Activities.Design
{
	/// <summary>
	/// Interaction logic for WizardActivityDesigner.xaml
	/// </summary>
	public partial class WizardActivityDesigner : ActivityDesigner
	{
		public WizardActivityDesigner()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Wizard dialog = new Wizard(ModelItem);
			dialog.Show();
		}
	}
}
