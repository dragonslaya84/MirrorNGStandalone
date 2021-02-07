using Mirror.Weaver;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Weaver weaver = new Weaver(null);
            weaver.Execute(args[0]);
        }
    }
}
