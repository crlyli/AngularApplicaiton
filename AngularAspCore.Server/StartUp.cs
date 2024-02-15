//using AngularAspCore.Database.Repositories.DbContextData;
//using Microsoft.EntityFrameworkCore;

//namespace AngularAspCore.Server
//{
//    public class StartUp
//    {
//        public StartUp(IConfiguration fConfiguration) 
//        {
//            Configuration = fConfiguration;
//        }
//        public void CongigureServices(IServiceCollection services)
//        {

//        }
//        public void Configure(WebApplication app, IWebHostEnvironment env)
//        {
//            if(!app.Environment.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseDefaultFiles();
//                app.UseCors(options =>
//                {
//                    options.AllowAnyHeader();
//                    options.AllowAnyOrigin();
//                    options.AllowAnyMethod();
//                });

//                app.UseStaticFiles();

//                // Configure the HTTP request pipeline.
//                if (app.Environment.IsDevelopment())
//                {
//                    app.UseSwagger();
//                    app.UseSwaggerUI();
//                }

//                app.UseHttpsRedirection();

//                app.UseAuthorization();

//                app.MapControllers();

//                app.MapFallbackToFile("/index.html");

//                app.Run();
//            }
//        }

//        public CongitureMySqlContext()
//        {
//            // Add services to the container.
//            var connectionString = builder.Configuration.GetConnectionString("BooksConnectionString");

//            // Replace with your server version and type.
//            // Use 'MariaDbServerVersion' for MariaDB.
//            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
//            // For common usages, see pull request #1233.
//            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));

//            // Replace 'YourDbContext' with the name of your own DbContext derived class.
//            builder.Services.AddDbContext<ApplicationDbContext>(
//                dbContextOptions => dbContextOptions
//                    .UseMySql(connectionString, serverVersion)
//                    // The following three options help with debugging, but should
//                    // be changed or removed for production.
//                    .LogTo(Console.WriteLine, LogLevel.Information)
//                    .EnableSensitiveDataLogging()
//                    .EnableDetailedErrors()
//            );
//        }
//        public IConfiguration Configuration { get; }
//    }
//}
