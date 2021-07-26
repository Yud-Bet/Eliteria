using Eliteria.API.Models;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface IParamesterProvider
    {
        Task<int> ConfigureParamester(string conn, OtherParameter item);

    }
}
