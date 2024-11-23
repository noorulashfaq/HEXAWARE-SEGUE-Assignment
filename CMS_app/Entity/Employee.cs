using System;

public class Employee
{
	//employeeID, employeeName, email, contactNumber, role String, salary
	private int employeeId;
	private long contactNumber;
	private string employeeName, email, role;
	private double salary;

    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
	public string Email { get; set; }
	public string Role { get; set; }
	public long ContactNumber { get; set; }
	public double Salary { get; set; }

	public Employee()
	{
	}

	public Employee(int employeeId, string employeeName, string email, string role, long phone, double salary)
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
		return $"Employee ID {EmployeeId}: {EmployeeName}\nEmail: {Email}\tRole: {Role}\tContact: {ContactNumber}";
	}
}
