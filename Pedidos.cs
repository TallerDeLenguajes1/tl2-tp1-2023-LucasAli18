using Cadetes;
using Clientes;

namespace Pedidos
{
     public enum EstadoPedidos{
        aceptado,
        pendiente,
        rechazado
    }
    public class Pedido
    {
        private int Numero;
        private string? Obs;
        private string? CadeteCargo;
        private Cliente? Cliente;
        private EstadoPedidos Estado;

        public string? CadeteCargo1 { get => CadeteCargo; set => CadeteCargo = value; }

        //Constructor PEDIDO
        public Pedido(int nro, string obs, Cliente cliente)
        {
            Numero = nro;
            Obs=obs;
            Cliente =cliente;
            Estado = EstadoPedidos.pendiente;
            CadeteCargo = null;
        }
        public Pedido()
        {
            Numero=0;
            Obs="";
            Cliente =new Cliente();
            Estado=EstadoPedidos.pendiente;
            CadeteCargo = null;
        }
        public string MostrarPedido()
        {
            string pedidoInfo = "--------------------------------\n";
            pedidoInfo += "---------Pedido nro: " + this.Numero + "\n";
            pedidoInfo += "---------Observacion: " + this.Obs + "\n";
            pedidoInfo += "---------Estado: " + this.Estado + "\n";
            if (CadeteCargo == null)
            {
                CadeteCargo = "Sin cadete";
            }
            pedidoInfo += "---------Cadete a cargo: " + this.CadeteCargo + "\n";
            pedidoInfo += "---------Cliente: \n";
            pedidoInfo += this.Cliente!.MostrarCliente();
            pedidoInfo += "--------------------------------";
            return pedidoInfo;
        }
        public string VerDireccionCliente(Cliente cliente)
        {
            return "Direccion del cliente: " + cliente.Direccion + "\n" + "Direccion del cliente: " + cliente.DatosReferenciaDireccion;
        }   
        public string VerDatosCliente(Cliente cliente)
        {
            return "Nombre del cliente: " + cliente.Nombre + "\n" + "Teléfono del cliente: " + cliente.Telefono;
        }   
        public void cambiarEstado(int num)
        {
            switch (num)
            {
                case 1:
                  this.Estado=EstadoPedidos.aceptado;              
                break;
                case 2:
                  this.Estado=EstadoPedidos.rechazado;
                break;
                case 3:
                  this.Estado=EstadoPedidos.pendiente;
                break;
                default:
                Console.WriteLine("Ingreso mal el numero");
                break;
            } 
        }
        public int ObtenerID()
        {
            return this.Numero;
        }
    }
}

