using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace TiendaReparaciones
{
    public abstract class Reparacion : Object
    {
        protected Reparacion(Aparato a, TimeSpan t)
        {
            this.Duracion = t;
            this.Aparato = a;
        }

        public static Reparacion FactoryMethod(Aparato aparato, TimeSpan duracion)
        {
            if (duracion.CompareTo(new TimeSpan(1, 0, 0))>1)
            {
                return new Compleja(aparato, duracion);
            }
            else
            {
                return new SustPiezas(aparato, duracion);
            }
        }
        public Aparato Aparato { get; set; }
        public TimeSpan Duracion { get; set; }

        public String toString()
        {
            return "Aparato: " + Aparato.ToString() + " Duracion: " + Duracion.ToString();
        }

        public virtual XElement toXML()
        {
            var raiz = new XElement("reparacion");
            raiz.Add(new XElement(this.Aparato.toXML()));
            raiz.Add(new XElement("duracion", this.Duracion));

            return raiz;
        }
    }
}