using System;

namespace MisLibrerias
{
    public class MiLibreria
    {
        public static void cargarLote(int[] vecCodigo, float[] vecPre)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Ingrese el código de artículo:");
                int codigo = int.Parse(Console.ReadLine());
                vecCodigo[i] = codigo;

                Console.WriteLine("Ingrese el precio del artículo:");
                float precio = float.Parse(Console.ReadLine());
                vecPre[i] = precio;




            }

        }

        //Número de  Cliente(1  a   300)
        //Código    de Artículo(4  dígitos no  correlativos)
        //Mes(1  a   12)
        //Día(1  a   31)
        //Cantidad  vendida
        ///Procesa los vectores...
        public static void procesarLote(int[] vecCodigo, int[] vecCant, bool[] vecMes)
        {
            int i = 0;



            Console.WriteLine("Ingrese el Nro de cliente");
            int cliente = int.Parse(Console.ReadLine());

            while (cliente != 0)
            {
                Console.WriteLine("Ingrese el código de artículo");
                int codigo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Nro de mes");
                int mes = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Nro de día");
                int dia = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese cantidad vendida");
                int cantidad = int.Parse(Console.ReadLine());

                i = buscarIndice(codigo, vecCodigo);

                vecCant[i] += cantidad;

                if (vecCant[i] > 0)
                {
                    vecMes[mes - 1] = true;
                }






                Console.WriteLine("Ingrese el Nro de cliente");
                cliente = int.Parse(Console.ReadLine());
            }
        }

        ///Ordena los vectores...
        public static void ordenarVector(int[] vecCod, float[] vecPrecio, int[] vecCan)
        {
            int aux;
            float aux2;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    if (vecCan[j] < vecCan[j + 1])
                    {
                        aux = vecCod[j];
                        vecCod[j] = vecCod[j + 1];
                        vecCod[j + 1] = aux;

                        aux2 = vecPrecio[j];
                        vecPrecio[j] = vecPrecio[j + 1];
                        vecPrecio[j + 1] = aux2;

                        aux = vecCan[j];
                        vecCan[j] = vecCan[j + 1];
                        vecCan[j + 1] = aux;

                    }
                }
            }
        }

        public static int buscarIndice(int codigo, int[] vecCodigo)
        {
            for (int i = 0; i < 20; i++)
            {
                if (vecCodigo[i] == codigo)
                {
                    return i;
                }
            }
            return 0;
        }

        public static void imprimirTablaA(int[] vecCodigo, int[] vecCantidad)
        {
            Console.WriteLine("Codigos - Cantidad Vendida");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Código: " + vecCodigo[i] + "       Cantidad: " + vecCantidad[i]);
            }
        }

        public static void reiniciarVector(int[] vec)
        {
            for (int i = 0; i < 20; i++)
                vec[i] = 0;
        }

        public static void setearMesesFalso(bool[] vecMeses)
        {
            for (int i = 0; i < 12; i++)
            {
                vecMeses[i] = false;
            }

        }

        public static void setearMesSinVentas(bool[] vecMeses)
        {
            Console.WriteLine("Meses sin ventas: ");
            for (int i = 0; i < 12; i++)
            {
                if (!vecMeses[i])
                {
                    string mes = nombrarMes(i);
                    Console.WriteLine(mes);
                }
            }

        }

        public static string nombrarMes(int i)
        {
            switch (i)
            {
                case 0:
                    return "Enero";
                case 1:
                    return "Febrero";
                case 2:
                    return "Marzo";
                case 3:
                    return "Abril";
                case 4:
                    return "Mayo";
                case 5:
                    return "Junio";
                case 6:
                    return "Julio";
                case 7:
                    return "Agosto";
                case 8:
                    return "Septiembre";
                case 9:
                    return "Octubre";
                case 10:
                    return "Noviembre";
                default:
                    return "Diciembre";
            }
        }

        public static float calcularPromedio(int[] vecCant)
        {
            float acu = 0;

            for (int i = 0; i < 20; i++)
            {
                acu += vecCant[i];
            }

            return acu / 20;
        }


        public static void imprimirMayoresPromedio(float promedio, int[] vecCantVend, int[] vecCodigo)
        {
            Console.WriteLine("Codigos con cantidad vendida mayor al promedio: ");
            for (int i = 0; i < 20; i++)
            {
                if (vecCantVend[i] > promedio)
                {
                    Console.WriteLine("Código: " + vecCodigo[i]);
                }
            }
        }
    }
}
