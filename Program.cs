using Cadeterias;
using Cadetes;
using Clientes;
using Pedidos;
using ArchivoExterno;
using System.IO;
using System.Collections;
using System.Linq;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        int numeroPedido=1;
        Pedido nuevoPedido = new Pedido();
        Cadete cadeteAsignado = new Cadete();
        Cadete nuevoCadete = new Cadete();
        Cadeteria cadeteria = new Cadeteria();
        List<Pedido> listaPedidos = new List<Pedido>();
        List<Cadete> listaCadetes = CSV.CargarCadetes("Cadetes.csv");
        cadeteria.AgregarCadete(listaCadetes);
        cadeteria.MostrarCadetes();
        
        int opcion;
        do
        {
            Console.WriteLine("----------MENU----------");
            Console.WriteLine("1)Dar de alta pedidos");
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
                    listaPedidos.Add(nuevoPedido);
                    numeroPedido++;
                break;
                case 2:
                Console.WriteLine("Asignar el pedido al cadete");
                cadeteAsignado = cadeteria.AsignarCadete(nuevoPedido);
                break;
                case 3:
                Console.WriteLine("Cambiar de estado el pedido");
                cadeteria.cambiarEstado(nuevoPedido, cadeteAsignado);
                break;
                case 4:
                Console.WriteLine("Reasignar el pedido a ");
                nuevoCadete = cadeteria.AsignarCadete(nuevoPedido);
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