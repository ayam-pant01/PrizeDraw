using PrizeDraw;

string basedirectory = AppDomain.CurrentDomain.BaseDirectory;
string filePath = Path.Combine(basedirectory, "inputfile.txt");
int? totalPrizeMoney = PrizeMoneyCalculator.CalculateTotalPrizeMoney(filePath);
Console.WriteLine(totalPrizeMoney);
Console.ReadLine();