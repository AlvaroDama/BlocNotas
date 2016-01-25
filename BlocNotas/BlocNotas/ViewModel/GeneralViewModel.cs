using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotas.Factorias;
using BlocNotas.Service;
using BlocNotas.Util;
using BlocNotas.ViewModel.Base;
using Xamarin.Forms;

namespace BlocNotas.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioDatos _servicio;
        protected Session Session { get; set; }


        public GeneralViewModel(INavigator navigator, IServicioDatos servicio, Session session)
        {
            _servicio = servicio;
            _navigator = navigator;
            Session = session;
        }
    }
}
