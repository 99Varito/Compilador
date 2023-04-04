using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Compilador.Token;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Compilador
{
    public class Token
    {
        public string Valor { get; set; }
        public TipoToken Tipo { get; set; }

        public Token(string valor, TipoToken tipo)
        {
            Valor = valor;
            Tipo = tipo;
        }
    }

    public enum TipoToken
    {
        PalabraReservada,
        Identificador,
        ConstanteNumerica,
        Operador,
        PuntoYComa,Cadena,Asignacion
    }





}
