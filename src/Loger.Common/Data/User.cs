using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.Data
{
    public class User
    {

        // primary key
        [Key]
        public int ID { get; set; }
        
        //[MaxLength(50)]
        public string Email { get; set; }
        //[MaxLength(50), MinLength(2)]
        public string Username { get; set; }
        //[MaxLength(50), MinLength(8)]
        public string Password { get; set; }
        //[MaxLength(255)]
        public string AccountPhotoURL { get; set; }
        public DateTime CreatedDate { get; set; }

        // Create relations
        // If ICollection is used then relation between this class/table and used class/table is 1:N
        // Without InverseProperty annotation, Entity Framework will create 2 foreign keys
        // http://www.entityframeworktutorial.net/code-first/inverseproperty-dataannotations-attribute-in-code-first.aspx
        [InverseProperty("User")]
        public virtual ICollection<Photo> Photos { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Like> Likes { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Comment> Comments { get; set; }

        // Solving recursive many to many relation
        [InverseProperty("UserFollowing")]
        public virtual ICollection<Follow> Followings { get; set; }
        [InverseProperty("UserFollowed")]
        public virtual ICollection<Follow> Followeds { get; set; }
    }
}
