using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca;

public class Usuario
{
    public int id { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }

    public List<Usuario> listarUsuarios(BibliotecaContext baseUsuario)
    {
        return baseUsuario.usuarios.ToList();
    }

    public Usuario listarUsuario(BibliotecaContext baseUsuario, int id)
    {
        return baseUsuario.usuarios.Find(id);
    }

    public string cadastrarUsuario(BibliotecaContext baseUsuario, Usuario usuario)
    {
        int cont = 0;

        usuario.id = cont++;
        baseUsuario.usuarios.Add(usuario);
        baseUsuario.SaveChanges();
        return "Usuário cadastrado com sucesso";
    }

    public string atualizarUsuario(BibliotecaContext baseUsuario, Usuario usuarioAtualizado, int id)
    {
        var usuario = baseUsuario.usuarios.Find(id);
        usuario.Nome = usuarioAtualizado.Nome;
        usuario.Email = usuarioAtualizado.Email;
        usuario.Telefone = usuarioAtualizado.Telefone;

        baseUsuario.SaveChanges();
        return "Usuário atualizado com sucesso";
    }

    public string deletarUsuario(BibliotecaContext baseUsuario, int id)
    {
        var usuario = baseUsuario.usuarios.Find(id);
        baseUsuario.Remove(usuario);
        baseUsuario.SaveChanges();
        return "Usuario deletado";
    }
}