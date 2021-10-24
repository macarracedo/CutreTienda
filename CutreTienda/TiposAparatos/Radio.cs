using System.Xml.Linq;

namespace TiendaReparaciones
{
    public enum Bandas { AM, FM, ambas }
    public class Radio : Aparato
    {
        private const int precioHora = 5;
        public Radio( int nSerie, string modelo, Bandas banda)
            :base(precioHora, nSerie, modelo)
        {
            this.Frecuencias=banda;
        }
        public Bandas Frecuencias { get; set; }

        public override string ToString()
        {
            return "Radio: " + base.ToString() + " Frecuencia: " + this.Frecuencias;
        }

        public XElement toXML()
        {
            var raiz = base.toXML();
            raiz.Name = "Radio";
            raiz.Add(new XElement("Frecuencias",this.Frecuencias));
            
            return raiz;
        }
    }
}