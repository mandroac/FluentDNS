using AutoMapper;
using FDNS.Common.Constants;
using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Models;
using FDNS.Services.Abstractions.Base;
using FDNS.Services.Abstractions.Security;
using Microsoft.AspNetCore.Identity;

namespace FDNS.Services.Base
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<User> userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ServiceResult<(UserDTO user, string token)>> RegisterAsync(AuthUserDTO authUserDTO)
        {
            var user = _mapper.Map<User>(authUserDTO);
            var result = await _userManager.CreateAsync(user, authUserDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
                var userDto = _mapper.Map<UserDTO>(user);
                return new ServiceResult<(UserDTO, string)>((userDto, _tokenService.GenerateToken(userDto, UserRoles.User)));
            }
            else
            {
                return new ServiceResult<(UserDTO, string)>(new List<string>(result.Errors.Select(e => e.Description))) ;
            }
        }

        public async Task<ServiceResult<(UserDTO user, string token)>> LoginAsync(AuthUserDTO authUserDTO)
        {
            User user;
            if (authUserDTO.Email != null)
            {
                user = await _userManager.FindByEmailAsync(authUserDTO.Email);
            }
            else
            {
                user = await _userManager.FindByNameAsync(authUserDTO.UserName);
            } 

            if (user != null && await _userManager.CheckPasswordAsync(user, authUserDTO.Password))
            {
                var userDto = _mapper.Map<UserDTO>(user);
                return new ServiceResult<(UserDTO, string)>((userDto, _tokenService.GenerateToken(userDto, UserRoles.User)));
            }
            else
            {
                return new ServiceResult<(UserDTO, string)>(new List<string>()
                {
                    "Provided login credentials are not valid"
                });
            }
        }

        public async Task<ServiceResult<(UserDTO user, string token)>> GetCurrentUserAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                return new ServiceResult<(UserDTO, string)>((userDto, _tokenService.GenerateToken(userDto, UserRoles.User)));
            }
            else
            {
                return new ServiceResult<(UserDTO, string)>(new List<string>()
                {
                    "User was not found"
                });
            }
        }
    }
}
