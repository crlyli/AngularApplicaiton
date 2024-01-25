﻿namespace AngularAspCore.Server.Data.Models.Dto
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Rate { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateRead { get; set; }
    }
}