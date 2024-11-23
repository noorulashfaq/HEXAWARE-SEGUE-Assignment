using CMS_app.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Repository
{
	internal interface IAdminRepository
	{
		int AddNewEmployee(Employee employee);
		int AddNewCourierService(CourierService service);
		int AddNewLocation(Location location);
		List<Employee> GetAllEmployees();
		List<CourierService> GetAllServices();
		List<Location> GetAllLocations();
	}
}
