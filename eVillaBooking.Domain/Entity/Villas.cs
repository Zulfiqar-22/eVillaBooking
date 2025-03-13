using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVillaBooking.Domain.Entity
{
	public class Villas
	{
		
         public int Id { get; set; }
		public required string Name { get; set; }
		[MaxLength(30)]
		public string? Description { get; set; }
		public double Price { get; set; }
		[Range(10,10000)]
		public int Sqft { get; set; }
		public int Occupancy { get; set; }
		public string? ImageUrl { get; set; }
		[NotMapped]
		public IFormFile? Image { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }

		[ValidateNever]
	  public ICollection<Amenity> AmenitiesList { get; set; }

		[NotMapped]
		public bool IsAvaliable { get; set; } = true;
	
	}



}

