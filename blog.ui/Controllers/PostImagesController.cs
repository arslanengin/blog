using blog.business.repositories;
using blog.data.models;
using blog.ui.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.ui.Controllers
{
    public class PostImagesController :Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostImageRepository _postImageRepository;
        private readonly IFileUpload _fileUpload;

        public PostImagesController(IPostRepository postRepository, IPostImageRepository postImageRepository,IFileUpload fileUpload)
        {
            _postRepository = postRepository;
            _postImageRepository = postImageRepository;
            _fileUpload = fileUpload;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload(Guid? id)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("Index", "Posts");
            }
            return View(id);
        }
        [HttpPost]
        public IActionResult Upload(IFormFile[] file, Guid? id)//Dropzone içerisinde tanımlı kelıme file 
        {
            if (id.HasValue)
            {
                Post post = _postRepository.GetById(id.Value);
                if(post == null)
                {
                    return NotFound();
                }

                if (file.Length > 0)
                {
                    foreach (var item in file)
                    {
                        var result = _fileUpload.Upload(item);
                        if(result.FileResult == Utility.FileResult.Succeded)
                        {
                            PostImage image = new PostImage
                            {
                                ImageUrl = result.FileUrl,
                                PostId = id.Value
                            };

                            _postImageRepository.Add(image);
                            _postImageRepository.Save();
                        }
                    }
                }
            }
            return View();
        }
    }
}
