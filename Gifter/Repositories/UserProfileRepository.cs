using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Gifter.Models;
using Gifter.Utils;

namespace Gifter.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }


        //public UserProfile GetByFirebaseUserId(string firebaseUserId)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                SELECT up.Id, Up.FirebaseUserId, up.Name AS UserProfileName, up.Email, up.UserTypeId,
        //                       ut.Name AS UserTypeName
        //                  FROM UserProfile up
        //                       LEFT JOIN UserType ut on up.UserTypeId = ut.Id
        //                 WHERE FirebaseUserId = @FirebaseuserId";

        //            DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

        //            UserProfile userProfile = null;

        //            var reader = cmd.ExecuteReader();
        //            if (reader.Read())
        //            {
        //                userProfile = new UserProfile()
        //                {
        //                    Id = DbUtils.GetInt(reader, "Id"),
        //                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
        //                    Name = DbUtils.GetString(reader, "UserProfileName"),
        //                    Email = DbUtils.GetString(reader, "Email"),
        //                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
        //                    UserType = new UserType()
        //                    {
        //                        Id = DbUtils.GetInt(reader, "UserTypeId"),
        //                        Name = DbUtils.GetString(reader, "UserTypeName"),
        //                    }
        //                };
        //            }
        //            reader.Close();

        //            return userProfile;
        //        }
        //    }
        //}


        public List<UserProfile> GetAllUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT Id, FirebaseUserId, Name, Email, ImageUrl, Bio, DateCreated
                            FROM UserProfile
                        ORDER BY DateCreated";

                    var reader = cmd.ExecuteReader();

                    var users = new List<UserProfile>();
                    while (reader.Read())
                    {
                        users.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Bio = DbUtils.GetString(reader, "Bio"),
                            //UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated")
                        });
                    }

                    reader.Close();

                    return users;
                }
            }
        }


        public UserProfile GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                              SELECT Id, FirebaseUserId, Name, Email, ImageUrl, Bio, DateCreated
                                FROM UserProfile
                               WHERE Id = @Id";



                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    UserProfile user = null;
                    if (reader.Read())
                    {
                        user = new UserProfile()
                        {
                            Id = id,
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Bio = DbUtils.GetString(reader, "Bio"),
                            //UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated")
                        };
                    }

                    reader.Close();

                    return user;
                }
            }
        }

        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                              SELECT Id, FirebaseUserId, Name, Email, ImageUrl, Bio, DateCreated
                                FROM UserProfile
                                WHERE FirebaseUserId = @FirebaseUserId";



                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);


                    UserProfile user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Bio = DbUtils.GetString(reader, "Bio"),
                            //UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated")
                        };

                        reader.Close();

                        return user;
                    }
                }
            }
        }

   public void Add(UserProfile user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO UserProfile (FirebaseUserId, Name, Email, ImageUrl, Bio, DateCreated)
                        OUTPUT INSERTED.ID
                        VALUES (@FirebaseUserId, @Name, @Email, @ImageUrl, @Bio, @DateCreated)";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", user.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@Name", user.Name);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@ImageUrl", user.ImageUrl);
                    DbUtils.AddParameter(cmd, "@Bio", user.Bio);
                    DbUtils.AddParameter(cmd, "@DateCreated", user.DateCreated);

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(UserProfile user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE UserProfile
                           SET 
                               FirebaseUserId = @FirebaseUserId,
                               Name = @Name,
                               Email = @Email,
                               ImageUrl = @ImageUrl,
                               Bio = @Bio,
                               DateCreated = @DateCreated

                         WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", user.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@Name", user.Name);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@ImageUrl", user.ImageUrl);
                    DbUtils.AddParameter(cmd, "@Bio", user.Bio);
                    DbUtils.AddParameter(cmd, "@DateCreated", user.DateCreated);
                    DbUtils.AddParameter(cmd, "@Id", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM UserProfile WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //public Post GetUserByIdWithPostAndComments(int id)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //              SELECT
        //               up.Name, up.Bio, up.Email, up.DateCreated AS UserProfileDateCreated, up.ImageUrl AS UserProfileImageUrl,
        //               p.Id AS PostId, p.Title, p.Caption, p.DateCreated AS PostDateCreated, p.ImageUrl AS PostImageUrl, p.UserProfileId AS PostUserProfileId,
        //               c.Id AS CommentId, c.Message, c.UserProfileId AS CommentUserProfileId

        //          FROM UserProfile up
                      
        //              LEFT JOIN Post p ON p.UserProfileId = up.Id
        //              LEFT JOIN Comment c ON p.UserProfileId = up.Id
        //                   WHERE up.Id = @id";


        //            DbUtils.AddParameter(cmd, "@id", id);

        //            var reader = cmd.ExecuteReader();

        //            UserProfile user = null;


        //            while (reader.Read())
        //            {
        //                var userProfileId = DbUtils.GetInt(reader, "UserProfileId");


        //                if (user == null)
        //                {
        //                    user = new UserProfile()
        //                    {
        //                        Id = userProfileId,
        //                        Name = DbUtils.GetString(reader, "Name"),
        //                        Email = DbUtils.GetString(reader, "Email"),
        //                        DateCreated = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
        //                        ImageUrl = DbUtils.GetString(reader, "UserProfileImageUrl"),

        //                        Post = new Post()
        //                        {
        //                            Title = DbUtils.GetString(reader, "Title"),
        //                            Caption = DbUtils.GetString(reader, "Caption"),
        //                            DateCreated = DbUtils.GetDateTime(reader, "PostDateCreated"),
        //                            ImageUrl = DbUtils.GetString(reader, "PostImageUrl"),
        //                            UserProfileId = DbUtils.GetInt(reader, "PostUserProfileId"),
        //                        },
        //                        Comments = new List<Comment>()

        //                    };
        //                }




        //                if (DbUtils.IsNotDbNull(reader, "CommentId"))
        //                    {
        //                        user.Post.Comments.Add(new Comment()
        //                        {
        //                            Id = DbUtils.GetInt(reader, "CommentId"),
        //                            Message = DbUtils.GetString(reader, "Message"),
        //                            PostId = postId,
        //                            UserProfileId = DbUtils.GetInt(reader, "CommentUserProfileId")
        //                        });
        //                    }
        //                }
                    


        //            reader.Close();
        //            return user;
        //        }
        //    }
        //}




    }
}