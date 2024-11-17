using System;

public class Location
{
	//LocationID, LocationName, Address
	private int locationId;
	private string locationName, address;

	public int LocationId { get; set; }
	public string LocationName { get; set; }
	public string Address { get; set; }

	//public Location()
	//{

	//}

	public Location(int id, string name, string address)
	{
		LocationId = id;
		LocationName = name;
		Address = address;
	}

	public override string ToString()
	{
		return $"Location ID: {LocationId}\t" +
			$"Location name: {LocationName}\t" +
			$"Address: {Address}\n";
	}

}