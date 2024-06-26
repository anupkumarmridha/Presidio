using DoctorAppoinmentAPI.Contexts;
using DoctorAppoinmentAPI.Repositories.Classes;
using DoctorAppoinmentAPI.Repositories.Interfaces;
using DoctorAppoinmentAPI.Services.Classes;
using DoctorAppoinmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppoinmentAPI
{
    public class Program
    {
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoctorAppoinmentDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("defaultConnection")));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ITimeSlotService, TimeSlotService>();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            AddDbContext(services, configuration);

            RegisterRepositories(services);
            RegisterServices(services);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        
    }
}
