using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerConsole.Repos;
using TaxpayerDesktop.Repos;

namespace TaxpayerDesktop.ViewModels
{
    public partial class AdatokViewModel:ObservableObject
    {
        private readonly ManyTaxpayerRepo _repo;
        public AdatokViewModel(ManyTaxpayerRepo repo)
        {
            _repo = repo;
            Update();
        }

        [ObservableProperty]
        public int _taxpayerCount = 0;
        [ObservableProperty]
        public string _maxAndMin = "A legtöbb és legkevesebb: ";


        public void Update()
        {
            TaxpayerCount = _repo.GetTaxpayerCount();
            MaxAndMin = $" A legtöbb és legkevesebb:";
            foreach(KeyValuePair<string, int> kvp in _repo.GetMaxAndMin())
            {
                MaxAndMin += $"\n {kvp.Key}: {kvp.Value}";
            }
        }

    }
}
