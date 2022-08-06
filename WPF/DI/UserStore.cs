using Microsoft.AspNetCore.Identity;

using Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
	public class UserStore : DependencyObject
	{
		public static readonly DependencyProperty CurrentUserProperty =
		DependencyProperty.Register("CurrentUser", typeof(AspNetUser),
		typeof(UserStore), new UIPropertyMetadata(defaultValue: null));

		/// <summary>
		/// Currently logged in <see cref="AspNetUser"/> 
		/// </summary>
		public AspNetUser CurrentUser
		{
			get => (AspNetUser)GetValue(CurrentUserProperty);
			set => SetValue(CurrentUserProperty, value);
		}
		public static UserStore Instance { get; private set; }

		static UserStore()
		{
			Instance = new UserStore();
		}
	}
}
