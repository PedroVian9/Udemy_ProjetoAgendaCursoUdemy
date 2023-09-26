using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Test
{
    public class BaseConstr<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;

        protected BaseConstr()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }

        public T Construir()
        {
            return _mock.Object;
        }

        public Mock<T> Obter()
        {
            return _mock;
        }
    }
}
