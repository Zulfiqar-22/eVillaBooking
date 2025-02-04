using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVillaBooking.Domain.Entity
{
	public class Amenity
	{
		[Key]
		public int Id { get; set; }

		public required string Name { get; set; }

		public string? Description { get; set; }

		[ValidateNever]
		public Villas Villas { get; set; }

		[ForeignKey("Villas")]
		public int VillaId {  get; set; }
	}
}
