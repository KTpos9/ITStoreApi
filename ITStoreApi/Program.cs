using Microsoft.AspNetCore.Authentication.Certificate;

namespace ITStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //the WebApplication.CreateBuilder method calls UseKestrel internally. See appsettings.json for configurations.
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<SqlDataAccess>();
            //builder.Services
            //    .AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
            //    .AddCertificate(options =>
            //    {
            //        options.AllowedCertificateTypes = CertificateTypes.All;
            //    });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod().AllowAnyOrigin());

            app.MapControllers();

            app.Run();
        }
    }
}