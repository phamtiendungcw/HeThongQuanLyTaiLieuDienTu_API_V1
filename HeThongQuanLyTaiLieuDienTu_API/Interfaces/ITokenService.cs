﻿using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;

namespace HeThongQuanLyTaiLieuDienTu_API.Interfaces {

    public interface ITokenService {

        Task<string> CreateToken(AppUser user, bool isRememberMe);
    }
}