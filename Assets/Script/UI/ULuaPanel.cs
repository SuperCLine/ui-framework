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

        public override void OnOpen()
        {
            LuaMgr.Instance.LuaPanelMgr.OnOpen(LuaPanelName, null, mControlHash);
        }

        public override void OnClose()
        {
            LuaMgr.Instance.LuaPanelMgr.OnClose(LuaPanelName);
        }

        public override void OnShow()
        {
            LuaMgr.Instance.LuaPanelMgr.OnShow(LuaPanelName);
        }

        public override void OnHide()
        {
            LuaMgr.Instance.LuaPanelMgr.OnHide(LuaPanelName);
        }

        private void Awake()
        {
            LuaMgr.Instance.LuaPanelMgr.AwakePanel(LuaPanelName, transform, gameObject);
        }

        private void OnEnable()
        {
            LuaMgr.Instance.LuaPanelMgr.OnEnable(LuaPanelName, null);
        }

        private void Start()
        {
            LuaMgr.Instance.LuaPanelMgr.Start(LuaPanelName, null);
        }

        private void OnDisable()
        {
            LuaMgr.Instance.LuaPanelMgr.OnDisable(LuaPanelName, null);
        }

        private void OnDestroy()
        {
            if (LuaMgr.Instance.LuaPanelMgr != null)
                LuaMgr.Instance.LuaPanelMgr.OnDestroy(LuaPanelName, null);
        }

        protected override void OnClick(Button btn)
        { LuaMgr.Instance.LuaPanelMgr.OnClick(LuaPanelName, null, btn); }
        protected override void OnInputValueChanged(InputField input, string val)
        { LuaMgr.Instance.LuaPanelMgr.OnInputValueChanged(LuaPanelName, null, input, val); }
        protected override void OnInputEndEdit(InputField input, string val)
        { LuaMgr.Instance.LuaPanelMgr.OnInputEndEdit(LuaPanelName, null, input, val); }
        protected override void OnToggleValueChanged(Toggle tog, bool val)
        { LuaMgr.Instance.LuaPanelMgr.OnToggleValueChanged(LuaPanelName, null, tog, val); }
        protected override void OnSliderValueChanged(Slider slider, float val)
        { LuaMgr.Instance.LuaPanelMgr.OnSliderValueChanged(LuaPanelName, null, slider, val); }
        protected override void OnDown(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnDown(LuaPanelName, null, go); }
        protected override void OnUp(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnUp(LuaPanelName, null, go); }
        protected override void OnEnter(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnEnter(LuaPanelName, null, go); }
        protected override void OnExit(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnExit(LuaPanelName, null, go); }
        protected override void OnLongPress(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnLongPress(LuaPanelName, null, go); }
        protected override void OnLongPressEnd(GameObject go)
        { LuaMgr.Instance.LuaPanelMgr.OnLongPressEnd(LuaPanelName, null, go); }
        protected override void OnDragStart(GameObject go, PointerEventData eventData)
        { LuaMgr.Instance.LuaPanelMgr.OnDragStart(LuaPanelName, null, go, eventData); }
        protected override void OnDrag(GameObject go, PointerEventData eventData)
        { LuaMgr.Instance.LuaPanelMgr.OnDrag(LuaPanelName, null, go, eventData); }
        protected override void OnDragEnd(GameObject go, PointerEventData eventData)
        { LuaMgr.Instance.LuaPanelMgr.OnDragEnd(LuaPanelName, null, go, eventData); }
    }

}