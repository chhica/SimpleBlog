using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }

        public virtual void SetPassword(string password)
        {
            PasswordHash = "123";
        }
    }

    //code based mapping
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("users");
            Id(x => x.Id, x=>x.Generator(Generators.Identity)); //what field and it's incremented automatically 
            //maps it quick bc it's not case sensitive
            Property(x => x.Username, x=> x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.PasswordHash, x => 
                {//explicity we say the name bc they don't match
                    x.Column("password_hash");
                    x.NotNullable(true);
                });
        }
    }
}