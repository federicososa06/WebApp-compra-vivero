using Dominio.EntidadNegocio;
using Dominio.InterfacesRepositorios;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public Context Db { get; set; }

        public RepositorioUsuario(Context ct)
        {
            Db = ct;
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            return Db.Usuarios.Where(u => u.Email == email).FirstOrDefault();
        }

        public bool ValidarCredenciales(string email, string contra)
        {
            Usuario buscado = BuscarUsuarioPorEmail(email);
            if (buscado.Contrasenia == contra)
                return true;
            else
                return false;
        }

        public bool PrecargarUsusarios()
        {
            Usuario usu = new Usuario();
            List<Usuario> lista = usu.PrecargarUsuarios();


            for (int i = 0; i < lista.Count(); i++)
            {
                //validar que no existan los ususarios
                if (BuscarUsuarioPorEmail(lista[i].Email) == null)
                {
                    Db.Usuarios.Add(lista[i]);
                    Db.SaveChanges();
                }
            }

            return true;
        }
    }
}