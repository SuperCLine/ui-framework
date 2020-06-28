/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\UI\ULuaPanel.cs
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
    using System.Collections.Generic;

    public sealed class ULuaPanel : PanelBase
    {
        public bool Mask = false;
        public int Layer = 0;
        public string LuaPanelName = string.Empty;

        public override bool PanelMask
        {
            get { return Mask; }
        }

        public override int PanelLayer
        {
            get { return Layer; }
        }

        public override void OnCreate()
        {
            LuaMgr.Instance.LuaPanelMgr.NewPanel(LuaPanelName, Prefab, transform, gameObject);
        }

        public override void OnOpen()
        {
            LuaMgr.Instance.LuaPanelMgr.OnOpen(Prefab, mControlHash);
        }

        public override void OnClose()
        {
            LuaMgr.Instance.LuaPanelMgr.OnClose(Prefab);
        }

        public override void OnShow()
        {
            LuaMgr.Instance.LuaPanelMgr.OnShow(Prefab);
        }

        public override void OnHide()
        {
            LuaMgr.Instance.LuaPanelMgr.OnHide(Prefab);
        }


        protected override void OnClick(Component btn)
        { LuaMgr.Instance.LuaPanelMgr.OnClick(Prefab, btn); }
        protected override void OnInputValueChanged(Component input, string val)
        { LuaMgr.Instance.LuaPanelMgr.OnInputValueChanged(Prefab, input, val); }
        protected override void OnInputEndEdit(Component input, string val)
        { LuaMgr.Instance.LuaPanelMgr.OnInputEndEdit(Prefab, input, val); }
        protected override void OnToggleValueChanged(Component tog, bool val)
        { LuaMgr.Instance.LuaPanelMgr.OnToggleValueChanged(Prefab, tog, val); }
        protected override void OnSliderValueChanged(Component slider, float val)
        { LuaMgr.Instance.LuaPanelMgr.OnSliderValueChanged(Prefab, slider, val); }
        protected override void OnLoopGridValueChanged(UILoopGrid loopGrid, ILuaPanelItem item, int index)
        { LuaMgr.Instance.LuaPanelMgr.OnLoopGridValueChanged(Prefab, loopGrid, item, index); }
        protected override void OnDown(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnDown(Prefab, go); }
        protected override void OnUp(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnUp(Prefab, go); }
        protected override void OnEnter(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnEnter(Prefab, go); }
        protected override void OnExit(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnExit(Prefab, go); }
        protected override void OnLongPress(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnLongPress(Prefab, go); }
        protected override void OnLongPressEnd(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnLongPressEnd(Prefab, go); }
        protected override void OnDragStart(GameObject go, PointerEventData eventData)
        { LuaMgr.Instance.LuaPanelMgr.OnDragStart(Prefab, go, eventData); }
        protected override void OnDrag(GameObject go, PointerEventData eventData)
        { LuaMgr.Instance.LuaPanelMgr.OnDrag(Prefab, go, eventData); }
        protected override void OnDragEnd(GameObject go, PointerEventData eventData)
        { LuaMgr.Instance.LuaPanelMgr.OnDragEnd(Prefab, go, eventData); }
    }
}