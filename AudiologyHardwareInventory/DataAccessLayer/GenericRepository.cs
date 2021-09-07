using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Interface;
using Microsoft.EntityFrameworkCore;

namespace AudiologyHardwareInventory.DataAccessLayer
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        private readonly DbSet<T> _table = null;

        //public GenericRepository(HardwareInventoryContext context)
        //{
        //    this._hardwareInventoryContext = context;
        //    _table = context.Set<T>();
        //}
        public GenericRepository()
        {
            this._hardwareInventoryContext = DBConnection.CreateHardwareInventoryContext();
            _table = _hardwareInventoryContext.Set<T>();
        }

        public void Create(T item)
        {
            _hardwareInventoryContext.Add(item);
            _hardwareInventoryContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _hardwareInventoryContext.Remove(item);
            _hardwareInventoryContext.SaveChanges();
        }

        public IEnumerable<T> Select()
        {
            if (_table != null)
            {
                return _table.ToList();
            }
            return null;
        }

        public void Update(T dataToUpdate)
        {
            _hardwareInventoryContext.Update(dataToUpdate);
            _hardwareInventoryContext.SaveChanges();
        }
    }
}
