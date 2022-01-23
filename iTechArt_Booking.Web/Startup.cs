using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using iTechArt_Booking.Infastructure.Repositories.EFRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using iTechArt_Booking.Application.Services;


namespace iTechArt_Booking.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

          
            services.AddControllers();

            services.AddDbContext<BookingDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<UserService>();

            services.AddTransient<IHotelRepository, EFHotelRepository>();
            services.AddTransient<HotelService>();

            services.AddTransient<IBookingRepository, EFBookingRepository>();
            services.AddTransient<BookingService>();

            services.AddTransient<IRoomRepository, EFRoomRepository>();
            services.AddTransient<RoomService>();

            services.AddTransient<IReviewRepository, EFReviewRepository>();
            services.AddTransient<ReviewService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Identity:JwtKey"]))
                    };
                });

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BookingDBContext>()
                .AddDefaultTokenProviders();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore  );


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iTechArt_Booking.Web", Version = "v1" });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = @"JWT Authorization header using the Bearer scheme. 
                                      Enter 'Bearer' [space] and then your token in the text input below.
                                      Example: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
                        new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)     
        {       //middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "iTechArt_Booking.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>              
            {
                endpoints.MapControllers();
            });
        }
    }
}
