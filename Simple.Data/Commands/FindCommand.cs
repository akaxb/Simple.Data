﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Simple.Data.Commands
{
    class FindCommand : ICommand
    {
        /// <summary>
        /// Determines whether the instance is able to handle the specified method.
        /// </summary>
        /// <param name="method">The method name.</param>
        /// <returns>
        /// 	<c>true</c> if the instance is able to handle the specified method; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCommandFor(string method)
        {
            return method.Equals("find", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="binder">The binder from the <see cref="DynamicTable"/> method invocation.</param>
        /// <param name="args">The arguments from the <see cref="DynamicTable"/> method invocation.</param>
        /// <returns></returns>
        public object Execute(Database database, string tableName, InvokeMemberBinder binder, object[] args)
        {
            if (args.Length == 1 && args[0] is SimpleExpression)
            {
                return database.Adapter.Find(tableName, (SimpleExpression) args[0]);
            }

            return null;
        }
    }
}
