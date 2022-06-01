using EC.Domain.DataAccess;
using EC.Domain.Tables;

namespace EC.BL.Business
{
    public class MenuBL : BlBase, IMenuBL
    {
        public MenuBL(EcContext db) : base(db)
        {
        }


        public async Task<ApiResultDTO> GetAll()
        {
            var data1 = await db.Menu.Include(m => m.SubMenu).Where(m => m.MenuId == null && m.isActive).ToListAsync();

            var data = data1.Select(m => new MenuDTO
            {
                Order = m.Order,
                IsActive = m.isActive,
                Text = m.Text,
                Icon = m.Icon,
                SubMenuId = m.SubMenuId,
                Tag = m.Tag,
                Url = m.SubMenuId ?? m.Url,
                Id = m.Id,
                SubMenu = m.SubMenu.Select(n => new MenuDTO
                {
                    Id = n.Id,
                    IsActive = n.isActive,
                    Order = n.Order,
                    Text = n.Text,
                    Icon = n.Icon,
                    Tag = n.Tag,
                    Url = m.Url + n.Url,
                    HasParam = string.IsNullOrEmpty(n.Url)
                }).ToList()
            }).OrderBy(m => m.Order).ToList();

            return data.Any() ? GetSuccessResult(data) : GetFailResult();
        }
        public async Task<ApiResultDTO> Add(Menu menu)
        {
                db.Menu.Add(menu);
            return await db.SaveChangesAsync() > 0
                    ? GetResult("منوی جدید با موفقیت اضافه شد، برای اعمال تغییرات، صفحه را Refresh نمایید", true)
                    : GetResult("خطا در درج منو", false);
        }

        public async Task<ApiResultDTO> ChangeOrder(OrderUpdateDTO input)
        {
            var menu = db.Menu.Find(input.Id);
            var menuCurrentValue = db.Menu.FirstOrDefault(m => m.Order == input.Order);
            if (menuCurrentValue == null)
                return GetResult("عدد وارد شده معتبر نمی باشد", false);
            menuCurrentValue.Order = menu.Order;
            menu.Order = input.Order;
            return await db.SaveChangesAsync() > 0 ? GetSuccessResult() : GetFailResult();
        }

        public async Task<ApiResultDTO> ToggleActive(int menuId)
        {
            var menu = db.Menu.Find(menuId);
            menu.isActive = !menu.isActive;
            return await db.SaveChangesAsync() > 0 ? GetSuccessResult() : GetFailResult();
        }
    }
}