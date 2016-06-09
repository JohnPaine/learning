﻿namespace LINQ_to_objects_1.Model
{
    internal class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; } = 0;

        public override string ToString() {
            return $"Name={Name}, Description={Description}, Number in Stock={NumberInStock}";
        }
    }
}