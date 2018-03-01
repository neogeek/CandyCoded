﻿using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    public static class Animate
    {

        public delegate void AnimationFunc(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null);

        public static CandyCoded.AnimationRunner GetAnimationRunner(GameObject gameObject)
        {

            CandyCoded.AnimationRunner animationRunner = gameObject.GetComponent<CandyCoded.AnimationRunner>();

            if (animationRunner == null)
            {

                animationRunner = gameObject.AddComponent<CandyCoded.AnimationRunner>();

            }

            return animationRunner;

        }

        public static CandyCoded.AnimationData GetAnimationData(GameObject gameObject)
        {

            CandyCoded.AnimationData animationData = gameObject.GetComponent<CandyCoded.AnimationData>();

            if (animationData == null)
            {

                animationData = gameObject.AddComponent<CandyCoded.AnimationData>();

            }

            return animationData;

        }

        public static IEnumerator Loop(GameObject gameObject, Vector3AnimationCurve animationCurve, AnimationFunc animationFunc)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            AnimationRunner runner = GetAnimationRunner(gameObject);

            string animationFuncName = animationFunc.Method.Name;

            float elapsedTime = 0;
            float maxTime = animationCurve.maxTime;

            while (animationCurve.isLooping || elapsedTime < maxTime)
            {

                animationFunc(gameObject, animationCurve, elapsedTime, animationData);

                elapsedTime += Time.deltaTime;

                yield return null;

            }

            runner.coroutines.Remove(animationFuncName);

        }

        public static Coroutine StartCoroutine(GameObject gameObject, Vector3AnimationCurve animationCurve, AnimationFunc animationFunc)
        {

            AnimationRunner runner = GetAnimationRunner(gameObject);

            IEnumerator routine = Loop(gameObject, animationCurve, animationFunc);

            string animationFuncName = animationFunc.Method.Name;

            if (runner.coroutines.ContainsKey(animationFuncName))
            {

                runner.StopCoroutine(runner.coroutines[animationFuncName]);

                runner.coroutines.Remove(animationFuncName);

            }

            runner.coroutines.Add(animationFuncName, runner.StartCoroutine(routine));

            return runner.coroutines[animationFuncName];

        }

        public static Coroutine Position(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, animationCurve, CandyCoded.Animate.Position);

        }

        public static void Position(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            gameObject.transform.localPosition = animationCurve.Evaluate(deltaTime);

        }

        public static Coroutine PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, animationCurve, CandyCoded.Animate.PositionRelative);

        }

        public static void PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localPosition = animationData.transformData.position + animationCurve.Evaluate(deltaTime);

        }

        public static void MoveTo(GameObject gameObject, Vector3 newPosition, float duration)
        {

            Vector3AnimationCurve animationCurve = new Vector3AnimationCurve();

            Vector3 currentPosition = gameObject.transform.position;

            animationCurve.x = AnimationCurve.Linear(0, currentPosition.x, duration, newPosition.x);
            animationCurve.y = AnimationCurve.Linear(0, currentPosition.y, duration, newPosition.y);
            animationCurve.z = AnimationCurve.Linear(0, currentPosition.z, duration, newPosition.z);

            Position(gameObject, animationCurve);

        }

        public static Coroutine Rotation(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, animationCurve, CandyCoded.Animate.Rotation);

        }

        public static void Rotation(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            gameObject.transform.localRotation = Quaternion.Euler(animationCurve.Evaluate(deltaTime));

        }

        public static Coroutine Scale(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, animationCurve, CandyCoded.Animate.Scale);

        }

        public static void Scale(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            gameObject.transform.localScale = animationCurve.Evaluate(deltaTime);

        }

        public static Coroutine ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, animationCurve, CandyCoded.Animate.ScaleRelative);

        }

        public static void ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localScale = animationData.transformData.scale + animationCurve.Evaluate(deltaTime);

        }

    }

}
