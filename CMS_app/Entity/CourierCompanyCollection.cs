using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Entity
{
	internal class CourierCompanyCollection
	{
		private List<CourierService> companies;

		public CourierCompanyCollection()
		{
			companies = new List<CourierService>();
		}

		public List<CourierService> Companies => companies;

		public void AddCompany(CourierService company)
		{
			companies.Add(company);
		}

		public void RemoveCompany(CourierService company)
		{
			companies.Remove(company);
		}

	}
}
