using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POCSwaggerYAML
{
    public class ToDo
    {
        [Required]
        public int idToDo { get; set; }

        [DefaultValue("")]
        public string task { get; set; }

        public string? date { get; set; }

        public string? time { get; set; }
    }
}
