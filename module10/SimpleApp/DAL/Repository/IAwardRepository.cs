using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IAwardRepository:IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userID);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userID);
        bool Save();

        IEnumerable<Award> GetAwards();
        Award GetAwardByID(int awardID);
        bool AddAward(Award award);
        bool UpdateAward(Award award);
        bool DeleteAward(int awardID);

        IEnumerable<UserAward> GetUserAwards();
        bool AddUserAward(UserAward userAward);

        IEnumerable<Role> GetRoles();
    }
}
