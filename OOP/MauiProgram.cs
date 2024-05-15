using Microsoft.Extensions.Logging;
using OOP.Entities;

namespace OOP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddScoped<IDbService, SQLiteService>();
            builder.Services.AddScoped<Agency>();
            builder.Services.AddScoped<AgencyEntry>();
            builder.Services.AddScoped<Admin>();

            builder.Services.AddScoped<FilterPage>();
            builder.Services.AddScoped<HotelInfo>();
            builder.Services.AddScoped<MainPage>();
            builder.Services.AddScoped<ReplyList>();
            builder.Services.AddScoped<ReviewList>();

            builder.Services.AddScoped<AddHotel>();
            builder.Services.AddScoped<AddReply>();
            builder.Services.AddScoped<AddRoom>();
            builder.Services.AddScoped<AddTour>();
            builder.Services.AddScoped<AdminProfile>();
            builder.Services.AddScoped<BookingList>();
            builder.Services.AddScoped<ClientsList>();
            builder.Services.AddScoped<EditHotel>();
            builder.Services.AddScoped<EditRoom>();
            builder.Services.AddScoped<EditTour>();
            builder.Services.AddScoped<HotelList>();
            builder.Services.AddScoped<ToursList>();

            builder.Services.AddScoped<AddReview>();
            builder.Services.AddScoped<ClientBookings>();
            builder.Services.AddScoped<ClientChangeName>();
            builder.Services.AddScoped<ClientChangePassword>();
            builder.Services.AddScoped<ClientProfile>();
            builder.Services.AddScoped<Settings>();

            builder.Services.AddScoped<EntryPage>();
            builder.Services.AddScoped<Profile>();
            builder.Services.AddScoped<Registration>();

            builder.Services.AddScoped<Contacts>();
            builder.Services.AddScoped<Favorites>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
