using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfGuestTableDal : GenericRepository<GuestTable>, IGuestTableDal
    {
        public EfGuestTableDal(SignalRContext context) : base(context)
        {
        }

        public int GuestTableCount()
        {
            using var context = new SignalRContext();
            return context.GuestTables.Count();
        }
    }
}
