using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebixDhtmlxDemos.Models.Webix
{
    public class Task
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
    }
}