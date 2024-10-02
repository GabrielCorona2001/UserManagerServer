using UserManager.DTO.User;
using UserManager.Models;

namespace UserManager.Services.User
{
    public interface IUserInterface
    {

        Task<ResponseModel<List<UserModel>>> GetAllUsers();
        Task<ResponseModel<UserModel>> GetUserByName (string name);

        Task<ResponseModel<List<UserModel>>> CreateUser(UserCreationDTO userCreationDTO);

        Task<ResponseModel<List<UserModel>>> UpdateUser(UserUpdateDTO userUpdateDTO);

        Task<ResponseModel<List<UserModel>>> DeleteUser(int idAutor);




    }
}
