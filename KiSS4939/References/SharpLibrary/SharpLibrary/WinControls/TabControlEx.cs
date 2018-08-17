#region Copyright (c) SharpLibrary Inc.
/*
{*******************************************************************}
{                                                                   }
{       Copyright (c) 2003 SharpLibrary Inc.                        }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF SHARPLIBRARY INC. THE REGISTERED DEVELOPER IS        }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM SHARPLIBRARY INC.                           }
{                                                                   }
{                                                                   }
{*******************************************************************}
*/
#endregion Copyright (c) 2003 SharpLibrary Inc.

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

#if DEMO
using Microsoft.Win32;
#endif

using SharpLibrary.Collections;
using SharpLibrary.Designers;
using SharpLibrary.General;
using SharpLibrary.Menus;
using SharpLibrary.Win32;

// Include this file in RELEASE mode only if TAB_CONTROL directive is defined
#if DEBUG || DEMO || TAB_CONTROL

namespace SharpLibrary.WinControls
{
	#region Enumerations
	/// <summary>
	/// Defines the style of the tabs
	/// </summary>
	public enum TabsStyle
	{
		/// <summary>
		/// The property holds no valid style yet. Can be used to mark a property as still having
		/// a default value instead of one assigned by the user.
		/// </summary>
		None,
		/// <summary>
		/// Tabs are drawn like the traditional tabs of the common control library.
		/// </summary>
		Standard,
		/// <summary>
		/// Tabs are drawn using a Visual Studio Tab control style.
		/// </summary>
		Document,
		/// <summary>
		/// Tabs are drawn using a flat look.
		/// </summary>
		Flat,
		/// <summary>
		/// Tabs are using using a flat look and a high contrast selection color.
		/// </summary>
		HighContrast,
		/// <summary>
		/// Tabs are drawn using a look similar to the Office 2003 Suite.
		/// </summary>
		Office2003,
		/// <summary>
		/// Tabs are drawn using the current Windows XP Theme. If not running
		/// on an XP Based system, the tabs look will fall back on the Standard tab style.
		/// When using XPTheme tab style, the border is always 1 pixel. The BorderStyleEx property will
		/// not respond to changes on the style. This is to provide more XPTheme compliance when drawing
		/// the TabControlEx using XPTheme glyphs.
		/// </summary>
		XPTheme,
		/// <summary>
		/// When this style is set, tabs are drawn using the images in the TabsImageList.
		/// If this style is set and the TabsImageList object is null --which is the default-- then
		/// Standard style tabs will drawn.
		/// </summary>
		CustomImages,
		/// <summary>
		/// Tabs are drawn using a similar look to the Microsoft's OneNote application.
		/// Automatic colors are generated for the tabs.
		/// </summary>
		OneNote,
		/// <summary>
		/// Tabs are drawn using a similar look to the Microsoft's OneNote application.
		/// If running under Windows XP and the Luna Style is enabled, the Luna colors are used otherwise
		/// system colors will be used.
		/// </summary>
		OneNoteLuna,
		/// <summary>
		/// Tabs are drawn using a similar look to the Microsoft's OneNote application using only
		/// standard system colors to paint the tabs.
		/// </summary>
		OneNoteSystem
	}


	/// <summary>
	/// Defines the location of the tabs.
	/// </summary>
	public enum TabsLocation
	{
		/// <summary>
		/// Tabs are located at the top of the control.
		/// </summary>
		Top,
		/// <summary>
		/// Tabs are located at the bottom of the control.
		/// </summary>
		Bottom,
		/// <summary>
		/// Tabs are located at the left side of the control.
		/// </summary>
		Left,
		/// <summary>
		/// Tabs are located at the right side of the control.
		/// </summary>
		Right
	}


	/// <summary>
	/// Defines the way the tabs will be drawn so as to fit them within the available are
	/// for the tabs.
	/// </summary>
	public enum TabsFitting
	{
		/// <summary>
		/// Tabs will be shrink so as to use only the needed space if they need less area than
		/// the available area or they will be shrink to an equal size depending on the number of tabs
		/// so as to make them all fit in the tabs area available.
		/// </summary>
		ShrinkTabs,
		/// <summary>
		/// Tabs will preserve the size they need to show their icon and text and the tabs that don't fit
		/// will not be visible but available through arrow controls.
		/// </summary>
		ShowArrows,
		/// <summary>
		/// Tab area will be evenly distribute among the available tabs. This style is meant to be used
		/// when the tabs actually fits within the tab area and there is fact space left that can be redistributed
		/// to the tabs. If the tabs don't fit, the behavior will be similar to the ShrinkTabs fitting.
		/// </summary>
		FullWidth,
		/// <summary>
		/// Tabs are drawn stacked up in several rows.
		/// </summary>
		MultiLine,
		/// <summary>
		/// Tabs are drawn using the width value from the FixedWidth property. If a tab text fits
		/// within a width less that the FixedWidth value, then the tab is drawn using the width needed
		/// for the tab, unless the AlwaysUseFixedWidth property has been set to True. In that case
		/// all tabs are drawn using the same width regardless of the text dimension. When using this
		/// style, the tabs text will show ellipses indicating that the rest of the text does not fit.
		/// If the property ShowFixedWidthTooltip is set to true, moving the mouse over the tab will show
		/// a tooltip only for tabs whose text does not fit within the space available for the tab.
		/// </summary>
		FixedWidth
	}


	/// <summary>
	/// Defines the properties that raise a TabControlExPropertyChange for the <see cref="TabControlEx"/> class.
	/// </summary>
	public enum TabControlExProperty
	{
		/// <summary>
		/// <see cref="TabsStyle"/> for the control.
		/// </summary>
		TabsStyle,
		/// <summary>
		/// <see cref="TabsLocation"/> for the control.
		/// </summary>
		TabsLocation,
		/// <summary>
		/// <see cref="TabsFitting"/> for the control.
		/// </summary>
		TabsFitting,
		/// <summary>
		/// The collection of <see cref="TabPageEx"/> objects in the control.
		/// </summary>
		TabPagesCollection,
		/// <summary>
		/// Currently selected tab index.
		/// </summary>
		SelectedTabIndex,
		/// <summary>
		/// Normal state image list.
		/// </summary>
		ImageList,
		/// <summary>
		/// Selected state image list.
		/// </summary>
		SelectedImageList,
		/// <summary>
		/// Flag whether to show the text for the tabs.
		/// </summary>
		ShowText,
		/// <summary>
		/// Flag whether to show the icons for the tabs.
		/// </summary>
		ShowIcon,
		/// <summary>
		/// Flag whether to show the selected tab text in bold.
		/// </summary>
		ShowSelectedTextBold,
		/// <summary>
		/// The color to be used for the arrow glyphs.
		/// </summary>
		GlyphsColor,
		/// <summary>
		/// The color to be used for the text of the tabs.
		/// </summary>
		TextColor,
		/// <summary>
		/// The hot color to be used for the text of the tabs.
		/// </summary>
		HotTextColor,
		/// <summary>
		/// Flag whether to use hot tracking on mouse for the tabs.
		/// </summary>
		HotTrack,
		/// <summary>
		/// Flag whether to show the close glyph. This is only for the ShowArrows Tab style.
		/// </summary>
		ShowClose,
		/// <summary>
		/// Flag whether to select a tab my mouse move.
		/// </summary>
		HoverSelect,
		/// <summary>
		/// Flag whether to show the text only for the selected tab. ShowText should also be enabled.
		/// </summary>
		ShowOnlySelectedTabText,
		/// <summary>
		/// Enable dragging the tabs to a different position by left clicking the mouse on the tab.
		/// </summary>
		TabDrag,
		/// <summary>
		/// Context menu when a tab is right clicked.
		/// </summary>
		TabControlContextMenu,
		/// <summary>
		/// Prevents the currently selected tab from moving to the front row.
		/// This property is only applicable when the tab control is multiline mode.
		/// Default value is true.
		/// </summary>
		KeepSelectedTabInSameRow,
		/// <summary>
		/// Allows for customization of the colors used to paint the tab. 
		/// The Base color is used to derived light and dark colors --among others-- so that
		/// the tab is painted according to the assumed light source origin.
		/// </summary>
		TabBaseColor,
		/// <summary>
		/// Background color of the tabs area when using the Document Style tabs.
		/// </summary>
		DocumentStyleBackColor,
		/// <summary>
		/// Background color of the tabs area when using a style other than Document Style tabs.
		/// </summary>
		TabsAreaBackColor,
		/// <summary>
		/// Darken the tabs by disregarding the assumed origin
		/// of the light source and painting one border dark instead of light. This property is only applicable
		/// when the control uses standard tabs on the left or top.
		/// </summary>
		IgnoreLightSource,
		/// <summary>
		/// The color to use for the selected tab when the TabStyle is Flat.
		/// </summary>
		FlatStyleSelectedTabColor,
		/// <summary>
		/// The color to use for the border of the selected tab when the TabStyle is Flat.
		/// </summary>
		FlatStyleSelectedTabBorderColor,
		/// <summary>
		/// Enable/disable updating the control when the TabPages collection changes
		/// </summary>
		InvalidateOnTabCollectionChange,
		/// <summary>
		/// Allows to turn off the drawing of the separators between document style rows when 
		/// the tab control is in multiline mode.
		/// </summary>
		DrawDocumentMultilineSeparators,
		/// <summary>
		/// Gradient start color for standard tab style.
		/// </summary>
		GradientStartColor,
		/// Gradient end color for standard tab style.
		GradientEndColor,
		/// <summary>
		/// Enable/Disable navigation of the tabs by using the up, down, left and right keyboard keys.
		/// </summary>
		KeyboardTabsNavigation,
		/// <summary>
		/// If set to true, the class automatically updates the colors used internally
		/// to do its painting when there is a system color change. Default is true.
		/// </summary>
		FollowSystemColorsChange,
		/// <summary>
		/// Width of the tabs when using FixedWidth as the tab fitting mode.
		/// </summary>
		FixedWidth,
		/// <summary>
		/// Tabs whose text and icon fit within a width less that the FixedWidth value will
		/// be drawn using the needed width for the tab instead the FixedWidth value. If this 
		/// property is set to True, all tabs will be drawn using the same width regardless they fit or not.
		/// </summary>
		AlwaysUseFixedWidth,
		/// <summary>
		/// Shows a tooltip for tabs that don't fit within the available width when using
		/// the FixedWidth tab fitting mode. Default value is true.
		/// </summary>
		ShowFixedWidthTooltip,
		/// <summary>
		/// Delay to show a tab tooltip after the tooltip has been hidden. 
		/// Tooltips are available only for the FixedWidth tabs fitting style.
		/// Default value is 500 milliseconds.
		/// </summary>
		ShowDelay,
		/// <summary>
		/// Delay to hide a cab's tooltip after it has been displayed. 
		/// Tooltips are available only for the FixedWidth tabs fitting style.
		/// Default value is 5000 milliseconds.
		/// </summary>
		HideDelay,
		/// <summary>
		/// Indicates whether a focus rectangle should be drawn around the 
		/// active tab page when the Tab control gets the focus.
		/// </summary>
		DrawFocusRectangle,
		/// <summary>
		/// Color used to draw the focus rectangle
		/// </summary>
		FocusRectangleColor,
		/// <summary>
		/// Allows to navigate the tab pages and child controls by using the Tab key alone.
		/// Tabbing will take the user from the current tab page to the child controls to another tab page and
		/// so on until the tabbing gets to the last page and the last control moment on which the tabbing
		/// gets out of the TabControl and to the next available control in the tab order that is a 
		/// peer of the tab control.
		/// </summary>
		EnableExtendedTabKeyNavigation,
		/// <summary>
		/// The margin between the text and the top and bottom bounds of the Tab rectangle.
		/// This property can be used to increase the height of the tab without increasing the
		/// size of the font used to draw the text. Default value is 4 pixels. 
		/// </summary>
		VerticalMargin,
		/// <summary>
		/// An <see cref="ImageListEx"/> object that contains the images used to draw the tabs if the 
		/// <see cref="TabsStyle"/> for the TabControlEx is set to TabsStyle.CustomImages.
		/// Default value is false. If this object is not a valid one and the style for the tabs
		/// is still set to TabsStyle.CustomImages the Standard style tabs will be drawn.
		/// </summary>
		TabsImageList,
		/// <summary>
		/// When this property is set to true and the TabsStyles is XPTheme, the background for 
		/// the tabs pages is painted using the current XP Theme.
		/// Default value is false.
		/// </summary>
		DrawXPThemeTabPagesBackground,
		/// <summary>
		/// Margins used to horizontally and/or vertically stretch the images in the TabsImageList.
		/// The default values is 5s pixel on the left, right, top and bottom.
		/// If the TabsStyle is set to TabsStyle.XPTheme, the background will be drawn using the XPTheme despise
		/// the value of this property.
		/// </summary>
		StretchMargins,
		/// <summary>
		/// The dark color used to draw the top or bottom border of the Tabs. This is the line
		/// that separates the tab area from the TabPages area.
		/// By default a SystemColor is calculated based on the <see cref="BorderStyleEx"/> property of the <see cref="TabControlEx"/>.
		/// By settings this property to a valid color value a customized color can be used.
		/// </summary>
		TabsLineColor,
		/// <summary>
		/// Flag indicating that text on vertical tabs should be drawn horizontally
		/// instead of vertically rotated. Applicable only when using tabs on the left or right side.
		/// Default value is false.
		/// </summary>
		HorizontalText,
		/// <summary>
		/// Flag that indicates that Left tabs should be drawn at the top instead of the bottom when
		/// using Horizontal Text. This property is only applicable when HorizontalText is set to true.
		/// Default value is false.
		/// </summary>
		LeftTabsTop,
		/// <summary>
		/// This unusual property is meant to allow the user to hide the tabs and use the TabControlEx as a mere container
		/// that controls visibility of the TabPages. By default this property is set to false.
		/// </summary>
		HideTabs,
		/// <summary>
		/// The margin between the first tab drawn in the tab control and the appropriate border --depending
		/// of the tabs position-- of the TabControlEx.
		/// Default value is 4 pixel. This value can only range between 0 and 4 pixels. It is basically
		/// added for users that want the first tab to be aligned with the edge of the tab control.
		/// </summary>
		FirstTabMargin
	}


	/// <summary>
	/// Defines the properties that fire a PropertyChange event for the <see cref="TabPageEx"/> class.
	/// </summary>
	public enum TabPageExProperty
	{
		/// <summary>
		/// Title of the tab.
		/// </summary>
		Title,
		/// <summary>
		/// Normal image index for the tab.
		/// </summary>
		ImageIndex,
		/// <summary>
		/// Selected image index for the tab.
		/// </summary>
		SelectedImageIndex,
		/// <summary>
		/// Makes a tab invisible.
		/// </summary>
		HideTab,
		/// <summary>
		/// Allows for customization of the colors used to paint the tab. 
		/// The Base color is used to derived light and dark colors --among others-- so that
		/// the tab is painted according to the assumed light source origin.
		/// </summary>
		TabBaseColor,
		/// <summary>
		/// Text color of the tab
		/// </summary>
		TextColor,
		/// <summary>
		/// Gradient start color for standard tab style.
		/// </summary>
		GradientStartColor,
		/// Gradient end color for standard tab style.
		GradientEndColor,
		/// <summary>
		/// Enable/Disable the TabPageEx.
		/// </summary>
		Enabled
	}


	/// <summary>
	/// Defines the different element in the control that can be hit test.
	/// </summary>
	public enum TabControlHit
	{
		/// <summary>
		/// No known element was hit.
		/// </summary>
		None,
		/// <summary>
		/// A tab was hit.
		/// </summary>
		Tab,
		/// <summary>
		/// The left arrow was hit.
		/// </summary>
		LeftArrow,
		/// <summary>
		/// The right arrow was hit.
		/// </summary>
		RightArrow,
		/// <summary>
		/// The close button was hit.
		/// </summary>
		CloseButton
	}


	enum TabControlGlyphImages
	{
		LeftArrowEnabled,
		LeftArrowDisabled,
		RightArrowEnabled,
		RightArrowDisabled,
		CloseButton
	}

	#endregion

	#region Delegates
	/// <summary>
	/// Signature for the method that handles the TabControlExPropertyChange for the <see cref="TabControlEx"/> class.
	/// </summary>
	public delegate void TabControlExPropertyChangedHandler(TabControlEx tabControl, TabControlExProperty property);
	/// <summary>
	/// Signature for the method that handles the propertyChange for the <see cref="TabPageEx"/> class.
	/// </summary>
	public delegate void TabPageExPropertyChangedHandler(TabPageEx page, TabPageExProperty property);
	/// <summary>
	/// Signature for the method that handles tab change events.
	/// </summary>
	public delegate void TabControlExTabChangeEventHandler(TabPageEx page);
	/// <summary>
	/// Signature for the method that handles the TabPageContextMenu event.
	/// </summary>
	public delegate void TabControlExTabContextMenuHandler(TabControlEx tabControl, TabPageEx page, PopupMenu contextMenu);
	/// <summary>
	/// Signature for the method that handles the ValidateTabClosing event
	/// </summary>
	public delegate void TabControlExTabValidateTabClosingHandler(TabControlEx tabControl, TabPageEx page, TabClosingArgs tca);

	#endregion

	#region Helper Classes
	/// <summary>
	/// This class is used as the argument to the ValidateTabClosing event for the Tab control.
	/// If the CloseTab property of this class is set to false, then the internal code in the
	/// TabControl will ignore the request to close the tab that was set in motion when
	/// the user clicked the close button arrow on the tab control.
	/// </summary>
	public class TabClosingArgs
	{
		#region Class Variables
		bool closeTab = true;
		#endregion
		
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the TabCloseArgs using
		/// using the flag that indicate whether to close the tab or keep it open.
		/// </summary>
		/// <param name="closeTab"></param>
		public TabClosingArgs(bool closeTab)
		{
			this.closeTab = closeTab;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Indicates whether a Tab should be closed or kept open.
		/// </summary>
		public bool CloseTab
		{
			get { return closeTab; }
			set { closeTab = value; }
		}
		#endregion
	}


	/// <summary>
	/// The TabPageEx represent the pages that are in the TabPages collection of the <see cref="TabControlEx"/> class.
	/// </summary>
	[DefaultProperty("Title")]
	[DefaultEvent("PropertyChanged")]
	[ToolboxItem(false)]
#if DEBUG || DEMO
	[Designer(typeof(TabPageExDesigner))]
#endif
	public class TabPageEx : UserControl
	{
		#region Events
		/// <summary>
		/// Raised when a <see cref="TabPageExProperty"/> changes.
		/// </summary>
		public event TabPageExPropertyChangedHandler PropertyChanged;
		#endregion

		#region Class Variables
		// Properties backing variables
		TabControlEx parentTabControl;
		string title = string.Empty;
		int imageIndex = -1;
		int selectedImageIndex = -1;
		internal bool hideTab = false;
		Color tabBaseColor = Color.Empty;
		Color textColor = Color.Empty;
		
		// Gradient support
		Color gradientStartColor = Color.Empty;
		Color gradientEndColor = Color.Empty;

		// Upper left corner where the text was drawn
		Point textPos = Point.Empty;

		// XP Theme support
		IntPtr hTheme = IntPtr.Zero;
        
		// Helpers
		internal Rectangle tabRectangle = Rectangle.Empty;
		internal Rectangle iconRectangle = Rectangle.Empty;

		// xpTheme support
		static Image xpThemeBackground;
		bool xpBitmapSet = false;
		Image previousBitmap;
		#endregion

		#region Constructors
		public TabPageEx()
		{
			InternalConstructor("Page", -1);
		}


		/// <summary>
		/// Initialize a new instance of the TabPageEx class using the title of the tab.
		/// </summary>
		/// <param name="title">Title of the tab.</param>
		public TabPageEx(string title)
		{
			InternalConstructor(title, -1);
		}


		/// <summary>
		/// Initialize a new instance of the TabPageEx class using the
		/// title of the tab and the image index for the icon of the tab.
		/// </summary>
		/// <param name="title">Title of the tab.</param>
		/// <param name="imageIndex">Image index of the icon for the tab.</param>
		public TabPageEx(string title, int imageIndex)
		{
			InternalConstructor(title, imageIndex);
		}


		void InternalConstructor(string title, int imageIndex)
		{
			Debug.Assert(title!=null);
			this.title = title;
			this.imageIndex = imageIndex;
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			// If we are disposing of this page, then release
			// all associated control in the controls collection
			if ( disposing )
			{
				int count = Controls.Count;
				while ( count > 0 )
				{
					Control c = Controls[0];
					c.Dispose();
					count--;
				}
			}

			base.Dispose(disposing);
		}

		#endregion

		#region Overrides
		/// <summary>
		/// Overridden. Please consult the base class documentation for 
		/// information on this method.
		/// </summary>
		protected override void SetBoundsCore(int x, int y, int width, int height,
			BoundsSpecified specified)
		{
			
			base.SetBoundsCore(x,y,width,height,specified);
			if ( WindowsAPI.IsWindowsXPThemeEnabled() )
                ApplyXPThemeLogic();
		}

		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
		}

		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="forward"></param>
		/// <returns></returns>
		protected override bool ProcessTabKey(bool forward) 
		{
			Control ac = ActiveControl;
			bool isChild = Controls.Contains(ac);
			int tabIndex = -1;

			if ( forward )
				tabIndex = GetTabIndex(this, true);
			else
				tabIndex = GetTabIndex(this, false);
			bool validIndex = tabIndex != Int32.MinValue && tabIndex != Int32.MaxValue;

			if ( isChild && validIndex && tabIndex == ac.TabIndex && forward )
			{
				// If the active control was the last control on the tab hierarchy for the page
				// move the focus to the next control on the hierarchy of the parent control
				if ( parentTabControl != null && parentTabControl.EnableExtendedTabKeyNavigation )
				{
					// If supporting the extended tab behavior, then set the focus
					// to the TabControl and change the current selected index to the next one
					if ( parentTabControl.SelectedTabIndex < parentTabControl.TabPages.Count - 1 )
					{
						if ( parentTabControl.IsScrollableTabsStyle() 
							&& parentTabControl.NeedsForceRightPageVisibility(parentTabControl.SelectedTabIndex + 1) )
						{
							parentTabControl.ForceRightSidePageVisible(parentTabControl.SelectedTabIndex + 1);	
						}
						else
						{
							parentTabControl.SelectedTabIndex = parentTabControl.SelectedTabIndex + 1;
						}
						parentTabControl.Focus();
						return true;
					}
					else
						return false;
				}
				else
				{
					return false;
				}
			}
			else if ( isChild && validIndex && tabIndex == ac.TabIndex && !forward  )
			{
				if ( parentTabControl != null && parentTabControl.EnableExtendedTabKeyNavigation )
				{
					// If supporting the extended tab behavior, then set the focus
					// to the TabControl and change the current selected index to the previous tab
					if ( parentTabControl.SelectedTabIndex > 0 )
					{
						parentTabControl.ForceTabKeydFocus = true;
						
						if ( parentTabControl.IsScrollableTabsStyle()
							&& parentTabControl.NeedsForceLeftPageVisibility(parentTabControl.SelectedTabIndex - 1) )
						{
							parentTabControl.ForceLeftSidePageVisible(parentTabControl.SelectedTabIndex - 1);
						}
						else
						{
							parentTabControl.SelectedTabIndex = parentTabControl.SelectedTabIndex - 1;
						}
						
						parentTabControl.Focus();
						return true;
					}
					else
					{
						// Select next control available to receive the focus
						// that is a peer of the tab control.
						Control previousControl = null;
						if ( parentTabControl.Parent != null )
						{
							previousControl = parentTabControl.Parent.GetNextControl(parentTabControl, false);
							// Do it twice so that we can break out of the tab page
							previousControl = parentTabControl.Parent.GetNextControl(previousControl, false);
						}
						if ( previousControl != null )
							previousControl.Focus();
						else
							parentTabControl.Focus();
						return true;
					}
				}
				else
				{
					if ( parentTabControl != null )
						parentTabControl.Focus();
					return true;
				}
			}
			else
			{
				if ( isChild )
				{
					// If we are tabbing from a control that is a direct child of the TabPage
					if ( SelectNextControl(ActiveControl, forward, true, true, true))
						return true;
				}
				else 
				{
					return base.ProcessTabKey(forward);
				}
			}

			return false;
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="m"></param>
		protected override  void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			
			const int WM_THEME_CHANGED = 794;
			if ( m.Msg == WM_THEME_CHANGED )
			{
				if ( hTheme != IntPtr.Zero )
				{
					UxTheme.CloseThemeData(hTheme);
					hTheme = IntPtr.Zero;
				}
			}
		}
		#endregion

		#region Overridables
		/// <summary>
		/// Derived classes should override this method if they
		/// want to change the default behavior when a <see cref="TabPageExProperty"/> changes.
		/// </summary>
		/// <param name="property"></param>
		protected virtual void OnPropertyChanged(TabPageExProperty property)
		{
			// Fire event handlers
			if ( PropertyChanged != null )
				PropertyChanged(this, property);

			// Update UI
			if ( parentTabControl != null )
				parentTabControl.Invalidate();

		}
		#endregion

		#region Properties
		/// <summary>
		/// Enable/Disable the TabPageEx.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description("Enable/Disable the TabPageEx.")]
		public new bool Enabled
		{
			get 
			{ 
				return base.Enabled;
			}

			set
			{
				if ( base.Enabled != value )
				{
					base.Enabled = value;
					OnPropertyChanged(TabPageExProperty.Enabled);	
				}
			}
		}


		/// <summary>
		///  Title of the tab.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description(" Title of the tab")]
		[DefaultValue("Page")]
		public string Title
		{
			get { return title; }
			set 
			{ 
				if ( title != value)
				{
					// Protect against null strings
					if ( value == null )
						value = string.Empty;

					title = value; 
					if ( parentTabControl != null && parentTabControl.TabsFitting == TabsFitting.MultiLine )
						parentTabControl.UpdateMultilineDimensions();

					if ( parentTabControl != null )
					{
						if ( parentTabControl.HorizontalText  && parentTabControl.TabsLocation == TabsLocation.Left 
							||  parentTabControl.TabsLocation == TabsLocation.Right )
						{
							parentTabControl.UpdateTabPagesBounds();
						}
					}

					OnPropertyChanged(TabPageExProperty.Title);
				}
			}
		}


		/// <summary>
		///  Normal image index for the tab.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description(" Normal image index for the tab")]
		[DefaultValue(-1)]
		public int ImageIndex
		{
			get { return imageIndex; }
			set 
			{ 
				if (imageIndex != value)
				{
					imageIndex = value; 

					OnPropertyChanged(TabPageExProperty.ImageIndex);
				}
			}
		}


		/// <summary>
		/// Selected image index for the tab.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description("Selected image index for the tab")]
		[DefaultValue(-1)]
		public int SelectedImageIndex
		{
			get { return selectedImageIndex; }
			set 
			{ 
				if (selectedImageIndex != value)
				{
					selectedImageIndex = value; 

					OnPropertyChanged(TabPageExProperty.SelectedImageIndex);
				}
			}
		}


		/// <summary>
		/// True to make the tab invisible. This is the proper way to make a tab invisible. 
		/// Do not make the tab invisible by setting the <code>Visible</code> property of the base control equal true. 
		/// This will not work in conjunction with the internal logic of the tab control.
		/// Default value is false.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description("Make a tab page invisible while remaining in the TabPages collection")]
		[DefaultValue(false)]
		public bool HideTab
		{
			get { return hideTab; }
			set 
			{ 
				if (hideTab != value)
				{
					hideTab = value;
					tabRectangle = Rectangle.Empty;
					// Make sure that if this was the selected index
					// that we set the new selected index to a valid index
					int selIndex = parentTabControl.SelectedTabIndex;
					int index =  parentTabControl.TabPages.IndexOf(this);
					if ( selIndex == index )
					{
						parentTabControl.SelectedTabIndex = parentTabControl.GetSafeNewSelectedIndexAfterHidingTab(index);
					}

					// Update tab control
					if ( parentTabControl.TabsFitting == TabsFitting.MultiLine )
						parentTabControl.UpdateMultilineDimensions();

					OnPropertyChanged(TabPageExProperty.HideTab);
				}
			}
		}


		/// <summary>
		/// Allows for customization of the colors used to paint the tab. 
		/// The Base color is used to derived light and dark colors --among others-- so that
		/// the tab is painted according to the assumed light source origin.
		/// The tab control itself has the same property but the property in the TabPage will take
		/// precedence over the property in the tab control.
		/// The default value is empty.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description("Allows for customization of the colors used to paint the tab")]
		public Color TabBaseColor
		{
			get { return tabBaseColor; }
			set 
			{ 
				if (tabBaseColor != value)
				{
					tabBaseColor = value;
					OnPropertyChanged(TabPageExProperty.TabBaseColor);
				}
			}
		}

		bool ShouldSerializeTabBaseColor()
		{
			return tabBaseColor != Color.Empty;
		}

		void ResetTabBaseColor()
		{
			TabBaseColor = Color.Empty;
		}


		/// <summary>
		/// Text color of the Tab.
		/// If this value is empty then the TextColor property of the tab
		/// control itself is used, otherwise this value takes precedence. 
		/// Default value is empty.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description("Text color of the Tab")]
		public Color TextColor
		{
			get { return textColor; }
			set 
			{ 
				if (textColor != value)
				{
					textColor = value;
					OnPropertyChanged(TabPageExProperty.TextColor);
				}
			}
		}

		bool ShouldSerializeTextColor()
		{
			return textColor != Color.Empty;
		}

		void ResetTextColor()
		{
			TextColor = Color.Empty;
		}


		/// <summary>
		/// Gradient start color for standard tab style.
		/// Gradient painting takes precedence over the TabBaseColor if both
		/// GradientStartColor and GradientEndColor are both not empty.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description("Gradient start color for standard tab style")]
		public Color GradientStartColor
		{
			get { return gradientStartColor; }
			set 
			{ 
				if (gradientStartColor != value)
				{
					gradientStartColor = value;
					OnPropertyChanged(TabPageExProperty.GradientStartColor);
				}
			}
		}

		bool ShouldSerializeGradientStartColor()
		{
			return gradientStartColor != Color.Empty;
		}

		void ResetGradientStartColor()
		{
			GradientStartColor = Color.Empty;
		}


		/// <summary>
		/// Gradient end color for standard tab style.
		/// Gradient painting takes precedence over the TabBaseColor if both
		/// GradientStartColor and GradientEndColor are both not empty.
		/// </summary>
		[Category("TabPageEx Properties")]
		[Description("Gradient end color for standard tab style")]
		public Color GradientEndColor
		{
			get { return gradientEndColor; }
			set 
			{ 
				if (gradientEndColor != value)
				{
					gradientEndColor = value;
					OnPropertyChanged(TabPageExProperty.GradientEndColor);
				}
			}
		}

		bool ShouldSerializeGradientEndColor()
		{
			return gradientEndColor != Color.Empty;
		}

		void ResetGradientEndColor()
		{
			GradientEndColor = Color.Empty;
		}


		internal Rectangle TabRectangle
		{
			get { return tabRectangle; }
			set { tabRectangle = value; }
		}

		internal Rectangle IconRectangle
		{
			get { return iconRectangle; }
			set 
			{ 
				iconRectangle = value; 
			}
		}

		internal TabControlEx ParentTabControl
		{
			get { return parentTabControl; }
			set 
			{ 
				parentTabControl = value; 
				parentTabControl.TabControlExPropertyChange += new TabControlExPropertyChangedHandler(OnTabControlExPropertyChange);
			}
		}

		internal Point TextPosition
		{
			get { return textPos; }
			set { textPos = value; }
		}
		#endregion

		#region Implementation
		void DrawXPThemeBackground(Graphics g)
		{
			if ( WindowsAPI.IsWindowsXPThemeEnabled() 
				&& parentTabControl != null &&
				(parentTabControl.DrawXPThemeTabPagesBackground || parentTabControl.TabsStyle == TabsStyle.XPTheme) )
			{
				if ( hTheme == IntPtr.Zero )
					hTheme = UxTheme.OpenThemeData(Handle, "TAB");

				if ( hTheme != IntPtr.Zero )
				{
					UxTheme.DrawThemedTabPageBackground(hTheme, g, ClientRectangle);
				}
			}
		}
		internal void PassMsg(ref Message m)
		{
			// To be called from the designer 
			WndProc(ref m);
		}

		int GetTabIndex(Control parent, bool highest)
		{
			// Get the first or last valid control that we can tab to
			int count = parent.Controls.Count;
			int tabIndex = Int32.MinValue;
			if ( !highest )
				tabIndex = Int32.MaxValue;

			for ( int i = 0; i < count; i++ )
			{
				Control c = parent.Controls[i];
				if ( c.TabStop )
				{
					if ( highest )
						tabIndex = Math.Max(tabIndex, c.TabIndex);
					else
						tabIndex = Math.Min(tabIndex, c.TabIndex);
				}
			}

			return tabIndex;
		}

		internal void SetFocusToLastChildControl()
		{
			int tabIndex = GetTabIndex(this, true);
			bool validIndex = tabIndex != Int32.MinValue && tabIndex != Int32.MaxValue;
			if ( validIndex )
			{
				Control c = GetControlFromTabIndex(tabIndex);
				c.Focus();
			}
		}

		Control GetControlFromTabIndex(int tabIndex)
		{
			Control c = null;
			int count = Controls.Count;
			for ( int i = 0; i < count; i++ )
			{
				if ( Controls[i].TabIndex == tabIndex )
				{
					c = Controls[i];
					break;
				}
			}

			Debug.Assert(c!=null);
			return c;
		}

		internal bool IsScrollBarHit(Point pt)
		{
			if ( AutoScroll )
			{
				int scrollBarHeight = SystemInformation.HorizontalScrollBarHeight;
				int scrollBarWidth =  SystemInformation.VerticalScrollBarWidth;
				Rectangle rc = new Rectangle(0, 0, Size.Width, Size.Height);

				Rectangle sbRect = Rectangle.Empty;
				pt = PointToClient(pt);
				if ( HScroll)
				{
					sbRect = new Rectangle(rc.Left, 
						rc.Bottom - scrollBarHeight, rc.Width, scrollBarHeight); 
					if ( sbRect.Contains(pt) )
						return true;
				}

				if ( VScroll)
				{
					sbRect = new Rectangle(rc.Right - scrollBarWidth, 
						rc.Top, scrollBarWidth, rc.Height); 
					if ( sbRect.Contains(pt) )
						return true;
				}
			}

			return false;
		}

		void ApplyXPThemeLogic()
		{
			bool xpTheme = parentTabControl != null && parentTabControl.TabsStyle == TabsStyle.XPTheme 
				&& WindowsAPI.IsWindowsXPThemeEnabled();

			bool force = xpTheme && xpBitmapSet == false;
			if ( xpTheme && ( xpThemeBackground == null  || force 
				|| (xpThemeBackground.Width != Bounds.Width || xpThemeBackground.Height != Bounds.Height) ) )
			{
				if ( Bounds.Width != 0 && Bounds.Height != 0 )
				{
					xpThemeBackground = new Bitmap(Bounds.Width, Bounds.Height);
					Graphics g = Graphics.FromImage(xpThemeBackground);
					DrawXPThemeBackground(g);
					xpBitmapSet = true;
					previousBitmap = BackgroundImage;
					BackgroundImage = xpThemeBackground;
				}
			}
			else if ( !xpTheme )
			{
				BackgroundImage = previousBitmap;
				xpBitmapSet = false;
			}
		}

		void OnTabControlExPropertyChange(TabControlEx tabControl, TabControlExProperty property)
		{
			if ( property == TabControlExProperty.TabsStyle )
				ApplyXPThemeLogic();
		}

		internal bool InvokeOnValidating()
		{
			CancelEventArgs e = new CancelEventArgs(false);
			base.OnValidating(e);
			return e.Cancel;
		}
		#endregion

	}

	internal class TabsRowHelper
	{
		#region Class Variables
		int numberOfTabs = -1;
		bool canAcceptMoreTabs = true;
		int startIndex = -1;
		int endIndex = -1;
		#endregion

		#region Constructor
		public TabsRowHelper(int numberOfTabs)
		{
			this.numberOfTabs = numberOfTabs;
		}
		#endregion

		#region Properties
		public int NumberOfTabs
		{
			get { return numberOfTabs; }
			set { numberOfTabs = value; }
		}

		public bool CanAcceptMoreTabs
		{
			get { return canAcceptMoreTabs;  }
			set { canAcceptMoreTabs = value; }
		}

		public int StartIndex
		{
			get { return startIndex;  }
			set { startIndex = value; }
		}

		public int EndIndex
		{
			get { return endIndex;  }
			set { endIndex = value; }
		}

		#endregion

	}
	#endregion

	/// <summary>
	/// A Tab control that implements the Visual Studio Tab control look as well as other looks
	/// to display the tabs.
	/// </summary>
	[ToolboxItem(true)]
#if DEBUG || DEMO
	[Designer(typeof(SharpLibrary.Designers.TabControlExDesigner))]
#endif
	[DefaultEvent("SelectedTabChanged")]
	[DefaultProperty("SelectedTabIndex")]
	public class TabControlEx : ControlEx
	{
		#region Events
		/// <summary>
		/// Raised when a <see cref="TabControlExProperty"/> changes.
		/// </summary>
		[Category("TabControlEx Events")]
		[Description("Raised when a TabControlExProperty changes")]
		public event TabControlExPropertyChangedHandler TabControlExPropertyChange;

		/// <summary>
		/// Raised when the selected tab changes.
		/// </summary>
		[Category("TabControlEx Events")]
		[Description("Raised when the selected tab changes")]
		public event TabControlExTabChangeEventHandler SelectedTabChanged;

