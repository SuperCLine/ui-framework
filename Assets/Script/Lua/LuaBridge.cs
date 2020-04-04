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
        void AwakePanel(string panelName, Transform tr, GameObject go);
        ILuaPanelItem AwakePanelItem(string itemName, Transform tr, GameObject go);

        void OnOpen(string panelName, ILuaPanelItem panelItem, Dictionary<string, Component> controls);
        void OnShow(string panelName);
        void OnHide(string panelName);
        void OnClose(string panelName);

        void OnEnable(string panelName, ILuaPanelItem panelItem);
        void Start(string panelName, ILuaPanelItem panelItem);
        void OnDisable(string panelName, ILuaPanelItem panelItem);
        void OnDestroy(string panelName, ILuaPanelItem panelItem);

        void OnClick(string panelName, ILuaPanelItem panelItem, Button btn);
        void OnInputValueChanged(string panelName, ILuaPanelItem panelItem, InputField input, string val);
        void OnInputEndEdit(string panelName, ILuaPanelItem panelItem, InputField input, string val);
        void OnToggleValueChanged(string panelName, ILuaPanelItem panelItem, Toggle tog, bool val);
        void OnSliderValueChanged(string panelName, ILuaPanelItem panelItem, Slider slider, float val);
        void OnDown(string panelName, ILuaPanelItem panelItem, GameObject go);
        void OnUp(string panelName, ILuaPanelItem panelItem, GameObject go);
        void OnEnter(string panelName, ILuaPanelItem panelItem, GameObject go);
        void OnExit(string panelName, ILuaPanelItem panelItem, GameObject go);
        void OnLongPress(string panelName, ILuaPanelItem panelItem, GameObject go);
        void OnLongPressEnd(string panelName, ILuaPanelItem panelItem, GameObject go);
        void OnDragStart(string panelName, ILuaPanelItem panelItem, GameObject go, PointerEventData eventData);
        void OnDrag(string panelName, ILuaPanelItem panelItem, GameObject go, PointerEventData eventData);
        void OnDragEnd(string panelName, ILuaPanelItem panelItem, GameObject go, PointerEventData eventData);

        void Main();
    }

    public interface ILuaPanelItem
    {
        void Awake();
        void OnOpen(Dictionary<string, Component> controls);
        void OnEnable();
        void Start();
        void OnDisable();
        void OnDestroy();

        void OnClick(Button btn);
        void OnInputValueChanged(InputField input, string val);
        void OnInputEndEdit(InputField input, string val);
        void OnToggleValueChanged(Toggle tog, bool val);
        void OnSliderValueChanged(Slider slider, float val);
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