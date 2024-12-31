using eVillaBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace eVillaBooking.Infrastructure.Data
{
	public class ApplicationDbContext :DbContext
	{
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
		public DbSet<Villas> villa { get; set; }
		public DbSet<VillaNumber> VillaNumbers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var seedData = new List<Villas>()
{
                                  new Villas(){
                                              Id = 1,
                                              Name = "Royal Villa",
                                              Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                                              ImageUrl = "https://placehold.co/600x400",
                                              Occupancy = 4,
                                              Price = 200,
                                              Sqft = 550,
                                          },
                                        new Villas()
                                        {
                                            Id = 2,
                                            Name = "Premium Pool Villa",
                                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                                            ImageUrl = "https://placehold.co/600x401",
                                            Occupancy = 4,
                                            Price = 300,
                                            Sqft = 550,
                                        },
                                        new Villas()
                                        {
                                            Id = 3,
                                            Name = "Luxury Pool Villa",
                                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                                            ImageUrl = "https://placehold.co/600x402",
                                            Occupancy = 4,
                                            Price = 400,
                                            Sqft = 750,
                                        }
};
			modelBuilder.Entity<Villas>().HasData(seedData);

			modelBuilder.Entity<VillaNumber>().HasData(

				new VillaNumber { Villa_id = 1, Vill_Number = 101 },
				new VillaNumber { Villa_id = 2, Vill_Number = 202 },
				new VillaNumber { Villa_id = 3, Vill_Number = 303 });
		
		
		
		}





	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	}


































}
