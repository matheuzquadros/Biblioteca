namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Livroes", newName: "Books");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Books", newName: "Livroes");
        }
    }
}
