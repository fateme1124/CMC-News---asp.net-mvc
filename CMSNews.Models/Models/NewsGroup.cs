using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSNews.Models.Models
{
    [Table("T_NewsGroups")]
    public class NewsGroup: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsGroupId { get; set; }
        [Required]
        [MaxLength(200)]
        public string NewsGroupTitle { get; set; }
        [MaxLength(100)]
        public string ImageName { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
