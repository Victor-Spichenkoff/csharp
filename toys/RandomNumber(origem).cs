using System;

namespace ORIGEM
{


    public class RandomNumber
    {
        private static int secretNumber = -1;
        private static int currentAttempt;
        private static bool venceu = false;
        private static bool quit = false;

        private static void setRandomNumber()
        {
            Random random = new Random();
            secretNumber = random.Next(1, 101);
        }


        private static void getInputNumber(string dica = "")
        {
            Console.WriteLine("getINput");
            try
            {
                if (dica == "")
                {
                    Console.Write("Tente um número: ");
                }
                else
                {
                    Console.Write($"Digite um número {dica}: ");
                }
                string? res = Console.ReadLine();
                if (res != null)
                {
                    currentAttempt = int.Parse(res);
                }
            }
            catch
            {
                Console.WriteLine("É IDIOTA????");
                getInputNumber(dica);
            }
        }


        private static void ShowTelaVencedor()
        {
            Console.WriteLine("SHOWTELAVENCEDOR");
            Console.Clear();
            Console.WriteLine($"Você acertou, o número era {secretNumber}");
            bool res = getQuitOption();
            if (res)
            {
                Console.WriteLine("ADEUS");
                quit = true;
                Console.WriteLine($"o valor de quit, apos a resposta é {quit}");
                Iniciar();
            }
            else
            {
                Iniciar();
            }
        }


        private static string getDica()
        {
            Console.WriteLine("get Dica");
            CheckVenceu();
            if (venceu)
            {
                ShowTelaVencedor();
                return "";
            }
            if (currentAttempt < secretNumber)
            {
                return "MAIOR";
            }
            else
            {
                return "MENOR";
            }
        }

        private static bool CheckVenceu()
        {
            if (currentAttempt == secretNumber)
            {
                venceu = true;
            }
            else
            {
                venceu = false;
            }
            return venceu;
        }


        private static void Reset()
        {
            secretNumber = -1;
            currentAttempt = -2;
            venceu = false;
        }


        private static void Iniciar()
        {
            Console.WriteLine("Iniciar");
            // setRandomNumber();
            secretNumber = 2;
            getInputNumber();
        }

        private static bool getQuitOption()
        {
            try
            {
                Console.Write("Sair [s/n]");
                string? res = Console.ReadLine();
                return res == "S" || res == "s";
            } catch 
            {
                Console.WriteLine("Muito burro!");
                getQuitOption();
            }
            return true;
        }


        private static void Tentativa()
        {
            Console.WriteLine("TEntativa");
            string dica = getDica();
            getInputNumber(dica);
        }

        public static void Principal()
        // public static void Main()
        {
            Iniciar();

            while (true)
            {
                Console.WriteLine(secretNumber);
                // Console.WriteLine($"Última tentativa: {currentAttempt}");
                Console.WriteLine($"o valor de quité {quit} e venveu é {venceu}");
                if (venceu)
                {
                    getQuitOption();
                    if(quit) {
                        break;
                    }
                }
                Tentativa();
            }
            Console.WriteLine("FIM");
        }
    }

}