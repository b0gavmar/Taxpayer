using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerConsole.Model;
using TaxpayerConsole.Models;

namespace TaxpayerConsole.Repos
{
    public class TaxpayerRepo
    {
        private readonly TaxpayerContext _context = new TaxpayerContext();

        public int GetTaxpayerCount()
        {
            return _context.Taxpayers.Count();
        }

        public Dictionary<string, int> GetMaxAndMin()
        {
            var max = _context.Taxpayers.Max(t => t.Amount);
            var min = _context.Taxpayers.Min(t => t.Amount);
            return new Dictionary<string, int>
            {
                { "max", max },
                { "min", min }
            };
        }

        public List<Taxpayer> GetAllTaxpayers()
        {
            return _context.Taxpayers.ToList();
        }
    }
}
