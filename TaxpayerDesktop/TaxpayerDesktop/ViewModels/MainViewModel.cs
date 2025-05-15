using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerDesktop.Repos;

namespace TaxpayerDesktop.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly AdozokViewModel AdozokViewModel;
        private readonly AdatokViewModel AdatokViewModel;
        private readonly ManyTaxpayerRepo _repo;

        [ObservableProperty]
        private object currentViewModel;

        public MainViewModel()
        {
            _repo = new ManyTaxpayerRepo();
            AdozokViewModel = new AdozokViewModel(_repo);
            AdatokViewModel = new AdatokViewModel(_repo);
            CurrentViewModel = AdatokViewModel;
        }

        [RelayCommand]
        public void ShowAdatok()
        {
            CurrentViewModel = AdatokViewModel;
        }

        [RelayCommand]
        public void ShowAdozok()
        {
            CurrentViewModel = AdozokViewModel;
        }
    }
}
