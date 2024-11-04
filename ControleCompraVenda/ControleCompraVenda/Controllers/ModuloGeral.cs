using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class ModuloGeral
    {
        public static Modulo MATERIAL = new Modulo("MATERIAL", 1);
        public static Modulo PESSOA = new Modulo("PESSOA", 2);
        public static Modulo MOVIMENTO = new Modulo("MOVIMENTO", 3);
        public static Modulo ESTOQUE = new Modulo("ESTOQUE", 4);
        public static Modulo MOVMATERIAIS = new Modulo("MOVMATERIAIS", 5);
        public static Modulo PAGAMENTO = new Modulo("PAGAMENTO", 6);
        public static Modulo CAIXAMOVIMENTO = new Modulo("CAIXAMOVIMENTO", 7);
    }
}
