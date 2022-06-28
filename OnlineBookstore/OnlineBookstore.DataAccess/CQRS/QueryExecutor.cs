using OnlineBookstore.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly BookstoreContext _context;

        public QueryExecutor(BookstoreContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}