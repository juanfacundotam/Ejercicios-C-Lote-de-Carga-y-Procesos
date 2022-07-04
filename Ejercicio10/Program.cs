using System;
using Libreria10;

namespace Ejercicio10
{
    internal class Program
    {
        public struct Auto
        {
            public int codAuto;
            public int categoria;
            public float importeKm;
            public int agencia;
        }
        public struct Agencia
        {
            public int numAgencia;
            public float totalImporte;
            public int ubicacion;
        }
        public struct Cliente
        {
            public int cliente;
            public int codAuto;
            public int dias;
            public float km;
            public float totalKm;
        }


        const int TAM = 20;
        static void Main(string[] args)
        {
            
            Auto[] vecAutos = new Auto[TAM];
            Agencia[] vecAgencia = new Agencia[TAM];
            Cliente[] vecClientes = new Cliente[TAM];
            int[] vecAcuCodigos = new int[TAM];
            int[] vecAcuAgencias = new int[TAM];

            Console.WriteLine("Cargaremos los datos de los Autos...");
            cargarLote1(vecAutos);

            Console.WriteLine("Cargaremos los datos de los Autos...");
            cargarLote2(vecAgencia);

            ordenarVector(vecAutos);

            Console.WriteLine("\nAlquileres de mes pasado: ");

            for(int i = 0; i < TAM; i++)
            {
                Console.WriteLine(vecAutos[i].codAuto + "   KM: " + vecAutos[i].importeKm);
            }

            reiniciarVector(vecClientes, vecAcuAgencias);

            procesarLote(vecClientes, vecAcuCodigos);

            Console.WriteLine("\n");
            
            resolverPuntoA(vecClientes, vecAutos);

            resolverPuntoB(vecClientes, vecAutos, vecAgencia);

            resolverPuntoC(vecAcuCodigos, vecAutos);

            resolverPuntod(vecAutos, vecAcuCodigos, vecAcuAgencias);


            Console.ReadKey();





        }

        //DECLARACIONES DE FUNCIONES==============================
        public static void cargarLote1(Auto[] vecAutos)
        {
            for (int i = 0; i < TAM; i++)
            {
                Console.WriteLine("Ingrese código de Auto (4num): ");
                int codigo = int.Parse(Console.ReadLine());
                vecAutos[i].codAuto = codigo;

                Console.WriteLine("Ingrese la categoría (1-10)");
                int categoria = int.Parse(Console.ReadLine());
                vecAutos[i].categoria = categoria;

                Console.WriteLine("Ingrese el importe x KM: ");
                int importeKm = int.Parse(Console.ReadLine());
                vecAutos[i].importeKm = importeKm;

                Console.WriteLine("Ingrese nro de agencia (1-20): ");
                int agencia = int.Parse(Console.ReadLine());
                vecAutos[i].agencia = agencia;


            }
        }

        public static void cargarLote2(Agencia[] vecAgencia)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Numero de agencia: " + (vecAgencia[i].numAgencia = i + 1));

