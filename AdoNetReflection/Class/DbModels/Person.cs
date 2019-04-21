using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetReflection.Class.DbModels
{
    class Person
    {
        [PrimaryKey]
        [PropName("ID")]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonLName { get; set; }
        public int PersonAge { get; set; }
    }
}
