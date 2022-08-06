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
	public class SideMenuItemDesignModel : SideMenuItemViewModel
	{
		public static SideMenuItemDesignModel Instance => new();

		public SideMenuItemDesignModel()
		{
			Name = "Dashboard";
			IsActive = true;
			IconName = "DashboardIcon";

		}
	}
}
