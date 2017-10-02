using System;
using System.ComponentModel;
using System.Linq;
using BLL;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Data;
using System.Net.Mail;

namespace ProjetoTCC.ViewModel
{
    public class MensagemViewModel : Base
    {
        private ICommand confirmar;
        public ICommand Confirmar
        {
            get { return confirmar; }
            set
            { confirmar = value; }
        }

        private string email;
        private string assunto;
        private string conteudo;
        private object mensagemSelecionada;

        public string Email { get { return email; } set { email = value; RaisePropertyChanged("Email"); } }
        public string Assunto { get { return assunto; } set { assunto = value; RaisePropertyChanged("Assunto"); } }
        public string Conteudo { get { return conteudo; } set { conteudo = value; RaisePropertyChanged("Conteudo"); } }
        public object MensagemSelecionada
        {
            get
            {
                return mensagemSelecionada;
            }
            set 
            {
                mensagemSelecionada = value;
                Email = Convert.ToString(((DataRowView)value)["EMAIL"]);
                RaisePropertyChanged("MensagemSelecionada");
            }
        }


        public MensagemViewModel()
        {
            Confirmar = new RelayCommand(Enviar);
        }


        public string From = "codfelsociety@gmail.com";
        void Enviar(object o)
        {
            try
            {
                MailMessage mail = new MailMessage(From, Email, Assunto,Conteudo);
                SmtpClient client = new SmtpClient("smtp.gmail.com");


                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential(From, "41986737fe");
                client.EnableSsl = true;

                client.Send(mail);
                MessageBox.Show("Email enviado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
