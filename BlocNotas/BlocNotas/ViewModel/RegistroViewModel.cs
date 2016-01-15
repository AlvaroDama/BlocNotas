using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlocNotas.Factorias;
using BlocNotas.Model;
using BlocNotas.Service;
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

        private Usuario _usuario;

        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            CmdAlta = new Command(GuardarUsuario);
        }

        private async void GuardarUsuario()
        {
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_usuario);
                if (r != null)
                {
                    await _navigator.PushModalAsync<PrincipalViewModel>();
                }
                else
                {
                    var a = "";
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
