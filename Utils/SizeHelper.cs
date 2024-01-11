using Zoo.Enums;

namespace Zoo.Utils;

public static class SizeHelper
{
    public static Size ToEnum(string size)
    {
        var enumeratedSize = size switch
        {
            "Small" => Size.Small,
            "Medium" => Size.Medium,
            "Large" => Size.Large,
            "Huge" => Size.Huge,
            _ => throw new ArgumentException("Invalid size provided: " + size)
        };

        return enumeratedSize;
    }
    
    public static string ToString(Size size)
    {
        return Enum.GetName(typeof(Size), size);
    }
    
    public static bool IsConsideredBig(Size size)
    {
        return size is Size.Large or Size.Huge;
    }
}