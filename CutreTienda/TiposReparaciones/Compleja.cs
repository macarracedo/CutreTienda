using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;

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
    }
}