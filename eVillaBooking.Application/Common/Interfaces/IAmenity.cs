﻿using eVillaBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVillaBooking.Application.Common.Interfaces
{
	public interface IAmenityRepositroy :IRepositroy<Amenity>
	{
	  void Update(Amenity amenity);

	}
}
