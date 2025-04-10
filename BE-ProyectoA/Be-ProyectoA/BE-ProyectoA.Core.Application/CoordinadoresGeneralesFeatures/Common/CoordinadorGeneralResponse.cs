﻿using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Common
{
   
    public record CoordinadorGeneralResponse
       (
           Guid Id,
           string NombreCompleto,
           CantidadVotos CantidadVotantes,
           Cedula Cedula,
           NumeroTelefono NumeroTelefono,
           DireccionResponseCoordinador Direccion,
           bool Activo
       );
    public record DireccionResponseCoordinador

       (string Provincia,
         string Sector,
         string CasaElectoral
       );
}
