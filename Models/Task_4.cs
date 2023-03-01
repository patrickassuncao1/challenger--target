/* 
    4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
    SP – R$67.836,43
    RJ – R$36.678,66
    MG – R$29.229,88
    ES – R$27.165,48
    Outros – R$19.849,53
    Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada 
    estado teve dentro do valor total mensal da distribuidora.
*/

using Challenger.Utils;
using Challenger.Entities;
using Challenger.Models.Interface;

namespace Challenger.Models
{
    public class Task_4 : ITask
    {
        private Decimal _total = 0;
        private List<Invoicing> _invoicing = JsonCustomList<Invoicing>.ListComplete("json/invoicing.json")!;


        public Task_4()
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            _invoicing.ForEach((data) =>
            {
                _total += data.Amount;
            });
        }

        private void Percentage()
        {
            decimal percentage = 0;

            _invoicing.ForEach((data) =>
            {
                percentage = (data.Amount / _total) * 100;
                Console.WriteLine($"Estado: {data.State}");
                Console.WriteLine($"Faturamento: {data.Amount}");
                Console.WriteLine($"Percentual: {percentage.ToString("F")}% \n");
            });
        }

        public void start()
        {
            Percentage();
        }
    }
}