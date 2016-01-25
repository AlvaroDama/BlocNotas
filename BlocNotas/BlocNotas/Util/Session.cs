using System.Collections.Generic;

namespace BlocNotas.Util
{
    public class Session
    {
        private static Dictionary<string, object> _session = new Dictionary<string, object>();

        public object this[string index]
        {
            get { return _session[index]; }

            set { _session[index] = value; }
        }
    }
}