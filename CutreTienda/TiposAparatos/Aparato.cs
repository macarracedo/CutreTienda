using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace TiendaReparaciones
{
    public abstract class Aparato
    {/// <summary>
     /// Constructor de Aparato
     /// </summary>
     /// <param name="precioHora"> Registra el precio por hora</param>
     /// <param name="nSerie"> Registra el numero de serie</param>
     /// <param name="modelo"> Registra el modelo</param>
        public Aparato (int precioHora, int nSerie, string modelo)
            {
                this.PrecioHora=precioHora;
                this.NSerie=nSerie;
                this.Modelo=modelo;
            }
            public int PrecioHora { get; set; }
            public int NSerie { get; }
            public string Modelo { get; }

            public override string ToString()
            {
                return " Num. de serie: "+NSerie+" Modelo: "+Modelo +" Precio por hora: "+PrecioHora ;
            }

            public XElement toXML()
            {
                var raiz = new XElement("Aparato");
                raiz.Add(new XElement("PrecioHora",this.PrecioHora));
                raiz.Add(new XElement("NSerie",this.NSerie));
                raiz.Add(new XElement("Modelo",this.Modelo));

                return raiz;
            }
    }
}