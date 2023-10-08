using Cadetes;
using Pedidos;
using Clientes;
using System.Text;
namespace Cadeterias
{
public class Cadeteria
{
    private string? nombre;
    private int telefono;
    private List<Cadete>? listadoCadetes;
    private List<Pedido>? listadoPedidos;
    public string? Nombre { get => nombre; set => nombre = value; }

    public Cadeteria()
    {
        this.nombre="Wombat";
        this.telefono=4342392;
        this.listadoCadetes=new List<Cadete>();
        this.listadoPedidos=new List<Pedido>();
    }
    public Cadeteria(string nombre, int telefono)
    {
        this.nombre=nombre;
        this.telefono=telefono;
        this.listadoCadetes=new List<Cadete>();
        this.listadoPedidos=new List<Pedido>();
    }
    public void AsignarCadeteAPedido(int idPedido, int idCadete)
    {
        if (this.listadoPedidos!.FirstOrDefault(p=>p.ObtenerID()==idPedido)!=null)
        {
            Pedido Encontrado = new Pedido();
            Encontrado = this.listadoPedidos!.FirstOrDefault(p=>p.ObtenerID()==idPedido)!;
            if (this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!=null)
            {
                Encontrado.CadeteCargo1=this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!.Nombre;
                Encontrado.cambiarEstado(1);
                this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!.CantEnvios++;
            }else
            {
                Console.WriteLine("No se encontro el cadete seleccionado");
            }
        }else{
            Console.WriteLine("No se encontro el pedido");
        }
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
        this.listadoPedidos!.Add(nuevoPedido);
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
        viejo.SacarPedido(pedido);
        nuevo.CantEnvios++;
        nuevo.TomarPedido(pedido);
    }
    public string MostrarCadetes()
    {
        StringBuilder cadetesInfo = new StringBuilder();

        foreach (var cadete in this.listadoCadetes!)
        {
            cadetesInfo.AppendLine($"------CADETE ID {cadete.ObtenerID()} ----------");
            cadetesInfo.AppendLine($"NOMBRE {cadete.Nombre}");
            cadetesInfo.AppendLine($"DIRECCION {cadete.Direccion}");
            cadetesInfo.AppendLine($"TELEFONO {cadete.Telefono}");
            cadetesInfo.AppendLine("-----------------------------------------------");
        }

        return cadetesInfo.ToString();
    }
      public string MostrarPedidos()
        {
            StringBuilder pedidosInfo = new StringBuilder();

            foreach (var pedido in this.listadoPedidos!)
            {
                string pedidoInfo = pedido.MostrarPedido();
                pedidosInfo.AppendLine(pedidoInfo);
            }

            return pedidosInfo.ToString();
        }
    public void JornalACobrar(int idCadete)
    {
        Cadete Encontrado = new Cadete();
        if (this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!=null)
            {
                Encontrado=this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!;
                Console.WriteLine("El Jornal a cobrar del cadete es: "+Encontrado.CantEnvios*500);
            }else
            {
                Console.WriteLine("No se encontro el cadete seleccionado");
            }
    }
    public void agregarPedido(Pedido pedido)
    {
        this.listadoPedidos!.Add(pedido);
    }

}
}
