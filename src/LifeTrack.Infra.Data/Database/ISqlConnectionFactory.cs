using System.Data;

namespace LifeTrack.Infra.Data.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
