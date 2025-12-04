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

        public Calendrier()
        {
            InitializeComponent();
            ChargerMessages();
            DémarrerCompteRebours();
        }

        private void ChargerMessages()
        {
            Messages.Add(1, "Premier sourire de Noël 🎅");
            Messages.Add(2, "Un chocolat chaud pour toi ☕");
            Messages.Add(3, "Une chanson de Noël 🎵");
            Messages.Add(4, "Un câlin magique 🤗");
            Messages.Add(5, "Un flocon de bonheur ❄️");
            Messages.Add(6, "Une surprise se prépare 🎁");
            Messages.Add(7, "Une lumière dans la nuit ✨");
            Messages.Add(8, "Une pensée positive 💭");
            Messages.Add(9, "Un vœu secret 🤍");
            Messages.Add(10, "Un moment cocooning 🕯️");
            Messages.Add(11, "Une douceur sucrée 🍬");
            Messages.Add(12, "Une joie partagée 🎊");
            Messages.Add(13, "De la magie dans l’air 🪄");
            Messages.Add(14, "Un sourire offert 😊");
            Messages.Add(15, "Une surprise approche 🎅");
            Messages.Add(16, "Un peu de rêve 🌙");
            Messages.Add(17, "Un chant de Noël 🎶");
            Messages.Add(18, "De la neige dans le cœur ❄️");
            Messages.Add(19, "Un souhait magique 🎁");
            Messages.Add(20, "Une étincelle de joie ✨");
            Messages.Add(21, "Bientôt le jour tant attendu 🎄");
            Messages.Add(22, "Le Père Noël approche 🎅");
            Messages.Add(23, "La magie est presque là 🎁");
            Messages.Add(24, "Demain… C’EST NOËL 🎄🎉");
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

        private void Jour_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && int.TryParse(btn.Tag.ToString(), out int jour))
            {
                if (DateTime.Now.Day < jour)
                {
                    MessageBox.Show("⏳ Patience... Ce jour n'est pas encore arrivé !");
                    return;
                }

                if (Messages.ContainsKey(jour))
                {
                    MessageBox.Show(Messages[jour], $"Jour {jour}", MessageBoxButton.OK, MessageBoxImage.Information);
                    btn.IsEnabled = false;
                    btn.Opacity = 0.5;
                }
            }
        }

    }

}
