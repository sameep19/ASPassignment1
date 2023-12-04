using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace swimming.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCSwimmingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVCSwimmingContext>>()))
            {
                // Look for any movies.
                if (context.Swimming.Any())
                {
                    return;   // DB has been seeded
                }

                context.Swimming.AddRange(
                    new Swimming
                    {
                        PoolName = "SCC Shortcourse Pool",
                        PoolLength = "25 Meters",
                        PoolLocation = "Windsor",
                        PoolCapacity= "50 People",
                        PoolTimings="7AM - 11PM",
                        PoolDays=" Monday To Friday",
                        PoolSize= 5.0M,
                        EntryDeadline=DateTime.Parse("2024-03-01")
                    },
                    new Swimming
                    {
                        PoolName = "Chad Le Clos Longcourse Pool",
                        PoolLength = "50 Meters",
                        PoolLocation = "USA",
                        PoolCapacity= "60 People",
                        PoolTimings="7AM - 11PM",
                        PoolDays=" Monday To Sunday",
                        PoolSize= 7.0M,
                        EntryDeadline=DateTime.Parse("2024-02-14")
                    },
                    new Swimming
                    {
                        PoolName = "MP Olympic Pool",
                        PoolLength = "50 Meters",
                        PoolLocation = "Brazil",
                        PoolCapacity= "50 People",
                        PoolTimings="7AM - 11PM",
                        PoolDays=" Monday To Saturday",
                        PoolSize= 6.0M,
                        EntryDeadline=DateTime.Parse("2024-10-01")
                    },
                    new Swimming
                    {
                        PoolName = "Community Pool",
                        PoolLength = "35 Meters",
                        PoolLocation = "Illinois",
                        PoolCapacity= "100 People",
                        PoolTimings="7AM - 11PM",
                        PoolDays=" All Days",
                        PoolSize= 9.0M,
                        EntryDeadline=DateTime.Parse("2023-12-25")
                    }

                    
                );
                context.SaveChanges();
            }
        }
    }
}