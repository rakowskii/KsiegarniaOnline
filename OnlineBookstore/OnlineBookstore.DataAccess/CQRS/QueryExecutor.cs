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
        private readonly BookstoreContext context;

        public QueryExecutor(BookstoreContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
