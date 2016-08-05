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
        static List<Funcionario> funcionarios = new List<Funcionario>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Medico> medicos = new List<Medico>();
        public Dados()
        {
            // foi alterado a estrutura de ifs...
            // Erro de lógica, tem que avaliar cada coleção...
            // são condições separadas...

            // tambem poderia inverter a logica e verificar apenas uma coleção...
            // se não ouver dados nela...deve popular todas as coleções...
            // já que essa rotina rodará apenas uma vez na criação bd.



            if (medicos.Count == 0)
            {
                medicos.Add(new Medico { Id = 1, Nome = "João", Crm = "11111" });
                medicos.Add(new Medico { Id = 2, Nome = "zé", Crm = "11111" });
                medicos.Add(new Medico { Id = 3, Nome = "mario", Crm = "11111" });
                medicos.Add(new Medico { Id = 4, Nome = "Maira", Crm = "11111" });
                medicos.Add(new Medico { Id = 5, Nome = "Sergio", Crm = "11111" });
            }
            //else if(clientes.Count == 0)
            if (clientes.Count == 0)
            {
                clientes.Add(new Cliente { Id = 1, Nome = "Sergio", Cnpj = "06297632000145", Email = "teste@hotmail.com" });
                clientes.Add(new Cliente { Id = 2, Nome = "Joao", Cnpj = "06297632000145", Email = "teste@hotmail.com" });
                clientes.Add(new Cliente { Id = 3, Nome = "Pedro", Cnpj = "06297632000145", Email = "teste@hotmail.com" });
                clientes.Add(new Cliente { Id = 4, Nome = "Maria", Cnpj = "06297632000145", Email = "teste@hotmail.com" });

            }
            //else if(funcionarios.Count == 0)
            if (funcionarios.Count == 0)
            {
                funcionarios.Add(new Funcionario { Id = 1, Nome = "João", Email = "teste@hotmail.com", Funcao = "teste", cliente = new Cliente { Id = 1, Nome = "Sergio", Cnpj = "06297632000145", Email = "teste@hotmail.com" } });
                funcionarios.Add(new Funcionario { Id = 2, Nome = "zé", Email = "teste@hotmail.com", Funcao = "teste" });
                funcionarios.Add(new Funcionario { Id = 3, Nome = "mario", Email = "teste@hotmail.com", Funcao = "teste" });
                funcionarios.Add(new Funcionario { Id = 4, Nome = "Maira", Email = "teste@hotmail.com", Funcao = "teste" });
                funcionarios.Add(new Funcionario { Id = 5, Nome = "Sergio", Email = "teste@hotmail.com", Funcao = "teste" });

            }



        }
       


        public List<Cliente> ListaCliente()
        {
                       
            return clientes;
        }
        public List<Medico> ListaMedicos()
        {

            return medicos;
        }

        public void IncluirMedico(Medico medico)
        {
            medicos.Add(medico);

        }
        public void IncluirCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        public void IncluirFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }

        public List<Funcionario> ListaFuncionario()
        {
            
            return funcionarios;
        }

        public void AlterarMedico(Medico medico)
        {
           var editado =  medicos.Where(x => x.Id == medico.Id).FirstOrDefault();
            editado.Nome = medico.Nome;
            editado.Crm = medico.Crm;
            editado.Especialidade = medico.Especialidade;
            editado.Email = medico.Email;

        }

        public void ExcluirMedico(Medico medico)
        {
            var editado = medicos.Where(x => x.Id == medico.Id).FirstOrDefault();
            medicos.Remove(editado);
        }
    }
}
