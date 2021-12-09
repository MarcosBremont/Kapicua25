using Android.Widget;
using Kapicua25.Objetos;
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
    public partial class PantallaPrincipal : ContentPage
    {
        EGlobal eGlobal = new EGlobal();
        public Puntos Puntos { get; set; }
        Ganador ganador = new Ganador();
        public List<EPuntos> ListPuntos { get; set; } = new List<EPuntos>();
        public List<EGanador> ListGanador { get; set; } = new List<EGanador>();


        EditarEquipos editarEquipos = new EditarEquipos();
        int puntosequipo1 = 0;
        int puntosequipos2 = 0;
        int Puntos1 = 0;
        int Puntos2 = 0;
        int Puntos3 = 0;
        int Puntos4 = 0;

        public PantallaPrincipal()
        {
            InitializeComponent();

            #region gridconfig
            PickerTantos.Items.Add("100");
            PickerTantos.Items.Add("200");
            PickerTantos.Items.Add("300");
            #endregion
            var result2 = Configuraciones.ObtenerDatosSesion();


            if (Convert.ToInt32(result2.Tantos) == 0)
            {
                Configuraciones.Grabar("", LblJugador1.Text, LblJugador2.Text, "", LblJugador1Equipo2.Text, LblJugador2Equipo2.Text, "100", "");
                LblTantos.Text = result2.Tantos;
            }

            gridInicio.BackgroundColor = Color.LightGray;



            //StackEquipo1.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(async () =>
            //    {
            //        //App.Equipo1 = LblEquipo1.Text;
            //       
            //    }),
            //    NumberOfTapsRequired = 1
            //});

            //StackEquipo2.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(async () =>
            //    {
            //        //App.Equipo2 = LblEquipo2.Text;
            //        App.Jugador1Equipo2 = LblJugador1Equipo2.Text;
            //        App.Jugador2Equipo2 = LblJugador2Equipo2.Text;
            //        await Navigation.PushModalAsync(editarEquipos);

            //    }),
            //    NumberOfTapsRequired = 1
            //});

            gridInicio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    gridInicio.BackgroundColor = Color.LightGray;
                    StackLayoutPaginaPrincipal.IsVisible = true;
                    StackLayoutAcercaDe.IsVisible = false;
                    StackLayoutConfig.IsVisible = false;
                    lytBackNav.IsVisible = true;
                    StackLayoutHistorialPartidas.IsVisible = false;
                    gridHistorialPartidas.BackgroundColor = Color.White;

                    gridconfig.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;
                    var result = Configuraciones.ObtenerDatosSesion();
                    LblTantos.Text = result.Tantos;
                    LblJugador1.Text = result.Equipo1Jugador1;
                    LblJugador2.Text = result.Equipo1Jugador2;
                    LblJugador1Equipo2.Text = result.Equipo2Jugador1;
                    LblJugador2Equipo2.Text = result.Equipo2Jugador2;
                    //lytBackNav1.IsVisible = true;
                }),
                NumberOfTapsRequired = 1
            });

            gridHistorialPartidas.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    gridInicio.BackgroundColor = Color.White;
                    gridconfig.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;
                    StackLayoutPaginaPrincipal.IsVisible = false;
                    StackLayoutAcercaDe.IsVisible = false;
                    StackLayoutConfig.IsVisible = false;
                    StackLayoutHistorialPartidas.IsVisible = true;
                    lytBackNav.IsVisible = false;
                    gridHistorialPartidas.BackgroundColor = Color.LightGray;
                    this.ListGanador = ganador.ObtenerGanadores();
                    this.Lsv_HistorialPartidas.ItemsSource = this.ListGanador;
                }),
                NumberOfTapsRequired = 1
            });


            gridInfo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    gridInicio.BackgroundColor = Color.White;
                    StackLayoutHistorialPartidas.IsVisible = false;
                    gridHistorialPartidas.BackgroundColor = Color.White;

                    gridconfig.BackgroundColor = Color.White;
                    StackLayoutPaginaPrincipal.IsVisible = false;
                    StackLayoutAcercaDe.IsVisible = true;
                    StackLayoutConfig.IsVisible = false;
                    lytBackNav.IsVisible = false;
                    gridInfo.BackgroundColor = Color.LightGray;

                }),
                NumberOfTapsRequired = 1
            });


            gridconfig.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    gridInicio.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;
                    gridHistorialPartidas.BackgroundColor = Color.White;

                    StackLayoutHistorialPartidas.IsVisible = false;

                    StackLayoutPaginaPrincipal.IsVisible = false;
                    StackLayoutAcercaDe.IsVisible = false;
                    StackLayoutConfig.IsVisible = true;
                    lytBackNav.IsVisible = false;
                    gridconfig.BackgroundColor = Color.LightGray;

                }),
                NumberOfTapsRequired = 1
            });
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

        protected override void OnAppearing()
        {

            base.OnAppearing();
            LblTantos.Text = App.TantosParaGanar.ToString();

            Puntos = new Puntos();
            var result = Configuraciones.ObtenerDatosSesion();
            //if (result.Item7 == "0" || result.Item7 == null || result.Item7 == "")
            //{
            //    PickerTantos.Title = "ELIJA LOS TANTOS PARA GANAR";
            //}
            //else
            //{
            //    PickerTantos.SelectedItem = result.Item7;
            //}

            PickerTantos.SelectedItem = result.Tantos;
            lbljugador1Editar.Text = result.Equipo1Jugador1;
            lbljugador2Editar.Text = result.Equipo1Jugador2;

            lbljugador1Equipo2Editar.Text = result.Equipo2Jugador1;
            lbljugador2Equipo2Editar.Text = result.Equipo2Jugador2;

            LLenarDatosAlmacenados();

            if (string.IsNullOrEmpty(result.Equipo1) && string.IsNullOrEmpty(result.Equipo1Jugador1) && string.IsNullOrEmpty(result.Equipo1Jugador2) && string.IsNullOrEmpty(result.Equipo2) && string.IsNullOrEmpty(result.Equipo2Jugador1) && string.IsNullOrEmpty(result.Equipo2Jugador2))
            {
                LblJugador1.Text = "Jugador 1";
                LblJugador2.Text = "Jugador 2";
                LblJugador1Equipo2.Text = "Jugador 1";
                LblJugador2Equipo2.Text = "Jugador 2";
                LblTantos.Text = "100";

                Configuraciones.Grabar("", LblJugador1.Text, LblJugador2.Text, "", LblJugador1Equipo2.Text, LblJugador2Equipo2.Text, LblTantos.Text, "");
            }
            else
            {

                //LblEquipo1.Text = result.Equipo1;
                LblJugador1.Text = result.Equipo1Jugador1;
                LblJugador2.Text = result.Equipo1Jugador2;
                //LblEquipo2.Text = result.Equipo2;
                LblJugador1Equipo2.Text = result.Equipo2Jugador1;
                LblJugador2Equipo2.Text = result.Equipo2Jugador2;
                LblTantos.Text = result.Tantos;

            }
        }
        private void LLenarDatosAlmacenados()
        {
         
            this.ListPuntos = Puntos.ObtenerPuntos();
            this.lsv_puntos.ItemsSource = this.ListPuntos;
            lblPuntosEquipo1.Text = string.Format("{0}", ListPuntos.Sum(n => n.Punto1));
            lblPuntosEquipo2.Text = string.Format("{0}", ListPuntos.Sum(n => n.Punto2));
        }

        private async void BtnAgregarRonda_Clicked(object sender, EventArgs e)
        {
            if (TxtPuntosEquipo1.Text == "0" && TxtPuntosEquipo2.Text == "0")
            {
                await DisplayAlert("Información", "Los puntos de ambos equipos no pueden estar en 0.", "OK");

            }
            else
            {
                if (TxtPuntosEquipo1.Text != "")
                {
                    Puntos1 = Convert.ToInt32(lblPuntosEquipo1.Text);
                    Puntos2 = Convert.ToInt32(TxtPuntosEquipo1.Text);
                    puntosequipo1 = Puntos1 + Puntos2;
                    lblPuntosEquipo1.Text = puntosequipo1.ToString();
                    TxtPuntosEquipo1.Text = "0";
                }

                if (TxtPuntosEquipo2.Text != "")
                {
                    Puntos3 = Convert.ToInt32(lblPuntosEquipo2.Text);
                    Puntos4 = Convert.ToInt32(TxtPuntosEquipo2.Text);
                    puntosequipos2 = Puntos3 + Puntos4;
                    lblPuntosEquipo2.Text = puntosequipos2.ToString();
                    TxtPuntosEquipo2.Text = "0";
                }

                this.ListPuntos.Add(new EPuntos() { Punto1 = Puntos2, Punto2 = Puntos4 });
                Puntos.GrabarPuntos(this.ListPuntos);
                this.lsv_puntos.ItemsSource = null;
                this.lsv_puntos.ItemsSource = this.ListPuntos;
                var result = Configuraciones.ObtenerDatosSesion();

                if (puntosequipo1 >= App.TantosParaGanar)
                {
                    //string EquipoGanador1 = result.Equipo1Jugador1 + " Y " + result.Equipo1Jugador2;
                    this.ListGanador.Add(new EGanador() { Ganador1 = result.Equipo1Jugador1, Ganador2 = result.Equipo2Jugador1, Juego = "G" });
                    ganador.GrabarGanadores(this.ListGanador);
                    await DisplayAlert("Información", "¡El Equipo 1 ha ganado la partida!", "OK");

                }
                else if (puntosequipos2 >= App.TantosParaGanar)
                {
                    string EquipoGanador2 = eGlobal.Equipo2Jugador1 + " Y " + eGlobal.Equipo2Jugador2;
                    Configuraciones.Grabar("", result.Equipo1Jugador1, result.Equipo1Jugador2, "", result.Equipo2Jugador1, result.Equipo2Jugador2, result.Tantos, EquipoGanador2);
                    await DisplayAlert("Información", "¡El Equipo 2 ha ganado la partida!", "OK");

                }
            }


        }

        async void BtnTerminarRonda_Clicked(System.Object sender, System.EventArgs e)
        {
            if (await DisplayAlert("Información", "¿Desea terminar la partida?", "SI", "NO"))
            {
                Configuraciones.Grabar("", "", "", "", "", "", "0", "");
                MainPage mainpage = new MainPage();
                await Navigation.PushModalAsync(mainpage);
                Configuraciones.Eliminar();


            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;


        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            App.Jugador1Equipo1 = LblJugador1.Text;
            App.Jugador2Equipo1 = LblJugador2.Text;
            App.Jugador1Equipo2 = LblJugador1Equipo2.Text;
            App.Jugador2Equipo2 = LblJugador2Equipo2.Text;

            await Navigation.PushModalAsync(editarEquipos);
        }

        private async void BtnNuevaPartida_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Información", "¿Desea empezar una nueva la partida?", "SI", "NO"))
            {
                lblPuntosEquipo1.Text = "0";
                lblPuntosEquipo2.Text = "0";
                TxtPuntosEquipo1.Text = "0";
                TxtPuntosEquipo2.Text = "0";
                lsv_puntos.ItemsSource = null;
                this.ListPuntos.Clear();
                Configuraciones.Eliminar();
                Puntos.EliminarPuntos(this.ListPuntos);


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

                Configuraciones.Grabar("", lbljugador1Editar.Text, lbljugador2Editar.Text, "", lbljugador1Equipo2Editar.Text, lbljugador2Equipo2Editar.Text, App.TantosParaGanar.ToString(), "");
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