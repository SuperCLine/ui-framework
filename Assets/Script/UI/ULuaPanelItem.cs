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
        private ILuaPanelItem mLuaPanelItem = null;
        public string PanelItemName = string.Empty;

        public override void OnOpen()
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnOpen(mControlHash);
        }

        public override void OnClose()
        {
        }

        public override void OnShow()
        {
        }

        public override void OnHide()
        {
        }

        private void Awake()
        {
            mLuaPanelItem = LuaMgr.Instance.LuaPanelMgr.AwakePanelItem(PanelItemName, transform, gameObject);
        }

        private void OnEnable()
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnEnable();
        }

        private void Start()
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.Start();
        }

        private void OnDisable()
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnDisable();
        }

        private void OnDestroy()
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnDestroy();
        }

        protected override void OnClick(Button btn)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnClick(btn);
        }
        protected override void OnInputValueChanged(InputField input, string val)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnInputValueChanged(input, val);
        }
        protected override void OnInputEndEdit(InputField input, string val)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnInputEndEdit(input, val);
        }
        protected override void OnToggleValueChanged(Toggle tog, bool val)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnToggleValueChanged(tog, val);
        }
        protected override void OnSliderValueChanged(Slider slider, float val)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnSliderValueChanged(slider, val);
        }
        protected override void OnDown(GameObject go)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnDown(go);
        }
        protected override void OnUp(GameObject go)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnUp(go);
        }
        protected override void OnEnter(GameObject go)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnEnter(go);
        }
        protected override void OnExit(GameObject go)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnExit(go);
        }
        protected override void OnLongPress(GameObject go)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnLongPress(go);
        }
        protected override void OnLongPressEnd(GameObject go)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnLongPressEnd(go);
        }
        protected override void OnDragStart(GameObject go, PointerEventData eventData)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnDragStart(go, eventData);
        }
        protected override void OnDrag(GameObject go, PointerEventData eventData)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnDrag(go, eventData);
        }
        protected override void OnDragEnd(GameObject go, PointerEventData eventData)
        {
            if (mLuaPanelItem != null)
                mLuaPanelItem.OnDragEnd(go, eventData);
        }
    }

}