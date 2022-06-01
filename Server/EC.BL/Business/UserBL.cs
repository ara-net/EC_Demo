using EC.Domain.DataAccess;
using EC.Domain.Tables;

namespace EC.BL.Business
{
    public class UserBL : BlBase, IUserBL
    {
        public UserBL(EcContext db) : base(db)
        {
        }
        public async Task<ApiResultDTO> GetAll()
        {
            var data = (await db.Users.ToListAsync())
                .Select(m => new UserDTO
                {
                    Id = m.UserId,
                    BirthDate = m.BirthDate.ToSepratedPersianDate(),
                    Email = m.Email,
                    Name = m.Name,
                    Family = m.Family,
                    IsActive = m.IsActive
                }).ToList();

            return data.Any() ?
                GetSuccessResult(data) :
                GetFailResult();
        }
        public async Task<ApiResultDTO> Get(int id)
        {
            var data = await db.Users.Where(m => m.UserId == id).Select(m => new UserDTO
            {
                Id = m.UserId,
                BirthDate = m.BirthDate.ToSepratedPersianDate(),
                Email = m.Email,
                Name = m.Name,
                Family = m.Family,
                IsActive = m.IsActive
            }).FirstOrDefaultAsync();

            return data != null ? GetSuccessResult(data) : GetFailResult();
        }

        public async Task<ApiResultDTO> ToggleBan(int id)
        {
            var user = await db.Users.FindAsync(id);
            user.IsActive = !user.IsActive;
            return await db.SaveChangesAsync() > 0 ? GetSuccessResult(user) : GetFailResult();
        }
        public async Task<ApiResultDTO> Add(UserDTO user)
        {
            if (user.Id == 0)
            {
                db.Users.Add(new User
                {
                    BirthDate = user.BirthDate.ArrayToDateTime(),
                    Email = user.Email,
                    Family = user.Family,
                    Name = user.Name,
                    IsActive = true,
                    Password = user.Password
                });
                return await db.SaveChangesAsync() > 0 ? GetSuccessResult(user) : GetFailResult();
            }
            var dbUser = db.Users.Find(user.Id);
            dbUser.BirthDate = user.BirthDate.ArrayToDateTime();
            dbUser.Email = user.Email;
            dbUser.Name = user.Name;
            dbUser.Family = user.Family;
            dbUser.IsActive = user.IsActive;
            dbUser.Password = user.Password;
            return await db.SaveChangesAsync() > 0 ? GetSuccessResult(dbUser) : GetFailResult();
        }

        public async Task<ApiResultDTO> Delete(int id)
        {
            var dbUser = db.Users.Find(id);
            db.Users.Remove(dbUser);
            return await db.SaveChangesAsync() > 0 ? GetSuccessResult(dbUser) : GetFailResult();
        }
    }
}