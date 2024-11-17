using System;

public class CourierCompany
{
	//companyName ,
	//courierDetails -collection of Courier Objects,
	//employeeDetailscollection of Employee Objects,
	//locationDetails - collection of Location Objects.

	private string companyName;
	private List<Courier> courierDetails;
	private List<Employee> employeeDetails;
	private List<Location> locationDetails;

	public string CompanyName { get; set; }
	public List<Courier> CourierDetails { get; set; }
	public List<Employee> EmployeeDetails { get; set; }
	public List<Location> LocationDetails { get; set; }

	//public CourierCompany()
	//{
	//}

	public CourierCompany(string companyName)
	{
		CompanyName = companyName;
		CourierDetails = new List<Courier>();
		EmployeeDetails = new List<Employee>();
		LocationDetails = new List<Location>();
	}

	public override string ToString()
	{
		return $"Company name: {CompanyName}\t" +
			$"Courier details: {CourierDetails}\t" +
			$"Employee details: {EmployeeDetails}\t" +
			$"Location details: {LocationDetails}\n";
	}
}
