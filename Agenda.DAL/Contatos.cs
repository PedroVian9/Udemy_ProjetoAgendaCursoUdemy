using System.Configuration;
using System.Data.SqlClient;
using Agenda.Domain;
using Dapper;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
        SqlConnection _con;

        public Contatos()
        {
            _strCon = @"Data Source=.\sqlexpress;Initial Catalog=Agenda;Integrated Security=True;";
            _con = new SqlConnection(_strCon);
        }

        public void Adicionar(Contato contato)
        {
            _con.Execute("insert into Contato (Id, Nome) values (@Id, @Nome)", contato);
        }

        public Contato Obter(Guid id)
        {
            Contato contato;

            contato = _con.QueryFirst<Contato>("select Id, Nome from Contato where Id = @Id", new { Id = id });

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            contatos = _con.Query<Contato>("select Id, Nome from Contato;").ToList();
            
            return contatos;
        }
    }
}