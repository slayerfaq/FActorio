using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.Service
{
    class GenerationHelper
    {
        public static string GetRandomPassword(int a, int b, int LenghtRandomString = 5)
        {
            string randomStr = string.Empty;
            //int a = 48, b = 122;

            Random r = new Random();
            while (randomStr.Length < LenghtRandomString)
            {
                Char c = (char)r.Next(a, b);
                if (Char.IsLetterOrDigit(c))
                    randomStr += c;
            }
            return randomStr;
        }
        public static List<int> GenerateListId(int count)
        {
            List<int> IDs = new List<int>();

            for(int i = 0; i < count; ++i)
            {
                IDs.Add(new Helper().GetHashCode());
            }

            return IDs;
        }
    }

    class Helper { }
}
