using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades

{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        public Numeracion PrimerOperando
        {
            get { return primerOperando; }
            set { primerOperando = value; }
        }

        public Numeracion SegundoOperando
        {
            get { return segundoOperando; }
            set { segundoOperando = value; }
        }

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            PrimerOperando = primerOperando;
            SegundoOperando = segundoOperando;

        }

        public Numeracion Operar(char operador)
        {
            switch (operador)
            {
                case '+':
                    return new Numeracion(Convert.ToDouble(primerOperando.valor) + Convert.ToDouble(segundoOperando.valor), Numeracion.ESistema.Decimal);
                case '-':
                    return new Numeracion(Convert.ToDouble(primerOperando.valor) - Convert.ToDouble(segundoOperando.valor), Numeracion.ESistema.Decimal);
                case '*':
                    return new Numeracion(Convert.ToDouble(primerOperando.valor) * Convert.ToDouble(segundoOperando.valor), Numeracion.ESistema.Decimal);
                case '/':
                    return new Numeracion(Convert.ToDouble(primerOperando.valor) / Convert.ToDouble(segundoOperando.valor), Numeracion.ESistema.Decimal);
                default:
                    return new Numeracion(Convert.ToDouble(primerOperando.valor) + Convert.ToDouble(segundoOperando.valor), Numeracion.ESistema.Decimal);
            }   
        }





    }
}