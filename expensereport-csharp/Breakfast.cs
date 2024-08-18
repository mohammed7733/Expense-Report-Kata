namespace expensereport_csharp;

public class Breakfast : Expense
{
    public Breakfast(int amount)
    {
        Amount = amount;
    }

    public override string Name() => "Breakfast";

    public override bool IsMeal() => true;

    public override bool IsOverExpense() => Amount > 1000;
}