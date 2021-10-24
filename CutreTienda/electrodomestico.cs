using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CutreTienda
{
    public abstract class electrodomestico
    {
        protected static List<string> infoXml = new List<string>();
        public electrodomestico(int numSerie, string modelo, float tiempoReparacion)
        {
            this.NumSerie = numSerie;
            this.Modelo = modelo;
            this.TiempoReparacion = tiempoReparacion;
        }
        public int NumSerie
        {
            get;
            set;
        }
        public string Modelo
        {
            get;
            set;
        }
        public float TiempoReparacion
        {
            get;
            set;
        }

        
        const string TagRadio = "RADIO";
        const string TagTV = "TV";
        const string TagDVD = "DVD";
        const string TagTDT = "TDT";
        
        public static void GuardarXML()
        {
            XElement subnode;
            string[] arrayInfo = new string[infoXml.Count];
            //infoXml.CopyTo(arrayInfo,0);
            int b = 0;
            
            foreach (var elem in infoXml)
            {
                arrayInfo[b] = elem;
                b++;
            }
            
            var raiz = new XElement("FACTURA_REPARACIONES");
            //Escribe <FACTURA_REPARACIONES>
            for(int i = 0 ; i < arrayInfo.Length; i++)
            {
                if (arrayInfo[i] == TagRadio)
                {
                    subnode = new XElement("TIPO", arrayInfo[i]);
                    raiz.Add(subnode);
                    subnode = new XElement("NumSerie", arrayInfo[i + 1]);
                    raiz.Add(subnode);
                    subnode = new XElement("Modelo", arrayInfo[i + 2]);
                    raiz.Add(subnode);
                    subnode = new XElement("TiempoReparacion", arrayInfo[i + 3]);
                    raiz.Add(subnode);
                    subnode = new XElement("Banda", arrayInfo[i + 4]);
                    raiz.Add(subnode);
                    subnode = new XElement("PrecioReparacion", arrayInfo[i + 5]);
                    raiz.Add(subnode);
                    i += 5;
                }
                if (arrayInfo[i] == TagTV)
                {
                    subnode = new XElement("TIPO", arrayInfo[i]);
                    raiz.Add(subnode);
                    subnode = new XElement("NumSerie", arrayInfo[i + 1]);
                    raiz.Add(subnode);
                    subnode = new XElement("Modelo", arrayInfo[i + 2]);
                    raiz.Add(subnode);
                    subnode = new XElement("TiempoReparacion", arrayInfo[i + 3]);
                    raiz.Add(subnode);
                    subnode = new XElement("Pulgadas", arrayInfo[i + 4]);
                    raiz.Add(subnode);
                    i += 4;
                }
                if (arrayInfo[i] == TagDVD)
                {
                    subnode = new XElement("TIPO", arrayInfo[i]);
                    raiz.Add(subnode);
                    subnode = new XElement("NumSerie", arrayInfo[i + 1]);
                    raiz.Add(subnode);
                    subnode = new XElement("Modelo", arrayInfo[i + 2]);
                    raiz.Add(subnode);
                    subnode = new XElement("TiempoReparacion", arrayInfo[i + 3]);
                    raiz.Add(subnode);
                    subnode = new XElement("BlueRay", arrayInfo[i + 4]);
                    raiz.Add(subnode);
                    subnode = new XElement("TipoGrabacion", arrayInfo[i + 5]);
                    raiz.Add(subnode);
                    i += 5;
                }
                if (arrayInfo[i] == TagTDT)
                {
                    subnode = new XElement("TIPO", arrayInfo[i]);
                    raiz.Add(subnode);
                    subnode = new XElement("NumSerie", arrayInfo[i + 1]);
                    raiz.Add(subnode);
                    subnode = new XElement("Modelo", arrayInfo[i + 2]);
                    raiz.Add(subnode);
                    subnode = new XElement("TiempoReparacion", arrayInfo[i + 3]);
                    raiz.Add(subnode);
                    subnode = new XElement("TiempoGrabacion", arrayInfo[i + 4]);
                    raiz.Add(subnode);
                    i += 4;
                }
            }
            raiz.Save("reparaciones.xml");
        }

        public static void CargarXML()
        {
            XElement raiz = XElement.Load( "reparaciones.xml" );

            foreach (XElement subNodo in raiz.Elements())
            {
                Console.WriteLine(subNodo);
            }
        }

    }
}