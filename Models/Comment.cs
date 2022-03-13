using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReviewService.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CommentContent { get; set; }
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        [JsonIgnore]
        public virtual Course Course { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }

    }
}
