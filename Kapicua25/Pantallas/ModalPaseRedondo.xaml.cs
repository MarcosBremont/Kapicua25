using Kapicua25.Objetos;
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
        public int PuntosPaseRedondo { get; set; }
        public bool SeEstaCerrando { get; set; }
        public ModalPaseRedondo()
        {
            InitializeComponent();
            var result = Configuraciones.ObtenerDatosSesion();
            PuntosPaseRedondo = Convert.ToInt32(result.PaseRedondo);
        }

        [Obsolete]
        private async void BtnAceptar_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();

        }

        [Obsolete]
        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            App.PaseRedondoPuntos1 = "N";
            App.PaseRedondoPuntos2 = "N";
            await PopupNavigation.PopAsync();
        }

        private void radioEquipo1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            App.PaseRedondoPuntos1 = "S";
            App.PaseRedondoPuntos2 = "N";
        }

        private void radioEquipo2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            App.PaseRedondoPuntos2 = "S";
            App.PaseRedondoPuntos1 = "N";
        }
    }
}