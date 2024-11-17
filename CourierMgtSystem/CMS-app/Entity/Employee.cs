using System;

public class Employee
{
	//employeeID, employeeName, email, contactNumber, role String, salary
	private int employeeId, contactNumber;
	private string employeeName, email, role;
	private double salary;

    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
	public string Email { get; set; }
	public string Role { get; set; }
	public int ContactNumber { get; set; }
	public double Salary { get; set; }

	//public Employee()
	//{
	//}

	public Employee(int employeeId, string employeeName, string email, string role, int phone, double salary)
	{
		EmployeeId = employeeId;
		EmployeeName = employeeName;
		Email = email;
		Role = role;
		ContactNumber = phone;
		Salary = salary;
	}

	public override string ToString()
	{
		return $"Employee ID: {EmployeeId}\t" +
			$"Employee name: {EmployeeName}\t" +
			$"Email: {Email}\t" +
			$"Role: {Role}\t" +
			$"Contact number: {ContactNumber}\t" +
			$"Salary: {Salary}\n";
	}
}
