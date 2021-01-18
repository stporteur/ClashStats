using ClashData.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness
{
    public class ApplicationManagement : IApplicationManagement
    {
        private readonly ISQLiteManagement _sQLiteManagement;

        public ApplicationManagement(ISQLiteManagement sQLiteManagement)
        {
            _sQLiteManagement = sQLiteManagement;
        }

        public bool ExecuteScript(string filename)
        {
            var script = File.ReadAllText(filename);
            return _sQLiteManagement.ExecuteNonQueryScript(script) > 1;
        }
    }
}
