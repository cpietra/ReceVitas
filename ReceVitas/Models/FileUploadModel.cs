﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReceVitas.Models
{
    public class FileUploadModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string file { get; set; }
    }
}
