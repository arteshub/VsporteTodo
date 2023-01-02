using NUnit.Framework;
using VSporte.Task.Solution;
using VSporte.Task.Solution.Models;
using VSporte.Task.Test.Providers;

namespace VSporte.Task.Test;

public class Tests
{
    private Fingerprint fingerprint = null!;
    private DuplicateResolver duplicateResolver = new();

    [SetUp]
    public void Setup()
    {
        var fingerprintProvider = new FingerprintProvider();
        fingerprint = fingerprintProvider.Get();
    }

    [Test]
    //<summary>Задание 1.1</summary>
    public void Task1_1()
    {
        throw new NotImplementedException();
    }

    [Test]
    //<summary>Задание 1.2</summary>
    public void Task1_2()
    {
        throw new NotImplementedException();
    }

    [Test]
    //<summary>Задание 1.3</summary>
    public void Task1_3()
    {
        throw new NotImplementedException();
    }
}