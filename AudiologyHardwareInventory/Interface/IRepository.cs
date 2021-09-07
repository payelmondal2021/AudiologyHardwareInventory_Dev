using System.Collections.Generic;

namespace AudiologyHardwareInventory.Interface
{
    public interface IRepository<T> where T : class
    {
        void Delete(T item);
        void Create(T id);
        void Update(T item);
        IEnumerable<T> Select();

    }
}
