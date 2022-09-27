using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca;

public class BibliotecaContext : DbContext
{
    // verificar atributos relacionados
    public BibliotecaContext(DbContextOptions options) : base(options)
    {
    }

    // verificar atributos relacionados
    public DbSet<Livro> Livros { get; set; } = null!;
    public DbSet<Usuario> usuarios { get; set; } = null!;
}