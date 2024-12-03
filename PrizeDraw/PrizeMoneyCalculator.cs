using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeDraw
{
    public class PrizeMoneyCalculator
    {
        public static int? CalculateTotalPrizeMoney(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
                }

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The specified file does not exist.", filePath);
                }
                int totalPrizeMoney = 0;
                List<int> allOrders = new List<int>();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    if (!int.TryParse(sr.ReadLine(), out int days))
                    {
                        throw new FormatException("Invalid data. The first line must contain a valid integer representing numer of days.");
                    }
                    for (int i = 0; i < days; i++)
                    {
                        string line = sr.ReadLine();
                        if (line == null)
                        {
                            throw new InvalidDataException($"Missing data for day {i + 1}. Ensure the file contains correct data.");
                        }
                        var ordersForTheDay = GetOrdersForTheDay(line);
                        allOrders.AddRange(ordersForTheDay);
                        allOrders.Sort();

                        int prizeMoneyForTheDay = allOrders[allOrders.Count() - 1] - allOrders[0];
                        totalPrizeMoney += prizeMoneyForTheDay;
                        allOrders.RemoveAt(allOrders.Count() - 1);
                        allOrders.RemoveAt(0);

                    }
                }
                return totalPrizeMoney;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        private static List<int> GetOrdersForTheDay(string line)
        {
            //skipping first integer in each line that is no. of orders placed that day
            return line.Split(' ').Skip(1).Select(int.Parse).ToList();
        }
    }
}
