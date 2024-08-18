using System;

namespace expensereport_csharp
{
    public class ExpenseReport
    {
        public void PrintReport(Expenses expenses)
        {
            Console.WriteLine("Expenses " + DateTime.Now);
            PrintExpenses(expenses);
            Console.WriteLine("Meal expenses: " + expenses.MealExpenses());
            Console.WriteLine("Total expenses: " + expenses.TotalExpenses());
        }

        private static void PrintExpenses(Expenses expenses)
        {
            foreach (var expense in expenses.ExpensesList)
            {
                Console.WriteLine(expense.Name() + "\t" + expense.Amount + "\t" + MealOverExpensesMarker(expense));
            }
        }

        private static string MealOverExpensesMarker(Expense expense) =>
            expense.IsOverExpense()
                ? "X"
                : " ";
    }
}