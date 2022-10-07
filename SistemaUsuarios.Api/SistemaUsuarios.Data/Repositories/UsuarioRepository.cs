using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Data.Contexts;
using SistemaUsuarios.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUsuarios.Data.Repositories
{
    public class UsuarioRepository
    {
        //método para inserir um usuário na base de dados
        public void Create(Usuario usuario)
        {
            //conectando no banco de dados
            using (var sqlServerContext = new SqlServerContext())
            {
                //gravando um usuario no banco de dados
                sqlServerContext.Usuario.Add(usuario);
                sqlServerContext.SaveChanges();
            }
        }

        //método para atualizar no banco de dados
        public void Update(Usuario usuario)
        {
            //conectando no banco de dados
            using (var sqlServerContext = new SqlServerContext())
            {
                //atualizar o usuário do banco de dados
                sqlServerContext.Entry(usuario).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }
        //método para excluir um usuário do banco de dados
        public void Delete(Usuario usuario)
        {
            //conectando no banco de dados
            using (var sqlServerContext = new SqlServerContext())
            {
                //excluíndo o usuário do banco de dados
                sqlServerContext.Remove(usuario);
                sqlServerContext.SaveChanges();
            }
        }

        //método para consultar 1 usuário através do e-mail
        public Usuario GetByEmail(string email)
        {
            //conectando no banco de dados
            using (var sqlServerContext = new SqlServerContext())
            {
                //consultando 1 usuario pelo email
                return sqlServerContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        //método para consultar 1 usuário através do email e da senha
        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            //conectando no banco de dados
            using (var sqlServerContext = new SqlServerContext())
            {
                //consultando 1 usuário pelo email e senha
                return sqlServerContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email) 
                                      && u.Senha.Equals(senha));
            }
        }
    }
}
