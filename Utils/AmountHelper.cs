namespace Zoo.Utils;

public static class AmountHelper
{
    public static bool IsConsideredMany(int amount)
    {
        return amount >= 4;
    }
}