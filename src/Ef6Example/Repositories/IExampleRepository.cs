using Ef6Example.Models;
using OfferingSolutions.UoW.Structure.RepositoryContext;

namespace Ef6Example.Repositories
{
    public interface IExampleRepository : IRepositoryContext<MyModel>
    {
    }
}