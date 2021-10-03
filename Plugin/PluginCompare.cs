using System;
using System.Collections.Generic;

namespace Plugin
{
    public class PluginCompare : IEqualityComparer<IPlugin>
    {
        public bool Equals(IPlugin x, IPlugin y)
        {
            return x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(IPlugin obj)
        {
            throw new NotImplementedException();
        }
    }
}
