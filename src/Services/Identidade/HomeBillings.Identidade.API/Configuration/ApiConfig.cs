namespace HomeBillings.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }

        public static WebApplicationBuilder UseApiConfiguration(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                builder.UseSwaggerConfiguration(app);
            }

            app.UseHttpsRedirection();

            builder.UseIdentityConfiguration(app);

            app.MapControllers();

            app.Run();

            return builder;
        }
    }
}
