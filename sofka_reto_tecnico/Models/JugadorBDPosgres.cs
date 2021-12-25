using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace sofka_reto_tecnico.Models
{
    internal class JugadorBDPosgres
    {
        private string connectionString = "server= ec2-54-204-99-176.compute-1.amazonaws.com; Port= 5432; User Id= vxcjwzillpvwyn; Password= d76e49c62be5fd37b35e91e2806c790f9b236e539e5c4022647c14caa875365d; Database= d3q98egnpu4b5a;";

        public List<Jugador> Get()
        {
            List<Jugador> jugadores = new List<Jugador>();

            string query = "SELECT Name, Score FROM Jugador ORDER BY Score DESC";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string Name = reader.GetString(0);
                    int Score = reader.GetInt32(1);
                    Jugador jugador = new Jugador(Name, Score);
                    jugadores.Add(jugador);
                }
                reader.Close();
                connection.Close();
            }

            return jugadores;
        }

        public void AgregarJugador(Jugador jugador)
        {
            string query = "insert into Jugador(Name, Score) " + "values(@Name, @Score)";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand npgsqlCommand = new   NpgsqlCommand(query, connection);
                npgsqlCommand.Parameters.AddWithValue("@Name", jugador.Name);
                npgsqlCommand.Parameters.AddWithValue("@Score", jugador.Score);

                connection.Open();
                npgsqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

    }
}
