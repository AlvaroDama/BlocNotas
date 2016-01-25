using System;
using System.Collections.Generic;
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

        #region Usuario

        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            var tabla = _client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().
                Where(o => o.Login == us.Login && o.Password == us.Password).
                ToListAsync();

            return data.Count.Equals(0) ? null : data[0];
        }

        public async Task<Usuario> AddUsuario(Usuario us)
        {
            var tabla = _client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().
                Where(o => o.Login == us.Login).
                ToListAsync();

            if (data.Count > 0)
                throw new Exception("Usuario ya registrado");

            try
            {
                await tabla.InsertAsync(us);
                //us = await ValidarUsuario(us);
            }
            catch (Exception)
            {
                throw new Exception("Error al dar de alta.");
            }

            return us;
        }

        public async Task UpdateUsuario(Usuario us)
        {
            await _client.GetTable<Usuario>().UpdateAsync(us);
        }

        public async Task DeleteUsuario(Usuario us)
        {
            await _client.GetTable<Usuario>().DeleteAsync(us);
        }

        #endregion

        #region Bloc

        public async Task AddBloc(Bloc bloc)
        {
            await _client.GetTable<Bloc>().InsertAsync(bloc);
        }

        public async Task<List<Bloc>> GetBlocs(string usuario)
        {
            return await _client.GetTable<Bloc>().CreateQuery().
                Where(o => o.IdUsuario == usuario).ToListAsync();
        }

        public async Task DeleteBloc(Bloc bloc)
        {
            await _client.GetTable<Bloc>().DeleteAsync(bloc);
        }

        public async Task UpdateBloc(Bloc bloc)
        {
            await _client.GetTable<Bloc>().UpdateAsync(bloc);
        }

        #endregion


    }
}
