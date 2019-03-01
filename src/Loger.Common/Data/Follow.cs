using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.Data
{
    public class Follow
    {

        // primary key
        [Key]
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        // foreign keys
        public int UserFollowingID { get; set; }
        public int UserFollowedID { get; set; }

        // Create relations
        // Because User has recursive many to many relationship it is equl to two 1-N relations with this table
        [ForeignKey("UserFollowingID")]
        public virtual User UserFollowing { get; set; }
        [ForeignKey("UserFollowedID")]
        public virtual User UserFollowed { get; set; }

    }
}
