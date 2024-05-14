using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Aplicacion.Recursos
{
    public class Utilidades
    {
        public static string EncriptarClave(string clave){
                   
                StringBuilder sb = new StringBuilder();

                using (SHA256 Hash = SHA256Managed.Create()){          
                Encoding enc = Encoding.UTF8;

                    byte[] result = Hash.ComputeHash(enc.GetBytes(clave));

                    foreach (byte b in result)
                        sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
        }
    }

}


