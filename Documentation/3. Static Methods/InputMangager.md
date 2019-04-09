### InputManager

#### GetInputDown

Returns true if the user has either pressed the primary mouse button or touched the screen over a specific GameObject.

```csharp
if (InputManager.GetInputDown(gameObject, mainCamera, out currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has either pressed the primary mouse button or touched the screen.

```csharp
if (InputManager.GetInputDown(out currentFingerId))
{

    Debug.Log("Input down");

}
```

```csharp
if (InputManager.GetInputDown())
{

    Debug.Log("Input down");

}
```

#### GetInputPosition

Returns the position of either the mouse or a specific touch.

```csharp
Debug.Log(InputManager.GetInputPosition(fingerId));
```

#### GetInputUp

Returns true if the user has either released the primary mouse button or ended a touch on the screen over a specific GameObject.

```csharp
if (InputManager.GetInputUp(gameObject, mainCamera, currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has either released the primary mouse button or ended a touch on the screen.

```csharp
if (InputManager.GetInputUp(currentFingerId))
{

    Debug.Log("Input up");

}
```

```csharp
if (InputManager.GetInputUp(out currentFingerId))
{

    Debug.Log("Input up");

}
```

```csharp
if (InputManager.GetInputUp())
{

    Debug.Log("Input up");

}
```

#### GetMouseButtonDown

Returns true if the user has pressed the primary mouse button over a specific GameObject.

```csharp
if (InputManager.GetMouseButtonDown(gameObject, mainCamera, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has pressed the primary mouse button.

```csharp
if (InputManager.GetMouseButtonDown())
{

    Debug.Log("Mouse button down");

}
```

#### GetMouseButtonUp

Returns true if the user has released the primary mouse button over a specific GameObject.

```csharp
if (InputManager.GetMouseButtonUp(gameObject, mainCamera, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has released the primary mouse button.

```csharp
if (InputManager.GetMouseButtonUp())
{

    Debug.Log("Mouse button up");

}
```

#### GetMousePosition

Returns the position of the mouse.

```csharp
Debug.Log(InputManager.GetMousePosition());
```

#### GetActiveTouch

Returns the active touch based on a unique finger ID and a TouchPhase enum filter.

```csharp
var touch = InputManager.GetActiveTouch(fingerId);

if (touch.HasValue)
{

    Debug.Log(touch.Value.position);

}
```

```csharp
var touch = InputManager.GetActiveTouch(fingerId, TouchPhase.Ended);

if (touch.HasValue)
{

    Debug.Log(touch.Value.position);

}
```

```csharp
var touch = InputManager.GetActiveTouch(TouchPhase.Began);

if (touch.HasValue)
{

    Debug.Log(touch.Value.position);

}
```

#### GetTouchDown

Returns true if the user has touched the screen over a specific GameObject.

```csharp
if (InputManager.GetTouchDown(gameObject, mainCamera, out currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has touched the screen.

```csharp
if (InputManager.GetTouchDown(out currentFingerId))
{

    Debug.Log("Touch down");

}
```

```csharp
if (InputManager.GetTouchDown())
{

    Debug.Log("Touch down");

}
```

#### GetTouchPosition

Returns the position of a specific touch.

```csharp
Debug.Log(InputManager.GetTouchPosition(fingerId));
```

#### GetTouchUp

Returns true if the user has ended a touch on the screen over a specific GameObject.

```csharp
if (InputManager.GetTouchUp(gameObject, mainCamera, currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has ended a touch on the screen.

```csharp
if (InputManager.GetTouchUp(currentFingerId))
{

    Debug.Log("Touch up");

}
```

```csharp
if (InputManager.GetTouchUp(out currentFingerId))
{

    Debug.Log("Touch up");

}
```

```csharp
if (InputManager.GetTouchUp())
{

    Debug.Log("Touch up");

}
```

#### RaycastToGameObject

Returns true if a position collides with a GameObject.

```csharp
if (InputManager.RaycastToGameObject(gameObject, mainCamera, Vector3.zero, out hit))
{

    Debug.Log(gameObject.name);

}
```