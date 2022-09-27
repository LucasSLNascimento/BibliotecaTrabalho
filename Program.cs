//criar projeto:
//	dotnet new webabi -minimal -o NomeDoProjeto
//entrar na pasta:
//	cd NomeDoProjeto
//adicionar entity framework no console:
//	dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0
//	dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0
//	dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
//incluir namespace do entity framework:
//	using Microsoft.EntityFrameworkCore;
//antes de rodar o dotnet run pela primeira vez, rodar os seguintes comandos para iniciar a base de dados:
//	dotnet ef migrations add InitialCreate
//	dotnet ef database update

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        //Como utilizar diferentes tabelas
        var connectionString = builder.Configuration.GetConnectionString("Usuarios") ?? "Data Source=Usuarios.db";
        builder.Services.AddSqlite<BibliotecaContext>(connectionString);

        var app = builder.Build();

        Usuario novoUs = new Usuario();

        //Usuario
        app.MapPost("/cadastrar/usuario", novoUs.cadastrarUsuario);
        app.MapGet("/listar/usuario/all", novoUs.listarUsuarios);
        app.MapGet("/listar/usuario/{id}", novoUs.listarUsuario);
        app.MapPost("/atualizar/usuario/{id}", novoUs.atualizarUsuario);
        app.MapPost("/deletar/usuario/{id}", novoUs.deletarUsuario);

        //Livros

        app.Run();
    }

}


