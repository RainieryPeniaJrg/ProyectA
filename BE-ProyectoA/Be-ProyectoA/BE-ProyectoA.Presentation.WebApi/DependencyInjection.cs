namespace BE_ProyectoA.Presentation.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationn(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
