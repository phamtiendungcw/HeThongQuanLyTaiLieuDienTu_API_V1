﻿using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTaiLieuDienTu_API.Data.DTOs
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string Password { get; set; }

        [EmailAddress] public string Email { get; set; }

        [Phone] public string Phone { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string HoVaTen { get; set; }

        [Required] public DateTime NgayThangNamSinh { get; set; }

        [StringLength(500, MinimumLength = 2)] public string DiaChi { get; set; }

        [Required] public bool GioiTinh { get; set; }

        [StringLength(12, MinimumLength = 10)] public string SoCMND { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string NoiCapCMND { get; set; }

        public DateTime NgayCapCMND { get; set; }
    }
}