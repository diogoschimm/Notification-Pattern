using NotificationsPattern.Domain;
using System;

namespace NotificationsPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o CPF: ");
            string CPF = Console.ReadLine();

            Console.Write("Informe o RG: ");
            string RG = Console.ReadLine();

            int id = 0;
            DateTime dataNasc = DateTime.Now.AddYears(-10);
            DateTime dataReg = DateTime.Now.AddYears(-10);

            Console.WriteLine("");

            var funcionario = new Funcionario(id, nome, dataNasc, CPF, RG, dataReg);
            if (funcionario.Validate())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Funcionário Válido");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("***** Funcionário Inválido ***** ");
                foreach (var item in funcionario.Notifications)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("===> " + item.Message);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

    }
}
