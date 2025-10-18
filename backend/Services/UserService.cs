using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using backend.DTOs;
using backend.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Models;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers(PaginationDTO pagination)
        {
            var users = await userRepository.GetAllAsync();
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<AuthenticationResponseDTO> Register(UserCredentialsDTO userCredentials)
        {
            var user = new ApplicationUser
            {
                Email = userCredentials.Email,
                UserName = userCredentials.Email,
                FirstName = userCredentials.FirstName,
                LastName = userCredentials.LastName
            };

            var result = await userRepository.CreateAsync(user, userCredentials.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return await BuildToken(user);
        }

        public async Task<AuthenticationResponseDTO?> Login(UserLoginDTO userCredentials)
            {
                var user = await userRepository.GetByEmailAsync(userCredentials.Email);
                if (user is null) return null;

                // Use UserManager to check the password (handles lockout, security stamps, validators)
                var passwordValid = await userRepository.CheckPasswordAsync(user, userCredentials.Password);
                if (!passwordValid) return null;

                return await BuildToken(user);
            }


        public async Task MakeAdmin(string email)
        {
            var user = await userRepository.GetByEmailAsync(email);
            if (user is null) throw new Exception("User not found");

            await userRepository.AddClaimAsync(user, new Claim("isadmin", "true"));
        }

        public async Task RemoveAdmin(string email)
        {
            var user = await userRepository.GetByEmailAsync(email);
            if (user is null) throw new Exception("User not found");

            await userRepository.RemoveClaimAsync(user, new Claim("isadmin", "true"));
        }

        private async Task<AuthenticationResponseDTO> BuildToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("email", user.Email!),
                new Claim("whatever", "any value")
            };

            var claimsDB = await userRepository.GetClaimsAsync(user);
            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtkey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(60);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new AuthenticationResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
