using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionUnitTesting;
using System.Reflection;
using System.Collections.Generic;

[TestClass]
public class SolutionUnitTests
{
    [TestMethod]
    public void AssemblyShouldExist()
    {
        GetAssembly();
    }

    private static Assembly GetAssembly()
    {
        return ReflectionAssert.AssemblyExists("Day0WeightedMean.exe");
    }

    [TestMethod]
    public void ClassShouldExist()
    {
        GetClass();
    }

    private static Type GetClass()
    {
        return GetAssembly().TypeExists("Solution");
    }

    [TestMethod]
    public void MethodShouldExist()
    {
        GetMethod();
    }

    private static MethodInfo GetMethod()
    {
        return GetClass().MethodExists(
            "WeightedMean",
            shouldBeStatic: true,
            shouldReturnType: typeof(string),
            parameterTypesAndNames: new List<Tuple<Type, string>> {
                Tuple.Create(typeof(int[]), "values"),
                Tuple.Create(typeof(int[]), "weights") });
    }

    //Sample Input
    //5
    //10 40 30 50 20
    //1 2 3 4 5
    //Sample Output
    //32.0
    [TestMethod]
    public void WeightedMean104030502012345ShouldBe320()
    {
        var parameters = new object[] { new int[] { 10, 40, 30, 50, 20 }, new int[] { 1, 2, 3, 4, 5 } };
        var expectedResult = "32.0";
        GetMethod().TestMethod(null, parameters, expectedResult);
    }
}

