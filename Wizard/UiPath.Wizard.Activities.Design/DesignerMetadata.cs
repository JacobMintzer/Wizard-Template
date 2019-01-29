using System;
using System.Activities.Presentation.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UiPath.Wizard.Activities.Design.Properties;
namespace UiPath.Wizard.Activities.Design
{
	public class DesignerMetadata : IRegisterMetadata
	{
		public void Register()
		{
			AttributeTableBuilder attributeTableBuilder = new AttributeTableBuilder();
			attributeTableBuilder.AddCustomAttributes(typeof(WizardActivity), new CategoryAttribute(Resources.WizardActivityCategory));
			attributeTableBuilder.AddCustomAttributes(typeof(WizardActivity), new DesignerAttribute(typeof(WizardActivityDesigner)));
			MetadataStore.AddAttributeTable(attributeTableBuilder.CreateTable());
		}
	}
}
