using System.Text;

namespace genhaslo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnGenerujClicked(object sender, EventArgs e)
        {
            int.TryParse(dlugoscEntry.Text, out int dlugosc);
            if (dlugosc <= 0) return;

            string male = "abcdefghijklmnopqrstuvwxyz";
            string wielkie = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cyfry = "0123456789";
            string znaki = "!@#$%^&*()";

            StringBuilder dostepne = new StringBuilder();
            if (maleWielkieCheck.IsChecked == true)
                dostepne.Append(male + wielkie);
            if (cyfryCheck.IsChecked == true)
                dostepne.Append(cyfry);
            if (znakiSpecjalneCheck.IsChecked == true)
                dostepne.Append(znaki);

            if (dostepne.Length == 0)
            {
                wygenerowaneHaslo.Text = "Wybierz przynajmniej jedną opcję.";
                return;
            }

            var rnd = new Random();
            var haslo = new StringBuilder();
            for (int i = 0; i < dlugosc; i++)
            {
                int index = rnd.Next(dostepne.Length);
                haslo.Append(dostepne[index]);
            }

            wygenerowaneHaslo.Text = haslo.ToString();
        }

        private void OnZatwierdzClicked(object sender, EventArgs e)
        {
            string komunikat = $"Dane pracownika:\n" +
                               $"Imię: {imieEntry.Text}\n" +
                               $"Nazwisko: {nazwiskoEntry.Text}\n" +
                               $"Stanowisko: {stanowiskoPicker.SelectedItem}\n" +
                               $"Hasło: {wygenerowaneHaslo.Text}";
            DisplayAlert("Zatwierdzono", komunikat, "OK");
        }
    }
}
