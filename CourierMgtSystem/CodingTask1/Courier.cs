public struct Courier
{
	public string name;
	public double distanceToShipment;
	public double maxLoadCapacity;
	public double currentLoad;

	public bool CanCarry(double shipmentWeight)
	{
		return (currentLoad + shipmentWeight) <= maxLoadCapacity;
	}
}
