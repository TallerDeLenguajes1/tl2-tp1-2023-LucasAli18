using Pedidos;

namespace Cadetes
{
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;
        private List<Pedido> listadoPedidos;
        public int CantEnvios;
        public float CantGanado;

        public string? Telefono { get => telefono; set => telefono = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Nombre { get => nombre; set => nombre = value; }

        public Cadete(int id,string nombre, string dir, string telefono)
        {
            this.id=id;
            Nombre=nombre;
            Direccion = dir;
            Telefono=telefono;
            this.listadoPedidos =new List<Pedido>();
            this.CantEnvios=0;
            this.CantGanado=0;
        }
        public Cadete()
        {
            this.id=999;
            Nombre="NN";
            Direccion = "NN";
            Telefono="999";
            this.listadoPedidos =new List<Pedido>();
            this.CantEnvios=0;
            this.CantGanado=0;
        }
        public int ObtenerID()
        {
           return this.id;
        }
        public void TomarPedido(Pedido pedido)
        {
            this.listadoPedidos.Add(pedido);
            pedido.cambiarEstado(1);
        }
        public void EliminarPedido (Pedido pedido)
        {
            this.listadoPedidos.Remove(pedido);
            pedido.cambiarEstado(2);
            pedido.MostrarPedido();
        }
        public void ActualizarPedido(Pedido pedido, int num)
        {
            pedido.cambiarEstado(num);
            if (num==1)
            {
                this.CantEnvios++;
            }else if (num==3)
            {
            this.CantEnvios--;
            this.listadoPedidos.Remove(pedido);
            }else{
                return;
            }
        }
        public void MostrarPedidos()
        {
            foreach (var pedido in this.listadoPedidos)
            {
                pedido.MostrarPedido();
            }
        }
    }
}