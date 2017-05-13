using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    static class Extensions
    {
        public static TValue Pluck<TKey, TValue>( this Dictionary<TKey, TValue> self, TKey key )
        {
            TValue v = self[ key ];
            self.Remove( key );
            return v;
        }

        public static String XFormat( this String format, params Object[] args )
        {
            return String.Format( format, args );
        }
    }
}
