/* 
    2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor 
    sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), 
    escreva um programa na linguagem que desejar onde, informado um número, 
    ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o
    número informado pertence ou não a sequência.

*/
using Challenger.Models.Interface;

namespace Challenger.Models
{
    public class Task_2 : ITask
    {
        private int _searchNumber;

        private void Message(string message)
        {
            Console.WriteLine(message);
        }
        private Boolean FibonacciSequence()
        {
            int currentNumber = 0;
            int previousNumber = 1;
            int secondPreviousNumber = 0;

            while (true)
            {
                if (currentNumber == _searchNumber) return true;
                else if (currentNumber > _searchNumber) return false;

                currentNumber = previousNumber + secondPreviousNumber;
                secondPreviousNumber = previousNumber;
                previousNumber = currentNumber;
            }
        }

        public void start()
        {
            Message("Digite um número Inteiro para pesquisar na sequência de Fibonacci: ");

            _searchNumber = int.Parse(Console.ReadLine()!);

            Boolean isTrue = FibonacciSequence();

            if (isTrue)
            {
                Message("O Número Pertence a Sequência Fibonnaci");
            }
            else
            {
                Message("O Número Não Pertence a Sequência Fibonnaci");
            }
        }

    }
}