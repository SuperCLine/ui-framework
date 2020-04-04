/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\UI\PanelMgr.cs
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
    using System;
    using System.Collections.Generic;

    public sealed class PanelMgr
    {
        public static PanelMgr Instance { get; } = Activator.CreateInstance<PanelMgr>();

        private readonly string mPrefix = "Layer";
        private Dictionary<int, RectTransform> mLayerHash = new Dictionary<int, RectTransform>();
        private Dictionary<string, PanelBase> mPanelHash = new Dictionary<string, PanelBase>();

        public void Init()
        {

        }

        public void Destroy()
        {
            using (var itr = mPanelHash.GetEnumerator())
            {
                while (itr.MoveNext())
                {
                    DestroyPanel(itr.Current.Value);
                }
            }
            mPanelHash.Clear();

            using (var itr = mPanelHash.GetEnumerator())
            {
                while (itr.MoveNext())
                {
                    GameObject.Destroy(itr.Current.Value.gameObject);
                }
            }
            mLayerHash.Clear();
        }

        public void Open(string prefabPath, bool show = true)
        {
            PanelBase panel;
            if (!mPanelHash.TryGetValue(prefabPath, out panel))
            {
                panel = CreatePanel(prefabPath);
            }

            panel.OnOpen();

            if (show)
            {
                Show(prefabPath);
            }
        }

        public void Close(string prefabPath)
        {
            PanelBase panel;
            if (mPanelHash.TryGetValue(prefabPath, out panel))
            {
                DestroyPanel(panel);
                mPanelHash.Remove(prefabPath);
            }
        }

        public void Show(string prefabPath)
        {
            PanelBase panel;
            if (mPanelHash.TryGetValue(prefabPath, out panel))
            {
                panel.OnShow();

                panel.gameObject.SetActive(true);
            }
        }

        public void Hide(string prefabPath)
        {
            PanelBase panel;
            if (mPanelHash.TryGetValue(prefabPath, out panel))
            {
                panel.OnHide();

                panel.gameObject.SetActive(false);
            }
        }

        public void AddPanelItem(string panelOwner, string prefabPath, RectTransform parent)
        {
            // TO CLine: to support grid view item.
        }

        private PanelBase CreatePanel(string prefabPath)
        {
            GameObject go = GameObject.Instantiate(ResourceMgr.Instance.LoadGameObject(prefabPath));
            PanelBase panel = go.GetComponent<PanelBase>();
            panel.BuildControl();
            Transform parent = GetLayer(panel.PanelLayer);
            RectTransform rect = go.transform as RectTransform;
            AddUIChild(rect, parent as RectTransform);
            rect.SetAsLastSibling();

            mPanelHash.Add(prefabPath, panel);

            return panel;
        }

        private void DestroyPanel(PanelBase panel)
        {
            if (panel != null)
            {
                panel.OnClose();

                GameObject.Destroy(panel.gameObject);

                // TO CLine: release asset
            }
        }

        private RectTransform GetLayer(int index)
        {
            RectTransform layer;
            if (!mLayerHash.TryGetValue(index, out layer))
            {
                GameObject go = new GameObject(mPrefix + index);
                go.layer = UIMgr.Instance.UI2DRoot.gameObject.layer;

                layer = go.AddComponent<RectTransform>();
                AddUIChild(layer, UIMgr.Instance.UI2DRoot);
                layer.anchorMin = Vector2.zero;
                layer.anchorMax = Vector2.one;
                layer.sizeDelta = Vector2.zero;

                layer.SetSiblingIndex(GetSiblingIndex(index));
                mLayerHash[index] = layer;
            }

            return layer;
        }

        private int GetSiblingIndex(int index)
        {
            int siblingIndex = 0;

            using (var itr = mLayerHash.Keys.GetEnumerator())
            {
                while (itr.MoveNext())
                {
                    if (itr.Current < index)
                    {
                        ++siblingIndex;
                    }
                }
            }

            return siblingIndex;
        }

        private void AddUIChild(RectTransform child, RectTransform parent)
        {
            Vector3 localScale = child.localScale;
            Vector3 localPosition = child.anchoredPosition3D;
            Quaternion localRotation = child.localRotation;

            Vector2 offsetMax = child.offsetMax;
            Vector2 offsetMin = child.offsetMin;
            Vector2 sizeDelta = child.sizeDelta;

            child.SetParent(parent);

            child.localScale = localScale;
            child.anchoredPosition3D = localPosition;
            child.localRotation = localRotation;

            child.offsetMax = offsetMax;
            child.offsetMin = offsetMin;
            child.sizeDelta = sizeDelta;
        }

    }

}