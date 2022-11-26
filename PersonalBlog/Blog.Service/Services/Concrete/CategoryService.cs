using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map.Take(24).ToList();
        }
        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            Category category = new(categoryAddDto.Name,userEmail);
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();
        }
        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;    
            
        }
        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);
            category.name = categoryUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;
            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return category.name; 
        }
        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return category.name;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
        public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return category.name;
        }
    }
}
