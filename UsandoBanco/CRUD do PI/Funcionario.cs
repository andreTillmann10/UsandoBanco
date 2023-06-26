using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoBanco.CRUD_do_PI
{
    internal class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public DateTime NascimentoFuncionario { get; set; }
        public string CpfFuncionario { get; set; }
        public double SalarioFuncionario { get; set; }
        public string CargoFuncionario { get; set; }
        public DateTime DataContratacao { get; set; }

    }
}
