﻿namespace test_case.Models
{
    public class Bucket
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
    }
}
