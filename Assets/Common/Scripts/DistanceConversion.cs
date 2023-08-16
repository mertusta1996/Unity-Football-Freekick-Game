public abstract class DistanceConversion
{
    public static string Distance(float meter)
    {
        string result;
        if (meter < 1000f)
        {
            result = meter.ToString("F1") + "m";
        }
        else
        {
            var kilometer = meter / 1000f;
            result = kilometer.ToString("F3") + "km";
        }

        return result;
    }
}
