using System;
using System.Threading;

namespace PROG_REL3_EJ8_Vera_Guillermo
{
    internal class Program
    {
        // Declaramos los campos.
        private static int _tiempoEsperaSalirJuego = 3500;

        private static int _tiempoEsperaIntentos = 800;
        private static int _numeroAAdivinar = 0;

        public static int TiempoEsperaSalirJuego { get => _tiempoEsperaSalirJuego; set => _tiempoEsperaSalirJuego = value; }
        public static int TiempoEsperaIntentos { get => _tiempoEsperaIntentos; set => _tiempoEsperaIntentos = value; }
        public static int NumeroAAdivinar { get => _numeroAAdivinar; set => _numeroAAdivinar = value; }

        private static void Main(string[] args)
        {
            // Título del juego en la consola.
            Console.Title = "Juego Acertar Número  (2-4 Jugadores)";

            // Declaramos.
            int tiempoEsperaMenuPrincipal = 2000;
            int numeroJugadores = 0;
            int numeroJugadorDos = 0;
            int numeroJugadorTres = 0;
            int numeroJugadorCuatro = 0;
            int contadorIntentosJugadorDos = 0;
            int contadorIntentosJugadorTres = 0;
            int numeroIntentosJugadorCuatro = 0;
            int dosJugadores = 2;
            int tresJugadores = 3;
            int cuatroJugadores = 4;

            Console.Clear();    // Limpiamos la consola antes de iniciar el juego.
            Console.BackgroundColor = ConsoleColor.Blue;    // Cambiamos el color del fondo de la consola a Azul.
            Console.Clear();    // Limpiamos la consola para pintar el fondo entero.

            // Llamada al método para escribir el título del juego.
            EscribirTituloJuego();

            Console.WriteLine(" El juego consiste en adivinar el número del 0 al 100 que otro jugador a introducido.");

            // Tiempo de espera hasta elegir el número de jugadores.
            Thread.Sleep(tiempoEsperaMenuPrincipal);

            Console.Clear();

            // Llamada al método para escribir el título del juego.
            EscribirTituloJuego();

            try
            {
                Console.Write(" Introduce el número de jugadores (2-4): ");
                numeroJugadores = int.Parse(Console.ReadLine());    // Lee el número de jugadores.

                // Llamada al método para dos jugadores.
                DosJugadores(numeroJugadores, ref numeroJugadorDos, ref contadorIntentosJugadorDos, dosJugadores);

                if (numeroJugadores == tresJugadores)   // Código para tres jugadores.
                {
                }

                if (numeroJugadores == cuatroJugadores) // Código para cuatro jugadores.
                {
                }

                if (numeroJugadores < 2 || numeroJugadores > 4) // Excepción fuera del rango de jugadores o formato incorrecto.
                {
                    ErrorJugadores(TiempoEsperaSalirJuego);
                }
            }
            catch (Exception)
            {
                ErrorJugadores(TiempoEsperaSalirJuego);
            }

            Console.ReadLine();
        }

