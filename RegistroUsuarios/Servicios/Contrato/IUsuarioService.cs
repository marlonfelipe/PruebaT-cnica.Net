using Microsoft.EntityFrameworkCore;
using RegistroUsuarios.Models;

namespace RegistroUsuarios.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
