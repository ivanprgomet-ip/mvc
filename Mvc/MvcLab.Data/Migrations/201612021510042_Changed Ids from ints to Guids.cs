namespace MvcLab.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIdsfromintstoGuids : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentEntities", "Album_AlbumId", "dbo.AlbumEntities");
            DropForeignKey("dbo.PhotoEntities", "Album_AlbumId", "dbo.AlbumEntities");
            DropForeignKey("dbo.AlbumEntities", "User_UserId", "dbo.UserEntities");
            DropForeignKey("dbo.CommentEntities", "Photo_PhotoId", "dbo.PhotoEntities");
            DropForeignKey("dbo.PhotoEntities", "User_UserId", "dbo.UserEntities");
            DropIndex("dbo.AlbumEntities", new[] { "User_UserId" });
            DropIndex("dbo.CommentEntities", new[] { "Album_AlbumId" });
            DropIndex("dbo.CommentEntities", new[] { "Photo_PhotoId" });
            DropIndex("dbo.PhotoEntities", new[] { "Album_AlbumId" });
            DropIndex("dbo.PhotoEntities", new[] { "User_UserId" });
            DropColumn("dbo.AlbumEntities", "UserId");
            DropColumn("dbo.CommentEntities", "AlbumId");
            DropColumn("dbo.CommentEntities", "PhotoId");
            DropColumn("dbo.PhotoEntities", "AlbumId");
            DropColumn("dbo.PhotoEntities", "UserId");
            RenameColumn(table: "dbo.CommentEntities", name: "Album_AlbumId", newName: "AlbumId");
            RenameColumn(table: "dbo.PhotoEntities", name: "Album_AlbumId", newName: "AlbumId");
            RenameColumn(table: "dbo.AlbumEntities", name: "User_UserId", newName: "UserId");
            RenameColumn(table: "dbo.CommentEntities", name: "Photo_PhotoId", newName: "PhotoId");
            RenameColumn(table: "dbo.PhotoEntities", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.AlbumEntities", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.AlbumEntities", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CommentEntities", "PhotoId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CommentEntities", "AlbumId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CommentEntities", "AlbumId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CommentEntities", "PhotoId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PhotoEntities", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PhotoEntities", "AlbumId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PhotoEntities", "AlbumId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PhotoEntities", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.AlbumEntities", "UserId");
            CreateIndex("dbo.CommentEntities", "PhotoId");
            CreateIndex("dbo.CommentEntities", "AlbumId");
            CreateIndex("dbo.PhotoEntities", "UserId");
            CreateIndex("dbo.PhotoEntities", "AlbumId");
            AddForeignKey("dbo.CommentEntities", "AlbumId", "dbo.AlbumEntities", "AlbumId", cascadeDelete: true);
            AddForeignKey("dbo.PhotoEntities", "AlbumId", "dbo.AlbumEntities", "AlbumId", cascadeDelete: true);
            AddForeignKey("dbo.AlbumEntities", "UserId", "dbo.UserEntities", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.CommentEntities", "PhotoId", "dbo.PhotoEntities", "PhotoId", cascadeDelete: true);
            AddForeignKey("dbo.PhotoEntities", "UserId", "dbo.UserEntities", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.CommentEntities", "PhotoId", "dbo.PhotoEntities");
            DropForeignKey("dbo.AlbumEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.PhotoEntities", "AlbumId", "dbo.AlbumEntities");
            DropForeignKey("dbo.CommentEntities", "AlbumId", "dbo.AlbumEntities");
            DropIndex("dbo.PhotoEntities", new[] { "AlbumId" });
            DropIndex("dbo.PhotoEntities", new[] { "UserId" });
            DropIndex("dbo.CommentEntities", new[] { "AlbumId" });
            DropIndex("dbo.CommentEntities", new[] { "PhotoId" });
            DropIndex("dbo.AlbumEntities", new[] { "UserId" });
            AlterColumn("dbo.PhotoEntities", "UserId", c => c.Guid());
            AlterColumn("dbo.PhotoEntities", "AlbumId", c => c.Guid());
            AlterColumn("dbo.PhotoEntities", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhotoEntities", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.CommentEntities", "PhotoId", c => c.Guid());
            AlterColumn("dbo.CommentEntities", "AlbumId", c => c.Guid());
            AlterColumn("dbo.CommentEntities", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.CommentEntities", "PhotoId", c => c.Int(nullable: false));
            AlterColumn("dbo.AlbumEntities", "UserId", c => c.Guid());
            AlterColumn("dbo.AlbumEntities", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PhotoEntities", name: "UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.CommentEntities", name: "PhotoId", newName: "Photo_PhotoId");
            RenameColumn(table: "dbo.AlbumEntities", name: "UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.PhotoEntities", name: "AlbumId", newName: "Album_AlbumId");
            RenameColumn(table: "dbo.CommentEntities", name: "AlbumId", newName: "Album_AlbumId");
            AddColumn("dbo.PhotoEntities", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.PhotoEntities", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.CommentEntities", "PhotoId", c => c.Int(nullable: false));
            AddColumn("dbo.CommentEntities", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.AlbumEntities", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhotoEntities", "User_UserId");
            CreateIndex("dbo.PhotoEntities", "Album_AlbumId");
            CreateIndex("dbo.CommentEntities", "Photo_PhotoId");
            CreateIndex("dbo.CommentEntities", "Album_AlbumId");
            CreateIndex("dbo.AlbumEntities", "User_UserId");
            AddForeignKey("dbo.PhotoEntities", "User_UserId", "dbo.UserEntities", "UserId");
            AddForeignKey("dbo.CommentEntities", "Photo_PhotoId", "dbo.PhotoEntities", "PhotoId");
            AddForeignKey("dbo.AlbumEntities", "User_UserId", "dbo.UserEntities", "UserId");
            AddForeignKey("dbo.PhotoEntities", "Album_AlbumId", "dbo.AlbumEntities", "AlbumId");
            AddForeignKey("dbo.CommentEntities", "Album_AlbumId", "dbo.AlbumEntities", "AlbumId");
        }
    }
}
