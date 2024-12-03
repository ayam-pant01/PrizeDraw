namespace PrizeDraw.Tests
{
    public class PrizeDrawTests
    {
        [Fact]
        public void CalculateTotalPrizeMoney_ValidInput_ReturnsCorrectPrizeMoney()
        {
            string testInput = "3\n5 10 20 30 40 50\n4 5 15 25 35\n3 10 30 40";
            string filePath = "test_input.txt";
            File.WriteAllText(filePath, testInput);

            int? result = PrizeMoneyCalculator.CalculateTotalPrizeMoney(filePath);

            Assert.Equal(105, result); 

            File.Delete(filePath);
        }

        [Fact]
        public void CalculateTotalPrizeMoney_NoOrders_ReturnsNull()
        {
            string testInput = "1\n0";
            string filePath = "test_input.txt";
            File.WriteAllText(filePath, testInput);

            int? result = PrizeMoneyCalculator.CalculateTotalPrizeMoney(filePath);

            Assert.Null(result);

            File.Delete(filePath);
        }
    }


}