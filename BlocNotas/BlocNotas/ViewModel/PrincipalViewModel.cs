using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotas.Factorias;
using BlocNotas.Service;

namespace BlocNotas.ViewModel
{
    public class PrincipalViewModel:GeneralViewModel
    {
        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
        }
    }
}
