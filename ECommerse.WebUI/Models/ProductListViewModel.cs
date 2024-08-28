﻿using ECommerce.Entities.Models;

namespace ECommerse.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product>? Products { get; set; }
        public int CurrentCategory { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentPage { get; internal set; }
        public string? SortProduct { get; internal set; }
        public string? LowerUpperBtn { get; internal set; }
    }
}