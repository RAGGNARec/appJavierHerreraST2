namespace jherreraT2.Views
{
    public partial class Login : ContentPage
    {
        // Vectores de usuarios y contrase�as
        private string[] users = { "Carlos", "Ana", "Jose" };
        private string[] passwords = { "carlos123", "ana123", "jose123" };

        public Login()
        {
            InitializeComponent();
        }

        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text?.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                await DisplayAlert("Advertencia", "Por favor ingresa usuario y contrase�a.", "OK");
                return;
            }

            // Buscar si el usuario y la contrase�a coinciden
            int index = Array.IndexOf(users, usuario);
            if (index >= 0 && passwords[index] == contrasena)
            {
                await Navigation.PushAsync(new Inicio(usuario));
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contrase�a incorrectos.", "OK");
            }
        }
    }
}
