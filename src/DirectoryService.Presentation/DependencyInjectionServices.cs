using DirectoryService.Application;

namespace DirectoryService.Presentation;

public static class DependencyInjectionServices
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services.AddApplication();
        services.AddControllers();
        services.AddOpenApi();
        return services;
    }
}