using Acr.UserDialogs;
using Kapicua25.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

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
        public event EventHandler<SwipedEventArgs> Swipe;
        string equipoOno = "";
        string conPremioOno = "";

        ToastConfigClass toastConfigClass = new ToastConfigClass();


        int puntosequipo1 = 0;
        int puntosequipos2 = 0;
        int Puntos1 = 0;
        int Puntos2 = 0;
        int Puntos3 = 0;
        int Puntos4 = 0;
        int PuntosPremio1 = 0;
        int PuntosPremio2 = 0;

        public PantallaPrincipal()
        {
            InitializeComponent();

            //GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Left));
            //GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Right));
            //GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Up));
            //GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Down));
            btnImgInicio.Source = "homeRojo";
            #region gridconfig
            PickerTantos.Items.Add("100");
            PickerTantos.Items.Add("200");
            PickerTantos.Items.Add("300");
            PickerTantos.Items.Add("400");
            PickerTantos.Items.Add("500");
            PickerTantos.Items.Add("500 + Premio");
            #endregion
            var result2 = Configuraciones.ObtenerDatosSesion();

            if (result2.equipoOno == "Si")
            {
                lblY1.IsVisible = true;
                lblY2.IsVisible = true;
                LblJugador2Equipo2.IsVisible = true;
                LblJugador2.IsVisible = true;
            }
            else
            {
                lblY1.IsVisible = false;
                lblY2.IsVisible = false;
                LblJugador2Equipo2.IsVisible = false;
                LblJugador2.IsVisible = false;
            }

            if (Convert.ToInt32(result2.Tantos) == 0)
            {
                Configuraciones.Grabar("", LblJugador1.Text, LblJugador2.Text, "", LblJugador1Equipo2.Text, LblJugador2Equipo2.Text, "100", "", result2.equipoOno);
                LblTantos.Text = result2.Tantos;
            }

            gridInicio.BackgroundColor = Color.WhiteSmoke;
            radioEquipo.IsChecked = true;


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
                    var result = Configuraciones.ObtenerDatosSesion();

                    if (result.equipoOno == "Si")
                    {
                        lblY1.IsVisible = true;
                        lblY2.IsVisible = true;
                        LblJugador2Equipo2.IsVisible = true;
                        LblJugador2.IsVisible = true;
                    }
                    else
                    {
                        lblY1.IsVisible = false;
                        lblY2.IsVisible = false;
                        LblJugador2Equipo2.IsVisible = false;
                        LblJugador2.IsVisible = false;
                    }

                    btnImgInicio.Source = "homeRojo.png";
                    gridComoUsarLaApp.BackgroundColor = Color.White;
                    gridInicio.BackgroundColor = Color.WhiteSmoke;
                    StackLayoutPaginaPrincipal.IsVisible = true;
                    StackLayoutAcercaDe.IsVisible = false;
                    StackLayoutConfig.IsVisible = false;
                    //lytBackNav.IsVisible = true;
                    StackLayoutComoUsarLaApp.IsVisible = false;

                    StackLayoutHistorialPartidas.IsVisible = false;
                    gridHistorialPartidas.BackgroundColor = Color.White;

                    gridconfig.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;

                    LblTantos.Text = result.Tantos;
                    LblJugador1.Text = result.Equipo1Jugador1;
                    LblJugador2.Text = result.Equipo1Jugador2;
                    LblJugador1Equipo2.Text = result.Equipo2Jugador1;
                    LblJugador2Equipo2.Text = result.Equipo2Jugador2;
                    btnImgConfiguracion.Source = "settings";
                    btnImgHistorial.Source = "Document";
                    btnImgComoUsarLaApp.Source = "interrogacion";
                    btnImgInfo.Source = "exclamacion";


                    //lytBackNav1.IsVisible = true;
                }),
                NumberOfTapsRequired = 1
            });

            gridHistorialPartidas.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    btnImgHistorial.Source = "documentRojo.png";
                    gridComoUsarLaApp.BackgroundColor = Color.White;
                    gridInicio.BackgroundColor = Color.White;
                    gridconfig.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;
                    StackLayoutPaginaPrincipal.IsVisible = false;
                    StackLayoutAcercaDe.IsVisible = false;
                    StackLayoutConfig.IsVisible = false;
                    StackLayoutHistorialPartidas.IsVisible = true;
                    StackLayoutComoUsarLaApp.IsVisible = false;

                    //lytBackNav.IsVisible = false;
                    gridHistorialPartidas.BackgroundColor = Color.WhiteSmoke;
                    this.ListGanador = ganador.ObtenerGanadores();
                    this.Lsv_HistorialPartidas.ItemsSource = this.ListGanador;
                    btnImgConfiguracion.Source = "settings";
                    btnImgInicio.Source = "home2";
                    btnImgComoUsarLaApp.Source = "interrogacion";
                    btnImgInfo.Source = "exclamacion";
                }),
                NumberOfTapsRequired = 1
            });

            gridComoUsarLaApp.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    btnImgComoUsarLaApp.Source = "interrogacionRojo.png";
                    gridComoUsarLaApp.BackgroundColor = Color.WhiteSmoke;
                    gridconfig.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;
                    gridInicio.BackgroundColor = Color.White;
                    gridHistorialPartidas.BackgroundColor = Color.White;
                    StackLayoutPaginaPrincipal.IsVisible = false;
                    StackLayoutAcercaDe.IsVisible = false;
                    StackLayoutConfig.IsVisible = false;
                    StackLayoutHistorialPartidas.IsVisible = false;
                    StackLayoutComoUsarLaApp.IsVisible = true;
                    //lytBackNav.IsVisible = false;
                    this.ListGanador = ganador.ObtenerGanadores();
                    this.Lsv_HistorialPartidas.ItemsSource = this.ListGanador;

                    btnImgConfiguracion.Source = "settings";
                    btnImgInicio.Source = "home2";
                    btnImgHistorial.Source = "Document";
                    btnImgInfo.Source = "exclamacion";
                }),
                NumberOfTapsRequired = 1
            });


            gridInfo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    btnImgInfo.Source = "exclamacionRojo.png";
                    gridComoUsarLaApp.BackgroundColor = Color.White;
                    gridInicio.BackgroundColor = Color.White;
                    StackLayoutHistorialPartidas.IsVisible = false;
                    gridHistorialPartidas.BackgroundColor = Color.White;

                    gridconfig.BackgroundColor = Color.White;
                    StackLayoutPaginaPrincipal.IsVisible = false;
                    StackLayoutAcercaDe.IsVisible = true;
                    StackLayoutComoUsarLaApp.IsVisible = false;

                    StackLayoutConfig.IsVisible = false;
                    //lytBackNav.IsVisible = false;
                    gridInfo.BackgroundColor = Color.WhiteSmoke;

                    btnImgConfiguracion.Source = "settings";
                    btnImgInicio.Source = "home2";
                    btnImgHistorial.Source = "Document";
                    btnImgComoUsarLaApp.Source = "interrogacion";

                }),
                NumberOfTapsRequired = 1
            });

            lblemail.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    Device.OpenUri(new Uri($"mailto:{lblemail.Text}?subject={"Sugerencia Kapicúa 25"}"));
                }),
                NumberOfTapsRequired = 1
            });

            gridconfig.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    var result = Configuraciones.ObtenerDatosSesion();

                    if (App.TantosParaGanar == 500 && result.conPremioOno == "Si")
                    {
                        PickerTantos.SelectedItem = "500 + Premio";
                    }
                    if (result.equipoOno == "No")
                    {
                        Framelbljugador2Editar.IsVisible = false;
                        Framelbljugador2Equipo2Editar.IsVisible = false;
                        radioSinEquipo.IsChecked = true;
                    }
                    else
                    {
                        radioEquipo.IsChecked = true;
                    }

                    btnImgConfiguracion.Source = "settingsRojo.png";

                    gridComoUsarLaApp.BackgroundColor = Color.White;
                    gridInicio.BackgroundColor = Color.White;
                    gridInfo.BackgroundColor = Color.White;
                    gridHistorialPartidas.BackgroundColor = Color.White;
                    StackLayoutComoUsarLaApp.IsVisible = false;

                    StackLayoutHistorialPartidas.IsVisible = false;

                    StackLayoutPaginaPrincipal.IsVisible = false;
                    StackLayoutAcercaDe.IsVisible = false;
                    StackLayoutConfig.IsVisible = true;
                    //lytBackNav.IsVisible = false;
                    gridconfig.BackgroundColor = Color.WhiteSmoke;
                    btnImgInfo.Source = "exclamacion";
                    btnImgInicio.Source = "home2";
                    btnImgHistorial.Source = "Document";
                    btnImgComoUsarLaApp.Source = "interrogacion";
                }),
                NumberOfTapsRequired = 1
            });
        }

        async private void lsv_puntos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var result = await DisplayAlert("Aviso", "¿Desea quitar la jugada?", "SI", "NO");
            if (result)
            {
                this.ListPuntos.Remove((EPuntos)lsv_puntos.SelectedItem);
                Puntos.GrabarPuntos(this.ListPuntos);
                this.lsv_puntos.ItemsSource = null;
                this.lsv_puntos.ItemsSource = this.ListPuntos;
                lblPuntosEquipo1.Text = string.Format("{0}", ListPuntos.Sum(n => n.Punto1));
                lblPuntosEquipo2.Text = string.Format("{0}", ListPuntos.Sum(n => n.Punto2));
            }
        }

        //void OnSwiped(object sender, SwipedEventArgs e)
        //{

        //    //lblNombreCompañia.Text = $"You swiped: {e.Direction.ToString()}";
        //}

        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            string DatoDelPicker = "";

            if (picker.SelectedItem == "500 + Premio")
            {
                App.TantosParaGanar = 500;
                App.EsConPremio = "Si";
            }
            else
            {
                App.EsConPremio = "No";

                if (selectedIndex != -1)
                {
                    App.TantosParaGanar = Convert.ToInt32(picker.Items[selectedIndex]);

                }
            }
        }



        protected override void OnAppearing()
        {

            base.OnAppearing();
            var result = Configuraciones.ObtenerDatosSesion();

            if (result.conPremioOno == "Si")
            {
                PickerTantos.SelectedIndex = 5;
            }
            else
            {
                PickerTantos.SelectedItem = result.Tantos;
            }

            LblTantos.Text = App.TantosParaGanar.ToString();

            Puntos = new Puntos();

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

                Configuraciones.Grabar("", LblJugador1.Text, LblJugador2.Text, "", LblJugador1Equipo2.Text, LblJugador2Equipo2.Text, LblTantos.Text, "", result.equipoOno);
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
            PuntosPremio1 = 0;
            PuntosPremio2 = 0;

            var resultagregarronda = Configuraciones.ObtenerDatosSesion();

            if (TxtPuntosEquipo1.Text == "0" && TxtPuntosEquipo2.Text == "0")
            {
                await DisplayAlert("Información", "Los puntos de ambos equipos no pueden estar en 0.", "OK");

            }
            else
            {
                if (!string.IsNullOrEmpty(TxtPuntosEquipo1.Text))
                {
                    if (resultagregarronda.conPremioOno == "Si")
                    {


                        if (resultagregarronda.primeraRonda != "Reclamado")
                        {
                            PuntosPremio1 = 100;
                            Configuraciones.GrabarRondas("Reclamado", "", "", "");
                        }
                        else if (resultagregarronda.segundaRonda != "Reclamado")
                        {
                            PuntosPremio1 = 75;
                            Configuraciones.GrabarRondas("Reclamado", "Reclamado", "", "");
                        }
                        else if (resultagregarronda.terceraRonda != "Reclamado")
                        {
                            PuntosPremio1 = 50;
                            Configuraciones.GrabarRondas("Reclamado", "Reclamado", "Reclamado", "");
                        }
                        else if (resultagregarronda.cuartaRonda != "Reclamado")
                        {
                            PuntosPremio1 = 25;
                            Configuraciones.GrabarRondas("Reclamado", "Reclamado", "Reclamado", "Reclamado");
                        }
                        else
                        {
                            PuntosPremio1 = 0;
                        }


                    }
                    try
                    {
                        Puntos1 = Convert.ToInt32(lblPuntosEquipo1.Text);
                        Puntos2 = Convert.ToInt32(TxtPuntosEquipo1.Text);
                        puntosequipo1 = Puntos1 + Puntos2 + PuntosPremio1;
                        lblPuntosEquipo1.Text = puntosequipo1.ToString();
                        TxtPuntosEquipo1.Text = "";
                    }
                    catch (Exception ex)
                    {

                    }
                   
                }

                if (!string.IsNullOrEmpty(TxtPuntosEquipo2.Text))
                {
                    if (resultagregarronda.conPremioOno == "Si")
                    {
                        if (resultagregarronda.primeraRonda != "Reclamado")
                        {
                            PuntosPremio2 = 100;
                            Configuraciones.GrabarRondas("Reclamado", "", "", "");
                        }
                        else if (resultagregarronda.segundaRonda != "Reclamado")
                        {
                            PuntosPremio2 = 75;
                            Configuraciones.GrabarRondas("Reclamado", "Reclamado", "", "");
                        }
                        else if (resultagregarronda.terceraRonda != "Reclamado")
                        {
                            PuntosPremio2 = 50;
                            Configuraciones.GrabarRondas("Reclamado", "Reclamado", "Reclamado", "");
                        }
                        else if (resultagregarronda.cuartaRonda != "Reclamado")
                        {
                            PuntosPremio2 = 25;
                            Configuraciones.GrabarRondas("Reclamado", "Reclamado", "Reclamado", "Reclamado");
                        }
                        else
                        {
                            PuntosPremio2 = 0;
                        }
                    }


                    try
                    {
                        Puntos3 = Convert.ToInt32(lblPuntosEquipo2.Text);
                        Puntos4 = Convert.ToInt32(TxtPuntosEquipo2.Text);
                        puntosequipos2 = Puntos3 + Puntos4 + PuntosPremio2;
                        lblPuntosEquipo2.Text = puntosequipos2.ToString();
                        TxtPuntosEquipo2.Text = "";
                    }
                    catch (Exception ex)
                    {

                    }
                   
                }

                this.ListPuntos.Add(new EPuntos() { Punto1 = Puntos2 + PuntosPremio1, Punto2 = Puntos4 + PuntosPremio2 });
                Puntos.GrabarPuntos(this.ListPuntos);
                this.lsv_puntos.ItemsSource = null;
                this.lsv_puntos.ItemsSource = this.ListPuntos;
                var result = Configuraciones.ObtenerDatosSesion();

                if (TxtPuntosEquipo1.Text == "")
                {
                    puntosequipo1 = 0;
                    Puntos2 = 0;

                }

                if (TxtPuntosEquipo2.Text == "")
                {
                    puntosequipos2 = 0;
                    Puntos4 = 0;
                }

                string PuntosEquipo1 = lblPuntosEquipo1.Text;
                string PuntosEquipo2 = lblPuntosEquipo2.Text;
                PuntosEquipo1.Replace("Tantos ", "");
                PuntosEquipo2.Replace("Tantos ", "");

                if (Convert.ToInt32(PuntosEquipo1) >= App.TantosParaGanar)
                {
                    if (result.equipoOno == "Si")
                    {
                        ganador.GrabarGanadores(new EGanador() { Ganador1 = result.Equipo1Jugador1, Ganador2 = result.Equipo1Jugador2, Juego = "Ganadores" });
                        await DisplayAlert("Información", "¡El Equipo 1 ha ganado la partida!", "OK");
                    }
                    else
                    {
                        ganador.GrabarGanadores(new EGanador() { Ganador1 = result.Equipo1Jugador1, Ganador2 = "", Juego = "Ganador" });
                        await DisplayAlert($"Información", "¡Felicidades " + result.Equipo1Jugador1 + ", has ganado la partida!", "OK");
                    }


                }
                else if (Convert.ToInt32(PuntosEquipo2) >= App.TantosParaGanar)
                {
                    if (result.equipoOno == "Si")
                    {
                        ganador.GrabarGanadores(new EGanador() { Ganador1 = result.Equipo2Jugador1, Ganador2 = result.Equipo2Jugador2, Juego = "Ganadores" });
                        await DisplayAlert("Información", "¡El Equipo 2 ha ganado la partida!", "OK");
                    }
                    else
                    {
                        ganador.GrabarGanadores(new EGanador() { Ganador1 = result.Equipo2Jugador1, Ganador2 = "", Juego = "Ganador" });
                        await DisplayAlert($"Información", "¡Felicidades " + result.Equipo2Jugador1 + ", has ganado la partida!", "OK");
                    }

                }

            }
        }

        async void BtnTerminarRonda_Clicked(System.Object sender, System.EventArgs e)
        {
            if (await DisplayAlert("Información", "¿Desea terminar la partida?", "SI", "NO"))
            {
                var result = Configuraciones.ObtenerDatosSesion();
                Configuraciones.Grabar("", "", "", "", "", "", "0", "", result.equipoOno);
                MainPage mainpage = new MainPage();
                await Navigation.PushModalAsync(mainpage);
                Configuraciones.Eliminar();
                Configuraciones.EliminarFileRondas();



            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void BtnNuevaPartida_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Información", "¿Desea empezar una nueva la partida?", "SI", "NO"))
            {
                lblPuntosEquipo1.Text = "0";
                lblPuntosEquipo2.Text = "0";
                TxtPuntosEquipo1.Text = "";
                TxtPuntosEquipo2.Text = "";
                lsv_puntos.ItemsSource = null;
                this.ListPuntos.Clear();
                //Configuraciones.Eliminar();
                Puntos.EliminarPuntos(this.ListPuntos);
                Configuraciones.EliminarFileRondas();



            }
        }

        public void BtnGuardarCambios_Clicked(System.Object sender, System.EventArgs e)
        {
            //IndicadorCargando.IsRunning = true;
            try
            {
                Configuraciones.EliminarFileEquipoOno();

                var result = Configuraciones.ObtenerDatosSesion();

                if (PickerTantos.SelectedIndex == 5)
                {
                    Configuraciones.GrabarConPremioOno("Si");
                }
                else
                {
                    Configuraciones.GrabarConPremioOno("No");
                }

                if (radioEquipo.IsChecked == true)
                {
                    equipoOno = "Si";
                }
                else
                {
                    equipoOno = "No";
                }


                Configuraciones.Grabar("", lbljugador1Editar.Text, lbljugador2Editar.Text, "", lbljugador1Equipo2Editar.Text, lbljugador2Equipo2Editar.Text, App.TantosParaGanar.ToString(), result.Ganador, equipoOno);
                toastConfigClass.MostrarNotificacion($"¡Los datos se han guardado exitosamente!", ToastPosition.Top, 3, "#51C560");

            }
            catch (Exception ex)
            {
                toastConfigClass.MostrarNotificacion($"Los datos no se han guardado, intente mas tarde.", ToastPosition.Top, 3, "#c82333");
            }

            //IndicadorCargando.IsRunning = false;
        }

        private async void BtnBorrarHistorial_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Información", "¿Desea eliminar el historial de partidas?", "SI", "NO"))
            {
                ganador.EliminarGanadores(this.ListGanador);
                this.ListGanador = ganador.ObtenerGanadores();
                this.Lsv_HistorialPartidas.ItemsSource = this.ListGanador;
            }

        }

        [Obsolete]
        void Btninstagram_Clicked(System.Object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("instagram://user?username=kapicua25app"));
        }

        void radioEquipo_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            Framelbljugador2Editar.IsVisible = true;
            Framelbljugador2Equipo2Editar.IsVisible = true;
            equipoOno = "Si";
        }

        void radioSinEquipo_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            Framelbljugador2Editar.IsVisible = false;
            Framelbljugador2Equipo2Editar.IsVisible = false;
            equipoOno = "No";

        }

        async void BtnCompartirApp_Clicked(System.Object sender, System.EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Prueba esta aplicación para anotar los puntos en el domino, está genial.",
                Title = "Share!"
            });
        }
    }
}