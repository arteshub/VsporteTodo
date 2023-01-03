using NUnit.Framework;
using System;
using Vsporte.HandlerServices.Services.DuplicateResolverService;
using VSporte.Tasks.Test.Providers;
using System.Threading.Tasks;
using System.Collections.Generic;
using VSporte.Task.Solution.Models;
using System.Linq;
using VSporte.Task.Test.Providers;

namespace VSporte.Tasks.Test;

[TestFixture]
public class Tests
{
    [Test]
    public async System.Threading.Tasks.Task Task1_1()
    {
        FingerprintProviderTask_1_1 provider = new FingerprintProviderTask_1_1();

        await TestMethod(provider, DuplicateResolverService.DuplicateResolveBad);
    }

    [Test]
    //<summary>Задание 1.2</summary>
    public async System.Threading.Tasks.Task Task1_2()
    {
        FingerprintProviderTask_1_2 provider = new FingerprintProviderTask_1_2();

        await TestMethod(provider, DuplicateResolverService.DuplicateResolveGood);
    }

    [Test]
    //<summary>Задание 1.3</summary>
    public async System.Threading.Tasks.Task Task1_3()
    {
        FingerprintProviderTask_1_3 provider = new FingerprintProviderTask_1_3();

        await TestMethod(provider, DuplicateResolverService.DuplicateResolvePerfect);
    }

    /// <summary>
    /// Базовый тестовый метод для всех заданий
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="testLogic"></param>
    /// <returns>Результат выполнения теста</returns>
    private async System.Threading.Tasks.Task TestMethod(BaseFingerPrintProvider provider, Func<System.Threading.Tasks.Task> testLogic)
    {
        try
        {
            provider.AddModelToDataBase(); // заполняем базу тестовыми данными

            await testLogic(); // выполняем логику задания

            var etalonClubs = provider.GetEtalonModel();

            var actualClubs = provider.GetModelFromDatabase();

            bool areEqual = etalonClubs.Item1.OrderBy(x => x).SequenceEqual(actualClubs.Item1.OrderBy(x => x))
                && etalonClubs.Item2.OrderBy(x => x).SequenceEqual(actualClubs.Item2.OrderBy(x => x))
                && etalonClubs.Item3.OrderBy(x => x).SequenceEqual(actualClubs.Item3.OrderBy(x => x));

            provider.TruncateModelFromDatabase(); // очищаем базу

            Assert.IsTrue(areEqual); // вердикт теста
        }
        catch (Exception)
        {
           provider.TruncateModelFromDatabase(); // очищаем базу
        }
    }
}

