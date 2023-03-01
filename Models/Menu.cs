using Challenger.Models;

namespace Challenger.Models
{
    public class Menu
    {

        private int _action;

        private void Action()
        {

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"({i}) Para Visualizar a Resolução da Tarefa {i + 1}");
            }

            _action = int.Parse(Console.ReadLine()!);
        }

        private void Choices()
        {
            switch (_action)
            {
                case 1:
                    var task_2 = new Task_2();
                    task_2.start();
                    break;
                case 2:
                    var task_3 = new Task_3();
                    task_3.start();
                    break;
                case 3:
                    var task_4 = new Task_4();
                    task_4.start();
                    break;
                case 4:
                    var task_5 = new Task_5();
                    task_5.start();
                    break;
                default:
                    Console.WriteLine("Não Encontrado");
                    break;
            }
        }

        public void Execute()
        {
            bool isStop = true;
            int number = 0;

            while (isStop)
            {
                Action();
                Choices();

                Console.WriteLine("\nDeseja Continuar: ");
                Console.WriteLine("(1) Sim \n(Qualquer outra número) Não  ");
                number = int.Parse(Console.ReadLine()!);

                if (number != 1)
                {
                    Console.WriteLine("Programa Finalizado");
                    break;
                }
                else
                {
                    Console.Clear();
                }

            }


        }
    }
}