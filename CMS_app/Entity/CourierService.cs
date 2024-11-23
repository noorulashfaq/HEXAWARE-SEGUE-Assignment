using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Entity
{
	internal class CourierService
	{
		private int serviceId;
		private string serviceName;
		private double cost;

		public int ServiceId { get; set; }
		public string ServiceName { get; set; }
		public double Cost { get; set; }

		public override string ToString()
		{
			return $"Service ID: {ServiceId}\tService name: {ServiceName}\tCost: {Cost}";
		}
	}
}
