using CleanCodeExersise0._1.classes;
using System;
using System.Text;

namespace CalculatorRPN
{
    class Program
    {
        static void Main(string[] args)
        {
            //initierar objekt
            UserInterface userInterface = new UserInterface();
            DoubleStack stack = new DoubleStack(userInterface);

            while (true)
            {
                //skriv ut meny om inget värde finns i stacken
                if (stack.stackIndexPosition == 0)
                    userInterface.WriteMenu();
                //annars skriv ut stacken
                else
                    Console.WriteLine(stack.ToString());

                //ta in och spara input. ta bort blankspace
                string input = Console.ReadLine().Trim();
                // ser till att input har ett tecken, även om det är ett blankspace..
                if (input == "") input = " ";
                //.. eftersom här sparas 1a tecknet från input och används i programmets vilkorsatser
                char command = input[0];

                // om input är en siffra, spara värdet och pusha till stacken. stackIndexPositionPosition ökar därefter med ett.
                if (char.IsDigit(command))
                {
                    double value = Convert.ToDouble(input);
                    stack.Push(value);
                }

                // annars om input är +, addera de senaste två talen från stacken och pusha.
                else if (command == '+')
                    stack.Push(stack.Pop() + stack.Pop()); // om jag ska addera 3 tal då?
                
                // annars om input är *, multiplicera de semaste två talen (dvs med stackIndexPosition 0 & 1) från stacken och pusha
                else if (command == '*')
                    stack.Push(stack.Pop() * stack.Pop());
                //annars om input är - poppa talet med stackIndexPosition 0, spara i variabel och subtrahera numret med det tal som du nu poppar. Resultatet pushas
                else if (command == '-')
                {
                    double numberToSubtract = stack.Pop();
                    stack.Push(stack.Pop() - numberToSubtract);
                }
                //annars om input är / poppa talet med stackIndexPosition 0, spara i variabel och dividera numret med det tal som du nu poppar från index 0. Resultatet pushas
                else if (command == '/')
                {
                    double numberToDivide = stack.Pop();
                    stack.Push(stack.Pop() / numberToDivide);
                }
                // annars om input är c töm stacken på värden
                else if (command == 'c')
                    stack.Clear();
                // annars om input är q, bryt loopen så att programmet avslutas
                else if (command == 'q')
                    break;
                // annars skriv ut felmeddelande i konsolen
                else
                    userInterface.WriteErrorMessageIllegalCommand();
            }
        }
    }
}
