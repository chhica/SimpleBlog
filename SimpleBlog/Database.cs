using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SimpleBlog
{
    public static class Database
    {
        private static ISessionFactory _sessionFactory;
        private const string SessionKey = "SimpleBlog.Database.SessionKey";
        
        //expose the session so the controllers can use it
        //by using the ISession
        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items[SessionKey]; }
        }

        //invoked at application startapp
        public static void Configure()
        {
            var config = new Configuration();

            //configure the connection string
            config.Configure();
            //add our mappings
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>(); //from User.cs
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
            //create session factory
            _sessionFactory = config.BuildSessionFactory();
        }

        //invoked at the beginning of every request session
        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        //invoked at the end of every session
        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
                session.Close();
            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}