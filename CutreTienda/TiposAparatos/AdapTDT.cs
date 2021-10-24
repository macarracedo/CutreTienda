using System.Xml.Linq;

namespace TiendaReparaciones
{
    public class AdapTDT : Aparato
    {
        private const int precioHora = 5;
        public AdapTDT(int nSerie, string modelo, bool graba, int tiempoGrabacion)
            :base(precioHora, nSerie, modelo)
        {
            this.Records=graba;
            this.RecTime=tiempoGrabacion;
        }
        public bool Records { get; set; }

        public int RecTime
        {
            get
            {
                int toRet;
                if(Records)
                    toRet = this.RecTime;
                else
                    toRet = 0;
                return toRet;
            }
            set{}
        }
        
        /// <summary>
        /// Esto hereda de <see cref="Aparato"/> con la información
        /// </summary>
        /// <returns></returns>
        public XElement toXML()
        {
            var raiz = base.toXML();
            raiz.Name = "AdapTDT";
            raiz.Add(new XElement("Records", this.Records));
            raiz.Add(new XElement("RecTime", this.RecTime));

            return raiz;
        }
    }
}