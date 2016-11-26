using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.Data
{
    public class Photo
    {

        // primary key
        [Key]
        public int ID { get; set; }
        
        //[MaxLength(255)]
        public string URL { get; set; }
        //[MaxLength(255)]
        public string Title { get; set; }
        //[MaxLength(255)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        // foreign key
        public int UserID { get; set; }

        // Create relations
        // Because User-Photo relation is 1-N i need foreign key
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        // If ICollection is used then relation between this class/table and used class/table is 1:N
        [InverseProperty("Photo")]
        public virtual ICollection<Like> Likes { get; set; }
        [InverseProperty("Photo")]
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
