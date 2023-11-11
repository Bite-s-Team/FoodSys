namespace FoodSys.Domain.Interface.Account
{
    public interface IAuth
    {
        Task<bool> Login(String email, String password);
        Task<bool> UserExist(String email);
        public String GenToken(Guid id, String email, String name);
    }
}
