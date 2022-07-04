using System;

namespace Libreria3
{
    public class Lib3
    {
        public static void resetearVector(int[] vec1, float[] vec2, float[] vec3)
        {
            for(int i = 0; i < 20; i++)
            {
                vec1[i] = 0;
                vec2[i] = 0;
                vec3[i] = 0;
            }
        }

        public static void resetearVector100(float[] vecCamion)
        {
            for (int i = 0; i < 100; i++)
            {
                vecCamion[i] = 0;
                
            }
        }

        public static void cargarVector(int[] vec1, float[] vec2)
        {
            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine("Ingresar número de tarifa");
                int tarifa = int.Parse(Console.ReadLine());
                vec1[i] = tarifa;

                Console.WriteLine("Ingresar importe por KM");
                float importe = float.Parse(Console.ReadLine());
                vec2[i] = importe;
            }
        }


        public static void procesarLote(int[] vecTarifa, float[] vecImpKm, float[] vecRecaudado, float[] vecCamion, float[] vecCamionKm)
        {
            Console.WriteLine("Ingrese número de camión (1a100)");
            int camion = int.Parse(Console.ReadLine());

            while (camion >= 0)
            {
                Console.WriteLine("Ingrese número de tarifa");
                int tarifa = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad de KM recorridos");
                float km = float.Parse(Console.ReadLine());

                int indice = buscarIndice(tarifa, vecTarifa);
                float monto = km * vecImpKm[indice];
                vecRecaudado[indice] += monto;

                vecCamion[camion - 1] += monto;

                vecCamionKm[camion - 1] += km;






                Console.WriteLine("Ingrese número de camión (1a100)");
                camion = int.Parse(Console.ReadLine());
            }
        }

        public static int buscarIndice(int tarifa, int[] vecTarifa)
        {
            for (int i = 0; i < 20; i++)
            {
                if (vecTarifa[i] == tarifa)
                {
                    return i;
                }
           
            }
            return -1;
        }

        public static void imprimirPuntoA(int[] vecTarifa, float[] vecRecaudado)
        {
            Console.WriteLine("Recaudación x tarifa:");

            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine("Nro de tarifa: " + vecTarifa[i] + "      Total recaudado: " + vecRecaudado[i]);
            }
        }

        public static void imprimirPuntoB(float[] vecCamion, int[] vecNumCam)
        {
            Console.WriteLine("\nRecaudación x camión:");

            for (int i = 0; i < 100; i++)
            {
                if (vecCamion[i] > 0)
                {
                    Console.WriteLine("Nro de camión: " + vecNumCam[i] + "      Total recaudado: " + vecCamion[i]);
                }
            }   
        }

        public static void ordenarVector(float[] vecCamion, int[] vecNumCam)
        {
            
            for(int i = 0; i < 100; i++)
            {
                vecNumCam[i] = i + 1;
            }

            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 99; j++)
                {
                    if(vecCamion[j] < vecCamion[j + 1])
                    {
                        float aux = vecCamion[j];
                        vecCamion[j] = vecCamion[j + 1];
                        vecCamion[j + 1] = aux;

                        int aux1 = vecNumCam[j];
                        vecNumCam[j] = vecNumCam[j + 1];
                        vecNumCam[j + 1] = aux1;
                    }
                }
            }
        }

        public static void imprimirPuntoC(float[] vecCamionKm)
        {
            bool bandKm = false;
            int menor = 0;
            float numCam = 0;
            

            for (int i = 0; i < 100; i++)
            {
                if (vecCamionKm[i] > 0)
                {
                    if (!bandKm)
                    {
                        numCam = vecCamionKm[i];
                        menor = i;
                        bandKm = true;
                    }
                    else
                    {
                        if(vecCamionKm[i] < numCam)
                        {
                            numCam = vecCamionKm[i];
                            menor = i;
                        }
                    }
                }

            }

            Console.WriteLine("\nCamión con menos KM recorridos: " + (menor + 1));
        }


    }
}
