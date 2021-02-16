using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto
{
    public class Gateway
    {
        public int id { get; set; }
        [Required]
        public string serial { get; set; }
        [Required,RegularExpression(@"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)", ErrorMessage = "Invalid V4Ip")]
        public string ipv4 { get; set; }
        public List<Peripheral> Peripheral { get; set; }
    }
}
