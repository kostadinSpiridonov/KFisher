using System;

namespace KFisher.Library.DTOs
{
    public class LocationDto
    {
        public Guid Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }
    }
}
