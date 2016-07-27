using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sergio.Saude.Dominio;


namespace Sergio.Saude.Repositorio
{
    public class Dados
    {
        public static List<Cliente> ListaCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente { Id = 1, Nome = "Sergio", Cnpj = "06297632000145", Email = "teste@hotmail.com" });
            clientes.Add(new Cliente { Id = 2, Nome = "Joao", Cnpj = "06297632000145", Email = "teste@hotmail.com" });
            clientes.Add(new Cliente { Id = 3, Nome = "Pedro", Cnpj = "06297632000145", Email = "teste@hotmail.com" });
            clientes.Add(new Cliente { Id = 4, Nome = "Maria", Cnpj = "06297632000145", Email = "teste@hotmail.com" });
            return clientes;
        }
        public static List<Medico> ListaMedicos()
        {
            List<Medico> medicos = new List<Medico>();
            medicos.Add(new Medico { Id = 1, Nome = "João", Crm = "11111" });
            medicos.Add(new Medico { Id = 2, Nome = "zé", Crm = "11111" });
            medicos.Add(new Medico { Id = 3, Nome = "mario", Crm = "11111" });
            medicos.Add(new Medico { Id = 4, Nome = "Maira", Crm = "11111" });
            medicos.Add(new Medico { Id = 5, Nome = "Sergio", Crm = "11111" });
            return medicos;
        }
        public static List<Funcionario> ListaFuncionario()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios.Add(new Funcionario { Id = 1, Nome = "João", Email = "teste@hotmail.com", Funcao = "teste", cliente= new Cliente { Id = 1, Nome = "Sergio", Cnpj = "06297632000145", Email = "teste@hotmail.com" } });
            funcionarios.Add(new Funcionario { Id = 2, Nome = "zé", Email = "teste@hotmail.com", Funcao = "teste" });
            funcionarios.Add(new Funcionario { Id = 3, Nome = "mario", Email = "teste@hotmail.com", Funcao = "teste" });
            funcionarios.Add(new Funcionario { Id = 4, Nome = "Maira", Email = "teste@hotmail.com", Funcao = "teste" });
            funcionarios.Add(new Funcionario { Id = 5, Nome = "Sergio", Email = "teste@hotmail.com", Funcao = "teste" });
            return funcionarios;
        }
    }
}
