namespace Venom
{
    using System.Collections;
    using System.Collections.Generic;
    using static Constants;

    internal class SiteEnumerator : IEnumerable<Site>
    {
        public IEnumerator<Site> GetEnumerator()
        {
            yield return new Site(Type.MetalInjection, MetalInjectionConstants.Paths);
            yield return new Site(Type.MetalSucks, MetalSucksConstants.Paths);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}