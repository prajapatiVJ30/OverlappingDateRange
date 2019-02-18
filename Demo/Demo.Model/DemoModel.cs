using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Demo")]
    public class DemoModel
    {
        public int ID { get; set; }

        [Required]
        public DateTime StartDate1 { get; set; }

        [Required]
        public DateTime EndDate1 { get; set; }

        [Required]
        public DateTime StartDate2 { get; set; }

        [Required]
        public DateTime EndDate2 { get; set; }

        public bool IsOverlap { get; set; }

        public DateTime? Overlap_StartDate { get; set; }

        public DateTime? Overlap_EndDate { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
