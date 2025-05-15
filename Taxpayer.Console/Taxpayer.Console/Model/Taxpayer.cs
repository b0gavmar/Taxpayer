using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxpayerConsole.Model
{
    public class Taxpayer
    {
        private int _amount;
        private string _email;

        public string Name { get; set; }
        public int Amount { get => _amount; set => _amount = value; }
        public string Email { get=> _email; set => _email = value; }

        public Taxpayer(string name,  string email, int amount = 0)
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(email))
                throw new ArgumentException("Email és név nem lehet üres vagy null", nameof(name));

            Name = name;
            _amount = amount;
            _email = email;
        }

        public void IncreaseTaxCredit(int amount)
        {
            if (amount > 0)
            {
                _amount += amount;
            }
            else
            {
                throw new ArgumentException("Az összeg nem lehet 0 vagy negatív", nameof(amount));
            }
        }

        public void DecreaseTaxCredit(int amount)
        {
            if (amount > 0)
            {
                _amount -= amount;
            }
            else
            {
                throw new ArgumentException("Az összeg nem lehet 0 vagy negatív", nameof(amount));
            }
        }

        public override string ToString()
        {
            return $"Név: {Name}, Email: {Email}, Adójóváírás: {Amount} Ft";
        }
    }
}
