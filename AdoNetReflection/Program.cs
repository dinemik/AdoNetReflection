using AdoNetReflection.Class;
using AdoNetReflection.Class.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetReflection
{
    class Program
    {
        public static void Main()
        {
            GenerateQuery t = new GenerateQuery();

            Person person = new Person()
            {
                Id = 1,
                PersonAge = 12,
                PersonLName = "bidzia",
                PersonName = "backsoon"
            };

            Console.WriteLine("Select: " + t.GenerateSelectQuery(person, new List<string> { "id > 1", "id < 100" }));
            //
            Console.WriteLine("insert: " + t.GenerateInsertQuery(person));
            Console.WriteLine("Update: " + t.GenerateUpdateQuery(person, new List<string> { "id = 11" }));
            Console.WriteLine("Delete: " + t.GenerateDeleteQuery(person, new List<string> { "id = 11" }));

            Console.ReadKey();
        }
    }
}
