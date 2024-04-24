﻿using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Update
{
    public record UpdateSubCoordinadorCommand
       
        (
        Guid Id,
        string Nombre,
     string Apellido,
     int CantidadVotantes,
     string Cedula,
     bool Activo,
     string Provincia,
     string Sector,
     int CasaElectoral,
     string NumeroTelefono,
     Guid CoordinadorsGeneralesId

        ) :
        IRequest<ErrorOr<Unit>>;
    
}
