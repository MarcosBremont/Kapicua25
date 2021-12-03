using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace Kapicua25.Objetos
{
    public class Puntos
    {
        public List<EPuntos> ObtenerPuntos()
        {
            List<EPuntos> list = new List<EPuntos>();

            try
            {
                if (File.Exists(ObtenerRunta("datos")))
                {
                    var fileDatos = File.ReadAllText(ObtenerRunta("datos"));
                    var json = JsonConvert.SerializeObject(fileDatos).Replace("\\", "");
                    if (json.Length > 4)
                    {
                        json = json.Substring(1, json.Length - 2);
                        list = JsonConvert.DeserializeObject<List<EPuntos>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        private string ObtenerRunta(string nombreArchivo)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nombreArchivo);
        }
        public bool GrabarPuntos(List<EPuntos> puntos)
        {
            bool result = true;
            try
            {
                var json = JsonConvert.SerializeObject(puntos);
                if (File.Exists(ObtenerRunta("datos")))
                    File.Delete(ObtenerRunta("datos"));

                File.WriteAllText(ObtenerRunta("datos"), json);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;

        }
    }
}
