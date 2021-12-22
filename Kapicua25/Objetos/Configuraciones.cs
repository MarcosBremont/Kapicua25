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


        public static void Grabar(string Equipo1, string Equipo1Jugador1, string Equipo1Jugador2, string Equipo2, string Equipo2Jugador1, string Equipo2Jugador2, string tantosParaGanar, string ganador, string equipoOno, string conPremioOno)
        {
            string fileEquipo1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1");
            string fileEquipo1Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador1");
            string fileEquipo1Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador2");
            string fileEquipo2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2");
            string fileEquipo2Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador1");
            string fileEquipo2Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador2");
            string TantosParaGanar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tantosParaGanar");
            string fileGanador = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ganador");
            string fileequipoOno = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "equipoOno");
            string fileconPremioOno = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "conPremioOno");

            File.WriteAllText(fileEquipo1, Equipo1);
            File.WriteAllText(fileEquipo1Jugador1, Equipo1Jugador1);
            File.WriteAllText(fileEquipo1Jugador2, Equipo1Jugador2);
            File.WriteAllText(fileEquipo2, Equipo2);
            File.WriteAllText(fileEquipo2Jugador1, Equipo2Jugador1);
            File.WriteAllText(fileEquipo2Jugador2, Equipo2Jugador2);
            File.WriteAllText(TantosParaGanar, tantosParaGanar);
            File.WriteAllText(fileGanador, ganador);
            File.WriteAllText(fileequipoOno, equipoOno);
            File.WriteAllText(fileconPremioOno, conPremioOno);
        }

        public static EGlobal ObtenerDatosSesion()
        {
            EGlobal eGlobal = new EGlobal();
            //string Equipo1 = string.Empty, Equipo1Jugador1 = string.Empty, Equipo1Jugador2 = string.Empty, Equipo2 = string.Empty, Equipo2Jugador1 = string.Empty, Equipo2Jugador2 = string.Empty, Tantos = string.Empty;
            try
            {
                string fileEquipo1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1");
                string fileEquipo1Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador1");
                string fileEquipo1Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo1Jugador2");
                string fileEquipo2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2");
                string fileEquipo2Jugador1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador1");
                string fileEquipo2Jugador2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Equipo2Jugador2");
                string TantosParaGanar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tantosParaGanar");
                string fileGanador = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ganador");
                string fileequipoOno = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "equipoOno");
                string fileconPremioOno = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "conPremioOno");
                eGlobal.Equipo1 = File.ReadAllText(fileEquipo1);
                eGlobal.Equipo1Jugador1 = File.ReadAllText(fileEquipo1Jugador1);
                eGlobal.Equipo1Jugador2 = File.ReadAllText(fileEquipo1Jugador2);
                eGlobal.Equipo2 = File.ReadAllText(fileEquipo2);
                eGlobal.Equipo2Jugador1 = File.ReadAllText(fileEquipo2Jugador1);
                eGlobal.Equipo2Jugador2 = File.ReadAllText(fileEquipo2Jugador2);
                eGlobal.Tantos = File.ReadAllText(TantosParaGanar);
                eGlobal.Ganador = File.ReadAllText(fileGanador);
                eGlobal.equipoOno = File.ReadAllText(fileequipoOno);
                eGlobal.equipoOno = File.ReadAllText(fileequipoOno);
            }
            catch (Exception)
            {

            }


            //return Tuple.Create(Equipo1, Equipo1Jugador1, Equipo1Jugador2, Equipo2, Equipo2Jugador1, Equipo2Jugador2, Tantos);
            return eGlobal;
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
            string fileGanador = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ganador");


            File.Delete(fileEquipo1);
            File.Delete(fileEquipo1Jugador1);
            File.Delete(fileEquipo1Jugador2);
            File.Delete(fileEquipo2);
            File.Delete(fileEquipo2Jugador1);
            File.Delete(fileEquipo2Jugador2);
            File.Delete(Tantos);
            File.Delete(fileGanador);
        }

        public static void EliminarFileEquipoOno()
        {
            string fileequipoOno = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "equipoOno");
            File.Delete(fileequipoOno);
        }

        public static void EliminarFileConPremioOno()
        {
            string fileconPremioOno = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "conPremioOno");
            File.Delete(fileconPremioOno);
        }

    }
}
