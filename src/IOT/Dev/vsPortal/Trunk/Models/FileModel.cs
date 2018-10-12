using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class FileModel
    {       
        public HttpPostedFile file { get; set; }
        public int Id { get; set; }
        public string FileName { get; set; }
        public int UserId { get; set; }
        public string File_Name { get; set; }
    }
}