using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Fehrestoonak_V1
{
    internal class Work
    {
        Id id = new Id();

        public void Add(string Subject, DateTime date)
        {
            string works = File.ReadAllText("user_works.txt");

            string new_work = $"{id.Last() + 1},,{Subject},,Progress,,{date}";

            File.AppendAllText("user_works.txt", new_work + ";;");
        }

        public List<Work_List> GetList()
        {
            string works = File.ReadAllText("user_works.txt");
            string[] works_arr = works.Replace("\n", "").Split(";;",StringSplitOptions.RemoveEmptyEntries);

            List<Work_List> list = new List<Work_List>();

            foreach (string work in works_arr)
            {
                string[] work_Mono = work.Split(",,");

                if (work_Mono.Length > 1)
                {
                    list.Add(
                        new Work_List
                        { Id = work_Mono[0], Subject = work_Mono[1], Status = work_Mono[2], Date = work_Mono[3] }
                        );
                }
            }

            return list;
        }

        public bool Done(int Id)
        {
            try
            {
                string works = File.ReadAllText("user_works.txt");
                var rows = works.Split(";;", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < rows.Count; i++)
                {
                    var cols = rows[i].Split(new[] { ",," }, StringSplitOptions.None);

                    if (int.TryParse(cols[0], out int id) && id == Id)
                    {
                        cols[2] = "Done";
                        rows[i] = string.Join(",,", cols);
                        break;
                    }
                }

                string result = string.Join(";;", rows) + ";;";
                File.WriteAllText("user_works.txt", result);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                string works = File.ReadAllText("user_works.txt");
                var rows = works.Split(";;").ToList();
                string result = "";

                for (int i = 0; i < rows.Count; i++)
                {
                    var cols = rows[i].Split(new[] { ",," }, StringSplitOptions.None);

                    if (int.TryParse(cols[0], out int id) && id == Id)
                    {
                        result = rows[i] + ";;";
                        break;
                    }
                }

                result = works.Replace(result, "");
                File.WriteAllText("user_works.txt", result);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
