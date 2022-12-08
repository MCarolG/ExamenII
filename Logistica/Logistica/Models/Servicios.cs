using System;
using System.Collections.Generic;
using System.Text;

namespace Logistica.Models
{
    [Serializable]
    public class Servicios
    {
        public string nombre_servicio { get; set; }
        public double tiempo_entrega { get; set; }
        public double coordinacion { get; set; }
        public DateTime fecha { get; set; }

        public string toString()
        {
            return fecha.ToString("MM-dd-yyyy") + " - " + nombre_servicio + " - tiempo " + tiempo_entrega + " - entrega " + coordinacion + " \t\n ";
        }

        public void CalcularServicios()
        {

            switch (nombre_servicio)
            {

                case "Almacenaje":
                    coordinacion = 30 * (tiempo_entrega / 60.00);
                    break;
                case "Terrestre":
                    coordinacion = 5 * (tiempo_entrega / 60.00);
                    break;
                case "Aduana":
                    coordinacion = 10 * (tiempo_entrega / 60.00);
                    break;
                case "Aereo":
                    coordinacion = 2 * (tiempo_entrega / 60.00);
                    break;
                default:
                    break;
            }

        }

    }
}
