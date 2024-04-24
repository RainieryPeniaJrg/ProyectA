using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;


namespace BE_ProyectoA.Core.Application.Common.ValueObjectsValidators
{
    public class ValueObjectValidators
    {
        public static ErrorOr<Cedula> CedulaValidator(string cedulaParam)
        {
          
            if (Cedula.Create(cedulaParam) is not Cedula cedula)
            {
               
                return Error.Validation("La Cedula no es valida");
            }
            return cedula;
        }

        public static ErrorOr<NumeroTelefono> NumeroValidator(string numeroParams)
        {

            if (NumeroTelefono.Create(numeroParams) is not NumeroTelefono numeroTelefono)
            {

                return Error.Validation("Formato de numero de telfono no valido");
            }
            return numeroTelefono;
        }

        public static ErrorOr<Direccion> DireccionValidator(string provincia,string sector, int casaElectoral)
        {

            if (Direccion.Create(provincia,sector, casaElectoral) is not Direccion direccion)
            {

                return Error.Validation("La direccion no es valida");
            }
            return direccion;
        }

        public static ErrorOr<Unit> ValidarDatos(string cedulaParam, string numeroParams, string provincia, string sector,int casaElectoral)
        {
            var cedulaResult = CedulaValidator(cedulaParam);
            var numeroResult = NumeroValidator(numeroParams);
            var direccionResult = DireccionValidator(provincia, sector, casaElectoral);

            if (cedulaResult.IsError)
                return Error.Validation($"Cedula.Validation", $"{cedulaResult.Errors.FirstOrDefault()}");

            if (numeroResult.IsError)
                return Error.Validation($"numero.Validation", $"{numeroResult.Errors.FirstOrDefault()}");

            if (direccionResult.IsError)
                return Error.Validation($"direccion.Validation", $"{direccionResult.Errors.FirstOrDefault()}");

            return Unit.Value;

        }
    }
}
