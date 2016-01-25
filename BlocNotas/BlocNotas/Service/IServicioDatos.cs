using System.Collections.Generic;
using System.Threading.Tasks;
using BlocNotas.Model;

namespace BlocNotas.Service
{
    //lo usaremos para el acceso a los datos mobileService.
    public interface IServicioDatos
    {
        #region Usuario

        Task<Usuario> ValidarUsuario(Usuario usuario);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(Usuario usuario);

        #endregion

        #region Bloc

        Task AddBloc(Bloc bloc);
        Task<List<Bloc>> GetBlocs(string usuario);
        Task DeleteBloc(Bloc bloc);
        Task UpdateBloc(Bloc bloc);

        #endregion

    }
}
