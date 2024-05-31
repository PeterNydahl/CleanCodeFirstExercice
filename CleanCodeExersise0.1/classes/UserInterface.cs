using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExersise0._1.classes
{
    public class UserInterface
    {
        public void WriteMenu (){
            Console.WriteLine("Commands: q c + - * / number");
            Console.WriteLine("[]");
        }

        public void WriteErrorMessageIllegalCommand()
        {
            Console.WriteLine("Illegal command, ignored");
        }

        public void WriteErrorMessageStackEmpty()
        {
            Console.WriteLine("stack empty, returning 0");
        }
    }
}
