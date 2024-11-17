using System;

public class User
{
	//userID , userName , email , password , contactNumber , address
	private int userId;
	private string username, email, password, address;
	private long contactNumber;
	
	public int UserId { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public long ContactNumber { get; set; }
	public string Address { get; set; }

	//public User()
	//{

	//}

	//public User(string name,  string mail, string pass, string addr, long contact)
	//{
	//	//UserId = id;
	//	UserName = name;
	//	Email = mail;
	//	Password = pass;
	//	Address = addr;
	//	ContactNumber = contact;
	//}

	public override string ToString()
	{
		return $"User details:\n" +
			$"ID: {userId}\t" +
			$"Name: {UserName}\t" +
			$"Email: {email}\t" +
			$"Address: {address}\t" +
			$"Contact: {ContactNumber}\n";
	}
}
