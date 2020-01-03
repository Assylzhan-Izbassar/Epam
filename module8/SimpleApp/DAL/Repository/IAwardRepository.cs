using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    interface IAwardRepository:IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userID);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userID);
        void Save();

        IEnumerable<Award> GetAwards();
        Award GetAwardByID(int awardID);
        bool AddAward(Award award);
        bool UpdateAward(Award award);
        bool DeleteAward(int awardID);
    }
}
