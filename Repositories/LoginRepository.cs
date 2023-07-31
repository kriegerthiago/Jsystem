using JucaSystem.Interfaces.IServices;
using JucaSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace JucaSystem.Repositories
{
    public class LoginRepository
    {
        private readonly Context _context;


        public LoginRepository(Context context)
        {
            _context = context;
        }



        public Login GetUsuarios(string login, string senha)
        {

            var usuario = _context.Logins.Where(p => p.DescricaoLogin.ToLower() == login && p.DescricaoSenha.ToLower() == senha && p.EhLoginAtivo == true).FirstOrDefault();

            return usuario;
        }
    }
}
