﻿using ActiproSoftware.UI.Avalonia.Themes;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Gambler.Bot.Common.Games;
using System;
using System.Globalization;

namespace Gambler.Bot.Converters
{
    public class BoolToColourConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Bet bet)
            {
                string resource = bet.IsWin ? ThemeResourceKind.ControlBackgroundBrushSoftSuccess.ToResourceKey() : ThemeResourceKind.ControlBackgroundBrushSoftDanger.ToResourceKey();
                if (Application.Current.TryFindResource(resource,App.Current.ActualThemeVariant, out object brush))
                {
                    return (Brush)brush;
                }
            }

            return Brushes.Transparent;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
