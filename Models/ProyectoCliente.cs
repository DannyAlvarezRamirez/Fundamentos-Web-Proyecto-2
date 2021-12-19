using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_2.Models
{
    public class ProyectoCliente
    {
        //atributos, referencias, instancias
        private decimal precioColones = 0;
        private decimal precioDolares = 0;

        [Key]
        [Display(Name = "ID Proyecto")]
        public int id_proyecto { get; set; }
        [StringLength(60, MinimumLength = 10, ErrorMessage = "El nombre no puede mas largo que 60 caracteres y menos que 10")]
        [Display(Name = "Nombre del Proyecto")]
        public string nombre { get; set; }
        [Display(Name = "ID Cliente")]
        [ForeignKey("id_cliente")]
        public int id_cliente { get; set; }
        [Range(1, 6)]
        [Display(Name = "Cantidad de Dormitorios")]
        public int cantidad_dormitorios { get; set; }
        [Range(1, 5)]
        [Display(Name = "Cantidad de Banos Completos")]
        public int cantidad_banos { get; set; }
        [Range(1, 3)]
        [Display(Name = "Cantidad de Medios Banos")]
        public int cantidad_medios_banos { get; set; }

        /// <summary>
        /// campos string y convertirlos a int para formula costos finales
        /// </summary>
        [Display(Name = "Terraza")]
        public string terraza { get; set; }
        [Display(Name = "Tipo de Piso")]
        public string tipo_piso { get; set; }
        [Display(Name = "Muebles de Cocina")]
        public string mueble_cocina { get; set; }
        [Display(Name = "Metros de construccion aproximado")]
        public string metros_construccion { get; set; }
        public int Terraza()
        {
            int valor = 0;
            if (this.terraza.Equals("Pequena"))
            {
                valor = 0;
            }
            else if (this.terraza.Equals("Mediana"))
            {
                valor = 1;
            }
            else
            {
                valor = 2;
            }
            return valor;
        }
        public int TipoDePiso()
        {
            int valor = 0;
            if (this.tipo_piso.Equals("Concreto Lujado"))
            {
                valor = 0;
            }
            else if (this.tipo_piso.Equals("Porcelanato"))
            {
                valor = 1;
            }
            else
            {
                valor = 2;
            }
            return valor;
        }
        public int MuebleDeCocina()
        {
            int valor = 0;
            if (this.mueble_cocina.Equals("Granito"))
            {
                valor = 0;
            }
            else if (this.mueble_cocina.Equals("Cuarzo"))
            {
                valor = 1;
            }
            else
            {
                valor = 2;
            }
            return valor;
        }
        public int MetrosDeConstruccionAproximado()
        {
            int valor = 0;
            if (this.mueble_cocina.Equals("De_50m2_a_80m2"))
            {
                valor = 0;
            }
            else if (this.mueble_cocina.Equals("De_80m2_a_100m2"))
            {
                valor = 1;
            }
            else if (this.mueble_cocina.Equals("De_100m2_a_150m2"))
            {
                valor = 2;
            }
            else if (this.mueble_cocina.Equals("De_150m2_a_200m2"))
            {
                valor = 3;
            }
            else
            {
                valor = 4;
            }
            return valor;
        }

        /// <summary>
        /// atributos booleanos(int, 0=false y 1=true) y convertirlos a int(2=si, 3=no) para formula costos finales
        /// </summary>
        [Display(Name = "La sala esta integrada con la cocina")]
        public int esta_sala_integrada_cocina { get; set; }
        [Display(Name = "El area de pilas es abierta")]
        public int esta_area_pila_abierta { get; set; }
        public int ConvertirSalaEstaIntegradaConLaCocina()
        {
            int valor = 0;
            if (esta_sala_integrada_cocina == 1)
            {
                valor = 2;
            }//fin if true
            else
            {
                valor = 3;
            }//fin else false
            return valor;
        }//fin ConvertirSalaEstaIntegradaConLaCocina
        public int ConvertirAreaDePilasEsAbierta()
        {
            int valor = 0;
            if (esta_area_pila_abierta == 1)
            {
                valor = 2;
            }//fin if true
            else
            {
                valor = 3;
            }//fin else false
            return valor;
        }//fin ConvertirAreaDePilasEsAbierta
        public string ConvertirRespuestaSalaIntegradaCocina()
        {
            string valor = "";
            if (esta_sala_integrada_cocina == 1)
            {
                valor = "Si";
            }//fin if true
            else
            {
                valor = "No";
            }//fin else false
            return valor;
        }//fin ConvertirRespuestaSalaIntegradaCocina
        public string ConvertirRespuestaAreaPilasAbierta()
        {
            string valor = "";
            if (esta_area_pila_abierta == 1)
            {
                valor = "Si";
            }//fin if true
            else
            {
                valor = "No";
            }//fin else false
            return valor;
        }//fin ConvertirRespuestaAreaPilasAbierta

        /// <summary>
        /// costos finales y enviarlos a la base de datos
        /// </summary>
        [Display(Name = "Costo Final Colones")]
        public decimal precio_metros_cuadrados_colones { get; set; }
        [Display(Name = "Costo Final Dolares")]
        public decimal precio_metros_cuadrados_dolares { get; set; }
        public decimal CostoFinalColones()
        {
            this.precioColones =
                ((cantidad_dormitorios + cantidad_banos + cantidad_medios_banos +
                (Terraza()) + (TipoDePiso()) + (MuebleDeCocina())) +
                (ConvertirSalaEstaIntegradaConLaCocina() + ConvertirAreaDePilasEsAbierta() * 
                (MetrosDeConstruccionAproximado())))
                * 20000;
            return this.precioColones;
        }
        public decimal CostoFinalDolares()
        {
            this.precioDolares = CostoFinalColones()/626;
            return this.precioDolares;
        }
        
    }//fin clase ProyectoCliente
}
