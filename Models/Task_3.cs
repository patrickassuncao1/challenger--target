/* 

    3) Dado um vetor que guarda o Valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
    • O menor Valor de faturamento ocorrido em um dia do mês;
    • O maior Valor de faturamento ocorrido em um dia do mês;
    • Número de dias no mês em que o Valor de faturamento diário foi superior à média mensal.

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
            _lowerBilledAmountAtTheDayOfMonth.Valor = _maxValue;
            _highestBilledAmountAtTheDayOfMonth.Valor = 0;
        }

        private void CalculateMonth()
        {
            _dataBase.ForEach((data) =>
            {
                if (data.Valor != 0 && data.Valor < _lowerBilledAmountAtTheDayOfMonth.Valor)
                {
                    _lowerBilledAmountAtTheDayOfMonth = data;
                }

                if (data.Valor > _highestBilledAmountAtTheDayOfMonth.Valor)
                {
                    _highestBilledAmountAtTheDayOfMonth = data;
                }

                if (data.Valor == 0)
                {
                    _skippedDays += 1;
                }

                _amount += data.Valor;
            });
        }

        private int GetAboveAverageDays()
        {
            int days = 0;

            decimal monthlyAverage = _amount / (_dataBase.Count() - _skippedDays);

            _dataBase.ForEach((data) =>
            {
                if (data.Valor > monthlyAverage)
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
            Console.WriteLine($"Dia: {_lowerBilledAmountAtTheDayOfMonth.Dia} Valor: R$ {_lowerBilledAmountAtTheDayOfMonth.Valor} \n");

            Console.WriteLine("O maior valor de faturamento ocorrido no mês foi: ");
            Console.WriteLine($"Dia: {_highestBilledAmountAtTheDayOfMonth.Dia} Valor: R$ {_highestBilledAmountAtTheDayOfMonth.Valor} \n");

            Console.WriteLine("A quatidade de dias que Valor de faturamento diário foi superior à média mensal foi de :");
            Console.WriteLine($"{days} dias");
        }
    }
}