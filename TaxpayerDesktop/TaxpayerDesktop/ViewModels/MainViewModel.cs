using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxpayerDesktop.ViewModels
{
    public class MainViewModel
    {
       
        public AdozokViewModel AdozokViewModel { get; set; }
        public AdatokViewModel AdatokViewModel { get; set; }

        public MainViewModel()
        {
            AdozokViewModel = new AdozokViewModel();
            AdatokViewModel = new AdatokViewModel();
        }
    }
}
