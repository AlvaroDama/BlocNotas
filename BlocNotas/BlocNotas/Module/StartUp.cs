using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotas.Factorias;
using BlocNotas.View;
using BlocNotas.ViewModel;
using Xamarin.Forms;

namespace BlocNotas.Module
{
    public class StartUp:AutofacBootstrapper
    {
        private readonly App _app;

        public StartUp(App app)
        {
            _app = app;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<BlocNotasModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, Login>();
            viewFactory.Register<PrincipalViewModel, Principal>();
            viewFactory.Register<RegistroViewModel, Registro>();
            viewFactory.Register<NuevoBlocViewModel, NuevoBloc>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var navPage = new NavigationPage(main); //pone la barra de navegación
            _app.MainPage = navPage;
        }
    }
}
