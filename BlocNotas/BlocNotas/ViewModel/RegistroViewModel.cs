using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlocNotas.Factorias;
using BlocNotas.Model;
using BlocNotas.Service;
using BlocNotas.Util;
using Xamarin.Forms;

namespace BlocNotas.ViewModel
{
    public class RegistroViewModel:GeneralViewModel
    {
        public ICommand CmdAlta { get; set; }

        public Usuario Usuario
        {
            get{return _usuario;}
            set{SetProperty(ref _usuario, value);}
        }

        private Usuario _usuario = new Usuario();

        public RegistroViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            CmdAlta = new Command(GuardarUsuario);
        }

        private async void GuardarUsuario()
        {
            _usuario.Avatar = "";
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_usuario);
                if (r != null)
                {
                    Session["usuario"] = r;
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Mis blocs";
                        viewModel.Blocs = new ObservableCollection<Bloc>();
                    });
                }
                else
                {
                    var a = "";
                }
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
