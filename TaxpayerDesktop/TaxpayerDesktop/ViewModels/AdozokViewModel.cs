using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerConsole.Model;
using TaxpayerConsole.Models;
using TaxpayerDesktop.Repos;

namespace TaxpayerDesktop.ViewModels
{
    public partial class AdozokViewModel: ObservableObject
    {
        private readonly ManyTaxpayerRepo _repo;

        public AdozokViewModel(ManyTaxpayerRepo repo)
        {
            _repo = repo;
            Update();
        }

        [ObservableProperty]
        public List<Taxpayer> _taxpayers = new List<Taxpayer>();
        [ObservableProperty]
        public string _searchEmail = string.Empty;

        [RelayCommand]
        public void OrderByAmount()
        {
            Taxpayers = _repo.GetTaxpayersDesc();
        }

        [RelayCommand]
        public void FilterByEmail()
        {
            if (string.IsNullOrWhiteSpace(SearchEmail))
            {
                Taxpayers = _repo.GetAllTaxpayers();
                return;
            }
            Taxpayers = _repo.GetTaxpayersWithDomain(SearchEmail);
        }

        public void Update()
        {
            Taxpayers = _repo.GetAllTaxpayers();
        }
    }
}
