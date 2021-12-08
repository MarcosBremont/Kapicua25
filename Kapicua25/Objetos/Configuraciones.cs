using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kapicua25.Objetos
{
    public class Configuraciones
    {
        public static string UrlLogo { get; set; }
        public static string NombreEmpresa { get; set; }
        public static bool IsPrimeraVez { get; set; } = false;
        public static string UrlApi { get; set; }
        public static string Telefono { get; set; }


        public static void Grabar(string Equipo1, string Equipo1Jugador1, string Equipo1Jugador2, string Equipo2, string Equipo2Jugador1, string Equipo2Jugador2, string tantosParaGanar)
        {
            string fileEquipo1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1");
            string fileEquipo1Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador1");
            string fileEquipo1Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador2");
            string fileEquipo2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2");
            string fileEquipo2Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador1");
            string fileEquipo2Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador2");
            string TantosParaGanar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tantosParaGanar");

            File.WriteAllText(fileEquipo1, Equipo1);
            File.WriteAllText(fileEquipo1Jugador1, Equipo1Jugador1);
            File.WriteAllText(fileEquipo1Jugador2, Equipo1Jugador2);
            File.WriteAllText(fileEquipo2, Equipo2);
            File.WriteAllText(fileEquipo2Jugador1, Equipo2Jugador1);
            File.WriteAllText(fileEquipo2Jugador2, Equipo2Jugador2);
            File.WriteAllText(TantosParaGanar, tantosParaGanar);
        }

        public static Tuple<string, string, string, string, string, string, string> ObtenerDatosSesion()
        {
            string Equipo1 = string.Empty, Equipo1Jugador1 = string.Empty, Equipo1Jugador2 = string.Empty, Equipo2 = string.Empty, Equipo2Jugador1 = string.Empty, Equipo2Jugador2 = string.Empty, Tantos = string.Empty;
            try
            {
                string fileEquipo1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1");
                string fileEquipo1Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador1");
                string fileEquipo1Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador2");
                string fileEquipo2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2");
                string fileEquipo2Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador1");
                string fileEquipo2Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador2");
                string TantosParaGanar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tantosParaGanar");
                Equipo1 = File.ReadAllText(fileEquipo1);
                Equipo1Jugador1 = File.ReadAllText(fileEquipo1Jugador1);
                Equipo1Jugador2 = File.ReadAllText(fileEquipo1Jugador2);
                Equipo2 = File.ReadAllText(fileEquipo2);
                Equipo2Jugador1 = File.ReadAllText(fileEquipo2Jugador1);
                Equipo2Jugador2 = File.ReadAllText(fileEquipo2Jugador2);
                Tantos = File.ReadAllText(TantosParaGanar);
            }
            catch (Exception)
            {

            }

            
            return Tuple.Create(Equipo1, Equipo1Jugador1, Equipo1Jugador2, Equipo2, Equipo2Jugador1, Equipo2Jugador2, Tantos);
        }


        public static void Eliminar()
        {
            string fileEquipo1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1");
            string fileEquipo1Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador1");
            string fileEquipo1Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador2");
            string fileEquipo2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2");
            string fileEquipo2Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador1");
            string fileEquipo2Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador2");
            string Tantos = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador2");

            File.Delete(fileEquipo1);
            File.Delete(fileEquipo1Jugador1);
            File.Delete(fileEquipo1Jugador2);
            File.Delete(fileEquipo2);
            File.Delete(fileEquipo2Jugador1);
            File.Delete(fileEquipo2Jugador2);
            File.Delete(Tantos);
        }

    }
}
