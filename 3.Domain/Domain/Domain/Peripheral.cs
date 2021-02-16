using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Domain
{
    public class Peripheral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id  { get; set; }
        public string vendor { get; set; }
        public DateTime creatioDate { get; set; }
        public  bool status { get; set; }
        public int GatewayId { get; set; }
        public Gateway Gateway { get; set; }
        [Index(IsUnique = true)]
        public int UID { get; set; }
    }
    
}
