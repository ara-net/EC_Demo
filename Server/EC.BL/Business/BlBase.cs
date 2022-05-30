global using EC.Common.DTO;
global using EC.Common.Tools;
global using static EC.Common.Tools.Extension;
global using EC.Domain;
global using Microsoft.EntityFrameworkCore;
global using EC.BL.Interface;

namespace EC.BL.Business
{
    public class BlBase
    {
        internal readonly EcContext db;

        public BlBase(EcContext db)
        {
            this.db = db;
        }
    }
}
