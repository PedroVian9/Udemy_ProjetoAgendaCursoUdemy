using Agenda.Domain;
using System.Collections.Immutable;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
        }

        
        [Test]
        public void AdicionarContatoTest()
        {
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Marcos"
            };

            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        
        [Test]
        public void ObterContatoTest()
        {
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Maria"
            };
            Contato contatoResultado;

            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);


            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            //Monta
            var contato1 = new Contato() { Id = Guid.NewGuid(), Nome = "Maria" };
            var contato2 = new Contato() { Id = Guid.NewGuid(), Nome = "Maria" };
            //Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContato = _contatos.ObterTodos();
            var contatoResultado = lstContato.Where(o =>o.Id == contato1.Id).FirstOrDefault();
            //Verifica
            Assert.IsTrue(lstContato.Count() > 1);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;

        }
    }
}