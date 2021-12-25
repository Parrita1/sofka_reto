using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sofka_reto_tecnico.Models
{
    internal class Pregunta
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string a_answer { get; set; }
        public string b_answer { get; set; }
        public string c_answer { get; set; }
        public string d_answer { get; set; }
        public string correct_answer { get; set; }

        public Pregunta(int id, string question, string a_answer, string b_answer, string c_answer, string d_answer, string correct_answer)
        {
            this.Id = id;
            this.Question = question;
            this.a_answer = a_answer;
            this.b_answer = b_answer;
            this.c_answer = c_answer;
            this.d_answer = d_answer;
            this.correct_answer = correct_answer;
        }

        public Pregunta() { }

        public override string ToString()
        {
            return $"----------------------------\n{Question}\n\n\tA. {a_answer}\n\tB. {b_answer}\n\tC. {c_answer}\n\tD. {d_answer}\n----------------------------\n";
        }


    }
}
