#nullable disable
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetinhoApi.Context;
using ProjetinhoApi.Models;
using ProjetinhoApi.Services.Interfaces;

namespace ProjetinhoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersService userService;
        private readonly ITokenService tokenService;

        public AuthenticationController(IUsersService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login request)
        {
            try
            {
                // Execute the login service
                var user = await this.userService.Login(request.Username, request.Password);

                // Generate security token
                var token = this.tokenService.CreateJwtToken(user);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(User request)
        {
            try
            {
                await this.userService.CreateUser(request, request.Password);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
