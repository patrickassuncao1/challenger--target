/* 

    3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
    • O menor valor de faturamento ocorrido em um dia do mês;
    • O maior valor de faturamento ocorrido em um dia do mês;
    • Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

*/

using Challenger.Models.Interface;
using Challenger.Entities;
using Challenger.Utils;

namespace Challenger.Models
{
    public class Task_3 : ITask
    {
        private const decimal _maxValue = decimal.MaxValue;
        private DataBase _lowerBilledAmountAtTheDayOfMonth = new DataBase();
        private DataBase _highestBilledAmountAtTheDayOfMonth = new DataBase();
        private decimal _amount = 0;
        private int _skippedDays = 0;
        private List<DataBase> _dataBase = JsonCustomList<DataBase>.ListComplete("json/dados.json")!;

        public Task_3()
        {
            _lowerBilledAmountAtTheDayOfMonth.valor = _maxValue;
            _highestBilledAmountAtTheDayOfMonth.valor = 0;
        }

        private void CalculateMonth()
        {
            _dataBase.ForEach((data) =>
            {
                if (data.valor != 0 && data.valor < _lowerBilledAmountAtTheDayOfMonth.valor)
                {
                    _lowerBilledAmountAtTheDayOfMonth = data;
                }

                if (data.valor > _highestBilledAmountAtTheDayOfMonth.valor)
                {
                    _highestBilledAmountAtTheDayOfMonth = data;
                }

                if (data.valor == 0)
                {
                    _skippedDays += 1;
                }

                _amount += data.valor;
            });
        }

        private int GetAboveAverageDays()
        {
            int days = 0;

            decimal monthlyAverage = _amount / (_dataBase.Count() - _skippedDays);

            _dataBase.ForEach((data) =>
            {
                if (data.valor > monthlyAverage)
                {
                    days += 1;
                }
            });

            return days;
        }

        public void start()
        {
            CalculateMonth();
            int days = GetAboveAverageDays();

            Console.WriteLine("O menor valor de faturamento ocorrido no mês foi: ");
            Console.WriteLine($"Dia: {_lowerBilledAmountAtTheDayOfMonth.dia} valor: R$ {_lowerBilledAmountAtTheDayOfMonth.valor} \n");

            Console.WriteLine("O maior valor de faturamento ocorrido no mês foi: ");
            Console.WriteLine($"Dia: {_highestBilledAmountAtTheDayOfMonth.dia} valor: R$ {_highestBilledAmountAtTheDayOfMonth.valor} \n");

            Console.WriteLine("A quatidade de dias que valor de faturamento diário foi superior à média mensal foi de :");
            Console.WriteLine($"{days} dias");
        }
    }
}