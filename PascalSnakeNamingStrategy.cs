using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

namespace SportzInteractive
{
    public class PascalSnakeNamingStrategy : NamingStrategy
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            var array = propertyName.ToArray();
            string name = string.Empty;
            name += array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Equals(Char.ToUpper(array[i])))
                {
                    name += "_";
                }
                name += array[i];
            }

            return name;
        }

    }
}
