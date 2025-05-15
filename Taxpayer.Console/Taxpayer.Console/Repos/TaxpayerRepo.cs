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

        public List<Taxpayer> GetTaxpayersWithMin(int amount)
        {
            return _context.Taxpayers.Where(t=> t.Amount>=amount).ToList();
        }

        public List<Taxpayer> GetTaxpayersDesc()
        {
            return _context.Taxpayers.OrderByDescending(t=>t.Amount).ToList();
        }

        public List<Taxpayer> GetTaxpayersWithDomain(string domain)
        {
            return _context.Taxpayers.Where(t=>t.Email.EndsWith(domain)).ToList();
        }

        public void ChangeAmountByEmail(string email, int newAmount)
        {
            Taxpayer taxpayer = _context.Taxpayers.FirstOrDefault(t => t.Email == email);
            if(taxpayer == null)
            {
                throw new ArgumentException("Nincs ilyen email című adózó");
            }
            taxpayer.Amount = newAmount;
            _context.SaveChanges();
        }

        public void AddTaxpayer(string name,string email, int newAmount)
        {
            Taxpayer taxpayer = _context.Taxpayers.FirstOrDefault(t => t.Email == email);
            if (taxpayer == null)
            {
                Taxpayer newTaxpayer = new Taxpayer(name, email, newAmount);
                _context.Taxpayers.Add(newTaxpayer);
            }
        }

        public void DeleteTaxpayer(string email)
        {
            Taxpayer taxpayer = _context.Taxpayers.FirstOrDefault(t => t.Email == email);
            if (taxpayer != null)
            {
                _context.Taxpayers.Remove(taxpayer);
            }
            else
            {
                throw new ArgumentException("Nincs ilyen email című adózó");
            }
        }

    }
}
