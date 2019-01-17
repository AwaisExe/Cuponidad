using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;
using Cuponidad.Models;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cuponidad.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        AddProductViewModel addProductViewModel = null;
        public AdminController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct(string message = " ")
        {
            try
            {
                addProductViewModel = new AddProductViewModel();
                if (message != " ")
                {
                    ViewData["SuccessMessage"] = message;
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessageRegister"] = ex.Message;
            }
            return View(addProductViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, List<IFormFile> Images)
        {
            string message = "";
            try
            {
                await UploadImage(Images);
                //product.ImagePath = await UploadImage(Image);
                //ProductRepository.Insert(product);
                message = "Your Product has been Uploaded successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            finally
            {
                addProductViewModel = new AddProductViewModel();
            }
            return RedirectToAction("AddProduct", new { message });
        }
        public IActionResult CategoryList(int FamilyID)
        {
            string vReturn = "";
            try
            {
                addProductViewModel = new AddProductViewModel(FamilyID);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 405;
                vReturn = ex.Message;
            }
            return new JsonResult(addProductViewModel.Categories);
        }

        private async Task<string> UploadImage(List<IFormFile> Images)
        {
            string ImagePath;
            foreach (var img in Images)
            {
                if (img.Length > 0)
                {
                    ImagePath = _hostingEnvironment.WebRootPath + "\\images\\Upload";
                    ImagePath = ImagePath + "\\" + img.FileName;
                    using (var stream = new FileStream(ImagePath, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }
                    var compressedImage = new FileInfo(ImagePath);
                    var optimizer = new ImageOptimizer();
                    optimizer.Compress(compressedImage);
                    compressedImage.Refresh();

                    ImagePath = "images\\Upload\\" + img.FileName;
                    ImagePath = "";
                }
            }

            return "";
        }
    }
}