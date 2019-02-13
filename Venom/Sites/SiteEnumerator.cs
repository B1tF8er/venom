namespace Venom
{
    using System.Collections.Generic;
    using static Constants;

    internal static class SiteEnumerator
    {
        internal static IEnumerable<Site> Sites()
        {
            yield return new Site(Type.MetalInjection, MetalInjectionConstants.Paths);
            yield return new Site(Type.MetalSucks, MetalSucksConstants.Paths);
        }
    }
}
