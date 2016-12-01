namespace MvcLab.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CommentEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateChanged = c.DateTime(nullable: false),
                        Album_Id = c.Guid(),
                        Photo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlbumEntities", t => t.Album_Id)
                .ForeignKey("dbo.PhotoEntities", t => t.Photo_Id)
                .Index(t => t.Album_Id)
                .Index(t => t.Photo_Id);
            
            CreateTable(
                "dbo.PhotoEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        FileName = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateChanged = c.DateTime(nullable: false),
                        UploadedBy = c.String(),
                        Album_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlbumEntities", t => t.Album_Id)
                .ForeignKey("dbo.UserEntities", t => t.User_Id)
                .Index(t => t.Album_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Phone = c.String(),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoEntities", "User_Id", "dbo.UserEntities");
            DropForeignKey("dbo.AlbumEntities", "User_Id", "dbo.UserEntities");
            DropForeignKey("dbo.CommentEntities", "Photo_Id", "dbo.PhotoEntities");
            DropForeignKey("dbo.PhotoEntities", "Album_Id", "dbo.AlbumEntities");
            DropForeignKey("dbo.CommentEntities", "Album_Id", "dbo.AlbumEntities");
            DropIndex("dbo.PhotoEntities", new[] { "User_Id" });
            DropIndex("dbo.PhotoEntities", new[] { "Album_Id" });
            DropIndex("dbo.CommentEntities", new[] { "Photo_Id" });
            DropIndex("dbo.CommentEntities", new[] { "Album_Id" });
            DropIndex("dbo.AlbumEntities", new[] { "User_Id" });
            DropTable("dbo.UserEntities");
            DropTable("dbo.PhotoEntities");
            DropTable("dbo.CommentEntities");
            DropTable("dbo.AlbumEntities");
        }
    }
}
