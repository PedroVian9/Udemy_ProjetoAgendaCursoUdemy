//using System;
//using NUnit.Framework;
//using System.Runtime;


//namespace Agenda.DAL.Test
//{
//    [TestFixture]
//    public class ContatosTest
//    {
//        Contatos _contatos;

//        [SetUp]
//        public void SetUp()
//        {
//            _contatos = new Contatos();
//        }

//        //IncluirContatoTest
//        [Test]
//        public void IncluirContatoTest()
//        {
//            //Monta
//            string id = Guid.NewGuid().ToString();
//            string nome = "Marcos";
//            //Executa
//            _contatos.Adicionar(id, nome);

//            //Verifica
//            Assert.True(true);
//        }

//        //ObterContatoTest
//        [Test]
//        public void ObterContatoTest()
//        {
//            //Monta
//            string id = Guid.NewGuid().ToString();
//            string nome = "Maria";
//            //Executa
//            _contatos.Adicionar(id, nome);
//            string nomeResultado = _contatos.Obter(id);

//            //Verifica
//            Assert.AreEqual(nome, nomeResultado);
//        }


//        [TearDown]
//        public void TearDown()
//        {
//            _contatos = null;
//        }
//    }
//}