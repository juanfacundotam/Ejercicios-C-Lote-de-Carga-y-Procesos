using System;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Lote de carga
            int[] vecCodArt = new int[20];
            float[] vecPrecio = new float[20];
            int x, codigo;
            float precio;
            int cliente, codArt, mes, dia, cantVendida;
            string nombreMes;
            

            for (x = 0; x < 20; x++)
            {
                vecCodArt[x] = 0;
                vecPrecio[x] = 0;
            }

            for (x = 0; x < 20; x++)
            {
                System.Console.WriteLine("Ingrese código de producto");
                codigo = int.Parse(Console.ReadLine());
                vecCodArt[x] = codigo;
                System.Console.WriteLine("Ingrese precio del producto");
                precio = float.Parse(Console.ReadLine());
                vecPrecio[x] = precio;
            }

            bool[] vecMeses = new bool[12];
            int[] vecCantVendida = new int[20];

            for (x = 0; x < 20; x++)
            {
                vecCantVendida[x] = 0;
            }

            for (x = 0; x < 12; x++)
            {
                vecMeses[x] = false;
            }


            System.Console.WriteLine("Ingrese Nro de cliente");
            cliente = int.Parse(Console.ReadLine());


            while (cliente != 0)
            {

                System.Console.WriteLine("Ingrese código de artículo");
                codArt = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Ingrese Nro de mes");
                mes = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Ingrese Nro de día");
                dia = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Ingrese la cantidad vendida");
                cantVendida = int.Parse(Console.ReadLine());

                int i = 0;
                for (x = 0; x < 20; x++)
                {
                    if (vecCodArt[x] == codArt)
                        i = x;
                }

                vecMeses[mes - 1] = true;
                vecCantVendida[i] += cantVendida;

                System.Console.WriteLine("Ingrese Nro de cliente");
                cliente = int.Parse(Console.ReadLine());
            }


            //Oredenar por burbujeo de mayor a menor la cantidad vendida
            
            for (int j = 0; j < 20; j++)
            {
                for (int k = 0; k < 19; k++)
                {
                    if (vecCantVendida[k] < vecCantVendida[k + 1])
                    {
                        int auxCant = vecCantVendida[k + 1];
                        vecCantVendida[k + 1] = vecCantVendida[k];
                        vecCantVendida[k] = auxCant;

                        int auxCod = vecCodArt[k + 1];
                        vecCodArt[k + 1] = vecCodArt[k];
                        vecCodArt[k] = auxCod;

                        float auxPre = vecPrecio[k + 1];
                        vecPrecio[k + 1] = vecPrecio[k];
                        vecPrecio[k] = auxPre;
                    }
                }
            }
            

            //Imprimir tabla Punto A
            Console.WriteLine("Tabla Códigos Artículos - Cantidad Vendida");
            for(x = 0; x < 20; x++)
            {
                Console.Write("Código de artículo: " + vecCodArt[x]);
                Console.WriteLine("     Cantidad total vendida: " + vecCantVendida[x]);
            }

            //Imprimir meses sin ventas Punto B
            
            Console.WriteLine("Meses sin ventas: ");
            for(x = 0; x < 12; x++)
            {
                if (vecMeses[x] == false)
                {
                    nombreMes = nombrarMes(x);
                    Console.WriteLine("Mes " + nombreMes);
                }
                    
            }

            //Punto C
            int acuCant = 0;

            for(x = 0; x < 20; x++)
            {
                acuCant += vecCantVendida[x];
            }

            float promedio = acuCant / 20;

            Console.WriteLine("Códigos cuyas ventas son mayores al promedio: ");
            for (x = 0; x < 20; x++)
            {
                if(vecCantVendida[x] > promedio)
                    Console.WriteLine("Código " + vecCodArt[x]);
            }

            Console.ReadKey();
        }

        static string nombrarMes(int mes)
        {
            switch (mes) { 
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
    }
}
