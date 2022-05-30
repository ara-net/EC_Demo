namespace EC.Common.DTO
{
    public class MenuDTO
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Tag { get; set; }
        public string Url { get; set; }
        public string SubMenuId { get; set; }
        public ICollection<MenuDTO> SubMenu { get; set; }
        public bool HasParam { get;  set; }
        public int Id { get;  set; }
        public int Order { get;  set; }
        public bool IsActive { get;  set; }
    }
}
