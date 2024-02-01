using Hotel.Models;
using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.DependencyInjection; // Add this namespace for CreateScope and GetRequiredService
using Microsoft.Extensions.Logging;
using Hotel.Data;

namespace Hotel.Data
{
    public static class TasksInitializer
    {
        public static void Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<ReservationContext>();
                try
                {
                    context.Database.EnsureCreated();

                    var tasks = context.Guests.FirstOrDefault();
                    if (tasks == null)
                    {
                        context.Guests.AddRange(
                           new Guest { Name = "Carson", Surename = "Alexander", Email = "sdaasdsa@gmail.com", Phone = "3214123421" },
                           new Guest { Name = "MArcin", Surename = "Wodder", Email = "sraken@gmail.com", Phone = "3214123421" }
                         );
                        context.SaveChanges();

                        context.Services.AddRange(
                            new Service { Name = "masaz", Description = "Lamanie", Rating = 5 },
               new Service { Name = "sprzatanie", Description = "Dodatkowe sprzatanie", Rating = 3 }
                            );
                        context.SaveChanges();

                        context.Rooms.AddRange(
                            new Room { Description = "smierdzi", BedsCount = 3, Availability = true },
            new Room { Description = "ladny", BedsCount = 2, Availability = true },
            new Room { Description = "ladny", BedsCount = 2, Availability = false }
                            );
                        context.SaveChanges();
                        context.Reservations.AddRange(

            new Reservation { RoomID = 2, UserID = 1, ServiceID = 1, ReservationDescription = "nie budzic przed 10", Startofdate = new DateTime(2009, 12, 1), Endofdate = new DateTime(2010, 05, 01) },
            new Reservation { RoomID = 3, UserID = 2, ServiceID = 2, ReservationDescription = "nie dokarmiac", Startofdate = new DateTime(2009, 12, 1), Endofdate = new DateTime(2010, 05, 01) }
                            );
                    }

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }


        }
    }
}

