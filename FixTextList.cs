using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fehrestoonak_V1
{
    internal class FixTextList
    {
        public string FixSpaces(string Input, int RowLength)
        {
            string Output = "";

            if (Input.Length <= RowLength)
            {
                string Spaces = "";
                for (int i = 0; i < RowLength - Input.Length; i++)
                {
                    Spaces = Spaces + " ";
                }
                Output = Input + Spaces;
            }
            else
            {
                Output = Input.Substring(0, RowLength);
            }

            return Output;
        }
    }
}
