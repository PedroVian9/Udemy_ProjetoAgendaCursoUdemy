using NUnit.Framework;
using Agenda.DAL;
using Agenda.Domain;
using AutoFixture;

namespace Agenta.DAL.Test
{

    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos(); 
            _fixture = new Fixture();
        }

        [Test] 
        public void IncluirContatoTest()
        {
            var contato = _fixture.Create<Contato>();

            _contatos.Adicionar(contato); 

            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            Contato contato = _fixture.Create<Contato>();
            Contato contatoResultado;

            _contatos.Adicionar(contato);

            contatoResultado = _contatos.Obter(contato.Id);

            Assert.AreEqual(contato.Id, contato.Id);
            Assert.AreEqual(contato.Nome, contato.Nome);
        }

        [TearDown]
        public void TearDown() {
            _contatos = null;
            _fixture = null;
        }
    }
}