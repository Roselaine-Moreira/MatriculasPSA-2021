using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interface
{
    public interface IHistoricoDAO
    {
        //Todas os históricos do aluno:
        Task<List<Historico>> todosHistoricos();
    }
}
