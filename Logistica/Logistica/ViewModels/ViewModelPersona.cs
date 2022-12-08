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
    public class ViewModelPersona : INotifyPropertyChanged
    {
        public ViewModelPersona()
        {

            AbrirArchivo();


            CrearPersona = new Command(() => {

                p = new Persona()
                {

                    Name = this.name,
                    Empresa = this.empresa,
                    Id = this.id,
                    Pais = this.pais

                };
                //Rutina de Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

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

                Name = p.Name;
                Empresa = p.Empresa;
                Id = p.Id;
                Pais = p.Pais;
            }
            catch (Exception e)
            {

            }

        }

        Persona p = new Persona();

        string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                var arg = new PropertyChangedEventArgs(nameof(Name));
                PropertyChanged?.Invoke(this, arg);

            }
        }

       
        string empresa;

        public string Empresa
        {
            get => empresa;
            set
            {
                empresa = value;
                var arg = new PropertyChangedEventArgs(nameof(Empresa));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string id;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                var arg = new PropertyChangedEventArgs(nameof(Id));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        String pais;

        public string Pais
        {
            get => pais;
            set
            {
                pais = value;
                var arg = new PropertyChangedEventArgs(nameof(Pais));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        public Command CrearPersona { get; }

        public event PropertyChangedEventHandler PropertyChanged;

    }

}
