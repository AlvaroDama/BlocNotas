using System;
using System.Threading.Tasks;
using BlocNotas.Model;
using BlocNotas.Util;
using Microsoft.WindowsAzure.MobileServices;

namespace BlocNotas.Service
{
    public class ServicioDatosImpl:IServicioDatos
    {
        private MobileServiceClient _client;

        public ServicioDatosImpl()
        {
            _client = new MobileServiceClient(Cadenas.UrlServicio, Cadenas.TokenServicio);
        }

        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            var tabla = _client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().
                Where(o => o.Login.Equals(us.Login) && o.Password.Equals(us.Password)).
                ToListAsync();

            if (data.Count.Equals(0))
                return null;

            return data[0];
        }

        public async Task<Usuario> AddUsuario(Usuario us)
        {
            var tabla = _client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().
                Where(o => o.Login.Equals(us.Login)).
                ToListAsync();

            if (data.Count>0)
                throw new Exception("Usuario ya registrado");

            try
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception)
            {
                throw new Exception("Error al dar de alta.");
            }

            return us;
        }

        public Task<Usuario> UpdateUsuario(Usuario us)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUsuario(string id)
        {
            throw new NotImplementedException();
        }
    }
}
