using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;

namespace Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Repository Layer Registration
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<IFollowRepository, FollowRepository>();

        // Service Layer Registration
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ILikeService, LikeService>();
        services.AddScoped<IFollowService, FollowService>();

        return services;
    }
}