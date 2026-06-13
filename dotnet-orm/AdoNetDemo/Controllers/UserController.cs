using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using AdoNetDemo.Data;
using AdoNetDemo.Models;
using Microsoft.Data.SqlClient;

namespace AdoNetDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBHelper _db;

        public UserController(DBHelper db)
        {
            _db = db;
        }

        // Get All Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = new List<User>();

            using var conn = _db.GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand("SELECT * FROM Users", conn);
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                users.Add(new User
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }

            return Ok(users);
        }

        // Insert a new user
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            using var conn = _db.GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(
                "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", conn);

            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            await cmd.ExecuteNonQueryAsync();

            return Ok("User Added");
        }

        // Get User by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            using var conn = _db.GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                var user = new User
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                };

                return Ok(user);
            }

            return NotFound("User not found");
        }

        // Update User by Id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            using var conn = _db.GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(
                "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            var rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
                return NotFound("User not found");

            return Ok("User updated successfully");
        }

        // Delete User by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            using var conn = _db.GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(
                "DELETE FROM Users WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);

            var rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
                return NotFound("User not found");

            return Ok("User deleted successfully");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(int id, [FromBody] User user)
        {
            using var conn = _db.GetConnection();
            await conn.OpenAsync();

            var updates = new List<string>();
            var cmd = new SqlCommand();
            cmd.Connection = conn;

            // Check fields dynamically
            if (!string.IsNullOrEmpty(user.Name))
            {
                updates.Add("Name = @Name");
                cmd.Parameters.AddWithValue("@Name", user.Name);
            }

            if (!string.IsNullOrEmpty(user.Email))
            {
                updates.Add("Email = @Email");
                cmd.Parameters.AddWithValue("@Email", user.Email);
            }

            // Nothing to update
            if (updates.Count == 0)
                return BadRequest("No fields to update");

            // Build query dynamically
            var query = $"UPDATE Users SET {string.Join(", ", updates)} WHERE Id = @Id";
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@Id", id);

            var rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
                return NotFound("User not found");

            return Ok("User partially updated");
        }
    }
}