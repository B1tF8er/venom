namespace Venom
{
    using System;

    class Symbiote
    {
        static void Main(string[] args)
        {
            try
            {
                App.Start();
            }
            catch (Exception ex)
            {
                Environment.FailFast($"{Error.Unexpected}", ex);
            }
        }
    }
}
