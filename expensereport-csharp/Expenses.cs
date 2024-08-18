using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp;

public class Expenses
{
    public readonly List<Expense> ExpensesList;

    public Expenses(List<Expense> expensesList)
    {
        this.ExpensesList = expensesList;
    }

    public int TotalExpenses() => ExpensesList.Sum(expense => expense.Amount);
    public int MealExpenses() => ExpensesList.Where(expense => expense.IsMeal()).Sum(expense => expense.Amount);
}