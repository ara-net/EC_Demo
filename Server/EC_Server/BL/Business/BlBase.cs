using EC_Server.Model;

namespace EC_Server.BL.Business
{
    public class BlBase
    {
        private readonly EiContext db;

        public BlBase(EiContext db)
        {
            this.db = db;
        }
    }
}
