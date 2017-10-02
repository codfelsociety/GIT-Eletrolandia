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
using System.Windows.Navigation;

namespace ProjetoTCC.ViewModel
{
    public class UserViewModel : Base
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
                if (value) Sexo = 1;
                RaisePropertyChanged("Masculino");
            }
        }

        private bool feminino;
        public bool Feminino
        {
            get { return feminino; }
            set
            {
                feminino = value;
                if (value) Sexo = 2;
                RaisePropertyChanged("Feminino");
            }
        }

        private List<byte[]> pictureSource;
        public List<byte[]> PictureSource
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

        private ICommand limpar;
        public ICommand Limpar
        {
            get { return limpar; }
            set
            { limpar = value; }
        }
        private ICommand voltar;
        public ICommand Voltar
        {
            get { return voltar; }
            set
            { voltar = value; }
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
                RaisePropertyChanged("Sexo");
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

        private NavigationService navigation;
        public NavigationService Navigation
        {
            get
            {
                return navigation;
            }
            set
            {
                navigation = value;
                RaisePropertyChanged("Navigation");
            }
        }

        public UserViewModel(NavigationService nav)
        {
            //Executa a função AtualizarData continuamente a cada 1s
            Time.KeepExecuting(AtualizarData);

            //Atribui ao comando à função
            Confirmar = new RelayCommand(NovoUsuario);
            Limpar = new RelayCommand(Reset);
            Voltar = new RelayCommand(VoltarPage);
            Navigation = nav;

            //Popula o combo dos Status
            StatusSource = new ObservableCollection<StatusUsuario>(StatusUsuario.Listar());
            //Popula o combos dos Acessos
            AcessoSource = new ObservableCollection<AcessoUsuario>(AcessoUsuario.Listar());

            Id = Usuario.NextId();
            Masculino = true;
            Senha = "123456";
            Acesso = 1;
            Status = 1;
        }
        public UserViewModel(int cod, NavigationService nav)
        {
            Confirmar = new RelayCommand(EditarUsuario);
            Limpar = new RelayCommand(Reset);
            Voltar = new RelayCommand(VoltarPage);
            Navigation = nav;

            StatusSource = new ObservableCollection<StatusUsuario>(StatusUsuario.Listar());
            AcessoSource = new ObservableCollection<AcessoUsuario>(AcessoUsuario.Listar());

            Usuario user = new Usuario(cod);
            Nome = user.Nome;
            Sobrenome = user.Sobrenome;
            Username = user.Username;
            Senha = user.Senha;
            DataCadastro = user.DataCadastro;
            Id = user.Id;
            Email = user.Email;
            if (user.Sexo == 1) Masculino = true;
            if (user.Sexo == 2) Feminino = true;
            if (user.Foto != null)
            {
                List<byte[]> imagens = new List<byte[]>();
                imagens.Add(user.Foto);
                PictureSource = imagens;
            }
            Status = user.Status;
            Acesso = user.Acesso;

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
                usuario.Foto = PictureSource[0];
                usuario.Email = Email;
                usuario.Username = Username;
                usuario.Senha = Senha;
                usuario.Acesso = Acesso;
                usuario.Status = Status;
                usuario.Alterar();
                Message.Warning("Dados salvos", "Everything is fine", 4);
            }
        }
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
                usuario.Foto = PictureSource[0];
                usuario.Email = Email;
                usuario.Username = Username;
                usuario.Senha = Senha;
                usuario.Acesso = Acesso;
                usuario.Status = Status;
                usuario.Adicionar();
                Message.Warning("Novo usuário cadastrado", "Everything is fine", 9);
                Reset(null);
            }
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
        public void Reset(object o)
        {
            Nome = Sobrenome = Email = Username = "";
            Masculino = true;
            PictureSource = null;
            Acesso = 1;
        }
        public void VoltarPage(object o)
        {
            Navigation.Navigate(new View.Usuarios.Home());
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

