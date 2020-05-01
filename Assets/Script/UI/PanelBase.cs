/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\UI\PanelBase.cs
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

    public abstract class PanelBase : MonoBehaviour
    {
        protected Dictionary<string, Component> mControlHash = new Dictionary<string, Component>();

        public virtual bool PanelMask
        {
            get { return false; }
        }

        public virtual int PanelLayer
        {
            get { return 0; }
        }

        public string Prefab
        { get; set; }

        public abstract void OnCreate();
        public abstract void OnOpen();
        public abstract void OnClose();
        public abstract void OnShow();
        public abstract void OnHide();

        public void BuildControl()
        {
            Transform[] trs = gameObject.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < trs.Length; ++i)
            {
                string name = trs[i].name;
                int len = name.IndexOf('_') + 1;
                string prefix = name.Substring(0, len);
                switch (prefix)
                {
                    case "Widget_":
                        {
                            RectTransform rt = trs[i].GetComponent<RectTransform>();
                            if (rt == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'RectTransform\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, rt);
                            }
                        }
                        break;
                    case "Text_":
                        {
                            Text label = trs[i].GetComponent<Text>();
                            if (label == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'Text\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, label);
                            }
                        }
                        break;
                    case "Button_":
                        {
                            Button btn = trs[i].GetComponent<Button>();
                            if (btn == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'Button\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, btn);

                                UIEventListener.Get(btn.gameObject).onClick = onClick;
                            }
                        }
                        break;
                    case "Input_":
                        {
                            InputField input = trs[i].GetComponent<InputField>();
                            if (input == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'InputField\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, input);

                                input.onValueChanged.AddListener((val) =>
                                {
                                    onInputValueChanged(input.gameObject, val);
                                });
                                input.onEndEdit.AddListener((val) =>
                                {
                                    onInputEndEdit(input.gameObject, val);
                                });
                            }
                        }
                        break;
                    case "Toggle_":
                        {
                            Toggle tog = trs[i].GetComponent<Toggle>();
                            if (tog == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'Toggle\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, tog);

                                tog.onValueChanged.AddListener((val) =>
                                {
                                    onToggleValueChanged(tog.gameObject, val);
                                });
                            }
                        }
                        break;
                    case "Slider_":
                        {
                            Slider slider = trs[i].GetComponent<Slider>();
                            if (slider == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'Slider\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, slider);
                                
                                slider.onValueChanged.AddListener((val) =>
                                {
                                    onSliderValueChanged(slider.gameObject, val);
                                });
                            }
                        }
                        break;
                    case "Sprite_":
                        {
                            Image img = trs[i].GetComponent<Image>();
                            if (img == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'Image\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, img);

                                UIEventListener li = UIEventListener.Get(img.gameObject);
                                li.onDown = onDown;
                                li.onUp = onUp;
                                li.onEnter = onEnter;
                                li.onExit = onExit;
                                li.onLongPress = onLongPress;
                                li.onLongPressEnd = onLongPressEnd;
                                li.onDragStart = onDragStart;
                                li.onDrag = onDrag;
                                li.onDragEnd = onDragEnd;
                            }
                        }
                        break;
                    case "Progress_":
                        {
                            Image img = trs[i].GetComponent<Image>();
                            if (img == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'Image\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, img);
                            }
                        }
                        break;
                    case "LoopGrid_":
                        {
                            UILoopGrid loopGird= trs[i].GetComponent<UILoopGrid>();
                            if (loopGird == null)
                            {
                                Debug.LogErrorFormat("{0} require component \'UILoopGrid\'.", name);
                            }
                            else
                            {
                                mControlHash.Add(name, loopGird);

                                loopGird.Init();
                                loopGird.OnLoopGridValueChanged = (item, index) =>
                                {
                                    onLoopGridValueChanged(loopGird.gameObject, item, index);
                                };
                            }
                        }
                        break;
                }
            }
        }

        #region event
        protected virtual void OnClick(Button btn)
        { }
        protected virtual void OnInputValueChanged(InputField input, string val)
        { }
        protected virtual void OnInputEndEdit(InputField input, string val)
        { }
        protected virtual void OnToggleValueChanged(Toggle tog, bool val)
        { }
        protected virtual void OnSliderValueChanged(Slider slider, float val)
        { }
        protected virtual void OnLoopGridValueChanged(UILoopGrid loopGrid, ILuaPanelItem item,int index)
        { }
        protected virtual void OnDown(GameObject go)
        { }
        protected virtual void OnUp(GameObject go)
        { }
        protected virtual void OnEnter(GameObject go)
        { }
        protected virtual void OnExit(GameObject go)
        { }
        protected virtual void OnLongPress(GameObject go)
        { }
        protected virtual void OnLongPressEnd(GameObject go)
        { }
        protected virtual void OnDragStart(GameObject go, PointerEventData eventData)
        { }
        protected virtual void OnDrag(GameObject go, PointerEventData eventData)
        { }
        protected virtual void OnDragEnd(GameObject go, PointerEventData eventData)
        { }
        #endregion event

        private void onClick(GameObject go)
        {
            Button btn = go.GetComponent<Button>();
            OnClick(btn);
        }
        private void onInputValueChanged(GameObject go, string val)
        {
            InputField input = go.GetComponent<InputField>();
            OnInputValueChanged(input, val);
        }
        private void onInputEndEdit(GameObject go, string val)
        {
            InputField input = go.GetComponent<InputField>();
            OnInputEndEdit(input, val);
        }
        private void onToggleValueChanged(GameObject go, bool val)
        {
            Toggle tog = go.GetComponent<Toggle>();
            OnToggleValueChanged(tog, val);
        }
        private void onSliderValueChanged(GameObject go, float val)
        {
            Slider slider = go.GetComponent<Slider>();
            OnSliderValueChanged(slider, val);
        }
        private void onLoopGridValueChanged(GameObject go, ILuaPanelItem item, int index)
        {
            UILoopGrid loopGird = go.GetComponent<UILoopGrid>();
            OnLoopGridValueChanged(loopGird, item, index);
        }
        private void onDown(GameObject go)
        {
            OnDown(go);
        }
        private void onUp(GameObject go)
        {
            OnUp(go);
        }
        private void onEnter(GameObject go)
        {
            OnEnter(go);
        }
        private void onExit(GameObject go)
        {
            OnExit(go);
        }
        private void onLongPress(GameObject go)
        {
            OnLongPress(go);
        }
        private void onLongPressEnd(GameObject go)
        {
            OnLongPressEnd(go);
        }
        private void onDragStart(GameObject go, PointerEventData eventData)
        {
            OnDragStart(go, eventData);
        }
        private void onDrag(GameObject go, PointerEventData eventData)
        {
            OnDrag(go, eventData);
        }
        private void onDragEnd(GameObject go, PointerEventData eventData)
        {
            OnDragEnd(go, eventData);
        }

    }

}