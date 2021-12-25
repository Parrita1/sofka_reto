using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sofka_reto_tecnico.Models
{
    internal class Juego
    {
        public void ArrancarJuego(PreguntaBDPosgrest preguntaBDPosgrest, JugadorBDPosgres jugadorBDPosgres)
        {
            var preguntas = preguntaBDPosgrest.GetPosgres();

            Console.WriteLine("\nBienvenido Ingresa tu NickName:\n");
            string userName = Console.ReadLine();

            Jugador jugador = new Jugador(userName);
            Console.WriteLine($"\nHola {jugador.Name}, :)");

            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"\nApenas tenemos {jugador.Score} puntos. :(\n\nQuieres continuar jugando?\n\n1- Si.\n2- No.\n");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    var random = new Random();
                    var preguntasTop5 = new List<Pregunta>();
                    var index = 0;
                    var preguntaRonda = new Pregunta();

                    switch (i)
                    {
                        case 1:
                            preguntasTop5 = preguntas.Take(5).ToList();
                            index = random.Next(preguntasTop5.Count());
                            preguntaRonda = preguntasTop5[index];
                            break;
                        case 2:
                            preguntasTop5 = preguntas.Skip(5).Take(5).ToList();
                            index = random.Next(preguntasTop5.Count());
                            preguntaRonda = preguntasTop5[index];
                            break;
                        case 3:
                            preguntasTop5 = preguntas.Skip(10).Take(5).ToList();
                            index = random.Next(preguntasTop5.Count());
                            preguntaRonda = preguntasTop5[index];
                            break;
                        case 4:
                            preguntasTop5 = preguntas.Skip(15).Take(5).ToList();
                            index = random.Next(preguntasTop5.Count());
                            preguntaRonda = preguntasTop5[index];
                            break;
                        case 5:
                            preguntasTop5 = preguntas.Skip(20).Take(5).ToList();
                            index = random.Next(preguntasTop5.Count());
                            preguntaRonda = preguntasTop5[index];
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(preguntaRonda.ToString());
                    string answer_player = Console.ReadLine().ToLower();

                    if (answer_player == preguntaRonda.correct_answer)
                    {
                        jugador.SumarPuntaje(100 * i);
                        Console.WriteLine($"\nGenial!! ya tienes {jugador.Score} puntos.\n");
                    }
                    else
                    {
                        jugador.Score = 0;
                        Console.WriteLine("\nLo siento.\n");
                        break;
                    }
                }
                else if (opcion == "2")
                {
                    Console.WriteLine($"\nBueno... si eso quieres {jugador.Name}\nAdios.\n");
                    break;
                }
                else
                {
                    Console.WriteLine("No ingresaste una opcion correcta\nAdios.");
                    break;
                }
                if (jugador.Score == 1500)
                { Console.WriteLine($"\n{jugador.Name} Ganaste todos los puntos del juego!!\n Felicitaciones!!\n"); }
            }
            jugadorBDPosgres.AgregarJugador(jugador);
            Console.WriteLine($"\nTu Puntuacion Final es: {jugador.Score}\n\n\n\n\n" +
                $"\t---PUNTUACIONES HISTORICAS---\n\n");

        }
    }
}
