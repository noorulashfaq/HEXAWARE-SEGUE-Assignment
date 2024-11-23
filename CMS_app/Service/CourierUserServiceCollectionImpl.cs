using CMS_app.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Service
{
	internal class CourierUserServiceCollectionImpl: ICourierUserServiceCollectionImpl
	{
		private CourierCompanyCollection companyObj;
		public CourierUserServiceCollectionImpl()
		{
			companyObj = new CourierCompanyCollection();
		}

		public void AddCourierCompany(CourierService company)
		{
			companyObj.AddCompany(company);
		}

		public List<CourierService> GetAllCourierCompanies()
		{
			return companyObj.Companies;
		}
	}
}
