namespace JucaSystem.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string DescricaoLogin { get; set; }
        public string DescricaoSenha { get; set; }
        public bool EhLoginAtivo { get; set; }
    }
}
