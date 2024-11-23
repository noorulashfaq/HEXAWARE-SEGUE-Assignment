using System;

namespace CMS_app.Repository
{
	public interface ICourierUserRepository
	{
		int UserSignUp(User user);
		int UserLogin(string email, string password);
		string PlaceOrder(Courier courier);
		string GetOrderStatus(string trackingNumber);
		bool cancelOrder(string trackingNumber);
		List<Courier> GetAssignedOrder(int employeeId);
	}
}
