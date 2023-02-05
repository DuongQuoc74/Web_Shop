using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace eShopSolution.ViewModels.System.Users
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }   
        [Display(Name = "Tên")]
        [Required(ErrorMessage ="Không được để trống")]
        public string FirstName { get; set; }

        [Display(Name = "Họ")]
		[Required(ErrorMessage = "Không được để trống")]
		public string LastName { get; set; }

        [Display(Name = "Ngày sinh")]
		[Required(ErrorMessage = "Không được để trống")]
		[DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name = "Email")]
		[Required(ErrorMessage = "Không được để trống")]
		public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
		[Required(ErrorMessage = "Không được để trống")]
		public string PhoneNumber { get; set; }

        

        
    }
}
