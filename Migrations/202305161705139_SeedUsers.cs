namespace VidlyDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'14e191f9-5686-41f0-ae8e-2c34d4274ecc', N'admin@vidlydotnet.com', 0, N'AGwfceMvxTbGfsIdOySkIyk0JSSzlMz3k+DvL3qbJS22i1uEOls6rWE7WJy1qgBC7w==', N'774a7a26-d08a-4631-8b9d-56960509ce6b', NULL, 0, 0, NULL, 1, 0, N'admin@vidlydotnet.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e5f30fd-b86d-4756-9740-8f11635445c0', N'guest@vidlydotnet.com', 0, N'ABf0ALxmwTg81HYwo6yKmccxrpa9Nl60wd5JW0rbQp6oKvzzQE8TiYSGBpI87iZt1A==', N'49f567a1-3a79-49e1-a1fc-2da8559e066e', NULL, 0, 0, NULL, 1, 0, N'guest@vidlydotnet.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e80117b1-9db2-4d9c-a14a-cf7e6fa131db', N'michelle.roufail@outlook.com', 0, N'AEAdra+jZYuspkclOWWP0K3BeTOKnmuY+RY9kFuA7RlYQAdpXpfOX8hLn+JcgcdrOw==', N'58fe3f1d-f5a8-4585-a227-af372425ba9e', NULL, 0, 0, NULL, 1, 0, N'michelle.roufail@outlook.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd202fc95-cbf5-4695-97ca-cd23df3d1a8e', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14e191f9-5686-41f0-ae8e-2c34d4274ecc', N'd202fc95-cbf5-4695-97ca-cd23df3d1a8e')

");
        }
        
        public override void Down()
        {
        }
    }
}
