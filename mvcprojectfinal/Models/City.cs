﻿namespace mvcprojectfinal.Models
{
    public class City
    {
        public int Id { get; set; }
        public  string Image { get; set; }

        public string Name { get; set; }
        public List<Hotels> Hotels { get; set; }
    }
}
