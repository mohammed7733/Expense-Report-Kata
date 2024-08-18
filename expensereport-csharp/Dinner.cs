namespace expensereport_csharp;

public class Dinner : Expense
{
    public Dinner(int amount)
    {
        Amount = amount;
    }

    public override string Name() => "Dinner";

    public override bool IsMeal() => true;

    public override bool IsOverExpense() => Amount > 5000;
}