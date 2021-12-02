using Kapicua25.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kapicua25.Pantallas
{
    public partial class MainPage : ContentPage
    {
        PantallaPrincipal pantallaprincipal = new PantallaPrincipal();


        public MainPage()
        {
            InitializeComponent();
            StackLayoutEquipo2.IsVisible = false;

            //BtnAdd.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(async () =>
            //    {
            //        modalavatar = new ModalAvatar();
            //        await PopupNavigation.PushAsync(modalavatar);
            //    }),
            //    NumberOfTapsRequired = 1
            //});
        }

        protected async override void OnAppearing()
        {
            var result = Configuraciones.ObtenerDatosSesion();
            TxtEquipo1.Text = result.Item1;
            TxtJugador1.Text = result.Item2;
            TxtJugador2.Text = result.Item3;
            TxtEquipo2.Text = result.Item4;
            TxtJugador1Equipo2.Text = result.Item5;
            TxtJugador2Equipo2.Text = result.Item6;
            base.OnAppearing();
        }


        private async void BtnSiguiente_Clicked(object sender, EventArgs e)
        {
            StackLayoutEquipo1.IsVisible = false;
            StackLayoutEquipo2.IsVisible = true;

        }

        private async void BtnSiguienteEquipo2_Clicked(object sender, EventArgs e)
        {

            Configuraciones.Grabar(TxtEquipo1.Text, TxtJugador1.Text, TxtJugador2.Text, TxtEquipo2.Text, TxtJugador1Equipo2.Text, TxtJugador2Equipo2.Text);

            StackLayoutEquipo2.IsVisible = false;
            pantallaprincipal = new PantallaPrincipal();
            await Navigation.PushModalAsync(pantallaprincipal);

        }

        private void BtnAtras_Clicked(object sender, EventArgs e)
        {
            StackLayoutEquipo1.IsVisible = true;
            StackLayoutEquipo2.IsVisible = false;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
