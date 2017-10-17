namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacaoFormulario : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Isbn", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Isbn", c => c.String());
        }
    }
}
