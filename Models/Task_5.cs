/* 
    5) Escreva um programa que inverta os caracteres de um string.

*/

using Challenger.Models.Interface;

namespace Challenger.Models
{
    public class Task_5 : ITask
    {

        private string _value = "";

        private string ReverseString()
        {
            string reverseString = "";

            for (int i = _value.Count() - 1; i >= 0; i--)
            {
                reverseString += _value[i];
            }

            return reverseString.ToLower();

        }

        public void start()
        {
            Console.WriteLine("Digite uma frase ou palavra: ");
            _value = Console.ReadLine()!;

            var reverseString = ReverseString();

            Console.WriteLine($" \n String Invertida: {reverseString} ");

        }
    }
}