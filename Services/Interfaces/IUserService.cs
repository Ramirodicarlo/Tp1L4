using ErrorOr;
using System.Collections.Generic;
using System.Threading.Tasks;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TODOLIST.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User? GetUserById(int userId);
        User CreateUser(User user);
        User? UpdateUser(int userId, User updatedUser);
        bool DeleteUser(int userId);
        BaseResponse ValidateUser(string email);

        User? GetUserByEmail(string email);

    }
}
