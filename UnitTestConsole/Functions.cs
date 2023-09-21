namespace UnitTestConsole
{
    public class Functions
    {
        public string ReturnPikachuIfZero(int num)
        {
            if (num.Equals(0))
            {
                return "PIKACHU!";
            }
            else
            {
                return "Bulbasaur";
            }
        } 
    }
}
