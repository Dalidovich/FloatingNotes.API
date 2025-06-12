using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.BLL.Services;
using FloatingNotes.API.DAL.Repositories.Implements;
using FloatingNotes.API.DAL.Repositories.Interafaces;
using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Midlaware;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace FloatingNotes.API
{
    public static class DIManger
    {
        public static void AddRepositores(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<IFloatingNoteRepositories, FloatingNoteRepositories>();
            webApplicationBuilder.Services.AddScoped<IConnectionFloatingNoteRepositories, ConnectionFloatingNoteRepositories>();
        }

        public static void AddServices(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<IFloatingNoteService, FloatingNoteService>();
            webApplicationBuilder.Services.AddScoped<IConnectionFloatingNoteService, ConnectionFloatingNoteService>();
            webApplicationBuilder.Services.AddScoped<IODataService, ODataService>();
        }

        public static void AddODataProperty(this WebApplicationBuilder webApplicationBuilder)
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<FloatingNote>("FloatingNote");
            odataBuilder.EntitySet<ConnectionFloatingNote>("ConnectionFloatingNote");

            webApplicationBuilder.Services.AddControllers().AddOData(opt =>
            {
                opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5000);
                opt.TimeZone = TimeZoneInfo.Utc;
            });
        }

        public static void AddMiddleware(this WebApplication webApplication)
        {
            webApplication.UseMiddleware<ExceptionHandlingMiddleware>();
            webApplication.UseMiddleware<CheckDBMiddleware>();
        }
    }
}