		/// <summary>
		/// Raised when the selected tab changes.
		/// </summary>
		[Category("TabControlEx Events")]
		[Description("Raised when the tab selection is about to change")]
		public event CancelEventHandler SelectedTabChanging;

		/// <summary>
		/// Raised when a tab is about to be closed.
		/// </summary>
		[Category("TabControlEx Events")]
		[Description("Raised when a tab is about to be closed")]
		public event TabControlExTabChangeEventHandler TabClosing;

		/// <summary>
		/// Raised after a tab was closed.
		/// </summary>
		[Category("TabControlEx Events")]
		[Description("Raised after a tab was closed")]
		public event TabControlExTabChangeEventHandler TabClosed;

		/// <summary>
		/// Raised when a tab is right clicked.
		/// </summary>
		[Category("TabControlEx Events")]
		[Description("Raised when a tab is right clicked")]
		public event TabControlExTabContextMenuHandler TabContextMenu;

		/// <summary>
		/// Raised when the internal code in the TabControl needs to know 
		/// if the the target tab should be closed.
		/// The TabClosing event is fired when the user click on the close button
		/// follow by the ValidateTabClosing event. If the user set the TabClose 
		/// property of the TabClosingArgs to false the tab won't be close and the
		/// TabClosed event won't be fired.
		/// </summary>
		[Category("TabControlEx Events")]
		[Description("RRaised when the internal code in the TabControl needs to know "
			 + "if the the target tab should be closed.")]
		public event TabControlExTabValidateTabClosingHandler ValidateTabClosing;
		#endregion

		#region Class Variables
		// Constants
		const int OVERLAPPING_GAP = 4;
		const int DESIGN_TIME_PAGE_GAP = 5;
		const int FIRST_TAB_MARGIN = 4;
        
		// Tabs related
		TabsStyle tabsStyle = TabsStyle.Document;
		TabsLocation tabsLocation = TabsLocation.Bottom;
		TabsFitting tabsFitting = TabsFitting.ShowArrows;
		bool showText = true;
		bool showIcon = true;
		bool showSelectedTextBold = false;
		bool showOnlySelectedTabText = false;
		bool hoverSelect = false;
		bool hideTabs = false;
		int hoverSelectIndex = -1;
		PopupMenu tabControlContextMenu = null;
		bool keyboardTabsNavigation = true;
		bool firstTimeVisible = true;
		bool drawFocusRectangle = false;
		bool enableExtendedTabKeyNavigation = false;
		int verticalMargin = 4;
		ImageListEx tabsImageList = null;
		bool drawXPThemeTabPagesBackground = false;
		bool horizontalText = false;
		bool leftTabsTop = false;
		static Rectangle DEFAULT_MARGINS = new Rectangle(8,8,8,8);
		Rectangle stretchMargins = DEFAULT_MARGINS;
		int tabControlFontHeight = -1;
		int firstTabMargin = FIRST_TAB_MARGIN;
						        
		// Tab dragging support
		bool tabDrag = false;
		int tabDragIndex = -1;
		Rectangle oldTabDragRect = Rectangle.Empty;

		// Margins for icon, tabs and text
		int TAB_AREA_TOP_MARGIN = 2;
		int TAB_AREA_BOTTOM_MARGIN = 2;
		int TAB_LEFT_TEXT_MARGIN = 4;
		int TAB_RIGHT_TEXT_MARGIN = 4;
		int ICON_TO_TEXT_MARGIN = 4;
			
        						
		// Glyphs
		bool updateGlyphsImageList = false;
		ImageListEx glyphsImageList;
		ImageListEx office2003GlyphsImageList;
		Color lastNewColor = Color.Black;
		const int GLYPH_WIDTH = 14;
		const int GLYPH_HEIGHT = 14;
		const int GLYPH_RIGHT_MARGIN = 3;
		Rectangle leftArrowRect = Rectangle.Empty;
		Rectangle rightArrowRect = Rectangle.Empty;
		Rectangle closeRect = Rectangle.Empty;
		bool mouseButtonDownOnGlyph = false;
		TabControlHit currentGlyphHit = TabControlHit.None;

		// Custom color support
		bool followSystemColorsChange = true;
		Color textColor = SystemColors.ControlText;
		Color glyphsColor = ColorUtil.DarkColor(SystemColors.ControlDark, 32);
		Color documentStyleBackColor = ColorUtil.VSNetTabBackgroundColor;
		Color flatStyleSelectedTabColor = ColorUtil.VSNetSelectionColor;
		Color flatStyleSelectedTabBorderColor = ColorUtil.SystemColorsHighlight;
		Color focusRectangleColor = SystemColors.ControlDark;
		Color tabsLineColor = Color.Empty;

		Color hotTextColor = Color.Blue;
		Color tabsAreaBackColor = SystemColors.Control;
		Color tabBaseColor = Color.Empty;
		
		// Gradient support
		Color gradientStartColor = Color.Empty;
		Color gradientEndColor = Color.Empty;

		// Hot Tracking
		bool hotTrack = false;
		int hotTrackIndex = -1;
	        
		// ImageLists support
		int selectedTabIndex = 0;
		ImageListEx imageList = null;
		ImageListEx selectedImageList = null;
                				
		// TabPages Collection
		TabPageExCollection tabPages;

		// ShowArrows support
		int firstVisiblePageIndex = 0;
		int lastVisiblePageIndex = 0;
		bool showClose = true;

		// To optimize painting
		bool invalidateOnPropertyChanged = true;

		// Multiline dimensions helpers
		int[] pageWidthArray = null;
		int numberOfMutilineRows = -1;
		const int MULTILINE_EDGE_MARGIN = 1;
		ArrayList multilineRows;
		bool needRowTableCalculation = true;
		int drawingRowIndex = 0;
		bool keepSelectedTabInSameRow = true;

		// Fixed width support
		int fixedWidth = 100;
		bool alwaysUseFixedWidth = false;
		bool showFixedWidthTooltip = true;

		// Other helpers
		int tabWidth = -1;
		int tabExtraWidth = -1;
		int lastTabRemainder = -1;
		bool drawingGlyphBackground = false;
		bool updateTabPageVisibility = true;
		bool invalidateOnTabCollectionChange = true;
		bool ignoreLightSource = false;
		bool drawDocumentMultilineSeparators = true;
		bool forceTabKeyFocus = false;
		bool handledShowWindowMessage = false;
		bool calculatingRowsTable = false;
		bool addDesignTimeTabPagePadding = true;
					        
		// Tooltip support
		ToolTipEx tooltip;
		int toolTipTargetTabIndex = -1;
		bool tooltipActive = false;
		int showDelay = 500;
		int hideDelay = 5000;
		int indexThatFiredTimer = -1;
		System.Windows.Forms.Timer showToolTipTimer = new System.Windows.Forms.Timer();
		System.Windows.Forms.Timer hideToolTipTimer = new System.Windows.Forms.Timer();

		// XPTheme support
		IntPtr hTheme = IntPtr.Zero;
		Color xpThemeBorderColor = Color.Empty;
#if DEMO
		DateTime releaseDate = new DateTime(2004, 09, 12);
#endif
		#endregion

		#region Constructors
		public TabControlEx()
		{
			// Set styles for control
			SetStyle(ControlStyles.AllPaintingInWmPaint|ControlStyles.ResizeRedraw
				|ControlStyles.UserPaint|ControlStyles.DoubleBuffer, true);
			
			tabPages = new TabPageExCollection();
			tabPages.CollectionChanged += new EventHandler(OnTabCollectionChanged);
			tabPages.InsertStart += new CollectionBaseExChangedEventHandler(OnTabPagesCollectionInsertStart);
			tabPages.RemoveStart += new CollectionBaseExChangedEventHandler(OnTabPagesCollectionRemoveStart);
			tabPages.InsertComplete += new CollectionBaseExChangedEventHandler(OnTabPagesCollectionInsertComplete);
			tabPages.RemoveComplete += new CollectionBaseExChangedEventHandler(OnTabPagesCollectionRemoveComplete);
			tabPages.ClearComplete += new CollectionBaseExClearEventHandler(OnTabPagesCollectionClearComplete);

			// Load glyph image list
			Bitmap image = ResourceUtil.LoadBitmapResource(typeof(SharpLibrary.WinControls.TabControlEx) , "SharpLibrary.Resources.TabControl", "GlyphImages");
			Debug.Assert(image!=null);
			glyphsImageList = new ImageListEx(image, new Size(GLYPH_WIDTH, GLYPH_HEIGHT));
			
			// Update image lists
			UpdateGlyphsImageList();
			UpdateOffice2003GlyphsImageList();

			tooltip = new ToolTipEx();
			// Add the tab control to the tooltip tools
			tooltip.SetTrackingTooltip(this, "TabControlEx");
			
			// Setup initialdelay timer
			showToolTipTimer.Tick += new EventHandler(OnShowToolTip);
			showToolTipTimer.Interval = showDelay;

			// Setup showPopDelay timer
			hideToolTipTimer.Tick += new EventHandler(OnHideToolTip);
			hideToolTipTimer.Interval = hideDelay;

			// This is just a very simple minded way of enforcing 
			// the evaluation time of the library.
			// It is not meant to be a strong protection system. 
			// nor will stop a clever college student that have tons of time on his hands.
			  
			// We don't create a function but repeat this piece of code
			// in several key controls in the library. This makes it harder
			// for someone trying to bypass the time restriction of the library
			// by patching up the binary file of the library. 
#if DEMO
			string controlGUID = "{2BEE6100-AB58-4f17-A1D4-956303E1B945}";
			string controlName = "TabControl";
			string controlHashCode = controlName.GetHashCode().ToString();
			string registryValue = RegistryUtil.ReadFromRegistry(Registry.ClassesRoot, controlGUID, controlHashCode, string.Empty);
			DateTime today = DateTime.Today;

			DateTime rightNow = DateTime.Now;
			DateTime maxDate = new DateTime(9998, 12, 31);
			DateTime twoMonthsLater = releaseDate.AddMonths(2);
			if ( rightNow < releaseDate || rightNow > twoMonthsLater )
			{
				if ( rightNow < releaseDate )
					RegistryUtil.WriteToRegistry(Registry.ClassesRoot, controlGUID, controlHashCode, maxDate.ToString());
				if ( rightNow < releaseDate )
					MessageBox.Show("Sharplibrary evaluation period has expired. No clock rolling backs allowed.");
				else
					MessageBox.Show("Sharplibrary evaluation period has expired.");
				return;
			}
						
			if ( registryValue == string.Empty )
			{
				// Probably first time getting this value
				RegistryUtil.WriteToRegistry(Registry.ClassesRoot, controlGUID, controlHashCode, today.ToString());
			}
			else
			{
				DateTime dt = DateTime.Parse(registryValue);
				if ( dt == maxDate )
				{
					MessageBox.Show("Sharplibrary evaluation period has expired. Would you give it up!");
					return;
				}

				dt = dt.AddDays(15);
				// Check if it has been a week since the first time this class was used
				if ( today > dt )
					MessageBox.Show("Sharplibrary evaluation period has expired");
			}
#endif

		}


		/// <summary>
		/// Makes sure resources held by the ButtonEx are destroyed.
		/// </summary>
		~TabControlEx()
		{
			if ( hTheme != IntPtr.Zero )
				UxTheme.CloseThemeData(hTheme);
		}
		#endregion

		#region Overrides
		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnFontChanged(EventArgs e) 
		{
			base.OnFontChanged(e);
			tabControlFontHeight = -1;
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSystemColorsChanged(EventArgs e)
		{
			base.OnSystemColorsChanged(e);
			updateGlyphsImageList = true;
			if ( followSystemColorsChange )
			{
				textColor = SystemColors.ControlText;
				glyphsColor = ColorUtil.DarkColor(SystemColors.ControlDark, 32);
				documentStyleBackColor = ColorUtil.VSNetTabBackgroundColor;
				flatStyleSelectedTabColor = ColorUtil.VSNetSelectionColor;
				flatStyleSelectedTabBorderColor = ColorUtil.SystemColorsHighlight;
				focusRectangleColor = SystemColors.ControlDark;
			}
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="pe"></param>
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Graphics g = pe.Graphics;
			if ( hideTabs == false )
                DrawBackground(g);
			DrawBorder(g);
			if ( hideTabs == false )
			{
				if ( HasHorizontalTabs() )
				{
					if ( ClientRectangle.Height >= TabsAreaHeight && tabPages.Count > 0)
						DrawTabs(g);
				}
				else
				{
					if ( ClientRectangle.Width >= TabsAreaHeight && tabPages.Count > 0)
						DrawTabs(g);
				}

				DrawGlyphs(g);
			}
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if ( tabsFitting == TabsFitting.MultiLine )
			{
				if ( ClientRectangle.Width != 0 && ClientRectangle.Height != 0 )
				{
					needRowTableCalculation = true;
					CalculateRowsTable(null);
				}
			}

			UpdateTabPagesBounds();
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="borderStyle"></param>
		protected override void SetBorderStyle(BorderStyleEx borderStyle)
		{
			// Don't let the base class to actually set the border style
			// we are going to fake it ourselves in an reduced area of the control
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);																											
			if ( e.Button == MouseButtons.Left )
				ProcessMouseDown(e);
			else if ( e.Button == MouseButtons.Right )
				ProcessContextMenu(e);
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if ( e.Button == MouseButtons.Left )
				ProcessMouseUp(e);
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			ProcessMouseMove(e);
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			mouseButtonDownOnGlyph = false;
			currentGlyphHit = TabControlHit.None;
			DrawDoubleBufferedGlyphs();

			if ( hotTrack && hotTrackIndex >= 0 && hotTrackIndex < tabPages.Count )
			{
				int previousHotTrack = hotTrackIndex;
				hotTrackIndex = -1;
				TabPageEx page = tabPages[previousHotTrack];
				DrawDoubleBufferedTab(page);
			}
			
			// In case a tooltip is up, close it
			if ( tabsFitting == TabsFitting.FixedWidth && tooltipActive )
			{
				tooltipActive = false;
				tooltip.HideTrackingToolTip(this);
			}

			// This gets reset every time the mouse leave the control
			toolTipTargetTabIndex = -1;

		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="property"></param>
		protected override void OnPropertyChanged(ControlExProperty property)
		{
			base.OnPropertyChanged(property);
			if ( property == ControlExProperty.BorderStyleEx  )
			{
				UpdateTabPagesBounds();
			}
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if ( Visible )
			{
				UpdateTabPagesBounds();
				UpdateTabPagesVisibility();

				if ( firstTimeVisible )
				{
					// Make sure the multirows are calculated right because
					// it is possible the right calculation was not picked up right
					// if the text for the tabs was changed after the TabsFitting property was
					// set to Multiline and/or the SizeChanged event was called before the property
					// was set to Multiline
					firstTimeVisible = false;
					if ( tabsFitting == TabsFitting.MultiLine )
					{
						needRowTableCalculation = true;
						CalculateRowsTable(null);
					}
				}
			}
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool IsInputKey(Keys keyData)
		{
			bool result = base.IsInputKey(keyData);
			if ( keyboardTabsNavigation )
			{
				if ( keyData == Keys.Up || keyData == Keys.Down 
					|| keyData == Keys.Left || keyData == Keys.Right )
					return true;
			}

			return result;
		}

		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="charCode"></param>
		/// <returns></returns>
		protected override bool ProcessMnemonic(char charCode)
		{
			if ( ProcessShortcut(charCode) )
				return true; 
						
			return base.ProcessMnemonic(charCode); 
		}
    
		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if ( IsFocusGainedThroughTabKey(e) )
				Invalidate();
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			ProcessKeyEvent(e.KeyCode);
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		protected override bool ProcessDialogKey(Keys key) 
		{
			if ( (key & Keys.Tab) != 0 )
			{
				// Only if pressing the shift key
				bool shift = (key & Keys.Shift)!=0;
				if ( shift && enableExtendedTabKeyNavigation )
				{
					ProcessKeyEvent(key);
					return false;
				}
			}
			        
			return base.ProcessDialogKey(key);
		}


		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
		}
		
		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			Invalidate();
		}

		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		/// <param name="m"></param>
		protected override  void WndProc(ref Message m)
		{
			if ( !DrawUtil.IsValidWindowObject(this) )
				return;            

			base.WndProc(ref m);
			
			const int WM_THEME_CHANGED = 794;
			if ( m.Msg == (int)Msg.WM_SHOWWINDOW && firstTimeVisible )
			{
				// If the tab control is not added to the control
				// collection of the main form but popped later by other
				// means, then we don't get the OnVisibleChanged call.
				// So we make sure that code runs from here:
				if ( !handledShowWindowMessage && (int)m.WParam == 1 )
				{
					// Skip if in the middle of the calculation of the rows table
					if ( calculatingRowsTable)
						return;

					handledShowWindowMessage = true;
					OnVisibleChanged(EventArgs.Empty);
				}
			}
			else if ( m.Msg == WM_THEME_CHANGED )
			{
				if ( hTheme != IntPtr.Zero )
				{
					UxTheme.CloseThemeData(hTheme);
					hTheme = IntPtr.Zero;
				}
			}
		}

		/// <summary>
		/// Overridden. Please consult the base class documentation for information on this method.
		/// </summary>
		protected override ControlCollection CreateControlsInstance()
		{
			SafeTypeControlCollection stc =  new SafeTypeControlCollection(this, Type.GetType("SharpLibrary.WinControls.TabPageEx"),
				Type.GetType("SharpLibrary.WinControls.TabControlEx"));
			return stc;
		}

		#endregion

		#region Overridables
		/// <summary>
		/// Derived classes should override this method if they want
		/// to change the default behavior when a <see cref="TabControlExProperty"/> changes.
		/// </summary>
		/// <param name="property"></param>
		protected virtual void OnPropertyChanged(TabControlExProperty property)
		{
			if ( TabControlExPropertyChange != null )
				TabControlExPropertyChange(this, property);
				
			// Invalidate the control to synch the UI with the control state
			if ( invalidateOnPropertyChanged )
				Invalidate();
		}

		/// <summary>
		/// Fires the SelectTabChange event.
		/// </summary>
		/// <param name="page"></param>
		protected virtual void OnSelectedTabChanged(TabPageEx page)
		{
			if ( SelectedTabChanged != null && page != null )
			{
				SelectedTabChanged(page);
			}
		}

		/// <summary>
		/// Fires the SelectTabChanging event.
		/// </summary>
		/// <param name="page"></param>
		protected virtual void OnSelectedTabChanging(object sender, CancelEventArgs e)
		{
			if ( SelectedTabChanging != null && selectedTabIndex > -1)
			{
				SelectedTabChanging(sender, e);
			}
		}

		/// <summary>
		/// Fires the TabClosing event.
		/// </summary>
		/// <param name="page"></param>
		protected virtual void OnTabClosing(TabPageEx page)
		{
			if ( TabClosing != null )
			{
				TabClosing(page);
			}
		}


		/// <summary>
		/// Fires the ValidateTabClosing event.
		/// </summary>
		/// <param name="page">TabPage to be validated.</param>
		protected virtual bool OnValidateTabClosing(TabPageEx page)
		{
			if ( ValidateTabClosing != null )
			{
				TabClosingArgs tca = new TabClosingArgs(true);
				ValidateTabClosing(this, page, tca);
				return tca.CloseTab;
			}

			return true;

		}


		/// <summary>
		/// Fires the TabClosed event. 
		/// </summary>
		/// <param name="page"></param>
		protected virtual void OnTabClosed(TabPageEx page)
		{
			if ( TabClosed != null )
			{
				TabClosed(page);
			}
		}


		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		protected virtual void OnCloseButtonClicked()
		{
			// Remove the page only if it is within valid range
			int index = selectedTabIndex;
			if ( index != -1 && index < tabPages.Count )
			{
				TabPageEx selectedPage = SelectedTab;
				OnTabClosing(selectedPage);

				// Only if the user did not stop the close event
				// from happening during validation
				if ( OnValidateTabClosing(selectedPage) )
				{
					tabPages.RemoveAt(index);
					OnTabClosed(selectedPage);

					// Set new selected index
					UpdateTabPagesVisibility();
					Invalidate();
				}
			}
		}


		/// <summary>
		/// Called when the left arrow is clicked.
		/// </summary>
		protected virtual void OnLeftArrowClicked()
		{
			int firstIndex = firstVisiblePageIndex-1;
			if ( firstIndex >= 0 )
			{
				firstVisiblePageIndex--;
				Invalidate();
			}
		}


		/// <summary>
		/// Called when the right arrow is clicked.
		/// </summary>
		protected virtual void OnRightArrowClicked()
		{
			int firstIndex = firstVisiblePageIndex+1;
			if ( firstIndex < tabPages.Count - 1 )
			{
				firstVisiblePageIndex++;
				Invalidate();
			}
		}


		/// <summary>
		/// Called when a tab is right clicked and right before the context menu
		/// is displayed.
		/// </summary>
		protected virtual void OnTabPageContextMenu(Point pos, TabPageEx page)
		{
			if ( TabContextMenu != null )
			{
				TabContextMenu(this, page, tabControlContextMenu);
			}
			
			if ( tabControlContextMenu != null )
			{
				tabControlContextMenu.Show(this, pos);
			}
		}


		/// <summary>
		/// This methods updates the visibility of the TabPages collection.
		/// </summary>
		protected virtual void UpdateTabPagesVisibility()
		{
			if ( updateTabPageVisibility == false ) return;

			// Make every page invisible and the selected index visible
			for ( int i = 0; i < tabPages.Count; i++ )
			{
				TabPageEx tabPage = tabPages[i];
				if ( i == selectedTabIndex )
				{
					if ( tabPage.Visible == false )
					{
						tabPage.Visible = true;
						if ( keyboardTabsNavigation == false )
						{
							SetTabPageFocus(tabPage);
						}
					}
				}
				else
				{
					if ( tabPage.Visible == true )
					{
						// Before settings the Visible property to false
						// we need to transfer the focus to the current active tab
						// so that setting the Visible = false here does not transfer the focus
						// to the TabControl which causes flickering since the focus
						// will have to go back to the current TabPageEx anyway
						if ( selectedTabIndex != -1 && selectedTabIndex < tabPages.Count )
						{
							TabPageEx selectedTab = tabPages[selectedTabIndex];
							if ( selectedTab.Visible == false )
								selectedTab.Visible = true;
							if ( keyboardTabsNavigation == false )
							{
								SetTabPageFocus(selectedTab);
							}
						}

						tabPage.Visible = false;
					}
				}
			}

			if ( keyboardTabsNavigation )
				Focus();

		}


		/// <summary>
		/// Allows to intercept the setting of the focus for a TabPageEx in a derived class
		/// This method is called the the current tab index changes and the new currently
		/// selected tab page is about to receive focus.
		/// </summary>
		/// <param name="tabPage">The <see cref="TabPageEx"/> object that will receive focus.</param>
		protected virtual void SetTabPageFocus(TabPageEx tabPage)
		{
			tabPage.Focus();
		}

		#endregion

		#region Properties
		/// <summary>
		/// The margin between the first tab drawn in the tab control and the appropriate border --depending
		/// of the tabs position-- of the TabControlEx.
		/// Default value is 4 pixel. This value can only range between 0 and 4 pixels. It is basically
		/// added for users that want the first tab to be aligned with the edge of the tab control.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("The margin between the first tab drawn in the tab control and the appropriate border")]
		[DefaultValue(FIRST_TAB_MARGIN)]
		public int FirstTabMargin
		{
			get { return firstTabMargin; }
			set
			{
				if ( firstTabMargin != value && value >= 0 && value <= FIRST_TAB_MARGIN )
				{ 
					firstTabMargin = value;
					OnPropertyChanged(TabControlExProperty.FirstTabMargin);
				}
			}
		}


		/// <summary>
		/// This unusual property is meant to allow the user to hide the tabs and use the TabControlEx as a mere container
		/// that controls visibility of the TabPages. By default this property is set to false.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("This unusual property is meant to allow the user to hide the tabs and use the TabControlEx as a mere container")]
		[DefaultValue(false)]
		public bool HideTabs
		{
			get { return hideTabs; }
			set
			{
				if ( hideTabs != value )
				{ 
					hideTabs = value;
					UpdateTabPagesBounds();
					OnPropertyChanged(TabControlExProperty.HideTabs);
				}
			}
		}


		/// <summary>
		/// Flag that indicates that Left tabs should be drawn at the top instead of the bottom when
		/// using Horizontal Text. This property is only applicable when HorizontalText is set to true.
		/// Default value is false.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Flag that indicates that Left tabs should be drawn at the top instead of the bottom")]
		[DefaultValue(false)]
		public bool LeftTabsTop
		{
			get { return leftTabsTop; }
			set
			{
				if ( leftTabsTop != value )
				{ 
					leftTabsTop = value;
					UpdateTabPagesBounds();
					OnPropertyChanged(TabControlExProperty.LeftTabsTop);
				}
			}
		}


		/// <summary>
		/// Flag that indicates that text on vertical tabs should be drawn horizontally
		/// instead of vertically rotated. Applicable only when using tabs on the left or right side.
		/// Default value is false.
		/// </summary>
		/// <remarks>Caveats: when using horizontal text instead of the standard left rotated or right rotated text, 
		/// some properties might not work the same as before. If using horizontal text all TabsFitting styles have not much 
		/// of an impact on the look and way the tabs are fitted. The reason for this is that the logic for fitting 
		/// the tabs is based on the tabs flowing one after another. If the tabs are stacked up one upon the other, 
		/// as it is the case when using horizontal text,  fitting that works on tabs from left to right or from top 
		/// to bottom does not make sense anymore. You can still use TabsFitting styles to at least get an style that 
		/// will allow the hiding or showing of the close and arrow buttons. Multilines are not supported when using 
		/// horizontal text. Allowing for multiple lines while using horizontal text will easily cause a depletion 
		/// of the space assigned to the TabPages themselves as well as being unpleasant to the eye. The ShowOnlySelectedTabText 
		/// is no supported when using horizontal text. Since all tabs have the size of the tab with the longest string, 
		/// setting the ShowOnlySelectedTabText property to true will not cause the other tabs decrease in size as it is the case 
		/// when not using horizontal text. When using Standard style tabs on the left combined with horizontal text, the visual feedback
		/// for the selected tab might not be as noticeable as before since the edge that grows if not as much as before. We advise
		/// setting the ShowSelectionBold property to true and alternately setting the IgnoreLightSource property to true to increase
		/// the selected tab visual feedback. Since multiline is not supported, adding more tabs that can be fitted in a row will cause
		/// the extra tabs be clipped. You should use a style that shows the arrow buttons if you are to add more tabs that can be fitted
		/// on a row.</remarks>
		[Category("TabControlEx Properties")]
		[Description("Flag that indicates that text on vertical tabs should be drawn horizontally")]
		[DefaultValue(false)]
		public bool HorizontalText
		{
			get { return horizontalText; }
			set
			{
				if ( horizontalText != value )
				{ 
					horizontalText = value;
					UpdateTabPagesBounds();
					OnPropertyChanged(TabControlExProperty.HorizontalText);
				}
			}
		}


		/// <summary>
		/// The dark color used to draw the top or bottom border of the Tabs. This is the line
		/// that separates the tab area from the TabPages area.
		/// By default a SystemColor is calculated based on the <see cref="BorderStyleEx"/> property of the <see cref="TabControlEx"/>.
		/// By settings this property to a valid color value a customized color can be used.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("The dark color used to draw the top or bottom border of the Tabs")]
		public Color TabsLineColor
		{
			get 
			{
				if ( tabsLineColor != Color.Empty )
					return tabsLineColor;
				else
					return GetLineDarkDarkColor();
			}

			set
			{
				if ( tabsLineColor != value )
				{
					tabsLineColor = value;
					OnPropertyChanged(TabControlExProperty.StretchMargins);
				}
			}
		}

		bool ShouldSerializeTabsLineColor()
		{
			return tabsLineColor != Color.Empty;
		}
        
		void ResetTabsLineColor()
		{
			TabsLineColor = Color.Empty;
		}


		/// <summary>
		/// Margins used to horizontally and/or vertically stretch the images in the TabsImageList.
		/// The default values is 8 pixels on the left, right, top and bottom.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Margins used to horizontally and/or vertically stretch the images in the TabsImageList")]
		public Rectangle StretchMargins
		{
			get { return stretchMargins; }
			set
			{
				if ( stretchMargins != value )
				{ 
					stretchMargins = value;
					OnPropertyChanged(TabControlExProperty.StretchMargins);
				}
			}
		}

		bool ShouldSerializeStretchMargins()
		{
			return !stretchMargins.Equals(DEFAULT_MARGINS);
		}

		void ResetStretchMargins()
		{
			StretchMargins = DEFAULT_MARGINS;
		}


		/// <summary>
		/// When this property is set to true and the TabsStyles is XPTheme, the background for 
		/// the tabs pages is painted using the current XP Theme.
		/// Default value is false.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("If set to true and the TabsStyle is XPTheme, the background for the tab pages is painted using " +
			 "the current XPTheme")]
		[DefaultValue(false)]
		public bool DrawXPThemeTabPagesBackground
		{
			get { return drawXPThemeTabPagesBackground; }
			set
			{
				if ( drawXPThemeTabPagesBackground != value )
				{ 
					drawXPThemeTabPagesBackground = value;
					OnPropertyChanged(TabControlExProperty.DrawXPThemeTabPagesBackground);
				}
			}
		}


		/// <summary>
		/// An <see cref="ImageListEx"/> object that contains the images used to draw the tabs if the 
		/// <see cref="TabsStyle"/> for the TabControlEx is set to TabsStyle.CustomImages.
		/// Default value is false. If this object is not a valid one and the style for the tabs
		/// is still set to TabsStyle.CustomImages the Standard style tabs will be drawn.
		/// </summary>
		/// <remarks>The images for the ImageListEx object needs to be layout horizontally and contains at least
		/// four images in the order of the DrawState enumeration: Normal, Hot, Pressed, and Disable.
		/// Currently the image will be correctly stretched horizontally by leaving 5 pixel margin on the left side
		/// and a 5 pixel margin on the right side. Thus is possible to have rounded corner on the left and right side
		/// of the images. </remarks>
		[Category("TabControlEx Properties")]
		[Description("Contains the images used to draw the tabs when the TabsStyle is set to CustomImages")]
		[DefaultValue(null)]
		public ImageListEx TabsImageList 
		{
			get { return tabsImageList; }
			set
			{
				if (  tabsImageList !=  value )
				{
					tabsImageList = value;
					OnPropertyChanged(TabControlExProperty.TabsImageList);
				}
			}
		}


		/// <summary>
		/// The margin between the text and the top and bottom bounds of the Tab rectangle.
		/// This property can be used to increase the height of the tab without increasing the
		/// size of the font used to draw the text. Default value is 4 pixels. 
		/// </summary>		
		[Category("TabControlEx Properties")]
		[Description("The margin between the text and the top and bottom bounds of the Tab rectangle")]
		[DefaultValue(4)]
		public int VerticalMargin 
		{
			get { return verticalMargin; }
			set
			{
				if ( verticalMargin != value && value >= 0)
				{
					verticalMargin = value;
					UpdateTabPagesBounds();
					OnPropertyChanged(TabControlExProperty.VerticalMargin);
				}
			}
		}


		/// <summary>
		/// Allows to navigate the tab pages and child controls by using the Tab key alone.
		/// Tabbing will take the user from the current tab page to the child controls to another tab page and
		/// so on until the tabbing gets to the last page and the last control moment on which the tabbing
		/// gets out of the TabControl and to the next available control in the tab order that is a 
		/// peer of the tab control. Default value is false.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Allows to navigate the tab pages and child controls by using the Tab key alone")]
		[DefaultValue(false)]
		public bool EnableExtendedTabKeyNavigation
		{
			get { return enableExtendedTabKeyNavigation; }
			set
			{
				if ( enableExtendedTabKeyNavigation != value )
				{ 
					enableExtendedTabKeyNavigation = value;
					OnPropertyChanged(TabControlExProperty.EnableExtendedTabKeyNavigation);
				}
			}
		}


		/// <summary>
		/// Color used to draw the focus rectangle
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Color used to draw the focus rectangle")]
		public Color FocusRectangleColor
		{
			get { return focusRectangleColor; }
			set
			{
				if ( focusRectangleColor != value )
				{ 
					focusRectangleColor = value;
					OnPropertyChanged(TabControlExProperty.FocusRectangleColor);
				}
			}
		}

		bool ShouldSerializeFocusRectangleColor()
		{
			return focusRectangleColor != SystemColors.ControlDark;
		}

		void ResetFocusRectangleColor()
		{
			FocusRectangleColor = SystemColors.ControlDark;
		}


		/// <summary>
		/// Indicates whether a focus rectangle should be drawn around the 
		/// active tab page when the Tab control gets the focus.
		/// </summary>
		/// <value> A bool value. Default value is false.</value>
		[Category("TabControlEx Properties")]
		[Description("Indicates whether a focus rectangle should be drawn")]
		[DefaultValue(false)]
		public bool DrawFocusRectangle 
		{
			get { return drawFocusRectangle; }
			set
			{
				if ( drawFocusRectangle != value )
				{
					drawFocusRectangle = value;
					OnPropertyChanged(TabControlExProperty.DrawFocusRectangle);
				}
			}
		}


		/// <summary>
		/// Delay to show a cab's tooltip after the tooltip has been hidden. 
		/// Tooltips are available only for the FixedWidth tabs fitting style.
		/// Default value is 500 milliseconds.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Delay to show a cab's tooltip after the tooltip has been hidden")]
		[DefaultValue(500)]
		public int ShowDelay 
		{
			get { return showDelay; }
			set
			{
				if ( showDelay != value )
				{
					showDelay = value;
					
					// Update show timer
					bool running = true;
					if ( showToolTipTimer.Enabled)
						showToolTipTimer.Stop();
					showToolTipTimer.Interval = value;
					if ( running )
						showToolTipTimer.Start();

					OnPropertyChanged(TabControlExProperty.ShowDelay);
				}
			}
		}


		/// <summary>
		/// Delay to hide a cab's tooltip after it has been displayed. 
		/// Tooltips are available only for the FixedWidth tabs fitting style.
		/// Default value is 5000 milliseconds.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Delay to show a cab's tooltip after the tooltip has been hidden")]
		[DefaultValue(5000)]
		public int HideDelay 
		{
			get { return hideDelay; }
			set
			{
				if ( hideDelay != value )
				{
					hideDelay = value;

					// Update hide timer
					bool running = true;
					if ( hideToolTipTimer.Enabled)
						hideToolTipTimer.Stop();
					hideToolTipTimer.Interval = value;
					if ( running )
						hideToolTipTimer.Start();

					OnPropertyChanged(TabControlExProperty.HideDelay);
				}
			}
		}


		/// <summary>
		/// Width of the tabs when the TabsFitting style is set to FixedWidth.
		/// Default value is 100 pixels.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Width of the tabs when the TabsFitting style is set to FixedWidth")]
		[DefaultValue(100)]
		public int FixedWidth 
		{
			get { return fixedWidth; }
			set
			{
				if ( fixedWidth != value )
				{
					fixedWidth = value;
					OnPropertyChanged(TabControlExProperty.FixedWidth);
				}
			}
		}


