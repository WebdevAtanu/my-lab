using Dapper;
using DapperDemo.Data;
using DapperDemo.Models;
using System.Data;

namespace DapperDemo.Repositories
{
    public class UserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        // Get All
        public async Task<IEnumerable<User>> GetAll()
        {
            var query = "SELECT * FROM users";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<User>(query);
        }

        // Get By Id
        public async Task<User> GetById(int id)
        {
            var query = "SELECT * FROM users WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }

        // Create new user
        public async Task<int> Create(User user)
        {
            var query = "INSERT INTO users (Name, Email) VALUES (@Name, @Email)";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, user);
        }

        // Update
        public async Task<int> Update(User user)
        {
            var query = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, user);
        }

        // Delete
        public async Task<int> Delete(int id)
        {
            var query = "DELETE FROM Users WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id });
        }

        //// Calling SP Demo
        //public async Task<User> GetByIdSP(int id)
        //{
        //    using var connection = _context.CreateConnection();

        //    return await connection.QueryFirstOrDefaultAsync<User>(
        //        "GetUserById",
        //        new { Id = id },
        //        commandType: CommandType.StoredProcedure
        //    );
        //}

        //public async Task<int> InsertSP(User user)
        //{
        //    using var connection = _context.CreateConnection();

        //    return await connection.ExecuteAsync(
        //        "InsertUser",
        //        user,
        //        commandType: CommandType.StoredProcedure
        //    );
        //}
    }
}
