using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fehrestoonak_V1
{
    internal class Id
    {
        public int Last()
        {
            int id = 0;

            string works = File.ReadAllText("user_works.txt");

            if (!String.IsNullOrEmpty(works))
            {
                string[] works_arr = works.Split(";;", StringSplitOptions.RemoveEmptyEntries);

                string last_work = works_arr[works_arr.Length - 1];

                id = Convert.ToInt32(last_work.Split(",,")[0]);
            }

            return id;
        }
    }
}
