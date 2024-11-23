using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Exceptions
{
	internal class TrackingNumberNotFoundException: ApplicationException
	{
		public TrackingNumberNotFoundException() { }

		public TrackingNumberNotFoundException(string message) : base(message) { }
	}
}
