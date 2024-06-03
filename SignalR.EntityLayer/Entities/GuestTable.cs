using System.Reflection.Emit;
using System.Security.AccessControl;

namespace SignalR.EntityLayer.Entities
{
    public class GuestTable
    {
        public int GuestTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
