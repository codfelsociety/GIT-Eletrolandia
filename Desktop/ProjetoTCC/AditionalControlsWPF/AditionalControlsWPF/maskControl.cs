using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AditionalControlsWPF
{
    public class maskControl : TextBox
    {



        private String tipo;

        //Property Tipo onde o programador vai definir o tipo cnpj ou cpf
        public String Tipo
        {
            get { return tipo; }
            set
            {
                try
                {
                    tipo = value;

                    //Verifica qual o tipo para atribuir
                    //o tamanho maximo da string
                    if (tipo.ToUpper() == "CPF")
                    {
                        MaxLength = 14;
                    }
                    else if (tipo.ToUpper() == "CNPJ")
                    {
                        MaxLength = 18;
                    }
                }
                catch
                {
                    //Exception criada para caso o objeto esteja sem tipo
                    throw new Exception("TextBoxCpfCnpj: Entre com o Tipo, CNPJ ou CPF");
                }

            }
        }

        //Sobescreve o metodo OnLeave
        //Verifica qual o tipo CNPJ ou CPF
        //e chama a validação, caso retorne
        //falso retorna o foco ao objeto 
        //e emite um beep
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (tipo.ToUpper() == "CPF")
            {
                if (!ValidaCPF(Text))
                {
                    System.Console.Beep(100, 100);
                    this.Focus();
                }
            }

            if (tipo.ToUpper() == "CNPJ")
            {
                if (!ValidaCnpj(Text))
                {
                    System.Console.Beep(100, 100);
                    this.Focus();
                }
            }
        }

        //Metodo que cria a mascara dinamica para CPF
        private void AjustaMascaraCPF()
        {
            int cont = 0;
            int cursorPos = SelectionStart;

            foreach (Char c in Text)
            {
                if (((cont == 3) || (cont == 7)) && (c != '.') && (Text.Length >= cont))
                {
                    Text = Text.Insert(cont, ".");
                    SelectionStart = cursorPos + 1;
                }
                if ((c == '.') && (Text.Length >= cont) && (cont != 3) && (cont != 7))
                {
                    Text = Text.Remove(cont, 1);
                    SelectionStart = cursorPos;
                }

                if ((cont == 11) && (c != '-') && (Text.Length >= cont))
                {
                    Text = Text.Insert(11, "-");
                    SelectionStart = cursorPos + 1;
                }
                if ((c == '-') && (cont != 11) && (Text.Length >= cont))
                {
                    Text = Text.Remove(cont, 1);
                    SelectionStart = cursorPos;
                }

                cont++;
            }
        }

        //Metodo que cria a mascara dinamica para CNPJ
        private void AjustaMascaraCnpj()
        {
            int cont = 0;
            int cursorPos = SelectionStart;

            foreach (Char c in Text)
            {
                if (((cont == 2) || (cont == 6)) && (c != '.') && (Text.Length >= cont))
                {
                    Text = Text.Insert(cont, ".");
                    SelectionStart = cursorPos + 1;
                }
                if ((c == '.') && (Text.Length >= cont) && (cont != 2) && (cont != 6))
                {
                    Text = Text.Remove(cont, 1);
                    SelectionStart = cursorPos;
                }

                if ((cont == 10) && (c != '\\') && (Text.Length >= cont))
                {
                    Text = Text.Insert(10, @"\");
                    SelectionStart = cursorPos + 1;
                }
                if ((c == '\\') && (cont != 10) && (Text.Length >= cont))
                {
                    Text = Text.Remove(cont, 1);
                    SelectionStart = cursorPos;
                }

                if ((cont == 15) && (c != '-') && (Text.Length >= cont))
                {
                    Text = Text.Insert(15, "-");
                    SelectionStart = cursorPos + 1;
                }
                if ((c == '-') && (cont != 15) && (Text.Length >= cont))
                {
                    Text = Text.Remove(cont, 1);
                    SelectionStart = cursorPos;
                }

                cont++;
            }
        }


        //Sobescreve o metodo OnKeyUp
        //Verifica qual o tipo CPF ou CNPJ
        //e e chama o metodo para a mascara dinamica
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (tipo.ToUpper() == "CPF")
                AjustaMascaraCPF();
            else if (tipo.ToUpper() == "CNPJ")
                AjustaMascaraCnpj();
        }


        //Sobescreve o metodo onKeyPress, para evitar que 
        //o usuario entre com um valor não numerico
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != '\x0008'))
            {
                e.KeyChar = '\x0000';
            }
        }

        //Sobrecarga de construtores
        //permitindo criar o objeto em tempo de execução
        //atribuindo o tipo
        public maskControl(String t) { Tipo = t; }
        public maskControl() { }

        //Valida CPF
        private bool ValidaCPF(String cpf)
        {
            Boolean valida = true;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            String tempCpf;
            String digito;
            String verifica;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace("-", "").Replace(".", "");

            if (cpf.Length == 11)
            {
                verifica = cpf.Substring(9);
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma = soma + int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                }

                resto = soma % 11;

                resto = resto < 2 ? resto = 0 : resto = 11 - resto; ;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                {
                    soma = soma + int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                }

                resto = soma % 11;

                resto = resto < 2 ? resto = 0 : resto = 11 - resto; ;

                digito = digito + resto.ToString();

                if (digito != verifica)
                {
                    valida = false;
                }
                switch (cpf)
                {
                    case "00000000000":
                        {
                            valida = false;
                            break;
                        }
                    case "11111111111":
                        {
                            valida = false;
                            break;
                        }
                    case "  22222222222 ":
                        {
                            valida = false;
                            break;
                        }
                    case "33333333333":
                        {
                            valida = false;
                            break;
                        }
                    case "44444444444":
                        {
                            valida = false;
                            break;
                        }
                    case "55555555555":
                        {
                            valida = false;
                            break;
                        }
                    case "66666666666":
                        {
                            valida = false;
                            break;
                        }
                    case "77777777777":
                        {
                            valida = false;
                            break;
                        }
                    case "88888888888":
                        {
                            valida = false;
                            break;
                        }
                    case "99999999999":
                        {
                            valida = false;
                            break;
                        }
                }
            }
            else
            {
                valida = false;
            }
            return valida;
        }

        //Valida  CNPJ
        private bool ValidaCnpj(String cnpj)
        {
            Boolean valida = true;
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            String tempCnpj;
            String digito;
            String verifica;
            int soma;
            int resto;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace("/", "").Replace(".", "").Replace("-", "");

            if (cnpj.Length == 14)
            {
                verifica = cnpj.Substring(12);
                tempCnpj = cnpj.Substring(0, 12);
                soma = 0;

                for (int i = 0; i < 12; i++)
                {
                    soma = soma + int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                }

                resto = soma % 11;
                resto = resto < 2 ? resto = 0 : resto = 11 - resto; ;
                digito = resto.ToString();

                tempCnpj = tempCnpj + digito;

                soma = 0;
                for (int i = 0; i < 13; i++)
                {
                    soma = soma + int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                }

                resto = soma % 11;
                resto = resto < 2 ? resto = 0 : resto = 11 - resto; ;
                digito = digito + resto.ToString();

                if (digito != verifica)
                {
                    valida = false;
                }

                switch (cnpj)
                {
                    case "11111111111111":
                        {
                            valida = false;
                            break;
                        }
                    case "22222222222222":
                        {
                            valida = false;
                            break;
                        }
                    case "33333333333333":
                        {
                            valida = false;
                            break;
                        }
                    case "44444444444444":
                        {
                            valida = false;
                            break;
                        }
                    case "55555555555555":
                        {
                            valida = false;
                            break;
                        }
                    case "66666666666666":
                        {
                            valida = false;
                            break;
                        }
                    case "77777777777777":
                        {
                            valida = false;
                            break;
                        }
                    case "88888888888888":
                        {
                            valida = false;
                            break;
                        }
                    case "99999999999999":
                        {
                            valida = false;
                            break;
                        }
                }
            }
            else
            {
                valida = false;
            }
            return valida;
        }
    }
}


