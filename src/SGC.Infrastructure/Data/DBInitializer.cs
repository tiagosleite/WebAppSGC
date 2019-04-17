﻿using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public static class DBInitializer
    {
        public static void Initialize(ClienteContext context)
        {
            if (context.Clientes.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente
                {
                    Nome = "Fulano da Silva",
                    CPF = "38585411090"
                },
                new Cliente
                {
                    Nome = "Beltrano da Silva",
                    CPF = "17647877062"
                }
            };

            context.AddRange(clientes);

            var contatos = new Contato[]
            {
                new Contato
                {
                    Nome = "Contato 1",
                    Telefone = "99999999",
                    Email="contato1@teste.com",
                    Cliente = clientes[0]                    
                },
                new Contato
                {
                    Nome = "Contato 2",
                    Telefone = "88888888",
                    Email="contato2@teste.com",
                    Cliente = clientes[1]
                }
            };

            context.AddRange(contatos);
            context.SaveChanges();
        }
    }
}

