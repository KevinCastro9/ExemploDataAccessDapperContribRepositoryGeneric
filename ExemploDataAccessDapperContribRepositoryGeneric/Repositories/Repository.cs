using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapperContribRepositoryGeneric.Repositories
{
    /*No caso "Repository<NomeQueDeseja>" é pra indicar que essa classe é um repositorio generico 
      ou seja ele esta fazendo o crud de qualquer objeto que for passado quando instanciar ela */

    /* Já o "where NomeQueDeseja : class" está fixando que tem que ser uma classe um objeto, para evitar que passe outro tipo */
    public class Repository<TModel> where TModel : class
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public Repository()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        //CRUD
        public long InsertGeneric(TModel model) => _sqlConnection.Insert(model);

        public bool UpdateGeneric(TModel model) => _sqlConnection.Update(model);

        public bool DeleteGeneric(TModel model) => _sqlConnection.Delete(model);

        public List<TModel> SelectGeneric() => _sqlConnection.GetAll<TModel>().ToList();

        public TModel SelectIdGeneric(int id) => _sqlConnection.Get<TModel>(id);
    }
}
