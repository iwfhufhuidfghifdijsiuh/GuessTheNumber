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

namespace GuessTheNumber
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
   public partial class MainWindow : Window
        {
            private int randomNumber;
            private int attempts;

            public MainWindow()
        {
            InitializeComponent();
            RestartGame();
        }
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputNumber.Text, out int guessedNumber))
            {
                attempts++;
                AttemptsCounterTextBlock.Text = $"Попытки: {attempts}";
                AttemptsListBox.Items.Add(guessedNumber);

                if (guessedNumber < randomNumber)
                {
                    HintTextBlock.Text = "Слишком мало!";
                    InputNumber.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else if (guessedNumber > randomNumber)
                {
                    HintTextBlock.Text = "Слишком много!";
                    InputNumber.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    HintTextBlock.Text = $"Поздравляем, вы угадали число за {attempts} попыток!";
                    InputNumber.IsEnabled = false;
                    CheckButton.IsEnabled = false;
                    InputNumber.BorderBrush = System.Windows.Media.Brushes.Green;
                }

                if (Math.Abs(guessedNumber - randomNumber) <= 5 && guessedNumber != randomNumber)
                {
                    HintTextBlock.Text += " Вы близко!";
                }
            }
            else
            {
                MessageBox.Show("Введите корректное число!");
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            Random rand = new Random();
            randomNumber = rand.Next(1, 1000);
            attempts = 0;

            InputNumber.IsEnabled = true;
            CheckButton.IsEnabled = true;
            InputNumber.Clear();
            HintTextBlock.Text = string.Empty;
            AttemptsCounterTextBlock.Text = "Попытки: 0";
            AttemptsListBox.Items.Clear();
            InputNumber.BorderBrush = System.Windows.Media.Brushes.Gray; 
        }
    }
}