        private static void DosJugadores(int numeroJugadores, ref int numeroJugadorDos, ref int contadorIntentosJugadorDos, int dosJugadores)
        {
            if (numeroJugadores == dosJugadores)    // Código para dos jugadores.
            {
                Console.Clear();
                // Llamada al método para escribir el título del juego.
                EscribirTituloJuego();

                Console.WriteLine();
                Console.WriteLine(" *** JUGADOR 1 ***");
                Console.WriteLine();
                Console.Write(" Introduce el número a adivinar por los demás jugadores (0 al 100): ");

                // Método que sustituye caracteres por asteriscos, como contraseñas.
                SustituirCaracterPorAsteriscos();

                if (NumeroAAdivinar < 0 || NumeroAAdivinar > 100)
                {
                    ErrorFormatoNumeroAAcertar(TiempoEsperaSalirJuego); // Ejecuta el método con el tiempo de espera.
                }
                else
                {
                    Console.Clear();
                    // Llamada al método para escribir el título del juego.
                    EscribirTituloJuego();

                    Console.WriteLine();
                    Console.WriteLine(" *** JUGADOR 2 ***");
                    Console.WriteLine();
                    Console.Write(" Introduce tu número a adivinar: ");
                    numeroJugadorDos = int.Parse(Console.ReadLine());

                    if (numeroJugadorDos < 0 || numeroJugadorDos > 100)
                    {
                        ErrorFormatoNumeroAAcertar(TiempoEsperaSalirJuego); // Ejecuta el método con el tiempo de espera.
                    }
                    else
                    {
                        // Mientras el "numeroAADivinar" esté en esta expresión, se ejecutará el siguiente código.
                        while (numeroJugadorDos != NumeroAAdivinar && numeroJugadorDos >= 0 && numeroJugadorDos <= 100)
                        {
                            if (numeroJugadorDos < NumeroAAdivinar)
                            {
                                // Llamada al método para escribir el título del juego.
                                EscribirTituloJuego();

                                Console.WriteLine();
                                Console.WriteLine(" ¡¡¡Casi!!!");
                                Console.WriteLine(" El número a acertar es MAYOR al introducido.");
                                Console.WriteLine();
                                contadorIntentosJugadorDos++;
                            }
                            if (numeroJugadorDos > NumeroAAdivinar)
                            {
                                // Llamada al método para escribir el título del juego.
                                EscribirTituloJuego();

                                Console.WriteLine();
                                Console.WriteLine(" ¡¡¡Casi!!!");
                                Console.WriteLine(" El número a acertar es MENOR al introducido.");
                                Console.WriteLine();
                                contadorIntentosJugadorDos++;
                            }

                            Thread.Sleep(TiempoEsperaIntentos); // Tiempo de espera para leer la información sobre el intento.
                            Console.Clear();
                            // Llamada al método para escribir el título del juego.
                            EscribirTituloJuego();

                            Console.WriteLine(" *** JUGADOR 2 ***");
                            Console.WriteLine();
                            Console.Write(" Introduce tu número a adivinar: ");
                            numeroJugadorDos = int.Parse(Console.ReadLine());
                        }

                        Console.Clear();
                        // Llamada al método para escribir el título del juego.
                        EscribirTituloJuego();

                        Console.WriteLine();
                        Console.WriteLine(" ***********************");
                        Console.WriteLine("   ¡¡¡LO LOGRASTE!!!");
                        Console.WriteLine(" ***********************");
                        Console.WriteLine();
                        Console.WriteLine(" El número a adivinar es: {0}", NumeroAAdivinar);

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

                        // Bucle para escribir tres puntos, tres veces, justo después del mensaje anterior.
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
        }

        /// <summary>
        /// Método que sustituye los carácteres introducidos por teclado por asteriscos '*'.
        /// </summary>
        private static void SustituirCaracterPorAsteriscos()
        {
            // Declaramos una variable temporal que se comporta como un string.
            string tmpNumeroAADivinar = "";

            // Declaramos para ocultar caracter del "numeroAADivinar".
            ConsoleKeyInfo ultimaTecla;
            bool continuar = true;
            char asterisco = '*'; //Caracter que mostrará.

            // Ocultar número a mostrar
            while (continuar)
            {
                ultimaTecla = Console.ReadKey(true);
                if (ultimaTecla.KeyChar != (char)ConsoleKey.Enter && ultimaTecla.KeyChar != (char)ConsoleKey.Delete && ultimaTecla.KeyChar != (char)ConsoleKey.Clear)
                {
                    tmpNumeroAADivinar = tmpNumeroAADivinar + ultimaTecla.KeyChar;
                    Console.Write(asterisco);
                }
                else
                    continuar = false;
            }

            // Se convierte la variable temporal a entero y su valor se guarda en la variable original.
            NumeroAAdivinar = int.Parse(tmpNumeroAADivinar);
        }

        /// <summary>
        /// Método que escribe el título del juego.
        /// </summary>
        private static void EscribirTituloJuego()
        {
            Console.WriteLine();
            Console.WriteLine("                             ========================= ");
            Console.WriteLine("                              JUEGO ACIERTA EL NUMERO ");
            Console.WriteLine("                             ========================= ");
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Método que muestra un mensaje de error en el número de jugadores. Luego se cierra la aplicación.
        /// </summary>
        /// <param name="tiempoEsperaSalirJuego"></param>
        private static void ErrorJugadores(int tiempoEsperaSalirJuego)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ERROR: EL PARÁMETRO NÚMERO DE JUGADORES TIENE UN FORMATO INCORRECTO.");
            Thread.Sleep(tiempoEsperaSalirJuego);
            Environment.Exit(0);
        }

        /// <summary>
        /// Método que muestra un mensaje de error en el parámetro número. Luego se cierra la aplicación.
        /// </summary>
        /// <param name="tiempoEsperaSalirJuego"></param>
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
