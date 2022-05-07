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
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10F).ToString("0.0s");
            if(matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐵","🐵",
                "🐶","🐶",
                "🐺","🐺",
                "🦁","🦁",
                "🦒","🦒",
                "🦊","🦊",
                "🦝","🦝",
                "🐸","🐸"
            };

            Random random = new Random();
            
            foreach (TextBlock tb in mainGrid.Children.OfType<TextBlock>()) 
            {
                if (tb.Name != "timeTextBlock")
                {
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    tb.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
                
            
            }

            
            
        }

        private void timerStartGame()
        {
            startGameFirstClick = true;
            if(startGameFirstClick == true)
            {
                timer.Start();
                tenthOfSecondsElapsed = 0;
                matchesFound = 0;
            }
                
            
            
        }


        TextBlock lastTextBoxClicked;
        bool findingMatch = false;
        bool startGameFirstClick = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(startGameFirstClick == false)
            {
                timerStartGame();
            }
            

            TextBlock tb = sender as TextBlock;
            if(findingMatch == false)
            {
                tb.Visibility = Visibility.Hidden;
                lastTextBoxClicked = tb;
                findingMatch = true;
           

            }
            else if (tb.Text == lastTextBoxClicked.Text)
            {
                matchesFound++;
                tb.Visibility = Visibility.Hidden;  
                findingMatch = false;
            }
            else
            {
                lastTextBoxClicked.Visibility = Visibility.Visible;
                findingMatch= false;
            }
        }

        private void TimeTextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }




    }
}
