using AllAboutSports.Models;
using AllAboutSports.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Category> GetCategoryById([FromRoute] int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddCategory([FromBody] Category category)
        {
            var response = _categoryRepository.AddCategory(category);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("update")]
        public StatusCodeResult UpdateCategory([FromBody] Category updatedCategory)
        {
            var respone = _categoryRepository.UpdateCategory(updatedCategory);
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public StatusCodeResult DeleteCategory([FromRoute] int id)
        {
            var respone = _categoryRepository.DeleteCategory(id)
;
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
