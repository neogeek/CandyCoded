// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CandyCoded.Experimental
{

    [AddComponentMenu("CandyCoded / Forms / Form")]
    public class Form : MonoBehaviour
    {

        private EventSystem _eventSystem;

        private void Awake()
        {

            _eventSystem = EventSystem.current;

        }

        public Dictionary<string, object> GetFormRawValues()
        {

            return gameObject.GetComponentsInChildren<FormField>().Where(field => field.name != "")
                .ToDictionary(field => field.name, field => field.value);

        }

        public void LoadFormRawValues(Dictionary<string, object> values)
        {

            var formFields = gameObject.transform.GetComponentsInChildren<FormField>();

            foreach (var value in values)
            {

                foreach (var formField in formFields)
                {

                    if (value.Key.Equals(formField.name))
                    {

                        formField.value = value.Value;

                    }

                }

            }

        }

        private void Update()
        {

            if (!Input.GetKeyDown(KeyCode.Tab))
            {
                return;
            }

            var selectable = _eventSystem.currentSelectedGameObject.GetComponent<Selectable>();

            var allSelectable = _eventSystem.currentSelectedGameObject.GetComponentInParent<Form>()
                .GetComponentsInChildren<Selectable>();

            var prevSelectable = selectable.FindSelectableOnUp() ?? allSelectable.Last();
            var nextSelectable = selectable.FindSelectableOnDown() ?? allSelectable.First();

            var next = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)
                ? prevSelectable
                : nextSelectable;

            _eventSystem.SetSelectedGameObject(next.gameObject, null);

        }

    }

}
