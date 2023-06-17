using System.Security.Cryptography;
using System.Text;

namespace RegistroUsuarios.Recursos
{
    public class Utilidades
    {
        public static string EncriptarClave(string clave) {
        
            StringBuilder sb = new StringBuilder();

            using(SHA256 sha256 = SHA256.Create()){


                byte[] inputBytes = Encoding.UTF8.GetBytes(clave);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }


            }
            return sb.ToString();
        }
    }
}
