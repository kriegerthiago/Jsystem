using Juca.Application.Dto;
using Juca.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JucaSystemWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        #region Métodos

        [HttpPost]
        [AllowAnonymous]
        public dynamic Autenticar([FromBody] AutenticarDto model)
        {
            try
            {
                var token = _loginService.AutenticarLogin(model);

                return token;
            }
            catch (System.Exception)
            {

                throw;
            }
        }



        #endregion
    }
}
