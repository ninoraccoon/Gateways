
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Domain
{
    public class Gateway
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Index(IsUnique = true)]
        public string serial { get; set; }
        public string ipv4 { get; set; }
        public ICollection<Peripheral> Peripheral { get; set; }
    }
}
