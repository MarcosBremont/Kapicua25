using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kapicua25.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcercaDe : ContentPage
    {
        public AcercaDe()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            _ = Salir();
            return true;
        }

        public async Task<bool> Salir()
        {
            await Navigation.PopModalAsync(true);
            return true;
        }


        private async void BtnAtras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}