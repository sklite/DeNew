using System.Collections;
using System.Collections.Generic;

namespace DeNew.Models.ViewModels.Interfaces
{
    public interface INavigable
    {
        ICollection<INavigationItem> NavigationItems { get; set; }
    }
}