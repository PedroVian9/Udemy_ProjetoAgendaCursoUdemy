using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Agenta.DAL.Test
{
    public class BaseTest
    {
        private string _script;
        private string _con;
        private string _catalogTest;

        IConfigurationRoot configuracao = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        public BaseTest() {

            
            _script = @"DBAgendaTest_Create.sql";
            _con =  configuracao.GetConnectionString("conSetUpTest");
            _catalogTest = configuracao["ProviderNames:conSetupTest"];
            

        }

        [OneTimeSetUp]
        public void OneTimeSetUp() {
             CreateDBTest();
        }

        [OneTimeTearDown] 
        public void OneTimeTearDown() {

            DeleteDBTest();
        }

        private void CreateDBTest()
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                var scriptSql = File
                .ReadAllText($@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\{_script}")
                    .Replace("$(DefaultDataPath)", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultLogPath)", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultFilePrefix)", _catalogTest)
                    .Replace("$(DatabaseName)", _catalogTest)
                    .Replace("WITH (DATA_COMPRESSION = PAGE)", string.Empty)
                    .Replace("SET NOEXEC ON", string.Empty)
                .Replace("GO\r\n", "|");

               ExecuteScriptSql(con, scriptSql);
            }
            
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using (var cmd = con.CreateCommand())
            {
                foreach (var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;

                    //Essa linha irá ignora as linhas que contem ':' como :setvar ou :on error etc
                    //No nosso caso, não irá fazer diferença.
                    if (sql.Contains(':'))
                        continue;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }

        private void DeleteDBTest()
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $@"USE [master]";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $@"USE [master];
                                        DECLARE @kill varchar(8000) = '';
                                        SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
                                        FROM sys.dm_exec_sessions
                                        WHERE database_id = db_id('{_catalogTest}')
                                        EXEC(@kill);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"DROP DATABASE {_catalogTest}";
                    cmd.ExecuteNonQuery();
                                         
                    
                }
            }
        }

    }
}
