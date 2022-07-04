using System;
using MisLibrerias;

namespace Ejercicio1ConFunciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] vecCodArt = new int[20];
            float[] vecPrecio = new float[20];
            int[] vecCantVend = new int[20];
            bool[] vecMeses = new bool[12];

            //Carga de Lote
            MiLibreria.cargarLote(vecCodArt, vecPrecio);

            MiLibreria.setearMesesFalso(vecMeses);

            MiLibreria.reiniciarVector(vecCantVend);

            //Proceso de Lote

            MiLibreria.procesarLote(vecCodArt, vecCantVend, vecMeses);

            MiLibreria.ordenarVector(vecCodArt, vecPrecio, vecCantVend);

            MiLibreria.imprimirTablaA(vecCodArt, vecCantVend);

            MiLibreria.setearMesSinVentas(vecMeses);

            float promedio = MiLibreria.calcularPromedio(vecCantVend);

            Console.WriteLine("El promedio es " + promedio);

            MiLibreria.imprimirMayoresPromedio(promedio, vecCantVend, vecCodArt);

            Console.ReadKey();
        
        }
    }
}
