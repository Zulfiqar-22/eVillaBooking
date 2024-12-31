using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVillaBooking.Domain.Entity
{
	public class VillaNumber
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Vill_Number {  get; set; }
		public string? SpecialDetails {  get; set; }

		public Villas Villas { get; set; }  //Genreic ID
		
		[ForeignKey("Villas")]
		public int Villa_id { get; set; }

	}
}
