using Kiss.DataAccess.Interfaces;

namespace Kiss.DataAccess
{
    public class KissUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;

        public KissUnitOfWorkFactory(string connectionString)
        {
            _connectionString = connectionString;
        }


        public IUnitOfWork Create()
        {
            return new KissUnitOfWork(_connectionString);
        }
    }
}
