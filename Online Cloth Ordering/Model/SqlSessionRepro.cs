using Online_Cloth_Ordering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Cloth_Ordering.Model
{
    public class SqlSessionRepro : ISessionsRepro
    {
        AuthDbContext context = null;

        public SqlSessionRepro(AuthDbContext _context) => context = _context;

        string ISessionsRepro.GetUsername()
        {
            String uname = "";

            List<Sessions> temptosave = context.Sessions.Select(s => s).ToList();
            temptosave.Reverse();
            uname = temptosave[0].UserName;

            //temptosave;

            return uname;
        }

        Sessions ISessionsRepro.Add(Sessions sess)
        {
            context.Sessions.Add(sess);
            context.SaveChanges();
            return sess;
        }
    }
}
