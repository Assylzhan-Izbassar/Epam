using BLL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class WidgetViewModel
    {
        public IList<Category> Categories { get; private set; }

        public WidgetViewModel(DataManager dataManager)
        {
            Categories = (List<Category>)dataManager.Category.GetCategories();
        }
    }
}
