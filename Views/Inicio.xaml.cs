namespace jherreraT2.Views
{
    public partial class Inicio : ContentPage
    {
        public Inicio(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = $"Usuario Conectado: {usuario}";
        }

        private async void OnCalcularClicked(object sender, EventArgs e)
        {
            if (pickerEstudiante.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(entrySeg1.Text) ||
                string.IsNullOrWhiteSpace(entryExam1.Text) ||
                string.IsNullOrWhiteSpace(entrySeg2.Text) ||
                string.IsNullOrWhiteSpace(entryExam2.Text))
            {
                await DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
                return;
            }

            if (!double.TryParse(entrySeg1.Text, out double seg1) || seg1 < 0 || seg1 > 10 ||
                !double.TryParse(entryExam1.Text, out double exam1) || exam1 < 0 || exam1 > 10 ||
                !double.TryParse(entrySeg2.Text, out double seg2) || seg2 < 0 || seg2 > 10 ||
                !double.TryParse(entryExam2.Text, out double exam2) || exam2 < 0 || exam2 > 10)
            {
                await DisplayAlert("Error", "Las notas deben ser números entre 0 y 10.", "OK");
                return;
            }

            double parcial1 = (seg1 * 0.3) + (exam1 * 0.2);
            double parcial2 = (seg2 * 0.3) + (exam2 * 0.2);
            double notaFinal = parcial1 + parcial2;

            string estado = notaFinal switch
            {
                >= 7 => "Aprobado",
                >= 5 => "Complementario",
                _ => "Reprobado"
            };

            await DisplayAlert("Resultado",
                $"Nombre: {pickerEstudiante.SelectedItem}\n" +
                $"Fecha: {fechaPicker.Date:d}\n" +
                $"Nota Parcial 1: {parcial1:F2}\n" +
                $"Nota Parcial 2: {parcial2:F2}\n" +
                $"Nota Final: {notaFinal:F2}\n" +
                $"Estado: {estado}",
                "Aceptar");
        }

        private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            // Regresar directamente al Login
            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
