using System;
using System.Collections.Generic;
using System.IO;
using expensereport_csharp;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void PrintReport_WithEmptyExpenses_WorkAsExpected()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            var expenseReport = new ExpenseReport();
            var dateTime = DateTime.Now;
            expenseReport.PrintReport(new Expenses(new List<ExpenseToRemove>()));
            Assert.Equal($"Expenses {dateTime}\nMeal expenses: 0\nTotal expenses: 0\n", writer.ToString());
        }

        [Fact]
        public void PrintReport_WithExpenses_WorkAsExpected()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            var expenseReport = new ExpenseReport();
            var expenses = new List<ExpenseToRemove>
            {
                new() { type = ExpenseType.BREAKFAST, amount = 900 },
                new() { type = ExpenseType.BREAKFAST, amount = 1000 },
                new() { type = ExpenseType.BREAKFAST, amount = 1100 },
                new() { type = ExpenseType.DINNER, amount = 4900 },
                new() { type = ExpenseType.DINNER, amount = 5000 },
                new() { type = ExpenseType.DINNER, amount = 5100 },
                new() { type = ExpenseType.CAR_RENTAL, amount = 2000 },
            };
            var dateTime = DateTime.Now;
            expenseReport.PrintReport(new Expenses(expenses));
            Assert.Equal($"Expenses {dateTime}\n" +
                         $"Breakfast\t900\t \n" +
                         $"Breakfast\t1000\t \n" +
                         $"Breakfast\t1100\tX\n" +
                         $"Dinner\t4900\t \n" +
                         $"Dinner\t5000\t \n" +
                         $"Dinner\t5100\tX\n" +
                         $"Car Rental\t2000\t \n" +
                         $"Meal expenses: 18000\n" +
                         $"Total expenses: 20000\n", writer.ToString());
        }
    }
}