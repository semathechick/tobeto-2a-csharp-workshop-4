﻿using System.Reflection;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers;

public static class ServiceCollectionBusinessExtension
{
    // Extension method
    // Metodun ve barındığı class'ın static olması gerekiyor
    // İlk parametere genişleteceğimiz tip olmalı ve başında this keyword'ü olmalı.
    public static IServiceCollection AddBusinessServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddScoped<IBrandService, BrandManager>()
            .AddScoped<IBrandDal, EfBrandDal>()
            .AddScoped<BrandBusinessRules>();
        // Fluent
        // Singleton: Tek bir nesne oluşturur ve herkese onu verir.
        // Ek ödev diğer yöntemleri araştırınız.

        services
            .AddScoped<IModelService, ModelManager>()
            .AddScoped<IModelDal, EfModelDal>()
            .AddScoped<ModelBusinessRules>(); // Fluent


        services
            .AddScoped<IFuelService, FuelManager>()
            .AddScoped<IFuelDal, EfFuelDal>();

        services
            .AddScoped<ITransmissionService, TransmissionManager>()
            .AddScoped<ITransmissionDal, EfTransmissionDal>();

        services
            .AddScoped<ICarService, CarManager>()
            .AddScoped<ICarDal, EfCarDal>();

        services
            .AddScoped<ICustomerService, CustomerManager>()
            .AddScoped<ICustomerDal, EfCustomerDal>();

        services
            .AddScoped<IUserService, UserManager>()
            .AddScoped<ITokenHelper,JwtTokenHelper>()
            .AddScoped<IUserDal, EfUserDal>();

        services
            .AddScoped<IIndividualCustomerService, IndividualCustomerManager>()
            .AddScoped<IIndividualCustomerDal, EfIndividualCustomerDal>();

        services
            .AddScoped<IUserRoleService, UserRoleManager>()
            .AddScoped<IUserRoleDal, EfUserRoleDal>();

        services.AddScoped<IRoleDal, EfRoleDal>();  

        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper.Extensions.Microsoft.DependencyInjection NuGet Paketi
        // Reflection yöntemiyle Profile class'ını kalıtım alan tüm class'ları bulur ve AutoMapper'a ekler.

        services.AddDbContext<RentACarContext>( // Scoped 
            options => options.UseSqlServer(configuration.GetConnectionString("RentACarMSSQL22"))
        );

        return services;
    }
}
