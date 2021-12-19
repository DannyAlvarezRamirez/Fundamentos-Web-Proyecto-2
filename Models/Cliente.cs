using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_2.Models
{
    public class Cliente
    {
        [Key]
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        [Display(Name = "Cedula")]
        public int id_cliente { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Imagen de la idea del cliente del proyecto")]
        [Required]
        public byte[] foto { get; set; }
        public string Convertir_Bytes_Imagen()
        {
            byte[] byteArrayIn = this.foto;
            string imageSrc = "";
            if (byteArrayIn != null)
            {
                string imageBase64 = Convert.ToBase64String(byteArrayIn);
                imageSrc = $"data:image/png;charset=utf-8;base64,{imageBase64}";
            }
            return imageSrc;
        }
        [Display(Name = "Telefono")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        public int telefono { get; set; }
    }//fin clase Cliente
}
