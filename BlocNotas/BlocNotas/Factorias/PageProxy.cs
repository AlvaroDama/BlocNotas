using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlocNotas.Factorias
{
    public class PageProxy:IPage
    {
        private readonly Func<Page> _page;

        public PageProxy(Func<Page> page)
        {
            _page = page;
        }
         
        public INavigation Navigation { get { return _page().Navigation; } }
    }
}
