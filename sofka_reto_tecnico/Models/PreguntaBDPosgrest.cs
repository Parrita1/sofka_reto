using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace sofka_reto_tecnico.Models
{
    internal class PreguntaBDPosgrest
    {
        private string connectionString = "server= ec2-54-204-99-176.compute-1.amazonaws.com; Port= 5432; User Id= vxcjwzillpvwyn; Password= d76e49c62be5fd37b35e91e2806c790f9b236e539e5c4022647c14caa875365d; Database= d3q98egnpu4b5a;";

        public List<Pregunta> GetPosgres()
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            string query = "select id, question, a_answer, b_answer, c_answer, d_answer, correct_answer from pregunta";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Question = reader.GetString(1);
                    string a_answer = reader.GetString(2);
                    string b_answer = reader.GetString(3);
                    string c_answer = reader.GetString(4);
                    string d_answer = reader.GetString(5);
                    string correct_answer = reader.GetString(6);
                    Pregunta pregunta = new Pregunta(Id, Question, a_answer, b_answer, c_answer, d_answer, correct_answer);
                    preguntas.Add(pregunta);
                }
                reader.Close();
                connection.Close();
            }

            return preguntas;
        }

    }
}
