using NetArchTest.Rules;

var result = Types.InCurrentDomain()
                  .That()
                  .HaveNameStartingWith("MyClass")
                  .Should()
                  .OnlyHaveDependenciesOn("System", "NetArchTestLabs")
                  .GetResult();

Console.WriteLine(result.IsSuccessful); // should be true
Console.WriteLine(string.Join(",", result.FailingTypeNames));

namespace NetArchTestLabs
{
    public static class MyClass
    {
        private static readonly MyEnum[] _values = { MyEnum.A, MyEnum.B, MyEnum.C };
    }

    public enum MyEnum
    {
        D,
        A,
        B,
        C,
        Z
    }
}