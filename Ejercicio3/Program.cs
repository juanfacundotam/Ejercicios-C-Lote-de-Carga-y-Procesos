using System;
using Libreria3;
namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vecTarifa = new int[20];
            float[] vecCamion = new float[100];
            float[] vecImporteKm = new float[20];
            float[] vecTotalRecaudado = new float[20];
            int[] vecNumCamion = new int[100];
            float[] vecCamionKm = new float[100];


            //Lote de Carga
            Lib3.resetearVector(vecTarifa, vecImporteKm, vecTotalRecaudado);
            Lib3.resetearVector100(vecCamion);

            Lib3.cargarVector(vecTarifa, vecImporteKm);

            //Número de  cliente(1  a   300).
            //Número    de artículo(4  dígitos,	no correlativos).
            //Cantidad  de unidades    vendidas.

            Console.WriteLine("\nEnvíos de la semana anterior");
            //Lote de Proceso
            Lib3.procesarLote(vecTarifa, vecImporteKm, vecTotalRecaudado, vecCamion, vecCamionKm);

            Lib3.imprimirPuntoA(vecTarifa, vecTotalRecaudado);

            Lib3.ordenarVector(vecCamion, vecNumCamion);

            Lib3.imprimirPuntoB(vecCamion, vecNumCamion);

            Lib3.imprimirPuntoC(vecCamionKm);








            Console.ReadKey();
        }
    }
}