		/// <summary>
		/// Tabs whose text and icon fit within a width less that the FixedWidth value will
		/// be drawn using the needed width for the tab instead the FixedWidth value. If this 
		/// property is set to True, all tabs will be drawn using the same width regardless they fit or not.
		/// Default value is false
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("tabs will be drawn using the same width regardless they fit or not")]
		[DefaultValue(false)]
		public bool AlwaysUseFixedWidth 
		{
			get { return alwaysUseFixedWidth; }
			set
			{
				if ( alwaysUseFixedWidth != value )
				{
					alwaysUseFixedWidth = value;
					OnPropertyChanged(TabControlExProperty.AlwaysUseFixedWidth);
				}
			}
		}

		
		/// <summary>
		/// Shows a tooltip for tabs that don't fit within the available width when using
		/// the FixedWidth tab fitting mode. Default value is true.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("tabs will be drawn using the same width regardless they fit or not")]
		[DefaultValue(false)]
		public bool ShowFixedWidthTooltip
		{
			get { return showFixedWidthTooltip; }
			set
			{
				if ( showFixedWidthTooltip != value )
				{
					showFixedWidthTooltip = value;
					OnPropertyChanged(TabControlExProperty.ShowFixedWidthTooltip);
				}
			}
		}


		/// <summary>
		/// If set to true, the class automatically updates the colors used internally
		/// to do its painting when there is a system color change. Default is true.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("If set to true, the class automatically updates the colors used internally")]
		[DefaultValue(true)]
		public bool FollowSystemColorsChange
		{
			get { return followSystemColorsChange; }
			set
			{
				if ( followSystemColorsChange != value )
				{
					followSystemColorsChange = value;
					OnPropertyChanged(TabControlExProperty.FollowSystemColorsChange);
				}
			}
		}


		/// <summary>
		/// Description the size of the control when first inserted in the IDE designer.
		/// </summary>
		protected override Size DefaultSize
		{
			get { return new Size(250, 150); }
		}


		/// <summary>
		/// Enable/Disable navigation of the tabs by using the up, down, left and right keyboard keys.
		/// Default value is true.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Enable/Disable navigation of the tabs by using the up, down, left and right keyboard keys")]
		[DefaultValue(true)]
		public bool KeyboardTabsNavigation
		{
			get { return keyboardTabsNavigation; }
			set
			{
				if ( keyboardTabsNavigation != value )
				{ 
					keyboardTabsNavigation = value;
					OnPropertyChanged(TabControlExProperty.KeyboardTabsNavigation);
				}
			}
		}


		/// <summary>
		/// Enable/disable updating the control when the TabPages collection changes.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Enable/disable updating the control when the TabPages collection changes")]
		[DefaultValue(true)]
		public bool InvalidateOnTabCollectionChange
		{
			get { return invalidateOnTabCollectionChange; }
			set
			{
				if ( invalidateOnTabCollectionChange != value )
				{ 
					invalidateOnTabCollectionChange = value;
					OnPropertyChanged(TabControlExProperty.InvalidateOnTabCollectionChange);
				}
			}
		}


		/// <summary>
		/// Allows to turn off the drawing of the separators between document style rows when 
		/// the tab control is in multiline mode.
		/// Default value is true.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Allows to turn off the drawing of the separators between document style rows")]
		[DefaultValue(true)]
		public bool DrawDocumentMultilineSeparators
		{
			get { return drawDocumentMultilineSeparators; }
			set
			{
				if ( drawDocumentMultilineSeparators != value )
				{ 
					drawDocumentMultilineSeparators = value;
					OnPropertyChanged(TabControlExProperty.DrawDocumentMultilineSeparators);
				}
			}
		}



		/// <summary>
		/// Defines the style of the tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Defines the style of the tabs")]
		[DefaultValue(typeof(TabsStyle), "Document")]
		public TabsStyle TabsStyle
		{
			get { return tabsStyle; }
			
			set
			{
				if (tabsStyle != value)
				{
					if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
					{
						if ( selectedTabIndex != -1 && SelectedTabIndex < tabPages.Count )
						{
							// Repaint the TabPage so that it clears up the XP Theme background
							TabPageEx p = tabPages[selectedTabIndex];
							p.Invalidate();
						}
					}

					tabsStyle = value;
					if ( tabsFitting == TabsFitting.MultiLine )
					{
						UpdateMultilineDimensions();
						UpdateTabPagesBounds();
					}
					else
					{
						UpdateTabPagesBounds();
					}
					
					UpdateSelectedTabPageBackground();
					OnPropertyChanged(TabControlExProperty.TabsStyle);
				}
			}
			

		}


		/// <summary>
		/// Defines the location of the tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Defines the location of the tabs.")]
		[DefaultValue(typeof(TabsLocation), "Bottom")]
		public TabsLocation TabsLocation
		{
			get { return tabsLocation; }

			set
			{
				if (tabsLocation != value)
				{
					tabsLocation = value;
					if ( tabsFitting == TabsFitting.MultiLine )
						UpdateMultilineDimensions();
					else
						UpdateTabPagesBounds();
				
					UpdateSelectedTabPageBackground();

					OnPropertyChanged(TabControlExProperty.TabsLocation);
				}
			}
		}


		/// <summary>
		/// Context menu when a tab is right clicked.
		/// Default value is <code>null</code>
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Context menu when a tab is right clicked")]
		[DefaultValue(null)]
		public PopupMenu TabControlContextMenu
		{			
			get { return tabControlContextMenu; }

			set
			{
				if (tabControlContextMenu != value)
				{
					tabControlContextMenu = value;
					OnPropertyChanged(TabControlExProperty.TabControlContextMenu);
				}
			}
		}
        

		/// <summary>
		/// Defines the way the tabs will be drawn so as to fit them within the available area
		/// for the tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Defines the way the tabs will be drawn so as to fit them within the available are " + 
			 "for the tabs")]
		[DefaultValue(typeof(TabsFitting), "ShowArrows")]
		public TabsFitting TabsFitting
		{
			get { return tabsFitting; }
			set
			{
				if (tabsFitting != value)
				{
					tabsFitting = value;
					if ( tabsFitting == TabsFitting.MultiLine )
					{
						UpdateMultilineDimensions();
						if ( IsOneNoteTabStyle() )
						{
							// Force a recalculation of the tabs again
							// since when using OneNote tabs and if the Multiline
							// rows array is initially empty, not extra width will be added
							// -- this second time it will --
							UpdateMultilineDimensions();
						}
					}
					else
						UpdateTabPagesBounds();
					OnPropertyChanged(TabControlExProperty.TabsFitting);
				}
			}
		}


		/// <summary>
		/// The collection of <see cref="TabPageEx"/> objects in the control.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("The collection of TabPageEx objects in the control")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TabPageExCollection TabPages
		{
			get { return tabPages; }

			set
			{
				if ( tabPages != value )
				{
					tabPages.Clear();
					tabPages = value;
					OnPropertyChanged(TabControlExProperty.TabPagesCollection);
				}
			}
		}


		/// <summary>
		/// Currently selected tab index.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Currently selected tab index")]
		[DefaultValue(typeof(int), "0")]
		virtual public int SelectedTabIndex
		{
			get { return selectedTabIndex; }
			set
			{
				if ( selectedTabIndex != value )
				{ 
					// Only if the new index is between the visible indexes
					if ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth )
					{
						if ( lastVisiblePageIndex < tabPages.Count )
						{
							TabPageEx lastPage = tabPages[lastVisiblePageIndex];
							if ( HasHorizontalTabs() )
							{
								if ( ( lastPage.TabRectangle.Right >= LeftArrowXPos() 
									&& value > lastVisiblePageIndex )|| value < firstVisiblePageIndex )
									return;
							}
							else if ( ShouldForceLeftTabsTop )
							{
								if ( ( lastPage.TabRectangle.Bottom >= LeftArrowYPos() 
									&& value > lastVisiblePageIndex ) || value < firstVisiblePageIndex )
									return;
							}
							else if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop )
							{
								if ( ( lastPage.TabRectangle.Top <= LeftArrowYPos() 
									&& value > lastVisiblePageIndex ) || value < firstVisiblePageIndex )
									return;
							}
							else if ( tabsLocation == TabsLocation.Right )
							{
								if ( ( lastPage.TabRectangle.Bottom >= LeftArrowYPos() 
									&& value > lastVisiblePageIndex ) || value < firstVisiblePageIndex )
									return;
							}
						}
					}

					// Manually check if we can actually change the index
					// by calling ourselves the OnValidating routine
					bool cancelIndexChanged = true;
					if ( selectedTabIndex != -1 && selectedTabIndex < tabPages.Count )
					{
						TabPageEx tp = tabPages[selectedTabIndex];
						cancelIndexChanged = tp.InvokeOnValidating();
						if ( cancelIndexChanged )
							return;
					}

					// raise SelectedTabChanging and check if change allowed
					CancelEventArgs e = new CancelEventArgs(false);
					OnSelectedTabChanging(this, e);
					if (e.Cancel) return;

					selectedTabIndex = value;
					UpdateTabPagesVisibility();
					OnPropertyChanged(TabControlExProperty.SelectedTabIndex);
					OnSelectedTabChanged(SelectedTab);
				}
			}
		}


		/// <summary>
		/// Normal state image list.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Normal state image list")]
		[DefaultValue(null)]
		public ImageListEx ImageList
		{
			get { return imageList; }
			set
			{
				if ( imageList != value )
				{ 
					imageList = value;
					OnPropertyChanged(TabControlExProperty.ImageList);
				}
			}
		}


		/// <summary>
		///  Selected state image list.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description(" Selected state image list.")]
		[DefaultValue(null)]
		public ImageListEx SelectedImageList
		{
			get { return selectedImageList; }
			set
			{
				if ( selectedImageList != value )
				{ 
					selectedImageList = value;
					OnPropertyChanged(TabControlExProperty.SelectedImageList);
				}
			}
		}


		/// <summary>
		/// Flag whether to show the text for the tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Flag whether to show the text for the tabs")]
		[DefaultValue(true)]
		public bool ShowText
		{
			get { return showText; }
			set
			{
				if ( showText != value )
				{ 
					showText = value;
					if ( tabsFitting == TabsFitting.MultiLine )
						UpdateMultilineDimensions();

					if ( IsHorizontalText() )
						UpdateTabPagesBounds();
                        
					OnPropertyChanged(TabControlExProperty.ShowText);
				}
			}
		}


		/// <summary>
		/// Flag whether to show the icons for the tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Flag whether to show the icons for the tabs")]
		[DefaultValue(true)]
		public bool ShowIcon
		{
			get { return showIcon; }
			set
			{
				if ( showIcon != value )
				{ 
					showIcon = value;
					if ( tabsFitting == TabsFitting.MultiLine )
						UpdateMultilineDimensions();

					if ( IsHorizontalText() )
						UpdateTabPagesBounds();

					OnPropertyChanged(TabControlExProperty.ShowIcon);
				}
			}
		}


		/// <summary>
		///  Flag whether to show the selected tab text in bold.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description(" Flag whether to show the selected tab text in bold")]
		[DefaultValue(false)]
		public bool ShowSelectedTextBold
		{
			get { return showSelectedTextBold; }
			set
			{
				if ( showSelectedTextBold != value )
				{ 
					showSelectedTextBold = value;
					if ( tabsFitting == TabsFitting.MultiLine )
						UpdateMultilineDimensions();
					UpdateTabPagesBounds();
					OnPropertyChanged(TabControlExProperty.ShowSelectedTextBold);
				}
			}
		}


		/// <summary>
		/// Flag whether to select a tab my mouse move.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Flag whether to select a tab my mouse move")]
		[DefaultValue(false)]
		public bool HoverSelect
		{
			get { return hoverSelect; }
			set
			{
				if ( hoverSelect != value )
				{ 
					hoverSelect = value;
					if ( tabsFitting == TabsFitting.MultiLine )
						UpdateMultilineDimensions();
					OnPropertyChanged(TabControlExProperty.HoverSelect);
				}
			}
		}
        

		/// <summary>
		/// Flag whether to show the text only for the selected tab. ShowText should also be enabled.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Flag whether to show the text only for the selected tab. ShowText should also be enabled")]
		[DefaultValue(false)]
		public bool ShowOnlySelectedTabText
		{
			get { return showOnlySelectedTabText; }
			set
			{
				if ( showOnlySelectedTabText != value )
				{ 
					showOnlySelectedTabText = value;
					if ( tabsFitting == TabsFitting.MultiLine )
						UpdateMultilineDimensions();
					OnPropertyChanged(TabControlExProperty.ShowOnlySelectedTabText);
				}
			}
		}
        

		/// <summary>
		/// Enable dragging the tabs to a different position by left clicking the mouse on the tab.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Enable dragging the tabs to a different position by left clicking the mouse on the tab")]
		[DefaultValue(false)]
		public bool TabDrag
		{
			get { return tabDrag; }
			set
			{
				if ( tabDrag != value )
				{ 
					tabDrag = value;
					OnPropertyChanged(TabControlExProperty.TabDrag);
				}
			}
		}
        

		/// <summary>
		///  The color to be used for the arrow glyphs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description(" The color to be used for the arrow glyphs")]
		public Color GlyphsColor
		{
			get { return glyphsColor; }
			set
			{
				if ( glyphsColor != value )
				{ 
					glyphsColor = value;
					// Update glyph ImageList
					UpdateGlyphsImageList();
					OnPropertyChanged(TabControlExProperty.GlyphsColor);
				}
			}
		}

		bool ShouldSerializeGlyphsColor()
		{
			return glyphsColor != ColorUtil.DarkColor(SystemColors.ControlDark, 32);
		}

		void ResetGlyphsColor()
		{
			GlyphsColor = ColorUtil.DarkColor(SystemColors.ControlDark, 32);
		}


		/// <summary>
		/// The color to be used for the text of the tabs. 
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("The color to be used for the text of the tabs")]
		public Color TextColor
		{
			get { return textColor; }
			set
			{
				if ( textColor != value )
				{ 
					textColor = value;
					OnPropertyChanged(TabControlExProperty.TextColor);
				}
			}
		}

		bool ShouldSerializeTextColor()
		{
			return textColor != SystemColors.ControlText;
		}

		void ResetTextColor()
		{
			TextColor = SystemColors.ControlText;
		}


		/// <summary>
		/// The hot color to be used for the text of the tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("The hot color to be used for the text of the tabs.")]
		public Color HotTextColor
		{
			get { return hotTextColor; }
			set
			{
				if ( hotTextColor != value )
				{ 
					hotTextColor = value;
					OnPropertyChanged(TabControlExProperty.HotTextColor);
				}
			}
		}

		bool ShouldSerializeHotTextColor()
		{
			return hotTextColor != Color.Blue;
		}

		void ResetHotTextColor()
		{
			HotTextColor = Color.Blue;
		}


		/// <summary>
		/// Background color of the tabs area when using the Document Style tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Background color of the tabs area when using the Document Style tabs")]
		public Color DocumentStyleBackColor
		{
			get { return documentStyleBackColor; }
			set
			{
				if ( documentStyleBackColor != value )
				{ 
					documentStyleBackColor = value;
					OnPropertyChanged(TabControlExProperty.DocumentStyleBackColor);
				}
			}
		}

		bool ShouldSerializeDocumentStyleBackColor()
		{
			return documentStyleBackColor != ColorUtil.VSNetTabBackgroundColor;
		}

		void ResetDocumentStyleBackColor()
		{
			DocumentStyleBackColor = ColorUtil.VSNetTabBackgroundColor;
		}


		/// <summary>
		/// Background color of the tabs area when using a style other than Document Style tabs.
		/// The default value is the BackColor of the tab control.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Background color of the tabs area when using a style other than Document Style tabs")]
		public Color TabsAreaBackColor
		{
			get { return tabsAreaBackColor; }
			set
			{
				if ( tabsAreaBackColor != value )
				{ 
					tabsAreaBackColor = value;
					OnPropertyChanged(TabControlExProperty.TabsAreaBackColor);
				}
			}
		}

		bool ShouldSerializeTabsAreaBackColor()
		{
			return tabsAreaBackColor != SystemColors.Control;
		}

		void ResetTabsAreaBackColor()
		{
			TabsAreaBackColor = SystemColors.Control;
		}


		/// <summary>
		/// Flag whether to use hot tracking on mouse for the tabs.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Flag whether to use hot tracking on mouse for the tabs")]
		[DefaultValue(false)]
		public bool HotTrack
		{
			get { return hotTrack; }
			set
			{
				if ( hotTrack != value )
				{ 
					hotTrack = value;
					OnPropertyChanged(TabControlExProperty.HotTrack);
				}
			}
		}


		/// <summary>
		/// Flag whether to show the close glyph. This is only applicable to the ShowArrows or
		/// FixedWidth tab fitting style.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Flag whether to show the close glyph. This is only applicable to the ShowArrows or FixedWidth tab fitting style")]
		[DefaultValue(true)]
		public bool ShowClose
		{
			get  { return showClose; }
			set
			{
				if ( showClose != value )
				{ 
					showClose = value;
					OnPropertyChanged(TabControlExProperty.ShowClose);
				}
			}
		}


		/// <summary>
		/// Prevents the currently selected tab from moving to the front row.
		/// This property is only applicable when the tab control is multiline mode.
		/// Default value is true.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Prevents the currently selected tab from moving to the front row")]
		[DefaultValue(true)]
		public bool KeepSelectedTabInSameRow
		{
			get  { return keepSelectedTabInSameRow; }
			set
			{
				if ( keepSelectedTabInSameRow != value )
				{ 
					keepSelectedTabInSameRow = value;
					OnPropertyChanged(TabControlExProperty.KeepSelectedTabInSameRow);
				}
			}
		}


		/// <summary>
		/// Darken the tabs by disregarding the assumed origin
		/// of the light source and painting one border dark instead of light. This property is only applicable
		/// when the control uses standard tabs on the left or top.
		/// Default value is false.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Darken the tabs by disregarding the assumed origin of the light source")]
		[DefaultValue(false)]
		public bool IgnoreLightSource
		{
			get  { return ignoreLightSource; }
			set
			{
				if ( ignoreLightSource != value )
				{ 
					ignoreLightSource = value;
					OnPropertyChanged(TabControlExProperty.IgnoreLightSource);
				}
			}
		}


		/// <summary>
		/// Area that contains the tabs.
		/// </summary>
		[Browsable(false)]
		public Rectangle TabsArea
		{
			get 
			{
				Rectangle tabsArea = Rectangle.Empty;
				int tabsAreaHeight = TabsAreaHeight;
				int tabsAreaWidth = TabsAreaWidth;
				int pagesHeight = ClientRectangle.Height - tabsAreaHeight;
				if (  tabsLocation == TabsLocation.Top )
				{
					tabsArea = new Rectangle(0, 0, ClientRectangle.Width, 
						tabsAreaHeight);
				}
				else if ( tabsLocation == TabsLocation.Bottom )
				{
					tabsArea = new Rectangle(0, ClientRectangle.Top + pagesHeight,
						ClientRectangle.Width, tabsAreaHeight);
				}
				else if ( tabsLocation == TabsLocation.Left )
				{
					tabsArea = new Rectangle(0, 0,  tabsAreaWidth, ClientRectangle.Height); 				
				}
				else if ( tabsLocation == TabsLocation.Right )
				{
					tabsArea = new Rectangle(ClientRectangle.Right - tabsAreaWidth, 0,  TabsAreaWidth, ClientRectangle.Height); 				
				}
							
				return tabsArea; 
			}
		}


		/// <summary>
		/// Area that contains the tab pages.
		/// </summary>
		[Browsable(false)]
		public Rectangle PageArea
		{
			get 
			{
				Rectangle pageArea = Rectangle.Empty;
				int tabsAreaHeight = TabsAreaHeight;
				int tabsAreaWidth = TabsAreaWidth;
				int topMargin = TAB_AREA_TOP_MARGIN;
				if ( hideTabs )
					topMargin = 0;

				if (  tabsLocation == TabsLocation.Top )
				{
					if ( IsSpecialBorder() && 
						(tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document 
						|| tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme 
						|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
					{
						pageArea = new Rectangle(0, tabsAreaHeight - topMargin, ClientRectangle.Width, 
							ClientRectangle.Height - tabsAreaHeight + topMargin);
					}
					else
					{
						pageArea = new Rectangle(0, tabsAreaHeight, ClientRectangle.Width, 
							ClientRectangle.Height - tabsAreaHeight);
					}
				}
				else if ( tabsLocation == TabsLocation.Bottom )
				{
					if ( IsSpecialBorder() && (tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document 
						|| tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme
						|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
					{
						pageArea = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height - tabsAreaHeight + topMargin);
					}
					else
					{			
						pageArea = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height - tabsAreaHeight);
					}
				}
				else if ( tabsLocation == TabsLocation.Left )
				{
					if ( IsSpecialBorder() && (tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document || 
						tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme
						|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
					{
						if ( horizontalText )
						{
							pageArea = new Rectangle(tabsAreaWidth - topMargin, 0, ClientRectangle.Width - tabsAreaWidth + topMargin, 
								ClientRectangle.Height);
						}
						else
						{
							pageArea = new Rectangle(tabsAreaHeight - topMargin, 0, ClientRectangle.Width - tabsAreaHeight + topMargin, 
								ClientRectangle.Height);
						}
					}
					else
					{
						pageArea = new Rectangle(tabsAreaWidth, 0, ClientRectangle.Width - tabsAreaWidth, ClientRectangle.Height);
					}
				}
				else if ( tabsLocation == TabsLocation.Right )
				{
					if ( IsSpecialBorder() && (tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document 
						|| tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme
						|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
					{
						pageArea = new Rectangle(0, 0, ClientRectangle.Width - tabsAreaWidth + topMargin, ClientRectangle.Height);
					}
					else
					{
						pageArea = new Rectangle(0, 0, ClientRectangle.Width - tabsAreaWidth, ClientRectangle.Height);
					}
				}
				
				return pageArea;
			}
		}


		/// <summary>
		/// Currently selected tab.
		/// </summary>
		[Browsable(false)]
		public TabPageEx SelectedTab
		{
			get 
			{
				if ( selectedTabIndex < 0 || selectedTabIndex >= tabPages.Count )
					return null;
				else
					return tabPages[selectedTabIndex]; 
			}
		}


		/// <summary>
		/// Allows for customization of the colors used to paint the tabs. 
		/// The Base color is used to derived light and dark colors --among others-- so that
		/// the tab is painted according to the assumed light source origin.
		/// The tab page class has the same property and it will take
		/// precedence over the property in the tab control.
		/// The default value is empty.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Allows for customization of the colors used to paint the tabs")]
		public Color TabBaseColor
		{
			get { return tabBaseColor; }
			set 
			{ 
				if (tabBaseColor != value)
				{
					tabBaseColor = value;
					OnPropertyChanged(TabControlExProperty.TabBaseColor);
				}
			}
		}

		bool ShouldSerializeTabBaseColor()
		{
			return tabBaseColor != Color.Empty;
		}

		void ResetTabBaseColor()
		{
			TabBaseColor = Color.Empty;
		}


		/// <summary>
		/// The color to use for the selected tab when the TabStyle is Flat.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("The color to use for the selected tab when the TabStyle is Flat")]
		public Color FlatStyleSelectedTabColor
		{
			get { return flatStyleSelectedTabColor; }
			set 
			{ 
				if (flatStyleSelectedTabColor != value)
				{
					flatStyleSelectedTabColor = value;
					OnPropertyChanged(TabControlExProperty.FlatStyleSelectedTabColor);
				}
			}
		}

		bool ShouldSerializeFlatStyleSelectedTabColor()
		{
			return flatStyleSelectedTabColor != ColorUtil.VSNetSelectionColor;
		}

		void ResetFlatStyleSelectedTabColor()
		{
			FlatStyleSelectedTabColor = ColorUtil.VSNetSelectionColor;
		}


		/// <summary>
		/// The color to use for the border of the selected tab when the TabStyle is Flat.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("The color to use for the border of the selected tab when the TabStyle is Flat")]
		public Color FlatStyleSelectedTabBorderColor
		{
			get { return flatStyleSelectedTabBorderColor; }
			set 
			{ 
				if (flatStyleSelectedTabBorderColor != value)
				{
					flatStyleSelectedTabBorderColor = value;
					OnPropertyChanged(TabControlExProperty.FlatStyleSelectedTabBorderColor);
				}
			}
		}

		bool ShouldSerializeFlatStyleSelectedTabBorderColor()
		{
			return flatStyleSelectedTabBorderColor != ColorUtil.SystemColorsHighlight;
		}

		void ResetFlatStyleSelectedTabBorderColor()
		{
			FlatStyleSelectedTabBorderColor = ColorUtil.SystemColorsHighlight;
		}


		/// <summary>
		/// Flag whether to invalidate the control every time a property changes. 
		/// </summary>
		[Browsable(false)]
		[DefaultValue(true)]
		public bool InvalidateOnPropertyChanged
		{
			get { return invalidateOnPropertyChanged; }
			set	{ invalidateOnPropertyChanged = value; }
		}
		

		/// <summary>
		/// Gradient start color for standard tab style.
		/// Gradient painting takes precedence over the TabBaseColor if both
		/// GradientStartColor and GradientEndColor are both not empty.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Gradient start color for standard tab style")]
		public Color GradientStartColor
		{
			get { return gradientStartColor; }
			set 
			{ 
				if (gradientStartColor != value)
				{
					gradientStartColor = value;
					OnPropertyChanged(TabControlExProperty.GradientStartColor);
				}
			}
		}

		bool ShouldSerializeGradientStartColor()
		{
			return gradientStartColor != Color.Empty;
		}

		void ResetGradientStartColor()
		{
			GradientStartColor = Color.Empty;
		}


		/// <summary>
		/// Gradient end color for standard tab style.
		/// Gradient painting takes precedence over the TabBaseColor if both
		/// GradientStartColor and GradientEndColor are both not empty.
		/// </summary>
		[Category("TabControlEx Properties")]
		[Description("Gradient end color for standard tab style")]
		public Color GradientEndColor
		{
			get { return gradientEndColor; }
			set 
			{ 
				if (gradientEndColor != value)
				{
					gradientEndColor = value;
					OnPropertyChanged(TabControlExProperty.GradientEndColor);
				}
			}
		}

		bool ShouldSerializeGradientEndColor()
		{
			return gradientEndColor != Color.Empty;
		}

		void ResetGradientEndColor()
		{
			GradientEndColor = Color.Empty;
		}


		internal int TabsAreaHeight
		{
			get { return  CalculateTabsAreaHeight(); }
		}


		internal int TabsAreaWidth
		{
			get 
			{ 
				if ( IsHorizontalText() && tabPages.Count > 0 && GetUnhiddenTabPageCount() > 0 )
					return GetGreatestTabWidth();
				else
					return CalculateTabsAreaHeight(); 
			}
		}

		internal bool ForceTabKeydFocus
		{
			get { return forceTabKeyFocus; }
			set { forceTabKeyFocus = value; }
		}

		internal bool AddDesignTimeTabPagePadding
		{
			get { return addDesignTimeTabPagePadding; }
			set { addDesignTimeTabPagePadding = value; }
		}

		internal bool ShouldForceLeftTabsTop
		{
			get { return tabsLocation == TabsLocation.Left && horizontalText && leftTabsTop; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Simulates a mouse click on the TabPageEx passed as a parameter.
		/// The click is only performed if the page is currently visible and it is
		/// contained within the TabPages collection of the parent TabControl.
		/// </summary>
		/// <param name="page">Page to simulate the click on.</param>
		/// <returns>True if the click was performed. False if the page is not visible and/or
		/// the page was not found on this TabControl pages collection</returns>
		public bool PerformClick(TabPageEx page)
		{
			bool performedClick = false;
			if ( tabPages.Contains(page) )
			{
				int index = tabPages.IndexOf(page);
				if ( IsScrollableTabsStyle() )
				{
					if ( index < firstVisiblePageIndex || index > lastVisiblePageIndex )
						return performedClick;
				}

				DoPerformClick(page);
				performedClick = true;
			}

			return performedClick;
			
		}


		/// <summary>
		/// Makes a page visible by setting it as the first visible tab.
		/// This method is only applicable when using the ShowArrows or FixedWidth tab fitting style.
		/// </summary>
		/// <param name="pageIndex">Index of the page to make visible.</param>
		/// <returns></returns>
		public bool MakePageVisible(int pageIndex)
		{
			if (  pageIndex >= 0 && pageIndex < tabPages.Count - 1 
				&& tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth )
			{
				firstVisiblePageIndex = pageIndex;
				Invalidate();
				return true;
			}
			
			return false;
		}


		/// <summary>
		/// Makes a page visible by setting it as the first visible tab.
		/// </summary>
		/// <param name="page">Page to make visible.</param>
		/// <returns></returns>
		public bool MakePageVisible(TabPageEx page)
		{
			int index = tabPages.IndexOf(page);
			return MakePageVisible(index);
		}


		/// <summary>
		/// Shows all tabs that are currently hidden.
		/// </summary>
		public void ShowHiddenTabs()
		{
			for ( int i = 0; i < tabPages.Count; i++ )
			{
				TabPageEx page = tabPages[i];
				page.hideTab = false;
			}

			// If in multiline mode force a recalculation of the rows
			if ( tabsFitting == TabsFitting.MultiLine )
				UpdateMultilineDimensions();

			// Force a repaint of the control.
			Invalidate();
		}


		/// <summary>
		/// Returns the number of rows in the tab control.
		/// This is mostly applicable when the control is in multiline mode. If it is not, then
		/// the value returned is always 1.
		/// </summary>
		/// <returns>Number of rows in the tab control.</returns>
		public int GetNumberOfRows()
		{
			if ( tabsFitting == TabsFitting.MultiLine )
				return multilineRows.Count;

			return 1;
		}


		/// <summary>
		/// Convenience method for setting the color of all tabs in a particular row in one call.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="rowTabColor">New color for the tabs in the row.</param>
		/// <returns>False if the row index is invalid. True if the new color was set for all tabs.</returns>
		public bool SetRowTabColor(int rowIndex, Color rowTabColor)
		{
			if ( rowIndex < multilineRows.Count )
			{
				// If within bounds
				TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];

				// Bracket our call with to InvalidateOnPropertyChanged 
				//to avoid repainting the control unnecessarily
				InvalidateOnPropertyChanged = false;
				
				for ( int i = trh.StartIndex; i <= trh.EndIndex; i++ )
				{
					TabPageEx page = tabPages[i];
					page.TabBaseColor = rowTabColor;
				}

				InvalidateOnPropertyChanged = true;
				// Update the control
				Invalidate();

				return true;
			}
			
			return false;
		}


		/// <summary>
		/// Convenience method for setting the text color of all tabs in a particular row in one call.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="rowTextColor">New text color for the tabs in the row.</param>
		/// <returns>False if the row index is invalid. True if the new text color was set for all tabs.</returns>
		public bool SetRowTabTextColor(int rowIndex, Color rowTextColor)
		{
			if ( rowIndex < multilineRows.Count )
			{
				// If within bounds
				TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];

				// Bracket our call with to InvalidateOnPropertyChanged 
				//to avoid repainting the control unnecessarily
				InvalidateOnPropertyChanged = false;
				
				for ( int i = trh.StartIndex; i <= trh.EndIndex; i++ )
				{
					TabPageEx page = tabPages[i];
					page.TextColor = rowTextColor;
				}

				InvalidateOnPropertyChanged = true;
				// Update the control
				Invalidate();

				return true;
			}
			
			return false;
		}


		/// <summary>
		/// Convenience method for setting text color and base color of all tabs in a particular row in one call.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="rowTabColor">New color for the tabs in the row.</param>
		/// <param name="rowTextColor">New text color for the tabs in the row.</param>
		/// <returns>False if the row index is invalid. True if the new text color was set for all tabs.</returns>
		public bool SetRowTabColors(int rowIndex, Color rowTabColor, Color rowTextColor)
		{
			if ( rowIndex < multilineRows.Count )
			{
				// If within bounds
				TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];

				// Bracket our call with to InvalidateOnPropertyChanged 
				//to avoid repainting the control unnecessarily
				InvalidateOnPropertyChanged = false;
				
				for ( int i = trh.StartIndex; i <= trh.EndIndex; i++ )
				{
					TabPageEx page = tabPages[i];
					page.TabBaseColor = rowTabColor;
					page.TextColor = rowTextColor;
				}

				InvalidateOnPropertyChanged = true;
				// Update the control
				Invalidate();

				return true;
			}
			
			return false;
		}


		/// <summary>
		/// Convenience method for setting the gradient colors of all tabs in a particular row in one call.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="rowGradientStartColor">GradientStartColor for the tabs in the row.</param>
		/// <param name="rowGradientEndColor">GradientEndColor for the tabs in the row.</param>
		/// <returns>False if the row index is invalid. True if the gradient colors were set for all tabs.</returns>
		public bool SetRowGradientColors(int rowIndex, Color rowGradientStartColor, Color rowGradientEndColor)
		{
			if ( rowIndex < multilineRows.Count )
			{
				// If within bounds
				TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];

				// Bracket our call with to InvalidateOnPropertyChanged 
				// to avoid repainting the control unnecessarily
				InvalidateOnPropertyChanged = false;
				
				for ( int i = trh.StartIndex; i <= trh.EndIndex; i++ )
				{
					TabPageEx page = tabPages[i];
					page.GradientStartColor = rowGradientStartColor;
					page.GradientEndColor = rowGradientEndColor;
				}

				InvalidateOnPropertyChanged = true;
				// Update the control
				Invalidate();

				return true;
			}
			
			return false;
		}


		/// <summary>
		/// Gets the rectangle bounds of a Tab.
		/// </summary>
		/// <param name="index">The index of the Tab</param>
		/// <returns>The rectangle for the Tab or an empty Rectangle if the index is outside
		/// the range of the available tabs, or the tab is not visible.</returns>
		public Rectangle GetTabRectangle(int index)
		{
			bool validIndex = index < tabPages.Count && index >= firstVisiblePageIndex && index <= lastVisiblePageIndex;
			if ( tabsFitting == TabsFitting.MultiLine )
				validIndex = true;
			if ( validIndex )
			{
				TabPageEx tp = tabPages[index];
				return tp.TabRectangle;
			}

			return Rectangle.Empty;
		}


		/// <summary>
		/// Get the bounding rectangle of the icon for the tab whose
		/// index is passed as a parameter.
		/// </summary>
		/// <param name="index">The index of the tab whose icon bounds the method returns.</param>
		/// <returns>The bounding rectangle of the icon in the tab. If the tab is not visible or
		/// the tab does not contains an icon or the index is greater than the number
		/// of available tabs, then an empty rectangle is returned.</returns>
		public Rectangle GetTabIconRectangle(int index)
		{
			bool validIndex = index < tabPages.Count && index >= firstVisiblePageIndex && index <= lastVisiblePageIndex;
			if ( tabsFitting == TabsFitting.MultiLine )
				validIndex = true;
			if ( validIndex )
			{
				TabPageEx tp = tabPages[index];
				return tp.IconRectangle;
			}

			return Rectangle.Empty;
		}


		/// <summary>
		/// Provides a way to hook up into the painting of the tabs. This function is called
		/// after the tab has been painted. By overriding this function it is possible to add
		/// some extra artifacts to the cab's look. The default implementation of this function
		/// does nothing.
		/// </summary>
		/// <param name="g">Graphics object for the Tab control.</param>
		/// <param name="tab">Tab currently being painted.</param>
		/// <param name="pageRectangle">Bounds of the tab.</param>
		public virtual void DrawTabAdorments(Graphics g, TabPageEx tab, Rectangle pageRectangle)
		{
            
		}

		#endregion

		#region Implementation
		void DrawBackground(Graphics g)
		{
			// Draw page area background only if there are not pages
			if ( tabPages.Count == 0 )
				g.Clear(BackColor);
			DrawTabsBackground(g, TabsArea, true);
		}

		void DrawTabsBackground(Graphics g, Rectangle tabsArea, bool doingPaintHandler)
		{
			Color tabsBackColor = GetTabAreaBackColor();
			using ( Brush b = new SolidBrush(tabsBackColor) )
			{
				Rectangle tabStripArea = GetTabStripArea(tabsArea);
				if ( !( (tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled()) && IsStandardTabsMultilineCase() ) )
                    g.FillRectangle(b, tabStripArea);
			}
			
			// Now draw background depending on the tabs style and tabs location
			if ( tabsStyle == TabsStyle.Document || tabsStyle == TabsStyle.Office2003 )
				DrawDocumentTabsBackground(g, tabsArea, doingPaintHandler);
			else if ( tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.XPTheme 
				|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() )
			{
				// Special case, don't draw the highlighting lines that separate the tabs from the tab pages
				// if using XPTheme tabs so that we get close in look the the XPTheme native TabControl
				if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
					return;

				DrawStandardTabsBackground(g, tabsArea);
			}
			else if ( tabsStyle == TabsStyle.Flat || tabsStyle == TabsStyle.HighContrast )
				DrawFlatTabsBackground(g, tabsArea);
		}

		void DrawDocumentTabsBackground(Graphics g, Rectangle tabsArea, bool doingPaintHandler)
		{
			Color backColor = GetTabAreaBackColor();
			bool multilineSpecialRow = false;
			bool noRowSeparators = tabsFitting == TabsFitting.MultiLine && drawDocumentMultilineSeparators == false;
			if ( noRowSeparators ) 
			{
				// Don't draw document rows separators
				if ( ( tabsLocation == TabsLocation.Bottom || tabsLocation == TabsLocation.Right ) 
					&& drawingRowIndex != 0 && tabsStyle != TabsStyle.Office2003 )
					return;
				else if ( (tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Left) 
					&& drawingRowIndex != multilineRows.Count-1 && tabsStyle != TabsStyle.Office2003 )
					return;

				multilineSpecialRow = true;

				// Don't consider special rows if using the Office2003 style
				if ( tabsLocation == TabsLocation.Top && tabsStyle == TabsStyle.Office2003 )
					multilineSpecialRow = false;
			}
			
			if (  tabsLocation == TabsLocation.Top )
			{
				Rectangle backArea = new Rectangle(tabsArea.Left, tabsArea.Top, 
					tabsArea.Width, tabsArea.Height - TAB_AREA_BOTTOM_MARGIN);
		
				DrawDocumentTabsBackground(g, backArea, backColor, doingPaintHandler);
				
				if ( IsSpecialBorder() )
				{
					// Draw dark line on the top
					DrawLineAdorment(g, GetLineDarkDarkColor(), tabsArea.Left, tabsArea.Top, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Top ); 

					if ( multilineSpecialRow == false )
					{
						// Bottom Lines
						g.DrawLine(SystemPens.ControlLight, tabsArea.Left, tabsArea.Bottom-2, 
							tabsArea.Left + tabsArea.Width - 1, tabsArea.Bottom-2); 

						g.DrawLine(SystemPens.ControlLightLight, tabsArea.Left, tabsArea.Bottom-1, 
							tabsArea.Left + tabsArea.Width - 1, tabsArea.Bottom-1); 
					}

					// Draw right points
					DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, TabsArea.Width - 1, TabsArea.Bottom-2);
					DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, TabsArea.Width - 1, TabsArea.Bottom-1);
					DrawUtil.DrawPoint(g, SystemColors.ControlDark, TabsArea.Width - 2, TabsArea.Bottom-1); 
				}
				else
				{
					// Draw dark line on the top
					DrawLineAdorment(g, GetLineDarkDarkColor(), tabsArea.Left, tabsArea.Top, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Top ); 

					// Draw light line on the bottom of the tabsRect
					if ( multilineSpecialRow == false )
					{
						DrawLineAdorment(g, SystemColors.ControlLightLight, backArea.Left, backArea.Bottom-1, 
							backArea.Left + backArea.Width - 1, backArea.Bottom-1); 
					}
				}
			}
			else if ( tabsLocation == TabsLocation.Bottom )
			{
				Rectangle backArea = new Rectangle(tabsArea.Left, tabsArea.Top + TAB_AREA_TOP_MARGIN, 
					tabsArea.Width, tabsArea.Height - TAB_AREA_TOP_MARGIN);
				
				DrawDocumentTabsBackground(g, backArea, backColor, doingPaintHandler);

				if ( IsSpecialBorder() )
				{
					// Top Lines
					g.DrawLine(SystemPens.ControlDark, tabsArea.Left, tabsArea.Top, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Top); 
					g.DrawLine(SystemPens.ControlDarkDark, tabsArea.Left, tabsArea.Top+1, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Top+1);
					DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, TabsArea.Width - 1, TabsArea.Top); 
				}
				else
				{
					DrawLineAdorment(g, GetLineDarkDarkColor(), backArea.Left, backArea.Top, 
						backArea.Left + backArea.Width - 1, backArea.Top ); 
				}
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				Rectangle backArea = new Rectangle(tabsArea.Left, tabsArea.Top, 
					tabsArea.Width - TAB_AREA_TOP_MARGIN, tabsArea.Height);
		
				DrawDocumentTabsBackground(g, backArea, backColor, doingPaintHandler);

				if ( IsSpecialBorder() )
				{
					if ( multilineSpecialRow == false ) 
					{
						// Left light line
						g.DrawLine(SystemPens.ControlLight, tabsArea.Right - 2, tabsArea.Top, 
							tabsArea.Right - 2, tabsArea.Bottom - 1);
						g.DrawLine(SystemPens.ControlLightLight, tabsArea.Right - 1, tabsArea.Top, 
							tabsArea.Right - 1, tabsArea.Bottom - 1);
					}

					if ( drawingGlyphBackground )
						DrawUtil.DrawPoint(g, SystemColors.ControlLight, tabsArea.Right - 1, tabsArea.Top);
				}
				else
				{
					// Draw dark line on left side
					DrawLineAdorment(g, GetLineDarkDarkColor(), backArea.Left, backArea.Top, 
						backArea.Left,  backArea.Top + tabsArea.Height);

					if ( multilineSpecialRow == false )
					{
						// Draw light line on bottom of the tabsRect
						DrawLineAdorment(g, SystemColors.ControlLightLight, backArea.Right-1, backArea.Top, 
							backArea.Right-1, backArea.Bottom-1); 
					}
				}
			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				Rectangle backArea = new Rectangle(tabsArea.Left + TAB_AREA_TOP_MARGIN, tabsArea.Top, 
					tabsArea.Width - TAB_AREA_TOP_MARGIN, tabsArea.Height);
		
				DrawDocumentTabsBackground(g, backArea, backColor, doingPaintHandler);

				if ( IsSpecialBorder() )
				{
					// Top Lines
					g.DrawLine(SystemPens.ControlDark, tabsArea.Left, tabsArea.Top, 
						tabsArea.Left, tabsArea.Bottom-1); 
					g.DrawLine(SystemPens.ControlDarkDark, tabsArea.Left+1, tabsArea.Top, 
						tabsArea.Left+1, tabsArea.Bottom-1);
					if ( drawingGlyphBackground )
						DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, tabsArea.Left, tabsArea.Bottom-1);
				}
				else
				{
					// Draw dark line on left side
					DrawLineAdorment(g, GetLineDarkDarkColor(), backArea.Left, backArea.Top, 
						backArea.Left,  backArea.Top + tabsArea.Height);
				}
			}

		}

		void DrawDocumentTabsBackground(Graphics g, Rectangle backArea, Color backColor, bool doingPaintHandler)
		{
			using ( Brush b = new SolidBrush(backColor) )
			{
				if ( tabsStyle == TabsStyle.Document )
					g.FillRectangle(b, backArea);
				else if ( tabsStyle == TabsStyle.Office2003 )
				{
					// Paint 2 pixel background
					if ( IsValidOffice2003FillStyle() )
					{
						Rectangle fillRect = GetTabsToTabPagesArea(backArea);
						Color fillColor =  GetOffice2003FillColor();
						using ( Brush fb = new SolidBrush(fillColor) )
							g.FillRectangle(fb, fillRect);
					}

					if ( doingPaintHandler && !IsHorizontalText() && tabsFitting == TabsFitting.MultiLine && multilineRows != null && multilineRows.Count > 1)
						using ( Brush ofb = new SolidBrush(ColorUtil.Office2003ToolBarStartGradient) )
							g.FillRectangle(ofb, backArea);
					else
						DrawOffice2003TabsBackground(g, backArea, ButtonState.Normal); 
				}
			}
		}

		Rectangle GetTabsToTabPagesArea(Rectangle tabsArea)
		{
			if ( tabsLocation == TabsLocation.Bottom )
			{
				if ( IsOneNoteTabStyle() )
					return new Rectangle(tabsArea.Left, tabsArea.Top, tabsArea.Width, 2);
				else
					return new Rectangle(tabsArea.Left, tabsArea.Top-2, tabsArea.Width, 2);
			}
			else if ( tabsLocation == TabsLocation.Top )
			{
				if ( IsOneNoteTabStyle() )
					return new Rectangle(tabsArea.Left, tabsArea.Bottom-2, tabsArea.Width, 2);
				else
					return new Rectangle(tabsArea.Left, tabsArea.Bottom, tabsArea.Width, 2);
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				if ( IsOneNoteTabStyle() )
					return new Rectangle(tabsArea.Right-2, tabsArea.Top, 2, tabsArea.Height);
				else
					return new Rectangle(tabsArea.Right, tabsArea.Top, 2, tabsArea.Height);
			}
			else 
			{
				if ( IsOneNoteTabStyle() )
					return new Rectangle(tabsArea.Left, tabsArea.Top, 2, tabsArea.Height);
				else
					return new Rectangle(tabsArea.Left-2, tabsArea.Top, 2, tabsArea.Height);
			}
		}

		bool IsValidOffice2003FillStyle()
		{
			if ( BorderStyleEx == BorderStyleEx.FixedSingle || BorderStyleEx == BorderStyleEx.Fixed3D ||
				BorderStyleEx == BorderStyleEx.StaticEdge || BorderStyleEx == BorderStyleEx.ThickFrame || BorderStyleEx == BorderStyleEx.None )
				return true;
			return false;
		}

		Color GetOffice2003FillColor()
		{
			if ( tabsLocation == TabsLocation.Bottom || tabsLocation == TabsLocation.Right )
				return ColorUtil.Office2003CheckedStartGradient;
			else 
				return ColorUtil.Office2003CheckedEndGradient;
		}

		void DrawOffice2003TabsBackground(Graphics g, Rectangle tabsArea, ButtonState state)
		{
			LinearGradientMode mode = LinearGradientMode.Horizontal;
			if ( HasHorizontalTabs() )
				mode = LinearGradientMode.Vertical;
			DrawUtil.DrawOffice2003GradientBackground(g, tabsArea, 
				mode, state);
		}

		void DrawOffice2003GlyphBackground(Graphics g, Rectangle tabsArea, Rectangle targetRect, int rowIndex)
		{
			if ( tabsFitting == TabsFitting.MultiLine && multilineRows != null && multilineRows.Count > 1 
				&& rowIndex != -1 )
			{
				// Match our target and destination
				int rowHeight = GetMultilineRowHeight(0);
				int rowOffset = 0;
				if ( tabsLocation == TabsLocation.Bottom || tabsLocation == TabsLocation.Right )
					rowOffset = rowIndex*rowHeight;
				else if ( tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Left )
					rowOffset = (multilineRows.Count-(rowIndex+1))*rowHeight;

				if ( HasHorizontalTabs() )
					tabsArea = new Rectangle(tabsArea.Left, tabsArea.Top + rowOffset, tabsArea.Width, rowHeight);
				else
					tabsArea = new Rectangle(tabsArea.Left + rowOffset, tabsArea.Top, rowHeight, tabsArea.Height);
			}

			// Create a bitmap with the size of the tab control
			Bitmap gradientBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			Graphics buffer = Graphics.FromImage(gradientBitmap);

			// Which gradient mode
			LinearGradientMode mode = LinearGradientMode.Horizontal;
			if ( HasHorizontalTabs() )
				mode = LinearGradientMode.Vertical;
			DrawUtil.DrawOffice2003GradientBackground(buffer, tabsArea, 
				mode, ButtonState.Normal);

			// Clip our section
			Region clipRegion = new Region(targetRect);
			Region oldClipRegion = g.Clip;
			g.Clip = clipRegion;

			// Now paint the little section we want
			g.DrawImage(gradientBitmap, targetRect, targetRect.Left, targetRect.Top, 
				targetRect.Width, targetRect.Height, GraphicsUnit.Pixel);
			g.Clip = oldClipRegion;

			// Cleanup
			buffer.Dispose();
			gradientBitmap.Dispose();
		}

		void DrawStandardTabsBackground(Graphics g, Rectangle tabsArea)
		{
			Rectangle tabsRect = Rectangle.Empty;
			bool drawLine = IsMultiLineFirstRow();
				
			// No need to draw the top line 
			if ( IsStandardTabsMultilineCase() && !drawLine ) 
				return;

			if (  tabsLocation == TabsLocation.Top )
			{
				tabsRect = new Rectangle(tabsArea.Left, tabsArea.Top + TAB_AREA_TOP_MARGIN, 
					tabsArea.Width, tabsArea.Height - TAB_AREA_TOP_MARGIN);

				if ( IsSpecialBorder() )
				{
					// Top Lines
					g.DrawLine(SystemPens.ControlLight, tabsArea.Left, tabsArea.Bottom-2, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Bottom-2); 
					g.DrawLine(SystemPens.ControlLightLight, tabsArea.Left, tabsArea.Bottom-1, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Bottom-1);

					// Draw right points
					DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, TabsArea.Width - 1, TabsArea.Bottom-2);
					DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, TabsArea.Width - 1, TabsArea.Bottom-1);
					DrawUtil.DrawPoint(g, SystemColors.ControlDark, TabsArea.Width - 2, TabsArea.Bottom-1); 		
				}
				else
				{
					// Draw highlight line at the bottom
					if ( IsOneNoteTabStyle() )
					{
						DrawLineAdorment(g, ColorUtil.GetOneNoteDarkColor(tabsStyle), tabsRect.Left, tabsRect.Bottom-3, 
							tabsRect.Left + tabsRect.Width - 1, tabsRect.Bottom-3 ); 
						// Fill area between tabs and tab pages
						Rectangle fillArea = GetTabsToTabPagesArea(tabsArea);
						using ( Brush b = new SolidBrush(ColorUtil.GetOneNoteFillColor(tabsStyle, selectedTabIndex)) )
							g.FillRectangle(b, fillArea);
					}
					else
					{
						DrawLineAdorment(g, SystemColors.ControlLightLight, tabsRect.Left, tabsRect.Bottom-3, 
							tabsRect.Left + tabsRect.Width - 1, tabsRect.Bottom-3 ); 
					}
				}

			}
			else if ( tabsLocation == TabsLocation.Bottom )
			{
				tabsRect = new Rectangle(tabsArea.Left, tabsArea.Top + TAB_AREA_TOP_MARGIN, 
					tabsArea.Width, tabsArea.Height - TAB_AREA_TOP_MARGIN);

				if ( IsSpecialBorder() )
				{
					// Top Lines
					g.DrawLine(SystemPens.ControlDark, tabsArea.Left, tabsArea.Top, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Top); 
					g.DrawLine(SystemPens.ControlDarkDark, tabsArea.Left, tabsArea.Top+1, 
						tabsArea.Left + tabsArea.Width - 1, tabsArea.Top+1);
					DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, TabsArea.Width - 1, TabsArea.Top); 					
				}
				else
				{
					// Draw highlight line at the bottom
					if ( IsOneNoteTabStyle() )
					{
						DrawLineAdorment(g, ColorUtil.GetOneNoteDarkColor(tabsStyle), tabsRect.Left, tabsRect.Top, 
							tabsRect.Left + tabsRect.Width - 1, tabsRect.Top ); 
						// Fill area between tabs and tab pages
						Rectangle fillArea = GetTabsToTabPagesArea(tabsArea);
						using ( Brush b = new SolidBrush(ColorUtil.GetOneNoteFillColor(tabsStyle, selectedTabIndex)) )
							g.FillRectangle(b, fillArea);
					}
					else
					{
						// Draw dark line on the top
						DrawLineAdorment(g, GetLineDarkDarkColor(), tabsRect.Left, tabsRect.Top, 
							tabsRect.Left + tabsRect.Width - 1, tabsRect.Top ); 
					}
				}

			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				tabsRect = new Rectangle(tabsArea.Left + TAB_AREA_TOP_MARGIN, tabsArea.Top, 
					tabsArea.Width - TAB_AREA_TOP_MARGIN, tabsArea.Height);

				if ( IsSpecialBorder() )
				{
					// Left light line
					g.DrawLine(SystemPens.ControlLight, tabsArea.Right - 2, tabsArea.Top, 
						tabsArea.Right - 2, tabsArea.Bottom - 1);
					g.DrawLine(SystemPens.ControlLightLight, tabsArea.Right - 1, tabsArea.Top, 
						tabsArea.Right - 1, tabsArea.Bottom - 1);
					if ( drawingGlyphBackground )
						DrawUtil.DrawPoint(g, SystemColors.ControlLight, tabsArea.Right - 1, tabsArea.Top);
				}
				else
				{
					// Draw highlight line at the bottom
					if (IsOneNoteTabStyle())
					{
						DrawLineAdorment(g, ColorUtil.GetOneNoteDarkColor(tabsStyle), tabsRect.Right-3, tabsRect.Top, 
							tabsRect.Right - 3, tabsRect.Bottom-1); 
						// Fill area between tabs and tab pages
						Rectangle fillArea = GetTabsToTabPagesArea(tabsArea);
						using ( Brush b = new SolidBrush(ColorUtil.GetOneNoteFillColor(tabsStyle, selectedTabIndex)) )
							g.FillRectangle(b, fillArea);
					}
					else
					{
						// Draw highlight line at the right
						DrawLineAdorment(g, SystemColors.ControlLightLight, tabsRect.Right-3, tabsRect.Top, 
							tabsRect.Right - 3, tabsRect.Bottom-1 ); 
					}
				}
			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				tabsRect = new Rectangle(tabsArea.Left + TAB_AREA_TOP_MARGIN, tabsArea.Top, 
					tabsArea.Width - TAB_AREA_TOP_MARGIN, tabsArea.Height);
		
				if ( IsSpecialBorder() )
				{
					// Top Lines
					g.DrawLine(SystemPens.ControlDark, tabsArea.Left, tabsArea.Top, 
						tabsArea.Left, tabsArea.Bottom-1); 
					g.DrawLine(SystemPens.ControlDarkDark, tabsArea.Left+1, tabsArea.Top, 
						tabsArea.Left+1, tabsArea.Bottom-1);
					if ( drawingGlyphBackground )
						DrawUtil.DrawPoint(g, SystemColors.ControlDarkDark, tabsArea.Left, tabsArea.Bottom-1);
				}
				else
				{
					// Draw highlight line at the bottom
					if ( IsOneNoteTabStyle() )
					{
						DrawLineAdorment(g, ColorUtil.GetOneNoteDarkColor(tabsStyle), tabsRect.Left, tabsRect.Top, 
							tabsRect.Left, tabsArea.Top + tabsArea.Height); 
						// Fill area between tabs and tab pages
						Rectangle fillArea = GetTabsToTabPagesArea(tabsArea);
						using ( Brush b = new SolidBrush(ColorUtil.GetOneNoteFillColor(tabsStyle, selectedTabIndex)) )
							g.FillRectangle(b, fillArea);
					}
					else
					{
						// Draw dark line on left side
						DrawLineAdorment(g, GetLineDarkDarkColor(), tabsArea.Left+2, tabsArea.Top, 
							tabsArea.Left+2,  tabsArea.Top + tabsArea.Height);
					}
				}
			}
		}

		bool IsMultiLineFirstRow()
		{
			if ( tabsFitting == TabsFitting.MultiLine && 
				(tabsStyle == TabsStyle.Standard  || tabsStyle  == TabsStyle.XPTheme
				|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle()) && multilineRows.Count > 1)
			{	
				if ( drawingRowIndex == 0 )
					return true;
			}		

			return false;
		}

		bool IsMultiLineLastRow()
		{
			if ( tabsFitting == TabsFitting.MultiLine && 
				(tabsStyle == TabsStyle.Standard || tabsStyle  == TabsStyle.XPTheme
				|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle()) && multilineRows.Count > 1)
			{	
				if ( drawingRowIndex == multilineRows.Count - 1 )
					return true;
			}		
			
			return false;
		}

		bool IsStandardTabsMultilineCase()
		{
			return (tabsFitting == TabsFitting.MultiLine && 
				( tabsStyle == TabsStyle.Standard || tabsStyle  == TabsStyle.XPTheme 
				|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle()) && 
				multilineRows != null && multilineRows.Count  > 1);
		}

		void DrawFlatTabsBackground(Graphics g, Rectangle tabsArea)
		{
			Color backColor = GetTabAreaBackColor();
			using ( Brush b = new SolidBrush(backColor) )
			{
				g.FillRectangle(b, tabsArea);
			}
		}
		
		void DrawLineAdorment(Graphics g, Color lineColor, int x1, int y1, int x2, int y2 )
		{
			using ( Pen p = new Pen(lineColor) )
			{
				g.DrawLine(p, x1, y1, x2, y2);
			}
		}
		
		void DrawBorder(Graphics g)
		{
			// Don't draw if we don't have enough room
			if ( ClientRectangle.Height < TabsAreaHeight + (BorderHeight * 2) )
				return;

			Rectangle rc = PageArea;

			if  ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
			{
				// Draw XP border 
				using ( Pen p = new Pen(xpThemeBorderColor) )
					g.DrawRectangle(p, rc.Left, rc.Top, rc.Width-1, rc.Height-1);
				return;
			}
			
			if ( BorderStyleEx == BorderStyleEx.FixedSingle )
				DrawUtil.DrawFixedSingleRectangle(g, rc);
			else if ( BorderStyleEx == BorderStyleEx.Fixed3D )
				DrawUtil.DrawFixed3DRectangle(g, rc);
			else if ( BorderStyleEx == BorderStyleEx.StaticEdge )
				DrawUtil.DrawStaticEdgeRectangle(g, rc);
			else if ( BorderStyleEx == BorderStyleEx.ModalFrame )
				DrawUtil.DrawModalFrameRectangle(g, rc);
			else if ( BorderStyleEx == BorderStyleEx.ThickFrame )
				DrawUtil.DrawThickFrameRectangle(g, rc);
			else if ( BorderStyleEx == BorderStyleEx.RaisedFrame )
				DrawUtil.DrawRaisedFrameRectangle(g, rc);
		}

		void DrawDoubleBufferedGlyphs()
		{
			if ( tabsFitting == TabsFitting.ShowArrows  || tabsFitting == TabsFitting.FixedWidth )
			{
				// Double buffer the drawing of the glyphs
				Bitmap bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
				Graphics db = Graphics.FromImage(bitmap);
				DrawGlyphs(db);
				
				Rectangle destRect = GetGlyphsArea();			

				if ( tabsLocation == TabsLocation.Left && IsSpecialBorder() )
				{
					// Decrease the width by 2 pixel so that we don't draw over the border of the page area
					destRect = new Rectangle(destRect.Left, destRect.Top, destRect.Width - 2, destRect.Height);
				}
				else if ( tabsLocation == TabsLocation.Right && IsSpecialBorder() )
				{
					destRect = new Rectangle(destRect.Left + 2, destRect.Top, destRect.Width - 2, destRect.Height);
				}

				Graphics g = Graphics.FromHwnd(Handle);
				g.DrawImage(bitmap, destRect, destRect, GraphicsUnit.Pixel);
			
				// Cleanup
				db.Dispose();
				g.Dispose();
				bitmap.Dispose();
			}
							
		}

		void DrawDoubleBufferedTabs()
		{
			// Double buffer the drawing of the glyphs
			Bitmap bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			Graphics db = Graphics.FromImage(bitmap);
			DrawTabs(db);
			Graphics g = Graphics.FromHwnd(Handle);
			Rectangle rc = TabsArea;
			g.DrawImage(bitmap, rc, rc,  GraphicsUnit.Pixel);
			
			// Cleanup
			g.Dispose();
			bitmap.Dispose();
			db.Dispose();

		}

		void DrawGlyphs(Graphics g)
		{
			if ( !(tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth) )
				return;

			if ( updateGlyphsImageList )
			{
				updateGlyphsImageList = false;
				UpdateGlyphsImageList();
				UpdateOffice2003GlyphsImageList();
			}

			// 3D Rectangle colors
			Color topLeftColor =  Color.FromArgb(128, SystemColors.Control);
			Color rightBottomColor = SystemColors.ControlText;
			if ( mouseButtonDownOnGlyph )
			{
				topLeftColor = SystemColors.ControlText;
				rightBottomColor = ColorUtil.VSNetBackgroundColor;
			}

			// Glyphs would be aligned from the right
			// Paint glyph area with the background color first
			Rectangle tabsRect = TabsArea;
			int glyphsAreaWidth = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*3;
			if ( showClose == false )
				glyphsAreaWidth = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*2;
			if ( !HasHorizontalTabs() )
				glyphsAreaWidth += GLYPH_RIGHT_MARGIN;

			Rectangle destRect = Rectangle.Empty;
			if ( HasHorizontalTabs() )
				destRect = new Rectangle(LeftArrowXPos(), tabsRect.Top, glyphsAreaWidth, tabsRect.Height);
			else if ( tabsLocation == TabsLocation.Right 
				|| (tabsLocation == TabsLocation.Left && IsHorizontalText() && leftTabsTop) )
			{
				destRect =  new Rectangle(tabsRect.Left, tabsRect.Bottom - glyphsAreaWidth, 
					tabsRect.Width, glyphsAreaWidth);
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				destRect =  new Rectangle(tabsRect.Left, tabsRect.Top, tabsRect.Width, glyphsAreaWidth);
			}
			
			// A little bit of a hack to avoid drawing over the upper border of 
			// special border styles
			drawingGlyphBackground = true;
			Rectangle rc = destRect;
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
			{
				if ( tabsLocation == TabsLocation.Top  )
                    rc = new Rectangle(destRect.Left, destRect.Top, destRect.Width, destRect.Height+2);
				else if ( tabsLocation == TabsLocation.Bottom  )
					rc = new Rectangle(destRect.Left, destRect.Top-2, destRect.Width, destRect.Height+2);
				else if ( tabsLocation == TabsLocation.Left  )
					rc = new Rectangle(destRect.Left, destRect.Top, destRect.Width+2, destRect.Height);
				else if ( tabsLocation == TabsLocation.Right  )
					rc = new Rectangle(destRect.Left-2, destRect.Top, destRect.Width+2, destRect.Height);
			}
			DrawTabsBackground(g, rc, false);

			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
			{
				if ( xpThemeBorderColor != Color.Empty )
				{
					using ( Pen p = new Pen(xpThemeBorderColor) )
					{
						if ( tabsLocation == TabsLocation.Top  )
                            g.DrawLine(p, new Point(rc.Left, rc.Bottom-1), new Point(rc.Right-1, rc.Bottom-1));
						else if ( tabsLocation == TabsLocation.Bottom  )
							g.DrawLine(p, new Point(rc.Left, rc.Top+1), new Point(rc.Right-1, rc.Top+1));
						else if ( tabsLocation == TabsLocation.Left  )
							g.DrawLine(p, new Point(rc.Right-2, rc.Top), new Point(rc.Right-2, rc.Bottom-1));
						else if ( tabsLocation == TabsLocation.Right  )
							g.DrawLine(p, new Point(rc.Left+1, rc.Top), new Point(rc.Left+1, rc.Bottom-1));
					}
				}
			}
			drawingGlyphBackground = false;
						            			        
			// Close button top left coordinates
			Brush b = new SolidBrush(GetTabAreaBackColor());
			
			// Calculate initial top coordinate
			int top = -1;
			if ( HasHorizontalTabs() )
				top = tabsRect.Top + (tabsRect.Height - GLYPH_WIDTH)/2 + 1;
			else if ( tabsLocation == TabsLocation.Left && horizontalText && leftTabsTop )
				top = tabsRect.Bottom - (GLYPH_RIGHT_MARGIN+GLYPH_HEIGHT);
			else if ( tabsLocation == TabsLocation.Left )
				top = GLYPH_RIGHT_MARGIN;
			else if ( tabsLocation == TabsLocation.Right )
				top = tabsRect.Bottom - (GLYPH_RIGHT_MARGIN+GLYPH_HEIGHT);
			
			// Calculate initial left coordinate
			int left = -1;
			if ( HasHorizontalTabs() )
				left = tabsRect.Right - GLYPH_RIGHT_MARGIN;
			else if ( tabsLocation == TabsLocation.Left )
				left = tabsRect.Left + (tabsRect.Width - GLYPH_WIDTH)/2 + 1;
			else if ( tabsLocation == TabsLocation.Right )
				left = tabsRect.Left + (tabsRect.Width - GLYPH_WIDTH)/2 + 1;

			// Rotated image support
			int rotateOffset = 0;
			Matrix oldMatrix = g.Transform;
			Matrix m = new Matrix();

			// Select correct glyph image list
			ImageListEx localGlyphsImageList = glyphsImageList;
			if ( tabsStyle == TabsStyle.Office2003 )
				localGlyphsImageList = office2003GlyphsImageList;

			// Draw ShowClose button
			if ( showClose )
			{
				if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop )
				{
					// Rotate the image
					m.RotateAt(-90, new Point(left, top+GLYPH_HEIGHT), MatrixOrder.Append);
					rotateOffset = GLYPH_HEIGHT;
					closeRect = new Rectangle(left, top, GLYPH_WIDTH, GLYPH_HEIGHT);
				}
				else if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
				{
					// Rotate the image
					m.RotateAt(90, new Point(left, top), MatrixOrder.Append);
					rotateOffset = -GLYPH_HEIGHT;
					closeRect = new Rectangle(left, top, GLYPH_WIDTH, GLYPH_HEIGHT);
				}
				else
				{
					left -= GLYPH_WIDTH;
					closeRect = new Rectangle(left, top, GLYPH_WIDTH, GLYPH_HEIGHT);
				}

				if ( tabsStyle == TabsStyle.Office2003 )
				{
					Rectangle targetRect = new Rectangle(closeRect.Left, closeRect.Top, closeRect.Width, closeRect.Height);
					DrawOffice2003GlyphBackground(g, tabsRect, targetRect, -1);
				}
				else
					g.FillRectangle(b, closeRect.Left, closeRect.Top, closeRect.Width, closeRect.Height);

				if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
					g.Transform = m;

				if ( currentGlyphHit == TabControlHit.CloseButton && mouseButtonDownOnGlyph )
				{
					if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
						localGlyphsImageList.DrawImage(g, left+1, top+rotateOffset, (int)TabControlGlyphImages.CloseButton);
					else if ( tabsLocation == TabsLocation.Left )
						localGlyphsImageList.DrawImage(g, left-1, top+1+rotateOffset, (int)TabControlGlyphImages.CloseButton);
					else
						localGlyphsImageList.DrawImage(g, left+1, top+1, (int)TabControlGlyphImages.CloseButton);
				}
				else
				{
					if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
						localGlyphsImageList.DrawImage(g, left, top+1+rotateOffset, (int)TabControlGlyphImages.CloseButton);
					else
						localGlyphsImageList.DrawImage(g, left, top+rotateOffset, (int)TabControlGlyphImages.CloseButton);
				}

				// Reset matrix not to affect the next drawing
				if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
					g.Transform = oldMatrix;

				if ( currentGlyphHit == TabControlHit.CloseButton )
				{
					DrawUtil.Draw3DRect(g, closeRect, topLeftColor, rightBottomColor);
				}
			}
			
			if ( showClose == false )
			{
				if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop )
					rotateOffset = GLYPH_HEIGHT;
				else if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
					rotateOffset = -GLYPH_HEIGHT;
			}
												
			// Draw right arrow button
			if ( HasHorizontalTabs() )
				left -= GLYPH_WIDTH;
			else if ( tabsLocation == TabsLocation.Left && ShouldForceLeftTabsTop && showClose )
				top -= (GLYPH_HEIGHT);
			else if ( tabsLocation == TabsLocation.Left && showClose )
				top += GLYPH_HEIGHT;
			else if ( tabsLocation == TabsLocation.Right && showClose )
				top -= GLYPH_HEIGHT;
			rightArrowRect = new Rectangle(left, top, GLYPH_WIDTH, GLYPH_HEIGHT);

			int rightArrowState = (int)(IsRightArrowEnabled() ? 
				TabControlGlyphImages.RightArrowEnabled:TabControlGlyphImages.RightArrowDisabled);

			if ( tabsStyle == TabsStyle.Office2003 )
			{
				Rectangle targetRect = new Rectangle(rightArrowRect.Left, rightArrowRect.Top, 
					rightArrowRect.Width, rightArrowRect.Height);
				DrawOffice2003GlyphBackground(g, tabsRect, targetRect, -1);
			}
			else
				g.FillRectangle(b, rightArrowRect.Left, rightArrowRect.Top, rightArrowRect.Width, rightArrowRect.Height);
			
			if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop )
			{
				if ( m != null ) m.Dispose();
				m = new Matrix();
				m.RotateAt(-90, new Point(left, top+GLYPH_HEIGHT), MatrixOrder.Append);
			}
			else if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
			{
				// Rotate the image
				if ( m != null ) m.Dispose();
				m = new Matrix();
				m.RotateAt(90, new Point(left, top), MatrixOrder.Append);
			}

			if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
			{
				g.Transform = m;
			}
			            			
			if ( currentGlyphHit == TabControlHit.RightArrow && mouseButtonDownOnGlyph )
			{
				if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
					localGlyphsImageList.DrawImage(g, left+1, top+rotateOffset, rightArrowState);
				else if ( tabsLocation == TabsLocation.Left )
					localGlyphsImageList.DrawImage(g, left-1, top+1+rotateOffset, rightArrowState);
				else
					localGlyphsImageList.DrawImage(g, left+1, top+1, rightArrowState);
			}
			else
			{
				if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
					localGlyphsImageList.DrawImage(g, left, top+rotateOffset+1, rightArrowState);
				else
					localGlyphsImageList.DrawImage(g, left, top+rotateOffset, rightArrowState);
			}

			// Reset matrix
			if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
				g.Transform = oldMatrix;

			if ( currentGlyphHit == TabControlHit.RightArrow && IsRightArrowEnabled() )
			{
				DrawUtil.Draw3DRect(g, rightArrowRect, topLeftColor, rightBottomColor);
			}
				            		
			// Draw left arrow button
			if ( HasHorizontalTabs() )
				left -= GLYPH_WIDTH;
			else if ( tabsLocation == TabsLocation.Left && ShouldForceLeftTabsTop )
				top -= GLYPH_WIDTH;
			else if ( tabsLocation == TabsLocation.Left )
				top += GLYPH_HEIGHT;
			else if ( tabsLocation == TabsLocation.Right )
				top -= GLYPH_HEIGHT;

			leftArrowRect = new Rectangle(left, top, GLYPH_WIDTH, GLYPH_HEIGHT);
			int leftArrowState = (int)(IsLeftArrowEnabled() ?  
				TabControlGlyphImages.LeftArrowEnabled:TabControlGlyphImages.LeftArrowDisabled);

			if ( tabsStyle == TabsStyle.Office2003 )
			{
				Rectangle targetRect = new Rectangle(leftArrowRect.Left, 
					leftArrowRect.Top, leftArrowRect.Width, leftArrowRect.Height);
				DrawOffice2003GlyphBackground(g, tabsRect, targetRect, -1);
			}
			else
				g.FillRectangle(b, leftArrowRect.Left, leftArrowRect.Top, leftArrowRect.Width, leftArrowRect.Height);

			if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop )
			{
				if ( m != null ) m.Dispose();
				m = new Matrix();
				m.RotateAt(-90, new Point(left, top+GLYPH_HEIGHT), MatrixOrder.Append);
				g.Transform = m;
			}
			else if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
			{
				// Rotate the image
				if ( m != null ) m.Dispose();
				m = new Matrix();
				m.RotateAt(90, new Point(left, top), MatrixOrder.Append);
			}

			if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
			{
				g.Transform = m;
			}

			if ( currentGlyphHit == TabControlHit.LeftArrow && mouseButtonDownOnGlyph )
			{
				if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
					localGlyphsImageList.DrawImage(g, left+1, top+rotateOffset, leftArrowState);
				else if ( tabsLocation == TabsLocation.Left )
					localGlyphsImageList.DrawImage(g, left-1, top+1+rotateOffset, leftArrowState);
				else
					localGlyphsImageList.DrawImage(g, left+1, top+1, leftArrowState);
			}
			else
			{
				if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
					localGlyphsImageList.DrawImage(g, left, top+rotateOffset+1, leftArrowState);
				else
					localGlyphsImageList.DrawImage(g, left, top+rotateOffset, leftArrowState);
			}

			// Reset matrix
			if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
				g.Transform = oldMatrix;

			if ( currentGlyphHit == TabControlHit.LeftArrow && IsLeftArrowEnabled() )
				DrawUtil.Draw3DRect(g, leftArrowRect, topLeftColor, rightBottomColor);

			// Cleanup
			if ( m != null ) m.Dispose();
			b.Dispose();

		}
		
		void DrawTabs(Graphics g)
		{
			if ( IsHorizontalText())
			{
				// If using horizontal text on vertical tabs
				// the tab width of every tab will be the greatest width among all tabs
				tabWidth = GetGreatestTabWidth();
				
				// In case the TabsFitting style is set to Multiline
				numberOfMutilineRows = 1;
			}
			else if ( tabsFitting == TabsFitting.ShrinkTabs  )
			{
				firstVisiblePageIndex = 0;
				int shrunkWidth;
				bool tabsFit = CanTabsFit(g, out shrunkWidth);
				if ( tabPages.Count != 0 && !tabsFit )
				{
					tabWidth = shrunkWidth;
				}
				else
					tabWidth = -1;
			}
			else if ( tabsFitting == TabsFitting.FullWidth )
			{
				firstVisiblePageIndex = 0;
				if ( tabPages.Count > 0 )
				{
					int unhiddenCount = GetUnhiddenTabPageCount();
					if ( HasHorizontalTabs() )
						tabWidth = (ClientRectangle.Width - MULTILINE_EDGE_MARGIN*2)/unhiddenCount;
					else
						tabWidth = (ClientRectangle.Height - MULTILINE_EDGE_MARGIN*2)/unhiddenCount;
				}
			}
			else if ( tabsFitting == TabsFitting.ShowArrows )
			{
				// This flags the logic ahead that
				// the width of every tab will have to be calculated
				// as we are going to draw every visible tab using
				// its actual size
				tabWidth = -1;
			}
			else if ( tabsFitting == TabsFitting.MultiLine )
			{
				firstVisiblePageIndex = 0;
				int shrunkWidth;
				bool tabsFit = CanTabsFit(g, out shrunkWidth);
				if ( tabsFit )
				{
					// Tabs fit, we don't have to do anything
					// special
					numberOfMutilineRows = 1;
					tabWidth = -1;
				}
				else
				{
					int firstTabRowIndex = -1;
					if ( IsOneNoteTabStyle() )
					{
						if ( multilineRows != null && multilineRows.Count > 1 )
						{
							TabsRowHelper trh = (TabsRowHelper)multilineRows[0];
							firstTabRowIndex = trh.StartIndex;
						}

						needRowTableCalculation = true;
					}
										
					CalculateRowsTable(g);
					firstVisiblePageIndex = 0;
					tabWidth = -1;

					if ( IsOneNoteTabStyle() && firstTabRowIndex != -1)	
					{
						int frontRowIndex = GetRowIndex(firstTabRowIndex) ;
						MoveRowToFront(frontRowIndex);
					}

					// Make sure Fist Visible page index in synch in case we have hidden pages
					for ( int i = 0; i < tabPages.Count; i++ )
					{
						TabPageEx px = tabPages[i];
						if ( px.HideTab == false )
						{
							firstVisiblePageIndex = i;
							break;
						}
					}
				}
			}
			else if ( tabsFitting == TabsFitting.FixedWidth )
			{
				tabWidth = -1;
			}

			OneNoteColors oneNoteColors = null;
			if ( IsOneNoteTabStyle() )
				oneNoteColors = ColorUtil.GetOneNoteColors(tabsStyle, selectedTabIndex);

			int localFirstTabMargin = firstTabMargin;
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
				localFirstTabMargin = 0;

			// Draw Tabs
			int xPos = 0;
			if ( HasHorizontalTabs() )
				if ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth || tabsFitting == TabsFitting.ShrinkTabs)
					xPos = localFirstTabMargin;
				else
					xPos = 1;
			else if ( tabsLocation == TabsLocation.Left )
				xPos = 0;
			else if ( tabsLocation == TabsLocation.Right )
				xPos = ClientRectangle.Right - TabsAreaWidth;

			int yPos = 1;
			if ( HasHorizontalTabs() )
				yPos = TabsArea.Top;
			else if ( tabsLocation == TabsLocation.Right || (tabsLocation == TabsLocation.Left && IsHorizontalText() && leftTabsTop) )
				if ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth )
					yPos = ClientRectangle.Top + localFirstTabMargin;
				else
					yPos = ClientRectangle.Top + 1;	
			else if ( tabsLocation == TabsLocation.Left )
				if (  tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth )
					yPos = ClientRectangle.Bottom - localFirstTabMargin;
				else
					yPos = ClientRectangle.Bottom - 1;
						
			// Bounds for the tabs
			int leftXArrowPos = LeftArrowXPos();
			int leftYArrowPos = LeftArrowYPos();

			lastVisiblePageIndex = 0;
			int localTabsAreaHeight = TabsAreaHeight;
			if( tabsFitting != TabsFitting.MultiLine || (tabsFitting == TabsFitting.MultiLine && numberOfMutilineRows == 1) )
			{
				for ( int i = firstVisiblePageIndex; i < tabPages.Count; i++ )
				{
					TabPageEx currentTab =  tabPages[i];
					if ( currentTab.HideTab == false )
					{
						DrawTab(g, currentTab, ref xPos, ref yPos, 0, false, localTabsAreaHeight, oneNoteColors);
					}
					else
					{
						currentTab.TabRectangle = Rectangle.Empty;
					}
					lastVisiblePageIndex = i;

					if ( HasHorizontalTabs() )
					{
						if ( ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth ) && xPos >= leftXArrowPos )
							break;
					}
					else if ( tabsLocation == TabsLocation.Left )
					{
						if ( IsHorizontalText() && leftTabsTop )
						{
							if ( ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth ) && yPos >= leftYArrowPos )
								break;
						}
						else
						{
							if ( (tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth ) && yPos <= leftYArrowPos )
								break;
						}
					}
					else if ( tabsLocation == TabsLocation.Right )
					{
						if ( ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth ) && yPos >= leftYArrowPos )
							break;
					}
				}
			}
			else
			{
				// Tabs don't fit in one line and the tabsFitting property is multiline
				Debug.Assert(multilineRows.Count  > 1);
				
				int startCounter = multilineRows.Count - 1;
				int endCounter = 0;
				
				if ( tabsLocation == TabsLocation.Top )
				{
					yPos = 0;
				}
				else if ( tabsLocation == TabsLocation.Bottom )
				{
					yPos = ClientRectangle.Height;
				}
				else if ( tabsLocation == TabsLocation.Right )
				{
					xPos = ClientRectangle.Right;
				}
				else if ( tabsLocation == TabsLocation.Left )
				{
					xPos = ClientRectangle.Left;
				}

				// Start of the rows
				int initialX = xPos;
				int initialY = yPos;
				       
				bool done = false;
				int i = startCounter;
							
				while ( done == false )
				{
					if ( tabsLocation == TabsLocation.Bottom )
						yPos -= GetMultilineRowHeight(i);
					else if ( tabsLocation == TabsLocation.Right )
						xPos -= GetMultilineRowHeight(i); 

					drawingRowIndex = i;
					TabsRowHelper currentTabRowHelper = (TabsRowHelper)multilineRows[i];
					int startIndex = currentTabRowHelper.StartIndex;
					int endIndex = currentTabRowHelper.EndIndex;

					// Calculate tabWidth for this row
					int rowWidth = GetRowWidth(startIndex, endIndex);
					

					// Calculate the the extra width for the last tab
					tabExtraWidth = 0;
					int visibleTabs = GetNumberOfVisibleTabs(currentTabRowHelper);
					if ( HasHorizontalTabs() )
					{
						if ( visibleTabs > 0 )
						{
							tabExtraWidth = ((ClientRectangle.Width - MULTILINE_EDGE_MARGIN*2) 
								- rowWidth)/visibleTabs;
							lastTabRemainder = ((ClientRectangle.Width - MULTILINE_EDGE_MARGIN*2) 
								- rowWidth)%visibleTabs;
						}
					}
					else
					{
						if ( visibleTabs > 0 )
						{
							tabExtraWidth = ((ClientRectangle.Height 
								- MULTILINE_EDGE_MARGIN*2) - rowWidth)/visibleTabs;
							lastTabRemainder = ((ClientRectangle.Height 
								- MULTILINE_EDGE_MARGIN*2) - rowWidth)%visibleTabs;
						}
					}
					
					for ( int j = startIndex; j <= endIndex; j++ )
					{
																
						TabPageEx currentTab =  tabPages[j];
						if ( currentTab.HideTab == false )
						{
							DrawTab(g, currentTab, ref xPos, ref yPos, i, false, localTabsAreaHeight, oneNoteColors);
						}
						else
						{
							currentTab.TabRectangle = Rectangle.Empty;
						}
					}

					// Move xPos to the next row
					if ( tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Bottom )
						xPos = initialX;
					else if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
						yPos = initialY;

					if ( tabsLocation == TabsLocation.Top )
						yPos += GetMultilineRowHeight(i);
					if ( tabsLocation == TabsLocation.Left )
						xPos += GetMultilineRowHeight(i);

					i--;
					if (i < endCounter)
						done = true;

				}
			}
		}

		int GetMultilineRowHeight(int rowIndex)
		{
			int tabsAreaHeight = TabsAreaHeight;
			int rowHeight = tabsAreaHeight / multilineRows.Count;
			if ( (tabsStyle == TabsStyle.Standard || tabsStyle  == TabsStyle.XPTheme 
				|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) && multilineRows.Count > 1 )
			{
				rowHeight = tabsAreaHeight - 3;
				rowHeight /= multilineRows.Count; 
				if ( rowIndex == 0 )
				{
					// The row closest to the tab control is two pixel wider
					rowHeight += 2;
				}
				else if ( rowIndex == multilineRows.Count - 1 )
				{
					// Last row is one pixel wider than the others
					rowHeight += 1;
				}
			}
			
			return rowHeight;
		}

		int GetNumberOfVisibleTabs(TabsRowHelper trh)
		{
			int count = 0;
			for ( int i = trh.StartIndex; i <= trh.EndIndex; i++ )
			{
				TabPageEx page = tabPages[i];
				if ( page.HideTab == false )
					count++;
			}

			return count;
		}

		void CalculateRowsTable(Graphics g)
		{
			if ( needRowTableCalculation == false )
				return;
			
			// Flag that we are in the middle of the calculation
			calculatingRowsTable = true;
			bool dispose = false;
			if ( g == null )
			{
				g = CreateGraphics();
				dispose = true;
			}

			int shrunkWidth;
			bool tabsFit = CanTabsFit(g, out shrunkWidth);
			// No need to multilines rows if all tabs fit
			if ( tabsFit ) 
			{
				// Just create a one row array
				multilineRows = new ArrayList();
				TabsRowHelper firstRow = new TabsRowHelper(tabPages.Count);
				firstRow.StartIndex = 0;
				firstRow.EndIndex = tabPages.Count - 1;
				multilineRows.Add(firstRow);
				if ( dispose ) g.Dispose();
				return;
			}

			// Calculate how many rows we would need if the tabs were to fit 
			// one after another
			int totalTabsWidth = 0;
			pageWidthArray = new int[tabPages.Count]; 
			for (int i = 0; i < tabPages.Count; i++ )
			{
				TabPageEx currentTab =  tabPages[i];
				int currentWidth = GetTabWidth(g, currentTab);
				totalTabsWidth += currentWidth;
				pageWidthArray[i] = currentWidth;
			}

			Debug.Assert(totalTabsWidth > 0);
			if ( HasHorizontalTabs() )
				numberOfMutilineRows = totalTabsWidth/(ClientRectangle.Width-MULTILINE_EDGE_MARGIN*2) + 1;
			else
				numberOfMutilineRows = totalTabsWidth/(ClientRectangle.Height-MULTILINE_EDGE_MARGIN*2) + 1;
					
			// Now apply the actual algorithm that calculates 
			// how many rows are actually displayed for each row
			CalculateRowsLayout();

			if ( dispose ) g.Dispose();

			// Flag that we don't need to calculate again until a tab is added or removed
			// or the tab control is resized
			needRowTableCalculation = false; 

			// Flag that we are done calculating
			calculatingRowsTable = true;

		}

		ArrayList CreateIdealRowsArray()
		{
			// Calculate what would be the perfect layout for the 
			// distribution of the tabs in each row
			Debug.Assert(numberOfMutilineRows > 1);
			int pageCount = tabPages.Count;
			int rowNumberOfTabs = pageCount / numberOfMutilineRows;
			int remainingTabs = (pageCount) % (numberOfMutilineRows);
			int addingIndex = numberOfMutilineRows - remainingTabs;
			
			multilineRows = new ArrayList(numberOfMutilineRows);
			int tabs = 0;
			for ( int i = 0; i < numberOfMutilineRows; i++ )
			{
				
				tabs = rowNumberOfTabs;
								
				// Add extra tabs if we are on the last indices that 
				// will get the overflow tabs
				if ( i >= addingIndex )
					tabs++;
								
				multilineRows.Add(new TabsRowHelper(tabs));
			}

			return multilineRows;
		}

		void CalculateRowsLayout()
		{
			multilineRows = CreateIdealRowsArray();

			bool done = false;
			int currentTabIndex = 0;
			bool recreateIdealArray = false;
			while ( done != true )
			{
				recreateIdealArray = false;
				for ( int i = 0; i < multilineRows.Count; i++ )
				{
					TabsRowHelper currentRowHelper = (TabsRowHelper)multilineRows[i];
					currentRowHelper.StartIndex = currentTabIndex;
					currentRowHelper.EndIndex = currentRowHelper.StartIndex + currentRowHelper.NumberOfTabs - 1;
					                    
					bool fit = CanTabsFitInRow(currentRowHelper.StartIndex, currentRowHelper.EndIndex);
					if ( !fit && currentRowHelper.NumberOfTabs > 1 )
					{
						if ( i == 0 )
						{
							PushTabsDown(currentRowHelper, multilineRows, i);
						}
						else if ( i != multilineRows.Count - 1 )
						{
							// If this is a row that is not the first or the last one
							// Try to push the tabs up first
							PushTabsUp(currentRowHelper, multilineRows, i);

							fit = CanTabsFitInRow(currentRowHelper.StartIndex, currentRowHelper.EndIndex);
							if ( !fit )
							{
								// If tabs still did not fit, then push tabs down
								PushTabsDown(currentRowHelper, multilineRows, i);
							}
						}
						else
						{
							// If this is the last row
							PushTabsUp(currentRowHelper, multilineRows, i);
							fit = CanTabsFitInRow(currentRowHelper.StartIndex, currentRowHelper.EndIndex);
							if ( !fit )
							{
								// If tabs still did not fit, then we don't have enough space,
								// create an extra row
								numberOfMutilineRows++;
								recreateIdealArray = true;
							}
						}
					}
					else
					{
						SetCanAcceptMoreTabsFlag(currentRowHelper, currentRowHelper.StartIndex, currentRowHelper.EndIndex);
						if ( i == multilineRows.Count - 1 )
							done = true;
					}

					// Update the start index for the next row
					currentTabIndex = currentRowHelper.EndIndex + 1;

				}

				if ( recreateIdealArray )
				{
					// Force a recalculation of the ideal array
					multilineRows = CreateIdealRowsArray();
					recreateIdealArray = false;
				}

				// Reset current start index
				currentTabIndex = 0;

			}
		}

		void PushTabsUp(TabsRowHelper currentRowHelper, ArrayList rows, int currentRow)
		{
			bool tabsFit = false;
			currentRowHelper.CanAcceptMoreTabs = false;
			TabsRowHelper beforeRowHelper = (TabsRowHelper)rows[currentRow-1];
			while ( !tabsFit && beforeRowHelper.CanAcceptMoreTabs )
			{
				beforeRowHelper.NumberOfTabs += 1;
				beforeRowHelper.EndIndex += 1;

				// Update indexes for the current row
				currentRowHelper.StartIndex += 1;
				currentRowHelper.NumberOfTabs -= 1;
							                                
				SetCanAcceptMoreTabsFlag(beforeRowHelper, beforeRowHelper.StartIndex, beforeRowHelper.EndIndex);

				tabsFit = CanTabsFitInRow(currentRowHelper.StartIndex, currentRowHelper.EndIndex);
			}
		}

		void PushTabsDown(TabsRowHelper currentRowHelper, ArrayList rows, int currentRow)
		{
			bool tabsFit = false;
			currentRowHelper.CanAcceptMoreTabs = false;
			while ( !tabsFit )
			{
				// If this is the first row
				currentRowHelper.NumberOfTabs -= 1;
				currentRowHelper.EndIndex -= 1;
				Debug.Assert(currentRowHelper.NumberOfTabs>0);
				
				// Put the overflow tab in the next row, we are going to check how it fits on
				// the next iteration or loop 
				if ( currentRow+1 < rows.Count )
				{
					TabsRowHelper nextRowHelper = (TabsRowHelper)rows[currentRow+1];
					nextRowHelper.NumberOfTabs += 1;
				}

				tabsFit = CanTabsFitInRow(currentRowHelper.StartIndex, currentRowHelper.EndIndex); 
			}
		}

		void SetCanAcceptMoreTabsFlag(TabsRowHelper currentRowHelper, int startIndex, int endIndex)
		{
			// Tabs do fit but check if we can actually fit the next one
			// so that we don't waste time trying to push up on the next iteration or loop
			if ( endIndex + 1 <  tabPages.Count )
			{
				bool doFit = CanTabsFitInRow(startIndex, endIndex+1);
				if ( !doFit )
					currentRowHelper.CanAcceptMoreTabs = false;
			}
			else
			{
				// No more tabs available, we must be in the last row
				currentRowHelper.CanAcceptMoreTabs = false;
			}
		}

		bool CanTabsFitInRow(int startIndex, int endIndex)
		{
			Debug.Assert(pageWidthArray.Length > 0 && pageWidthArray.Length > endIndex);
			int tabsWidth = 0;
			for ( int i = startIndex; i <= endIndex; i++ )
			{
				tabsWidth += pageWidthArray[i];
			}

			if ( HasHorizontalTabs() )
			{
				if ( tabsWidth < (ClientRectangle.Width - MULTILINE_EDGE_MARGIN*2) )
					return true;
			}
			else
			{
				if ( tabsWidth < (ClientRectangle.Height - MULTILINE_EDGE_MARGIN*2) )
					return true;
			}

			return false;
            
		}

		int GetRowWidth(int startIndex, int endIndex)
		{
			Debug.Assert(pageWidthArray.Length > 0 && pageWidthArray.Length > endIndex);
			int tabsWidth = 0;
			for ( int i = startIndex; i <= endIndex; i++ )
			{
				tabsWidth += pageWidthArray[i];
			}

			return tabsWidth;
		}

		bool IsLastTab(int rowIndex, int tabIndex)
		{
			Debug.Assert(rowIndex < multilineRows.Count);
			TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];
			if ( tabIndex == trh.EndIndex || IsLastVisibleTab(rowIndex, tabIndex) )
				return true;
	
			return false;
		}

		bool IsLastVisibleTab(int rowIndex, int tabIndex)
		{
			// Check if all tabs after the current tab index
			// are hidden
			Debug.Assert(rowIndex < multilineRows.Count);
			TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];
			for ( int i = tabIndex+1; i <= trh.EndIndex; i++ )
			{
				TabPageEx pageEx = tabPages[i];
				if ( pageEx.HideTab == false )
					return false;
			}

			return true;

		}

		bool IsLastTabInRow(int rowIndex, int tabIndex)
		{
			TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];
			if ( tabIndex == trh.EndIndex || IsLastVisibleTab(rowIndex, tabIndex) )
				return true;
						
			return false;
		}

		bool IsFirstTabInRow(int rowIndex, int tabIndex)
		{
			Debug.Assert(rowIndex != -1 && tabIndex != -1);
			if ( multilineRows != null && rowIndex < multilineRows.Count )
			{
				TabsRowHelper trh = (TabsRowHelper)multilineRows[rowIndex];
				if ( tabIndex == trh.StartIndex )
					return true;
			}
						
			return false;
		}

		int GetRowIndex(int tabIndex)
		{
			if ( multilineRows.Count == 1 )
				return 0;

			for ( int i = 0; i < multilineRows.Count; i++ )
			{
				TabsRowHelper trh = (TabsRowHelper)multilineRows[i];
				if ( tabIndex >= trh.StartIndex && tabIndex <= trh.EndIndex)
					return i;
			}
			
			return -1;
		}

		void DrawTab(Graphics g, TabPageEx page, ref int xPos, ref int yPos, 
			int rowIndex, bool doubleBuffering, int localTabsAreaHeight, OneNoteColors oneNoteColors)
		{
			int index = tabPages.IndexOf(page);
			int currentTabWidth = tabWidth;
			bool isHorizontalText = IsHorizontalText();
			
			if ( currentTabWidth == -1 )
			{
				// Tabs are not all same width
				// calculate the tab width
				if ( doubleBuffering == false )
				{
					// If used fixed width and enforcing FixedWidth no need to calculate
					// the tab width
					bool usingFixedWidth = tabsFitting == TabsFitting.FixedWidth && alwaysUseFixedWidth == true;
					if ( usingFixedWidth )
						currentTabWidth = fixedWidth;
					else
						currentTabWidth = GetTabWidth(g, page);
						
					if ( tabsFitting == TabsFitting.MultiLine && numberOfMutilineRows > 1)
					{
						currentTabWidth += tabExtraWidth;
						if ( IsLastTab(rowIndex, index) )
						{
							currentTabWidth += lastTabRemainder;
						}
					}
					else if ( tabsFitting == TabsFitting.FixedWidth && alwaysUseFixedWidth == false )
					{
						if ( currentTabWidth > fixedWidth )
							currentTabWidth = fixedWidth;
					}
				}
				else
				{
					if ( HasHorizontalTabs() )
						currentTabWidth = page.TabRectangle.Width;
					else
						currentTabWidth = page.TabRectangle.Height;
				}
			}
			else if ( (tabsFitting == TabsFitting.FullWidth 
				|| tabsFitting == TabsFitting.ShrinkTabs ) && index == tabPages.Count -1 )
			{
				// Only if using vertical text
				if ( isHorizontalText == false )
				{
					// For the last page if we are using the full width tab fitting, add the
					// remainder to the last tab so that we fill the width completely
					int visiblePages = GetUnhiddenTabPageCount(); 
					if ( HasHorizontalTabs() )
					{
						currentTabWidth += (ClientRectangle.Width - 2) - 
							currentTabWidth * visiblePages;
					}
					else
					{
						currentTabWidth += (ClientRectangle.Height - 2) - 
							currentTabWidth * visiblePages;
					}
				}
			}

			if ( tabsFitting == TabsFitting.MultiLine && multilineRows.Count > 1 )
			{
				localTabsAreaHeight = GetMultilineRowHeight(rowIndex);
			}
			
			Rectangle tabAreaRect = Rectangle.Empty;
			if ( HasHorizontalTabs() )
				tabAreaRect = new Rectangle(xPos, yPos, currentTabWidth, localTabsAreaHeight);
			else if ( tabsLocation == TabsLocation.Left )
			{
				if ( yPos == 0 )
				{
					if ( isHorizontalText )
					{
						tabAreaRect = new Rectangle(xPos, yPos, currentTabWidth, localTabsAreaHeight);
					}
					else
					{
						// Doing double buffering draw
						tabAreaRect = new Rectangle(xPos, yPos, localTabsAreaHeight, currentTabWidth);
					}
				}
				else
				{
					if ( isHorizontalText && leftTabsTop )
					{
						tabAreaRect = new Rectangle(xPos, yPos, currentTabWidth, localTabsAreaHeight);
					}
					else if ( isHorizontalText )
					{
						tabAreaRect = new Rectangle(xPos, yPos-localTabsAreaHeight, currentTabWidth, localTabsAreaHeight);
					}
					else
					{
						tabAreaRect = new Rectangle(xPos, yPos-currentTabWidth, localTabsAreaHeight, currentTabWidth);
					}
				}
			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				if ( isHorizontalText )
					tabAreaRect = new Rectangle(xPos, yPos, currentTabWidth, localTabsAreaHeight);
				else
					tabAreaRect = new Rectangle(xPos, yPos, localTabsAreaHeight, currentTabWidth);
			}

			Rectangle tabRect = CalculateTabRect(tabAreaRect);

			// One Note offset
			int oneNoteHeight = tabRect.Height;
			if ( HasVerticalTabs() && !isHorizontalText )
				oneNoteHeight = tabRect.Width;

			Rectangle tabShapeRect = tabAreaRect;
			bool firstTabRowIndex = false;
			if ( IsOneNoteTabStyle() && !IsHorizontalText() && index == selectedTabIndex && (index != 0
				&& index != firstVisiblePageIndex) )
			{
				bool doOffset =  true;
				firstTabRowIndex = IsFirstTabInRow(rowIndex, index);
				if ( tabsFitting == TabsFitting.MultiLine && firstTabRowIndex )
					doOffset = false;
				if ( doOffset )
				{
					if ( HasVerticalTabs() && !isHorizontalText )
					{
						if ( tabsLocation == TabsLocation.Left )
						{
							tabShapeRect = new Rectangle(tabAreaRect.Left, tabAreaRect.Top, 
								tabAreaRect.Width, tabAreaRect.Height + oneNoteHeight - OVERLAPPING_GAP);
						}
						else
						{
							tabShapeRect = new Rectangle(tabAreaRect.Left, tabAreaRect.Top - oneNoteHeight + OVERLAPPING_GAP, 
								tabAreaRect.Width, tabAreaRect.Height + oneNoteHeight - OVERLAPPING_GAP);
						}
					}
					else
					{  
						tabShapeRect = new Rectangle(tabAreaRect.Left - oneNoteHeight + OVERLAPPING_GAP, tabAreaRect.Top, 
							tabAreaRect.Width + oneNoteHeight - OVERLAPPING_GAP, tabAreaRect.Height);
					}
				}
			}

			// Draw the actual tab --shape of the tab--
			DrawTab(g, page, tabShapeRect, oneNoteColors);

			if ( IsOneNoteTabStyle() )
			{
				bool horizontalTextLeftTabs = IsHorizontalText() && tabsLocation == TabsLocation.Left;
				bool firstHorizontalTextRightTab = tabsLocation == TabsLocation.Right && horizontalText && index == 0;
				bool veryFirstTab = index == 0  || index == firstVisiblePageIndex || firstTabRowIndex;
				bool noMultilines = (tabsFitting != TabsFitting.MultiLine || (multilineRows != null && multilineRows.Count == 1))
					|| IsHorizontalText();
				if ( noMultilines && !firstHorizontalTextRightTab && (horizontalTextLeftTabs || veryFirstTab) )
				{
					// Offset the tabRect if we are using OneNote tab style and the tab is the first index
					if ( HasVerticalTabs() && !isHorizontalText )
					{
						if ( tabsLocation == TabsLocation.Left )
							tabRect = new Rectangle(tabRect.Left, tabRect.Top - oneNoteHeight, tabRect.Width, tabRect.Height);
						else
							tabRect = new Rectangle(tabRect.Left, tabRect.Top + oneNoteHeight, tabRect.Width, tabRect.Height);
					}
					else
						tabRect = new Rectangle(tabRect.Left + oneNoteHeight, tabRect.Top, tabRect.Width, tabRect.Height);
				}
			}
			
			// Don't draw separator if forcing horizontal text on Vertical Tabs
			if ( !isHorizontalText )
			{
				// Draw separator
				// --Don't draw it if this tab is the one immediately before the selected tab
				if ( tabsFitting == TabsFitting.MultiLine && multilineRows.Count > 1)
				{
					if ( index != selectedTabIndex && index != (selectedTabIndex - 1) 
						&& IsLastTab(rowIndex, index) == false && ( GetVisibleIndexAfterIndex(index) != selectedTabIndex ) )
						DrawTabSeparator(g, tabRect, false, rowIndex);
				}
				else 
				{
					if ( index != selectedTabIndex && index != ( selectedTabIndex - 1 ) 
						&& !( tabsFitting == TabsFitting.FullWidth && index == tabPages.Count -1) 
						&& ( GetVisibleIndexAfterIndex(index) != selectedTabIndex ) )
						DrawTabSeparator(g, tabAreaRect, false, rowIndex);
				}
			}

			//  Draw Tab Icon
			int drawX = 0;
			int drawY = 0;
			// Reset rectangle just in case there is not available icon
			// so that the GetTabIconRectangle returns the right information
			page.IconRectangle = Rectangle.Empty;

			// Now do the drawing of the icon
			DrawIcon(g, page, tabRect, ref drawX, ref drawY);
			
			// Draw Text
			DrawText(g, page, tabRect, drawX, drawY);

			// increase the position of the tab
			// xPos for the next tab
			if ( HasHorizontalTabs() )
				xPos += currentTabWidth;
			else if ( tabsLocation == TabsLocation.Right || ( tabsLocation == TabsLocation.Left && isHorizontalText && leftTabsTop) )  
			{
				if ( isHorizontalText )
					yPos += localTabsAreaHeight;
				else
					yPos += currentTabWidth;
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				if ( isHorizontalText )
					yPos -= localTabsAreaHeight;
				else
					yPos -= currentTabWidth;
			}
			
			// Save tab rectangle for easy hit testing
			page.TabRectangle = tabAreaRect;
			
			// Draw focus rectangle if we need to
			if ( drawFocusRectangle && Focused && index == selectedTabIndex )
			{
				using ( Pen p = new Pen(focusRectangleColor) )
				{
					Rectangle focusRect = tabRect;
					focusRect.Inflate(-3,-2);
					p.DashStyle = DashStyle.Dot;
					g.DrawRectangle(p, focusRect);
				}
			}

			// Hook up some possible extra drawing
			DrawTabAdorments(g, page, tabAreaRect);
		}

		void DrawIcon(Graphics g, TabPageEx page, Rectangle tabRect, ref int drawX, ref int drawY)
		{
			bool hasHorizontalTabs = HasHorizontalTabs();
			int index = tabPages.IndexOf(page);
			bool isHorizontalText = IsHorizontalText();

			ImageListEx iconImageList = null;
			int imageIndex = -1;
			if ( index == selectedTabIndex && 
				showIcon && selectedImageList != null && page.SelectedImageIndex != -1)
			{
				iconImageList = selectedImageList;
				imageIndex = page.SelectedImageIndex;
			}
			else if ( showIcon && imageList != null && page.ImageIndex != -1 )
			{
				iconImageList = imageList;
				imageIndex = page.ImageIndex;
				if ( hotTrack && hotTrackIndex == index )
				{
					if ( selectedImageList != null && page.SelectedImageIndex != -1 )
					{
						iconImageList = selectedImageList;
						imageIndex = page.SelectedImageIndex;
					}
				}
			}
									
			if ( hasHorizontalTabs || isHorizontalText )
			{
				drawX = tabRect.Left + TAB_LEFT_TEXT_MARGIN;
				if ( iconImageList != null )
					drawY = tabRect.Top + (tabRect.Height - iconImageList.ImageSize.Height)/2;
			}
			else 
			{
				if ( iconImageList != null )
					drawX = tabRect.Left + (tabRect.Width - iconImageList.ImageSize.Height)/2;
				if ( tabsLocation == TabsLocation.Left )
					drawY = tabRect.Bottom - TAB_LEFT_TEXT_MARGIN;
				else
					drawY = tabRect.Top + TAB_LEFT_TEXT_MARGIN;
			}
			
			// Don't try to center icon if forcing horizontal text on Vertical Tabs
			if ( !isHorizontalText )
			{
				if ( tabsFitting == TabsFitting.FullWidth || tabsFitting == TabsFitting.MultiLine )
				{
					// Center Icon if in FullWidth mode
					int actualWidth = GetTabWidth(g, page);
					
					// Decrease the extra width that OneNote tabs style get 
					// so that the icon and text get actually centered
					int oneNoteOffset = 0;
					if ( IsOneNoteTabStyle() && tabsFitting != TabsFitting.FullWidth)
					{
						if ( hasHorizontalTabs )
							oneNoteOffset = tabRect.Height/2;
						else
							oneNoteOffset = tabRect.Width/2;
					}

					if ( hasHorizontalTabs &&  tabRect.Width > actualWidth ) 
						drawX = tabRect.Left + oneNoteOffset + (tabRect.Width - 
							(actualWidth - (TAB_LEFT_TEXT_MARGIN+TAB_RIGHT_TEXT_MARGIN)))/2;  
					else if ( tabsLocation == TabsLocation.Left && tabRect.Height > actualWidth )
						drawY = tabRect.Bottom - oneNoteOffset - (tabRect.Height - actualWidth)/2 - TAB_LEFT_TEXT_MARGIN; 
					else if ( tabsLocation == TabsLocation.Right && tabRect.Height > actualWidth )
						drawY = tabRect.Top + oneNoteOffset + (tabRect.Height - actualWidth)/2 + TAB_LEFT_TEXT_MARGIN; 
				}
			}

			// Nothing to do if we don't have a valid image list
			if ( iconImageList == null ) return;

			if ( hasHorizontalTabs || isHorizontalText )
			{
				if ( page.Enabled == false )
					iconImageList.DrawImageDisabled(g, drawX, drawY, imageIndex);
				else
					iconImageList.DrawImage(g, drawX, drawY, imageIndex);
			}
			else
			{
				// We have vertical tabs, we need to rotate the graphic object
				// so that the icon shows aligned with the text direction
				Matrix oldMatrix = g.Transform;
				Matrix m = new Matrix();
				if ( tabsLocation == TabsLocation.Left )
				{
					m.RotateAt(-90, new Point(drawX, drawY), MatrixOrder.Append);
					g.Transform = m;
					if ( page.Enabled == false )
						iconImageList.DrawImageDisabled(g, drawX, drawY, imageIndex);
					else
						iconImageList.DrawImage(g, drawX, drawY, imageIndex);
				}
				else
				{
					m.RotateAt(90, new Point(drawX + iconImageList.ImageSize.Height, drawY), MatrixOrder.Append);
					g.Transform = m;
					if ( page.Enabled == false )
						iconImageList.DrawImageDisabled(g, drawX + iconImageList.ImageSize.Height, drawY, imageIndex);
					else
						iconImageList.DrawImage(g, drawX + iconImageList.ImageSize.Height, drawY, imageIndex);
				}

				// Reset matrix
				g.Transform = oldMatrix;
			}

			// Save the icon rectangle for the tab for easy hit testing
			if ( hasHorizontalTabs )
				page.IconRectangle = new Rectangle(drawX, drawY, iconImageList.ImageSize.Width, iconImageList.ImageSize.Height);
			else
			{
				if ( tabsLocation == TabsLocation.Left && !isHorizontalText )
				{
					page.IconRectangle = new Rectangle(drawX, drawY-iconImageList.ImageSize.Width, 
						iconImageList.ImageSize.Height, iconImageList.ImageSize.Width);
				}
				else
				{
					page.IconRectangle = new Rectangle(drawX, drawY, 
						iconImageList.ImageSize.Height, iconImageList.ImageSize.Width);
				}
			}
			
			drawX += iconImageList.ImageSize.Width + ICON_TO_TEXT_MARGIN;
			if ( !hasHorizontalTabs && !isHorizontalText )
			{
				if ( tabsLocation == TabsLocation.Left )
					drawY -= iconImageList.ImageSize.Width + ICON_TO_TEXT_MARGIN;
				else
					drawY += iconImageList.ImageSize.Width + ICON_TO_TEXT_MARGIN;
			}
			
		}

		void DrawText(Graphics g, TabPageEx page, Rectangle tabRect, int drawX, int drawY)
		{
			int index = tabPages.IndexOf(page);
			bool isHorizontalText = IsHorizontalText();
			if ( !showText || ( showOnlySelectedTabText && index != selectedTabIndex ) && !isHorizontalText ) return;
									
			// Draw text to fit within the tabRectangle
			Font font = Font;
			Color currentTextColor = textColor;
			if ( page.TextColor != Color.Empty )
				currentTextColor = page.TextColor;

			if ( hotTrack && hotTrackIndex == index )
				currentTextColor = hotTextColor;

			bool cleanupFont = false;
			if ( index == selectedTabIndex && showSelectedTextBold )
			{
				cleanupFont = true;
				font = new Font(font, FontStyle.Bold);
			}

			if ( page.Enabled == false )
			{
				currentTextColor = ControlPaint.LightLight(Color.Black);
			}
		            							
			DrawTextFormatFlags flags = DrawTextFormatFlags.DT_SINGLELINE | DrawTextFormatFlags.DT_LEFT;
			string title = page.Title;
			Size textSize = TextUtil.GetTextSize(g, title, font, flags);
			Rectangle rcText = Rectangle.Empty;

			StringFormat format = new StringFormat();
			format.Trimming = StringTrimming.EllipsisWord;
			format.LineAlignment = StringAlignment.Near;
			format.Alignment = StringAlignment.Near;
			format.FormatFlags = StringFormatFlags.NoWrap;
			format.HotkeyPrefix = HotkeyPrefix.Show;
			
			if ( HasHorizontalTabs() || isHorizontalText )
			{
				// In case text does not fit
				flags |= DrawTextFormatFlags.DT_WORD_ELLIPSIS;

				rcText = new Rectangle(drawX, tabRect.Top + (tabRect.Height - textSize.Height)/2, 
					tabRect.Width - (drawX - tabRect.Left) - TAB_RIGHT_TEXT_MARGIN, tabRect.Height);
				// Save text pos
				page.TextPosition = new Point(rcText.Left, rcText.Top);
				using ( Brush b = new SolidBrush(currentTextColor) )
					g.DrawString(page.Title, font, b, rcText, format);
			}
			else
			{
							
				if ( tabsLocation == TabsLocation.Left )
				{
					rcText = new Rectangle(tabRect.Left + (tabRect.Width - textSize.Height)/2, 
						tabRect.Top + TAB_RIGHT_TEXT_MARGIN, 
						tabRect.Width, drawY - (tabRect.Top + TAB_RIGHT_TEXT_MARGIN));
					// Save text pos
					page.TextPosition = new Point(rcText.Left, rcText.Top);
					TextUtil.DrawLeftRotatedText(g, page.Title, font, rcText, currentTextColor, format);
				}
				else
				{
					format.LineAlignment = StringAlignment.Far;
					rcText = new Rectangle(tabRect.Left + (tabRect.Width - textSize.Height)/2, drawY,
						tabRect.Width, (tabRect.Bottom - TAB_RIGHT_TEXT_MARGIN) - drawY);
					// Save text pos
					page.TextPosition = new Point(rcText.Left, rcText.Top);
					TextUtil.DrawRightRotatedText(g, page.Title, font, rcText, currentTextColor, format);
				}
			}

			// Cleanup
			if ( cleanupFont )
				font.Dispose();

					
		}

		void DrawTab(Graphics g, TabPageEx page, Rectangle tabAreaRect, OneNoteColors oneNoteColors)
		{
			if ( tabsStyle == TabsStyle.Document || tabsStyle == TabsStyle.Office2003 )
				DrawDocumentTab(g, page, tabAreaRect);
			else if ( tabsStyle == TabsStyle.Standard 
				|| tabsStyle == TabsStyle.XPTheme || tabsStyle  == TabsStyle.CustomImages 
				|| IsOneNoteTabStyle() )
			{
				DrawStandardTab(g, page, tabAreaRect, oneNoteColors);
			}
			else if ( tabsStyle == TabsStyle.Flat || tabsStyle == TabsStyle.HighContrast )
				DrawFlatTab(g, page, tabAreaRect);
		}

		void DrawDocumentTab(Graphics g, TabPageEx page, Rectangle tabAreaRect)
		{
			int index = tabPages.IndexOf(page);
			bool selected = index == selectedTabIndex;
									
			// Draw background
			DrawTabsBackground(g, tabAreaRect, false);
			Rectangle tabRect = CalculateTabRect(tabAreaRect);
			
			// Draw tab background
			Color controlColor = GetControlColor(page);
			Color controlLightLightColor = GetControlLightLightColor(page);
			Color documentTabDarkColor = GetDocumentTabDarkDarkColor(page);
			Color originalDocumentTabDarkColor = GetDocumentTabDarkDarkColor(page);
			if ( tabsStyle == TabsStyle.Office2003 )
				documentTabDarkColor = ColorUtil.Office2003DarkGripper;	
					
			// Pens
			Pen controlPen = new Pen(controlColor);
			Pen controlLightLightPen = null;
			if ( tabsStyle == TabsStyle.Office2003 )
				controlLightLightPen = new Pen(ColorUtil.Office2003DarkGripper);
			else
				controlLightLightPen = new Pen(controlLightLightColor);
			
			// Draw foreground
			if ( tabsLocation == TabsLocation.Top )
			{
				if ( selected )
				{
					int specialBorderOffset = 0;
					if ( IsSpecialBorder() )
					{
						specialBorderOffset = 2;
						// Bottom lines
						g.DrawLine(controlPen, tabRect.Left+1, tabRect.Bottom, 
							tabRect.Left + tabRect.Width - 2, tabRect.Bottom); 
						g.DrawLine(controlPen, tabRect.Left+1, tabRect.Bottom + 1, 
							tabRect.Left + tabRect.Width - 2, tabRect.Bottom + 1); 
					}

					DrawDocumentTab(g, tabRect, controlColor);
					
					using ( Pen p = new Pen(documentTabDarkColor) )
					{
						// Left line
						g.DrawLine(controlLightLightPen, tabRect.Left, 
							tabRect.Top, tabRect.Left, 
							tabRect.Top + tabRect.Height - 1 + specialBorderOffset);
						// Right line
						g.DrawLine(p, tabRect.Left + tabRect.Width - 1, tabRect.Top, 
							tabRect.Left + tabRect.Width - 1, tabRect.Top + tabRect.Height - 1 + specialBorderOffset); 
						// Top Line
						g.DrawLine(SystemPens.ControlLightLight, tabRect.Left, tabRect.Top, 
							tabRect.Left + tabRect.Width - 1, tabRect.Top); 

						if ( tabsStyle == TabsStyle.Office2003 && !IsValidOffice2003FillStyle() )
						{
							if ( IsSpecialBorder() )
								specialBorderOffset = -2;	

							g.DrawLine(SystemPens.ControlLightLight, tabRect.Left, tabRect.Bottom - (specialBorderOffset+1), 
								tabRect.Left + tabRect.Width-1, tabRect.Bottom - (specialBorderOffset+1)); 
							
							if ( IsSpecialBorder() )
							{
								specialBorderOffset = 0;
								g.DrawLine(SystemPens.ControlLight, tabRect.Left, tabRect.Bottom - specialBorderOffset, 
									tabRect.Left + tabRect.Width-1, tabRect.Bottom - specialBorderOffset); 
							}	
						}
					}
				}
			}
			else if ( tabsLocation == TabsLocation.Bottom )
			{
				if ( selected )
				{
					int specialBorderOffset = 0;
					if ( IsSpecialBorder() )
					{
						specialBorderOffset = 2;
						// Top Lines
						g.DrawLine(controlPen, tabRect.Left+1, tabRect.Top - specialBorderOffset, 
							tabRect.Left + tabRect.Width - 2, tabRect.Top - specialBorderOffset); 
						g.DrawLine(controlPen, tabRect.Left+1, tabRect.Top - specialBorderOffset + 1, 
							tabRect.Left + tabRect.Width - 2, tabRect.Top - specialBorderOffset + 1); 
					}

					DrawDocumentTab(g, tabRect, controlColor);
					
					using ( Pen p = new Pen(documentTabDarkColor) )
					{
						// Left line
						g.DrawLine(controlLightLightPen, tabRect.Left, 
							tabRect.Top - specialBorderOffset, tabRect.Left, 
							tabRect.Top + tabRect.Height - 1);
						// Right line
						g.DrawLine(p, tabRect.Left + tabRect.Width - 1, tabRect.Top - specialBorderOffset, 
							tabRect.Left + tabRect.Width - 1, tabRect.Top + tabRect.Height - 1); 
						// Bottom line
						g.DrawLine(p, tabRect.Left, tabRect.Top + tabRect.Height - 1, 
							tabRect.Left + tabRect.Width - 1, tabRect.Top + tabRect.Height - 1);
 
						if ( tabsStyle == TabsStyle.Office2003 && !IsValidOffice2003FillStyle() )
						{
							if ( IsSpecialBorder() )
								specialBorderOffset = 1;	

							using ( Pen ofp = new Pen(originalDocumentTabDarkColor) )
							{
								g.DrawLine(ofp, tabRect.Left, tabRect.Top - specialBorderOffset, 
									tabRect.Left + tabRect.Width-1, tabRect.Top - specialBorderOffset); 
							}

							if ( IsSpecialBorder() )
							{
								specialBorderOffset = 2;
								g.DrawLine(SystemPens.ControlDark, tabRect.Left, tabRect.Top - specialBorderOffset, 
									tabRect.Left + tabRect.Width-1, tabRect.Top - specialBorderOffset); 
							}	
						}
					}
				}
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				if ( selected )
				{
					int specialBorderOffset = 0;
					if ( IsSpecialBorder() )
					{
						specialBorderOffset = 2;
						// Right Lines
						g.DrawLine(controlPen, tabRect.Right+1, tabRect.Top, tabRect.Right+1, tabRect.Bottom-1);
						g.DrawLine(controlPen, tabRect.Right, tabRect.Top, tabRect.Right, tabRect.Bottom-1); 
					}

					DrawDocumentTab(g, tabRect, controlColor);
										
					using ( Pen p = new Pen(documentTabDarkColor) )
					{
						// Left line
						g.DrawLine(controlLightLightPen, tabRect.Left, tabRect.Top, 
							tabRect.Left, tabRect.Top + tabRect.Height - 1); 
						// Bottom line
						g.DrawLine(p, tabRect.Left+1, tabRect.Bottom - 1, tabRect.Left + tabRect.Width - 1 + specialBorderOffset, 
							tabRect.Bottom - 1);
						// Top line
						g.DrawLine(controlLightLightPen, tabRect.Left+1, tabRect.Top, 
							tabRect.Left + tabRect.Width - 1 + +specialBorderOffset, tabRect.Top); 

						if ( tabsStyle == TabsStyle.Office2003 && !IsValidOffice2003FillStyle() )
						{
							specialBorderOffset = 1;
							if ( IsSpecialBorder() )
								specialBorderOffset = -1;	

							g.DrawLine(SystemPens.ControlLightLight, tabRect.Right-specialBorderOffset, tabRect.Top,  
								tabRect.Right-specialBorderOffset, tabRect.Bottom-1); 
							
							if ( IsSpecialBorder() )
							{
								g.DrawLine(SystemPens.ControlLight, tabRect.Right, tabRect.Top, 
									tabRect.Right, tabRect.Bottom-1); 
							}	
						}
					}
				}
			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				if ( selected )
				{
					int specialBorderOffset = 0;
					if ( IsSpecialBorder() )
					{
						specialBorderOffset = 2;
						// Left Lines
						g.DrawLine(controlPen, tabRect.Left-2, tabRect.Top, 
							tabRect.Left-2, tabRect.Bottom - 1); 
						g.DrawLine(controlPen, tabRect.Left-1, tabRect.Top, 
							tabRect.Left-1, tabRect.Bottom - 1); 
					}

					DrawDocumentTab(g, tabRect, controlColor);
										
					using ( Pen p = new Pen(documentTabDarkColor) )
					{
						// Left line
						g.DrawLine(p, tabRect.Right-1, tabRect.Top, 
							tabRect.Right-1, tabRect.Top + tabRect.Height - 1); 
						// Bottom line
						g.DrawLine(p, tabRect.Left - specialBorderOffset, tabRect.Bottom - 1, tabRect.Left + tabRect.Width - 1, 
							tabRect.Bottom - 1);
						// Top line
						g.DrawLine(controlLightLightPen, tabRect.Left - specialBorderOffset, tabRect.Top, 
							tabRect.Left + tabRect.Width - 1, tabRect.Top); 

						if ( tabsStyle == TabsStyle.Office2003 && !IsValidOffice2003FillStyle() )
						{
							specialBorderOffset = 0;
							if ( IsSpecialBorder() )
								specialBorderOffset = 1;
	
							using ( Pen ofp = new Pen(originalDocumentTabDarkColor) )
							{
								g.DrawLine(ofp, tabRect.Left - specialBorderOffset, tabRect.Top, 
									tabRect.Left  - specialBorderOffset, tabRect.Bottom - 1); 
							}

							if ( IsSpecialBorder() )
							{
								specialBorderOffset = 2;
								using ( Pen ofp = new Pen(SystemColors.ControlDark) )
								{
									g.DrawLine(ofp, tabRect.Left - specialBorderOffset, tabRect.Top, 
										tabRect.Left  - specialBorderOffset, tabRect.Bottom - 1); 
								}
							}	
						}
					}
				}
			}

			// Cleanup 
			controlPen.Dispose();
			controlLightLightPen.Dispose();
		}

		void DrawDocumentTab(Graphics g, Rectangle tabRect, Color controlColor)
		{
			if ( tabsStyle == TabsStyle.Office2003 )
			{
				DrawOffice2003TabsBackground(g, tabRect, ButtonState.Checked);
				if (GetType().ToString() == "SharpLibrary.Docking.DockTabControl")
				{
					// To work around a bug in the DockTabControl in the first tab
					Color fillColor =  GetOffice2003FillColor();
					using ( Pen p = new Pen(fillColor) )
					{
						g.DrawLine(p, new Point(tabRect.Left, tabRect.Top),
							new Point(tabRect.Right-1, tabRect.Top));
					}
				}
			}
			else
			{
				using ( Brush b = new SolidBrush(controlColor) )
					g.FillRectangle(b, tabRect);
			}
		}

		void DrawFlatTab(Graphics g, TabPageEx page, Rectangle tabAreaRect)
		{
			int index = tabPages.IndexOf(page);
			bool selected = index == selectedTabIndex;

			// Draw background
			DrawTabsBackground(g, tabAreaRect, false);
					
			Rectangle tabRect = CalculateTabRect(tabAreaRect);

			if ( selected )
			{
				Color tabColor = flatStyleSelectedTabColor;
				if ( tabsStyle == TabsStyle.HighContrast )
					tabColor = SystemColors.ControlLightLight;

				using ( Brush b = new SolidBrush(tabColor) ) 
					g.FillRectangle(b, tabRect);

				Color tabBorderColor = flatStyleSelectedTabBorderColor;
				if ( tabsStyle == TabsStyle.HighContrast )
					tabBorderColor = ColorUtil.SystemColorsHighlight;
								
				using ( Pen borderPen = new Pen(tabBorderColor) )
				{
					g.DrawRectangle(borderPen, new Rectangle(tabRect.Left, tabRect.Top, 
						tabRect.Width - 1, tabRect.Height-1));
				}
			}
			else
			{
				if (this.Parent != null)
				{
					using ( Brush b = new SolidBrush(this.Parent.BackColor)) 
						g.FillRectangle(b, tabRect);
				}

				using ( Pen borderPen = new Pen(Color.Black) )
				{
					g.DrawRectangle(borderPen, new Rectangle(tabRect.Left, tabRect.Top, 
						tabRect.Width - 1, tabRect.Height-1));
				}
			}
		}

		void DrawStandardTab(Graphics g, TabPageEx page, Rectangle tabAreaRect, OneNoteColors oneNoteColors)
		{
			int index = tabPages.IndexOf(page);
			bool selected = index == selectedTabIndex;

			// Draw tab area background
			if ( !IsOneNoteTabStyle() )
				DrawTabsBackground(g, tabAreaRect, false);
			Rectangle tabRect = CalculateTabRect(tabAreaRect);
			if ( IsHorizontalText() && selected )
			{
				// Increase the bounds by one pixel to help
				// make the selected tab more noticeable
				if ( tabsLocation == TabsLocation.Left )
				{
					tabRect.X -= 1;
					tabRect.Width += 1;
				}
			}

			// Draw tab background
			// --Don't draw tab background for OneNote tabs style--
			Color controlColor = GetControlColor(page);
			if ( !IsOneNoteTabStyle() ) 
			{
				Rectangle innerRect = Rectangle.Empty;
				using ( Brush b = new SolidBrush(controlColor) )
				{
					if ( tabsLocation == TabsLocation.Top )
					{
						// Avoid drawing over the light bottom line
						innerRect = new Rectangle(tabRect.Left, tabRect.Top, 
							tabRect.Width, tabRect.Height-1);
					}
					else if ( tabsLocation == TabsLocation.Bottom )
					{
						// Avoid drawing over the dark top line
						innerRect = new Rectangle(tabRect.Left, tabRect.Top+1, 
							tabRect.Width, tabRect.Height-1);
					}
					else if ( tabsLocation == TabsLocation.Left )
					{
						// Avoid drawing over the light bottom line
						innerRect = new Rectangle(tabRect.Left, tabRect.Top, 
							tabRect.Width-1, tabRect.Height);
					}
					else if ( tabsLocation == TabsLocation.Right )
					{
						// Avoid drawing over the dark bottom line
						innerRect = new Rectangle(tabRect.Left, tabRect.Top, 
							tabRect.Width-1, tabRect.Height);
					}

					if ( tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Bottom )
					{
						// We need to make this even smaller since we don't want
						// to show the tab back color showing trough the corners but
						// the TabsAreaBackColor
					    innerRect.Inflate(-2,0);
					}
					else
					{
						innerRect.Inflate(0, -2);
						if ( (tabsLocation == TabsLocation.Right && tabsFitting != TabsFitting.MultiLine) ||
							(tabsLocation == TabsLocation.Right && IsStandardTabsMultilineCase() && IsMultiLineFirstRow())  )
						{
							innerRect = new Rectangle(innerRect.Left + 1, innerRect.Top, innerRect.Width, innerRect.Height);
						}
					}

					// Check if we need to do gradient painting for the tab page or the whole control
					LinearGradientMode mode = LinearGradientMode.Vertical;
					if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
						mode = LinearGradientMode.Horizontal;
					if ( page.GradientStartColor != Color.Empty && page.GradientEndColor != Color.Empty )
					{
						using ( Brush lb = new LinearGradientBrush(innerRect, page.GradientStartColor, page.GradientEndColor, mode) )
							g.FillRectangle(lb, innerRect);
					}
					else if ( GradientStartColor != Color.Empty && GradientEndColor != Color.Empty )
					{
						using ( Brush lb = new LinearGradientBrush(innerRect, GradientStartColor, GradientEndColor, mode) )
							g.FillRectangle(lb, innerRect);
					}
					else
					{
						g.FillRectangle(b, innerRect);
					}
				}
			}

			// Break to the DrawXPThemeTab method if we are using XPTheme tabs
			if ( (tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled()) || 
				(tabsStyle  == TabsStyle.CustomImages && tabsImageList != null) )
			{
				if ( selected )
				{
					if ( tabsLocation == TabsLocation.Top )
                        tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width, tabRect.Height+1);
					else if ( tabsLocation == TabsLocation.Bottom )
						tabRect = new Rectangle(tabRect.Left, tabRect.Top-1, tabRect.Width, tabRect.Height+1);
					else if ( tabsLocation == TabsLocation.Left )
						tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width+1, tabRect.Height);
					else if ( tabsLocation == TabsLocation.Right )
						tabRect = new Rectangle(tabRect.Left-1, tabRect.Top, tabRect.Width+1, tabRect.Height);
				}

				DrawXPThemeTab(g, page, tabRect);
				return;
			}
			else if ( IsOneNoteTabStyle() )
			{
				if ( tabsFitting == TabsFitting.MultiLine && multilineRows != null 
					&& multilineRows.Count > 1 )
				{
					if ( (tabsLocation == TabsLocation.Top  || tabsLocation == TabsLocation.Left) 
						&& !(IsMultiLineLastRow() || IsMultiLineFirstRow()) )
					{
						// If not the first or last row, increase the height
						// of the tab by one pixel so that the dark pixel at
						// the bottom of the tabs does not show and thus create
						// a feeling that the tabs are overlapping
						if ( tabsLocation == TabsLocation.Top)
							tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width, tabRect.Height+1);
						else
							tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width+1, tabRect.Height);
					}
					else if ( tabsLocation == TabsLocation.Bottom && IsMultiLineLastRow() )
					{
						tabRect = new Rectangle(tabRect.Left, tabRect.Top-1, tabRect.Width, tabRect.Height+1);
					}

					else if ( tabsLocation == TabsLocation.Right )
					{
						if (  !IsMultiLineFirstRow() )
							tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width+1, tabRect.Height);
						else
							tabRect = new Rectangle(tabRect.Left, tabRect.Top-1, tabRect.Width+1, tabRect.Height);
					}
				}

				DrawOneNoteTab(g, page, tabRect, oneNoteColors);
				return;
			}

			// Get the rest of the colors we are going to use
			Color controlLightColor = GetControlLightColor(page);
			Color controlLightLightColor = GetControlLightLightColor(page);
			Color controlDarkColor = GetControlDarkColor(page);
			Color controlDarkDarkColor = GetControlDarkDarkColor(page);

			// Pens
			Pen controlPen = new Pen(controlColor);
			Pen controlLightPen = new Pen(controlLightColor);
			Pen controlLightLightPen = new Pen(controlLightLightColor);
			Pen controlDarkPen = new Pen(controlDarkColor);
			Pen controlDarkDarkPen = new Pen(controlDarkDarkColor);

            		
			int specialBorderOffset = 0;
			if ( IsSpecialBorder() )
			{
				specialBorderOffset = 1;
			}

			int multilineOffset = 0;
			if ( tabsLocation == TabsLocation.Bottom )
			{
				if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow())
					multilineOffset = -1;
			}
			else if ( tabsLocation == TabsLocation.Top )
			{
				if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow() && !IsMultiLineLastRow() )
					multilineOffset = 1;
			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow() )
					multilineOffset = 1;
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow() && !IsMultiLineLastRow() )
					multilineOffset = 1;
			}
			
			// Draw foreground
			if ( tabsLocation == TabsLocation.Top )
			{
				if ( selected )
				{
					if ( IsSpecialBorder() )
					{
						// Draw bottom erase lines
						g.DrawLine(controlPen, tabRect.Left+2, tabAreaRect.Bottom-2, 
							tabRect.Left + tabRect.Width - 3, tabAreaRect.Bottom-2);
						g.DrawLine(controlPen, tabRect.Left+2, tabAreaRect.Bottom-1, 
							tabRect.Left + tabRect.Width - 3, tabAreaRect.Bottom-1);
					}
					else
					{
						// Draw bottom erase line
						g.DrawLine(controlPen, tabRect.Left+2, tabRect.Bottom-1, 
							tabRect.Left + tabRect.Width - 3, tabRect.Bottom-1);
					
					}

					// Increase the selected tab rectangle
					tabRect = new Rectangle(tabRect.Left, tabRect.Top-1, tabRect.Width, tabRect.Height + 1);

				}
				
				// Draw left highlight line
				g.DrawLine(controlLightLightPen, tabRect.Left, tabRect.Top+2, 
					tabRect.Left, tabRect.Top + tabRect.Height-2 + specialBorderOffset + multilineOffset); 

				// Draw left light line
				g.DrawLine(controlLightPen, tabRect.Left+1, tabRect.Top+2, 
					tabRect.Left+1, tabRect.Top + tabRect.Height-2 + specialBorderOffset + multilineOffset); 
				
				// Draw Left light light point
				DrawUtil.DrawPoint(g, controlLightLightColor,  tabRect.Left+1, tabRect.Top + 1); 

				// Draw top highlight line
				if ( ignoreLightSource )
				{
					g.DrawLine(controlDarkDarkPen, tabRect.Left+2, tabRect.Top, 
						tabRect.Left + tabRect.Width - 3, tabRect.Top); 
				}
				else
				{
					g.DrawLine(controlLightLightPen, tabRect.Left+2, tabRect.Top, 
						tabRect.Left + tabRect.Width - 3, tabRect.Top); 
				}

				// Draw top light line
				if ( ignoreLightSource )
				{
					g.DrawLine(controlDarkPen, tabRect.Left+2, tabRect.Top+1, 
						tabRect.Left + tabRect.Width - 3, tabRect.Top+1); 
				}
				else
				{
					g.DrawLine(controlLightPen, tabRect.Left+2, tabRect.Top+1, 
						tabRect.Left + tabRect.Width - 3, tabRect.Top+1); 
				}

				if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow() )
					g.DrawLine(controlPen, tabRect.Left+2, 
						tabRect.Top+ tabRect.Height-1, tabRect.Left + tabRect.Width-2, tabRect.Top + tabRect.Height-1); 

				
				if ( IsSpecialBorder() )
					g.DrawLine(controlPen, tabRect.Left+2, 
						tabRect.Top+ tabRect.Height-1, 
						tabRect.Left + tabRect.Width-2, tabRect.Top + tabRect.Height-1); 
                
				// Draw right dark point
				DrawUtil.DrawPoint(g, controlDarkDarkColor,  tabRect.Right-2, tabRect.Top + 1); 

				// Draw right dark line
				g.DrawLine(controlDarkPen, tabRect.Right-2, tabRect.Top+2, 
					tabRect.Right-2, tabRect.Top + tabRect.Height-2 + specialBorderOffset + multilineOffset); 

				// Draw right darkdark line
				g.DrawLine(controlDarkDarkPen, tabRect.Right-1, tabRect.Top+2, 
					tabRect.Right-1, tabRect.Top + tabRect.Height-2 + specialBorderOffset + multilineOffset); 

			}
			else if ( tabsLocation == TabsLocation.Bottom )
			{
				if ( selected )
				{
					if ( IsSpecialBorder() )
					{
						// Draw top line
						g.DrawLine(controlPen, tabRect.Left, tabRect.Top-2, 
							tabRect.Left + tabRect.Width - 2, tabRect.Top-2); 
						// Draw top line 
						g.DrawLine(controlPen, tabRect.Left, tabRect.Top-1, 
							tabRect.Left + tabRect.Width - 2, tabRect.Top-1); 

						// Draw top line with tab back color
						g.DrawLine(controlPen, tabRect.Left+2, tabRect.Top, tabRect.Left + tabRect.Width-2, tabRect.Top); 
					
						// Draw right dark segment
						g.DrawLine(controlDarkPen, tabRect.Left + tabRect.Width - 2, tabRect.Top-2, 
							tabRect.Left + tabRect.Width - 2, tabRect.Top-1); 

						// Increase the selected tab rectangle
						tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width, tabRect.Height + 1);

						// Draw Left lightlight line
						g.DrawLine(controlLightLightPen, tabRect.Left, tabRect.Top-2, 
							tabRect.Left, tabRect.Top + tabRect.Height - 3);
					}
					else
					{
						// Draw top line 
						g.DrawLine(controlPen, tabRect.Left, 
							tabRect.Top-specialBorderOffset+multilineOffset, 
							tabRect.Left + tabRect.Width - 3, tabRect.Top-specialBorderOffset+multilineOffset); 

						// Draw top line
						if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow())
							g.DrawLine(controlPen, tabRect.Left+2, tabRect.Top, tabRect.Left + tabRect.Width-2, tabRect.Top);

						// Increase the selected tab rectangle
						tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width, tabRect.Height + 1);
					
						// Draw Left lightlight line
						g.DrawLine(controlLightLightPen, tabRect.Left, 
							tabRect.Top-specialBorderOffset+multilineOffset, 
							tabRect.Left, tabRect.Top + tabRect.Height - 3); 
					}
				}
				else
				{
					
					// Draw top line with tab back color
					if ( IsSpecialBorder() )
					{
						g.DrawLine(controlPen, tabRect.Left+2, tabRect.Top, tabRect.Left + tabRect.Width-2, tabRect.Top); 
					}

					// Draw top line
					if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow())
						g.DrawLine(controlPen, tabRect.Left+2, tabRect.Top, tabRect.Left + tabRect.Width-2, tabRect.Top); 

					// Draw Left lightlight line
					g.DrawLine(controlLightLightPen, tabRect.Left, 
						tabRect.Top+1-specialBorderOffset+multilineOffset, 
						tabRect.Left, tabRect.Top + tabRect.Height - 3); 

				}

				// Draw Left light line
				g.DrawLine(controlLightPen, tabRect.Left+1, tabRect.Top+1-specialBorderOffset+multilineOffset, 
					tabRect.Left+1, tabRect.Top + tabRect.Height - 3); 
				
				// Draw Left light light point
				DrawUtil.DrawPoint(g, controlLightLightColor,  tabRect.Left+1, tabRect.Top + tabRect.Height - 2); 

				// Draw bottom dark line
				g.DrawLine(controlDarkPen, tabRect.Left+2, tabRect.Top + tabRect.Height - 2, 
					tabRect.Left + tabRect.Width - 2, tabRect.Top + tabRect.Height - 2); 

				// Draw bottom dark dark line
				g.DrawLine(controlDarkDarkPen, tabRect.Left+2, tabRect.Top + tabRect.Height - 1, 
					tabRect.Left + tabRect.Width - 3, tabRect.Top + tabRect.Height - 1); 

				// Draw right dark line
				g.DrawLine(controlDarkPen, tabRect.Right-2, tabRect.Top+1-specialBorderOffset+multilineOffset, 
					tabRect.Right-2, tabRect.Top + tabRect.Height - 3);

				// Draw right dark dark line
				g.DrawLine(controlDarkDarkPen, tabRect.Right-1, tabRect.Top+1-specialBorderOffset+multilineOffset, 
					tabRect.Right-1, tabRect.Top + tabRect.Height - 3);

				// Draw right darkdark point
				DrawUtil.DrawPoint(g, controlDarkDarkColor,  tabRect.Right-2, tabRect.Top + tabRect.Height - 2); 
				
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				if ( selected )
				{
					if ( IsSpecialBorder() )
					{
						specialBorderOffset = 3;
						// Right Lines
						g.DrawLine(controlPen, tabRect.Right+1, tabRect.Top, tabRect.Right+1, tabRect.Bottom-1);
						g.DrawLine(controlPen, tabRect.Right, tabRect.Top, tabRect.Right, tabRect.Bottom-1); 
					}
					else
					{
						// Draw bottom erase line
						g.DrawLine(controlPen, tabRect.Right-1, tabRect.Top+2,
							tabRect.Right-1, tabRect.Bottom-3);
					}

					// Increase the selected tab rectangle
					tabRect = new Rectangle(tabRect.Left-1, tabRect.Top, tabRect.Width+1, tabRect.Height);
				}
				
				// Draw left lightlight line
				if ( ignoreLightSource )
				{
					g.DrawLine(controlDarkDarkPen, tabRect.Left, tabRect.Top+2, 
						tabRect.Left, tabRect.Top + tabRect.Height-3); 
				}
				else
				{
					g.DrawLine(controlLightLightPen, tabRect.Left, tabRect.Top+2, 
						tabRect.Left, tabRect.Top + tabRect.Height-3); 
				}

				// Draw left light line
				if ( ignoreLightSource )
				{
					g.DrawLine(controlDarkPen, tabRect.Left+1, tabRect.Top+2, 
						tabRect.Left+1, tabRect.Top + tabRect.Height-3); 
				}
				else
				{
					g.DrawLine(controlLightPen, tabRect.Left+1, tabRect.Top+2, 
						tabRect.Left+1, tabRect.Top + tabRect.Height-3); 
				}

				if ( IsStandardTabsMultilineCase() && !IsMultiLineFirstRow() && !IsMultiLineLastRow() )
					g.DrawLine(controlPen, tabRect.Left+tabRect.Width-1, 
						tabRect.Top + 2, tabRect.Left+tabRect.Width-1, tabRect.Top + tabRect.Height-2); 

				if ( IsSpecialBorder() && 
					( tabsFitting != TabsFitting.MultiLine || (tabsFitting ==  TabsFitting.MultiLine && ( IsMultiLineFirstRow() || multilineRows.Count == 1)))  )
				{
					g.DrawLine(controlPen, tabRect.Left + tabRect.Width - 1, 
						tabRect.Top+2, tabRect.Left + tabRect.Width - 1, tabRect.Top + tabRect.Height-2); 
				}
				
				// Draw Left light light point
				DrawUtil.DrawPoint(g, controlLightLightColor,  tabRect.Left+1, tabRect.Top + 1); 

				// Draw top lightlight line
				g.DrawLine(controlLightLightPen, tabRect.Left+2, tabRect.Top, 
					tabRect.Left + tabRect.Width - 2 + specialBorderOffset + multilineOffset, tabRect.Top); 

				// Draw top light line
				g.DrawLine(controlLightPen, tabRect.Left+2, tabRect.Top+1, 
					tabRect.Left + tabRect.Width - 2 + specialBorderOffset + multilineOffset, tabRect.Top+1); 

				// Draw bottom dark line
				g.DrawLine(controlDarkPen, tabRect.Left+2, tabRect.Bottom-2, 
					tabRect.Left + tabRect.Width - 2 + specialBorderOffset + multilineOffset, tabRect.Bottom-2); 

				// Draw bottom dark dark line
				g.DrawLine(controlDarkDarkPen, tabRect.Left+2, tabRect.Bottom-1, 
					tabRect.Left + tabRect.Width - 2 + specialBorderOffset + multilineOffset, tabRect.Bottom-1); 

				// Draw bottom dark dark point
				DrawUtil.DrawPoint(g, controlDarkDarkColor,  tabRect.Left+1, tabRect.Bottom - 2); 
			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				if ( selected )
				{
					specialBorderOffset = 1;
					if ( IsSpecialBorder() )
					{
						// Left Lines
						specialBorderOffset = 3;
						g.DrawLine(controlPen, tabRect.Left-2, tabRect.Top, 
							tabRect.Left-2, tabRect.Bottom - 1); 
						g.DrawLine(controlPen, tabRect.Left-1, tabRect.Top, 
							tabRect.Left-1, tabRect.Bottom - 1); 
					}
					else
					{
						// Draw bottom erase line
						g.DrawLine(controlPen, tabRect.Left, tabRect.Top+2,
							tabRect.Left, tabRect.Bottom-3);
					}

					// Increase the selected tab rectangle
					tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width+1, tabRect.Height);
				}

				if ( IsSpecialBorder() && 
					( tabsFitting != TabsFitting.MultiLine || (tabsFitting ==  TabsFitting.MultiLine && IsMultiLineFirstRow()) )  )
				{
					g.DrawLine(controlPen, tabRect.Left, tabRect.Top+2, tabRect.Left, tabRect.Top + tabRect.Height-2); 
				}
				
				// Draw top lightlight line
				g.DrawLine(controlLightLightPen, tabRect.Left+1-specialBorderOffset-multilineOffset, tabRect.Top, 
					tabRect.Right-3, tabRect.Top); 

				// Draw top light line
				g.DrawLine(controlLightPen, tabRect.Left+1-specialBorderOffset-+multilineOffset, tabRect.Top+1, 
					tabRect.Right-3, tabRect.Top + 1); 
				
				// Draw right light light point
				DrawUtil.DrawPoint(g, controlLightLightColor,  tabRect.Right-2, tabRect.Top + 1); 

				// Draw right dark dark line
				g.DrawLine(controlDarkDarkPen, tabRect.Right-1, tabRect.Top+2, 
					tabRect.Right-1, tabRect.Bottom-3); 

				// Draw right dark line
				g.DrawLine(controlDarkPen, tabRect.Right-2, tabRect.Top+2, 
					tabRect.Right-2, tabRect.Bottom-3); 

				// Draw bottom dark line
				g.DrawLine(controlDarkPen, tabRect.Left+1-specialBorderOffset-multilineOffset, tabRect.Bottom-2, 
					tabRect.Right-3, tabRect.Bottom-2); 

				// Draw bottom dark dark line
				g.DrawLine(controlDarkDarkPen, tabRect.Left+1-specialBorderOffset-multilineOffset, tabRect.Bottom-1, 
					tabRect.Right-3, tabRect.Bottom-1); 
				
				// Draw right dark dark point
				DrawUtil.DrawPoint(g, controlDarkDarkColor,  tabRect.Right-2, tabRect.Bottom - 2); 
			
			}

			// Cleanup
			controlPen.Dispose();
			controlLightPen.Dispose();
			controlLightLightPen.Dispose();
			controlDarkPen.Dispose();
			controlDarkDarkPen.Dispose();

		}

		void DrawXPThemeTab(Graphics g, TabPageEx page, Rectangle tabRect)
		{
			// Open a handle the TAB theme if necessary
			if ( tabsStyle == TabsStyle.XPTheme )
			{
				if ( hTheme == IntPtr.Zero )
				{
					hTheme = UxTheme.OpenThemeData(Handle, "TAB");
					if ( hTheme == IntPtr.Zero )
					{
						Debug.Assert(false, "A handle for the themed TAB class could not be opened.");
						return;
					}

					bool wasEmpty = xpThemeBorderColor == Color.Empty;

                    // Get xpThemeBorderColor
					Bitmap bm = new Bitmap(40, 24);
					Graphics gBuffer = Graphics.FromImage(bm);
					UxTheme.DrawThemedTabControlBackground(hTheme, gBuffer, new Rectangle(0, 0, bm.Width, bm.Height));
					xpThemeBorderColor = bm.GetPixel(0, 0);

					if ( wasEmpty )
						Invalidate();
				}
			}

			int index = tabPages.IndexOf(page);
			bool selected = index == selectedTabIndex;

			// Increase the rectangle by one pixel if the tab is selected
			if ( selected )
			{
				if ( tabsLocation == TabsLocation.Top )
					tabRect = new Rectangle(tabRect.Left, tabRect.Top-1, tabRect.Width, tabRect.Height + 1);
				else if ( tabsLocation == TabsLocation.Bottom )
					tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width, tabRect.Height + 1);
				else if ( tabsLocation == TabsLocation.Left )
				{
					if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
						tabRect = new Rectangle(tabRect.Left-1, tabRect.Top+1, tabRect.Width+1, tabRect.Height-1);
					else
						tabRect = new Rectangle(tabRect.Left-1, tabRect.Top, tabRect.Width+1, tabRect.Height);
				}
				else if ( tabsLocation == TabsLocation.Right )
				{
					if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
						tabRect = new Rectangle(tabRect.Left-1, tabRect.Top, tabRect.Width+1, tabRect.Height-1);
				}		 
			}

			// There seems to be bug somewhere of the implementation of the drawing of right tabs
			// we compensate here
			if ( selected && tabsLocation == TabsLocation.Right )
				tabRect = new Rectangle(tabRect.Left+1, tabRect.Top, tabRect.Width, tabRect.Height);
			else if ( tabsLocation == TabsLocation.Right )
				tabRect = new Rectangle(tabRect.Left+1, tabRect.Top, tabRect.Width-1, tabRect.Height);

			// If we need to rotate the matrix
			Matrix oldMatrix = g.Transform;
			Matrix m = new Matrix();
			Rectangle finalRect = Rectangle.Empty;
						
			// Now decrease the rectangle to avoid painting over the border line that separates the tabs
			// from the tab pages area
			if ( !IsSpecialBorder()) 
			{						  
				if ( (tabsFitting != TabsFitting.MultiLine || (multilineRows != null && multilineRows.Count == 1))
					|| (IsStandardTabsMultilineCase() && IsMultiLineFirstRow()) )
				{
					if ( tabsLocation == TabsLocation.Top )
						tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width, tabRect.Height - 1);
					else if ( tabsLocation == TabsLocation.Bottom ) 
						tabRect = new Rectangle(tabRect.Left, tabRect.Top + 1, tabRect.Width, tabRect.Height - 1);
					else if ( tabsLocation == TabsLocation.Left ) 
						tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width - 1, tabRect.Height);
					else if ( tabsLocation == TabsLocation.Right ) 
						tabRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Width, tabRect.Height);
				}
			}

			if ( tabsLocation == TabsLocation.Right && tabsFitting == TabsFitting.MultiLine 
				&& multilineRows != null && multilineRows.Count != 1 && !IsMultiLineFirstRow() )
			{
				tabRect = new Rectangle(tabRect.Left-1, tabRect.Top, tabRect.Width+1, tabRect.Height);
			}

			// Apply rotation
			if ( tabsLocation == TabsLocation.Top )
			{
				finalRect = tabRect;
			}
			else if ( tabsLocation == TabsLocation.Bottom ) 
			{
				m.RotateAt(-180, new Point(tabRect.Left, tabRect.Top + tabRect.Height - 1), MatrixOrder.Append);
				finalRect = new Rectangle(tabRect.Left - tabRect.Width, 
					tabRect.Top + tabRect.Height - 2, tabRect.Width, tabRect.Height);
			}
			else if ( tabsLocation == TabsLocation.Left ) 
			{
				m.RotateAt(-90, new Point(tabRect.Left, tabRect.Top), MatrixOrder.Append);
				finalRect = new Rectangle(tabRect.Left - tabRect.Height, tabRect.Top, tabRect.Height, tabRect.Width);
			}
			else if ( tabsLocation == TabsLocation.Right ) 
			{
				m.RotateAt(90, new Point(tabRect.Left, tabRect.Bottom), MatrixOrder.Append);
				finalRect = new Rectangle(tabRect.Left - tabRect.Height, tabRect.Bottom - tabRect.Width, tabRect.Height, tabRect.Width);
			}

			// Now draw the tab
			DrawState state = DrawState.Normal;
			if ( selected )
				state = DrawState.Pressed;
			else if ( hotTrack && hotTrackIndex == index )
				state = DrawState.Hot;
			
			// Override the above state if the tab page or the tab control is disable
			if ( !page.Enabled || !Enabled )
				state = DrawState.Disable;
			
			// Draw the image into a bitmap so that we can
			// apply transformation when drawing the image into the real Graphics object
			Bitmap image = null;
			Rectangle targetRect = Rectangle.Empty;
			if  ( HasHorizontalTabs() )
			{
				targetRect = new Rectangle(0, 0, tabRect.Width, tabRect.Height);
				image = new Bitmap(tabRect.Width, tabRect.Height);
			}
			else
			{
				if ( tabsLocation == TabsLocation.Right ) 
				{
					targetRect = new Rectangle(0, 1, tabRect.Height, tabRect.Width+1);
					image = new Bitmap(tabRect.Height, tabRect.Width+2);
					finalRect = new Rectangle(finalRect.Left, finalRect.Top, finalRect.Width, finalRect.Height);
				}
				else
				{
					targetRect = new Rectangle(0, 0, tabRect.Height, tabRect.Width);
					image = new Bitmap(tabRect.Height, tabRect.Width);
				}
			}

			Graphics buffer = Graphics.FromImage(image);
								
			// Apply the transformation
			g.Transform = m;
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
			{
				Rectangle rcTab = page.TabRectangle;
                UxTheme.DrawThemedTab(hTheme, buffer, targetRect, state);
				g.DrawImage(image,  finalRect, 0, 0, targetRect.Width, targetRect.Height, GraphicsUnit.Pixel);

				// Reset matrix
				g.Transform = oldMatrix;
				
				if ( selected )
				{
					if ( tabsLocation == TabsLocation.Top )
					{
						DrawUtil.DrawPoint(g, xpThemeBorderColor, rcTab.Left, rcTab.Bottom);
						DrawUtil.DrawPoint(g, xpThemeBorderColor, rcTab.Right-1, rcTab.Bottom);
					}
					else if ( tabsLocation == TabsLocation.Bottom )
					{
						DrawUtil.DrawPoint(g, xpThemeBorderColor, rcTab.Left, rcTab.Top-1);
						DrawUtil.DrawPoint(g, xpThemeBorderColor, rcTab.Right-1, rcTab.Top-1);
					}
					else if ( tabsLocation == TabsLocation.Left )
					{
						DrawUtil.DrawPoint(g, xpThemeBorderColor, rcTab.Right, rcTab.Top+1);
						DrawUtil.DrawPoint(g, xpThemeBorderColor, rcTab.Right, rcTab.Bottom-1);
					}
					else if ( tabsLocation == TabsLocation.Right )
					{
						DrawUtil.DrawPoint(g, xpThemeBorderColor, rcTab.Left-2, rcTab.Top);
					}
				}
			}
			else if ( tabsStyle == TabsStyle.CustomImages )
			{
				DrawState imageState = DrawState.Normal;
				if ( (int)state < tabsImageList.Count )
					imageState = state;
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				DrawUtil.DrawStrechedImage(buffer, targetRect, 
					tabsImageList.GetImage((int)imageState), ImageStretchMode.Both, stretchMargins);
				g.DrawImage(image,  finalRect, 0, 0, targetRect.Width, targetRect.Height, GraphicsUnit.Pixel);

				// Reset matrix
				g.Transform = oldMatrix;

			}
		}

		void DrawOneNoteTab(Graphics g, TabPageEx page, Rectangle tabRect, OneNoteColors oneNoteColors)
		{
			Debug.Assert(tabRect.Width > 0 && tabRect.Height > 0);
			int index = tabPages.IndexOf(page);
			int actualPageIndex = index;
			DrawState drawState = DrawState.Normal;
			if ( index == selectedTabIndex )
				drawState = DrawState.Hot;
			
			if ( index != 0 && firstVisiblePageIndex == index )
				index = 0;
			
			// Draw the left edge of the tab which is not normally drawn if the tab is the first one
			// on a line other that the first row
			bool drawLeftEdge = false;
			if ( tabsFitting == TabsFitting.MultiLine && multilineRows != null && multilineRows.Count > 1 )
			{
				int rowIndex = GetRowIndex(index);
				Debug.Assert(rowIndex != -1);
				if ( IsFirstTabInRow(rowIndex, index) && index != selectedTabIndex )
					drawLeftEdge = true;
				if ( IsHorizontalText() )
					index = 0;
			}
			else if ( IsHorizontalText() )
			{
				// Horizontal text tabs always get the diagonal line
				index = 0;
			}
			
			Rectangle actualTabRect = tabRect;
			Color startColor = ColorUtil.GetOneNoteGradientStartColor(tabsStyle, actualPageIndex);
			Color endColor = ColorUtil.GetOneNoteGradientEndColor(tabsStyle, actualPageIndex);
			if ( index == selectedTabIndex && tabsStyle != TabsStyle.OneNote )
			{
				// Light the colors a little bit so that
				// the selected tab is more noticeable --only for OneNoteLuna and OneNoteSystem-- styles
				startColor = ControlPaint.Light(startColor);
				endColor = ControlPaint.Light(endColor);
			}

			if ( (IsHorizontalText() && tabsLocation == TabsLocation.Left) || tabsLocation == TabsLocation.Top )
			{
				DrawUtil.DrawOneNoteTabStyle(g, tabRect, tabsStyle, startColor, endColor, drawState, index, drawLeftEdge, oneNoteColors);
			}
			else if ( (IsHorizontalText() && tabsLocation == TabsLocation.Right) || tabsLocation == TabsLocation.Bottom 
				|| tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
			{
				// Draw the tab into a buffer so that we can left mirror invert to the image
				Bitmap bitmap = null;
				Rectangle targetRect = Rectangle.Empty;
				if ( (IsHorizontalText() && tabsLocation == TabsLocation.Right) || tabsLocation == TabsLocation.Bottom )
				{
					bitmap = new Bitmap(tabRect.Width, tabRect.Height);
					targetRect = new Rectangle(0, 0, tabRect.Width, tabRect.Height);
				}
				else if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
				{
					if ( tabsLocation == TabsLocation.Left )
					{
						bitmap = new Bitmap(tabRect.Height, tabRect.Width);
						targetRect = new Rectangle(0, 0, tabRect.Height, tabRect.Width);
					}
					else
					{
						bitmap = new Bitmap(tabRect.Height+1, tabRect.Width+2);
						targetRect = new Rectangle(0, 1, tabRect.Height+1, tabRect.Width);
					}
				}
				
				Graphics buffer = Graphics.FromImage(bitmap);
				DrawUtil.DrawOneNoteTabStyle(buffer, targetRect, tabsStyle, startColor, endColor, 
					drawState, index, drawLeftEdge, oneNoteColors);

				// Hack: somehow we missing the first pixel of the tab, force the drawing of the left edge here
				if ( tabsLocation == TabsLocation.Right && drawLeftEdge && drawState != DrawState.Hot && index != 0 )
				{
					using ( Pen p = new Pen(ColorUtil.OneNoteDarkDarkColor(tabsStyle)) )
						buffer.DrawLine(p, targetRect.Left+1, targetRect.Top+4, targetRect.Left+1, targetRect.Bottom - 2);
				}

				// Now draw into actual tab control device context
				if ( tabsLocation == TabsLocation.Bottom )
				{
					g.DrawImage(bitmap, new Rectangle(actualTabRect.Left, actualTabRect.Top, bitmap.Width, bitmap.Height),
						0, bitmap.Height - 1, bitmap.Width, -bitmap.Height, GraphicsUnit.Pixel);
				}
				else if ( IsHorizontalText() && tabsLocation == TabsLocation.Right )
				{
					g.DrawImage(bitmap, new Rectangle(actualTabRect.Left, actualTabRect.Top, bitmap.Width, bitmap.Height),
						bitmap.Width - 1, 0, -bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
				}
				else if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
				{
					// We need to rotate the matrix
					Matrix oldMatrix = g.Transform;
					Matrix m = new Matrix();
					Rectangle finalRect = Rectangle.Empty;

					if ( tabsLocation == TabsLocation.Left ) 
					{
						m.RotateAt(-90, new Point(tabRect.Left, tabRect.Top), MatrixOrder.Append);
						finalRect = new Rectangle(tabRect.Left - tabRect.Height, tabRect.Top, tabRect.Height, tabRect.Width);

						// Apply the transformation
						g.Transform = m;

						// Draw into actual device context
						g.DrawImage(bitmap,  finalRect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
					}
					else if ( tabsLocation == TabsLocation.Right ) 
					{
						m.RotateAt(90, new Point(tabRect.Left, tabRect.Bottom), MatrixOrder.Append);
						finalRect = new Rectangle(tabRect.Left - tabRect.Height, 
							tabRect.Bottom - tabRect.Width, tabRect.Height+1, tabRect.Width);

						// Apply the transformation
						g.Transform = m;
						
						// Draw into actual device context
						g.DrawImage(bitmap,  finalRect, 1, 0, bitmap.Width, bitmap.Height-2, GraphicsUnit.Pixel);
					}

					// Reset matrix
					g.Transform = oldMatrix;

				}
			}
		}

		int LeftArrowXPos()
		{
			Rectangle tabsRect = TabsArea;
			int glyphsWidth = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*3;
			if ( !showClose )
				glyphsWidth = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*2;
					 				
			return tabsRect.Right - glyphsWidth;
		}

		int LeftArrowYPos()
		{
			Rectangle tabsRect = TabsArea;
			int glyphsHeight = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*3;
			if ( !showClose )
				glyphsHeight = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*2;

			if ( IsHorizontalText() && leftTabsTop )
				return tabsRect.Bottom - glyphsHeight - GLYPH_RIGHT_MARGIN;
			else if ( tabsLocation == TabsLocation.Left )
				return tabsRect.Top + glyphsHeight + GLYPH_RIGHT_MARGIN;
			else
				return tabsRect.Bottom - glyphsHeight - GLYPH_RIGHT_MARGIN;

		}

		Rectangle GetGlyphsArea()
		{
			Rectangle tabsRect = TabsArea;
			int glyphsWidth = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*3;
			if ( !showClose )
				glyphsWidth = GLYPH_RIGHT_MARGIN + GLYPH_WIDTH*2;

			if ( HasHorizontalTabs() )
			{
				int left = LeftArrowXPos();
				int top = tabsRect.Top + (tabsRect.Height - GLYPH_WIDTH)/2 + 1;
				return new Rectangle(left,top, glyphsWidth, GLYPH_HEIGHT);
			}
			else if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop )
			{
				int left = tabsRect.Left + (tabsRect.Width - GLYPH_WIDTH)/2 + 1;
				return new Rectangle(left, tabsRect.Top, GLYPH_WIDTH, glyphsWidth);
			}
			else if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
			{
				int left = tabsRect.Left + (tabsRect.Width - GLYPH_WIDTH)/2 + 1;
				return new Rectangle(left, tabsRect.Bottom - glyphsWidth, GLYPH_WIDTH, glyphsWidth);
			}
			
			return Rectangle.Empty;

		}

		void DrawTabSeparator(Graphics g, Rectangle tabRect, bool erase, int rowIndex)
		{
			// Don't draw a separator for the Flat + Standard style
			if (  tabsStyle == TabsStyle.Flat  || tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.XPTheme || tabsStyle  == TabsStyle.CustomImages
				|| IsOneNoteTabStyle() )
				return;

			// Don't draw separator is forcing Horizontal Text on Vertical Tabs
			if ( IsHorizontalText() )
				return;

			Color color = Color.Empty;
			if ( erase )
				color = GetTabAreaBackColor();
			else
				color = GetSeparatorColor();

			// Draw separator
			Rectangle sepRect = tabRect;
			Rectangle tabsRect = TabsArea;

			int separatorWidth = 1;
			if  (tabsStyle == TabsStyle.HighContrast || tabsStyle == TabsStyle.Office2003 )
				separatorWidth = 2;

			// Separators are smaller for the Document and Office styles
			if ( HasHorizontalTabs() )
			{
				if ( tabsStyle == TabsStyle.Document || tabsStyle == TabsStyle.Office2003 )
					sepRect.Inflate(0,-6);
				else
					sepRect.Inflate(0,-4);
			}
			else
			{
				if ( tabsStyle == TabsStyle.Document || tabsStyle == TabsStyle.Office2003 )
					sepRect.Inflate(-6,0);
				else
					sepRect.Inflate(-4,0);
			}

			using ( Pen p = new Pen(color) )
			{
				if ( HasHorizontalTabs() )
				{
					if( tabsStyle == TabsStyle.Office2003 && erase )
					{
						DrawOffice2003GlyphBackground(g, tabsRect, new Rectangle(sepRect.Left + 
							sepRect.Width - separatorWidth, sepRect.Top, 1, sepRect.Height), rowIndex);
					}
					else
					{
						g.DrawLine(p, sepRect.Left + sepRect.Width - separatorWidth, 
							sepRect.Top, sepRect.Left + sepRect.Width - separatorWidth, sepRect.Top + sepRect.Height - 1);
					}

					if ( tabsStyle == TabsStyle.Flat  || tabsStyle == TabsStyle.HighContrast || tabsStyle == TabsStyle.Office2003 )
					{
						separatorWidth = 1;
						Color lightColor = SystemColors.ControlLightLight;
						
						if ( tabsStyle == TabsStyle.Office2003 && erase )
						{
							DrawOffice2003GlyphBackground(g, tabsRect, new Rectangle(sepRect.Left + 
								sepRect.Width - separatorWidth,	sepRect.Top, 1, sepRect.Height), rowIndex);
						}
						else
						{
							if ( erase )
								lightColor = color;
							using ( Pen lightPen = new Pen(lightColor) )
							{
								g.DrawLine(lightPen, sepRect.Left + sepRect.Width - separatorWidth, 
									sepRect.Top, sepRect.Left + sepRect.Width - separatorWidth, 
									sepRect.Top + sepRect.Height - 1);
							}
						}
					}
				}
				else
				{
					bool flatStyle = tabsStyle == TabsStyle.Flat  || tabsStyle == TabsStyle.HighContrast 
						|| tabsStyle == TabsStyle.Office2003;
					bool flipPens = flatStyle && !erase && TabsLocation == TabsLocation.Left;
					if ( flipPens )
						separatorWidth = 1;
                     
					if ( tabsLocation == TabsLocation.Left )
					{
						if ( tabsStyle == TabsStyle.Office2003 && erase )
						{
							DrawOffice2003GlyphBackground(g, tabsRect, new Rectangle(sepRect.Left, 
								tabRect.Top + separatorWidth, sepRect.Width, 1), rowIndex);
						}
						else
						{
							g.DrawLine(p, sepRect.Left, tabRect.Top + separatorWidth, 
								sepRect.Left + sepRect.Width - 1, tabRect.Top + separatorWidth);
						}
					}
					else
					{
						if ( tabsStyle == TabsStyle.Office2003 && erase )
						{
							DrawOffice2003GlyphBackground(g, tabsRect, new Rectangle(sepRect.Left, 
								tabRect.Bottom - separatorWidth, sepRect.Width, 1), rowIndex);
						}
						else
						{
							g.DrawLine(p, sepRect.Left, tabRect.Bottom - separatorWidth, 
								sepRect.Left + sepRect.Width - 1, tabRect.Bottom - separatorWidth);
						}
					}

					if ( flatStyle )
					{
						separatorWidth = 1;
						Color lightColor = SystemColors.ControlLightLight;
						if ( erase )
							lightColor = color;

						if ( flipPens )
							separatorWidth = 2;

						using ( Pen lightPen = new Pen(lightColor) )
						{
							if ( tabsLocation == TabsLocation.Left )
							{
								if ( tabsStyle == TabsStyle.Office2003 && erase )
								{
									DrawOffice2003GlyphBackground(g, tabsRect, 
										new Rectangle(sepRect.Left, sepRect.Top + separatorWidth, 
										sepRect.Width, 1), rowIndex);
								}
								else
								{
									g.DrawLine(lightPen, sepRect.Left, tabRect.Top + separatorWidth, 
										sepRect.Left + sepRect.Width - 1, tabRect.Top + separatorWidth);
								}
							}
							else
							{
								if ( tabsStyle == TabsStyle.Office2003 && erase )
								{
									DrawOffice2003GlyphBackground(g, tabsRect, 
										new Rectangle(sepRect.Left, tabRect.Bottom - separatorWidth, 
										sepRect.Width, 1), rowIndex);
								}
								else
								{
									g.DrawLine(lightPen, sepRect.Left, tabRect.Bottom - separatorWidth, 
										sepRect.Left + sepRect.Width - 1, tabRect.Bottom - separatorWidth);
								}
							}

						}
					}
				}
			}
		}

		void DrawDoubleBufferedTab(TabPageEx page)
		{
			if ( !ShouldDrawDoubleBufferedTab(page) ) return;

			// To be efficient and avoid possible flickering just draw the
			// one tab that needs to be repainted in a bitmap buffer
			DoubleBuffer db = new DoubleBuffer();
			Rectangle rcTab = page.TabRectangle;
			Rectangle rcIcon = page.IconRectangle;

			// Get buffer
			Graphics gdb;
			int localTabsAreaHeight = TabsAreaHeight;
			int index = tabPages.IndexOf(page);
			bool selected = index == selectedTabIndex;

			if ( HasHorizontalTabs() ) 
			{
				if ( rcTab.Width == 0 || localTabsAreaHeight == 0 )
					return;
				gdb = db.RequestBuffer(rcTab.Width, localTabsAreaHeight);
			}
			else
			{
				if ( TabsAreaWidth == 0 || rcTab.Height == 0 )
					return;
				gdb = db.RequestBuffer(TabsAreaWidth, rcTab.Height);
			}
			
			int left = 0;
			int top = 0;
											
			// Draw tab into buffer
			int rowIndex = 0;
			if ( tabsFitting == TabsFitting.MultiLine && multilineRows.Count > 1 )
			{
				rowIndex = GetRowIndex(index);
				drawingRowIndex = rowIndex;
			}

			OneNoteColors oneNoteColors = ColorUtil.GetOneNoteColors(tabsStyle, selectedTabIndex);
			DrawTab(gdb, page, ref left, ref top, rowIndex, true, localTabsAreaHeight, oneNoteColors);
			// Reset position to actual one since the above function sets it to the wrong rectangle
			page.TabRectangle = rcTab;
			page.IconRectangle = rcIcon;

			// Now paint the buffer into the actual control area
			Graphics g = Graphics.FromHwnd(Handle);
			if ( (tabsFitting == TabsFitting.ShowArrows 
				|| tabsFitting == TabsFitting.FixedWidth) && index == lastVisiblePageIndex )
			{
				// Make sure we clip the glyphs
				Rectangle clipRect = Rectangle.Empty;
				if ( HasHorizontalTabs() ) 
				{
					clipRect = new Rectangle(ClientRectangle.Left, 
						ClientRectangle.Top, LeftArrowXPos(), ClientRectangle.Height);
				}
				else if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop )
				{
					clipRect = new Rectangle(ClientRectangle.Left, 
						LeftArrowYPos(), ClientRectangle.Width, ClientRectangle.Height - LeftArrowYPos());
				}
				else if ( tabsLocation == TabsLocation.Right || ShouldForceLeftTabsTop )
				{
					clipRect = new Rectangle(ClientRectangle.Left,  
						ClientRectangle.Top, ClientRectangle.Width, LeftArrowYPos());
				}

				g.Clip = new Region(clipRect);			 
			}

			db.PaintBuffer(g, rcTab.Left, rcTab.Top);
			db.Dispose();
			g.Dispose();
		}

		bool ShouldDrawDoubleBufferedTab(TabPageEx page)
		{
			// No need to draw it if not within visible range
			if ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth )
			{
				int index = tabPages.IndexOf(page);
				if ( index < firstVisiblePageIndex || index > lastVisiblePageIndex )
					return false;
			}

			return true;

		}

		bool CanTabsFit(Graphics g, out int shrunkWidth)
		{
			// Iterate though the tabs collection and calculate if all tabs
			// fit within available width
			int currentTabWidth = 0;
			bool tabsDoFit = true;
			shrunkWidth = 0;
			int availableWidth = 0;
			
			if ( HasHorizontalTabs() )
				availableWidth = ClientRectangle.Width - 2;
			else
				availableWidth = ClientRectangle.Height - 2;

			int tabsWidth = 0;
			for ( int i = 0; i < tabPages.Count; i++ )
			{
				currentTabWidth = GetTabWidth(g, tabPages[i]);
				tabsWidth += currentTabWidth;
				if ( tabsDoFit == true && tabsWidth > availableWidth )
				{
					tabsDoFit = false;
					break;
				}
			}

			if ( tabsDoFit == false && tabPages.Count > 0 )
			{
				shrunkWidth = availableWidth/tabPages.Count;
			}
			
			return tabsDoFit;
		}

		int GetTabWidth(Graphics g, TabPageEx page)
		{
			if ( page.HideTab )
				return 0;

			int width = TAB_LEFT_TEXT_MARGIN;
			if ( showIcon && imageList != null && page.ImageIndex != -1 )
			{
				width += imageList.ImageSize.Width;
			}
			
			// Now add the text width
			int index = tabPages.IndexOf(page);
			bool cleanupFont = false;
			if ( showText && page.Title != string.Empty )
			{
				if ( ShowOnlySelectedTabText == false || ( ShowOnlySelectedTabText && index == selectedTabIndex ) || IsHorizontalText() )
				{
					if ( width > TAB_LEFT_TEXT_MARGIN )
					{
						// If we have an icon, add icon to text margin
						width += ICON_TO_TEXT_MARGIN;
					}
				
					// Now add text width
					Font font = Font;
					if ( showSelectedTextBold )
					{
						// Leave space for bold face even if we are  going to use it
						// only for the selected tab so that we don't have to recalculate the
						// whole thing every time the user clicks on a tab
						font = new Font(font, FontStyle.Bold);
						cleanupFont = true;
					}

					SizeF dimension = SizeF.Empty;
					if ( tabsFitting == TabsFitting.FullWidth && !IsHorizontalText() )
					{
						StringFormat format = StringFormat.GenericTypographic;
						format.HotkeyPrefix = HotkeyPrefix.Show;
						dimension = g.MeasureString(page.Title, font, new PointF(0,0), format);
					}
					else
					{
						StringFormat format = new StringFormat();
						format.HotkeyPrefix = HotkeyPrefix.Show;
						dimension = g.MeasureString(page.Title, font, new PointF(0,0), format);
					}
					
					// One pixel fudge factor for rounding errors
					width += (int)dimension.Width + 1;

					// Cleanup
					if ( cleanupFont )
						font.Dispose();
				}
			}

			//  Add the right margin
			width += TAB_RIGHT_TEXT_MARGIN;

			if ( tabsStyle == TabsStyle.Flat  || tabsStyle == TabsStyle.HighContrast || tabsStyle == TabsStyle.Office2003 )
			{
				// One extra pixel because the separator
				// is now two pixel wide
				width++;
			}

			// Make sure not tab width is actually greater
			// than the available width for the tab controls since
			// that would not make sense
			if ( !(tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth) )
			{
				if ( (tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Bottom)  && 
					width > (ClientRectangle.Width - (MULTILINE_EDGE_MARGIN * 2)) )
				{
					width = ClientRectangle.Width - (MULTILINE_EDGE_MARGIN * 2);
				}
				else if ( width > (ClientRectangle.Height - (MULTILINE_EDGE_MARGIN * 2)) )
				{
					width = ClientRectangle.Height - (MULTILINE_EDGE_MARGIN * 2);
				}
			}

			if ( IsHorizontalText() )
			{
				// Add margins on both sides to compensate for the fact
				// that the TabRect will be adjusted not just one time
				// but for every tab and thus the whole tab area is not just
				// being adjusted once but every tab area is
				width += (TAB_AREA_TOP_MARGIN*2);
			}

			if ( IsOneNoteTabStyle() && !IsHorizontalText() )
			{
				// If using OneNote tabs style make sure
				// to add extra space for the selected tab and/or the first tab in the control
				int tabsHeight = TabsAreaHeight - (TAB_AREA_TOP_MARGIN + TAB_AREA_BOTTOM_MARGIN);
				bool firstRowIndex = false;
				if ( tabsFitting == TabsFitting.MultiLine && multilineRows != null 
					&& multilineRows.Count > 1 )
				{
					int rowIndex = GetRowIndex(index);
					if ( rowIndex != -1 )
					{
						tabsHeight = GetMultilineRowHeight(rowIndex);
						// We are going to draw the diagonal effect in a row other than the first one
						// only if the tab is actually also the currently selected tab
						firstRowIndex = IsFirstTabInRow(rowIndex, index) && index == selectedTabIndex;
					}
					else
					{
						int height = Font.Height;
						if ( imageList != null && imageList.ImageSize.Height > height )
							height = imageList.ImageSize.Height;
						tabsHeight = height + TAB_AREA_TOP_MARGIN + verticalMargin*2 + TAB_AREA_BOTTOM_MARGIN;
					}
				}

				if ( tabsFitting == TabsFitting.MultiLine && multilineRows != null 
					&& multilineRows.Count > 1 )
				{
					// For multiline line fitting and OneNote tabs style
					// add an equal increment for all tabs so that we don't have
					// different size tabs that might cause rows grow and shrink
					// which we cause a confusing effect to the user
					width += tabsHeight;
				}
				else if ( index == 0  || index == firstVisiblePageIndex || firstRowIndex )
				{
					width += tabsHeight;
					if ( (index == 0 && selectedTabIndex == 1) 
						|| (index != 0 && index == firstVisiblePageIndex && selectedTabIndex == (firstVisiblePageIndex+1)) )
						width += tabsHeight - OVERLAPPING_GAP;
				}
				else if ( index == (selectedTabIndex-1) )
				{
					width += tabsHeight;

					if ( !(tabsFitting == TabsFitting.FixedWidth || tabsFitting == TabsFitting.FullWidth) )
					{
						// Take out the right margin so that we don't have too much space
						// on the right --makes it look better--
						width -= (TAB_RIGHT_TEXT_MARGIN*2); 
					}
				}
			}

			return width;
		}

		int GetGreatestTabWidth()
		{
			if ( hideTabs )
				return 0;

			// If we are displaying horizontal text 
			// on vertical Tabs, we need to calculate
			// the tab with the greatest width and use that
			// as the width for all tabs now needs to have the same size

			// Make sure this call is only made when the Vertical tabs are being displayed
			Debug.Assert(tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right);  
			int width = 0;
			using ( Graphics g = CreateGraphics() )
			{
				for ( int i = 0; i < tabPages.Count; i++ )
				{
					TabPageEx page = tabPages[i];
					int tabWidth = GetTabWidth(g, page);
					if ( page.HideTab == false )
						width = Math.Max(width, tabWidth);
				}
			}

			if ( IsOneNoteTabStyle() && IsHorizontalText() )
			{
				// Add extra width to all tabs
				int height = Font.Height;
				if ( imageList != null && imageList.ImageSize.Height > height )
					height += imageList.ImageSize.Height;
				height += TAB_AREA_TOP_MARGIN + verticalMargin*2 + TAB_AREA_BOTTOM_MARGIN;
				width += height;
			}

			return width;
		}

		internal TabControlHit HitTest(Point pt, ref int index)
		{
			index = -1;

			if ( tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth )
			{
				// Check if we hit any of the glyphs
				if ( showClose && closeRect.Contains(pt) )
				{
					if ( tabPages.Count > 0 )
						return TabControlHit.CloseButton;
					else
						return TabControlHit.None;
				}
				else if ( rightArrowRect.Contains(pt) )
				{
					if ( IsRightArrowEnabled() )
						return TabControlHit.RightArrow;
					else
						return TabControlHit.None;
				}
				else if ( leftArrowRect.Contains(pt) )
				{
					if ( IsLeftArrowEnabled() )
						return TabControlHit.LeftArrow;
					else
						return TabControlHit.None;
				}
			}

			// Check if we hit any of the tabs
			for ( int i = firstVisiblePageIndex; i < tabPages.Count; i++ )
			{
				TabPageEx page = tabPages[i];
				if ( page.TabRectangle.Contains(pt) )
				{
					index = i;
					return TabControlHit.Tab;
				}
			}

			return TabControlHit.None;
		}

		void ProcessMouseDown(MouseEventArgs e)
		{
			int index = -1;
			mouseButtonDownOnGlyph = false;
			Point pt = new Point(e.X, e.Y);
			// Disable automatic painting of the control
			// when a property change
			InvalidateOnPropertyChanged = false;
		
			TabControlHit hit = HitTest(pt, ref index);

			if ( hit == TabControlHit.LeftArrow || hit == TabControlHit.RightArrow 
				|| hit == TabControlHit.CloseButton )
			{
				// Update glyphs
				Graphics g = Graphics.FromHwnd(Handle);
				currentGlyphHit = hit;
				mouseButtonDownOnGlyph = true;
				DrawDoubleBufferedGlyphs();
				g.Dispose();
			}
			else if ( hit == TabControlHit.Tab )
			{
				// Process the tab only if it is enabled
				if ( tabPages[index].Enabled )
				{

					// Check if we need to move the selected tab row to the front
					bool moveTabs = false;
					if ( tabsFitting == TabsFitting.MultiLine && multilineRows.Count > 1 && keepSelectedTabInSameRow == false )
					{
						MoveSelectedTabRowToFront(index);
						moveTabs = true;
					}
                
					if ( showOnlySelectedTabText || IsStandardTabsMultilineCase() || moveTabs || IsOneNoteTabStyle()
						|| (tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled()) )
					{
						// Force a repaint because tab width
						// actually need to be recalculated
						SelectedTabIndex = index;
						UpdateTabPagesVisibility();
						ScrollTabs(index);
						Invalidate();
					}
					else
					{
						// Double buffer the process of updating the new tab
						ProcessSelectedTabIndexChange(index);
					}

					// Flag the index that was clicked in case
					// TabDragging is enabled
					tabDragIndex = index;
				}

			}

			// Reset automatic repainting when a property of the control changes
			InvalidateOnPropertyChanged = true;

		}

		void ProcessContextMenu(MouseEventArgs e)
		{
			Point pt = new Point(e.X, e.Y);
			int index = 0;
			TabControlHit hit = HitTest(pt, ref index);
			if ( hit == TabControlHit.Tab )
			{
				OnTabPageContextMenu(pt, tabPages[index]);
			}
		}

		void ProcessSelectedTabIndexChange(int index)
		{
			// Repaint previously selected tab and new selected tab
			int previousIndex = selectedTabIndex;
			int separatorIndex = GetVisibleIndexBeforeIndex(previousIndex);
	            
			// Use the property instead on the variable so
			// that the ChangedProperty event is fired
			SelectedTabIndex = index;
			
			// If the index did not change, perhaps because of Validation
			// then we have nothing to do
			if ( previousIndex == SelectedTabIndex)
				return;

			// Draw only the tab that was clicked and the one
			// that was selected before
			if ( previousIndex >= 0&& previousIndex < tabPages.Count )
				DrawDoubleBufferedTab(tabPages[previousIndex]);
			// Now newly selected tab
			DrawDoubleBufferedTab(tabPages[selectedTabIndex]);
			
			// Draw separator if needed for the tab before the previously selected index 
			if ( separatorIndex >= firstVisiblePageIndex && separatorIndex < tabPages.Count 
				&& separatorIndex != selectedTabIndex)
			{
				if ( ShouldDrawDoubleBufferedTab(tabPages[previousIndex]) )
				{
					bool drawIt = true;
					int rowIndex = -1;
					// In multiline mode we don't draw the separator for the last tab
					if ( tabsFitting == TabsFitting.MultiLine && multilineRows.Count > 1 )
					{
						rowIndex = GetRowIndex(separatorIndex);
						drawIt = !IsLastTabInRow(rowIndex, separatorIndex);
					}

					if ( drawIt )
					{
						Graphics g = Graphics.FromHwnd(Handle);
						DrawTabSeparator(g, tabPages[separatorIndex].TabRectangle, false, rowIndex);
						g.Dispose();
					}
				}
			}

			// Erase separator if needed for the tab before the newly selected index 
			separatorIndex = GetVisibleIndexBeforeIndex(selectedTabIndex); 
			if ( separatorIndex >= firstVisiblePageIndex && separatorIndex < tabPages.Count 
				&& separatorIndex != selectedTabIndex)
			{
				bool drawIt = true;
				int rowIndex = -1;
				// In multiline mode we don't draw the separator for the last tab
				if ( tabsFitting == TabsFitting.MultiLine && multilineRows.Count > 1 )
				{
					rowIndex = GetRowIndex(separatorIndex);
					drawIt = !IsLastTabInRow(rowIndex, separatorIndex);
				}

				if ( drawIt )
				{
					// Skip if tab is not visible
					Graphics g = Graphics.FromHwnd(Handle);
					DrawTabSeparator(g, tabPages[separatorIndex].TabRectangle, true, rowIndex);
					g.Dispose();
				}
			}

			UpdateTabPagesVisibility();

			// If the tab that was clicked is not fully visible
			// and we are in ShowArrows or FixedWidth tab fitting mode, then scroll the tabs
			// so that the last tab clicked is fully visible
			ScrollTabs(index);
		}

		void ScrollTabs(int clickedIndex )
		{
			if ( !IsScrollableTabsStyle() || clickedIndex != lastVisiblePageIndex )
				return;

			TabPageEx page = tabPages[lastVisiblePageIndex];
			Debug.Assert(page!=null);
			if ( HasHorizontalTabs())
			{
				if ( (page.TabRectangle.Left + page.TabRectangle.Width) > LeftArrowXPos() )
				{
					int neededWidth = page.TabRectangle.Width - (LeftArrowXPos()- page.TabRectangle.Left); 
					TabPageEx firstPage = tabPages[firstVisiblePageIndex];
					Debug.Assert(firstPage!=null);
					int currentWidth = firstPage.TabRectangle.Width;
					firstVisiblePageIndex++; 
					while ( currentWidth < neededWidth && firstVisiblePageIndex < lastVisiblePageIndex)
					{
						firstPage = tabPages[firstVisiblePageIndex];
						Debug.Assert(firstPage!=null);
						currentWidth += firstPage.TabRectangle.Width;
						firstVisiblePageIndex++;					
					}
					Invalidate();
				}
			}
			else 
			{
				int neededHeight = 0;
				if ( tabsLocation == TabsLocation.Left && ShouldForceLeftTabsTop && page.TabRectangle.Bottom  >= LeftArrowYPos() )
					neededHeight = page.TabRectangle.Height - (LeftArrowYPos() - page.TabRectangle.Top); 
				else if ( tabsLocation == TabsLocation.Left && !ShouldForceLeftTabsTop && page.TabRectangle.Top  <= LeftArrowYPos() )
					neededHeight = page.TabRectangle.Height - (LeftArrowYPos() - page.TabRectangle.Top); 
				else if ( tabsLocation == TabsLocation.Right && page.TabRectangle.Bottom  >= LeftArrowYPos() )
					neededHeight = page.TabRectangle.Height - (page.TabRectangle.Bottom - LeftArrowYPos()); 
				else
					return;
					
				TabPageEx firstPage = tabPages[firstVisiblePageIndex];
				Debug.Assert(firstPage!=null);
				int currentHeight = firstPage.TabRectangle.Height;
				firstVisiblePageIndex++; 
				while ( currentHeight < neededHeight && firstVisiblePageIndex < lastVisiblePageIndex)
				{
					firstPage = tabPages[firstVisiblePageIndex];
					Debug.Assert(firstPage!=null);
					currentHeight += firstPage.TabRectangle.Height;
					firstVisiblePageIndex++;					
				}
				
				Invalidate();
			}
		
		}

		void ProcessMouseUp(MouseEventArgs e)
		{
			tabDragIndex = -1;
			int index = -1;
			mouseButtonDownOnGlyph = false;
			currentGlyphHit = TabControlHit.None;
			Point pt = new Point(e.X, e.Y);
			
			TabControlHit hit = HitTest(pt, ref index);
			if ( hit == TabControlHit.LeftArrow || hit == TabControlHit.RightArrow 
				|| hit == TabControlHit.CloseButton )
			{
				// Update glyphs
				Graphics g = Graphics.FromHwnd(Handle);
				mouseButtonDownOnGlyph = false;
				DrawDoubleBufferedGlyphs();

				if ( hit != TabControlHit.None )
				{
					if ( hit == TabControlHit.CloseButton )
						OnCloseButtonClicked();
					else if ( hit == TabControlHit.LeftArrow )
						OnLeftArrowClicked();
					else if ( hit == TabControlHit.RightArrow )
						OnRightArrowClicked();
				}
			}
		}

		void ProcessMouseMove(MouseEventArgs e)
		{
			int index = -1;
			mouseButtonDownOnGlyph = false;
			Point pt = new Point(e.X, e.Y);
			
			TabControlHit hit = HitTest(pt, ref index);
			if ( currentGlyphHit != hit )
			{
				TabControlHit previousHit = currentGlyphHit;
				currentGlyphHit = hit;
				Graphics g = Graphics.FromHwnd(Handle);
				if ( IsGlyph(hit) || IsGlyph(previousHit) )
					DrawDoubleBufferedGlyphs();
			}
			
			if ( (hotTrack && hotTrackIndex != -1 && hotTrackIndex != index) 
				|| (hotTrack && index == -1) )
			{
				int previousHotTrack = hotTrackIndex;
				hotTrackIndex = -1;
				if ( previousHotTrack >= 0 && previousHotTrack < tabPages.Count )
				{
					TabPageEx page = tabPages[previousHotTrack];
					if ( !IsStandardTabsMultilineCase() )
						DrawDoubleBufferedTab(page);
					else
					{
						// When using the standard tabs style
						// Don't double buffer, just draw all tabs
						Invalidate();
					}
				}
			}

			if ( hit == TabControlHit.Tab && hotTrack && hotTrackIndex != index )
			{
				// Draw hot tracked tab
				hotTrackIndex = index;
				TabPageEx hotTrackPage = tabPages[index];
				
				if ( hotTrackPage.Enabled )
				{
					if ( !IsStandardTabsMultilineCase() )
						DrawDoubleBufferedTab(hotTrackPage);
					else
					{
						// When using the standard tabs style
						// Don't double buffer, just draw all tabs
						Invalidate();
					}
				}
			}

			if ( tabDrag && hit == TabControlHit.Tab && index != -1 && index != tabDragIndex && tabDragIndex != -1)
			{
				ProcessTabSwitching(index, pt);
				// We don't want to process hover select if we are processing TabDragging
				return;
			}

			if ( hit == TabControlHit.Tab && hoverSelect && index != -1 && index != hoverSelectIndex )
			{
				if (tabPages[index].Enabled)
				{
					hoverSelectIndex = index;
					// Make this tab the current selection
					SelectedTabIndex = index;
					ScrollTabs(index);
				}
			}

			if ( tabsFitting == TabsFitting.FixedWidth )
			{
				if ( (hit == TabControlHit.Tab && toolTipTargetTabIndex == -1)
					||  (hit == TabControlHit.Tab && index != toolTipTargetTabIndex ) )
				{
					if ( tooltipActive == false )
					{

						// If the tab fit within the fixed width then there is not 
						// need to display a tooltip
						Graphics g = Graphics.FromHwnd(Handle);
						TabPageEx px = tabPages[index];
						int tabWidth = GetTabWidth(g, px);
						toolTipTargetTabIndex = index;
						if ( tabWidth > fixedWidth )
						{
							// Update tooltip text
							tooltip.UpdateToolTipText(this, px.Title);

							// Make sure we don't end up displaying the wrong text
							// if the move the mouse to fast before the timers have
							// time to display the tooltip
							indexThatFiredTimer = index;
										
							// Start timer to display the tooltip
							// using the initial delay setting
							showToolTipTimer.Start();
						}
					}
					else if ( tooltipActive && index != toolTipTargetTabIndex )
					{
						// Hide previous tooltip first
						tooltipActive = false;
						showToolTipTimer.Stop();
						tooltip.HideTrackingToolTip(this);
					}
				}
			}
		}

		void ProcessTabSwitching(int index, Point pt)
		{
			if ( index >= 0 && index <= tabPages.Count - 1 )
			{
				// Disable flags to automatically paint the control
				InvalidateOnPropertyChanged = false;
				updateTabPageVisibility = false;
				invalidateOnTabCollectionChange = false;
								
				if ( selectedTabIndex >=0 && selectedTabIndex <= tabPages.Count - 1 && !oldTabDragRect.Contains(pt) )
				{
					if ( index >=0 && index <= tabPages.Count - 1 )
					{
						TabPageEx previousPage = tabPages[index];
						oldTabDragRect = previousPage.TabRectangle;
					}
					else
					{
						oldTabDragRect = Rectangle.Empty;
					}

					// Suspend painting to eliminate the flickering
					// associated with inserting and removing a page
					WindowsAPI.BeginUpdate(Handle);

					TabPageEx page = tabPages[selectedTabIndex];
					page.TabRectangle = Rectangle.Empty;
					tabPages.Remove(page);
					tabPages.Insert(index, page);
					tabDragIndex = index;
					SelectedTabIndex = index;
                    
					// Resume painting
					WindowsAPI.EndUpdate(Handle);

					// Draw tabs in the new order
					if ( !IsOneNoteTabStyle() )
						DrawDoubleBufferedTabs();
				}

				// Reset repainting flags
				invalidateOnTabCollectionChange = true;
				updateTabPageVisibility = true;
				InvalidateOnPropertyChanged = true;

				// Don't double buffer for OneNote tabs style
				if ( IsOneNoteTabStyle() )
					Invalidate();

			}
		}

		bool IsGlyph(TabControlHit hit)
		{
			return hit == TabControlHit.LeftArrow || 
				hit == TabControlHit.RightArrow || hit == TabControlHit.CloseButton;
		}

		void OnTabCollectionChanged(object sender, EventArgs e)
		{
			if ( IsHorizontalText() )
				UpdateTabPagesBounds();

			// TabPages collection changed, invalidate the control
			// to update the tab area
			if ( invalidateOnTabCollectionChange )
				Invalidate();
		}

		void OnTabPagesCollectionClearComplete()
		{
			// All control in the control collection are TabPageEx,
			// thus is safe just to clear the Controls collection
			Controls.Clear();

			// Reset to default values
			selectedTabIndex = 0;
			firstVisiblePageIndex = 0;

			if ( multilineRows != null )
				multilineRows.Clear();

			if ( IsHorizontalText() )
				UpdateTabPagesBounds();
		}

		void OnTabPagesCollectionInsertStart(int index, object value)
		{
			// TabPage added to the TabPages collection will
			// also be added to the Controls collection
			TabPageEx tabPage = value as TabPageEx;
			
			// Add a back reference to the TabPage so 
			// that we can update the parent when a page has changed
			if ( tabPage != null )
			{
				// If the control is a tab page
				tabPage.ParentTabControl = this;
			}

			// Add it only if it is not in the collection already
			if ( tabPage != null && !Controls.Contains(tabPage) )
			{
				Rectangle oldBounds = tabPage.Bounds;
				Rectangle newBounds = GetPageBounds();
				if ( !oldBounds.Equals(newBounds) ) 
					tabPage.Bounds = newBounds;

				Controls.Add(tabPage);
			}

			// Set current tab to the first one if there is not current tab selected
			if ( tabPages.Count > 0 && selectedTabIndex == -1 )
				SelectedTabIndex = 0;

			UpdateTabPagesVisibility();
		}

		void OnTabPagesCollectionInsertComplete(int index, object value)
		{
			// In we are in multiline mode, recalculate tabs distribution
			if ( tabsFitting == TabsFitting.MultiLine )
			{
				UpdateMultilineDimensions();
				if ( IsOneNoteTabStyle() )
				{
					// Force a recalculation of the tabs again
					// since when using OneNote tabs and if the Multiline
					// rows array is initially empty, not extra width will be added
					// -- this second time it will --
					UpdateMultilineDimensions();
				}
				else
				{
					needRowTableCalculation = true;
					CalculateRowsTable(null);
					UpdateTabPagesBounds();
				}
			}
		}

		void OnTabPagesCollectionRemoveStart(int index, object value)
		{
			TabPageEx tabPage = value as TabPageEx;
			Debug.Assert(tabPage != null);
			// Remove the page only if it is in the collection
			if ( Controls.Contains(tabPage) )
			{
				// Avoid the form close button bug
				RemoveChildControlSafely(tabPage);
				SelectedTabIndex = GetSafeNewSelectedIndex(index);
			}

			UpdateTabPagesVisibility();

		}

		void OnTabPagesCollectionRemoveComplete(int index, object value)
		{
			// In we are in multiline mode, recalculate tabs distribution
			if ( tabsFitting == TabsFitting.MultiLine )
			{
				needRowTableCalculation = true;
				CalculateRowsTable(null);
				UpdateTabPagesBounds();
			}
		}

		internal void UpdateTabPagesBounds()
		{
			Rectangle rc = ClientRectangle;
			int borderWidth = BorderWidth;

			// Special case for XPTheme tabs
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled())
				borderWidth = GetXPTabBorderWidth();

			//  Make sure we resize the TabPages properly before display
			Rectangle bounds = GetPageBounds();
			for ( int i = 0; i < tabPages.Count; i++ )
			{
				TabPageEx tabPage = tabPages[i];
				tabPage.Bounds = bounds;
			}
		}

		int GetXPTabBorderWidth()
		{
			return 1;
		}

		internal void UpdateTabPagesBound(int index)
		{
			Rectangle rc = ClientRectangle;
			int borderWidth = BorderWidth;

			// Special case for XPTheme tabs
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
				borderWidth = GetXPTabBorderWidth();

			//  Make sure we resize the TabPages properly before display
			Rectangle bounds = GetPageBounds();
			if ( index >= 0 && index < tabPages.Count )
			{
				TabPageEx tabPage = tabPages[index];
				tabPage.Bounds = bounds;
			}
		}


		internal Rectangle GetPageBounds()
		{
			Rectangle rc = ClientRectangle;
			int borderWidth = BorderWidth;

			// Special case for XPTheme tabs
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
				borderWidth = GetXPTabBorderWidth();

			int tabsAreaWidth = TabsAreaWidth;
			int tabsAreaHeight = TabsArea.Height;
			int topMargin = TAB_AREA_TOP_MARGIN;
			if ( hideTabs )
				topMargin = 0;
			
			Rectangle bounds = Rectangle.Empty;
			if ( tabsLocation == TabsLocation.Top )
			{
				if ( IsSpecialBorder() && (tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document
					|| tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme
					|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
				{
					bounds =  new Rectangle(rc.Left + borderWidth, rc.Top + borderWidth + tabsAreaHeight - topMargin, 
						rc.Width - (borderWidth*2), rc.Height -((borderWidth*2) + tabsAreaHeight) + topMargin);

				}
				else
				{
					bounds =  new Rectangle(rc.Left + borderWidth, rc.Top + borderWidth + tabsAreaHeight, 
						rc.Width - (borderWidth*2), rc.Height -((borderWidth*2) + tabsAreaHeight));
				}
			}
			else if ( tabsLocation == TabsLocation.Bottom )
			{
				if ( IsSpecialBorder() && (tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document
					|| tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme
					|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
				{
					bounds =  new Rectangle(rc.Left + borderWidth, rc.Top + borderWidth, 
						rc.Width - (borderWidth*2), rc.Height -((borderWidth*2) + tabsAreaHeight) + topMargin);
				}
				else
				{
					bounds =  new Rectangle(rc.Left + borderWidth, rc.Top + borderWidth, 
						rc.Width - (borderWidth*2), rc.Height -((borderWidth*2) + tabsAreaHeight));
				}
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				if ( IsSpecialBorder() && (tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document
					|| tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme
					|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
				{
					bounds =  new Rectangle(rc.Left + tabsAreaWidth + borderWidth - topMargin, rc.Top + borderWidth, 
						rc.Width - (borderWidth*2 + tabsAreaWidth) + topMargin, rc.Height - borderWidth*2);
				}
				else
				{
					bounds =  new Rectangle(rc.Left + tabsAreaWidth + borderWidth, rc.Top + borderWidth, 
						rc.Width - (borderWidth*2 + tabsAreaWidth), rc.Height - borderWidth*2);
				}

			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				if ( IsSpecialBorder() && (tabsStyle == TabsStyle.Standard || tabsStyle == TabsStyle.Document
					|| tabsStyle == TabsStyle.Office2003 || tabsStyle  == TabsStyle.XPTheme
					|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) )
				{
					bounds =  new Rectangle(rc.Left + borderWidth, rc.Top + borderWidth, 
						rc.Width - (borderWidth*2 + tabsAreaWidth) + topMargin, rc.Height - borderWidth*2);
				}
				else
				{
					bounds =  new Rectangle(rc.Left + borderWidth, rc.Top + borderWidth, 
						rc.Width - (borderWidth*2 + tabsAreaWidth), rc.Height - borderWidth*2);
				}
			}

			if ( DesignMode && addDesignTimeTabPagePadding )
				bounds.Inflate(-DESIGN_TIME_PAGE_GAP,-DESIGN_TIME_PAGE_GAP);
						
			return bounds;
		}

		void UpdateGlyphsImageList()
		{
			Color imageColor = glyphsColor;
				        
			// Change the black color in the image list
			// to the control dark dark color

			ImageAttributes ia = new ImageAttributes();
			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = lastNewColor;
			colorMap.NewColor = imageColor;
			lastNewColor = Color.FromArgb(imageColor.R, imageColor.G, imageColor.B);
			ia.SetRemapTable(new ColorMap[]{colorMap}, ColorAdjustType.Bitmap);
	        
			Bitmap newBitmap = new Bitmap(glyphsImageList.Count*glyphsImageList.ImageSize.Width, 
				glyphsImageList.ImageSize.Height);
			Graphics g = Graphics.FromImage(newBitmap);
			g.DrawImage(glyphsImageList.Image, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
				0, 0, newBitmap.Width, newBitmap.Height, GraphicsUnit.Pixel, ia);
			glyphsImageList = new ImageListEx(newBitmap, new Size(GLYPH_WIDTH, GLYPH_HEIGHT));

			// Cleanup
			ia.Dispose();
			
		}

		void UpdateOffice2003GlyphsImageList()
		{
			Color imageColor = ColorUtil.Office2003DarkGripper;
				        
			// Change the black color in the image list
			// to the control dark dark color

			ImageAttributes ia = new ImageAttributes();
			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = lastNewColor;
			colorMap.NewColor = imageColor;
			lastNewColor = Color.FromArgb(imageColor.R, imageColor.G, imageColor.B);
			ia.SetRemapTable(new ColorMap[]{colorMap}, ColorAdjustType.Bitmap);
	        
			Bitmap newBitmap = new Bitmap(glyphsImageList.Count*glyphsImageList.ImageSize.Width, 
				glyphsImageList.ImageSize.Height);
			Graphics g = Graphics.FromImage(newBitmap);
			g.DrawImage(glyphsImageList.Image, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
				0, 0, newBitmap.Width, newBitmap.Height, GraphicsUnit.Pixel, ia);
			office2003GlyphsImageList = new ImageListEx(newBitmap, new Size(GLYPH_WIDTH, GLYPH_HEIGHT));

			// Cleanup
			ia.Dispose();
			
		}

		bool IsLeftArrowEnabled()
		{
			return firstVisiblePageIndex > 0;
		}

		bool IsRightArrowEnabled()
		{
			return lastVisiblePageIndex < (tabPages.Count-1);
		}

		Color GetControlColor(TabPageEx page)
		{
			// Draw the tab background
			Color tabBackColor = page.TabBaseColor;
			if ( tabBackColor == Color.Empty )
				tabBackColor = tabBaseColor;
			if ( tabBackColor == Color.Empty )
				tabBackColor = BackColor;

			return tabBackColor;
		}

		Color GetControlLightColor(TabPageEx page)
		{
			Color controlColor = page.TabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = tabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = BackColor;
			
			if ( controlColor == BackColor )
				return SystemColors.ControlLight;
			else
				return ControlPaint.Light(controlColor);
		}

		Color GetControlLightLightColor(TabPageEx page)
		{
			Color controlColor = page.TabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = tabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = BackColor;
			
			if ( controlColor == BackColor )
				return SystemColors.ControlLightLight;
			else
				return ControlPaint.LightLight(controlColor);
		}

		Color GetControlDarkColor(TabPageEx page)
		{
			Color controlColor = page.TabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = tabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = BackColor;
			
			if ( controlColor == BackColor )
				return SystemColors.ControlDark;
			else
				return ControlPaint.Dark(controlColor);
		}

		Color GetControlDarkDarkColor(TabPageEx page)
		{
			Color controlColor = page.TabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = tabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = BackColor;
			
			if ( controlColor == BackColor )
				return SystemColors.ControlDarkDark;
			else
				return ControlPaint.DarkDark(controlColor);
		}

		Color GetLineDarkDarkColor()
		{
			if ( tabsLineColor != Color.Empty )
				return tabsLineColor;
			else if ( BorderStyleEx == BorderStyleEx.FixedSingle )
				return Color.Black;
			else if ( BorderStyleEx == BorderStyleEx.StaticEdge )
				return SystemColors.ControlDark;
				        
			return SystemColors.ControlDarkDark;
		}

		Color GetDocumentTabDarkDarkColor(TabPageEx page)
		{
			Color controlColor = page.TabBaseColor;
			if ( controlColor == Color.Empty )
				controlColor = tabBaseColor;
			
			if ( controlColor != Color.Empty )
				return ControlPaint.DarkDark(controlColor);
			else
			{
				if ( tabsLineColor != Color.Empty )
					return tabsLineColor;
				else if ( BorderStyleEx == BorderStyleEx.FixedSingle )
					return Color.Black;
				else if ( BorderStyleEx == BorderStyleEx.StaticEdge )
					return SystemColors.ControlDark;
			}
	        
			return SystemColors.ControlDarkDark;
		}

		Color GetTabAreaBackColor()
		{
			Color backColor = Color.Empty;
			if ( tabsStyle == TabsStyle.Document )
				backColor = documentStyleBackColor;
			else 
			{
				backColor = tabsAreaBackColor;
			}
			return backColor;
		}

		Color GetSeparatorColor()
		{
			if ( tabsStyle == TabsStyle.Office2003 )
				return ColorUtil.Office2003SeparatorDarkColor;
			return SystemColors.ControlDark;
		}

		bool IsSpecialBorder()
		{
			// When using XPTheme, the border is always 1 pixel
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
				return false;

			if (BorderStyleEx == BorderStyleEx.ModalFrame || BorderStyleEx == BorderStyleEx.RaisedFrame)
				return true;
	        
			return false;
		}

		bool HasHorizontalTabs()
		{
			if ( tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Bottom )
				return true;
			return false;
		}

		bool HasVerticalTabs()
		{
			if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
				return true;
			return false;
		}

		int CalculateTabsAreaHeight()
		{
			if ( hideTabs )
				return 0;

			// Try to use cached value to speed up things
			int height = tabControlFontHeight;
			if ( height == -1 )
			{
				height = Font.Height;
				tabControlFontHeight = height;
			}

			if ( imageList != null && imageList.ImageSize.Height > height )
				height = imageList.ImageSize.Height;

			int tabsAreaHeight = height + TAB_AREA_TOP_MARGIN + verticalMargin*2 + TAB_AREA_BOTTOM_MARGIN;
			if ( tabsFitting == TabsFitting.MultiLine && multilineRows != null && multilineRows.Count > 1)
			{
				if ( tabsStyle == TabsStyle.Standard || tabsStyle  == TabsStyle.XPTheme 
					|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() )
				{
					// For standard type the rows will be thinner to allow for an overlapping feeling
					// Two pixel extra for the row closest to the tab area and one extra pixel
					// for the farthest so that we can grows it size by one pixel when a tab is selected
					tabsAreaHeight = height + verticalMargin*2;
					tabsAreaHeight *= multilineRows.Count;
					tabsAreaHeight += 3;
				}
				else
				{
					tabsAreaHeight *= multilineRows.Count;
				}
			}
		
			return tabsAreaHeight;

		}

		Rectangle CalculateTabRect(Rectangle tabsArea)
		{
			Rectangle rc = Rectangle.Empty;
			if ( tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Bottom )
			{
				if ( tabsFitting == TabsFitting.MultiLine && 
					(tabsStyle == TabsStyle.Standard 
					|| tabsStyle  == TabsStyle.XPTheme 
					|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() )&& multilineRows.Count > 1)
				{
					int multineLineOffset = 0;
					int lastRowOffset = 0;
					if ( tabsLocation == TabsLocation.Bottom )
					{
						if ( IsMultiLineFirstRow() )
							multineLineOffset = 2;
						else if ( IsMultiLineLastRow() )
							lastRowOffset = 1;
						rc = new Rectangle(tabsArea.Left, tabsArea.Top + multineLineOffset, 
							tabsArea.Width, tabsArea.Height - multineLineOffset - lastRowOffset);
					}
					else if ( tabsLocation == TabsLocation.Top )
					{
						if ( IsMultiLineFirstRow() )
							multineLineOffset = 2;
						else if ( IsMultiLineLastRow() )
							lastRowOffset = 1;
						rc = new Rectangle(tabsArea.Left, tabsArea.Top + lastRowOffset, 
							tabsArea.Width, tabsArea.Height - multineLineOffset);
					}
				}
				else
				{
					if (tabsStyle  == TabsStyle.Flat)
						if (tabsLocation == TabsLocation.Top)
							rc = new Rectangle(tabsArea.Left, tabsArea.Top + 5,
								tabsArea.Width + 1, tabsArea.Height - (TAB_AREA_TOP_MARGIN + TAB_AREA_BOTTOM_MARGIN));
						else
							rc = new Rectangle(tabsArea.Left, tabsArea.Top - 1,
								tabsArea.Width + 1, tabsArea.Height - (TAB_AREA_TOP_MARGIN + TAB_AREA_BOTTOM_MARGIN));
					else
					rc = new Rectangle(tabsArea.Left, tabsArea.Top + TAB_AREA_TOP_MARGIN, 
						tabsArea.Width, tabsArea.Height - (TAB_AREA_TOP_MARGIN + TAB_AREA_BOTTOM_MARGIN));
				}
				
			}
			else if ( tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )
			{
				if ( tabsFitting == TabsFitting.MultiLine && 
					(tabsStyle == TabsStyle.Standard || tabsStyle  == TabsStyle.XPTheme
					|| tabsStyle  == TabsStyle.CustomImages || IsOneNoteTabStyle() ) && multilineRows.Count > 1)
				{
					int multineLineOffset = 0;
					int lastRowOffset = 0;
					if ( tabsLocation == TabsLocation.Right )
					{
						if ( IsMultiLineFirstRow() )
							multineLineOffset = 2;
						else if ( IsMultiLineLastRow() )
							lastRowOffset = 1;
						rc = new Rectangle(tabsArea.Left + multineLineOffset, tabsArea.Top, 
							tabsArea.Width - multineLineOffset - lastRowOffset, tabsArea.Height);
					}
					else if ( tabsLocation == TabsLocation.Left )
					{
						if ( IsMultiLineFirstRow() )
							multineLineOffset = 2;
						else if ( IsMultiLineLastRow() )
							lastRowOffset = 1;
						rc = new Rectangle(tabsArea.Left + lastRowOffset, tabsArea.Top, 
							tabsArea.Width - multineLineOffset, tabsArea.Height);
					}
				}
				else
				{
					rc = new Rectangle(tabsArea.Left + TAB_AREA_TOP_MARGIN, tabsArea.Top, 
						tabsArea.Width - (TAB_AREA_TOP_MARGIN + TAB_AREA_BOTTOM_MARGIN), tabsArea.Height);
				}
			}

			// Special case for Windows XP Theme tabs
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled() )
			{
				int xpTopOffset = 0;
				if ( tabsFitting == TabsFitting.MultiLine && !IsMultiLineFirstRow() )
					xpTopOffset = 3;
				if ( tabsLocation == TabsLocation.Top )
				{
					return new Rectangle(rc.Left, rc.Top+TAB_AREA_BOTTOM_MARGIN+1+xpTopOffset, rc.Width, rc.Height);
				}
				else if ( tabsLocation == TabsLocation.Bottom )
				{
					return new Rectangle(rc.Left, rc.Top-(TAB_AREA_BOTTOM_MARGIN+1+xpTopOffset), rc.Width, rc.Height);
				}
				else if ( tabsLocation == TabsLocation.Left )
				{
					return new Rectangle(rc.Left+TAB_AREA_BOTTOM_MARGIN+1+xpTopOffset, 
						rc.Top, rc.Width, rc.Height);
				}
				else if ( tabsLocation == TabsLocation.Right )
				{
					return new Rectangle(rc.Left-(TAB_AREA_BOTTOM_MARGIN+1+xpTopOffset), 
						rc.Top, rc.Width, rc.Height);
				}
			}
			
			return rc;
		}

		int GetUnhiddenTabPageCount()
		{
			int count = 0;
			for ( int i = 0; i < tabPages.Count; i++ )
			{
				TabPageEx page = tabPages[i];
				if ( page.HideTab == false )
					count++;
			}
			
			return count;
		}

		TabPageExCollection GetVisiblePages()
		{
			TabPageExCollection visiblePages = new TabPageExCollection(); 
			for ( int i = 0; i < tabPages.Count; i++ )
			{
				TabPageEx page = tabPages[i];
				if ( page.HideTab == false )
					visiblePages.Add(page);
			}
			
			return visiblePages;
		}

		int GetVisibleIndexAfterIndex(int index)
		{
			for ( int i = index+1; i < tabPages.Count; i++ )
			{
				TabPageEx page = tabPages[i];
				if ( page.HideTab == false )
					return i;
			}

			return -1;
           
		}

		int GetVisibleIndexBeforeIndex(int index)
		{
			for ( int i = index-1; i >= 0; i-- )
			{
				TabPageEx page = tabPages[i];
				if ( page.HideTab == false )
					return i;
			}

			return -1;
		}

		int GetSafeNewSelectedIndex(int index)
		{
			// Set selection to the previous page
			if ( index == (tabPages.Count -1) )
				return index-1;
			else
				return index;
		}
		
		void RemoveChildControlSafely(Control target)
		{
			// Avoid the From Close Button bug
			Button tempButton = null;
			Form parentForm = target.FindForm();

			if (parentForm != null)
			{
				// Create a hidden, temporary button
				tempButton = new Button();
				tempButton.Visible = false;

				// Add this temporary button to the parent form
				parentForm.Controls.Add(tempButton);

				// Must ensure that temp button is the active one
				parentForm.ActiveControl = tempButton;
			}
                
			// Remove our target control
			Controls.Remove(target);

			if (parentForm != null)
			{
				// Remove the temporary button
				tempButton.Dispose();
				parentForm.Controls.Remove(tempButton);
			}
		}

		void MoveSelectedTabRowToFront(int selectedTabIndex)
		{
			int rowIndex = GetRowIndex(selectedTabIndex);
			// No need to do anything if the row is already the first row
			if ( rowIndex == 0 )
				return;
						            		
			TabsRowHelper frontRow = (TabsRowHelper)multilineRows[rowIndex];
			Debug.Assert(frontRow!=null);
			multilineRows.Remove(frontRow);
			// Insert it as the first item
			multilineRows.Insert(0, frontRow);
		}

		void MoveRowToFront(int rowIndex)
		{
			TabsRowHelper frontRow = (TabsRowHelper)multilineRows[rowIndex];
			Debug.Assert(frontRow!=null);
			multilineRows.Remove(frontRow);
			// Insert it as the first item
			multilineRows.Insert(0, frontRow);
		}

		Rectangle GetTabStripArea(Rectangle tabsArea)
		{
			bool noRowSeparators = ( (tabsStyle == TabsStyle.Document || tabsStyle == TabsStyle.Office2003) && 
				tabsFitting == TabsFitting.MultiLine && drawDocumentMultilineSeparators == false && IsSpecialBorder() );
			if ( noRowSeparators )
				return tabsArea;
			
			if ( tabsLocation == TabsLocation.Top )
			{
				return new Rectangle(tabsArea.Left, tabsArea.Top, 
					tabsArea.Width, tabsArea.Height-TAB_AREA_TOP_MARGIN);
			}
			else if ( tabsLocation == TabsLocation.Bottom )
			{
				return new Rectangle(tabsArea.Left, tabsArea.Top+TAB_AREA_TOP_MARGIN, 
					tabsArea.Width, tabsArea.Height-TAB_AREA_TOP_MARGIN);
			}
			else if ( tabsLocation == TabsLocation.Left )
			{
				return new Rectangle(tabsArea.Left, tabsArea.Top, 
					tabsArea.Width-TAB_AREA_TOP_MARGIN, tabsArea.Height);
			}
			else if ( tabsLocation == TabsLocation.Right )
			{
				return new Rectangle(tabsArea.Left+TAB_AREA_TOP_MARGIN, tabsArea.Top, 
					tabsArea.Width-TAB_AREA_TOP_MARGIN, tabsArea.Height);
			}
			
			return Rectangle.Empty;
		}

		void ProcessKeyEvent(Keys key)
		{
			bool selectNewTab = false;
			bool forward = true;
			bool ctrl = (Control.ModifierKeys&Keys.Control) != 0;
			bool tabKey = key == Keys.Tab;
			if ( tabKey )
				tabKey = true;
			bool shift = (Control.ModifierKeys&Keys.Shift) != 0;
            			
			// Swap our tab key for the equivalent of an Arrow key
			if ( key == Keys.Tab && ctrl && shift == false )
			{
				if ( (tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Bottom )  
					&& key == Keys.Tab )
				{
					key = Keys.Right;
				}
				else if ( (tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right)  
					&& ( key == Keys.Tab ) )
				{
					if ( tabsLocation == TabsLocation.Left )
					{
						key = Keys.Up;
					}
					else if ( tabsLocation == TabsLocation.Right )
					{
						key = Keys.Down;
					}
				}
			}
			
			if ( (tabsLocation == TabsLocation.Top || tabsLocation == TabsLocation.Bottom )  
				&& ( key == Keys.Left || key == Keys.Right ) )
			{
				// Set the 
				selectNewTab = true;
				if ( key == Keys.Left )
					forward = false;
			
			}
			else if ( (tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right )  
				&& ( key == Keys.Up || key == Keys.Down ) )
			{
				selectNewTab = true;
				if ( tabsLocation == TabsLocation.Left && key == Keys.Down )
				{
					forward = false;
					if ( horizontalText && leftTabsTop )
						forward = true;
				}
				else if  ( (tabsLocation == TabsLocation.Right 
					|| (tabsLocation == TabsLocation.Left && horizontalText && leftTabsTop)) && key == Keys.Up )
					forward = false;
			}

			int newTab = -1 ;
			if (selectNewTab)
			{
				selectNewTab = false ;

				// Look until an enabled tab is found
				if ( forward )
				{
					for ( int i = selectedTabIndex + 1; i < tabPages.Count; i++ )
					{
						if ( tabPages[i].Enabled )
						{
							selectNewTab = true ;
							newTab = i ;
							break ;
						}
					}
				}
				else
				{
					for ( int i = selectedTabIndex - 1; i > -1; i-- )
					{
						if (tabPages[i].Enabled)
						{
							selectNewTab = true ;
							newTab = i ;
							break ;
						}
					}
				}
			}

			// Move to next tab
			if ( selectNewTab )
			{
				if ( forward )
				{
					if ( (newTab) < tabPages.Count )
						SelectedTabIndex = newTab;

				}
				else
				{
					if ( (newTab) >= 0 )
						SelectedTabIndex = newTab;
				}
			}
			else if ( tabKey && ctrl )
			{
				// If the user is pressing the tab key and the ctrl key
				// then we are going to allow to move between pages in a circular manner
				selectNewTab = false;
				if ( forward && shift == false)
				{
					// Selected the first tab that is enabled
					for ( int i = 0; i < tabPages.Count; i++ )
					{
						if ( tabPages[i].Enabled )
						{
							selectNewTab = true ;
							newTab = i ;

							// This makes sure that if we are in an Scrollable Tabs style
							// that the new tab selected can be brought into view when
							// the code below calls ForcePageVisible
							if ( IsScrollableTabsStyle() && newTab < firstVisiblePageIndex )
							{ 
								forward = false;
							}

							break ;
						}
					}
				}
				else if ( shift )
				{
					// Select the first previous tab available
					for ( int i = selectedTabIndex - 1; i > -1; i-- )
					{
						if (tabPages[i].Enabled)
						{
							selectNewTab = true ;
							newTab = i ;
							break ;
						}
					}

					// If we are in the first page, select
					// the last page to provide for a circular movement
					if ( selectedTabIndex == 0 )
					{
						for ( int i = tabPages.Count - 1; i > -1; i-- )
						{
							if (tabPages[i].Enabled)
							{
								selectNewTab = true ;
								newTab = i ;

								// Make sure last page come into view
								if ( IsScrollableTabsStyle() && newTab > lastVisiblePageIndex )
								{
									ForceRightSidePageVisible(newTab);
								}

								break ;
							}
						}
					}
				}

				// Now select it
				if ( selectNewTab && (newTab < tabPages.Count) )
					SelectedTabIndex = newTab;
			}
			else if ( tabKey && shift && enableExtendedTabKeyNavigation )
			{
				// If using extended tab key navigation
				// then set the focus to the last tab control in the current page
				if ( selectedTabIndex != -1 && SelectedTabIndex < tabPages.Count )
				{
					TabPageEx page = tabPages[selectedTabIndex];
					page.SetFocusToLastChildControl();
				}
			}

			// In case the tab is not fully visible or not visible at all
			if ( selectNewTab && (newTab < tabPages.Count) )
			{
				bool backward = tabKey && ctrl && shift;
				if ( forward && !backward ) 
				{
					ScrollTabs(newTab);
				}
				else
				{
					// Invalidate the control 
					// to get to the newly selected tab if the
					// tab is not currently visible
					if ( newTab < firstVisiblePageIndex )
					{
						ForceLeftSidePageVisible(newTab);
					}
				}
			}
		}

		bool ProcessShortcut(char charCode)
		{
			// Check if any of the tab has that key on its text
			// setup as a shortcut
			int count = tabPages.Count;
			for ( int i = 0; i < count; i++ )
			{
				TabPageEx page = tabPages[i];
				if ( page.Title != null && page.Title != string.Empty )
				{
					string text = page.Title;
					int ampersand = text.IndexOf('&');
					if ( ampersand != -1 && ampersand < text.Length-1)
					{
						char letter = text[ampersand+1];
						string letterString = letter.ToString();
						letterString = letterString.ToUpper();
						string keyString = charCode.ToString();
						keyString = keyString.ToUpper();
						if ( letterString == keyString )
						{
							// Make this page the currently selected tab page
							if ( IsScrollableTabsStyle() )
							{
								// Check if we need to force a tab into view
								if ( i < firstVisiblePageIndex )
								{
									ForceLeftSidePageVisible(i);
								}
								else if ( i > lastVisiblePageIndex )
									ForceRightSidePageVisible(i);
								else
									SelectedTabIndex = i;
							}
							else
							{
								SelectedTabIndex = i;
							}

							// Make sure control is repainted
							Invalidate();
							return true;
						}
					}
				}
			}

			return false;
		}

		void OnShowToolTip(object sender, EventArgs e)
		{
			// Stop our timers
			showToolTipTimer.Stop();
			hideToolTipTimer.Stop();
			
			if ( toolTipTargetTabIndex != -1 
				&& toolTipTargetTabIndex < tabPages.Count && tooltipActive == false
				&& indexThatFiredTimer == toolTipTargetTabIndex )
			{
				tooltipActive = true;
				TabPageEx page = tabPages[toolTipTargetTabIndex];
				Point textPos = page.TextPosition;
				Point pos = new Point(textPos.X+1, textPos.Y-2);
				tooltip.DisplayTrackingToolTip(this, pos);

				// Now start the hide tooltip timer
				hideToolTipTimer.Start();
			}
            
		}

		void OnHideToolTip(object sender, EventArgs e)
		{
			// Stop our timers
			showToolTipTimer.Stop();
			hideToolTipTimer.Stop();
			
			if ( tooltipActive )
			{
				// Flag that tooltip is not up anymore
				tooltipActive = false;
				tooltip.HideTrackingToolTip(this);
			}
		}

		bool IsFocusGainedThroughTabKey(KeyEventArgs e)
		{
			bool result = false;
			bool tabKey = e.KeyCode == Keys.Tab;
			if ( Focused && tabKey && (e.Shift == false||forceTabKeyFocus)  && e.Control == false && e.Alt == false )
			{
				forceTabKeyFocus = false;
				return true;
			}
			
			return result;
		}

		void DoPerformClick(TabPageEx tabPage)
		{
			// Send a mouse message with using the center of the tab page rectangle to simulate
			// a mouse click
			Rectangle rc = tabPage.TabRectangle;
			Point pt = new Point(rc.Left + rc.Width/2, rc.Top + rc.Height/2);
			WindowsAPI.SendMessage(Handle, (int)Msg.WM_LBUTTONDOWN, 0, WindowsAPI.MAKELPARAM(pt.X, pt.Y));
		}

		void UpdateSelectedTabPageBackground()
		{
			if ( tabsStyle == TabsStyle.XPTheme && WindowsAPI.IsWindowsXPThemeEnabled()
				&& selectedTabIndex != -1 && selectedTabIndex < tabPages.Count && drawXPThemeTabPagesBackground)
			{
				// Invalidate the currently selected page so that the XP Theme background
				// gets painted
				TabPageEx page = tabPages[selectedTabIndex];
				Debug.Assert(page!=null);
				page.Invalidate();
			}
		}

		internal void ForceLeftSidePageVisible(int index)
		{
			// This method only makes sense to call
			// when using a tab style that have the ability to allow
			// the user scroll the tabs with the keyboard or arrows
			Debug.Assert(IsScrollableTabsStyle());

			if ( index < tabPages.Count )
			{
				firstVisiblePageIndex = index;
				SelectedTabIndex = index;
			}
		}

		internal void ForceRightSidePageVisible(int index)
		{
			// This method only makes sense to call
			// when using a tab style that have the ability to allow
			// the user scroll the tabs with the keyboard or arrows
			Debug.Assert(IsScrollableTabsStyle());

			// Make sure we are not out of bounds
			Debug.Assert(index > 0 && index < tabPages.Count);
			// Make sure the last page is visible to the user
			lastVisiblePageIndex = index;

			// Now find where the left side of the tab that is going to become
			// visible would be
			int targetPageWidth = -1;
			using ( Graphics g = Graphics.FromHwnd(Handle) )
				targetPageWidth = GetTabWidth(g, tabPages[index]);
			int leftArrowXPos = LeftArrowXPos();
			int left = leftArrowXPos - targetPageWidth - 1;

			// The xPos of the first page
			int xPos = tabPages[firstVisiblePageIndex].Left;
			int width = 0;
			for ( int i = index - 1; i >= 0; i-- )
			{
				TabPageEx tp = tabPages[i];
				int currentPageWidth = tp.TabRectangle.Width;
				width += currentPageWidth;
				if ( left - width < xPos )
				{
					firstVisiblePageIndex = i+1;
					SelectedTabIndex = index;
					break;
				}
			}
		}

		internal int GetSafeNewSelectedIndexAfterHidingTab(int index)
		{
			TabPageEx previous = null;
			if ( index-1 >= 0 )
				previous = tabPages[index-1];
			
			TabPageEx next = null;
			if ( index+1 < tabPages.Count )
				next = tabPages[index+1];
            
			// Set selection to the previous page
			if ( index - 1 >= 0 && previous.HideTab == false )
				return index - 1;
			else if ( index+1 < tabPages.Count && next.HideTab == false )
				return index+1;
			else
				return 0;
		}

		bool IsHorizontalText()
		{
			if ( horizontalText && (tabsLocation == TabsLocation.Left || tabsLocation == TabsLocation.Right) )
				return true;
			return false;
		}

		bool IsOneNoteTabStyle()
		{
			if ( tabsStyle == TabsStyle.OneNote || tabsStyle == TabsStyle.OneNoteLuna || tabsStyle == TabsStyle.OneNoteSystem )
				return true;

			return false;
		}

		internal void UpdateMultilineDimensions()
		{
			// Force an update of the rows array since
			// the size of the tabs change depending on
			// the tab style and we are caching the tab sizes
			// which need to be update
			needRowTableCalculation = true;
			CalculateRowsTable(null);
			UpdateTabPagesBounds();
		}

		internal bool  IsScrollableTabsStyle()
		{
			return tabsFitting == TabsFitting.ShowArrows || tabsFitting == TabsFitting.FixedWidth;
		}

		internal bool NeedsForceLeftPageVisibility(int index)
		{
			Debug.Assert(IsScrollableTabsStyle());
			Debug.Assert(index >= 0 && index < tabPages.Count);
			return index < firstVisiblePageIndex;
		}

		internal bool NeedsForceRightPageVisibility(int index)
		{
			Debug.Assert(IsScrollableTabsStyle());
			Debug.Assert(index > 0 && index < tabPages.Count);
			int rightPos = tabPages[lastVisiblePageIndex].TabRectangle.Right;
			int leftArrowXPos = LeftArrowXPos();
			bool fullyVisible = rightPos < leftArrowXPos;

			return index > lastVisiblePageIndex 
				|| ( index == lastVisiblePageIndex && !fullyVisible ); 
		}

		internal void PassMsg(ref Message m)
		{
			// To be called from the designer 
			WndProc(ref m);
		}

		#endregion
        	
	}
}
#endif
