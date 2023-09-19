using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class BaseTest
    {
        private string _script;
        private string _con;
        private string _catalogTest;

        public BaseTest()
        {
            //_script = @"ProjetoDB_Create.sql";
            //_con = ConfigurationManager.ConnectionStrings["conSetUpTest"].ConnectionString;
            //_catalogTest = ConfigurationManager.ConnectionStrings["conSetUpTest"].ProviderName;
        }


        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        { 

        }

    }
}
