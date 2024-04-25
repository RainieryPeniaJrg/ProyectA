﻿using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commom
{
    public record DirigenteResponse
       (
           Guid Id,
           string NombreCompleto,
           CantidadVotos CantidadVotantes,
           Cedula Cedula,
           NumeroTelefono NumeroTelefono,
           DireccionResponseDirigente Direccion,
           CoordinadorResponse Coordinador,
           bool Activo
       );
    public record DireccionResponseDirigente

       (string Provincia,
         string Sector,
         int CasaElectoral
       );

    public record CoordinadorResponse
     (
         Guid Id,
         string NombreCompleto,
         CantidadVotos CantidadVotantes,
         Cedula Cedula,
         NumeroTelefono NumeroTelefono,

         bool Activo
     );






}
