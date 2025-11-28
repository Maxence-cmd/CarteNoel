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
using System.Windows.Shapes;

namespace CarteNoel
{

    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
     
    public partial class Window1 : Window
    {
        private MediaPlayer musiquePlayer = new MediaPlayer();
        public Window1()
        {
            InitializeComponent();
            musiquePlayer.Open(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Son", "sonFond.mp3"), UriKind.Absolute));
            musiquePlayer.MediaEnded += (s, e) => musiquePlayer.Position = TimeSpan.Zero;
            musiquePlayer.Play();

        }

        private void StartAdvent_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
