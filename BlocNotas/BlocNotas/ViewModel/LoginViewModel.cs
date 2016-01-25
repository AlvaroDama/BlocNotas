using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BlocNotas.Factorias;
using BlocNotas.Model;
using BlocNotas.Service;
using BlocNotas.Util;
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

        public LoginViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            CmdLogin = new Command(IniciarSesion);
            CmdAlta = new Command(NuevoUsuario);
            Titulo = "Bloc de Notas";
        }

        private async void NuevoUsuario()
        {
            await _navigator.PopToRootAsync();
            await _navigator.PushAsync<RegistroViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo usuario";
            });
        }

        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_login);

                if (us != null)
                {
                    Session["usuario"] = us;
                    var blocs = await _servicio.GetBlocs(us.Id);

                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Mis blocs";
                        viewModel.Blocs = new ObservableCollection<Bloc>(blocs);
                    });
                }
                else
                {
                    var xx = ""; //para comprobar que se haga bien.
                }

                //TODO: aquí navegaríamos a la pantalla principal o daríamos error
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Error", e.Message, "Aceptar");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
