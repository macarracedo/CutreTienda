using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.VisualBasic.CompilerServices;
using TiendaReparaciones;

namespace CutreTienda
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //listaReparaciones
            var lr = new List<Reparacion>();
            //listaAparatos
            var la = new List<Aparato>();

            //cargar XML
            cargarXML();
            
            
            int op;

            int numSerie;
            
            String modelo;
            
            TimeSpan tiempoReparacion;
            Reparacion rep;
            Aparato ap;
            Bandas banda;
            bool graba;
            int pulgadas;
            string resp;
            bool blueray = false;
            int tiempoGrabacion;
            bool seguir = true;
            string factura;
            
            
            do
            {

                op = menu();
                numSerie = introducirValor("Numero de serie: ");
                modelo = introducirCadena("Modelo: ");
                tiempoReparacion = introducirTimeSpan("Tiempo de la reparacion: ");
                
                switch (op)
                {
                    case 1:
                        banda = introducirBandas("Banda?");
                        
                        ap = FachadaAparatos.CrearRadio(numSerie, modelo, banda);
                        la.Add(ap);
                        rep = Reparacion.FactoryMethod(ap, tiempoReparacion);
                        lr.Add(rep);
                        Console.WriteLine("\n \nIntroducido: \n"+ rep);

                        break;
                    
                    
                    case 2:
                        pulgadas = introducirValor("Pulgadas?");
                        
                        ap = FachadaAparatos.CrearTV(numSerie, modelo, pulgadas);
                        la.Add(ap);
                        rep = Reparacion.FactoryMethod(ap, tiempoReparacion);
                        lr.Add(rep);
                        Console.WriteLine("Introducido: " + ap + " " + rep);
                        
                        break;
                    
                    
                    case 3:
                        
                        blueray = introducirBooleano("Tiene BlueRay?");
                        graba = introducirBooleano("Graba?");
                        tiempoGrabacion = 0;
                        if (graba)
                        {
                            Console.WriteLine(" \t Tiempo de grabacion: \n");
                            tiempoGrabacion = Convert.ToInt32(Console.ReadLine());
                        }
                        
                        ap = FachadaAparatos.CrearDVD(numSerie, modelo, blueray, graba, tiempoGrabacion);
                        la.Add(ap);
                        rep = Reparacion.FactoryMethod(ap, tiempoReparacion);
                        lr.Add(rep);
                        Console.WriteLine("Introducido: " + ap + " " + rep);

                        break;
                    
                    case 4:
                        graba = introducirBooleano("Graba?");
                        tiempoGrabacion = 0;
                        if (graba)
                        {
                            Console.WriteLine(" \t Tiempo de grabacion: \n");
                            tiempoGrabacion = Convert.ToInt32(Console.ReadLine());
                        }
                        
                        ap = FachadaAparatos.CrearTDT(numSerie, modelo, graba, tiempoGrabacion);
                        la.Add(ap);
                        rep = Reparacion.FactoryMethod(ap, tiempoReparacion);
                        lr.Add(rep);
                        Console.WriteLine("Introducido: " + ap + " " + rep);

                        break;
                    
                    case 5:
                        
                        Console.WriteLine("Reparaciones: ");
                        foreach (var reparacion in lr)
                        {
                            Console.WriteLine(reparacion);
                        }
                        
                        Console.WriteLine("Aparatos: ");
                        foreach (var aparato in la)
                        {
                            Console.WriteLine(aparato);
                        }
                        
                        break;
                    
                    default:
                        Console.WriteLine("Opción no valida.");
                        break;
                }
                
            }while(introducirBooleano("Seguir?"));
            
            guardarXML(la,lr);
        }
        
        static int menu()
        {
            Console.WriteLine("Bienvenido a tu app de gestión de reparaciones \n"
                              + "Opciones: \n" +
                              " (1) Nueva reparacion de Radio \n" +
                              " (2) Nueva reparacion de TV \n" +
                              " (3) Nueva reparacion de DVD \n" +
                              " (4) Nueva reparacion de TDT \n" +
                              " (5) Mostrar datos");

            return Convert.ToInt32(Console.ReadLine());
        }

        static void cargarXML()
        {
            
            /*
            XElement raiz = XElement.Load( "reparaciones.xml" );

            foreach (XElement subNodo in raiz.Elements())
            {
                Console.WriteLine(subNodo);
            }
            */
        }

        static void guardarXML(List<Aparato> la, List<Reparacion> lr)
        {
            var raiz = new XDocument();
            var reparaciones = new XElement("reparaciones");
            
            foreach (var rep in lr)
            {
                reparaciones.Add(rep.toXML());
            }
            raiz.Add(reparaciones);
            raiz.Save("reparaciones2.xml");
        }

        static TimeSpan introducirTimeSpan(string msg)
        {
            Console.WriteLine("\t" + msg);
            int horas, minutos;
            horas = introducirValor("Horas?:");
            minutos = introducirValor("Minutos?");
            return new TimeSpan(horas, minutos, 0);
        }

        static bool introducirBooleano(string msg)
        {
            bool toRet;
            String resp;
            do
            {
                Console.WriteLine( "\t" + msg  + " ?(S/N)" );
                resp = Console.ReadLine();
            } while (!resp.ToUpper().StartsWith("S") & !resp.ToUpper().StartsWith("N"));
    
            if (resp.ToUpper().StartsWith("S"))
                toRet = true;
            else
            {
                toRet = false;
            }

            return toRet;
        }

        static int introducirValor(string msg)
        {
            Console.WriteLine( "\t" + msg );
            int toRet = Convert.ToInt32(Console.ReadLine());
            
            return toRet;
        }
        
        static string introducirCadena(string msg)
        {
            Console.WriteLine( "\t" + msg );
            string toRet = Console.ReadLine();
            
            return toRet;
        }

        static Bandas introducirBandas(string msg)
        {
            string banda;
            bool repetir = false;
            Bandas toRet = Bandas.ambas;
            do
            {
                Console.WriteLine( "\t" + msg + "(am/fm/ambas)" );
                banda = Console.ReadLine().ToUpper();
                
                if (banda == "AM")
                {
                    Console.Write("AM recognised!");
                    toRet = Bandas.AM;
                }
                else if (banda.Equals("FM".ToString()))
                {
                    Console.Write("FM recognised!");
                    toRet = Bandas.FM;
                }
                else if (banda == "AMBAS")
                {
                    Console.Write("AMBAS recognised!");
                    toRet = Bandas.ambas;
                }
                else
                {
                    repetir = true;
                }
            } while (repetir);

            return toRet;
        }
    }
}