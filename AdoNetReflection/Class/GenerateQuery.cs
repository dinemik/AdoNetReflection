using AdoNetReflection.Class.DbModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetReflection.Class
{
    public class GenerateQuery
    {
        private readonly string ConsStr = ConfigurationManager.ConnectionStrings["ReflectionConnectionString"].ConnectionString;

        public string GenerateSelectQuery(object tbl, List<string> condition)
        {
            string command = $"select * from dbo.{tbl.GetType().Name}" +
                             $" where ";

            foreach (var item in condition)
            {
                command += item + " and ";
            }
            command = command.Substring(0, command.Length - 4);

            return command;
        }

        public string GenerateInsertQuery(object tbl)
        {
            string command = $"insert into dbo.{tbl.GetType().Name} (";

            var tblProp = tbl.GetType().GetProperties().Where(o => !(o.GetCustomAttributes(false).Any(i => (i is PrimaryKeyAttribute)))).ToList();

            //for prop names.
            foreach (var item in tblProp)
            {
                if (item.GetCustomAttributes(false).Any(o => o is PropNameAttribute))
                    command += (item.GetCustomAttributes(false).Where(o => o is PropNameAttribute).First() as PropNameAttribute).PropName + ", ";
                else
                    command += item.Name + ", ";
            }

            command = command.Substring(0, command.Length - 2);
            command += ") Values (";

            //for prop values.
            foreach (var item in tblProp)
            {
                command += $"'{item.GetValue(tbl)}', ";
            }
            command = command.Substring(0, command.Length - 2);
            command += ")";

            return command;
        }

        public string GenerateUpdateQuery(object tbl, List<string> condition)
        {
            string command = $"update dbo.{tbl.GetType().Name} set ";

            var tblProp = tbl.GetType().GetProperties().Where(o => !(o.GetCustomAttributes(false).Any(i => (i is PrimaryKeyAttribute)))).ToList();

            //set.
            foreach (var item in tblProp)
            {
                command += $"{item.Name} = '{item.GetValue(tbl)}', ";
            }
            command = command.Substring(0, command.Length - 2);
            command += " where ";

            //where.
            foreach (var item in condition)
            {
                command += item + " and ";
            }
            command = command.Substring(0, command.Length - 4);

            return command;
        }

        public string GenerateDeleteQuery(object tbl, List<string> condition)
        {
            string command = $"delete from dbo.{tbl.GetType().Name} where ";

            //where.
            foreach (var item in condition)
            {
                command += item + " and ";
            }
            command = command.Substring(0, command.Length - 4);

            return command;
        }
    }
}
