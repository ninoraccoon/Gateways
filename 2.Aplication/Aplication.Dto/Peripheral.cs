using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto
{
    public class Peripheral
    {
        public int id { get; set; }
        [Required]
        public int UID  { get; set; }
        public string vendor { get; set; }
        public DateTime creatioDate { get; set; }
        public  bool status { get; set; }

        public int GatewayId { get; set; }
    }
    
}
