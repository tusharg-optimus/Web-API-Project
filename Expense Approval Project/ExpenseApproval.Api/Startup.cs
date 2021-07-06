using ExpenseApproval.DataAccess;
using ExpenseApproval.DataAccess.Repository.Implementations;
using ExpenseApproval.DataAccess.Repository.Interfaces;
using ExpenseApproval.Service.Implementations;
using ExpenseApproval.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpenseApproval", Version = "v1" });
            });

            //Adding database connection
            string cs = "server=OPTIMUS-12; database=ExpenseApproval; trusted_connection=true; User ID=tushar; Password=Kanikagupta@12";
            services.AddDbContext<ExpenseContext>(options => options.UseSqlServer(cs));

            //Registering Dependencies with their lifetimes
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IExpenseRequestRepository, ExpenseRequestRepository>();

            services.AddScoped<IExpenseRequestService, ExpenseRequestService>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IApprovalRepository, ApprovalRepository>();

            services.AddScoped<IApprovalService, ApprovalService>();

            //Registering AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExpenseApproval.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
