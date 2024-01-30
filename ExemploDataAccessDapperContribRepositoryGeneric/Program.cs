

/*Lembrar de instalar os Packages/Pacotes "Microsoft.Data.SqlClient", "Dapper", "Dapper.Contrib" */

using ExemploDataAccessDapperContribRepositoryGeneric.Models;
using ExemploDataAccessDapperContribRepositoryGeneric.Repositories;




var categoryGeneric = new Repository<Category>();
var roleGeneric = new Repository<Role>();
var tagGeneric = new Repository<Tag>();
var userRepository = new UserRepository();

var categoria = new Category()
{
    Name = "Backend",
    Slug = "backend"
};

var role = new Role()
{
    Name = "Autor new",
    Slug = "authorNew"
};

var tag = new Tag()
{
    Name = "VB.NET",
    Slug = "VisualBasic"
};

var user = new User()
{
    Bio = "Equipe balta.io",
    Email = "hello@balta.io",
    Image = "https://...",
    Name = "Equipe balta.io",
    PasswordHash = "HASH",
    Slug = "equipe-balta"
};

//InsertCategory(categoria);
//UpdateCategory(categoria);
//DeleteCategory(categoria);
//SelectCategoryId(1);
//SelectListCategory();

//InsertRole(role);
//UpdateRole(role);
//DeleteRole(role);
//SelectRoleId(1);
//SelectListRole();

//InsertTag(tag);
//UpdateTag(tag);
//DeleteTag(tag);
//SelectTagId(1);
//SelectListTag();

//InsertUser(user);
//UpdateUser(user);
//DeleteUser(user);
//SelectUserId(1);
//SelectListUser();
//SelectUserWithRole();



// ---------------------------------------------------------- CRUD CATEGORY --------------------------------------------------------------------------
void InsertCategory(Category category)
{
    var returnInsertCategory = categoryGeneric.InsertGeneric(category);

    if (returnInsertCategory > 0)
        Console.WriteLine("Categoria inserida com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel inserir a categoria!");
}

void UpdateCategory(Category category)
{
    category.Id = 3;
    category.Name = "BackEnd new";
    var returnUpdateCategory = categoryGeneric.UpdateGeneric(category);

    if (returnUpdateCategory == true)
        Console.WriteLine("Categoria alterada com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel alterar a categoria!");
}

void DeleteCategory(Category category)
{
    category.Id = 3;
    var returnDeleteCategory = categoryGeneric.DeleteGeneric(category);

    if (returnDeleteCategory == true)
        Console.WriteLine("Categoria excluida com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel excluir a categoria!");
}

void SelectListCategory()
{
    var returnSelectListCategory = categoryGeneric.SelectGeneric();

    foreach (var category in returnSelectListCategory)
        Console.WriteLine($"{category.Id} - {category.Name}");
}

void SelectCategoryId(int id)
{
    var returnSelectCategoryId = categoryGeneric.SelectIdGeneric(id);

    Console.WriteLine($"{returnSelectCategoryId.Id} - {returnSelectCategoryId.Name}");
}

// ---------------------------------------------------------- CRUD ROLE --------------------------------------------------------------------------

void InsertRole(Role role)
{
    var returnInsertRole = roleGeneric.InsertGeneric(role);

    if (returnInsertRole > 0)
        Console.WriteLine("Role inserido com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel inserir a Role!");
}

void UpdateRole(Role role)
{
    role.Id = 5;
    role.Name = "Autor novo";
    var returnUpdateRole = roleGeneric.UpdateGeneric(role);

    if (returnUpdateRole == true)
        Console.WriteLine("Role alterada com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel alterar a Role!");
}

void DeleteRole(Role role)
{
    role.Id = 5;
    var returnDeleteRole = roleGeneric.DeleteGeneric(role);

    if (returnDeleteRole == true)
        Console.WriteLine("Role excluida com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel excluir a Role!");
}

void SelectListRole()
{
    var returnSelectListRole = roleGeneric.SelectGeneric();

    foreach (var role in returnSelectListRole)
        Console.WriteLine($"{role.Id} - {role.Name}");
}

void SelectRoleId(int id)
{
    var returnSelectRoleId = roleGeneric.SelectIdGeneric(id);

    Console.WriteLine($"{returnSelectRoleId.Id} - {returnSelectRoleId.Name}");
}

// ---------------------------------------------------------- CRUD TAG --------------------------------------------------------------------------

void InsertTag(Tag tag)
{
    var returnInsertTag = tagGeneric.InsertGeneric(tag);

    if (returnInsertTag > 0)
        Console.WriteLine("Tag inserido com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel inserir a Tag!");
}

void UpdateTag(Tag tag)
{
    tag.Id = 3;
    tag.Name = "VB.NET new";
    var returnUpdateTag = tagGeneric.UpdateGeneric(tag);

    if (returnUpdateTag == true)
        Console.WriteLine("Tag alterada com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel alterar a Tag!");
}

void DeleteTag(Tag tag)
{
    tag.Id = 3;
    var returnDeleteTag = tagGeneric.DeleteGeneric(tag);

    if (returnDeleteTag == true)
        Console.WriteLine("Tag excluida com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel excluir a Tag!");
}

void SelectListTag()
{
    var returnSelectListTag = tagGeneric.SelectGeneric();

    foreach (var tag in returnSelectListTag)
        Console.WriteLine($"{tag.Id} - {tag.Name}");
}

void SelectTagId(int id)
{
    var returnSelectTagId = tagGeneric.SelectIdGeneric(id);

    Console.WriteLine($"{returnSelectTagId.Id} - {returnSelectTagId.Name}");
}

// ---------------------------------------------------------- CRUD USER --------------------------------------------------------------------------

void InsertUser(User user)
{
    var returnInsertUser = userRepository.InsertGeneric(user);

    if (returnInsertUser > 0)
        Console.WriteLine("User inserido com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel inserir a User!");
}

void UpdateUser(User user)
{
    user.Id = 9;
    user.Name = "New balta.io";
    var returnUpdateUser = userRepository.UpdateGeneric(user);

    if (returnUpdateUser == true)
        Console.WriteLine("User alterada com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel alterar a User!");
}

void DeleteUser(User user)
{
    user.Id = 9;
    var returnDeleteUser = userRepository.DeleteGeneric(user);

    if (returnDeleteUser == true)
        Console.WriteLine("User excluida com sucesso!!!");
    else
        Console.WriteLine("Não foi possivel excluir a User!");
}

void SelectListUser()
{
    var returnSelectListUser = userRepository.SelectGeneric();

    foreach (var user in returnSelectListUser)
        Console.WriteLine($"{user.Id} - {user.Name}");
}

void SelectUserId(int id)
{
    var returnSelectUserId = userRepository.SelectIdGeneric(id);

    Console.WriteLine($"{returnSelectUserId.Id} - {returnSelectUserId.Name}");
}

void SelectUserWithRole()
{
    var returnSelectUserWithRole = userRepository.SelectUserWithRole();

    foreach (var user in returnSelectUserWithRole)
    {
        Console.WriteLine($"{user.Id} - {user.Name}");
        foreach (var role in user.Roles)
            Console.WriteLine($" -- {role.Id} - {role.Name}");
    }
}