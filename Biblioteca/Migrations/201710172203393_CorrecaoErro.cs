namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoErro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Titulo", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Books", "UrlCapa", c => c.String(maxLength: 255));
            AlterColumn("dbo.Books", "Prefacio", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Books", "Autor", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Autor", c => c.String());
            AlterColumn("dbo.Books", "Prefacio", c => c.String());
            AlterColumn("dbo.Books", "UrlCapa", c => c.String());
            AlterColumn("dbo.Books", "Titulo", c => c.String());
        }
    }
}
