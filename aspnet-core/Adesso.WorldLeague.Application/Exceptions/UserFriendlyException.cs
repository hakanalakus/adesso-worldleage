using System;

namespace Adesso.WorldLeague.Exceptions
{
    public class UserFriendlyException:Exception
    {
        public UserFriendlyException(string msg):base(msg)
        {
            
        }
    }
}
