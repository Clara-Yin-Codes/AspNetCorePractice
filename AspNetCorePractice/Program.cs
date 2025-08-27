using AspNetCorePractice.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCorePractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint(); // 自動更新資料庫
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // 發生錯誤時，導向 /Home/Error 頁面
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); // 強制使用 https
            }

            // http 要求管線
            app.UseHttpsRedirection(); // 瀏覽http時，會自動轉址到https
            app.UseStaticFiles(); // 指定存放靜態檔案的資料夾 wwwroot
            app.UseWebSockets();
            app.UseRouting(); // 啟用路由功能 (URL Routing)
            app.UseAuthorization(); // 啟用授權功能 (Authenticate -> authorize)

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
