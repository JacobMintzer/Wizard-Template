using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UiPath.Wizard
{

	/**
	 * This is a generic class that would do the actual computation for your activity, 
	 * right now it just returns hardcoded values
	 */
	public class WizardBackend
	{
		public WizardBackend(string username, string password, string url) { }
		/**
		 * generic api call that returns multiple values can go here, this function
		 * is asynchronous, so can be used with await
		 */
		public async Task<Dictionary<string,string> >LoadValues()
		{
            await Task.Run(()=>Thread.Sleep(3000)); //add waits to your code so people will be impressed when you optimize it later
            return new Dictionary<string, string>() {
				{"instead of using hardcoded values","value1" },
				{"make an api call, or some other function", "value2" }
			};
		}
	}
}
