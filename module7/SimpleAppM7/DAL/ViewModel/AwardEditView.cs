using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModel
{
    public class AwardEditView : AwardView
    {
        public int Id { get; set; }
        public string ExistingPath { get; set; }
    }
}
