using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha
{
    public static class SessionMgr
    {
        private static string m_UserId;
        public static string UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }
    }
}
