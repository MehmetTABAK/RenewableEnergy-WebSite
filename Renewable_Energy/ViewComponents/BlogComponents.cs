﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_DataAccess;
using Renewable_Energy_Entities.DTOs;

namespace Renewable_Energy_Web.ViewComponents
{
    public class BlogComponents : ViewComponent
    {
        RenewableEnergyContext context = new();

        public IViewComponentResult Invoke() 
        {
            List<BlogCategoryDTO> blog = context.Blogs.Include(w => w.Category).ToList().Select(blog =>
            new BlogCategoryDTO
            {
                Id = blog.Id,
                Title = blog.Title,
                Body = blog.Body,
                ImageUrl = blog.ImageUrl,
                CategoryId = blog.CategoryId,
                Time = blog.Time,
                Writer = blog.Writer,
                CategoryName = blog.Category != null ? string.Join(", ", blog.Category.Name) : string.Empty,
            }
            ).ToList();
            return View(blog);
        }
    }
}