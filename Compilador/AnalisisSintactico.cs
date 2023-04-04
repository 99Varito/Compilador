using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Compilador
{
    internal class AnalisisSintactico
    {
        private AnalisisLexico analisisLexico;
        private List<Token> tokens;
        private int posicionActual;

        public AnalisisSintactico(AnalisisLexico analisisLexico)
        {
            this.analisisLexico = analisisLexico;
            tokens = analisisLexico.AnalizarTexto();
            posicionActual = 0;
        }

        public void Analizar()
        {
            Programa();
        }

        private void Programa()
        {
            // Regla de la gramática: <Programa> ::= <Declaraciones>
            Declaraciones();
        }

        private void Declaraciones()
        {
         
            
            switch (tokens[posicionActual].Valor )
            {
                case "int":
                    while (posicionActual < tokens.Count && (tokens[posicionActual].Tipo == TipoToken.PalabraReservada && tokens[posicionActual].Valor == "int"))
                    {
                       Arbol_Var_NUmerico();
                      
                    }
              


                    break;

                case "double":
                    while (posicionActual < tokens.Count && (tokens[posicionActual].Tipo == TipoToken.PalabraReservada && tokens[posicionActual].Valor == "double"))
                    {
                        Arbol_Var_NUmerico();

                    }


                    break;


                case "float":
                    while (posicionActual < tokens.Count && (tokens[posicionActual].Tipo == TipoToken.PalabraReservada && tokens[posicionActual].Valor == "float"))
                    {
                        Arbol_Var_NUmerico();
                    }
                    break;
                case "string":
                    while (posicionActual < tokens.Count && (tokens[posicionActual].Tipo == TipoToken.PalabraReservada && tokens[posicionActual].Valor == "string"))
                    {
                        Arbol_Var_Texto();
                    }
                    break;

                case "char":
                    while (posicionActual < tokens.Count && (tokens[posicionActual].Tipo == TipoToken.PalabraReservada && tokens[posicionActual].Valor == "char"))
                    {
                        Arbol_Var_Texto();
                    }
                    break;

                
                   
            }
         

        }

         private void Arbol_Var_NUmerico()
        {
            // Regla de la gramática: <Declaracion> ::= "operador numerico" <Identificador> ";"
            Emparejar(TipoToken.PalabraReservada);
            Emparejar(TipoToken.Identificador);
            if (tokens[posicionActual].Valor != ";")
            {
                Emparejar(TipoToken.Asignacion);
                Emparejar(TipoToken.ConstanteNumerica);
                
                while (tokens[posicionActual].Tipo == TipoToken.Operador)
                {
                    Emparejar(TipoToken.Operador);
                    Emparejar(TipoToken.ConstanteNumerica);
                }


            }
           
                Emparejar(TipoToken.PuntoYComa);

            if (tokens[posicionActual].Tipo == TipoToken.PuntoYComa && tokens[posicionActual].Valor == ";")
            {
                posicionActual++;
            }

        }
        
        private void Arbol_Var_Texto()
        {
            // Regla de la gramática: <Declaracion> ::= "operador tect" <Identificador> ";"
            Emparejar(TipoToken.PalabraReservada);
        Emparejar(TipoToken.Identificador);
            if (tokens[posicionActual].Valor != ";")
            {
                Emparejar(TipoToken.Asignacion);
                Emparejar(TipoToken.Cadena);

            }

    Emparejar(TipoToken.PuntoYComa);

            if (tokens[posicionActual].Tipo == TipoToken.PuntoYComa && tokens[posicionActual].Valor == ";")
            {
                posicionActual++;
            }

        }



private void Emparejar(TipoToken tipoToken)
        {
            if (posicionActual < tokens.Count && tokens[posicionActual].Tipo == tipoToken)
            {
                posicionActual++;
            }
            else
            {
                throw new Exception($"Se esperaba un token de tipo {tipoToken}, pero se encontró {tokens[posicionActual].Tipo},linea no > {tokens[posicionActual]}");
            }
        }
    }
}