using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Animation
{
	/// <summary>
	/// Styles of page animations for appearing/disappearing
	/// </summary>
	public enum PageAnimation
	{
		/// <summary>
		/// No animation takes place
		/// </summary>
		None,
		/// <summary>
		/// The page slides in and fades in from the right
		/// </summary>
		SlideAndFadeInFromRight,
		/// <summary>
		/// The page slides out and fades away to the left
		/// </summary>
		SlideAndFadeOutToLeft
	}
}
