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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CarteNoel.views
{
    /// <summary>
    /// Logique d'interaction pour Calendrier.xaml
    /// </summary>

    public partial class Calendrier : UserControl
    {
        private Dictionary<int, string> Messages = new Dictionary<int, string>();
        private DispatcherTimer timer;
        private DateTime Noel = new DateTime(DateTime.Now.Year, 12, 25);
        private string[] phrasesNoel;

        private string PrenomUtilisateur;


        public Calendrier(string prenom)
        {
            InitializeComponent();
           
            DémarrerCompteRebours();
            PrenomUtilisateur = prenom;
            
            WelcomeMessageText.Text = $"Bienvenue {PrenomUtilisateur} !";
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

        }

       

        private void DémarrerCompteRebours()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var restant = Noel - DateTime.Now;

            if (restant.TotalSeconds <= 0)
            {
                CountdownText.Text = "🎁 JOYEUX NOËL !!! 🎁";
                timer.Stop();
            }
            else
            {
                CountdownText.Text = $"Plus que {restant.Days}j {restant.Hours}h {restant.Minutes}m {restant.Seconds}s avant Noël 🎄";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            if (sender is not Button btn) return;

            int jour = int.Parse(btn.Tag.ToString());   // Le numéro réel de la case
            int index = jour - 1;                       // Index pour tableaux (0 → jour 1)

            // ---- 🗓️ Vérification de la date ----
            DateTime today = DateTime.Today;
            int jourDecembre = today.Month == 12 ? today.Day : 0;

            if (jour > jourDecembre)
            {
                MessageBox.Show($"⏳ Vous pourrez ouvrir cette case dans {jour - jourDecembre} jour(s) !");
                return;
            }
            AnimatePopup();
            // ---- 🎁 MET LE MESSAGE DU JOUR ----
            if (phrasesNoel != null && index >= 0 && index < phrasesNoel.Length)
                MessageText.Text = phrasesNoel[index];
            else
                MessageText.Text = $"Voici ton message du jour {jour} ! 🎄";

            // ---- 🖼️ MET L’IMAGE DU JOUR ----
            try
            {
                if (imagePaths != null && index >= 0 && index < imagePaths.Length)
                    PopupImage.Source = new BitmapImage(new Uri(imagePaths[index], UriKind.Relative));
                else
                    PopupImage.Source = new BitmapImage(new Uri($"/Image/noel{jour}.png", UriKind.Relative));
            }
            catch
            {
                PopupImage.Source = null; // En cas d'image manquante
            }

            // ---- ✨ ANIMATION DE LA POPUP ----
            FlipScale.ScaleX = 0;
            var anim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(250));
            FlipScale.BeginAnimation(ScaleTransform.ScaleXProperty, anim);

            // ---- 👀 AFFICHE LA POPUP ----
            MessageOverlay.Visibility = Visibility.Visible;

            // ---- 🎨 Effet visuel sur la case ouverte ----
            btn.Opacity = 0.5;

        }
        private string[] imagePaths = new string[]
        {
            "/Image/noel1.jpg",
            "/Image/noel2.jpg",
            "/Image/noel3.jpg",
            "/Image/noel4.jpg",
            "/Image/noel5.jpg",
            "/Image/noel6.jpg",
            "/Image/noel7.jpg",
            "/Image/noel8.jpg",
            "/Image/noel9.jpg",
            "/Image/noel10.jpg",
            "/Image/noel11.jpg",
            "/Image/noel12.jpg",
            "/Image/noel13.jpg",
            "/Image/noel14.jpg",
            "/Image/noel15.jpg",
            "/Image/noel16.jpg",
            "/Image/noel17.jpg",
            "/Image/noel18.jpg",
            "/Image/noel19.jpg",
            "/Image/noel20.jpg",
            "/Image/noel21.jpg",
            "/Image/noel22.jpg",
            "/Image/noel23.jpg",
            "/Image/noel24.jpg"
        };   

        private void AnimatePopup()
        {
            var animation = new DoubleAnimation
            {
                From = 0,       // invisible horizontalement
                To = 1,         // visible
                Duration = TimeSpan.FromMilliseconds(500),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            FlipScale.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
        }

        private void MessageOverlay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageOverlay.Visibility = Visibility.Collapsed;
        }

    }

}
