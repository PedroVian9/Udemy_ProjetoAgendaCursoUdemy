using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain
{
    public interface IContato
    {
        Guid Id { get; set;  }
        string Nome { get; set; }
        List<ITelefone> Telefones { get; set; }
    }
}
