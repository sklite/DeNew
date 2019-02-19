using DeNew.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DeNew.Controllers
{
    public class UploadController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private const string tempImage = "currentFileImage";
        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        string GetFullPathOfPreview(string previewImgName)
        {
            return _hostingEnvironment.WebRootPath + VariablesSettingsConfig.PREVIEW_IMG_DIR + previewImgName;
        }

        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> Save(IEnumerable<IFormFile> previewImage)
        {
            if (previewImage == null)
                return Ok();
            //return Content("");

            // The Name of the Upload component is "files"
            TempData[tempImage] = string.Empty;
            var fileList = previewImage.ToList();
            if (fileList.Count == 1)
            {
                foreach (var file in fileList)
                {
                    var fileName = $@"{DateTime.Now.Ticks}.jpg";
                    string physicalPath = GetFullPathOfPreview(fileName);
                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        TempData[tempImage] = fileName;
                    }
                }
            }

            return Ok();
            // Return an empty string to signify success
            //return Content(string.Empty);
        }
        [Authorize]
        public IActionResult Remove(string[] fileNames)
        {
            if (fileNames == null || fileNames.Length == 0)
                return Ok();
                //return Content("");



            foreach (var fullName in fileNames)
            {

                var fileName = Path.GetFileName(fullName);
                string physicalPath = _hostingEnvironment.WebRootPath + VariablesSettingsConfig.PREVIEW_IMG_DIR + fileName;
                //var physicalPath = Path.Combine(Server.MapPath($"~/{VariablesSettingsConfig.FolderPrefix}Images"), fileName);

                if (System.IO.File.Exists(physicalPath))
                    System.IO.File.Delete(physicalPath);

            }

            return Ok();
            //return Content(string.Empty);
        }

        public JsonResult Getcurimage()
        {
            return Json(new
            {
                Name = TempData[tempImage]
            });

        }
    }
}