using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ef6Example.Models;
using OfferingSolutions.UoW.Structure.RepositoryContext;

namespace Ef6Example.Repositories
{
    public class ExampleRepository : RepositoryContextImpl<MyModel>, IExampleRepository
    {
        public ExampleRepository(MyEf6EntityFrameworkContext databaseContext) : base(databaseContext)
        {
        }
    }
}
