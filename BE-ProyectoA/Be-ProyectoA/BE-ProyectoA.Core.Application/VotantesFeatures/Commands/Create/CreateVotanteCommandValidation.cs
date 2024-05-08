﻿using FluentValidation;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Create
{
    public class CreateVotanteCommandValidation : AbstractValidator<CreateVotanteCommand>
    {
        public CreateVotanteCommandValidation()
        {
            RuleFor(r => r.Nombre).NotEmpty().MaximumLength(50).WithName("nombre");
            RuleFor(r => r.Apellido).NotEmpty().MaximumLength(50).WithName("Apellido");
            RuleFor(r => r.NumeroTelefono).NotEmpty().MaximumLength(15).WithName("Numero de telefono");
            RuleFor(r => r.Sector).NotEmpty().MaximumLength(40).WithName("Sector");
            RuleFor(r => r.Provincia).NotEmpty().MaximumLength(20).WithName("Provincia");
            RuleFor(r => r.Cedula).MaximumLength(15).WithName("Cedula");
            RuleFor(r => r.Activo).NotEmpty();

        }
    }
}
