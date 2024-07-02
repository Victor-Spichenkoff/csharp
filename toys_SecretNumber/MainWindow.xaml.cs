using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameSecretNumber;

namespace toys_SecretNumber
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int attempsCount = 10;
        private static bool isFinished = false;
        int currentAttemp;


        public MainWindow()
        {
            InitializeComponent();
            numberInput.Focus();
            Game.SetRandomNumber();
        }

        private void enter(object sender, KeyEventArgs e)
        {

        }

        private void Lose()
        {
            attempsLabel.Content = "Sem jogadas";
            status.Content = $"O número era {Game.GetRandomNumber()}";
        }        
        
        private void Winner()
        {
            dica.Content = "Parábens!!!!!!";
            status.Content = $"O número era {Game.GetRandomNumber()}";
            btn.Content = "Reiniciar";
            isFinished = true;
        }

        private void Reset()
        {
            numberInput.Focus();
            Game.SetRandomNumber();
            btn.Content = "Tentar";
            dica.Content = "DICA";
            attempsCount = 10;
            attempsLabel.Content = $"Tentativas: {attempsCount}";
            status.Content = "STAUS";
            numberInput.Focus();
            numberInput.Text = "";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isFinished)
            {
                Reset();

                return;
            }

            try
            {
                currentAttemp = int.Parse(numberInput.Text);
                if (currentAttemp < 0 || currentAttemp > 20) throw new Exception("Erro");
            }
            catch
            {
                MessageBox.Show("Não sabe escrever????");
                return;
            }
            bool isWinner = Game.Check(currentAttemp);

            attempsCount -= 1;
            attempsLabel.Content = $"Tentativas: {attempsCount}";
            if (attempsCount == 0)
            {
                Lose();
                return;
            }


            if (isWinner)
            {
                status.Content = Game.GetRandomNumber();
                Winner();
                return;
            }

            dica.Content = Game.GetHint(currentAttemp);
            status.Content = $"Última tentativa: {currentAttemp}";

            numberInput.Focus();
            numberInput.Text = "";
        }


        private void InputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
