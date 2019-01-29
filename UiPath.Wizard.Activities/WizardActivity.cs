using System;
using System.Activities;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPath.Wizard.Activities
{
	public class WizardActivity : AsyncCodeActivity
	{

		public InArgument<string> Username { get; set; }
		public InArgument<string> Password { get; set; }
		public InArgument<string> Endpoint { get; set; }
		public InArgument<string> SelectedValue { get; set; }

		protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
		{
			throw new NotImplementedException();
		}

		protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
		{
			throw new NotImplementedException();
		}
	}
}
