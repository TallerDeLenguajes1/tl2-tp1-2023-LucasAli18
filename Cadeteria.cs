using Cadetes;
using Pedidos;
using Clientes;
namespace Cadeterias
{
public class Cadeteria
{
    private string? nombre;
    private int telefono;
    private List<Cadete>? listadoCadetes;
    public string? Nombre { get => nombre; set => nombre = value; }

    public Cadeteria()
    {
        this.nombre="Wombat";
        this.telefono=4342392;
        this.listadoCadetes=new List<Cadete>();
    }
    public Cadeteria(string nombre, int telefono)
    {
        this.nombre=nombre;
        this.telefono=telefono;
        this.listadoCadetes=new List<Cadete>();
    }
    public Cadete AsignarCadete(Pedido pedido)
    {
        Console.WriteLine("A que cadete desea asignar el pedido?");
        string? nombreCadete = Console.ReadLine();
        this.listadoCadetes!.FirstOrDefault(p=>p.Nombre==nombreCadete)!.TomarPedido(pedido);
        this.listadoCadetes!.FirstOrDefault(p=>p.Nombre==nombreCadete)!.CantEnvios++;
        this.listadoCadetes!.FirstOrDefault(p=>p.Nombre==nombreCadete)!.MostrarPedidos();
        return this.listadoCadetes!.FirstOrDefault(p=>p.Nombre==nombreCadete)!;
    }
    public void AgregarCadete(List<Cadete> cadete)
    {
        this.listadoCadetes!.AddRange(cadete);
    }
    public Pedido DarDeAlta(int numeroPedido)
    {
        string? nom, dir, referencia, observacion;
        int tel;
        Console.WriteLine("Introducir el nombre del cliente");
        nom = Console.ReadLine()!;
        Console.WriteLine("Introducir la direccion del cliente");
        dir = Console.ReadLine()!;
        Console.WriteLine("Introducir el nombre del cliente");
        int.TryParse(Console.ReadLine(),out tel);
        Console.WriteLine("Introducir una referencia de la direccion");
        referencia = Console.ReadLine()!;
        Console.WriteLine();
        Console.WriteLine("Observacion sobre el pedido");
        observacion = Console.ReadLine()!;
        Cliente nuevoCliente = new Cliente(nom,dir,tel,referencia);
        Pedido nuevoPedido = new Pedido(numeroPedido,observacion,nuevoCliente);
        return nuevoPedido;
    }
    public void cambiarEstado(Pedido pedido, Cadete cadete)
    {
        Console.WriteLine("Que desea realizar al pedido?");
        Console.WriteLine("1. Aceptado");
        Console.WriteLine("2. Pendiente");
        Console.WriteLine("3. Rechazado");
        int.TryParse(Console.ReadLine(),out int num);
        if (num == 3)
        {
            cadete.ActualizarPedido(pedido,3);
        }else if (num == 2)
        {
            cadete.ActualizarPedido(pedido,2);
        }else
        {
            cadete.ActualizarPedido(pedido,1);
        }
        pedido.MostrarPedido();
    }
    public void EliminarCadete(Cadete cadete)
    {
        this.listadoCadetes!.Remove(cadete);
    }
    public void cambiarCadete(Cadete viejo, Cadete nuevo, Pedido pedido)
    {
        viejo.CantEnvios--;
        viejo.EliminarPedido(pedido);
        nuevo.CantEnvios++;
        nuevo.TomarPedido(pedido);
    }
    public void MostrarCadetes()
    {
        foreach (var cadete in this.listadoCadetes!)
        {
            Console.WriteLine($"------CADETE ID {cadete.ObtenerID()} ----------");
            Console.WriteLine($"NOMBRE {cadete.Nombre}");
            Console.WriteLine($"DIRECCION {cadete.Direccion}");
            Console.WriteLine($"TELEFONO {cadete.Telefono}");
            Console.WriteLine("-----------------------------------------------");
                   
        }
    }

}
}
