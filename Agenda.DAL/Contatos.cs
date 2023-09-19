using System.Configuration;
using System.Data.SqlClient;
using Agenda.Domain;
using Microsoft.Extensions.Configuration;
using System.IO;
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
            IConfigurationRoot configuracao = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();            
            _strCon = configuracao.GetConnectionString("con");
            _con = new SqlConnection(_strCon);
        }

        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Execute("insert into Contato (Id, Nome) values (@Id, @Nome)", contato);
            }
        }

        public Contato Obter(Guid id)
        {
            Contato contato;
            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("select Id, Nome from Contato where Id = @Id", new { ID = id });   
            }
            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                contatos = con.Query<Contato>("select Id, Nome from Contato").ToList();
            }
            return contatos;
        }
    }
}