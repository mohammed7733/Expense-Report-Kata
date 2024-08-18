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
            expenseReport.PrintReport(new Expenses(new List<Expense>()));
            Assert.Equal($"Expenses {dateTime}\nMeal expenses: 0\nTotal expenses: 0\n", writer.ToString());
        }

        [Fact]
        public void PrintReport_WithExpenses_WorkAsExpected()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new Breakfast(900),
                new Breakfast(1000),
                new Breakfast(1100),
                new Dinner(4900),
                new Dinner(5000),
                new Dinner(5100),
                new CarRental(2000),
                new Lunch(2900),
                new Lunch(3000),
                new Lunch(3100),
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
                         $"Lunch\t2900\t \n" +
                         $"Lunch\t3000\t \n" +
                         $"Lunch\t3100\tX\n" +
                         $"Meal expenses: 27000\n" +
                         $"Total expenses: 29000\n", writer.ToString());
        }
    }
}