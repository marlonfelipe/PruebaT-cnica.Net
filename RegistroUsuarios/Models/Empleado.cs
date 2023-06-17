using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RegistroUsuarios.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DPI { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        public int? CantidadHijos { get; set; }

        public decimal? SalarioBase { get; set; }

        [HiddenInput]
        [Display (Name = "Bono Decreto")]
        public decimal? BonoDecreto { get; set; }

        [HiddenInput]

        public string Usuario { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacion { get; set; }

        [HiddenInput]
        public decimal? Igss { get; set; }
        [HiddenInput]
        public decimal? Irtra { get; set; }
        [HiddenInput]
        public decimal? BonoPaternidad { get; set; }
        [HiddenInput]
        public decimal? SalarioTotal { get; set; }
        [HiddenInput]
        public decimal? SalarioLiquido { get; set; }

        public Empleado()
        {
            BonoDecreto = 250;
        }

        public void CalcularValores()
        {
            Igss = SalarioBase * 0.0483m;
            Irtra = SalarioBase  * 0.01m;
            BonoPaternidad = 133 * CantidadHijos;
            SalarioTotal = SalarioBase + BonoPaternidad + BonoDecreto;
            SalarioLiquido = SalarioTotal - Igss - Irtra;

        }




    }
}
