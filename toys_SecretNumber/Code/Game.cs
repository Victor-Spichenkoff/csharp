using System;

namespace GameSecretNumber
{
    public class Game
    {
        private static int secretNumber;
        
        public static void SetRandomNumber()
        {
            Random rand = new Random();
            secretNumber = rand.Next(1, 21);
        }

        public static int GetRandomNumber()
        {
            return secretNumber;
        }

        public static string GetHint(int attemp)
        {
            if (attemp < secretNumber)
            {
                return "Tente um número maior";
            }
            else
            {
                return "Tente um número menor";
            }
        }


        public static bool Check(int attemp)
        {
            if(attemp == secretNumber) return true;

            return false;
        }
    }
}
