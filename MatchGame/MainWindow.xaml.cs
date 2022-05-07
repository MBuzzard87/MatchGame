﻿using System;
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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
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
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];  
                tb.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            
            }
        }


        TextBlock lastTextBoxClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            TextBlock tb = sender as TextBlock;
            if(findingMatch == false)
            {
                tb.Visibility = Visibility.Hidden;
                lastTextBoxClicked = tb;
                findingMatch = true;
           

            }
            else if (tb.Text == lastTextBoxClicked.Text)
            {
                tb.Visibility = Visibility.Hidden;  
                findingMatch = false;
            }
            else
            {
                lastTextBoxClicked.Visibility = Visibility.Visible;
                findingMatch= false;
            }
        }
    }
}
