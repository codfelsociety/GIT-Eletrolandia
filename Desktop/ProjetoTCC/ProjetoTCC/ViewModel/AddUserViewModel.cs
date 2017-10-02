using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using ProjetoTCC.Model;
using System.Windows.Media;
using ProjetoTCC.Common;
using System.Windows;
using System.Data;

namespace ProjetoTCC.ViewModel
{
    public class AddUserViewModel : Base
    {
        #region Interface
        private Brush nomeBorderColor;
        private Brush sobrenomeBorderColor;
        private Brush emailBorderColor;
        private string errorMessage;

        public Brush NomeBorderColor
        {
            get
            {
                return nomeBorderColor;
            }
            set
            {
                nomeBorderColor = value;
                RaisePropertyChanged("NomeBorderColor");
            }
        }
        public Brush SobrenomeBorderColor
        {
            get
            {
                return sobrenomeBorderColor;
            }
            set
            {
                sobrenomeBorderColor = value;
                RaisePropertyChanged("SobrenomeBorderColor");
            }
        }
        public Brush EmailBorderColor
        {
            get
            {
                return emailBorderColor;
            }
            set
            {
                emailBorderColor = value;
                RaisePropertyChanged("EmailBorderColor");
            }
        }
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        public Brush Transparent = Brushes.Transparent;
        public void Red()
        {
            NomeBorderColor = SobrenomeBorderColor = EmailBorderColor = Brushes.Red;
        }


        #endregion

        #region Sources
        private ObservableCollection<StatusUsuario> statusSource;
        public ObservableCollection<StatusUsuario> StatusSource
        {
            get
            {
                return statusSource;
            }
            set
            {
                statusSource = value;
                RaisePropertyChanged("StatusSource");
            }
        }

        private ObservableCollection<AcessoUsuario> acessoSource;
        public ObservableCollection<AcessoUsuario> AcessoSource
        {
            get
            {
                return acessoSource;
            }
            set
            {
                acessoSource = value;
                RaisePropertyChanged("AcessoSource");
            }
        }

        private bool masculino;
        public bool Masculino
        {
            get { return masculino; }
            set
            {
                masculino = value;
                if (value) Sexo = 1; else sexo = 2;
                RaisePropertyChanged("Masculino");
            }
        }
        private DataView pictureSource;
        public DataView PictureSource
        {
            get
            {
                return pictureSource;
            }
            set
            {
                pictureSource = value;
                RaisePropertyChanged("PictureSource");
            }
        }

        #endregion

        #region Comandos
        private ICommand confirmar;
        public ICommand Confirmar
        {
            get { return confirmar; }
            set
            { confirmar = value; }
        }
        #endregion

        #region Private Properties
        private int id;
        private int acesso;
        private int sexo;
        private string nome;
        private string sobrenome;
        private string username;
        private string email;
        private string senha;
        private ImageSource foto;
        private int status;
        private string dataCadastro;
        #endregion

        #region Public Properties
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        public int Acesso
        {
            get
            {
                return acesso;
            }
            set
            {
                acesso = value;
            }
        }
        public int Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
                Username = Nome.ToUpper() + "_" + Id;
                RaisePropertyChanged("Nome");
            }
        }
        public string Sobrenome
        {
            get
            {
                return sobrenome;
            }
            set
            {
                sobrenome = value;
                RaisePropertyChanged("Sobrenome");
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                RaisePropertyChanged("Username");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string Senha
        {
            get
            {
                return senha;
            }
            set
            {
                senha = value;
                RaisePropertyChanged("Senha");
            }
        }
        public ImageSource Foto
        {
            get
            {
                return foto;
            }
            set
            {
                foto = value;
                RaisePropertyChanged("Foto");
            }
        }
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                RaisePropertyChanged("Status");
            }
        }
        public string DataCadastro
        {
            get { return dataCadastro; }
            set
            {
                if (value != dataCadastro)
                {
                    dataCadastro = value;
                    RaisePropertyChanged("DataCadastro");
                }
            }
        }
        #endregion

        public void NovoUsuario(object o)
        {
            if (Validar())
            {
                Usuario usuario = new Usuario();
                usuario.Id = 0;
                usuario.DataCadastro = DateTime.Now.ToString();
                usuario.Nome = Nome;
                usuario.Sobrenome = Sobrenome;
                usuario.Sexo = Sexo;
                usuario.Foto = Image.Byte(Foto);
                usuario.Email = Email;
                usuario.Username = Username;
                usuario.Senha = Senha;
                usuario.Acesso = Acesso;
                usuario.Status = Status;
                usuario.Adicionar();
                View.Warning.Warning n = new View.Warning.Warning("Everthing is fine", "Novo Usuario Cadastrado", 9);
                n.Show();
            }
        }
        public void EditarUsuario(object o)
        {
            if (Validar())
            {
                Usuario usuario = new Usuario();
                usuario.Id = Id;
                usuario.DataCadastro = DataCadastro;
                usuario.Nome = Nome;
                usuario.Sobrenome = Sobrenome;
                usuario.Sexo = Sexo;
                usuario.Foto = Image.Byte(Foto);
                usuario.Email = Email;
                usuario.Username = Username;
                usuario.Senha = Senha;
                usuario.Acesso = Acesso;
                usuario.Status = Status;
                usuario.Adicionar();
                Message.Warning("Novo usuário cadastrado", "Everything is fine", 9);
            }
        }
        public void OprCriar()
        {
            //Executa a função AtualizarData continuamente a cada 1s
            Time.KeepExecuting(AtualizarData);
            //Atribui ao comando à função
            Confirmar = new RelayCommand(NovoUsuario);

            Id = Usuario.NextId();
            Masculino = true;
            Senha = "123456";
        }
        public void OprEditar(Usuario us)
        {
            Usuario user = new Usuario(cod);
            Nome = user.Nome;
            Sobrenome = user.Sobrenome;
            Username = user.Username;
            Senha = user.Senha;
            DataCadastro = user.DataCadastro;
            Id = user.Id;
            Email = user.Email;
            if (user.Sexo == 1) Masculino = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("COD_PRODUTO", typeof(int));
            dt.Columns.Add("IMAGEM", typeof(byte[]));
            dt.Rows.Add(1, user.Foto);
            PictureSource = dt.DefaultView;
            Status = 2;
            Acesso = 2;
        }
        public AddUserViewModel(int Opr, Usuario us)
        {
            
            //Popula o combo dos Status
            StatusSource = new ObservableCollection<StatusUsuario>(StatusUsuario.Listar());
            //Popula o combos dos Acessos
            AcessoSource = new ObservableCollection<AcessoUsuario>(AcessoUsuario.Listar());

            if (Opr == 1) OprCriar(); else OprEditar(us);




        }
        public bool Validar()
        {
            Validation.Reset(); Red();
            if (Validation.Email(Email)) EmailBorderColor = Transparent;
            if (Validation.Empty(Nome)) Validation.Error("Digite o nome"); else NomeBorderColor = Transparent;
            if (Validation.Empty(Sobrenome)) Validation.Error("Digite o sobrenome"); else SobrenomeBorderColor = Transparent;
            ErrorMessage = Validation.ErrorMessage;
            return !Validation.HasErrors();
        }
        /// <summary>  
        /// Comando atribui um novo valor(atualizado) para a propriedade DataCadastro a cada 1 segundo.
        /// </summary>
        private void AtualizarData(object sender, EventArgs e)
        {
            DataCadastro = DateTime.Now.ToString();
            CommandManager.InvalidateRequerySuggested();
        }
    }

}

