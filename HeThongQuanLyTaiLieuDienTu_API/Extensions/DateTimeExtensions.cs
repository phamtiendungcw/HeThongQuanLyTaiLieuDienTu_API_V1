﻿namespace HeThongQuanLyTaiLieuDienTu_API.Extensions {

    public static class DateTimeExtensions {

        public static int CalculateAge(this DateTime dob) {
            var today = DateTime.Now;
            var age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;

            return age;
        }
    }
}