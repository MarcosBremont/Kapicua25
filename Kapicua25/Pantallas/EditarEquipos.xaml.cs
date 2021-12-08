using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
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
            PickerTantos.Items.Add("100");
            PickerTantos.Items.Add("200");
            PickerTantos.Items.Add("300");
        }

        protected async override void OnAppearing()
        {
            var result = Configuraciones.ObtenerDatosSesion();
          

            lbljugador1.Text = result.Item2;
            lbljugador2.Text = result.Item3;

            lbljugador1Equipo2.Text = result.Item5;
            lbljugador2Equipo2.Text = result.Item6;
            PickerTantos.Title = App.TantosParaGanar.ToString();
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

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                App.TantosParaGanar = Convert.ToInt32(picker.Items[selectedIndex]);

            }
        }

        public void BtnGuardarCambios_Clicked(System.Object sender, System.EventArgs e)
        {
            string tantos = "";
            //IndicadorCargando.IsRunning = true;
            try
            {

                var result = Configuraciones.ObtenerDatosSesion();
                //if (PickerTantos.Title == "ELIJA LOS TANTOS PARA GANAR")
                //{
                //   tantos = "100";
                //}

                Configuraciones.Grabar("", lbljugador1.Text, lbljugador2.Text, "", lbljugador1Equipo2.Text, lbljugador2Equipo2.Text, App.TantosParaGanar.ToString());
                //Toast.MakeText(this, "¡Los datos se han guardado exitosamente!", 1, ToastLength.Long).Show();
                Toast.MakeText(Android.App.Application.Context, "¡Los datos se han guardado exitosamente!", ToastLength.Long).Show();


            }
            catch (Exception ex)
            {
                Toast.MakeText(Android.App.Application.Context, "¡Los datos no se han guardado, intente mas tarde!", ToastLength.Long).Show();


            }

            //IndicadorCargando.IsRunning = false;



        }
    }
}