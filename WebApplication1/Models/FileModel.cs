﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class FileModel
    {
        // what will be displayed
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        // allows communication between server and user
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}