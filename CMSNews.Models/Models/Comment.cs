using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CMSNews.Models.Models
{
    [Table("T_Comments")]
    public class Comment: BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string CommentText { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive{ get; set; }
        [Required]
        public int NewsId{ get; set; }

        public virtual News News { get; set; }
    }
}
