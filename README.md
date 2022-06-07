#Inicia o projeto Web APi versão 2
 - Adiciona os packages: 
    ~ dotnet add package Microsoft.EntityFrameworkCore.SqLite
    ~ dotnet add package Microsoft.EntityFrameworkCore.Design

#Adiciona a estrutura Model e Data
   - Instala a ferramenta global do .Ne Entity Framework, para adicionar uma migração (passo seguinte)
      ~ dotnet tool install --global dotnet-ef

   - Adiciona uma migração
      ~ dotnet ef migrations add InitialCreation

      - Após executar este comando, será criado a pasta Migrations e seus respectivos arquivos:
         - 20220607025224_InitialCreate.cs
         - 20220607025224_InitialCreate.Designer.cs
         - AppDbContextModelSnapshot.cs

      