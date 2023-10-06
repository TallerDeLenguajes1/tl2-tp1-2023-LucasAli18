using Cadetes;
namespace ArchivoExterno
{
   public class CSV
   {
    public static List<string[]>? LeerCsv(string nombreArchivo)
    {
        var LecturaDelArchivo = new List<string[]>();
        if (File.Exists(nombreArchivo)) {
            var archivo = new FileStream(nombreArchivo, FileMode.Open);
            var strReader = new StreamReader(archivo);
            var linea = "";
            while ((linea = strReader.ReadLine()) != null) {
                string[] arregloLinea = linea.Split(',');
                LecturaDelArchivo.Add(arregloLinea);
            }
            strReader.Close();
        }
        else {
            Console.WriteLine("Archivo no encontrado: {0}", nombreArchivo);
            return null;
        }
        return LecturaDelArchivo;
    }
    public static List<Cadete> CargarCadetes(string ruta)
    {
        Cadete nuevoCadete;
        var nuevaLista = new List<Cadete>();
        var listaCsv = LeerCsv(ruta);
        
        if (listaCsv != null && listaCsv.Any()) {
            int id=0;
            foreach (var cadete in listaCsv) {
                if(cadete == null)
                    break;
                nuevoCadete = new Cadete(id,cadete[0],cadete[1],cadete[2]);
                nuevaLista.Add(nuevoCadete);
                id++;
            }
        } else {
            Console.WriteLine("\n(no se encontraron cadetes para cargar)");
        }
        return nuevaLista;
    }

   } 
}