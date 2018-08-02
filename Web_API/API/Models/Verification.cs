using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Verification
    {
        public int Id { get; set; }
        public string sign { get; set; }//签名
        public string datetime { get; set; }//时间戳  
        public string username { get; set; }//用户登录名
        public string password { get; set; }//登录密码   
        public string stoken { get; set; }//stoken值
    }
}