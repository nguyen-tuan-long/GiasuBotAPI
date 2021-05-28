using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiasuBotAPI.Models
{
    public class Lop4
    {
        [Key]
        public int SubjectId { get; set; }
        public string Subject { get; set; }
        public string Tenbai { get; set; }
        public string Bailam { get; set; }
    }
}