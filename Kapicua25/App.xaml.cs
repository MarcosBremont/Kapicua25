using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kapicua25
{
    public partial class App : Application
    {
        public static int TantosParaGanar { get; set; }
        public static string Equipo1 { get; set; }
        public static string Equipo2 { get; set; }
        public static string Jugador1Equipo1 { get; set; }
        public static string Jugador2Equipo1 { get; set; }
        public static string Jugador1Equipo2 { get; set; }
        public static string Jugador2Equipo2 { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Pantallas.PantallaPrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
