using System.Diagnostics.CodeAnalysis;

namespace MfTui.Core;

public struct Color(byte r, byte g, byte b)
{
    public static readonly Color Black   = new(0,   0,   0);
    public static readonly Color White   = new(255, 255, 255);
    public static readonly Color Red     = new(197, 15,  31);
    public static readonly Color Green   = new(19,  161, 14);
    public static readonly Color Blue    = new(0,   0,   238);
    public static readonly Color Yellow  = new(193, 156, 0);
    public static readonly Color Cyan    = new(58,  150, 221);
    public static readonly Color Magenta = new(136, 23,  152);
    public static readonly Color Gray    = new(118, 118, 118);
    public static readonly Color DarkGray= new(59,  59,  59);
    public static readonly Color Default = new(0,   0,   0) { IsDefault = true };
    public byte R { get; set; } = r;
    public byte G { get; set; } = g;
    public byte B { get; set; } = b;

    public bool IsDefault { get; private init; }
    public string ToFg() => IsDefault ? "\e[39m" : $"\e[38;2;{R};{G};{B}m";
    public string ToBg() => IsDefault ? "\e[49m" : $"\e[48;2;{R};{G};{B}m";

    public bool Equals(Color other) => R == other.R && G == other.G && B == other.B && IsDefault == other.IsDefault;
    public override bool Equals(object? obj) => obj is Color c && Equals(c);
    public override int GetHashCode() => HashCode.Combine(R, G, B, IsDefault);
    public static bool operator ==(Color a, Color b) => a.Equals(b);
    public static bool operator !=(Color a, Color b) => !a.Equals(b);
}