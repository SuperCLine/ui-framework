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
                                        IPointerEnterHandler,
                                        IPointerExitHandler,
                                        IPointerUpHandler,
                                        IBeginDragHandler,
                                        IDragHandler,
                                        IEndDragHandler
    {
        public delegate void VoidDelegate(GameObject go);
        public delegate void DragDelegate(GameObject go, PointerEventData eventData);

        public VoidDelegate onClick;
        public VoidDelegate onDown;
        public VoidDelegate onUp;
        public VoidDelegate onEnter;
        public VoidDelegate onExit;
        public VoidDelegate onLongPress;
        public VoidDelegate onLongPressEnd;
        public DragDelegate onDragStart;
        public DragDelegate onDrag;
        public DragDelegate onDragEnd;

        private float delay = 0.2f;
        private bool isDown = false;
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
            if (onLongPressEnd != null)
            {
                onLongPressEnd(gameObject);
            }
            if (onUp != null)
            {
                onUp(gameObject);
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

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (onDragStart != null)
            {
                onDragStart(gameObject, eventData);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (onDrag != null)
            {
                onDrag(gameObject, eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (onDragEnd != null)
            {
                onDragEnd(gameObject, eventData);
            }
        }

        private void Update()
        {
            if (isDown)
            {
                if (Time.time - lastIsDownTime > delay)
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