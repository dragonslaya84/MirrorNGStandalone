namespace Mirror.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Weaver.Weaver weaver = new Weaver.Weaver(null);
            weaver.Execute();

            StandaloneNG mirror = new StandaloneNG();

            TestComponent comp = new TestComponent(mirror);

            while (true)
            {
                mirror.Update();
                comp.Update();
            }
        }
    }
}