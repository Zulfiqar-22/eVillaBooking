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

		public DbSet<Amenity> Amenities { get; set; }
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

				new VillaNumber { Villa_id = 1, Villa_Number = 101 },
				new VillaNumber { Villa_id = 2, Villa_Number = 202 },
				new VillaNumber { Villa_id = 3, Villa_Number = 303 });

			modelBuilder.Entity<Amenity>().HasData(


				new Amenity { Id = 1, VillaId = 1, Name = "Private Pool" },

				new Amenity { Id = 2, VillaId = 1, Name = "Microwave" },

				new Amenity { Id = 3, VillaId = 1, Name = "Private Balcony" },

				new Amenity { Id = 4, VillaId = 1, Name = "Bed And Sofa" },

				new Amenity { Id = 5, VillaId = 2, Name = "Private Plunge Pool" },

				new Amenity { Id = 6, VillaId = 2, Name = "Microwave and mini Refrigerator" },

				new Amenity { Id = 7, VillaId = 2, Name = "Private Balcony" },

				new Amenity { Id = 8, VillaId = 2, Name = "King Bed And Sofa" },




				new Amenity { Id = 9, VillaId = 3, Name = "Private Plunge Pool" },

				new Amenity { Id = 10, VillaId = 3, Name = "Microwave and mini Refrigerator" },

				new Amenity { Id = 11, VillaId = 3, Name = "Private Balcony" },

				new Amenity { Id = 12, VillaId = 3, Name = "King Bed And Sofa" });
		
		}





	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	}


































}
