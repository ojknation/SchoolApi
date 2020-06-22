using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudyApi.ClientModels;
using StudyApi.Helpers;
using StudyApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StudyApi.Models;
using System.Collections.Generic;

namespace StudyApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IAuthService _authService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IAuthService authService,
            IMapper mapper,
            IOptions<AppSettings> appSettings) 
        {
            _authService = authService;
            _mapper = mapper;
            _appSettings = appSettings.Value; 
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthModel model) {
            
            var user = _authService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect"});

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
               Subject = new ClaimsIdentity(new Claim[] 
               {
                   new Claim(ClaimTypes.Name, user.UserID.ToString())
               }),
               Expires = DateTime.UtcNow.AddDays(7),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                UserID = user.UserID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Department = user.Department,
                Token = tokenString
            });
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model){

            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                _authService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            } 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _authService.GetAll();
            var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _authService.GetById(id);
            var model = _mapper.Map<UserModel>(user);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateUserModel model)
        {
            // map model to entity and set id
            var user = _mapper.Map<User>(model);
            user.UserID = id;

            try
            {
                // update user 
                _authService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authService.Delete(id);
            return Ok();
        }
        
    }
}