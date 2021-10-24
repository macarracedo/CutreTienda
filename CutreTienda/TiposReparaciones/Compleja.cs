using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;

namespace TiendaReparaciones
{
    public class Compleja : Reparacion
    {
        public Compleja(Aparato a, TimeSpan t) : base(a, t)
        {
            
        }
        
        public double Coste()
        {
            double toRet=0;
            //Reparación Compleja
            double precio = this.Aparato.PrecioHora * 1.25;
            int mediasHoras = (int) this.Duracion.TotalMinutes / 30;
            Console.WriteLine("Reparación compleja. Medias horas: " + mediasHoras);
            toRet += precio * mediasHoras;
        return toRet;
        }

        public override string ToString()
        {
            return "Reparacion compleja : " + base.toString();
        }

        public override XElement toXML()
        {
            var raiz = base.toXML();
            raiz.Name = "sust_piezas";
            raiz.Add(new XElement("coste",this.Coste()));
            
            return raiz;
        }
    }
}