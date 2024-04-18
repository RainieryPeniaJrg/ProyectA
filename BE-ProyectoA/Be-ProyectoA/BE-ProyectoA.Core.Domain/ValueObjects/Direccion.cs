namespace BE_ProyectoA.Core.Domain.ValueObjects
{
    public partial record Direccion
    {
        public Direccion(string provincia, string sector)
        {
            Provincia = provincia;
            Sector = sector;
        }
        public string Provincia { get; set; }
        public string Sector { get; set; }

        public static Direccion? Create(string provincia, string sector)
        {
            if (string.IsNullOrEmpty(provincia) || string.IsNullOrEmpty(sector))
            {
                return null;
            }

            return new Direccion(provincia, sector);
        }

    }
}
