using DataAccess;
using Domain.Models.Boards;
using Domain.Models.Teams;
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
            // services.AddSingleton<IDataContext, TestDataContext>();
            //Если нужно особым образом инициализировать реализацию, то можно сделать это так
            //В данном случае будет использована БД в памяти
            services.AddSingleton<IDataContext, DatabaseDataContext>(_ => new DatabaseDataContext(true));
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
                    dataContext?.AddBoard(new Board
                    {
                        Title = "Test Board",
                        Description = "Learning domain models",
                        Owner = new User {Name = "Calimber"},
                    });
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