using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.Data
{
    public class Comment
    {

        // primary key
        [Key]
        public int ID { get; set; }

        //[MaxLength(255)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        // foreign keys
        public int UserID { get; set; }
        public int PhotoID { get; set; }

        // Create relations
        // Because User-Comment relation is 1-N i need foreign key
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        // Because Photo-Comment relation is 1-N i need foreign key
        [ForeignKey("PhotoID")]
        public virtual Photo Photo { get; set; }
    }
}
