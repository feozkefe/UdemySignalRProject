using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGuestTableService:IGenericService<GuestTable>
    {
        int TGuestTableCount();

    }
}
