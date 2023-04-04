using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Compilador;
namespace Compilador
{
    internal class AnalisisLexico
    {
     string texto="" ;
        
       
        private List<Token> tokens = new List<Token>();

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public void IngresarTexto()
        {
            Console.Write("Ingrese una cadena de texto: ");
            texto = Console.ReadLine();
        }

        public void MostrarTexto()
        {
            Console.WriteLine("El texto ingresado es: {0}", texto);
        }

        public List<Token> AnalizarTexto()
        {
           
            // Convierte el string a un arreglo de caracteres
            char[] caracteres = texto.ToCharArray();
            int longitud = texto.Length;

            // Analiza el texto carácter por carácter
            int i = 0;
            while (i < longitud && char.IsWhiteSpace(caracteres[i]))
            {
                i++;
            }

            while (i < longitud)
            {
                // Verifica si el carácter es una palabra reservada o un identificador
                if (char.IsLetter(caracteres[i]))
                {
                    int j = i;
                    while (j < longitud && char.IsLetterOrDigit(caracteres[j]))
                    {
                        j++;
                    }
                    string palabra = Texto.Substring(i, j - i);
                    if (esPalabraReservada(palabra))
                    {
                        tokens.Add(new Token(palabra, TipoToken.PalabraReservada));
                    }
                    else
                    {
                        tokens.Add(new Token(palabra, TipoToken.Identificador));
                    }
                    i = j;
                }
                // verifica si es de tipo cadena 
                else if (caracteres[i] == '"')
                {
                    int j = i + 1;
                    while (j < longitud && caracteres[j] != '"' || (j > 0 && caracteres[j - 1] == '\\'))
                    {
                        j++;
                    }
                    tokens.Add(new Token(texto.Substring(i, j - i + 1), TipoToken.Cadena));
                    i = j + 1;
                }
                // punto y coma 
                else if (caracteres[i] == ';')
                {
                    tokens.Add(new Token(";", TipoToken.PuntoYComa));
                    i++;
                }
                // asignacion
                    else if (caracteres[i] == '=')
                {
                    tokens.Add(new Token("=", TipoToken.Asignacion));
                    i++;
                }
                // Verifica si el carácter es un número
                else if (char.IsDigit(caracteres[i]))
                {
                    int j = i;
                    while (j < longitud && char.IsDigit(caracteres[j]))
                    {
                        j++;
                    }
                    tokens.Add(new Token(texto.Substring(i, j - i), TipoToken.ConstanteNumerica));
                    i = j;
                }
                // Verifica si el carácter es un operador
                else if (i < longitud - 1 && esOperador(texto.Substring(i, 2)))
                {
                    tokens.Add(new Token(texto.Substring(i, 2), TipoToken.Operador));
                    i += 2;
                }
                else if (esOperador(texto.Substring(i, 1)))
                {
                    tokens.Add(new Token(caracteres[i].ToString(), TipoToken.Operador));
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return tokens;
        }

        private bool esPalabraReservada(string palabra)
        {
            // Aquí irían las palabras reservadas del lenguaje de programación
            return (palabra == "abstract" || palabra == "as" || palabra == "base" || palabra == "bool" || palabra == "break"
                    || palabra == "byte" || palabra == "case" || palabra == "catch" || palabra == "char" || palabra == "checked"
                    || palabra == "class" || palabra == "const" || palabra == "continue" || palabra == "decimal" || palabra == "default"
                    || palabra == "delegate" || palabra == "do" || palabra == "double" || palabra == "else" || palabra == "enum"
                    || palabra == "event" || palabra == "explicit" || palabra == "extern" || palabra == "false" || palabra == "finally"
                    || palabra == "fixed" || palabra == "float" || palabra == "for" || palabra == "foreach" || palabra == "goto"
                    || palabra == "if" || palabra == "implicit" || palabra == "in" || palabra == "int" || palabra == "interface"
                    || palabra == "internal" || palabra == "is" || palabra == "lock" || palabra == "long" || palabra == "namespace"
                    || palabra == "new" || palabra == "null" || palabra == "object" || palabra == "operator" || palabra == "out"
                    || palabra == "override" || palabra == "params" || palabra == "private" || palabra == "protected" || palabra == "public"
                    || palabra == "readonly" || palabra == "ref" || palabra == "return" || palabra == "sbyte" || palabra == "sealed"
                    || palabra == "short" || palabra == "sizeof" || palabra == "stackalloc" || palabra == "static" || palabra == "string"
                    || palabra == "struct" || palabra == "switch" || palabra == "this" || palabra == "throw" || palabra == "true"
                    || palabra == "try" || palabra == "typeof" || palabra == "uint" || palabra == "ulong" || palabra == "unchecked"
                    || palabra == "unsafe" || palabra == "ushort" || palabra == "using" || palabra == "virtual" || palabra == "void"
                    || palabra == "volatile" || palabra == "while" || palabra == "++" || palabra == "--");

        }

        private bool esOperador(string operador)
        {
            // Aquí irían los operadores del lenguaje de programación
           
                // Aquí irían los operadores del lenguaje de programación
                return (   operador == "+" || operador == "-" || operador == "*" || operador == "/" || operador == "%" || operador == "="
                        || operador == "==" || operador == "!=" || operador == ">" || operador == ">=" || operador == "<" || operador == "<="
                        || operador == "&&" || operador == "||" || operador == "!" || operador == "&" || operador == "|" || operador == "^"
                        || operador == "<<" || operador == ">>" || operador == "~" || operador == "+=" || operador == "-=" || operador == "*="
                        || operador == "/=" || operador == "%=" || operador == "&=" || operador == "|=" || operador == "^=" || operador == "<<="
                        || operador == ">>=" ||  operador == "?" || operador == ":" || operador == "=>");
            }

        }
    }



