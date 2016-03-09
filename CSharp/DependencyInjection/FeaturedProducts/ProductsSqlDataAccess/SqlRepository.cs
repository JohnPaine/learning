using System.Linq;
using Ninject;
using ProductsDomain;

namespace ProductsSqlDataAccess
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public ProductDataClassesDataContext Db { get; set; }
    }
}