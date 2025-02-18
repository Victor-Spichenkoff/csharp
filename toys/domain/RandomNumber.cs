using System;
//pegar dificuldade
//resetar e iniciar
//Tentar um número


namespace NSRandomNumber
{
    public class RandomNumber
    {
        private static int secretNumber = -1;
        private static int currentAttempt;
        private static bool venceu = false;
        private static bool perdeu = false;
        private static bool quit = false;
        private static int attempsCount = 0;
        private static int maxAttemps = 10;


        public static void Describe()
        {
            Console.Clear();
            Console.WriteLine(@"Você irá tentar descobrir um número entre 1 e 20
- A dificuldade varia de 1 até 10
- 10 significa que você terá apenas 1 tentativa
- 1 significa ter 10 tentativas
- Não se preocupe, você receberá dicas para ajudar a encontrar o número
");
        }

        private static void SetRandomNumber()
        {
            Random random = new Random();
            secretNumber = random.Next(1, 21);
        }


        private static void getCurrentInput(string dica = "")
        {
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
                getCurrentInput(dica);
            }
        }



        private static void GetDifficult() 
        {
            Console.Write("Escolha uma dificuldade [1-10]: ");
            string? res = Console.ReadLine();
            if(res != null) 
            {
                int diffucultRange = int.Parse(res);
                if(diffucultRange < 1 || diffucultRange > 10)
                {
                    Console.WriteLine("NÂO SABE CONTAR?????");
                    GetDifficult();
                    return;
                }

                maxAttemps = 11 - diffucultRange;
            }
        }

        private static string GetDica() 
        {
            CheckVenceu();
            if (venceu || attempsCount == 0)
            {
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

        private static void Iniciar()
        {
            GetDifficult();
            SetRandomNumber();
            currentAttempt = 0;
            venceu = false;
            perdeu = false;
            quit = false;
            attempsCount = 0;

        }

        private static bool GetQuitOption()
        {
            try
            {
                Console.Write("Mais uma? [s/n]: ");
                string? res = Console.ReadLine();
                return res == "n" || res == "N";
            } catch 
            {
                Console.WriteLine("Muito burro!");
                GetQuitOption();
            }
            return false;
        }


        private static void Tentativa()
        {
            Console.Clear();
            Console.WriteLine($"\nVocê tem {maxAttemps - attempsCount} tentativa{(attempsCount<2 ? "" : "s")}");
            if(currentAttempt != 0) Console.WriteLine($"Última tentativa: {currentAttempt}");
            string dica = GetDica();
            getCurrentInput(dica);
            
            attempsCount ++;
            CheckWinOrLose();
        }

        private static void CheckWinOrLose()
        {
            if(currentAttempt == secretNumber)
            {
                venceu = true;
                return;
            }

            if(attempsCount >= maxAttemps)
            {
                perdeu = true;
            }
        }

        private static void ShowWinnerScreen()
        {
            Console.Clear();
            Console.WriteLine($"Você venceu, o número era {secretNumber}");
            Console.WriteLine($"Foram usadas: {attempsCount} jogadas");
        }
        private static void ShowLoserScreen()
        {
            Console.Clear();
            Console.WriteLine($"Você PERDEU, o número era {secretNumber}");
        }



        public static void Principal()
        // public static void Main()
        {
            Iniciar();

            while (true)
            {
                Tentativa();

                Console.WriteLine($"PERDEU {perdeu} MaxAtemps {maxAttemps}, Count {attempsCount}");
                if (venceu)
                {
                    ShowWinnerScreen();
                }

                if(perdeu) 
                {
                    ShowLoserScreen();
                }
                
                if(perdeu || venceu)
                {
                    quit = GetQuitOption();
                    if(quit) {
                        break;
                    }
                    Iniciar();
                }
            }
            Console.WriteLine("ADEUS");
        }
    }

}