using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(Name = "Entry")]
    public class Entry
    {
        private List<Comment> _comments;

        public Entry()
        {
            _comments = new List<Comment>();
        }

        [Column(IsDbGenerated = true, IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Summary { get; set; }

        [Column]
        public DateTime Published { get; set; }

        [Column]
        public int LatestRevisionId { get; set; }

        [Column]
        public bool IsDiscussionEnabled { get; set; }

        [Column]
        public string MetaDescription { get; set; }

        [Column]
        public string MetaTitle { get; set; }

        [Column]
        public bool HideChrome { get; set; }

        [Column]
        public string Status { get; set; }

        [Column]
        public string PageTemplate { get; set; }

        [Column]
        public int RevisionNumber { get; set; }

        [Column]
        public string Body { get; set; }

        [Column]
        public string Author { get; set; }

        [Column]
        public string RevisionAuthor { get; set; }

        [Column]
        public DateTime LastRevised { get; set; }

        [Column]
        public string LatestRevisionFormat { get; set; }

        [Column]
        public string TagsCommaSeparated { get; set; }

        [Column]
        public int CommentCount { get; set; }

        public string Url { get; set; }

        public List<Comment> Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
            }
        }
    }
}
