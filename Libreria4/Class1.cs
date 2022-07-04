using System;

namespace Libreria4
{
    public class Lib4
    {

        public static void cargarLote(int[] vecNumCho, int[] vecCodCho)
        {
            for(int i = 0; i < 31; i++)
            {
                vecNumCho[i] = i + 1;
                Console.WriteLine("Chofer: " + vecNumCho[i]);

                Console.Write("Código de chofer: ");
                int codigo = int.Parse(Console.ReadLine());
                
                vecCodCho[i] = codigo;
            }
        }
        
        
        
        
        public static void reiniciarVectores(float[,] vecDiaCodKm, int[,] vecDiaCodPieza, int[,] vecDiaCodPiezaMenor, int[] vecMenorDia, int[] vecCodMenor, float[] vecTotalKm, int[] vecTotalPiezas1era, int[] vecTotalPiezas2da)
        {
            for (int i = 0; i < 31; i++)
            {
                vecMenorDia[i] = 0;
                vecCodMenor[i] = 0;
                vecTotalKm[i] = 0;
                vecTotalPiezas1era[i] = 0;
                vecTotalPiezas2da[i] = 0;
                for (int j = 0; j < 31; j++)
                {
                    vecDiaCodKm[i, j] = 0;
                    vecDiaCodPieza[i, j] = 0;
                    vecDiaCodPiezaMenor[i, j] = 0;
                    
                }
            }
        }

        public static void procesarLote(int[] vecCodChofer, float[,] vecDiaCodKm, int[,] vecDiaCodPiezas, int[,] vecDiaCodPiezasMenor, int[] vecCodMenor, int[] vecMenorDia, float[] vecTotalKm, ref int acuPiezas1era, ref int acuPiezas2da, int[] vecTotalPiezas1era, int[] vecTotalPiezas2da)
        {

            Console.WriteLine("*****Viajes del mes anterior*****");

            Console.WriteLine("Ingrese Nro de día:");
            int dia = int.Parse(Console.ReadLine());

            while(dia != 0)
            {
                Console.WriteLine("Ingrese el código de chofer");
                int codigo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese los KM recorridos");
                float km = float.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese cantidad de piezas rotas");
                int piezas = int.Parse(Console.ReadLine());

                //-------
                int indice = buscarIndice(codigo, vecCodChofer);
                vecDiaCodKm[dia-1, indice] += km;
                vecDiaCodPiezas[dia-1, indice] += piezas;

                vecTotalKm[indice] += km;

                     

                if (vecDiaCodPiezasMenor[dia-1, indice] == 0)
                {
                    vecDiaCodPiezasMenor[dia-1, indice] = piezas;

                }
                else if(vecDiaCodPiezasMenor[dia-1, indice] != 0)
                {
                    if(vecDiaCodPiezasMenor[dia-1, indice] > piezas)
                    {
                        vecDiaCodPiezasMenor[dia-1, indice] = piezas;
                    }
                }

                if(dia > 0 && dia < 16)
                {
                    acuPiezas1era += piezas;
                    vecTotalPiezas1era[indice] += piezas;
                }
                else if(dia >= 16)
                {
                    acuPiezas2da += piezas;
                    vecTotalPiezas2da[indice] += piezas;
                }

                


                Console.WriteLine("Ingrese Nro de día:");
                dia = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("\n");
            for(int i = 0; i < 31; i++)
            {

                for(int j = 0; j < 31; j++)
                {   
                    if(vecDiaCodKm[i, j] != 0)
                       Console.WriteLine("Dia " + (i+1) + "   Km: " + vecDiaCodKm[i, j] + "   codigo: " + vecCodChofer[j]);
                }
            }
            


            

        }

        public static int buscarIndice(int cod, int[] vecCodCho)
        {
            for(int i = 0; i < 31; i++)
            {
                if(vecCodCho[i] == cod)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void buscarMenorPiezas(int[,] vecDiaCogPiezaMenor, int[] vecMenorDia, int[] vecCodMenor, int[] vecCodChofer) 
        {
            bool bandMenor = false;
            
            for( int i = 0; i < 31; i++)
            {
                bandMenor = false;

                for (int j = 0; j < 31; j++)
                {
                    if (vecDiaCogPiezaMenor[i, j] != 0)
                    {
                        if (!bandMenor)
                        {
                            vecMenorDia[i] = vecDiaCogPiezaMenor[i, j];
                            vecCodMenor[i] = vecCodChofer[j];
                            bandMenor = true;
                        }
                        else
                        {
                            if (vecDiaCogPiezaMenor[i, j] != 0 && vecMenorDia[i] > vecDiaCogPiezaMenor[i, j])
                            {
                                vecMenorDia[i] = vecDiaCogPiezaMenor[i, j];
                                vecCodMenor[i] = vecCodChofer[j];
                            }
                        }
                    }
                }
            }
        }

        public static void imprimirPuntoAD(int[] vecMenorDia, int[] vecCodMenor)
        {
            for (int i = 0; i < 31; i++)
            {
                if (vecMenorDia[i] > 0)
                    Console.WriteLine("dia: " + (i + 1) + "    " + vecMenorDia[i] + "     " + vecCodMenor[i]);

            }
        }

        public static int calcularPuntoBE(float[] vecTotalKm)
        {   
            float mayor = vecTotalKm[0];
            int indiceMayor = 0;
            for (int i = 1; i < 31; i++)
            {
                if (mayor < vecTotalKm[i])
                {
                    mayor = vecTotalKm[i];
                    indiceMayor = i;
                }
                    

            }

            return indiceMayor;

        }

    }
}
