using Dapper;
using ExemploDataAccessDapperContribRepositoryGeneric.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapperContribRepositoryGeneric.Repositories
{
    //Criando uma herança do Repository generico para que o UserRepository tenha o CRUD completo
    public class UserRepository : Repository<User>
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public UserRepository()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        /* Nesse caso de tabelas interligadas não é possivel retornar o objeto completo por um repositorio generico, 
           então esse tipo de método deve ser criado a parte em um repositorio especifico */
        public List<User> SelectUserWithRole()
        {
            /* Nesse caso eu tenho uma lista de objetos Role dentro do objeto User então dentro do QUERY()
                  preciso informar para que ele consiga organizar da forma correta */

            //Criando a query
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            //Lista externa que vai ser o retorno do método
            var users = new List<User>();

            /*No tipo do objeto dentro de QUERY() voce deve informar na seguinte ordem <TabelaPrincipal, TabelaDoJoin, TabelaPrincipal>
                     essa ordem se trata de as duas primeiras serem as tabelas que vão retornar na query e a terceira informando dentro de qual tabela vai ser o retorno
                    como nesse caso nosso objeto principal é o User se passa ela na terceira posição*/

            var items = _sqlConnection.Query<User, Role, User>( // lembrando que podem ser N objetos "<User, Role, Category, User>" o importante é o ultimo ser sempre o Principal
                query,
                (user, role) => //Aqui voce vai passar o dois objetos que vão ser adicionadas as tabelas
                {
                    /*Aqui dentro voce possui os objetos das duas tabelas e pode fazer o tratamento que quiser neles */

                    //Aqui voce está verificando se o item já existe dentro da lista externa que voce criou "linha 37"
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        //caso não exista 

                        //Voce cria o item que vai receber as duas tabelas primeira adicionando a tabela principal
                        usr = user;
                        //Verificando se o role existe
                        if (role != null)
                            usr.Roles.Add(role);//Depois adicionando a tabela relacionada na sua respectiva variavel

                        users.Add(usr);//e agora sim voce adiciona na lista que vai ser o retorno do método
                    }
                    else
                        //Se o usuario já existe na lista vai apenas adicionar o Role dele
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }
    }
}
