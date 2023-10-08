using Cadeterias;
using Cadetes;
using System.Text.Json;
namespace AccesoDatos
{
    public class AccesoADatos
    {
        public virtual List<Cadete>? LeerArchivo(string nombreArchivo)
        {
            return null;
        }

        public virtual void GuardarArchivo(List<Cadete> listaCadetes){}
    }

    public class CSV : AccesoADatos
    {
        public override List<Cadete>? LeerArchivo(string nombreArch)
        {
        string nombreArchivo =nombreArch; // Reemplaza con la ruta de tu archivo CSV

        List<string[]> listaDeArreglos = new List<string[]>();
        List<Cadete> nuevaLista = new List<Cadete>();

        if (File.Exists(nombreArchivo))
        {
            using (StreamReader sr = new StreamReader(nombreArchivo))
            {
                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine()!;
                    string[] campos = linea.Split(',');

                    listaDeArreglos.Add(campos);
                }
            }
            // Ahora tienes una lista de arreglos de cadenas
           if (listaDeArreglos != null && listaDeArreglos.Any())
            {
                int id = 0;
                foreach (var cadete in listaDeArreglos)
                {
                    if (cadete == null)
                        break;
                    var nuevoCadete = new Cadete(id, cadete[0], cadete[1], cadete[2]);
                    nuevaLista.Add(nuevoCadete);
                    id += 1;
                }
            }
            return nuevaLista;
        }
        else
        {
            Console.WriteLine("El archivo no existe: " + nombreArchivo);
            return null;
        }
        
    }

    }
    public class JSON : AccesoADatos
    {
        public override List<Cadete>? LeerArchivo(string rutaDeArchivo)
        {
            List<Cadete>? listaProductos;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaProductos = JsonSerializer.Deserialize<List<Cadete>>(documento);
            }
            return listaProductos;
        }
        public override void GuardarArchivo(List<Cadete> listaCadetes)
        {
           /*  // Serializar el objeto en formato JSON
            string json = JsonSerializer.Serialize(nombreArchivo);

            // Especificar la ruta del archivo donde deseas guardar el JSON
            string rutaArchivo = "Cadetes.json";

            // Guardar el JSON en un archivo
            File.WriteAllText(rutaArchivo, json); */
            string json = JsonSerializer.Serialize(listaCadetes, new JsonSerializerOptions
            {
                WriteIndented = true // Indentar el JSON para mayor legibilidad
            });

            // Especificar la ruta del archivo donde deseas guardar el JSON
            string rutaArchivo = "personas.json";

            // Guardar el JSON en un archivo
            File.WriteAllText(rutaArchivo, json);

            Console.WriteLine("Datos guardados en el archivo JSON.");
            }
    }
        
}