using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class GuestTableManager : IGuestTableService
    {
        private readonly IGuestTableDal _guestTableDal;

        public GuestTableManager(IGuestTableDal guestTableDal)
        {
            _guestTableDal = guestTableDal;
        }

        public void TAdd(GuestTable entity)
        {
            _guestTableDal.Add(entity);
        }

        public void TDelete(GuestTable entity)
        {
            _guestTableDal.Delete(entity);
        }

        public GuestTable TGetById(int id)
        {
            return _guestTableDal.GetById(id);
        }

        public List<GuestTable> TGetListAll()
        {
            return _guestTableDal.GetListAll();
        }

        public int TGuestTableCount()
        {
            return _guestTableDal.GuestTableCount();
        }

        public void TUpdate(GuestTable entity)
        {
            _guestTableDal.Update(entity);
        }
    }
}
