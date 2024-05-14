using Microsoft.EntityFrameworkCore;
using Aplicacion.Models;

namespace Aplicacion.Servicios.Contrato
{
    public interface IUsuarioService
    {

        Task<Usuario> GetUsuario(string correo, string clave);

        Task<Usuario> SaveUsuario(Usuario modelo);

    }
}
