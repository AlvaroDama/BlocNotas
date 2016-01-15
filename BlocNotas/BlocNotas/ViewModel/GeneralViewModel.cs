using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotas.Factorias;
using BlocNotas.Service;
using BlocNotas.ViewModel.Base;
using Xamarin.Forms;

namespace BlocNotas.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioDatos _servicio;

        public GeneralViewModel(INavigator navigator, IServicioDatos servicio)
        {
            _servicio = servicio;
            _navigator = navigator;
        }
    }
}
