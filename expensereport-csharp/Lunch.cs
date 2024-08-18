namespace expensereport_csharp;

public class Lunch : Expense
{
    public Lunch(int amount)
    {
        Amount = amount;
    }

    public override string Name() => "Lunch";

    public override bool IsMeal() => true;

    public override bool IsOverExpense() => Amount > 3000;
}