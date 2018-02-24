﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CustomExtensionsTest
{

    [Test]
    public void LayerMaskContains()
    {

        LayerMask layerMask = ~0;

        Assert.IsTrue(layerMask.Contains(LayerMask.NameToLayer("Default")));
        Assert.IsTrue(layerMask.Contains(1));
        Assert.IsTrue(layerMask.Contains(0 | 1));

        layerMask = 0;

        Assert.IsFalse(layerMask.Contains(LayerMask.NameToLayer("UI")));
        Assert.IsFalse(layerMask.Contains(1));
        Assert.IsFalse(layerMask.Contains(0 | 1));

    }

    [Test]
    public void AnimationCurveReplaceKey()
    {

        AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        Keyframe[] keys = animationCurve.keys;

        Assert.AreEqual(keys[0].time, 0);
        Assert.AreEqual(keys[0].value, 0);

        Assert.AreEqual(keys[1].time, 1);
        Assert.AreEqual(keys[1].value, 1);

        animationCurve.ReplaceKey(1, new Keyframe(5, 10));

        keys = animationCurve.keys;

        Assert.AreEqual(keys[1].time, 5);
        Assert.AreEqual(keys[1].value, 10);

    }

    [Test]
    public void ListShuffle()
    {

        List<int> numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreNotEqual(numberRange.Shuffle(), numberRange);

    }

    [Test]
    public void ListShuffleWithoutChangingReference()
    {

        List<int> numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        numberRange.Shuffle();

        for (int i = 0; i < 10; i += 1)
        {
            Assert.AreEqual(numberRange[i], i);
        }

    }

}