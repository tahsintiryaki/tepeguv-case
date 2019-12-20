using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeGuvCase.DAL;

namespace TepeGuvCase.BLL.SingletonDesingPattern
{
    public class DbInstance
    {
        private static TepeGuvCaseDbEntities _dbInstance;
        private DbInstance()
        {

        }

        public static TepeGuvCaseDbEntities Instance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new TepeGuvCaseDbEntities();
                }
                return _dbInstance;
            }
        }
    }
}
