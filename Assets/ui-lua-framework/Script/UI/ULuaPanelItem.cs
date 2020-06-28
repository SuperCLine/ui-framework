/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\UI\ULuaPanelItem.cs
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

    public sealed class ULuaPanelItem : PanelBase
    {
        public ILuaPanelItem LuaPanelItem { get; private set; } = null;
        public string PanelItemName = string.Empty;

        public override void OnCreate()
        {
            LuaPanelItem = LuaMgr.Instance.LuaPanelMgr.NewPanelItem(PanelItemName, transform, gameObject);
        }

        public override void OnOpen()
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnOpen(mControlHash);
        }

        public override void OnClose()
        {
            if (LuaPanelItem != null)
            {
                LuaPanelItem.OnClose();
                LuaPanelItem = null;
            }

            // TO CLine: lua gc
        }

        public override void OnShow()
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnShow();
        }

        public override void OnHide()
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnShow();
        }


        protected override void OnClick(Component btn)
        {
            if (LuaPanelItem != null)
            {
                LuaMgr.Instance.LuaPanelMgr.OnClickItem(LuaPanelItem, btn);
                LuaPanelItem.OnClick(btn);
            }
        }
        protected override void OnInputValueChanged(Component input, string val)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnInputValueChanged(input, val);
        }
        protected override void OnInputEndEdit(Component input, string val)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnInputEndEdit(input, val);
        }
        protected override void OnToggleValueChanged(Component tog, bool val)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnToggleValueChanged(tog, val);
        }
        protected override void OnSliderValueChanged(Component slider, float val)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnSliderValueChanged(slider, val);
        }
        protected override void OnLoopGridValueChanged(UILoopGrid loopGrid, ILuaPanelItem item, int index)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnLoopGridValueChanged(loopGrid, item, index);
        }
        protected override void OnDown(GameObject go)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnDown(go);
        }
        protected override void OnUp(GameObject go)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnUp(go);
        }
        protected override void OnEnter(GameObject go)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnEnter(go);
        }
        protected override void OnExit(GameObject go)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnExit(go);
        }
        protected override void OnLongPress(GameObject go)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnLongPress(go);
        }
        protected override void OnLongPressEnd(GameObject go)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnLongPressEnd(go);
        }
        protected override void OnDragStart(GameObject go, PointerEventData eventData)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnDragStart(go, eventData);
        }
        protected override void OnDrag(GameObject go, PointerEventData eventData)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnDrag(go, eventData);
        }
        protected override void OnDragEnd(GameObject go, PointerEventData eventData)
        {
            if (LuaPanelItem != null)
                LuaPanelItem.OnDragEnd(go, eventData);
        }
    }
}