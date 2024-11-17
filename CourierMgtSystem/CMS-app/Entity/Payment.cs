using System;

public class Payment
{
	private long paymentId, courierId;
	private double amount;
	private DateTime paymentDate;

	public long PaymentId { get; set; }
	public long CourierId { get; set; }
	public double Amount { get; set; }
	public DateTime PaymentDate { get; set; }

	//public Payment()
	//{
	//}

	public Payment(long payId, long courierId, double amount, DateTime paymentDate)
	{
		PaymentId = payId;
		CourierId = courierId;
		Amount = amount;
		PaymentDate = paymentDate;
	}

	public override string ToString()
	{
		return $"Payment ID: {PaymentId}\t" +
			$"Courier ID: {CourierId}\t" +
			$"Amount: {Amount}\t" +
			$"Payment date: {PaymentDate}\n";
	}
}
