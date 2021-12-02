using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapicua25.Objetos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kapicua25.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarEquipos : ContentPage
    {

        public EditarEquipos()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            var result = Configuraciones.ObtenerDatosSesion();


            lbljugador1.Text = result.Item2;
            lbljugador2.Text = result.Item3;

            lbljugador1Equipo2.Text = result.Item5;
            lbljugador2Equipo2.Text = result.Item6;
            //if (!string.IsNullOrEmpty(App.Equipo1))
            //{
            //    //lblequipo.Text = App.Equipo1;

            //}
            //else
            //{
            //    //lblequipo.Text = App.Equipo2;

            //}

            base.OnAppearing();

        }


        private async void BtnAtras_Clicked(object sender, EventArgs e)
        {
            App.Equipo1 = "";
            App.Equipo2 = "";
            App.Jugador1Equipo1 = "";
            App.Jugador2Equipo1 = "";
            App.Jugador1Equipo2 = "";
            App.Jugador2Equipo2 = "";
            await Navigation.PopModalAsync();
        }

        public void BtnGuardarCambios_Clicked(System.Object sender, System.EventArgs e)
        {
            //IndicadorCargando.IsRunning = true;
            try
            {

                var result = Configuraciones.ObtenerDatosSesion();
                Configuraciones.Grabar("", lbljugador1.Text, lbljugador2.Text, "", lbljugador1Equipo2.Text, lbljugador2Equipo2.Text);
                //toastConfig.MostrarNotificacion($"¡Los datos se han guardado exitosamente!", ToastPosition.Top, 3, "#51C560");
            }
            catch (Exception ex)
            {
                //toastConfig.MostrarNotificacion($"¡No se han podido guardar los datos!", ToastPosition.Top, 3, "#A52A2A");

            }

            //IndicadorCargando.IsRunning = false;



        }
    }
}