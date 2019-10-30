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
