using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerConsole.Models;

namespace TaxpayerDesktop.Repos
{
    public class ManyTaxpayerRepo
    {
        private readonly TaxpayerContext _context = new TaxpayerContext();
    }
}
