using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain
{
    public interface ITelefone
    {
        Guid Id { get; set;  }
        string Numero {  get; set; }
        Guid ContatoId { get; set; }
    }
}
