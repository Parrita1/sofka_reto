using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sofka_reto_tecnico.Models
{
    internal class Jugador
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Jugador(string name)
        {
            this.Name = name;
            this.Score = 0;
        }
        public Jugador(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public void SumarPuntaje (int Ganado)
        {
            this.Score += Ganado;
        }

        public override string ToString()
        {
            return $"\t{Name}\t-->\t{Score}\n";
        }
    }
}
