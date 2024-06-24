using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpresa
{
    internal class EmpresaCRUD
    {
        private List<Empresa> listaEmpresa = new List<Empresa>();
        private MensajeUI mensaje = new MensajeUI(50);
        private const string FilePath = "EmpresasRegistradas.csv";

        public EmpresaCRUD()
        {
            //Empresa empresaMuestra = new Empresa("2045449861", "JJV PLANT", "Av. El Sol");
            //listaEmpresa.Add(empresaMuestra);
            this.CargarEmpresas();
        }

        public void MostrarEmpresas()
        {
            this.mensaje.mostrarEncabezado("RELACION DE EMPRESAS");
            foreach (var empresa in listaEmpresa)
            {
                Console.WriteLine(new string('*', 50));
                empresa.Mostrar();
            }            
        }

        public void RegistrarEmpresa()
        {
            this.mensaje.mostrarEncabezado("REGISTRO DE NUEVA EMPRESA");
            Console.WriteLine("RUC : ");
            string ruc = Console.ReadLine();
            Console.WriteLine("RAZON SOCIAL : ");
            string razon = Console.ReadLine();
            Console.WriteLine("DIRECCIÓN : ");
            string direcc = Console.ReadLine();

            Empresa nuevaEmpresa = new Empresa(ruc, razon, direcc);
            listaEmpresa.Add(nuevaEmpresa);
            this.mensaje.mostrarAlerta("EMPRESA registrada con EXITO!!!");
        }

        private Empresa BuscarEmpresa(string opcion)
        {
            Console.WriteLine($"{opcion} EMPRESA");
            Console.WriteLine($"INGRESE LA RUC DE LA EMPRESA A {opcion}: ");
            string ruc = Console.ReadLine() ;

            Empresa empresa = listaEmpresa.Find(a => a.Ruc.Equals(ruc, StringComparison.OrdinalIgnoreCase));
            return empresa;
        }

        public void ActualizarEmpresa()
        {
            Empresa empresa = this.BuscarEmpresa("ACTUALIZAR");
            if (empresa != null)
            {
                Console.WriteLine("NUEVO RUC : ");
                string nuevoRuc = Console.ReadLine();
                Console.WriteLine("NUEVA RAZON SOCIAL : ");
                string nuevoRaz = Console.ReadLine();
                Console.WriteLine("NUEVA DIRECCION : ");
                string nuevoDirecc = Console.ReadLine();

                empresa.Ruc = nuevoRuc;
                empresa.Razon = nuevoRaz;
                empresa.Direccion = nuevoDirecc;

                this.mensaje.mostrarAlerta("EMPRESA ACTUALIZADA CON EXITO!!!");
            }
            else
            {
                this.mensaje.mostrarAlerta("EMPRESA NO ENCONTRADA...");
            }
        }

        public void EliminarEmpresa()
        {
            Empresa empresa = this.BuscarEmpresa("ELIMINAR");
            if(empresa != null)
            {
                listaEmpresa.Remove(empresa);
                this.mensaje.mostrarAlerta("EMPRESA ELIMINADA CON EXITO!!!");
            }
            else
            {
                this.mensaje.mostrarAlerta("NO SE ENCONTRO LA EMPRESA!!!");
            }
        } 
        
        public void CargarEmpresas ()
        {
            if(File.Exists(FilePath))
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string Line;
                    while ((Line = sr.ReadLine()) != null)
                    {
                        listaEmpresa.Add(Empresa.FromCsv(Line));
                    }
                }
            }
        }

        public void GuardarEmpresas()
        {
            using(StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach(var empresa in listaEmpresa)
                {
                    sw.WriteLine(empresa.ToCsv());
                }
            }
        }
    }
}
