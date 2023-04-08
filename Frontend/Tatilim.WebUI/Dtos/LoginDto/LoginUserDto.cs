﻿using System.ComponentModel.DataAnnotations;

namespace Tatilim.WebUI.Dtos.LoginDto
{
	public class LoginUserDto
	{
        [Required(ErrorMessage ="Kullanıcı Adını Giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Kullanıcı Şifresini Giriniz")]
        public string Password { get; set; }
	}
}
