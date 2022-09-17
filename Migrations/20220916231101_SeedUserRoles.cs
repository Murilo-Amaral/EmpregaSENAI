using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaSENAI.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        private string RoleEmpresaID = Guid.NewGuid().ToString();
        private string RoleAlunoID = Guid.NewGuid().ToString();
        private string RoleAdminID = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRole(migrationBuilder);

        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [Identity].[Role] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{RoleAdminID}', 'Adm', 'ADM', null);");
            migrationBuilder.Sql($@"INSERT INTO [Identity].[Role] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{RoleEmpresaID}', 'Empresa', 'EMPRESA', null);");
            migrationBuilder.Sql($@"INSERT INTO [Identity].[Role] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{RoleAlunoID}', 'Aluno', 'ALUNO', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO 
            [Identity].[AspNetUsers] (
                [Id],[FirstName],[LastName],[UserName],[NormalizedUserName],[Email]
               ,[NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp]
               ,[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled]
               ,[LockoutEnd],[LockoutEnabled],[AccessFailedCount])
                VALUES
                ('{User1Id}'
               ,'Aluno','LastName','aluno@aluno.com', N'ALUNO@ALUNO.COM' , N'aluno@aluno.com' 
               ,N'ALUNO@ALUNO.COM' , 0
               ,'AQAAAAEAACcQAAAAEGga5LPm+8hjjgb96M3LpqRtanmzN9R/unLrGCXmqpYPDMYvVuXf13lGdtGxmphasg=='
               ,'QFSBEWXRZLALZYQA34SYGYG45I4GA5Z2'
               ,'c7f899f9-4e6b-42ad-9080-a408a884fd7e'
               ,NULL,0,0,NULL,1,0); ");
            migrationBuilder.Sql($@"INSERT INTO 
            [Identity].[AspNetUsers] (
                [Id],[FirstName],[LastName],[UserName],[NormalizedUserName],[Email]
               ,[NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp]
               ,[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled]
               ,[LockoutEnd],[LockoutEnabled],[AccessFailedCount])
                VALUES
                (N'{User2Id}'
               ,N'EMPRESA' , N' Adm' , N'empresa ADM', N'EMPRESA ADM' , N'empresa@empresa.com' 
               ,N'EMPRESA@EMPRESA.COM' , 0 
               ,'AQAAAAEAACcQAAAAEGga5LPm+8hjjgb96M3LpqRtanmzN9R/unLrGCXmqpYPDMYvVuXf13lGdtGxmphasg=='
               ,'QFSBEWXRZLALZYQA34SYGYG45I4GA5Z2' 
               ,'c7f899f9-4e6b-42ad-9080-a408a884fd7e'
               ,NULL
               ,0,0,NULL,1,0);"
            );

        }

        private void SeedUserRole(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
                INSERT INTO [Identity].[UserRoles]
                   ([UserId]
                   ,[RoleId])
                VALUES
                   ('{User1Id}'
                   ,'{RoleAlunoID}');
                INSERT INTO [Identity].[UserRoles]
                   ([UserId]
                   ,[RoleId])
                VALUES
                   ('{User1Id}'
                   ,'{RoleAdminID}');
            ");
            migrationBuilder.Sql(@$"
                INSERT INTO [Identity].[UserRoles]
                   ([UserId]
                   ,[RoleId])
                VALUES
                   ('{User2Id}'
                   ,'{RoleEmpresaID}');
                INSERT INTO [Identity].[UserRoles]
                   ([UserId]
                   ,[RoleId])
                VALUES
                   ('{User2Id}'
                   ,'{RoleAdminID}');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
