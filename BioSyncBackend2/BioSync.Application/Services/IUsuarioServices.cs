
namespace BioSync.Application.Services
{
    public interface IUsuarioServices
    {
        bool Ativo { get; set; }
        string CPF { get; set; }
        DateTime DataCadastro { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        string Nome { get; set; }

        void Ativar();
        void Ativar(bool Ativo);
        void AtualizarInformacoes(string nome, string email);
        void Desativar();
        void Desativar(bool Ativo);
    }
}