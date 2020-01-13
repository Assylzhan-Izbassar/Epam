using System;
using System.Collections.Generic;
using DAL.Models;
using DAL.Staff;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class AwardRepository : IAwardRepository
    {
        private AwardDbContext _awardDbContext;
        private bool Disposed = false;

        public AwardRepository(AwardDbContext dbContext)
        {
            _awardDbContext = dbContext;
        }

        public bool AddAward(Award award)
        {
            if(award != null)
            {
                _awardDbContext.Awards.Add(award);
                return true;
            }
            return false;
        }

        public bool AddUser(User user)
        {
            if(user != null)
            {
                _awardDbContext.Users.Add(user);
                return true;
            }
            return false;
        }

        public bool AddUserAward(UserAward userAward)
        {
            if(userAward != null)
            {
                _awardDbContext.UserAwards.Add(userAward);
                return true;
            }
            return false;
        }

        public bool DeleteAward(int awardID)
        {
            Award award = _awardDbContext.Awards.Find(awardID);
            if (award != null)
            {
                _awardDbContext.Awards.Remove(award);
                return true;
            }
            return false;
        }

        public bool DeleteUser(int userID)
        {
            User user = _awardDbContext.Users.Find(userID);
            if (user != null)
            {
                _awardDbContext.Users.Remove(user);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed && disposing)
            {
                _awardDbContext.Dispose();
            }
            this.Disposed = true;
        }

        public Award GetAwardByID(int awardID)
        {
            return _awardDbContext.Awards.Find(awardID);
        }

        public IEnumerable<Award> GetAwards()
        {
            return _awardDbContext.Awards;
        }

        public User GetUserByID(int userID)
        {
            return _awardDbContext.Users.Find(userID);
        }

        public DbSet<User> GetUsers()
        {
            return _awardDbContext.Users;
        }

        public void Save()
        {
            _awardDbContext.SaveChanges();
        }
        public async void SaveAsync()
        {
            await _awardDbContext.SaveChangesAsync();
        }

        public bool UpdateAward(Award award)
        {
            if(award != null)
            {
                _awardDbContext.Entry(award).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            return false;
        }

        public bool UpdateUser(User user)
        {
            if(user != null)
            {
                _awardDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            return false;
        }

        public IEnumerable<UserAward> GetUserAwards()
        {
            return _awardDbContext.UserAwards;
        }

        public DbSet<Role> GetRoles()
        {
            return _awardDbContext.Roles;
        }
    }
}
