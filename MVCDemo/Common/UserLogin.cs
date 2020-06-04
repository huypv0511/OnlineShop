using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace MVCDemo
{
    [Serializable]
    public class UserLogin
    {
  
        public long UserID { set; get; }
        public string UserName { set; get; }
    }
}