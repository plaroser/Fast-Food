using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRÁCTICA__1_FAST_FOOD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaracion de variables
            String[] nombres = { "Hamburguesa", "Ensalada", "Perritos Calientes", "Pollo Frito (Ración)", "Pastel (Porción)", "Helado", "Cerveza", "Refrestos" };
            float[] precios = { 3.45f, 2.75f, 3.25f, 4.15f, 2.25f, 1.75f, 2f, 1.75f};
            int[] cantidades = new int[nombres.Length];
            const float IMPUESTO = 21;
            int cantidad = 0;
            int opcion = 0;
            Boolean terminado = false;
            float dineroBruto = 0.0f;
            float impuestos = 0.0f;
            float dineroLimpio = 0.0f;
            float aux = 0.0f;
            int indice = 0;
            String salida = "";
            const String ENCABEZADO ="\t*************************\n"
                                    +"\t*                       *\n"
                                    +"\t*       FAST FOOD       *\n"
                                    +"\t*                       *\n"
                                    +"\t*************************\n";
            //Entrada y validacion
            do
            {
                Console.Clear();
                Console.WriteLine(ENCABEZADO);
                //Mostramos la carta y leeemos la opcion a elegir
                opcion = mostrarMenu(nombres, precios);
                //Leemos la cantidad del producto elegido
                Console.Write("Introduce la cantidad de "+nombres[opcion-1]+" : ");
                cantidad = leerEnterosMayorDeCero();
                //Sumamos la cantidad
                cantidades[opcion - 1] += cantidad;
                Console.Clear();
                Console.WriteLine(ENCABEZADO);
                //Preguntamos si quiere introducir mas productos
                Console.WriteLine("¿Quiere continuar introduciendo productos?");
                terminado = continuar();
                } while (!terminado);
            //Proceso
            //Calcular dinero bruto
            for (indice = 0; indice < nombres.Length; indice++) dineroBruto += precios[indice] * cantidades[indice];
            //Calcular impuestos
            impuestos = dineroBruto * (IMPUESTO/100);
            //Calcular dinero con impuestos
            dineroLimpio = dineroBruto - impuestos;
            //Dibujo la pantalla de salida
            salida =(mostrarSalida(nombres, precios, cantidades));
            salida += "\n\t\t\t\t\tTotal bruto:    " + dineroBruto+" Eur\n";
            salida += "Impuestos: "+IMPUESTO+" %  \t\t  Impuestos pagados:    "+impuestos+" Eur\n";
            salida += "\t\t\t\t\t Total neto:    "+dineroLimpio+" Eur";
            //Salida
            Console.Clear();
            Console.WriteLine(ENCABEZADO);
            Console.WriteLine(salida);
        }

        public static int mostrarMenu(String[] nombres, float[] precios)
        {
            int aux = 0;
            int i = 0;
            Boolean esCorrecto = false;
            if (nombres.Length != precios.Length)
            {
                aux = -1;
            }else
            {
                for (i = 0; i < nombres.Length; i++)
                {
                    Console.WriteLine((i+1)+" "+nombres[i].PadRight(25,'·')+(String)(precios[i]+"").PadRight(6,' ')+" Eur");
                }
                do
                {
                    Console.Write("Selecciona un producto: ");
                    aux = leerEnterosMayorDeCero();
                    esCorrecto = (aux <= nombres.Length) ? true : false;
                    if (!esCorrecto) Console.WriteLine("[ERROR] No ha introducido una opción valida.\n"
                        +"Por favor vuelve a introducir una opción.");
                } while (!esCorrecto);

            }
            return aux;          
        }
        public static int leerEnterosMayorDeCero()
        {
            String aux;
            int numero = 0;
            bool esCorrecto = false;

            do
            {
                aux = Console.ReadLine();
                esCorrecto = Int32.TryParse(aux, out numero);
                if (esCorrecto == false || numero < 0)
                {
                    Console.WriteLine("Error: no ha introducido un número o no es valido.");
                    esCorrecto = false;

                }

            } while (esCorrecto == false);
            return numero;

        }
        public static Boolean continuar()
        {
            Boolean esCorrecto = false;
            Boolean salida = false;
            String aux = "";
            do
            {
                Console.WriteLine("Introduce:\n\"S\" para continuar."
                    + "\n\"N\" para salir");
                aux = Console.ReadLine();
                aux = aux.ToUpper();
                if (aux.Equals("N") || aux.Equals("S"))
                {
                    if (aux.Equals("N"))
                    {
                        salida = true;
                    }
                    else
                    {
                        salida = false;
                    }
                    esCorrecto = true;
                }
                else
                {
                    Console.WriteLine("[ERROR] No ha introducido una opcion valida.");
                    Console.WriteLine("Por favor, vuelva a introducir una opción.");
                }
            } while (!esCorrecto);
            return salida;
        }

        public static string mostrarSalida(String[] nombres, float[] precios, int[] unidades)
        {
            int i = 0;
            String aux = "Nombre\t\t\t\tPrecio\tUnidades\tPrecio Total\n";
            aux += "".PadRight(70, '-')+"\n";
            for (i = 0; i < nombres.Length; i++)
            {
                if (unidades[i] != 0)
                {
                    aux += (nombres[i].PadRight(25, ' ') + "\t" + (precios[i]) + "\t" + unidades[i]+ "\t\t" + precios[i] * unidades[i]+" Eur\n");
                    aux += "".PadRight(70, '-') + "\n";
                }
            }
            
            return aux;
        }
    }
}
