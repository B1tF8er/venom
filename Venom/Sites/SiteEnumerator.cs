namespace Venom
{
    using System.Collections;
    using System.Collections.Generic;
    using static Constants;

    internal class SiteEnumerator : IEnumerable<Site>
    {
        public IEnumerator<Site> GetEnumerator()
        {
            yield return new Site(Type.MetalInjection, MetalInjection.Paths);
            yield return new Site(Type.MetalSucks, MetalSucks.Paths);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
