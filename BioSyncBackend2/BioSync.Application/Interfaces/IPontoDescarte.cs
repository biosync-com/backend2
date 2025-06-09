using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IPontoDescarte
    {
        string Name { get; }
        string CNPJ { get; }
        string Endereco { get; }
        bool IsActive { get; }
        void Activate();
        void Deactivate();
        void UpdateInformation(DTOs.Response.PontoDescarteResponseDTO.PontoDescarteUpdateDTO updateDto);
        void ChangeEndereco(string newEndereco);
        bool ValidateEndereco(string Endereco);
        void AddMaterial(string materialName);
        void RemoveMaterial(string materialName);
    }
}
