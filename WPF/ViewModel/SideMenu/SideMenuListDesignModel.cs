using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
	/// <summary>
	/// 
	/// </summary>
	public class SideMenuListDesignModel : SideMenuListViewModel
	{
		public static SideMenuListDesignModel Instance => new();
		//TODO change icon
		public SideMenuListDesignModel()
		{
			Items = new List<SideMenuItemViewModel>
			{
			new SideMenuItemViewModel
			{
				Name = "Home",
				IsActive = true,
				IconName = "Home"
			},
			new SideMenuItemViewModel
			{
				Name = "Search",
				IsActive = false,
				IconName = "Search"
			},
			new SideMenuItemViewModel
			{
				Name = "Import",
				IsActive = false,
				IconName = "Add"
			}
		};
		}
	}
}
