namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoModelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 70),
                        Descricao = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "Email", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.Exemplars", "BookId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "Nome", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Clientes", "Cpf", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Senha", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Books", "CategoriaId");
            CreateIndex("dbo.Exemplars", "BookId");
            AddForeignKey("dbo.Books", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exemplars", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exemplars", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Exemplars", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "CategoriaId" });
            AlterColumn("dbo.Clientes", "Senha", c => c.String());
            AlterColumn("dbo.Clientes", "Cpf", c => c.String());
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
            DropColumn("dbo.Exemplars", "BookId");
            DropColumn("dbo.Clientes", "Email");
            DropColumn("dbo.Books", "CategoriaId");
            DropTable("dbo.Categorias");
        }
    }
}
