using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain;
using Agenda.DAL;
using Agenda.Repos;
using NUnit.Framework;
using Moq;
using AutoFixture;

namespace Agenda.Repos.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;


        [SetUp]
        public void SetUp()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void DeveSerPossivelObterContatoComListaTelefone()
        {
            //Monta
            //Criar Moq de IContato
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(Guid.NewGuid());
            mContato.SetupGet(o => o.Nome).Returns("João");
            //Moq da função ObterPorId de IContatos
            _contatos.Setup(o => o.Obter(It.IsAny<Guid>())).Returns(mContato.Object);
            //Criar Moq de ITelefone
            Mock<ITelefone> mTelefone = new Mock<ITelefone>();
            mTelefone.SetupGet(o => o.Id).Returns(Guid.NewGuid);
            mTelefone.SetupGet(o => o.Numero).Returns("1234-1234");
            mTelefone.SetupGet(o => o.ContatoId).Returns(Guid.NewGuid());
            //Moq da função ObterTodosDoContato de ITelefones
            _telefones.Setup(o => o.ObterTodosDoContato(It.IsAny<Guid>())).Returns(new List<ITelefone> { mTelefone.Object });
            //Executa
            //Chamar o metodo ObterPorId de RepositorioContatos
            IContato contatoResultado = _repositorioContatos.ObterPorId(Guid.NewGuid());
            //Verifica
            //Verificar se o Contato retornado contém os mesmos dados do Moq IContato de Telefones do Moq ITelefone
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}
