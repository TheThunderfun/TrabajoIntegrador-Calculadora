namespace Entidades
{
    public class Numeracion
    {   

        public enum ESistema
        {
            Decimal,
            Binario
        }
        private ESistema sistema;
        private double valorNumerico;


        public ESistema Sistema
        {
            get { return sistema; }
        }
        public string valor
        {
            get { return valorNumerico.ToString(); }
        }


        public Numeracion(string valorNumerico, ESistema sistema)
        {

            InicializarValores(valorNumerico, sistema);
        }
        public Numeracion(double valorNumerico, ESistema sistema) : this(valorNumerico.ToString(), sistema)
        {

        }

        private void InicializarValores(string valor, ESistema sistema)
        {
            if (sistema == ESistema.Binario && EsBinario(valor))
            {
                this.valorNumerico = BinarioADecimal(valor);

            }
            else if (valor != null && !EsBinario(valor))
            {
                this.valorNumerico = Convert.ToDouble(valor);
            }
            else
            {
                this.valorNumerico = double.MinValue;
            }
        }

        private static double BinarioADecimal(string valor)
        {
            if (EsBinario(valor) == true)
            {

                int numeroDecimal = Convert.ToInt32(valor, 2);
                return Convert.ToDouble(numeroDecimal);
            }
            else
            {
                return 0;
            }

        }

        public string ConvertirA(ESistema sistema)
        {
            if (sistema == this.sistema)
            {
                return this.valorNumerico.ToString();
            }
            else
            {
                return DecimalABinario(this.valorNumerico.ToString());
            }


        }
        private static string DecimalABinario(int valor)
        {

            if (valor < 0)
            {
                return "Numero invalido";
            }
            else
            {
                return Convert.ToString(valor, 2);
            }

        }

        private static string DecimalABinario(string valor)
        {
            if (valor[0] == '-' || valor == null)
            {
                return "Numero invalido";
            }
            return DecimalABinario((int)Convert.ToInt64(valor));
        }


        private static bool EsBinario(string valor)
        {


            if (valor == null && valor.Length < 1)
            {
                return false;
            }

            foreach (char c in valor)
            {
                if (c != '0' || c != '1')
                {
                    return false;
                }

            }

            return true;

        }
        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return sistema != numeracion.sistema;
        }

        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            return sistema == numeracion.sistema;
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return n1.sistema != n2.sistema;
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return n1.sistema == n2.sistema;
        }

        public static Numeracion operator +(Numeracion n1, Numeracion n2)
        {
            double aux = Convert.ToDouble(n1.valor) + Convert.ToDouble(n2.valor);
            return new Numeracion(aux.ToString(), ESistema.Decimal);

        }
        public static Numeracion operator -(Numeracion n1, Numeracion n2)
        {
            double aux = Convert.ToDouble(n1.valor) - Convert.ToDouble(n2.valor);
            return new Numeracion(aux.ToString(), ESistema.Decimal);
        }
        public static Numeracion operator *(Numeracion n1, Numeracion n2)
        {
            double aux = Convert.ToDouble(n1.valor) * Convert.ToDouble(n2.valor);
            return new Numeracion(aux.ToString(), ESistema.Decimal);

        }
        public static Numeracion operator /(Numeracion n1, Numeracion n2)
        {
            double aux = Convert.ToDouble(n1.valor) / Convert.ToDouble(n2.valor);
            return new Numeracion(aux.ToString(), ESistema.Decimal);
        }
    }
}