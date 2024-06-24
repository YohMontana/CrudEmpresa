using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpresa
{
    internal class Empresa
    {
        private string ruc;
        private string razon;
        private string direccion;

        public Empresa(string ruc, string raz, string direc)
        {
            this.ruc = ruc;
            this.razon = raz;
            this.direccion = direc;
        }

        public string Ruc { get => ruc; set => ruc = value; }
        public string Razon { get => razon; set => razon = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        public void Mostrar()
        {
            Console.WriteLine($"Ruc : {this.ruc}");
            Console.WriteLine($"Razon Social : {this.razon}");
            Console.WriteLine($"Dirección : {this.direccion}");
        }

        public string ToCsv()
        {
            return $"{this.Ruc}, {this.Razon}, {this.Direccion}";
        }

        public static Empresa FromCsv(string csvLine )
        {
            string[] values = csvLine.Split(',');
            if(values.Length != 3)
            {
                throw new ArgumentException("El formato csv no es valido");
            }
            return new Empresa(values[0], values[1], values[2]);
        }
    }
}
