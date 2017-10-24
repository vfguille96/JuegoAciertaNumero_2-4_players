using System;
using System.Threading;

namespace PROG_REL3_EJ8_Vera_Guillermo
{
    internal class Program
    {
        private static int tiempoEsperaSalirJuego = 3500;
        private static int tiempoEsperaIntentos = 800;

        private static void Main(string[] args)
        {
            Console.Title = "Juego Acertar Número  (2-4 Jugadores)";

            // Declaramos
            int tiempoEsperaMenuPrincipal = 2000;
            int numeroJugadores = 0;
            int numeroAAdivinar = 0;
            int numeroJugadorDos = 0;
            int numeroJugadorTres = 0;
            int numeroJugadorCuatro = 0;
            int contadorIntentosJugadorDos = 0;
            int contadorIntentosJugadorTres = 0;
            int numeroIntentosJugadorCuatro = 0;
            int dosJugadores = 2;
            int tresJugadores = 3;
            int cuatroJugadores = 4;

            // Declaramos para ocultar caracter del "numeroAADivinar"
            ConsoleKeyInfo ultimaTecla;
            bool continuar = true;
            char asterisco = '*'; //Caracter que mostrara :)

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            EscribirTituloJuego();

            Console.WriteLine(" El juego consiste en adivinar el número del 0 al 100 que otro jugador a introducido.");

            // Tiempo de espera hasta elegir el número de jugadores.
            Thread.Sleep(tiempoEsperaMenuPrincipal);

            Console.Clear();
            EscribirTituloJuego();

            try
            {
                Console.Write(" Introduce el número de jugadores (2-4): ");
                numeroJugadores = int.Parse(Console.ReadLine());    // Lee el número de jugadores.

                if (numeroJugadores == dosJugadores)    // Código para dos jugadores.
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine(" *** JUGADOR 1 ***");
                    Console.WriteLine();
                    Console.Write(" Introduce el número a adivinar por los demás jugadores (0 al 100): ");

                    // Declaramos una variable temporal que se comporta como un string.
                    string tmpNumeroAADivinar = "";

                    // Ocultar número a mostrar
                    while (continuar)
                    {
                        ultimaTecla = Console.ReadKey(true);
                        if (ultimaTecla.KeyChar != (char)ConsoleKey.Enter)
                        {
                            tmpNumeroAADivinar = tmpNumeroAADivinar + ultimaTecla.KeyChar;
                            Console.Write(asterisco);
                        }
                        else
                            continuar = false;
                    }

                    // Se convierte la variable temporal a entero y su valor se guarda en la variable original.
                    numeroAAdivinar = int.Parse(tmpNumeroAADivinar);

                    if (numeroAAdivinar < 0 || numeroAAdivinar > 100)
                    {
                        ErrorFormatoNumeroAAcertar(tiempoEsperaSalirJuego); // Ejecuta el método con el tiempo de espera.
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" *** JUGADOR 2 ***");
                        Console.WriteLine();
                        Console.Write(" Introduce tu número a adivinar: ");
                        numeroJugadorDos = int.Parse(Console.ReadLine());

                        if (numeroJugadorDos < 0 || numeroJugadorDos > 100)
                        {
                            ErrorFormatoNumeroAAcertar(tiempoEsperaSalirJuego); // Ejecuta el método con el tiempo de espera.
                        }
                        else
                        {
                            while (numeroJugadorDos != numeroAAdivinar && numeroJugadorDos >= 0 && numeroJugadorDos <= 100) // Mientras el "numeroAADivinar" esté en esta expresión, se ejecutará el siguiente código.
                            {
                                if (numeroJugadorDos < numeroAAdivinar)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(" ¡¡¡Casi!!!");
                                    Console.WriteLine(" El número a acertar es MAYOR al introducido.");
                                    Console.WriteLine();
                                    contadorIntentosJugadorDos++;
                                }
                                if (numeroJugadorDos > numeroAAdivinar)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(" ¡¡¡Casi!!!");
                                    Console.WriteLine(" El número a acertar es MENOR al introducido.");
                                    Console.WriteLine();
                                    contadorIntentosJugadorDos++;
                                }

                                Thread.Sleep(tiempoEsperaIntentos); // Tiempo de espera para leer la información sobre el intento.
                                Console.Clear();
                                Console.WriteLine(" *** JUGADOR 2 ***");
                                Console.WriteLine();
                                Console.Write(" Introduce tu número a adivinar: ");
                                numeroJugadorDos = int.Parse(Console.ReadLine());
                            }

                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine(" ***********************");
                            Console.WriteLine("   ¡¡¡LO LOGRASTE!!!");
                            Console.WriteLine(" ***********************");
                            Console.WriteLine();
                            Console.WriteLine(" El número a adivinar es: {0}", numeroAAdivinar);
                            if (contadorIntentosJugadorDos == 0)
                            {
                                Console.WriteLine(" Lo has conseguido en {0} intento.", contadorIntentosJugadorDos + 1);
                            }
                            else
                            {
                                Console.WriteLine(" Lo has conseguido en {0} intentos.", contadorIntentosJugadorDos + 1);
                            }
                            Console.WriteLine();
                            Console.Write(" Pulsa cualquier tecla para salir");

                            for (int i = 0; i < 3; i++)
                            {
                                Thread.Sleep(200);
                                Console.SetCursorPosition(33, 8);
                                Console.Write(".");
                                Thread.Sleep(200);
                                Console.Write(".");
                                Thread.Sleep(200);
                                Console.Write(".");
                                Console.SetCursorPosition(33, 8);
                                Thread.Sleep(200);
                                Console.Write("   ");
                            }
                        }
                    }
                }

                if (numeroJugadores == tresJugadores)   // Código para tres jugadores.
                {
                }

                if (numeroJugadores == cuatroJugadores) // Código para cuatro jugadores.
                {
                }

                if (numeroJugadores < 2 || numeroJugadores > 4) // Excepción fuera del rango de jugadores o formato incorrecto.
                {
                    ErrorJugadores(tiempoEsperaSalirJuego);
                }
            }
            catch (Exception)
            {
                ErrorJugadores(tiempoEsperaSalirJuego);
            }

            Console.ReadLine();
        }

        private static void EscribirTituloJuego()
        {
            Console.WriteLine();
            Console.WriteLine("                             ========================= ");
            Console.WriteLine("                              JUEGO ACIERTA EL NUMERO ");
            Console.WriteLine("                             ========================= ");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void ErrorJugadores(int tiempoEsperaSalirJuego)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ERROR: EL PARÁMETRO NÚMERO DE JUGADORES TIENE UN FORMATO INCORRECTO.");
            Thread.Sleep(tiempoEsperaSalirJuego);
            Environment.Exit(0);
        }

        private static void ErrorFormatoNumeroAAcertar(int tiempoEsperaSalirJuego)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ERROR: EL PARÁMETRO NÚMERO TIENE UN FORMATO INCORRECTO.");
            Thread.Sleep(tiempoEsperaSalirJuego);
            Environment.Exit(0);
        }
    }
}