namespace expensereport_csharp;

public class CarRental : Expense
{
    public CarRental(int amount)
    {
        Amount = amount;
    }

    public override string Name() => "Car Rental";

    public override bool IsMeal() => false;

    public override bool IsOverExpense() => false;
}