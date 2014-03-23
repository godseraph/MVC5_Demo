using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="请输入你的名字")]
        [Display(Name="姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请输入你的邮件地址")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage="请输入有效的邮件地址")]
        [Display(Name="邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage="请输入电话号码")]
        [Display(Name="电话")]
        public string Phone { get; set; }
        [Required(ErrorMessage="请设置是否参加")]
        [Display(Name="是否参加")]
        public bool? WillAttend { get; set; }       //? 代表可以为null
    }
}