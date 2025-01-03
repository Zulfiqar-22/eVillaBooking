using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVillaBooking.Domain.Entity
{
	public class VillaNumber
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Villa_Number {  get; set; }
		public string? SpecialDetails {  get; set; }
		
		[ValidateNever]
		public Villas Villas { get; set; }  //Genreic ID
		
		[ForeignKey("Villas")]
		public int Villa_id { get; set; }

	}
}
