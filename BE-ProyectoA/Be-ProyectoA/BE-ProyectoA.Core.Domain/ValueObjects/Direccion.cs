namespace BE_ProyectoA.Core.Domain.ValueObjects
{
    public partial record Direccion
    {
        public Direccion(string provincia, string sector, int casaElectoral)
        {
            Provincia = provincia;
            Sector = sector;
            CasaElectoral = casaElectoral;
        }
        public string Provincia { get; set; }
        public string Sector { get; set; }
        public int CasaElectoral { get; set; }

        public static Direccion? Create(string provincia, string sector, int casaElectoral)
        {
            if (string.IsNullOrEmpty(provincia) || string.IsNullOrEmpty(sector))
            {
                return null;
            }

            return new Direccion(provincia, sector, casaElectoral);
        }

    }
}
