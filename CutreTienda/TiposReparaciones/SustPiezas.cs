using System;
using System.Xml.Linq;

namespace TiendaReparaciones
{
    public class SustPiezas : Reparacion
    {
        public SustPiezas(Aparato a, TimeSpan t) : base(a, t)
        {
            
        }

        public double Coste()
        {
            double toRet = 0;
            //Sustitución de piezas 
            double precio = this.Aparato.PrecioHora;
            int mediasHoras = (int) this.Duracion.TotalMinutes / 30;
            Console.WriteLine("Sust. de piezas. Medias horas: " + mediasHoras);
            toRet += precio * mediasHoras;
            return toRet;
        }

        public override string ToString()
        {
            return "Sustitucion de piezas : " + base.toString();
        }

        public XElement toXML()
        {
            var raiz = base.toXML();
            raiz.Name = "sust_piezas";
            raiz.Add(new XElement("coste",this.Coste()));
            
            return raiz;
        }
    }
}