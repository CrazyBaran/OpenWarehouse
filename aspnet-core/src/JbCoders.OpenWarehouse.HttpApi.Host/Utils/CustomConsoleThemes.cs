using System;
using System.Collections.Generic;
using Serilog.Sinks.SystemConsole.Themes;

namespace JbCoders.OpenWarehouse.Utils;

public static class CustomConsoleThemes
{
    public static SystemConsoleTheme ColoredForRider { get; } = new SystemConsoleTheme(
        new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
        {
            [ConsoleThemeStyle.Text] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Black},
            [ConsoleThemeStyle.SecondaryText] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Green},
            [ConsoleThemeStyle.TertiaryText] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Magenta},
            [ConsoleThemeStyle.Invalid] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Yellow},
            [ConsoleThemeStyle.Null] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Gray},
            [ConsoleThemeStyle.Name] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Gray},
            [ConsoleThemeStyle.String] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Gray},
            [ConsoleThemeStyle.Number] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Gray},
            [ConsoleThemeStyle.Boolean] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Gray},
            [ConsoleThemeStyle.Scalar] = new SystemConsoleThemeStyle {Foreground = ConsoleColor.Gray},
            [ConsoleThemeStyle.LevelVerbose] = new SystemConsoleThemeStyle
                {Foreground = ConsoleColor.White, Background = ConsoleColor.DarkGray},
            [ConsoleThemeStyle.LevelDebug] = new SystemConsoleThemeStyle
                {Foreground = ConsoleColor.White, Background = ConsoleColor.Gray},
            [ConsoleThemeStyle.LevelInformation] = new SystemConsoleThemeStyle
                {Foreground = ConsoleColor.Black, Background = ConsoleColor.Blue},
            [ConsoleThemeStyle.LevelWarning] = new SystemConsoleThemeStyle
                {Foreground = ConsoleColor.Black, Background = ConsoleColor.Yellow},
            [ConsoleThemeStyle.LevelError] = new SystemConsoleThemeStyle
                {Foreground = ConsoleColor.Black, Background = ConsoleColor.Red},
            [ConsoleThemeStyle.LevelFatal] = new SystemConsoleThemeStyle
                {Foreground = ConsoleColor.Black, Background = ConsoleColor.Red},
        });
}