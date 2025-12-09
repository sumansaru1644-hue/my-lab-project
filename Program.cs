using System;

namespace SydneyCoffee
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 5;

			String[] name = new string[n];
			int[] quantity = new int[n];
			String[] reseller = new string[n];
			double[] charge = new double[n];
			double price;
			double min = 9999999;
			String minName = "";
			double max = -1;
			String maxName = "";

			//change 1

			//Console.WriteLine("\t\t\t\tWelcome to use Sydney Coffee Program\n");

			Console.WriteLine("\t\t\t\tWelcome to use Sydney Coffee Program - Updated\n");


			for (int i = 0; i < n; i++)
			{
				Console.Write("Enter customer name: ");
				name[i] = Console.ReadLine();

				quantity[i] = 0;
				do
				{
					Console.Write("Enter the number of coffee beans bags (bag/1kg): ");
					quantity[i] = Convert.ToInt32(Console.ReadLine());

					if (quantity[i] < 1 || quantity[i] > 200)
					{
						Console.WriteLine("Invalid Input!\nCoffee bags between 1 and 200 can be ordered.");
					}
				} while (quantity[i] < 1 || quantity[i] > 200);

				if (quantity[i] <= 5)
				{
					price = 36 * quantity[i];
				}
				else if (quantity[i] <= 15)
				{
					price = 34.5 * quantity[i];
				}
				else
				{
					price = 32.7 * quantity[i];
				}

				Console.Write("Enter yes/no to indicate whether you are a reseller: ");
				reseller[i] = Console.ReadLine();

				// CHANGE 2

				//if (reseller[i] == "yes")
				if (reseller[i].ToLower() == "yes")
				{
					charge[i] = price * 0.8;   // reseller discount
				}
				else
				{
					charge[i] = price;
				}

				// ✅ ADD 10% GST 
				charge[i] = charge[i] * 1.10;

				Console.WriteLine($"The total sales value from {name[i]} is ${charge[i]:F2}");
				Console.WriteLine("-----------------------------------------------------------------------------");

				if (min > charge[i])
				{
					min = charge[i];
					minName = name[i];
				}

				if (max < charge[i])
				{
					max = charge[i];
					maxName = name[i];
				}
			}

			Console.WriteLine("\t\t\t\t\tSummary of sales\n");
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine("-----------------------------------------------------------------------------");

			Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10}",
						"Name", "Quantity", "Reseller", "Charge"));

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10:F2}",
					   name[i], quantity[i], reseller[i], charge[i]));
			}

			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine($"The customer spending most is {maxName} ${max:F2}");
			Console.WriteLine($"The customer spending least is {minName} ${min:F2}");
		}
	}
}
