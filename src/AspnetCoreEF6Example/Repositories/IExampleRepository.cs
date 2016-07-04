using System.Collections.Generic;
using AspnetCoreEF6Example.Models;

namespace AspnetCoreEF6Example.Repositories
{
    public interface IExampleRepository
    {
        IEnumerable<MyModel> GetAll();
        MyModel GetSingle(int id);
        MyModel Add(MyModel toAdd);
        MyModel Update(MyModel toUpdate);
        void Delete(MyModel toDelete);
        int Save();
    }
}