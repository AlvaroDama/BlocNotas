using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotas.Factorias;
using BlocNotas.Service;
using Xamarin.Forms;

namespace BlocNotas.Module
{
    public class BlocNotasModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>().As<IServicioDatos>().SingleInstance();
            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = Application.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : Application.Current.MainPage;

                var navigation = page as IPageContainer<Page>;

                return navigation != null ? navigation.CurrentPage : page;
            });
        }
    }
}
