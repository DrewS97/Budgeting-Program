using System;
using System.Collections.Generic;
class MainClass {
  public static void Main (string[] args) {
    List<Expenses> ExpenseList = new List<Expenses>();
    // Creating new Expenses with Name, Budgeted Amount, and Actual Amount

    //read the csv into the Expense List
    // for loop to go through file
      //ExpenseList.Add(value1,value2,value3);

    ExpenseList.Add(new Expenses("House Payment: ", 450, 450));
    ExpenseList.Add(new Expenses("Car Loan: ", 150, 150));
    ExpenseList.Add(new Expenses("Car Insurance: ", 68.98, 68.98));
    ExpenseList.Add(new Expenses("Life Insurance: ", 0, 0));
    ExpenseList.Add(new Expenses("Electric: ", 100, 94.65));
    ExpenseList.Add(new Expenses("Gas (Home): ", 100, 80));
    ExpenseList.Add(new Expenses("Gas (Car): ", 60, 46.45));
    ExpenseList.Add(new Expenses("Groceries: ", 200, 215));
    ExpenseList.Add(new Expenses("Necessities: ", 100, 80));
    ExpenseList.Add(new Expenses("Entertainment: ", 50, 0));
    ExpenseList.Add(new Expenses("Phone: ", 44.33, 44.33));
    ExpenseList.Add(new Expenses("Savings: ", 100, 0));
    ExpenseList.Add(new Expenses("Investments: ", 300, 300));
    ExpenseList.Add(new Expenses("Clothing: ", 100, 45));
    ExpenseList.Add(new Expenses("Eating Out: ", 80, 50));
    ExpenseList.Add(new Expenses("Pick Me Up: ", 60, 100));
    ExpenseList.Add(new Expenses("Annual Payments: ", 180, 180));
    ExpenseList.Add(new Expenses("Day Care: ", 0, 0));
    ExpenseList.Add(new Expenses("Diapers: ", 75, 50));
    ExpenseList.Add(new Expenses("Car Maintenance: ", 50, 50));
    ExpenseList.Add(new Expenses("Next Big Purchase: ", 100, 100));
    ExpenseList.Add(new Expenses("Holidays: ", 50, 80));
    ExpenseList.Add(new Expenses("Unforeseeable Event: ", 150, 150));
    ExpenseList.Add(new Expenses("Internet: ", 91.77, 91.77));
    ExpenseList.Add(new Expenses("Trash: ", 30, 30));
    ExpenseList.Add(new Expenses("Misc: ", 40, 0));
    ExpenseList.Add(new Expenses("Baby Misc: ", 100, 100));
    ExpenseList.Add(new Expenses("Home Maintenance: ", 100, 1000));
    ExpenseList.Add(new Expenses("Home Insurance: ", 70, 70));
    ExpenseList.Add(new Expenses("Water/Sewage: ", 40, 34.50));
    ExpenseList.Add(new Expenses("Computer Security: ", 6, 6));

    //Creates Dictionary
    Dictionary<string, Expenses> dictionaryExpenses = new Dictionary<string, Expenses>();
    //Adds Expenses to Dictionary
    for(int i=0;i<ExpenseList.Count;i++){
      dictionaryExpenses.Add(ExpenseList[i].Name, ExpenseList[i]);
    }

    //Variables used in foreach loop -printed after loop-
    double mostNegative = 0;
    string mostOver = "";
    double totalBA = 0;
    double totalAA = 0;
    double howYouDid = 0;

    Console.WriteLine($"\n----------------------------------------Expenses-----------------------------------------------\n");

    //Print the Dictionary with all values
    foreach (KeyValuePair<string, Expenses> ExpenseKVP in dictionaryExpenses) {
      
      //Sets exp to the values of each expense
      Expenses exp = ExpenseKVP.Value;
      totalBA = totalBA + exp.BudgetedAmount;
      totalAA = totalAA + exp.ActualAmount;

      string words = "Expense - {0} - Budgeted Amount: ${1} - Actual Amount: ${2} - Total: ${3}";
      string line = "-----------------------------------------------------------------------------------------------";

      //Decides colors and prints dictionary
      if (exp.ActualAmount > exp.BudgetedAmount)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(words, exp.Name, exp.BudgetedAmount, exp.ActualAmount, Math.Round(exp.Total, 2));
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(line);

        Console.ResetColor();
      }
      else if (exp.ActualAmount < exp.BudgetedAmount)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(words, exp.Name, exp.BudgetedAmount, exp.ActualAmount, Math.Round(exp.Total, 2));
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(line);

        Console.ResetColor();
      }
      else
      {
        Console.WriteLine(words, exp.Name, exp.BudgetedAmount, exp.ActualAmount, Math.Round(exp.Total, 2));

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(line);

        Console.ResetColor();
      }

      if (exp.Total < mostNegative)
      {
        mostNegative = exp.Total;
        mostOver = exp.Name;
      }
    }

    howYouDid = totalBA - totalAA;

    string ovrUnd = "";

    if (howYouDid > 0)
    {
      ovrUnd = "under";
    }
    else if (howYouDid < 0)
    {
      ovrUnd = "over";
    }
    else
    {
      ovrUnd = "on ";
    }

    howYouDid = Math.Abs(howYouDid);

    Console.WriteLine($"\n----------------------------------------Summation----------------------------------------------\n");

    Console.WriteLine($"The most overbudget Expense was " + mostOver +  "$" + mostNegative);

    Console.WriteLine("The total Budgeted Amount was: $" + totalBA);

    Console.WriteLine("The total Actual Amount was: $" + totalAA);
    
    Console.WriteLine("You were " + ovrUnd + "budget by S" + howYouDid);
  }

}
    
//Class called Expenses with properties
public class Expenses {
  public string Name {get; set;}
  public double BudgetedAmount {get; set;}
  public double ActualAmount {get; set;}
  public double Total {get{return BudgetedAmount - ActualAmount;}}
  

  //Constructor that makes creating objects much easier
  public Expenses(string aName, double aBudgetedAmount, double aActualAmount)
  {
    Name = aName;
    BudgetedAmount = aBudgetedAmount;
    ActualAmount = aActualAmount;
  }
}

