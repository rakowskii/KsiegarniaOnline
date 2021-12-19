using OnlineBookstore.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly BookstoreContext context;

        public CommandExecutor(BookstoreContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
