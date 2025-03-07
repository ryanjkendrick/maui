﻿using System;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Controls.ControlGallery
{
	public class ClickGestureGalleryPage : ContentPage
	{
		Command clickCommand;
		BoxView changeColorBoxView;

		public ClickGestureGalleryPage()
		{
			clickCommand = new Command<Color>(HandleClickCommand);
			var vertical = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Spacing = 40
			};

			var horizontal = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Spacing = 20,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			vertical.Children.Add(horizontal);

			var singleClickLabel = new Label
			{
				Text = "Click me!",
				BackgroundColor = Colors.PaleGreen
			};
			var singleClickGesture = new ClickGestureRecognizer
			{
				Command = clickCommand,
				CommandParameter = Colors.PaleGreen,
				NumberOfClicksRequired = 1,
				Buttons = ButtonsMask.Primary
			};
			singleClickLabel.GestureRecognizers.Add(singleClickGesture);
			horizontal.Children.Add(singleClickLabel);

			var doubleClickLabel = new Label
			{
				Text = "Double click me!!",
				BackgroundColor = Colors.Aqua
			};
			var doubleClickGesture = new ClickGestureRecognizer
			{
				Command = clickCommand,
				CommandParameter = Colors.Aqua,
				NumberOfClicksRequired = 2,
				Buttons = ButtonsMask.Primary
			};
			doubleClickLabel.GestureRecognizers.Add(doubleClickGesture);
			horizontal.Children.Add(doubleClickLabel);

			var tripleClicklabel = new Label
			{
				Text = "Triple click me!!!",
				BackgroundColor = Colors.Olive
			};
			var tripleClickGesture = new ClickGestureRecognizer
			{
				Command = clickCommand,
				CommandParameter = Colors.Olive,
				NumberOfClicksRequired = 3,
				Buttons = ButtonsMask.Primary
			};
			tripleClicklabel.GestureRecognizers.Add(tripleClickGesture);
			horizontal.Children.Add(tripleClicklabel);

			var rightClickLabel = new Label
			{
				Text = "Right click me¡",
				BackgroundColor = Colors.Coral
			};
			var rigthClickGesture = new ClickGestureRecognizer
			{
				Command = clickCommand,
				CommandParameter = Colors.Coral,
				NumberOfClicksRequired = 1,
				Buttons = ButtonsMask.Secondary
			};
			rightClickLabel.GestureRecognizers.Add(rigthClickGesture);
			horizontal.Children.Add(rightClickLabel);

			var doubleRightClickLabel = new Label
			{
				Text = "Double right click me¡¡",
				BackgroundColor = Colors.Gold
			};
			var doubleRigthClickGesture = new ClickGestureRecognizer
			{
				Command = clickCommand,
				CommandParameter = Colors.Gold,
				NumberOfClicksRequired = 2,
				Buttons = ButtonsMask.Secondary
			};
			doubleRightClickLabel.GestureRecognizers.Add(doubleRigthClickGesture);
			horizontal.Children.Add(doubleRightClickLabel);


			changeColorBoxView = new BoxView
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200,
				HeightRequest = 50
			};
			vertical.Children.Add(changeColorBoxView);
			Content = vertical;
		}

		void HandleClickCommand(Color backgroundColor)
		{
			changeColorBoxView.BackgroundColor = backgroundColor;
		}
	}
}
