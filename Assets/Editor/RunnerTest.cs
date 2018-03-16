using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RunnerTest
{

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void RunnerAddCoroutine()
    {

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        CandyCoded.Runner runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.AreEqual(1, runner.coroutines.Count);

    }

    [Test]
    public void RunnerFailsToAddDuplicateCoroutine()
    {

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        CandyCoded.Runner runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.Throws<ArgumentException>(() => runner.AddCoroutine("TestCoroutine", TestCoroutine()));

    }

    [Test]
    public void RunnerRemoveCoroutine()
    {

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        CandyCoded.Runner runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.AreEqual(1, runner.coroutines.Count);

        runner.RemoveCoroutine("TestCoroutine");

        Assert.AreEqual(0, runner.coroutines.Count);

    }

    [Test]
    public void RunnerRemoveAllCoroutines()
    {

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        CandyCoded.Runner runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine1", TestCoroutine());
        runner.AddCoroutine("TestCoroutine2", TestCoroutine());
        runner.AddCoroutine("TestCoroutine3", TestCoroutine());

        Assert.AreEqual(3, runner.coroutines.Count);

        runner.RemoveAllCoroutines();

        Assert.AreEqual(0, runner.coroutines.Count);

    }

    IEnumerator TestCoroutine()
    {

        yield return new WaitForSeconds(1f);

    }

}
