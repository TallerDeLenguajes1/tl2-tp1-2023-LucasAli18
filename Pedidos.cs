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
        private Cliente? Cliente;
        private EstadoPedidos Estado;

        //Constructor PEDIDO
        public Pedido(int nro, string obs, Cliente cliente)
        {
            Numero = nro;
            Obs=obs;
            Cliente =cliente;
            Estado = EstadoPedidos.pendiente;
        }
        public Pedido()
        {
            Numero=0;
            Obs="";
            Cliente =new Cliente();
            Estado=EstadoPedidos.pendiente;
        }
        public void MostrarPedido()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("---------Pedido nro: "+this.Numero);
            Console.WriteLine("---------Observacion: "+this.Obs);
            Console.WriteLine("---------Estado: "+this.Estado);
            Console.WriteLine("---------Cliente: ");
            this.Cliente!.MostrarCliente();
            Console.WriteLine("--------------------------------");
        }
        public void VerDireccionCliente(Cliente cliente)
        {
            Console.WriteLine("Direccion del cliente: "+cliente.Direccion);
            Console.WriteLine("Direccion del cliente: "+cliente.DatosReferenciaDireccion);
        }    
        public void VerDatosCliente(Cliente cliente)
        {
            Console.WriteLine("Direccion del cliente: "+cliente.Nombre);
            Console.WriteLine("Direccion del cliente: "+cliente.Telefono);
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
    }
}

