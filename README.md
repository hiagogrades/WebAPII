#Inicia o projeto Web APi versão 2
   1 - Adiciona os packages: 
     ~ dotnet add package Microsoft.EntityFrameworkCore.SqLite
     ~ dotnet add package Microsoft.EntityFrameworkCore.Design

#Adiciona a estrutura Model e Data
   2 Instala a ferramenta global do .Ne Entity Framework, para adicionar uma migração (passo seguinte)
      ~ dotnet tool install --global dotnet-ef

   3 Adiciona uma migração
      ~ dotnet ef migrations add InitialCreation

      - Após executar este comando, será criado a pasta Migrations e seus respectivos arquivos:
         - 20220607025224_InitialCreate.cs
         - 20220607025224_InitialCreate.Designer.cs
         - AppDbContextModelSnapshot.cs

#Finaliza o método Get na classe ToDoController
   4 - Cria o método get

#Inicia a gravação em banco e a Injection Dependency
   5 - Acidiona na classe Startup o serviço (Diz que irá trabalhar com um DbContext (banco de dados))
      - services.AddDbContext<AppDbContext>();
   
   6 - Criar os verbos de manipulação de dados (CRUD) 
      6.1 - Cria o método Get com o parâmetro Id
            - [Route(template: "ToDos/{id}")]
   
      6.2 - Cria a estrutura View, a classe CreateToDoViewModel 
         6.2.1 - Cria o método Title e define como required.
      
      6.3 - Cria o método Post
         - [HttpPost(template: "ToDos")]