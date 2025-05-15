using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerConsole.Model;
using TaxpayerConsole.Models;

namespace TaxpayerDesktop.Repos
{
    public class ManyTaxpayerRepo
    {
        private readonly TaxpayerContext _context = new TaxpayerContext();

        public int GetTaxpayerCount()
        {
            return _context.Manytaxpayers.Count();
        }

        public Dictionary<string, int> GetMaxAndMin()
        {
            var max = _context.Manytaxpayers.Max(t => t.Amount);
            string taxpayer = _context.Manytaxpayers.FirstOrDefault(t => t.Amount == max)?.Name;
            var min = _context.Manytaxpayers.Min(t => t.Amount);
            string taxpayer2 = _context.Manytaxpayers.FirstOrDefault(t => t.Amount == min)?.Name;
            return new Dictionary<string, int>
            {
                { taxpayer, max },
                { taxpayer2, min }
            };
        }

        public List<Taxpayer> GetAllTaxpayers()
        {
            return _context.Manytaxpayers.ToList();
        }

        public List<Taxpayer> GetTaxpayersWithMin(int amount)
        {
            return _context.Manytaxpayers.Where(t => t.Amount >= amount).ToList();
        }

        public List<Taxpayer> GetTaxpayersDesc()
        {
            return _context.Manytaxpayers.OrderByDescending(t => t.Amount).ToList();
        }

        public List<Taxpayer> GetTaxpayersWithDomain(string domain)
        {
            return _context.Manytaxpayers.Where(t => t.Email.EndsWith(domain)).ToList();
        }

        public void ChangeAmountByEmail(string email, int newAmount)
        {
            Taxpayer taxpayer = _context.Manytaxpayers.FirstOrDefault(t => t.Email == email);
            if (taxpayer == null)
            {
                throw new ArgumentException("Nincs ilyen email című adózó");
            }
            taxpayer.Amount = newAmount;
            _context.SaveChanges();
        }

        public void AddTaxpayer(string name, string email, int newAmount)
        {
            Taxpayer taxpayer = _context.Manytaxpayers.FirstOrDefault(t => t.Email == email);
            if (taxpayer == null)
            {
                Taxpayer newTaxpayer = new Taxpayer(name, email, newAmount);
                _context.Manytaxpayers.Add(newTaxpayer);
                _context.SaveChanges();
            }
        }

        public void DeleteTaxpayer(string email)
        {
            Taxpayer taxpayer = _context.Manytaxpayers.FirstOrDefault(t => t.Email == email);
            if (taxpayer != null)
            {
                _context.Manytaxpayers.Remove(taxpayer);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Nincs ilyen email című adózó");
            }
        }
    }
}
