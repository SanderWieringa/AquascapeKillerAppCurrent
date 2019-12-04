using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Factory
{
    public static class AquascapeDALFactory
    {
        //public static IUserRepository CreateUserRepository()
        //{
        //    return new UserRepository(new UserSQLContext());
        //}

        //public static IUserCollectionRepository CreateUserCollectionDAL()
        //{
        //    return new UserRepository(new UserSQLContext());
        //}

        public static IAquascapeCollectionRepository CreateUserRepository()
        {
            return new AquascapeRepository(new AquascapeSQLContext());
        }

        public static IAquascapeRepository CreateAquascapeRepository()
        {
            return new AquascapeRepository(new AquascapeSQLContext());
        }
    }
}
