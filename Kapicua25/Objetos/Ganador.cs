﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace Kapicua25.Objetos
{
    public class Ganador
    {
        public List<EGanador> ObtenerGanadores()
        {
            List<EGanador> list = new List<EGanador>();

            try
            {
                if (File.Exists(ObtenerRuta("ganador")))
                {
                    var fileGanador = File.ReadAllText(ObtenerRuta("ganador"));
                    var json = JsonConvert.SerializeObject(fileGanador).Replace("\\", "");
                    if (json.Length > 4)
                    {
                        json = json.Substring(1, json.Length - 2);
                        list = JsonConvert.DeserializeObject<List<EGanador>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        private string ObtenerRuta(string nombreArchivo)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nombreArchivo);
        }
        public bool GrabarGanadores(List<EGanador> Ganador)
        {
            bool result = true;
            try
            {
                var json = JsonConvert.SerializeObject(Ganador);
                if (File.Exists(ObtenerRuta("ganador")))
                    File.Delete(ObtenerRuta("ganador"));

                File.WriteAllText(ObtenerRuta("ganador"), json);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;

        }


        public bool EliminarGanadores(List<EGanador> Ganador)
        {
            bool result = true;
            try
            {
                var json = JsonConvert.SerializeObject(Ganador);
                if (File.Exists(ObtenerRuta("ganador")))
                    File.Delete(ObtenerRuta("ganador"));

                //File.WriteAllText(ObtenerRunta("datos"), json);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;

        }
    }
}
