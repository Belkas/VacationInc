using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<decimal> GetExchangeRate(string currency);
    }
}
