using BE_ProyectoA.Core.Application.Common.Enums;
using BE_ProyectoA.Core.Application.Data;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.Common.CreadorCantidadVotantes
{
    public class CrearVotantes(ICoordinadorGeneralRepository coordinadorGeneralRepository,
        ISubCoordinadorRepository subcoordinadorGeneralRepository,
        IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository,
        IDirectoresRepository directoresRepository, IUnitOfWork unitOfWork) 

    {



        //public async void CalcularVotos(List<Votante> votantes, Guid miembroId, TipoMiembro tipoMiembro, CancellationToken cancellationToken)
        //{
        //    int votos;
        //    Guid memberId = Guid.Parse(miembroId.ToString());

        //    switch (tipoMiembro)
        //    {
        //        case TipoMiembro.CoordinadorGeneral:
        //            var coordinadorGeneralId = new CoordinadoresGeneralesId(memberId);
        //            if (await coordinadorGeneralRepository.ExistsAsync (coordinadorGeneralId, cancellationToken))
        //            {
        //                votos = votantes.Count(v => v.CoordinadorGeneralId == coordinadorGeneralId);
        //                if (votos == 0)
        //                {
        //                    votos++;
        //                }

        //                var votosTotales = CantidadVotos.Create(votos);
        //                var coordinadorDto = await coordinadorGeneralRepository.GetByIdAsync(coordinadorGeneralId, cancellationToken);

        //                if (coordinadorDto != null)
        //                {
        //                    var coordinador = CoordinadoresGenerales.UpdateWithOutRelationShip(coordinadorGeneralId, coordinadorDto.Nombre, coordinadorDto.Apellido, coordinadorDto.Cedula, coordinadorDto.NumeroTelefono, coordinadorDto.Direccion, coordinadorDto.Activo, votosTotales);

        //                    coordinadorGeneralRepository.Update(coordinador!);
        //                    await unitOfWork.SaveChangesAsync(cancellationToken);
        //                }
        //            }
        //            break;


        //    }
        //}
    }
}
