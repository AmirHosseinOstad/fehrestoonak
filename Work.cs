using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fehrestoonak_V1
{
    internal class Work
    {
        Id id = new Id();

        public void Add(string Subject, DateTime date)
        {
            string works = File.ReadAllText("user_works.txt");

            string new_work = $"{id.Last() + 1},,{Subject},,{date}";

            File.AppendAllText("user_works.txt", new_work + ";;\n");
        }

        public List<Work_List> GetList()
        {
            string works = File.ReadAllText("user_works.txt");
            string[] works_arr = works.Replace("\n", "").Split(";;");

            List<Work_List> list = new List<Work_List>();

            foreach (string work in works_arr)
            {
                string[] work_Mono = work.Split(",,");

                if (work_Mono.Length > 1)
                {
                    list.Add(
                        new Work_List
                        { Id = work_Mono[0], Subject = work_Mono[1], Date = work_Mono[2] }
                        );
                }
            }

            return list;
        }
    }
}
