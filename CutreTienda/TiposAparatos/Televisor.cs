using System.Xml.Linq;

namespace TiendaReparaciones
{
    public class Televisor : Aparato
    {
        private const int precioHora = 10;
        public Televisor(int nSerie, string modelo, int pulgadas)
            :base(precioHora, nSerie, modelo)
        {
            this.Pulgadas=pulgadas;
        }
        public int Pulgadas { get; set; }
        
        public override string ToString()
        {
            return "Televeisor. Pulgadas: "+Pulgadas+ base.ToString();
        }

        public XElement toXML()
        {
            var raiz = base.toXML();
            raiz.Name = "Televisor";
            raiz.Add(new XElement("Pulgadas",this.Pulgadas));

            return raiz;
        }
    }
}