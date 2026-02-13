using ClinicPOS.Application.Model.Request;
using ClinicPOS.Application.Model.Response;
using ClinicPOS.Domain.Entity;
using ClinicPOS.Domain.Helper;
using ClinicPOS.Infrastructure.Repository;

namespace ClinicPOS.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenHelper _jwt;

        public UserService(IUserRepository userRepository, JwtTokenHelper jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }

        public async Task<LoginDTO> LoginAsync(string username, string password)
        {
            var returnLogin = new LoginDTO();
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null || !user.IsActive || !PasswordHashHelper.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            else
            {
                var role = await _userRepository.GetRoleById(user.RoleId);
                returnLogin = new LoginDTO
                {
                    Username = user.Username.Trim(),
                    Role = role.Name.Trim(),
                    Token = _jwt.GenerateToken(user, role)
                };
            }
            return returnLogin;
        }

        public async Task CreateUserAsync(CreateUserRequest request)
        {
            if (await _userRepository.UsernameExistsAsync(request.Username))
                throw new InvalidOperationException("Username already exists");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = PasswordHashHelper.Hash(request.Password),
                Firstname = request.FirstName,
                Lastname = request.LastName,
                PhoneNumber = request.TelNo,
                RoleId = new Guid("126203F9-7531-4CF6-9231-9BD72DFC5FE7"),
                IsActive = true,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException();

            user.Username = request.Username;
            user.Firstname = request.FirstName;
            user.Lastname = request.LastName;
            user.PhoneNumber = request.TelNo;
            user.IsActive = request.IsActive;
            user.UpdateDate = DateTime.Now;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<List<UserDTO>> GetAllUserAsync()
        {
            var returnUserDto = new List<UserDTO>();
            var users = await _userRepository.GetAllAsync();
            if (users.Count() > 0)
            {
                foreach (var u in users)
                {
                    var role = await _userRepository.GetRoleById(u.RoleId);
                    returnUserDto.Add(new UserDTO {
                        Id = u.Id,
                        Username = u.Username.Trim(),
                        FirstName = u.Firstname.Trim(),
                        LastName = u.Lastname.Trim(),
                        Role = role.Name,
                        TelNo = u.PhoneNumber,
                        IsActive = u.IsActive
                    });
                }
            }
            return returnUserDto;
        }
    }
}
