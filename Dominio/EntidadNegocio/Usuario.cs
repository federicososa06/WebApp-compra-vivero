using System.Collections.Generic;

namespace Dominio.EntidadNegocio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        private List<Usuario> Precarga = new List<Usuario>();

        public List<Usuario> PrecargarUsuarios()
        {
            Precarga.Add(new Usuario { Email = "forlan@gmail.com", Contrasenia = "Forlan123" });
            Precarga.Add(new Usuario { Email = "cavani@gmail.com", Contrasenia = "Cavani123" });
            Precarga.Add(new Usuario { Email = "suarez@gmail.com", Contrasenia = "Suarez123" });

            return Precarga;
        }
    }
}