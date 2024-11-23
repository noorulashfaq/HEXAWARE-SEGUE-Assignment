using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Service
{
	internal interface IAdminService
	{
		void AddNewEmployee();
		void AddNewLocation();
		void AddNewCourierService();
		void GetAllServices();
		void GetAllEmployees();
		void GetAllLocations();
	}
}
