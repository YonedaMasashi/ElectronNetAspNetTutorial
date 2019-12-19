using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ElectronNET.API; // �C��
using ElectronNetAspNetTutorial.Data; // �C��
using Microsoft.EntityFrameworkCore; // �C��

namespace ElectronNetAspNetTutorial {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();

            // �C��
            services.AddDbContext<MvcMovieContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcMovieContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    //--- Home �R���g���[��(�v���W�F�N�g�쐬���ɐ��������R�[�h) ---
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    //--- HelloWorld �R���g���[�� ---
                    //pattern: "{controller=HelloWorld}/{action=Index}/{id?}");
                    pattern: "{controller=HelloWorld}/{action=Welcome}/{name=Rick}/{numtimes=4}");
            });

            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync()); // �C��
        }
    }
}
