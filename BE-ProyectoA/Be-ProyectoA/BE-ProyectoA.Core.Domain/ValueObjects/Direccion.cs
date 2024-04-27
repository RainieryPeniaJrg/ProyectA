namespace BE_ProyectoA.Core.Domain.ValueObjects
{
    public partial record Direccion
    {
        public Direccion(string provincia, string sector, string casaElectoral)
        {
            Provincia = provincia;
            Sector = sector;
            CasaElectoral = casaElectoral;
        }
        public string Provincia { get; set; }
        public string Sector { get; set; }
        public string CasaElectoral { get; set; }

        public static Direccion? Create(string provincia, string sector, string casaElectoral)
        {
            if (string.IsNullOrEmpty(provincia) || string.IsNullOrEmpty(sector) || string.IsNullOrEmpty(casaElectoral))
            {
                return null;
            }

            return new Direccion(provincia, sector, casaElectoral);
        }

    }
}
