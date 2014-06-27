using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class SqlRepository
    {
        private DataContext _context;
        private Table<Comment> _commentsTable;
        private Table<Entry> _entriesTable;

        public IEnumerable<Comment> Comments
        {
            get
            {
                return _commentsTable.AsEnumerable();
            }
        }

        public IEnumerable<Entry> Entries
        {
            get
            {
                return _entriesTable.AsEnumerable();
            }
        }

        public SqlRepository(string connectionString)
        {
            _context = new DataContext(connectionString);
            _commentsTable = _context.GetTable<Comment>();
            _entriesTable = _context.GetTable<Entry>();
        }
    }
}
