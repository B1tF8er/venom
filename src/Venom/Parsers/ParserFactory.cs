namespace Venom
{
    using System;
    using System.Collections.Generic;

    internal static class ParserFactory
    {
        private static readonly IDictionary<Type, IParser> parsers;
        
        static ParserFactory()
        {
            parsers = new Dictionary<Type, IParser>
            {
                { Type.MetalInjection, new MetalInjectionParser() },
                { Type.MetalSucks, new MetalSucksParser() },
            };
        }

        internal static IParser GetParser(Type type)
        {
            parsers.TryGetValue(type, out var parser);
            
            return parser;
        }
    }
}
