using CMS_app.Entity;
using CMS_app.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Repository
{
	internal class AdminRepository : IAdminRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public AdminRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public int AddNewCourierService(CourierService service)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into CourierServices (ServiceName, Cost) values (@name, @cost)";
					_cmd.Parameters.AddWithValue("@name", service.ServiceName);
					_cmd.Parameters.AddWithValue("@cost", service.Cost);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return _cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public int AddNewEmployee(Employee employee)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Employees (Name, Email, ContactNumber, Role, Salary) values (@name, @email, @contact, @role, @salary)";
					_cmd.Parameters.AddWithValue("@name", employee.EmployeeName);
					_cmd.Parameters.AddWithValue("@email", employee.Email);
					_cmd.Parameters.AddWithValue("@contact", employee.ContactNumber);
					_cmd.Parameters.AddWithValue("@role", employee.Role);
					_cmd.Parameters.AddWithValue("@salary", employee.Salary);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return _cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public int AddNewLocation(Location location)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Locations (LocationName, Address) values (@name, @address)";
					_cmd.Parameters.AddWithValue("@name", location.LocationName);
					_cmd.Parameters.AddWithValue("@address", location.Address);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return _cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public List<Employee> GetAllEmployees()
		{
			List<Employee> employees = new List<Employee>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select * from Employees";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Employee employee = new Employee();

							employee.EmployeeId = (int)reader["EmployeeID"];
							employee.EmployeeName = (string)reader["Name"];
							employee.Email = (string)reader["Email"];
							employee.ContactNumber = (long)reader["ContactNumber"];
							employee.Role = (string)reader["Role"];
							employee.Salary = Convert.ToDouble(reader["Salary"]);

							employees.Add(employee);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return employees;
		}

		public List<Location> GetAllLocations()
		{
			List<Location> locations = new List<Location>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select * from Locations";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Location location = new Location();

							location.LocationId = (int)reader["LocationID"];
							location.LocationName = (string)reader["LocationName"];
							location.Address = (string)reader["Address"];

							locations.Add(location);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return locations;
		}

		public List<CourierService> GetAllServices()
		{
			List<CourierService> courierServices = new List<CourierService>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select * from CourierServices";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							CourierService courierService = new CourierService();

							courierService.ServiceId = (int)reader["ServiceID"];
							courierService.ServiceName = (string)reader["ServiceName"];
							courierService.Cost = Convert.ToDouble(reader["Cost"]);

							courierServices.Add(courierService);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return courierServices;
		}

	}
}
