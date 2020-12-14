using Logic.Entities;

namespace Logic.Services
{
    public interface ILoginService
    {
      
        User Login(string username, string password);
        
    }
}