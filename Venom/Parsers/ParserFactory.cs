namespace Venom
{
    using System;

    internal static class ParserFactory
    {
        internal static IParser GetParser(Type type)
        {
            switch (type)
            {
                case Type.MetalInjection:
                    return GetMetalInjectionParser();
                case Type.MetalSucks:
                    return GetMetalSucksParser();
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type));
            }
        }

        private static IParser GetMetalInjectionParser() => new MetalInjectionParser();

        private static IParser GetMetalSucksParser() => new MetalSucksParser();
    }
}
