using Microsoft.EntityFrameworkCore;
using Aplicacion.Models;
using Aplicacion.Servicios.Contrato;

namespace Aplicacion.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {

        private readonly DBPRUEBAContext _dbContext;

        public UsuarioService(DBPRUEBAContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u=>u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
