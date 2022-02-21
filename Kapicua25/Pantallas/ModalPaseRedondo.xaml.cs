using Rg.Plugins.Popup.Services;
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
    public partial class ModalPaseRedondo : Rg.Plugins.Popup.Pages.PopupPage
    {
        public int ID { get; set; }
        public bool SeEstaCerrando { get; set; }
        public ModalPaseRedondo()
        {
            InitializeComponent();

        }

        [Obsolete]
        private async void BtnAceptar_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();

        }

        [Obsolete]
        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            App.PaseRedondoPuntos1 = 0;
            App.PaseRedondoPuntos2 = 0;
            await PopupNavigation.PopAsync();
        }

        private void radioEquipo1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (App.TantosParaGanar == 500)
            {
                App.PaseRedondoPuntos1 = 75;
            }
            else
            {
                App.PaseRedondoPuntos1 = 50;
            }

            App.PaseRedondoPuntos2 = 0;

        }

        private void radioEquipo2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (App.TantosParaGanar == 500)
            {
                App.PaseRedondoPuntos2 = 75;
            }
            else
            {
                App.PaseRedondoPuntos2 = 50;
            }

            App.PaseRedondoPuntos1 = 0;


        }
    }
}