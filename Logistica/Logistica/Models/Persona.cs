using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Logistica.Models
{
    [Serializable]
    public class Persona
    {
        public string Name { get; set; }
        public string Empresa { get; set; }
        public string Id { get; set; }
        public string Pais { get; set; }

        public ObservableCollection<Maritimo> lista_maritimo { get; set; } = new ObservableCollection<Maritimo>();
        public ObservableCollection<Servicios> lista_servicios { get; set; } = new ObservableCollection<Servicios>();

    }
}
