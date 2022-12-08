using Logistica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Logistica.ViewModels
{
    public class ViewModelMaritimo : INotifyPropertyChanged
    {
        public ViewModelMaritimo()
        {

            AbrirArchivo();


            CrearSalida = new Command( () => {

                Maritimo s1 = new Maritimo ()
                {
                    nombre_service = this.service,
                    fecha = this.fechaSalida

                };

                s1.CalculoSalidas();
                p.lista_maritimo.Add(s1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Resultado = "";

                foreach (Maritimo s in p.lista_maritimo)
                {

                    Resultado += s.toString();

                }
            });

        }

        private void AbrirArchivo()
        {

            // Es una estructura 

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                p = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                Resultado = "";

                foreach (Maritimo x in p.lista_maritimo)
                {

                    Resultado += x.toString();

                }

            }
            catch (Exception e)
            {


            }

        }


        string resultado;

        public string Resultado
        {

            get => resultado;
            set
            {

                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }

        }

        Persona p = new Persona();

        string service;

        public string Service
        {

            get => service;
            set
            {

                service = value;
                var args = new PropertyChangedEventArgs(nameof(Service));
                PropertyChanged?.Invoke(this, args);

            }

        }


        DateTime fechaSalida = DateTime.Today;

        public DateTime FechaSalida
        {

            get => fechaSalida;
            set
            {

                fechaSalida = value;
                var args = new PropertyChangedEventArgs(nameof(FechaSalida));
                PropertyChanged?.Invoke(this, args);

            }

        }

        DateTime fechaMin = DateTime.Today;

        public DateTime FechaMin
        {
            get => fechaMin;
            set
            {

                fechaMin = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaMin));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public Command CrearSalida { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
