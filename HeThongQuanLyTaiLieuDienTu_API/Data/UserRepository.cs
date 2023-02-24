using AutoMapper;
using AutoMapper.QueryableExtensions;
using HeThongQuanLyTaiLieuDienTu_API.Data.DTOs;
using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;
using HeThongQuanLyTaiLieuDienTu_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTaiLieuDienTu_API.Data {

    public class UserRepository : IUserRepository {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async void Delete(int id) {
            var user = await GetUserByIdAsync(id);
            _context.Users.Remove(user);
        }

        public async Task<MemberDto> GetMemberAsync(string username) {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync() {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id) {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username) {
            return await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync() {
            return await _context.Users
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync() {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user) {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}