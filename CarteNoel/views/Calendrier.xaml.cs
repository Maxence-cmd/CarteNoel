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

namespace CarteNoel.views
{
    /// <summary>
    /// Logique d'interaction pour Calendrier.xaml
    /// </summary>

   
    public partial class Calendrier : UserControl
    {
        private Timer timer;
        private DateTime noel = new DateTime(DateTime.Now.Year, 12, 25);

        private List<(string Message, string ImagePath)> cartes = new List<(string, string)>
        {
            ("Joyeux 1er décembre !", "Images/noel1.png"),
            ("Bonne journée du 2 !", "Images/noel2.png"),
            // ... jusqu'au 24
        };

        public Calendrier()
        {
            InitializeComponent();
            SetupCards();
            StartCountdown();
        }

        private void SetupCards()
        {
            int i = 0;
            foreach (Button btn in FindVisualChildren<Button>(this))
            {
                int jour = i + 1;
                if (i < cartes.Count)
                {
                    btn.DataContext = new { Jour = jour, Image = cartes[i].ImagePath };
                    btn.Click += (s, e) =>
                    {
                        MessageBox.Show(cartes[jour - 1].Message, $"Jour {jour}");
                    };
                }
                i++;
            }
        }
}
