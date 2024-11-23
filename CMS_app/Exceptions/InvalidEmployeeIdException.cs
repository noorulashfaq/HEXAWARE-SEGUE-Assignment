using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Exceptions
{
	internal class InvalidEmployeeIdException: ApplicationException
	{
		public InvalidEmployeeIdException() { }

		public InvalidEmployeeIdException(string message) : base(message) { }
	}
}
