using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExersise0._1.classes
{

    public class DoubleStack
    {
        private double[] data;
        public int stackIndexPosition { get; private set; }

        private UserInterface _userInterface;

        public DoubleStack(UserInterface userInterface)
        {
            data = new double[1000];
            stackIndexPosition = 0;
            _userInterface = userInterface;
        }

        public void Push(double value)
        {
            //värdet läggs till i listan, EFTER det ökar stackIndexPosition med 1. Föregående värde i listan ligger allts åen plats efter värdet i indexValue som är det aktuella indexplatsen där vi kan stoppa in ett nytt värde. 
            data[stackIndexPosition++] = value;
        }

        public double Pop()
        {
            if (stackIndexPosition > 0)
            {
                // stackIndexPosition/stackIndexPosition räknas ned INNAN det returneras så att vi får senast tillagda värdet. stackIndexPosition har värdet på det index där ett eventuellt nytt värde ska läggas in. 
                return data[--stackIndexPosition];
            }
            else
            {
                Console.WriteLine("stack empty, returning 0");
                return 0;
            }
        }

        public double Peek()
        {
            if (stackIndexPosition > 0)
            {
                return data[stackIndexPosition - 1];
            }
            else
            {
                _userInterface.WriteErrorMessageStackEmpty();
                return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append('[');
            for (int i = stackIndexPosition - 1; ; i--)
            {
                b.Append(data[i]);
                if (i == 0)
                    return b.Append(']').ToString();
                b.Append(", ");
            }
        }

        public void Clear()
        {
            stackIndexPosition = 0;
        }
    }
}
