using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotas.Factorias;
using BlocNotas.Model;
using BlocNotas.Service;

namespace BlocNotas.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        private Usuario _login = new Usuario();

        public string TituloIniciar { get { return "Iniciar sesión"; } }
        public string TituloRegistro { get { return "Nuevo usuario"; } }
        public string TituloLogin { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }
        
        public Usuario Usuario
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
        }
    }
}
