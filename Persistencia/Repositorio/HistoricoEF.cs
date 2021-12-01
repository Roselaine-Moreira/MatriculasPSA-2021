using Entidades.Interface;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.Repositorio
{
    public class HistoricoEF : IHistoricoDAO
    {
        private readonly MatriculasPSA2021Context _context;

        //construtor entity framework        
        public HistoricoEF(MatriculasPSA2021Context context)
        {
            _context = context;
        }

        //Exibe todo histórico
        public async Task<List<Historico>> todosHistoricos()
        {
            return await _context.Historico.Include(h => h.Disciplina).ToListAsync();
        }
    }
}
