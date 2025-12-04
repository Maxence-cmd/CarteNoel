using CarteNoel.views;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CarteNoel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartAdvent_Click(object sender, RoutedEventArgs e)
        {
            string prenom = UserNameInput.Text;
            if (string.IsNullOrWhiteSpace(prenom))
            {
                MessageBox.Show("Entre ton prénom 🎅");
                return;
            }
            Container.Children.Clear();

            Calendrier calendrier = new Calendrier(prenom);
            Container.Children.Add(calendrier);

            
        }
    }

}