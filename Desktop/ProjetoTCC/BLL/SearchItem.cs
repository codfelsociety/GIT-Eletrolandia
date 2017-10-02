using System.Windows.Media;

namespace BLL
{
    public class SearchItem
    {
        private int id;
        private string nome;
        private decimal preco;
        private int codBarras;
        private ImageSource picture;

        public SearchItem(int id, string nome, decimal preco, int codBarras, ImageSource picture)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            CodBarras = codBarras;
            Picture = picture;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public decimal Preco { get { return preco; } set { preco = value; } }
        public int CodBarras { get { return codBarras; } set { codBarras = value; } }
        public ImageSource Picture { get { return picture; } set { picture = value; } }
    }
}
