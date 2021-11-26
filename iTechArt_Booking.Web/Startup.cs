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

              //  .AddDefaultTokenProviders();


            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IHotelRepository, EFHotelRepository>();
            services.AddTransient<IBookingRepository, EFBookingRepository>();
            services.AddTransient<IRoomRepository, EFRoomRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BookingDBContext>(); 
                  ///.AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iTechArt_Booking.Web", Version = "v1" });
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

         

            app.UseEndpoints(endpoints =>              
            {
                endpoints.MapControllers();
            });
        }
    }
}
