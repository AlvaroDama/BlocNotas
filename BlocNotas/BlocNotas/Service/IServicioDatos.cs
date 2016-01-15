using System.Threading.Tasks;
using BlocNotas.Model;

namespace BlocNotas.Service
{
    //lo usaremos para el acceso a los datos mobileService.
    public interface IServicioDatos
    {
        #region Usuario

        Task<Usuario> ValidarUsuario(Usuario us);
        Task<Usuario> AddUsuario(Usuario us);
        Task<Usuario> UpdateUsuario(Usuario us);
        Task DeleteUsuario(string id);

        #endregion


    }
}
