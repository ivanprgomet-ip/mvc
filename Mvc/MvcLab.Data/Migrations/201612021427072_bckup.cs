namespace MvcLab.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bckup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentEntities", "Album_Id", "dbo.AlbumEntities");
            DropForeignKey("dbo.PhotoEntities", "Album_Id", "dbo.AlbumEntities");
            DropForeignKey("dbo.CommentEntities", "Photo_Id", "dbo.PhotoEntities");
            DropForeignKey("dbo.AlbumEntities", "User_Id", "dbo.UserEntities");
            DropForeignKey("dbo.PhotoEntities", "User_Id", "dbo.UserEntities");
            RenameColumn(table: "dbo.CommentEntities", name: "Album_Id", newName: "Album_AlbumId");
            RenameColumn(table: "dbo.PhotoEntities", name: "Album_Id", newName: "Album_AlbumId");
            RenameColumn(table: "dbo.AlbumEntities", name: "User_Id", newName: "User_UserId");
            RenameColumn(table: "dbo.CommentEntities", name: "Photo_Id", newName: "Photo_PhotoId");
            RenameColumn(table: "dbo.PhotoEntities", name: "User_Id", newName: "User_UserId");
            RenameIndex(table: "dbo.AlbumEntities", name: "IX_User_Id", newName: "IX_User_UserId");
            RenameIndex(table: "dbo.CommentEntities", name: "IX_Album_Id", newName: "IX_Album_AlbumId");
            RenameIndex(table: "dbo.CommentEntities", name: "IX_Photo_Id", newName: "IX_Photo_PhotoId");
            RenameIndex(table: "dbo.PhotoEntities", name: "IX_Album_Id", newName: "IX_Album_AlbumId");
            RenameIndex(table: "dbo.PhotoEntities", name: "IX_User_Id", newName: "IX_User_UserId");
            DropPrimaryKey("dbo.AlbumEntities");
            DropPrimaryKey("dbo.CommentEntities");
            DropPrimaryKey("dbo.PhotoEntities");
            DropPrimaryKey("dbo.UserEntities");
            AddColumn("dbo.AlbumEntities", "AlbumId", c => c.Guid(nullable: false));
            AddColumn("dbo.CommentEntities", "CommentId", c => c.Guid(nullable: false));
            AddColumn("dbo.PhotoEntities", "PhotoId", c => c.Guid(nullable: false));
            AddColumn("dbo.UserEntities", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.AlbumEntities", "AlbumId");
            AddPrimaryKey("dbo.CommentEntities", "CommentId");
            AddPrimaryKey("dbo.PhotoEntities", "PhotoId");
            AddPrimaryKey("dbo.UserEntities", "UserId");
            AddForeignKey("dbo.CommentEntities", "Album_AlbumId", "dbo.AlbumEntities", "AlbumId");
            AddForeignKey("dbo.PhotoEntities", "Album_AlbumId", "dbo.AlbumEntities", "AlbumId");
            AddForeignKey("dbo.CommentEntities", "Photo_PhotoId", "dbo.PhotoEntities", "PhotoId");
            AddForeignKey("dbo.AlbumEntities", "User_UserId", "dbo.UserEntities", "UserId");
            AddForeignKey("dbo.PhotoEntities", "User_UserId", "dbo.UserEntities", "UserId");
            DropColumn("dbo.AlbumEntities", "Id");
            DropColumn("dbo.CommentEntities", "Id");
            DropColumn("dbo.PhotoEntities", "Id");
            DropColumn("dbo.UserEntities", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserEntities", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.PhotoEntities", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.CommentEntities", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.AlbumEntities", "Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.PhotoEntities", "User_UserId", "dbo.UserEntities");
            DropForeignKey("dbo.AlbumEntities", "User_UserId", "dbo.UserEntities");
            DropForeignKey("dbo.CommentEntities", "Photo_PhotoId", "dbo.PhotoEntities");
            DropForeignKey("dbo.PhotoEntities", "Album_AlbumId", "dbo.AlbumEntities");
            DropForeignKey("dbo.CommentEntities", "Album_AlbumId", "dbo.AlbumEntities");
            DropPrimaryKey("dbo.UserEntities");
            DropPrimaryKey("dbo.PhotoEntities");
            DropPrimaryKey("dbo.CommentEntities");
            DropPrimaryKey("dbo.AlbumEntities");
            DropColumn("dbo.UserEntities", "UserId");
            DropColumn("dbo.PhotoEntities", "PhotoId");
            DropColumn("dbo.CommentEntities", "CommentId");
            DropColumn("dbo.AlbumEntities", "AlbumId");
            AddPrimaryKey("dbo.UserEntities", "Id");
            AddPrimaryKey("dbo.PhotoEntities", "Id");
            AddPrimaryKey("dbo.CommentEntities", "Id");
            AddPrimaryKey("dbo.AlbumEntities", "Id");
            RenameIndex(table: "dbo.PhotoEntities", name: "IX_User_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.PhotoEntities", name: "IX_Album_AlbumId", newName: "IX_Album_Id");
            RenameIndex(table: "dbo.CommentEntities", name: "IX_Photo_PhotoId", newName: "IX_Photo_Id");
            RenameIndex(table: "dbo.CommentEntities", name: "IX_Album_AlbumId", newName: "IX_Album_Id");
            RenameIndex(table: "dbo.AlbumEntities", name: "IX_User_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.PhotoEntities", name: "User_UserId", newName: "User_Id");
            RenameColumn(table: "dbo.CommentEntities", name: "Photo_PhotoId", newName: "Photo_Id");
            RenameColumn(table: "dbo.AlbumEntities", name: "User_UserId", newName: "User_Id");
            RenameColumn(table: "dbo.PhotoEntities", name: "Album_AlbumId", newName: "Album_Id");
            RenameColumn(table: "dbo.CommentEntities", name: "Album_AlbumId", newName: "Album_Id");
            AddForeignKey("dbo.PhotoEntities", "User_Id", "dbo.UserEntities", "Id");
            AddForeignKey("dbo.AlbumEntities", "User_Id", "dbo.UserEntities", "Id");
            AddForeignKey("dbo.CommentEntities", "Photo_Id", "dbo.PhotoEntities", "Id");
            AddForeignKey("dbo.PhotoEntities", "Album_Id", "dbo.AlbumEntities", "Id");
            AddForeignKey("dbo.CommentEntities", "Album_Id", "dbo.AlbumEntities", "Id");
        }
    }
}
