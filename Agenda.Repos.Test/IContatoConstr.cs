using Agenda.Domain;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Test
{
    public class IContatoConstr : BaseConstr<IContato>
    {
        protected IContatoConstr() : base() { }

        public static IContatoConstr Um()
        {
            return new IContatoConstr();
        }

        public IContatoConstr ComNome(string nome)
        {
            _mock.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }

        public IContatoConstr ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }
    }
}
