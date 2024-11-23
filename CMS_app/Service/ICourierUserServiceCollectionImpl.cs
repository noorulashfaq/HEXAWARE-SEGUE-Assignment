using CMS_app.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Service
{
	internal interface ICourierUserServiceCollectionImpl
	{
		void AddCourierCompany(CourierService company);
		List<CourierService> GetAllCourierCompanies();
	}
}
