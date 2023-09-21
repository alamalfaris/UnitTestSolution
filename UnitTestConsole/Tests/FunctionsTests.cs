namespace UnitTestConsole.Tests
{
    public static class FunctionsTests
    {
        // Naming Convention - ClassName_MethodName_ExpectedResult
        public static void Functions_ReturnPikachuIfZero_ReturnString()
        {
            try
            {
                // Arrange - Go get variables, classes, functions
                int num = 0;
                Functions functions = new Functions();

                // Act - Execute this function
                string result = functions.ReturnPikachuIfZero(num);

                // Assert - Whatever ever is returned is it what you want
                if (result.Equals("PIKACHU!"))
                {
                    Console.WriteLine("PASSED");
                }
                else
                {
                    Console.WriteLine("FAILED");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
