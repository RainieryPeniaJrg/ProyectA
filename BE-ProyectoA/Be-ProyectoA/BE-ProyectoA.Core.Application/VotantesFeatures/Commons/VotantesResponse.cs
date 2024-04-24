using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commons
{
    public record VotantesResponse(
            Guid Id,
            string NombreCompleto,
            Cedula Cedula,
            NumeroTelefono NumeroTelefono,
            DireccionResponse Direccion,
            bool Activo
        );
    public record DireccionResponse

      (string Provincia,
        string Sector

      );


}
