using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca;

public class Livro
{
    public int id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Lancamento { get; set; }
}



