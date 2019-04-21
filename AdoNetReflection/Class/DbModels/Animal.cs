using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetReflection.Class.DbModels
{
    class Animal
    {
        [PrimaryKey]
        [PropName("ID")]
        public int Id { get; set; }
        public string AnimalName { get; set; }
    }
}
