using Microsoft.Extensions.Configuration;

namespace Data.Repositories
{
    public abstract class BaseRepository
    {
        public BaseRepository(IConfiguration configuration)
        {
            ConnetionString = configuration.GetConnectionString("ConnectionString");
        }

        public string ConnetionString { get; set; }


    }
}
