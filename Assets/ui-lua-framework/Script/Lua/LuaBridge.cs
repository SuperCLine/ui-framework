/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\Lua\LuaBridge.cs
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

    public delegate ILuaPanelMgr NewLuaPanelMgr();

    public interface ILuaPanelMgr
    {
        void NewPanel(string panelName, string prefabPath, Transform tr, GameObject go);
        ILuaPanelItem NewPanelItem(string itemName, Transform tr, GameObject go);

        void OnOpen(string prefabPath, Dictionary<string, Component> controls);
        void OnShow(string prefabPath);
        void OnHide(string prefabPath);
        void OnClose(string prefabPath);

        void OnClick(string prefabPath, Component btn);
        void OnInputValueChanged(string prefabPath, Component input, string val);
        void OnInputEndEdit(string prefabPath, Component input, string val);
        void OnToggleValueChanged(string prefabPath, Component tog, bool val);
        void OnSliderValueChanged(string prefabPath, Component slider, float val);
        void OnLoopGridValueChanged(string prefabPath, UILoopGrid loopGrid, ILuaPanelItem item, int index);
        void OnDown(string prefabPath, GameObject go);
        void OnUp(string prefabPath, GameObject go);
        void OnEnter(string prefabPath, GameObject go);
        void OnExit(string prefabPath, GameObject go);
        void OnLongPress(string prefabPath, GameObject go);
        void OnLongPressEnd(string prefabPath, GameObject go);
        void OnDragStart(string prefabPath, GameObject go, PointerEventData eventData);
        void OnDrag(string prefabPath, GameObject go, PointerEventData eventData);
        void OnDragEnd(string prefabPath, GameObject go, PointerEventData eventData);

        void OnClickItem(ILuaPanelItem item, Component btn);

        void Main();
    }

    public interface ILuaPanelItem
    {
        void OnOpen(Dictionary<string, Component> controls);
        void OnShow();
        void OnHide();
        void OnClose();

        void OnClick(Component btn);
        void OnInputValueChanged(Component input, string val);
        void OnInputEndEdit(Component input, string val);
        void OnToggleValueChanged(Component tog, bool val);
        void OnSliderValueChanged(Component slider, float val);
        void OnLoopGridValueChanged(UILoopGrid loopGrid, ILuaPanelItem item, int index);
        void OnDown(GameObject go);
        void OnUp(GameObject go);
        void OnEnter(GameObject go);
        void OnExit(GameObject go);
        void OnLongPress(GameObject go);
        void OnLongPressEnd(GameObject go);
        void OnDragStart(GameObject go, PointerEventData eventData);
        void OnDrag(GameObject go, PointerEventData eventData);
        void OnDragEnd(GameObject go, PointerEventData eventData);
    }

}