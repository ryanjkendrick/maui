﻿using System;
using System.Linq;
using Microsoft.Maui.Platform;
using PlatformView = UIKit.UIView;

namespace Microsoft.Maui.Handlers
{
	public partial class BorderHandler : ViewHandler<IBorderView, ContentView>
	{
		protected override ContentView CreatePlatformView()
		{
			_ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a {nameof(ContentView)}");
			_ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

			return new ContentView
			{
				CrossPlatformLayout = VirtualView
			};
		}

		protected override void ConnectHandler(ContentView platformView)
		{
			base.ConnectHandler(platformView);
		}

		protected override void DisconnectHandler(ContentView platformView)
		{
			base.DisconnectHandler(platformView);
		}

		public override void SetVirtualView(IView view)
		{
			base.SetVirtualView(view);
			_ = PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");
			_ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} should have been set by base class.");

			PlatformView.View = view;
			PlatformView.CrossPlatformLayout = VirtualView;
		}

		static void UpdateContent(IBorderHandler handler)
		{
			_ = handler.PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");
			_ = handler.VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} should have been set by base class.");
			_ = handler.MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} should have been set by base class.");

			// Cleanup the old view when reused
			var oldChildren = handler.PlatformView.Subviews.ToList();
			oldChildren.ForEach(x => x.RemoveFromSuperview());

			if (handler.VirtualView.PresentedContent is IView view)
			{
				handler.PlatformView.AddSubview(view.ToPlatform(handler.MauiContext));
				handler.PlatformView.ChildMaskLayer = null;
			}
		}

		public static void MapContent(IBorderHandler handler, IBorderView border)
		{
			UpdateContent(handler);
		}
	}
}
