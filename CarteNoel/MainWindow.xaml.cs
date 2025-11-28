using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;

namespace CarteNoel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MediaPlayer _player = new MediaPlayer();
        private string[] phrasesNoel;

        public MainWindow()
        {
            InitializeComponent();
            phrasesNoel = new string[]
                   {
            "Joyeux Noël ! Que ta journée soit remplie de magie et de douceur.",
            "Que la paix et la joie de Noël t’accompagnent tout au long de l'année.",
            "Je te souhaite un Noël chaleureux entouré de ceux que tu aimes.",
            "Que l'esprit de Noël illumine ton cœur.",
            "Passe un merveilleux Noël plein de sourires et de bonheur.",
            "Que cette fête t’apporte sérénité et enchantement.",
            "Joyeux Noël ! Que chaque instant soit un cadeau.",
            "Que la magie de Noël brille dans ta vie.",
            "Un très joyeux Noël à toi et à ta famille.",
            "Que ce Noël soit rempli d’amour et de tendresse.",
            "Je te souhaite un Noël doux comme un chocolat chaud.",
            "Que les étoiles de Noël veillent sur ton foyer.",
            "Joyeuses fêtes et plein de belles surprises !",
            "Que le bonheur de Noël remplisse ta maison.",
            "Passe un Noël magnifique rempli de paix.",
            "Que ton réveillon soit aussi beau que ton sourire.",
            "Joyeux Noël, que ton cœur soit léger et heureux.",
            "Que ce Noël t’apporte tout ce que tu espères.",
            "Je te souhaite un Noël magique et scintillant.",
            "Que ton Noël soit aussi merveilleux que toi.",
            "Un Noël plein d’amour, de joie et de rires.",
            "Que ce jour spécial te comble de bonheur.",
            "Joyeux Noël ! Profite de chaque instant précieux.",
            "Que la magie de Noël te réchauffe le cœur.",
            "Un Noël radieux et joyeux rien que pour toi."
                   };
            BloquerBoutonsSelonDate();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int index = int.Parse(btn.Tag.ToString());

            DateTime today = DateTime.Today;
            int jourDecembre = today.Month == 12 ? today.Day : 0;
            int jourBouton = index + 1; // Tag commence à 0

            if (jourBouton > jourDecembre)
            {
                MessageBox.Show($"Vous pouvez ouvrir cette case dans {jourBouton - jourDecembre} jour(s) !");
                return;
            }

            // Texte et image dans la popup
            MessageText.Text = phrasesNoel[index];
            PopupImage.Source = new BitmapImage(new Uri(imagePaths[index], UriKind.Relative));

            // Affiche le popup
            MessageOverlay.Visibility = Visibility.Visible;
        }
        private void MessageOverlay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageOverlay.Visibility = Visibility.Collapsed;
        }
        private string[] imagePaths = new string[]
        {
             "Images/noel1.png",
             "Images/noel2.png",
             "Images/noel3.png",
             "Images/noel4.png",
             "Images/noel5.png",
             "Images/noel6.png",
             "Images/noel7.png",
             "Images/noel8.png",
             "Images/noel9.png",
             "Images/noel10.png",
             "Images/noel11.png",
             "Images/noel12.png",
             "Images/noel13.png",
             "Images/noel14.png",
             "Images/noel15.png",
             "Images/noel16.png",
             "Images/noel17.png",
             "Images/noel18.png",
             "Images/noel19.png",
             "Images/noel20.png",
             "Images/noel21.png",
             "Images/noel22.png",
             "Images/noel23.png",
             "Images/noel24.png",
             "Images/noel25.png"
        };
        private void BloquerBoutonsSelonDate()
        {
            DateTime today = DateTime.Today;
            int jourDecembre = today.Month == 12 ? today.Day : 0; // 0 si pas en décembre

            foreach (var child in BoutonsGrid.Children)
            {
                if (child is Button btn && int.TryParse(((StackPanel)btn.Content).Children[1] is TextBlock tb ? tb.Text : "0", out int jourBouton))
                {
                    if (jourBouton > jourDecembre)
                    {
                        btn.IsEnabled = false; // Bloque le bouton
                        btn.ToolTip = $"Disponible dans {jourBouton - jourDecembre} jour(s)";
                    }
                }
            }
        }


    }
}