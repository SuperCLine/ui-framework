/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\UI\UIEventListener.cs
| AUTHOR     : http://supercline.com/
| PURPOSE    :
|
| SPEC       :
|
| MODIFICATION HISTORY
|
| Ver      Date            By              Details
| -----    -----------    -------------   ----------------------
| 1.0      2020-4-4      SuperCLine           Created
|
+-----------------------------------------------------------------------------*/

namespace CAE.Core
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    public sealed class UIEventListener : MonoBehaviour,
                                        IPointerClickHandler,
                                        IPointerDownHandler,
                                        IPointerUpHandler,
                                        IPointerEnterHandler,
                                        IPointerExitHandler
    {
        public delegate void VoidDelegate(GameObject go);

        public VoidDelegate onClick;
        public VoidDelegate onDown;
        public VoidDelegate onUp;
        public VoidDelegate onEnter;
        public VoidDelegate onExit;
        public VoidDelegate onLongPressStart;
        public VoidDelegate onLongPress;
        public VoidDelegate onLongPressEnd;

        private bool isDown = false;
        private float recognitionTime = 0.2f;
        private float intervalTime = 0.01f;
        private bool isLongPressed = false;
        private float lastIsDownTime;

        public static UIEventListener Get(GameObject go)
        {
            UIEventListener listener = go.GetComponent<UIEventListener>();
            if (listener == null) listener = go.AddComponent<UIEventListener>();

            return listener;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (onClick != null)
            {
                onClick(gameObject);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isDown = true;
            lastIsDownTime = Time.time;

            if (onDown != null)
            {
                onDown(gameObject);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isDown = false;

            if (isLongPressed)
            {
                onLongPressEnd?.Invoke(gameObject);
                isLongPressed = false;
            }
            else
            {
                onUp?.Invoke(gameObject);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (onEnter != null)
            {
                onEnter(gameObject);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isDown = false;
            if (onExit != null)
            {
                onExit(gameObject);
            }
        }

        private void Update()
        {
            if (isDown)
            {
                if (!isLongPressed)
                {
                    if (Time.time - lastIsDownTime > recognitionTime)
                    {
                        if (onLongPressStart != null)
                        {
                            onLongPressStart(gameObject);
                        }

                        isLongPressed = true;
                        lastIsDownTime = Time.time;
                    }
                }
                else
                {
                    if (Time.time - lastIsDownTime > intervalTime)
                    {
                        if (onLongPress != null)
                        {
                            onLongPress(gameObject);
                        }

                        lastIsDownTime = Time.time;
                    }
                }
            }

        }

    }

}