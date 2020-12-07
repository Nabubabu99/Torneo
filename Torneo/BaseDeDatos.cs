using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Torneo
{
    class BaseDeDatos
    {
        public List<Partido> partidos = new List<Partido>();
        public string ruta;

        public BaseDeDatos(string ruta)
        {
            this.ruta = ruta;
        }

        public void Guardar()
        {
            string partido = JsonConvert.SerializeObject(partidos);
            File.WriteAllText(ruta, partido);
        }

        public void Cargar()
        {
            string archivo = File.ReadAllText(ruta);
            partidos = JsonConvert.DeserializeObject<List<Partido>>(archivo);
            foreach (var partidoG in partidos)
            {
                Console.WriteLine($" El partido es {partidoG.partidoCreado()} {partidoG.equipoLocal.numeroEquipo}");
            }
        }

        public void CargarPartidos(Partido partido)
        {
            partidos.Add(partido);
            Guardar();
        }
    }
}
