namespace MemoryLib.Utils
{
    public class EnumUtil<TEnum> where TEnum : struct, System.Enum
    {
        public IEnumerable<TEnum> Values => Enum.GetValues<TEnum>();
    }
}
