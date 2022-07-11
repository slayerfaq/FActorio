using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Roman.Service.Interfaces
{
    interface IAuthRegHelper
    {
        public List<string[]> ReadDataUsers();
    }
    /*private void LoadUsers()
    {
        try
        {
            FileStream fs = new FileStream("Users.txt", FileMode.Open);
            fs.Close();
        }
        catch { return; }
    }*/
}
