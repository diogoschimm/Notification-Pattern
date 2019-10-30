# Notification Pattern

Exemplo de Notification Pattern utilizando Flunt
  
  
Para mais informações sobre o Flunt acesse o repositório oficial do projeto.

https://github.com/andrebaltieri/flunt
  
  
Para instalar o Flunt utilize o seguinte comando via Nuget Package Manager

```
Install-Package Flunt
```

Após instalar o Package faça sua entidade herdar da classe Notifiable

```c#
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsPattern.Domain
{
    public class Funcionario : Notifiable
    {
        public int FuncionarioId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public DateTime DataRegistro { get; private set; }

        public Funcionario(int id, string nome, DateTime dataNasc, string cpf, string rg, DateTime dataReg)
        {
            this.FuncionarioId = id;
            this.Nome = nome;
            this.DataNascimento = dataNasc;
            this.CPF = cpf;
            this.RG = rg;
            this.DataRegistro = dataReg;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.Nome))
                AddNotification(new Notification("Nome", "Nome inválido, deve ser preenchido"));

            if (this.DataNascimento >= DateTime.Now)
                AddNotification(new Notification("DataNascimento", "Data de Nascimento não pode ser maior ou igual a data do Sistema"));

            if (this.CPF.Length != 11)
                AddNotification(new Notification("CPF", "CPF inválido"));

            if (string.IsNullOrEmpty(this.RG))
                AddNotification(new Notification("RG", "RG deve ser preenchido"));

            if (this.DataRegistro >= DateTime.Now)
                AddNotification(new Notification("DataRegistro", "Data de Registro não pode ser maior que a Data atual do sistema"));

            return this.Notifications.Count == 0;
        }
    }
}

```

E adicione as notificações com o Metodo AddNotification.
E após isso faça a verificação das notificações quando utilizar a entidade

```c#
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

```

## Resultado

Caso o funcionário seja válido o resultado será

![image](https://user-images.githubusercontent.com/30643035/67825057-808cd200-fa9e-11e9-9da7-874477ec5454.png)

Caso o funcionário seja inválido ele conterá as notificações

![image](https://user-images.githubusercontent.com/30643035/67825145-c47fd700-fa9e-11e9-9829-6bc66f61c1da.png)


