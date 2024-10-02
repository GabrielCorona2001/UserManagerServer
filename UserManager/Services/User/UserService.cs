using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using UserManager.Data;
using UserManager.DTO.User;
using UserManager.Models;

namespace UserManager.Services.User
{
    public class UserService : IUserInterface
    {
        private readonly AppDbContext _context;


        public UserService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
        {
            
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            try
            {
                var users = await _context.Users.ToListAsync();
                response.Data = users;
                response.Message = "Todos os usuários foram listados";

            }
            catch (Exception e) {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }

            return response;

        }

        public async Task<ResponseModel<UserModel>> GetUserByName(string name)
        { 
            ResponseModel<UserModel> response  = new ResponseModel<UserModel>();
            try
            {
                var User = await _context.Users.FirstOrDefaultAsync(x => x.Name == name);

                if (User == null) {
                
                response.Message = "Nenhum Registro Localizado";
                    return response;
                }

                response.Data = User;
                response.Message = "Autor Localizado";
                return response;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }

        }


        public async Task<ResponseModel<List<UserModel>>> CreateUser(UserCreationDTO userCreationDTO)
        {

            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = new UserModel()
                {
                    Name = userCreationDTO.Name,
                    Email = userCreationDTO.Email,
                    Password = userCreationDTO.Password,
                    Register = userCreationDTO.Register
                };
                _context.Add(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "Usuario criado com sucesso";
                return response;
                
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<List<UserModel>>> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == userUpdateDTO.Id);
                if (user == null)
                {
                    response.Message = "Nenhum Usuário encontrado";
                    return response;
                }
                user.Name = userUpdateDTO.Name;
                user.Register = userUpdateDTO.Register;
                user.Password = userUpdateDTO.Password;
                user.Email = userUpdateDTO.Email;

                _context.Update(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "Usuário editado com sucesso";
                return response;
            }
            catch (Exception e) {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> DeleteUser(int idAutor)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == idAutor);

                if (user == null)
                {
                    response.Message = "Nenhum Usuário encontrado";
                    return response;
                }

                _context.Remove(user);

                await _context.SaveChangesAsync();
                response.Data = await _context.Users.ToListAsync();
                response.Message = "Usuário removido com sucesso";

                return response;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }

        }


    }
}
