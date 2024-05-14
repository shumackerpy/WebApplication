using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Aplicacion.Controllers
{
    public class UsuarioViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Obtener el nombre de usuario del contexto de usuario actual
            string nombreUsuario = User.Identity.Name;

            return View((object)nombreUsuario);
        }
    }
}
