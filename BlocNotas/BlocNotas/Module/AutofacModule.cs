using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotas.Factorias;
using Xamarin.Forms;

namespace BlocNotas.Module
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance(); //singleton

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            builder.Register(ctx => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}
