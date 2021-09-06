using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleCore.Models
{
    public class User
    {
        //好像是不讓sqlserver產生PK
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NationId { get; set; }
        public string Name { get; set; }
        public DateTime BTH { get; set; }

    }
}
