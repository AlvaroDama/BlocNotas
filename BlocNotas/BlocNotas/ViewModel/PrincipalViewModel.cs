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
    public class PrincipalViewModel:GeneralViewModel
    {
        private ObservableCollection<Bloc> _blocs;  //al agregar nuevos datos a la lista, 
                                                    //este tipo hace que se refresque automáticamente

        public ICommand CmdNuevo { get; set; }

        public ObservableCollection<Bloc> Blocs
        {
            get { return _blocs; }
            set
            {
                SetProperty(ref _blocs, value);
            }
        }

        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            CmdNuevo = new Command(NuevoBloc);
        }

        private async void NuevoBloc()
        {
            await _navigator.PushAsync<NuevoBlocViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo bloc";
                viewModel.Blocs = Blocs;
            });
        }
    }
}
