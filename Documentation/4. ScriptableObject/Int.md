### Int

Each ScriptableObject has a `value` and a `defaultValue`. The `value` can be modified via script, the `defaultValue` can not.

A `Reset` method is publicly available to reset the `value` to equal the `defaultValue`. This method is also accessible via the inspector.

<img src="https://i.imgur.com/899tEuG.png" width="400">

Event handlers for update and reset events are available to each ScriptableObject with `value` and `defaultValue` properties.

```csharp
private void OnEnable()
{

    intReference.UpdateEvent += OnScriptableObjectUpdate;
    intReference.ResetEvent += OnScriptableObjectReset;

}
```

When adding a handler to any event, make sure and remove it when the script it is associated with is disabled.

```csharp
private void OnDisable()
{

    intReference.UpdateEvent -= OnScriptableObjectUpdate;
    intReference.ResetEvent -= OnScriptableObjectReset;

}
```
