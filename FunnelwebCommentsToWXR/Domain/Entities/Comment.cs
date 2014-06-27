using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(Name = "Comment")]
    public class Comment
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column]
        public string Body { get; set; }

        [Column]
        public string AuthorName { get; set; }

        [Column]
        public string AuthorEmail { get; set; }

        [Column]
        public string AuthorUrl { get; set; }

        [Column]
        public string AuthorIp { get; set; }

        [Column]
        public DateTime Posted { get; set; }

        [Column]
        public int EntryId { get; set; }

        [Column]
        public int EntryRevisionNumber { get; set; }

        [Column]
        public int Status { get; set; }
    }
}
