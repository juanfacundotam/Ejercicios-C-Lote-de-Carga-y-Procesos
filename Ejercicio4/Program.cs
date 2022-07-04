using System;
using Libreria4;
namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int acuPiezas1era = 0;
            int acuPiezas2da = 0;

            int[] vecNumChofer = new int[31];
            int[] vecCodChofer = new int[31];
            float[] vecTotalKm = new float[31];
            int[] vecTotalPiezas1era = new int[31];
            int[] vecTotalPiezas2da = new int[31];

            int[] vecMenorDia = new int[31];
            int[] vecCodMenor = new int[31];
            float[,] vecDiaCodigoKm = new float[31, 31];
            int[,] vecDiaCodigoPieza = new int[31, 31];
            int[,] vecDiaCodPiezasMenor = new int[31, 31];



            Lib4.cargarLote(vecNumChofer, vecCodChofer);

            Lib4.reiniciarVectores(vecDiaCodigoKm, vecDiaCodigoPieza, vecDiaCodPiezasMenor, vecMenorDia, vecCodMenor, vecTotalKm, vecTotalPiezas1era, vecTotalPiezas2da);

            Lib4.procesarLote(vecCodChofer, vecDiaCodigoKm, vecDiaCodigoPieza, vecDiaCodPiezasMenor, vecMenorDia, vecCodMenor, vecTotalKm, ref acuPiezas1era, ref acuPiezas2da, vecTotalPiezas1era, vecTotalPiezas2da);

            Lib4.buscarMenorPiezas(vecDiaCodPiezasMenor, vecMenorDia, vecCodMenor, vecCodChofer);

            Console.WriteLine("\nPuntoAD");

            Lib4.imprimirPuntoAD(vecMenorDia, vecCodMenor);

            Console.WriteLine("\nPuntoBE");

            int indiceMayor = Lib4.calcularPuntoBE(vecTotalKm);

            Console.WriteLine("Chofer con más KM recorridos en el mes: " + vecCodChofer[indiceMayor] + " (" + vecTotalKm[indiceMayor] + "KM)");

            Console.WriteLine("\nPuntoCF");

            //VOY POR ACA

            Console.WriteLine("Promedio x quincena de piezas rotas");

            for(int i = 0; i < 31; i++)
            {
                if (vecTotalPiezas1era[i] != 0 || vecTotalPiezas2da[i] != 0)
                {
                    if (vecTotalPiezas1era[i] != 0)
                        Console.Write("Chofer: " + vecCodChofer[i] + "    Primera quincena: " + (acuPiezas1era / vecTotalPiezas1era[i]));
                    else
                        Console.Write("Chofer: " + vecCodChofer[i] + "    Primera quincena: 0");

                    if (vecTotalPiezas2da[i] != 0)
                        Console.Write("    Segunda quincena: " + (acuPiezas2da / vecTotalPiezas2da[i]));
                    else if (vecTotalPiezas2da[i] == 0)
                        Console.Write("    Segunda quincena: 0");
                    Console.WriteLine("\n");
                }
            }







            Console.ReadLine();

        }
    }
}
