using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<AwardEditView> Awards { get; set; }
        public IEnumerable<UserEditViewModel> Users { get; set; }
        public IEnumerable<UserAward> UserAwards { get; set; }

        public Award Award { get; set; }
        public User User { get; set; }
        public UserAward UserAward { get; set; }
        public AwardEditView AwardEdit { get; set; }
    }
}
