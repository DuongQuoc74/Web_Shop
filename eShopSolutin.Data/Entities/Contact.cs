using eShopsolutin.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class Contact // phần Liên hệ
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Message { set; get; } // Thông diệp
        public Status Status { set; get; }
    }
}
