// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    public static class InputManager
    {

        public static bool TouchActive
        {
            get
            {
                return Input.touchSupported && Input.touchCount > 0;
            }
        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit hit)
        {

            currentFingerId = 0;

            if (TouchActive)
            {

                return GetTouchDown(gameObject, mainCamera, out currentFingerId, out hit);

            }

            return GetMouseButtonDown(gameObject, mainCamera, out hit);

        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit2D hit)
        {

            currentFingerId = 0;

            if (TouchActive)
            {

                return GetTouchDown(gameObject, mainCamera, out currentFingerId, out hit);

            }

            return GetMouseButtonDown(gameObject, mainCamera, out hit);

        }

        public static Vector3? GetInputPosition(int currentFingerId)
        {

            if (TouchActive)
            {

                return GetTouchPosition(currentFingerId);

            }

            return GetMousePosition();

        }

        public static bool GetInputUp(this GameObject gameObject, Camera mainCamera, int currentFingerId, out RaycastHit hit)
        {

            if (TouchActive)
            {

                return GetTouchUp(gameObject, mainCamera, currentFingerId, out hit);

            }

            return GetMouseButtonUp(gameObject, mainCamera, out hit);

        }

        public static bool GetInputUp(this GameObject gameObject, Camera mainCamera, int currentFingerId, out RaycastHit2D hit)
        {

            if (TouchActive)
            {

                return GetTouchUp(gameObject, mainCamera, currentFingerId, out hit);

            }

            return GetMouseButtonUp(gameObject, mainCamera, out hit);

        }

        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera, out RaycastHit hit)
        {

            hit = new RaycastHit();

            return Input.GetMouseButtonDown(0) && RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

        }

        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera, out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            return Input.GetMouseButtonDown(0) && RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

        }

        public static bool GetMouseButtonUp(this GameObject gameObject, Camera mainCamera, out RaycastHit hit)
        {

            hit = new RaycastHit();

            return Input.GetMouseButtonUp(0) && RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

        }

        public static bool GetMouseButtonUp(this GameObject gameObject, Camera mainCamera, out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            return Input.GetMouseButtonUp(0) && RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

        }

        public static Vector3? GetMousePosition()
        {

            return Input.mousePosition;

        }

        public static Touch? GetActiveTouch(int fingerId, params TouchPhase[] touchPhasesFilter)
        {

            if (TouchActive)
            {

                for (var i = 0; i < Input.touchCount; i += 1)
                {

                    var touch = Input.GetTouch(i);

                    if (touch.fingerId.Equals(fingerId) && touchPhasesFilter.Contains(touch.phase))
                    {

                        return touch;

                    }

                }

            }

            return null;

        }

        public static Touch? GetActiveTouch(params TouchPhase[] touchPhasesFilter)
        {

            if (TouchActive)
            {

                for (var i = 0; i < Input.touchCount; i += 1)
                {

                    var touch = Input.GetTouch(i);

                    if (touchPhasesFilter.Contains(touch.phase))
                    {

                        return touch;

                    }

                }

            }

            return null;

        }

        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit hit)
        {

            currentFingerId = 0;

            hit = new RaycastHit();

            var touch = GetActiveTouch(TouchPhase.Began);

            if (touch.HasValue && RaycastToGameObject(gameObject, mainCamera, touch.Value.position, out hit))
            {

                currentFingerId = touch.Value.fingerId;

                return true;

            }

            return false;

        }

        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit2D hit)
        {

            currentFingerId = 0;

            hit = new RaycastHit2D();

            var touch = GetActiveTouch(TouchPhase.Began);

            if (touch.HasValue && RaycastToGameObject(gameObject, mainCamera, touch.Value.position, out hit))
            {

                currentFingerId = touch.Value.fingerId;

                return true;

            }

            return false;

        }

        public static Vector3? GetTouchPosition(int currentFingerId)
        {

            var touch = GetActiveTouch(currentFingerId);

            if (touch.HasValue)
            {

                return touch.Value.position;

            }

            return null;

        }

        public static bool GetTouchUp(this GameObject gameObject, Camera mainCamera, int currentFingerId, out RaycastHit hit)
        {

            hit = new RaycastHit();

            var touch = GetActiveTouch(currentFingerId, TouchPhase.Ended, TouchPhase.Canceled);

            if (touch.HasValue && RaycastToGameObject(gameObject, mainCamera, touch.Value.position, out hit))
            {

                return true;

            }

            return false;

        }

        public static bool GetTouchUp(this GameObject gameObject, Camera mainCamera, int currentFingerId, out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            var touch = GetActiveTouch(currentFingerId, TouchPhase.Ended, TouchPhase.Canceled);

            if (touch.HasValue && RaycastToGameObject(gameObject, mainCamera, touch.Value.position, out hit))
            {

                return true;

            }

            return false;

        }

        public static bool RaycastToGameObject(GameObject gameObject, Camera mainCamera, Vector3 position, out RaycastHit hit)
        {

            var ray = mainCamera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, gameObject.GetLayerMask()) && hit.transform.gameObject.Equals(gameObject))
            {

                return true;

            }

            return false;

        }

        public static bool RaycastToGameObject(GameObject gameObject, Camera mainCamera, Vector3 position, out RaycastHit2D hit)
        {

            var ray = mainCamera.ScreenPointToRay(position);

            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, gameObject.GetLayerMask());

            if (hit && hit.transform.gameObject.Equals(gameObject))
            {

                return true;

            }

            return false;

        }

    }

}