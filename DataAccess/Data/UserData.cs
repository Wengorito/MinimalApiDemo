using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>("spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id) =>
        (await _db.LoadData<UserModel, dynamic>("spUser_Get", new { Id = id }))
            .FirstOrDefault();

    public Task InsertUser(UserModel user) =>
        _db.SaveData("spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) =>
        _db.SaveData("spUser_Update", user);

    public Task DeleteUser(int id) =>
        _db.SaveData("spUser_Delete", new { Id = id });
}
