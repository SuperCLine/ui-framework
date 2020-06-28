/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2018 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\UI\UIDragListener.cs
| AUTHOR     : CLine
| PURPOSE    :
|
| SPEC       :
|
| MODIFICATION HISTORY
|
| Ver      Date            By              Details
| -----    -----------    -------------   ----------------------
| 1.0      2020-6-26      CLine           Created
|
+-----------------------------------------------------------------------------*/

namespace CAE.Core
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    public sealed class UIDragListener : MonoBehaviour,
                                        IBeginDragHandler,
                                        IDragHandler,
                                        IEndDragHandler
    {
        public delegate void DragDelegate(GameObject go, PointerEventData eventData);

        public DragDelegate onDragStart;
        public DragDelegate onDrag;
        public DragDelegate onDragEnd;

        public static UIDragListener Get(GameObject go)
        {
            UIDragListener listener = go.GetComponent<UIDragListener>();
            if (listener == null) listener = go.AddComponent<UIDragListener>();

            return listener;
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

    }
}