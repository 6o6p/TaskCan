using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Front.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Front
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Добавляем в DI контейнер реализацию интерфейса
            services.AddSingleton<IDataContext, TestDataContext>();
            //services.AddSingleton<IDataContext, DatabaseDataContext>();
        }

        // В этом методе выстраивается конвейер обработки запросов на сервер
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Если сервер запущен в режиме разработки, то выводим красивое сообщение об ошибке
            //со стек трейсом
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //Настраиваем обработку запроса для корня сайта (https://localhost:5001/)
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //Получаем DataContext из DI. Затем достаем объект и сериализуем его в JSON 
                    var dataContext = app.ApplicationServices.GetService<IDataContext>();
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(
                        dataContext?.GetBoard(),
                        Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        })
                    );
                });
            });
        }
    }
}