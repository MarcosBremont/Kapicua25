﻿using Android.Widget;
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

        public Puntos Puntos { get; set; }
        public List<EPuntos> ListPuntos { get; set; } = new List<EPuntos>();

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


            if (Convert.ToInt32(result2.Item7) == 0)
            {
                Configuraciones.Grabar("", LblJugador1.Text, LblJugador2.Text, "", LblJugador1Equipo2.Text, LblJugador2Equipo2.Text, "100");
                LblTantos.Text = result2.Item7;
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
                    gridconfig.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;
                    var result = Configuraciones.ObtenerDatosSesion();
                    LblTantos.Text = result.Item7;
                    LblJugador1.Text = result.Item2;
                    LblJugador2.Text = result.Item3;
                    LblJugador1Equipo2.Text = result.Item5;
                    LblJugador2Equipo2.Text = result.Item6;
                    //lytBackNav1.IsVisible = true;
                }),
                NumberOfTapsRequired = 1
            });

            gridInfo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    gridInicio.BackgroundColor = Color.White;
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
            PickerTantos.Title = App.TantosParaGanar.ToString();


            lbljugador1Editar.Text = result.Item2;
            lbljugador2Editar.Text = result.Item3;

            lbljugador1Equipo2Editar.Text = result.Item5;
            lbljugador2Equipo2Editar.Text = result.Item6;
            PickerTantos.Title = App.TantosParaGanar.ToString();

            LLenarDatosAlmacenados();

            if (string.IsNullOrEmpty(result.Item1) && string.IsNullOrEmpty(result.Item2) && string.IsNullOrEmpty(result.Item3) && string.IsNullOrEmpty(result.Item4) && string.IsNullOrEmpty(result.Item5) && string.IsNullOrEmpty(result.Item6))
            {
                LblJugador1.Text = "Jugador 1";
                LblJugador2.Text = "Jugador 2";
                LblJugador1Equipo2.Text = "Jugador 1";
                LblJugador2Equipo2.Text = "Jugador 2";
                LblTantos.Text = "100";

                Configuraciones.Grabar("", LblJugador1.Text, LblJugador2.Text, "", LblJugador1Equipo2.Text, LblJugador2Equipo2.Text, LblTantos.Text);
            }
            else
            {

                //LblEquipo1.Text = result.Item1;
                LblJugador1.Text = result.Item2;
                LblJugador2.Text = result.Item3;
                //LblEquipo2.Text = result.Item4;
                LblJugador1Equipo2.Text = result.Item5;
                LblJugador2Equipo2.Text = result.Item6;
                LblTantos.Text = result.Item7;

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

            if (puntosequipo1 >= App.TantosParaGanar)
            {
                await DisplayAlert("Información", "¡El Equipo 1 ha ganado la partida!", "OK");
            }
            else if (puntosequipos2 >= App.TantosParaGanar)
            {
                await DisplayAlert("Información", "¡El Equipo 2 ha ganado la partida!", "OK");
            }
        }

        async void BtnTerminarRonda_Clicked(System.Object sender, System.EventArgs e)
        {
            if (await DisplayAlert("Información", "¿Desea terminar la partida?", "SI", "NO"))
            {
                Configuraciones.Grabar("", "", "", "", "", "", "0");
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

                Configuraciones.Grabar("", lbljugador1Editar.Text, lbljugador2Editar.Text, "", lbljugador1Equipo2Editar.Text, lbljugador2Equipo2Editar.Text, App.TantosParaGanar.ToString());
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