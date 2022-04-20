using System.Threading.Tasks;
using DB.Models;

namespace Service.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}