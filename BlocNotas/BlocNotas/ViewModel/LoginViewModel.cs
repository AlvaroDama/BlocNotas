using System;
using System.Windows.Input;
using BlocNotas.Factorias;
using BlocNotas.Model;
using BlocNotas.Service;
using BlocNotas.View;
using Xamarin.Forms;

namespace BlocNotas.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        private Usuario _login = new Usuario();

        public string TituloIniciar { get { return "Iniciar sesión"; } }
        public string TituloRegistro { get { return "Nuevo usuario"; } }
        public string TituloLogin { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }
        
        public Usuario Usuario
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            CmdLogin = new Command(IniciarSesion);
            CmdAlta = new Command(() =>
            {
                //new Registro();
            });
        }

        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_login);

                //TODO: aquí navegaríamos a la pantalla principal o daríamos error
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
