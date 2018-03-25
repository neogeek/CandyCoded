using System.Collections.Generic;
using UnityEngine;

public static class CustomExtensions
{

    /// <summary>
    /// Returns a reference to an existing component or a new component if it didn't already exist.
    /// </summary>
    /// <returns><typeparamref name="T"/>></returns>
    public static T AddOrGetComponent<T>(this GameObject gameObject) where T : Component
    {

        T component = gameObject.GetComponent<T>();

        if (component == null)
        {

            component = gameObject.AddComponent<T>();

        }

        return component;

    }

    /// <summary>
    /// Tests LayerMask for the supplied Layer name.
    /// </summary>
    /// <param name="layerName">Layer name to compare against layerMask.</param>
    /// <returns>bool</returns>
    public static bool Contains(this LayerMask layerMask, string layerName)
    {

        return layerMask.Contains(LayerMask.NameToLayer(layerName));

    }

    /// <summary>
    /// Tests LayerMask for the supplied Layer int.
    /// </summary>
    /// <param name="layerInt">Layer number to compare against layerMask.</param>
    /// <returns>bool</returns>
    public static bool Contains(this LayerMask layerMask, int layerInt)
    {

        return ((int)layerMask).Contains(1 << layerInt);

    }

    /// <summary>
    /// Is value in mask?
    /// </summary>
    /// <param name="value">Value to compare against mask.</param>
    /// <returns>bool</returns>
    public static bool Contains(this int mask, int value)
    {

        return mask == (mask | value);

    }

    /// <summary>
    /// Edit the value of a keyframe in an AnimationCurve leaving the time and curve untouched.
    /// </summary>
    /// <param name="key">Key of keyframe to modify.</param>
    /// <param name="value">Value to update keyframe with.</param>
    /// <returns>void</returns>
    public static void EditKeyframeValue(this AnimationCurve animationCurve, int key, float value)
    {

        Keyframe[] keys = animationCurve.keys;

        keys[key].value = value;

        animationCurve.keys = keys;

    }

    /// <summary>
    /// Edit the values of the corresponding keyframes in a Vector3AnimationCurve leaving the time and curve of each keyframe untouched.
    /// </summary>
    /// <param name="key">Key of each keyframe to modify.</param>
    /// <param name="vector">Vector to update each corresponding keyframe with.</param>
    /// <returns>void</returns>
    public static void EditKeyframeValue(this CandyCoded.Vector3AnimationCurve animationCurve, int key, Vector3 vector)
    {

        animationCurve.x.EditKeyframeValue(key, vector.x);
        animationCurve.y.EditKeyframeValue(key, vector.y);
        animationCurve.z.EditKeyframeValue(key, vector.z);

    }

    /// <summary>
    /// Tests to see if AnimationCurve loops.
    /// </summary>
    /// <returns>bool</returns>
    public static bool IsLooping(this AnimationCurve animationCurve)
    {

        return animationCurve != null && (animationCurve.postWrapMode == WrapMode.Loop || animationCurve.postWrapMode == WrapMode.PingPong);

    }

    /// <summary>
    /// Rotates transform so the forward vector points at target's position.
    /// </summary>
    /// <param name="target">Object to point towards.</param>
    /// <param name="direction">Vector specifying the forward direction.</param>
    /// <returns>void</returns>
    public static void LookAt2D(this Transform transform, Transform target, Vector3 direction)
    {

        Vector2 angle = target.position - transform.position;

        float deg = Vector3.Angle(Vector3.forward, direction) * Mathf.Sign(Vector3.Cross(Vector3.forward, direction).x);

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + deg, Vector3.forward);

    }

    /// <summary>
    /// Rotates transform so the forward vector points at target's position.
    /// </summary>
    /// <param name="target">Object to point towards.</param>
    /// <returns>void</returns>
    public static void LookAt2D(this Transform transform, Transform target)
    {

        Vector2 angle = target.position - transform.position;

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg, Vector3.forward);

    }

    /// <summary>
    /// Returns duration of the AnimationCurve.
    /// </summary>
    /// <returns>float</returns>
    public static float MaxTime(this AnimationCurve animationCurve)
    {

        return (animationCurve != null && animationCurve.keys.Length > 0) ? animationCurve.keys[animationCurve.keys.Length - 1].time : 0;

    }

    /// <summary>
    /// Creates a new copy of a list and shuffles the values.
    /// </summary>
    /// <returns>List<typeparamref name="T"/>></returns>
    public static List<T> Shuffle<T>(this List<T> list)
    {

        List<T> shuffledList = new List<T>(list);

        int count = shuffledList.Count;

        for (int i = 0; i < count; i += 1)
        {

            int randomIndex = UnityEngine.Random.Range(i, count);

            var tempValue = shuffledList[i];

            shuffledList[i] = shuffledList[randomIndex];

            shuffledList[randomIndex] = tempValue;

        }

        return shuffledList;

    }

    /// <summary>
    /// Returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="index">Index of list to start at.</param>
    /// <param name="count">Number of items to return.</param>
    /// <returns>List<typeparamref name="T"/>></returns>
    public static List<T> Slice<T>(this List<T> list, int index = 0, int count = 1)
    {

        List<T> items = list.GetRange(index, count);

        return items;

    }

    /// <summary>
    /// Returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="count">Number of items to return.</param>
    /// <returns>List<typeparamref name="T"/>></returns>
    public static List<T> Slice<T>(this List<T> list, int count = 1)
    {

        return list.Slice(0, count);

    }

    /// <summary>
    /// Removes and returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="index">Index of list to start at.</param>
    /// <param name="count">Number of items to return and remove.</param>
    /// <returns>List<typeparamref name="T"/>></returns>
    public static List<T> Splice<T>(this List<T> list, int index = 0, int count = 1)
    {

        List<T> items = list.GetRange(index, count);

        list.RemoveRange(index, count);

        return items;

    }

    /// <summary>
    /// Removes and returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="count">Number of items to return and remove.</param>
    /// <returns>List<typeparamref name="T"/>></returns>
    public static List<T> Splice<T>(this List<T> list, int count = 1)
    {

        return list.Splice(0, count);

    }

}
