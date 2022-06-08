using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
        public ActionResult FilePage()
        {

            string[] filePathImage = Directory.GetFiles(Server.MapPath("~/App_Data/Images/"));
            string[] filePathDocument = Directory.GetFiles(Server.MapPath("~/App_Data/Documents/"));
            string[] filePathVideo = Directory.GetFiles(Server.MapPath("~/App_Data/Videos/"));

            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePathImage)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });

            }

            foreach (string filePath in filePathDocument)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });

            }

            foreach (string filePath in filePathVideo)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });

            }

            return View(files);
            
        }

        public FileResult DownloadFile(string fileName) 
        {
            //Build the File Path.

            
            string path = Server.MapPath("~/App_Data/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //not working
            // for documents
            string pathd = Server.MapPath("~/App_Data/Documents/") + fileName;
            byte[] bytesd = System.IO.File.ReadAllBytes(pathd);

            // for videos
            string pathv = Server.MapPath("~/App_Data/Videos/") + fileName;
            byte[] bytesv = System.IO.File.ReadAllBytes(pathv);




            return File(bytes, "application/octet-stream", fileName);
           
        }


        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            //for images
            string path = Server.MapPath("~/App_Data/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //not working
            // for documents
            string pathd = Server.MapPath("~/App_Data/Documents/") + fileName;
            byte[] bytesd = System.IO.File.ReadAllBytes(pathd);

            //not working
            // for videos
            string pathv = Server.MapPath("~/App_Data/Videos/") + fileName;
            byte[] bytesv = System.IO.File.ReadAllBytes(pathv);

            //deleting files
            System.IO.File.Delete(path);

            //not working
            System.IO.File.Delete(pathd);
            System.IO.File.Delete(pathv);

            return RedirectToAction("FilePage");
        }
    }
}