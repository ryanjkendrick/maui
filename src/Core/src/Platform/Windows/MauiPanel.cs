﻿#nullable enable
using System;
using Microsoft.Maui.Graphics;
using Microsoft.UI.Xaml.Controls;
using WSize = global::Windows.Foundation.Size;

namespace Microsoft.Maui.Platform
{
	public abstract class MauiPanel : Panel, ICrossPlatformLayoutBacking
	{
		public ICrossPlatformLayout? CrossPlatformLayout
		{
			get; set;
		}

		Size CrossPlatformMeasure(double widthConstraint, double heightConstraint)
		{
			return CrossPlatformLayout?.CrossPlatformMeasure(widthConstraint, heightConstraint) ?? Size.Zero;
		}

		Size CrossPlatformArrange(Rect bounds)
		{
			return CrossPlatformLayout?.CrossPlatformArrange(bounds) ?? Size.Zero;
		}

		// TODO: Possibly reconcile this code with ViewHandlerExtensions.MeasureVirtualView
		// If you make changes here please review if those changes should also
		// apply to ViewHandlerExtensions.MeasureVirtualView
		protected override WSize MeasureOverride(global::Windows.Foundation.Size availableSize)
		{
			if (CrossPlatformMeasure == null || (availableSize.Width * availableSize.Height == 0))
			{
				return base.MeasureOverride(availableSize);
			}

			var measure = CrossPlatformMeasure(availableSize.Width, availableSize.Height);

			return measure.ToPlatform();
		}

		protected override WSize ArrangeOverride(WSize finalSize)
		{
			if (CrossPlatformArrange == null)
			{
				return base.ArrangeOverride(finalSize);
			}

			var width = finalSize.Width;
			var height = finalSize.Height;

			var actual = CrossPlatformArrange(new Rect(0, 0, width, height));

			return actual.ToPlatform();
		}
	}
}
