using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxpayerDesktop.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly AdozokViewModel AdozokViewModel;
        private readonly AdatokViewModel AdatokViewModel;

        [ObservableProperty]
        private object currentViewModel;

        public MainViewModel()
        {
            AdozokViewModel = new AdozokViewModel();
            AdatokViewModel = new AdatokViewModel();
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
