using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SimpleBlog.Migrations
{
    [Migration(1)]
    public class _001_UsersAndRoles : Migration
    {
        /// <summary>
        /// when rollbacking changes to db
        /// </summary>
        public override void Down()
        {
            //first delete all the related tables
            Delete.Table("role_users");
            Delete.Table("roles");
            Delete.Table("users");
        }

        /// <summary>
        /// do modifications to the db
        /// </summary>
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsCustom("VARCHAR(256)")//AsString(256)
                .WithColumn("password_hash").AsString(128);

            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);

            //pivot table to associate users and roles
            //with referencial integrity
            //when a user is deleted, it cascades on the role_users
            Create.Table("role_users")
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(Rule.Cascade);
               
        }
    }
}