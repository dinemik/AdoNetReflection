using System;

namespace AdoNetReflection.Class.DbModels
{
    internal class PropNameAttribute : Attribute
    {
        public string PropName { get; set; }

        public PropNameAttribute(string name)
        {
            PropName = name;
        }
    }
}