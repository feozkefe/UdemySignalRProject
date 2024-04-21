using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IGuestTableDal:IGenericDal<GuestTable>
    {
        int GuestTableCount();
    }
}
