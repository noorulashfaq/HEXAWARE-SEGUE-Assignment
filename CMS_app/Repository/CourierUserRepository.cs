using CMS_app.Utility;
using CMS_app.Main;
using System;
using System.Data.SqlClient;

namespace CMS_app.Repository
{
	public class CourierUserRepository: ICourierUserRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public static string TrackingNumber = "TRK" + DateTime.Now.Ticks.ToString() + new Random().Next(1000, 10000);

		public CourierUserRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public int UserSignUp(User user)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Users (Name, Email, Password, ContactNumber, Address) output INSERTED.UserID values (@name, @email, @password, @contact, @address)";
					_cmd.Parameters.AddWithValue("@name", user.UserName);
					_cmd.Parameters.AddWithValue("@email", user.Email);
					_cmd.Parameters.AddWithValue("@password", user.Password);
					_cmd.Parameters.AddWithValue("@contact", user.ContactNumber);
					_cmd.Parameters.AddWithValue("@address", user.Address);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return (int)_cmd.ExecuteScalar();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public int UserLogin(string email, string password)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			using (SqlCommand _cmd = new SqlCommand())
			{
				try
				{
					_cmd.CommandText = "SELECT UserID FROM Users WHERE Email = @email AND Password = @password";
					_cmd.Parameters.AddWithValue("@email", email);
					_cmd.Parameters.AddWithValue("@password", password);
					_cmd.Connection = conn;
					conn.Open();
					object result = _cmd.ExecuteScalar();
					return result == null ? 0 : (int)result;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return 0;
				}
			}
		}

		public string PlaceOrder(Courier courier)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Couriers (SenderID, ReceiverName, ReceiverAddress, Weight, TrackingNumber, ServiceID, EmployeeID, DeliveryDate, OrderedDate) output INSERTED.TrackingNumber values (@senderId, @receiverName, @receiverAddress, @weight, @trackingNumber, @serviceId, @employeeId, @deliveryDate, @orderedDate)";
					_cmd.Parameters.AddWithValue("@senderId", MainModule.LoggedUserId);
					_cmd.Parameters.AddWithValue("@receiverName", courier.ReceiverName);
					_cmd.Parameters.AddWithValue("@receiverAddress", courier.ReceiverAddress);
					_cmd.Parameters.AddWithValue("@weight", courier.Weight);
					_cmd.Parameters.AddWithValue("@trackingNumber", TrackingNumber);
					_cmd.Parameters.AddWithValue("@serviceId", courier.ServiceId);
					_cmd.Parameters.AddWithValue("@employeeId", courier.EmployeeId);
					_cmd.Parameters.AddWithValue("@deliveryDate", DateTime.Now.AddDays(3));
					_cmd.Parameters.AddWithValue("@orderedDate", DateTime.Now);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					object result = _cmd.ExecuteScalar();
					return result != null ? result.ToString() : null;

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		public string GetOrderStatus(string trackingNumber)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			using (SqlCommand _cmd = new SqlCommand())
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "SELECT Status FROM Couriers WHERE TrackingNumber = @trackingNumber";
					_cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);
					_cmd.Connection = conn;
					conn.Open();
					return (string)_cmd.ExecuteScalar();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return null;
				}
			}
		}

		public bool cancelOrder(string trackingNumber)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			using (SqlCommand _cmd = new SqlCommand())
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "update Couriers set Status = 'Cancelled' where TrackingNumber = @trackingNumber";
					_cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);
					_cmd.Connection = conn;
					conn.Open();
					return _cmd.ExecuteNonQuery() > 0;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return false;
				}
			}
		}

		public List<Courier> GetAssignedOrder(int employeeId)
		{
			List<Courier> couriers = new List<Courier>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = $"select * from Couriers where EmployeeID = {employeeId}";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Courier courier = new Courier();

							courier.CourierId = (int)reader["CourierID"];
							courier.SenderId = (int)reader["SenderID"];
							courier.ReceiverName = (string)reader["ReceiverName"];
							courier.ReceiverAddress = (string)reader["ReceiverAddress"];
							courier.Weight = Convert.ToDouble(reader["Weight"]);
							courier.Status = (string)reader["Status"];
							courier.TrackingNumber = (string)reader["TrackingNumber"];
							courier.ServiceId = (int)reader["ServiceID"];
							courier.EmployeeId = (int)reader["EmployeeID"];
							courier.DeliveryDate = (DateTime)reader["DeliveryDate"];
							courier.OrderedDate = (DateTime)reader["OrderedDate"];

							couriers.Add(courier);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return couriers;
		}

	}
}