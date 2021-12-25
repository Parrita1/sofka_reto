using System;
using System.Collections.Generic;
using System.Linq;
using sofka_reto_tecnico.Models;

namespace sofka_reto_tecnico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego();

            PreguntaBDPosgrest preguntaBDPosgrest = new PreguntaBDPosgrest();
            JugadorBDPosgres jugadorBDPosgres = new JugadorBDPosgres();

            juego.ArrancarJuego(preguntaBDPosgrest, jugadorBDPosgres);

            var jugadores = jugadorBDPosgres.Get();
            foreach (var jugador1 in jugadores)
            {
                Console.WriteLine(jugador1.ToString());
            }
        }
    }
}
