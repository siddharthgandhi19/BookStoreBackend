using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBackend
{
    public class Startup
    {
        private readonly string _secret; //  secret key Autorisation
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _secret = configuration.GetSection("JwtConfig").GetSection("secret").Value; // secret key Autorisation
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services )
        {

            services.AddControllers();
            services.AddTransient<IUserBL, UserBL>(); // registration
            services.AddTransient<IUserRL, UserRL>();
            services.AddTransient<IAdminBL, AdminBL>(); // admin
            services.AddTransient<IAdminRL, AdminRL>();
            services.AddTransient<IBookRL, BookRL>(); // Book
            services.AddTransient<IBookBL, BookBL>();
            services.AddTransient<ICartRL, CartRL>(); // Cart
            services.AddTransient<ICartBL, CartBL>();
            services.AddTransient<IWishListBL, WishListBL>(); // WishLis
            services.AddTransient<IWishListRL, WishListRL>();
            services.AddTransient<IFeedbackBL, FeedbackBL>(); // Feedback
            services.AddTransient<IFeedbackRL, FeedbackRL>();
            services.AddTransient<IAddressBL, AddressBL>(); // Address
            services.AddTransient<IAddressRL, AddressRL>();
            services.AddTransient<IOrderBL, OrderBL>(); // order
            services.AddTransient<IOrderRL, OrderRL>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookSTore",
                    //Description = "A simple example to Implement Swagger UI",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
                },
                   new string[]{}
                }

                });
            });
            services.AddAuthentication(options =>  // verify token through secret key
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.SaveToken = true;
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ClockSkew = TimeSpan.Zero,// It forces tokens to expire exactly at token expiration time instead of 5 minutes later
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)) // verify the generrated one token / secret key
                  };
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //Middle ware //  connect be to Fe
            app.UseCors(x => x  
               .AllowAnyOrigin() //connect to host
               .AllowAnyMethod() //
               .AllowAnyHeader()); // data communication
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });
        }
    }
}
