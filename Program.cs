using Cadeterias;
using Cadetes;
using Clientes;
using Pedidos;
using AccesoDatos;
using System.IO;
using System.Collections;
using System.Linq;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        int numeroPedido=1;
        AccesoADatos lecturaCSV = new CSV();
        AccesoADatos JSONS = new JSON();
        Pedido nuevoPedido = new Pedido();
        Cadete cadeteAsignado = new Cadete();
        Cadete nuevoCadete = new Cadete();
        Cadeteria cadeteria = new Cadeteria();
        List<Pedido> listaPedidos = new List<Pedido>();
        List<Cadete> listaCadetes =lecturaCSV.LeerArchivo("Cadetes.csv")!;
        JSONS.GuardarArchivo(listaCadetes);
        cadeteria.AgregarCadete(listaCadetes);
        cadeteria.MostrarCadetes();
        
        int opcion;
        do
        {
            Console.WriteLine("----------MENU----------");
            Console.WriteLine("1)Nuevo pedido");
            Console.WriteLine("2)Asignarlos a cadetes");
            Console.WriteLine("3)Cambiarlos de estado");
            Console.WriteLine("4)Reasignar el pedido a otro cadete");
            Console.WriteLine("5)Salir");
            Console.WriteLine("Selecciona la opcion");
            int.TryParse(Console.ReadLine(), out opcion);
            switch (opcion)
            {
                case 1:
                    nuevoPedido = cadeteria.DarDeAlta(numeroPedido);
                    numeroPedido++;
                break;
                case 2:
                int idCadete, idPedido;
                cadeteria.MostrarPedidos();
                Console.WriteLine("Selecciona el pedido que desea asignar");
                int.TryParse(Console.ReadLine(), out idPedido);
                Console.WriteLine("Selecciona el cadete");
                int.TryParse(Console.ReadLine(), out idCadete);
                cadeteria.AsignarCadeteAPedido(idPedido,idCadete);
                cadeteria.JornalACobrar(idCadete);
                break;
                case 3:
                Console.WriteLine("Cambiar de estado el pedido");
                cadeteria.cambiarEstado(nuevoPedido, cadeteAsignado);
                break;
                case 4:
                Console.WriteLine("Reasignar el pedido a ");
                cadeteria.cambiarCadete(cadeteAsignado, nuevoCadete, nuevoPedido);
                cadeteAsignado = nuevoCadete;
                break;
                default:
                    Console.WriteLine("Selecciona la opcion correcta");
                break;
            }
        } while (opcion!=5);
    }
}