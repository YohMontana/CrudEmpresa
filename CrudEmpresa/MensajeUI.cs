using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpresa
{
    internal class MensajeUI
    {
        private int ancho;

        public MensajeUI(int ancho)
        {
            this.ancho = ancho;
        }

        public void mostrarEncabezado(string cabecera)
        {
            Console.WriteLine(new String('=', this.ancho));
            Console.WriteLine(new String(' ', 15) + cabecera);
            Console.WriteLine(new String('=', this.ancho));
        }

        public void mostrarAlerta(string alerta)
        {
            Console.Clear();
            Console.WriteLine(new String(' ', 15) + alerta);
            Console.WriteLine(new String('=', this.ancho));
            System.Threading.Thread.Sleep(1000);
        }
    }
}
