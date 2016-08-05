﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sergio.Saude.Dominio;


namespace Sergio.Saude.Repositorio.Contexto
{
    public class SaudeWebDbContexto : DbContext
    {
        // foi alterado os acessores.... para public, estava usando o default
        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public SaudeWebDbContexto() : base("SaudeWebContexto")
        {
            //Database.SetInitializer(new PreparaDb());
            //CarregaBancoSistema(db);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(150));
            //base.OnModelCreating(modelBuilder);
        }

        //private void CarregaBancoSistema()
        //public static void CarregaBancoSistema(SaudeWebDbContexto contexto)
        //{
        //    //SaudeWebDbContexto contexto = new SaudeWebDbContexto();
        //    if (contexto.Clientes.Count() == 0)
        //    {
        //        Dados dados = new Dados();

        //        var clientes = dados.ListaCliente();
        //        var medicos = dados.ListaMedicos();
        //        var funcionarios = dados.ListaFuncionario();
        //        medicos.ForEach(m => contexto.Medicos.Add(m));//cada registro é um item da coleção
        //        clientes.ForEach(m => contexto.Clientes.Add(m));
        //        funcionarios.ForEach(m => contexto.Funcionarios.Add(m));
        //        contexto.SaveChanges();
        //    }
        //}
    }
}
