﻿using System.Collections.Generic;

namespace WebApp
{
    public static class BaseUsuarios
    {
        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario {Nome = "Fulano", Senha = "123456789", Funcoes = new string[] { Funcao.Aluno} },
                new Usuario {Nome = "Beltrano", Senha = "123", Funcoes = new string[] { Funcao.Professor} },
                new Usuario {Nome = "Siclano", Senha = "123", Funcoes = new string[] { Funcao.Professor, Funcao.Administrador} },
            };
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string[] Funcoes { get; set; }
    }

    public class Funcao
    {
        public const string Aluno = "Aluno";
        public const string Professor = "Professor";
        public const string Administrador = "Administrador";
    }
}