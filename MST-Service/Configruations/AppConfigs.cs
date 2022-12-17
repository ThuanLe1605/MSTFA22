using Microsoft.OpenApi.Models;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;

namespace MST_Service.Configruations
{
    public static class AppConfigs
    {
        public static void AddDependenceInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILectureService, LectureService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IDemandService, DemandService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ISyllabusService, SyllabusService>();
            services.AddScoped<IPromotionService, PromotionService>();
            

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MST Service Interface", Description = "APIs for MST", Version = "v1" });
                c.DescribeAllParametersInCamelCase();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                 });
            });
        }

    }
}
