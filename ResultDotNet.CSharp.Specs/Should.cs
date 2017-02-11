using NUnit.Framework;
namespace ResultDotNet.CSharp.Specs {
  public static class ShouldExtensions {
    public static void ShouldBe<T>(this T actual, T expected) {
      Assert.AreEqual(expected, actual);
    }

    public static void ShouldNotBe<T>(this T actual, T expected) {
      Assert.AreNotEqual(expected, actual);
    }
  }
}