                Console.WriteLine("Ingrese la ubicacion (1=Aeropuerto Ezeiza, 2=Aeroparque, 3=Centro Ciudad)");
                int ubicacion = int.Parse(Console.ReadLine());
                vecAgencia[i].ubicacion = ubicacion;

            }
        }

        public static void ordenarVector(Auto[] vecAutos)
        {
            
            for(int i = 0; i < TAM; i++)
            {
                for(int j = 0; j < TAM-1; j++)
                {
                    if(vecAutos[j].codAuto > vecAutos[j + 1].codAuto)
                    {
                        Auto aux = vecAutos[j];
                        vecAutos[j] = vecAutos[j + 1];
                        vecAutos[j + 1] = aux;
                    }
                }
            }
        }

        public static void procesarLote(Cliente[] vecClientes, int[] vecAcuCodigos)
        {
            Console.WriteLine("Ingrese Nro de cliente (1-200)");
            int cliente = int.Parse(Console.ReadLine());
            int indice = 0;
            while(cliente != 0)
            {
                Console.WriteLine("Ingrese el código de auto");
                int codigo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el total de dias del alquiler");
                int dias = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Km recorridos");
                float km = float.Parse(Console.ReadLine());

                //int indice = buscarIndiceCodigo(codigo, vecAutos);

                vecClientes[cliente - 1].codAuto = codigo;
                vecClientes[cliente - 1].dias = dias;
                //vecClientes[cliente - 1].km += km;
                vecClientes[cliente - 1].totalKm += km;

                
                vecAcuCodigos[codigo - 1001]++;





                Console.WriteLine("Ingrese Nro de cliente (1-200)");
                cliente = int.Parse(Console.ReadLine());
            }
        }

        public static int buscarIndiceCodigo(int i, Auto[] vecAutos, Cliente[] vecClientes)
        {
            for (int x = 0; x < TAM; x++)
            {
                if (vecClientes[i].codAuto == vecAutos[x].codAuto)
                    return x;
            }
            return 0;

        }

        public static void resolverPuntoA(Cliente[] vecClientes,Auto[] vecAutos)
        {
            for(int i = 0; i < TAM; i++)
            {
                if (vecClientes[i].totalKm > 0)
                {
                    int indice = buscarIndiceCodigo(i, vecAutos, vecClientes);
                    Console.WriteLine("Cliente: " + vecClientes[i].cliente + "    Importe total por KM recorridos: $" + (vecClientes[i].totalKm * vecAutos[indice].importeKm));
                }
            }
        }

        public static void reiniciarVector(Cliente[] vecClientes, int[] vecAcuAgencias)
        {
            for(int i = 0; i < TAM; i++)
            {
                vecClientes[i].cliente = i + 1;
                vecClientes[i].codAuto = 0;
                vecClientes[i].dias = 0;
                vecClientes[i].km = 0;
                vecClientes[i].totalKm = 0;

                vecAcuAgencias[i] = 0;


            }
        }


        public static int buscarIndiceAgencia(int indice,Auto[] vecAutos,Agencia[] vecAgencia)
        {
            for(int x = 0; x < TAM; x++)
            {

                if (vecAutos[indice].agencia == vecAgencia[x].numAgencia)
                    return x;
            }
            return 0;
        }
        
        
        public static void resolverPuntoB(Cliente[] vecClientes, Auto[] vecAutos, Agencia[] vecAgencia)
        {
            float acuUbicacion1 = 0;
            float acuUbicacion2 = 0;
            float acuUbicacion3 = 0;

            for (int i = 0; i < TAM; i++)
            {
                if (vecClientes[i].totalKm > 0)
                {
                    int indiceCodigo = buscarIndiceCodigo(i, vecAutos, vecClientes);
                    float Kmtotales = vecClientes[i].totalKm * vecAutos[indiceCodigo].importeKm;

                    int indiceAgencia = buscarIndiceAgencia(indiceCodigo, vecAutos, vecAgencia);
                    
                    if (vecAgencia[indiceAgencia].ubicacion == 1)
                    {
                        acuUbicacion1 += Kmtotales;
                    }
                    else if(vecAgencia[indiceAgencia].ubicacion == 2)
                    {
                        acuUbicacion2 += Kmtotales;
                    }
                    else if(vecAgencia[indiceAgencia].ubicacion == 3)
                    {
                        acuUbicacion3 += Kmtotales;
                    }

                }
                
            }

            Console.WriteLine("\nTotal importe recacudado x ubicación");
            Console.WriteLine("Ubicacion 1 (Ezeiza): " + acuUbicacion1);
            Console.WriteLine("Ubicacion 2 (Aeroparque): " + acuUbicacion2);
            Console.WriteLine("Ubicacion 3 (Centro Ciudad): " + acuUbicacion3);

        }

        public static void resolverPuntoC(int[] vecAcuCodigos, Auto[] vecAutos)
        {

            bool bandMayor = false;
            int mayorCantidad = 0;
            int mayorCategoria = 0;

            for (int i = 1; i < TAM; i++)
            {
                if (vecAcuCodigos[i] > 0 && bandMayor == false)
                {
                    mayorCantidad = vecAcuCodigos[i];
                    mayorCategoria = vecAutos[i].categoria;
                    bandMayor = true;
                }
                else if(bandMayor == true && vecAcuCodigos[i] > 0 && vecAcuCodigos[i] > mayorCantidad)
                {
                    mayorCantidad = vecAcuCodigos[i];
                    mayorCategoria = vecAutos[i].categoria;
                }
            }

            Console.WriteLine("\nCategoria Mayor: " + mayorCategoria);
        }

        public static void resolverPuntod(Auto[] vecAutos, int[] vecAcuCodigos, int[] vecAcuAgencias)
        {
            for(int i = 0; i < TAM; i++)
            {

                if(vecAcuCodigos[i] > 0)
                {
                    vecAcuAgencias[vecAutos[i].agencia - 1] += vecAcuCodigos[i];
                }
            }

            Console.WriteLine("\nAgencias con menos de 5 alquileres");

            for (int i = 0; i < TAM; i++)
            {
                if(vecAcuAgencias[i] < 5)
                    Console.WriteLine("Agencia: " + (i+1) + "    Cantidad de alquileres: " + vecAcuAgencias[i]);
            }
        }

    }
}
