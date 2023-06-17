using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace RegistroUsuarios.Models
{
    public class Palindromo
    {

        [Required]
        [Key]
        public string Texto { get; set; }
        public IEnumerable<Palindromo> Palindromos { get;  set; }
        public int CantidadPalindromos { get;  set; }
    }
}
