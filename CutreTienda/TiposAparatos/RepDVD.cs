using System.Xml.Linq;

namespace TiendaReparaciones
{
    public class RepDVD : Aparato
    {
        private const int precioHora = 10;
        public RepDVD( int nSerie, string modelo, bool blueRay, bool graba, int tiempoGrabacion)
            :base(precioHora, nSerie, modelo)
        {
            this.BlueRay=blueRay;
            this.Records=graba;
            this.RecTime=tiempoGrabacion;
        }
        public bool BlueRay { get; set; }
        public bool Records { get; set; }
        public int RecTime { get; set; }

        public override XElement toXML()
        {
            var raiz = base.toXML();
            raiz.Name = "rep_dvd";
            raiz.Add(new XElement("blueRay", this.BlueRay));
            raiz.Add(new XElement("records", this.Records));
            raiz.Add(new XElement("rec_time", this.RecTime));

            return raiz;
        }
    }
}