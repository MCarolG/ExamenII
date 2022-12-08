using System;
using System.Collections.Generic;
using System.Text;

namespace Logistica.Models
{
    [Serializable]
    public class Maritimo
    {
        public string nombre_service { get; set; }
        public double tiempo_transito { get; set; }
        public DateTime fecha { get; set; }

        public string toString()
        {
            return fecha.ToString("MM-dd-yyyy") + " - " + nombre_service + " - tiempo en transito " + tiempo_transito + " \t\n ";
        }

        public void CalculoSalidas()
        {
            switch (nombre_service)
            {
                case "Gulf Port":
                    tiempo_transito = 5;
                    break;
                case "Jacksonville Port":
                    tiempo_transito = 4;
                    break;
                case "Puerto Rico Port":
                    tiempo_transito = 8;
                    break;
                case "Long beach Port":
                    tiempo_transito = 10;
                    break;
                default:
                    break;
            }
        }

    }
}
