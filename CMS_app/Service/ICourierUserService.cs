namespace CMS_app.Service
{
	public interface ICourierUserService
	{
		void UserSignUp();
		bool UserLogin();
		void PlaceOrder();
		void GetOrderStatus();
		void CancelOrder();
		void GetAssignedOrders();
	}
}
