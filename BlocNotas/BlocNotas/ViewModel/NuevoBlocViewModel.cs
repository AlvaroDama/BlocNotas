using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BlocNotas.Factorias;
using BlocNotas.Model;
using BlocNotas.Service;
using BlocNotas.Util;
using Xamarin.Forms;

namespace BlocNotas.ViewModel
{
    public class NuevoBlocViewModel:GeneralViewModel
    {
        public ObservableCollection<Bloc> Blocs { get; set; }
        public ICommand CmdGuardar { get; set; }

        public Bloc Bloc
        {
            get { return _bloc; }
            set { SetProperty(ref _bloc, value); }
        }

        private Bloc _bloc;

        public NuevoBlocViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            _bloc = new Bloc();
            CmdGuardar = new Command(Guardar);
        }

        private async void Guardar()
        {

            try
            {
                Bloc.Fecha = DateTime.Now;
                Bloc.IdUsuario = ((Usuario) Session["usuario"]).Id;
                Bloc.Icono = "";
                await _servicio.AddBloc(Bloc);
                Blocs.Add(Bloc);

                await _navigator.PopAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Error", e.Message, "OK");
            }
        }
    }
}