﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HitIt.Models
{
    public partial class HttpPostedFileClass
    {
        [Required(ErrorMessage = "Please select file")]
        public HttpPostedFileBase file { get; set; }
        [Required(ErrorMessage = "Please select file")]
        public HttpPostedFileBase fileTeaser { get; set; }
    }   

}
