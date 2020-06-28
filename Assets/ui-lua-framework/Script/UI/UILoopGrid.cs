/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\UI\UILoopGrid.cs
| AUTHOR     : http://supercline.com/
| PURPOSE    :
|
| SPEC       :
|
| MODIFICATION HISTORY
|
| Ver      Date            By              Details
| -----    -----------    -------------   ----------------------
| 1.0      2020-4-30      SuperCLine           Created
|
+-----------------------------------------------------------------------------*/

namespace CAE.Core
{
    using UnityEngine;
    using UnityEngine.UI;
    using System;
    using System.Collections.Generic;
    using UnityEngine.EventSystems;

    public class UILoopGrid : MonoBehaviour
    {
        public class UIUtils
        {
            public static void SetActive(PanelBase item, bool isActive)
            {
                if (item != null)
                {
                    item.gameObject.SetActive(isActive);
                }

            }
        }

        public enum e_Direction
        {
            Horizontal,
            Vertical
        }

        public GameObject m_PointingFirstArrow;
        public GameObject m_PointingEndArrow;

        public GameObject m_CellGameObject;
        public GameObject m_CellPrefab;

        public bool m_IsShowArrow = true;
        public e_Direction m_Direction = e_Direction.Horizontal;
        
        public int m_Row = 1;
        public float m_Spacing = 0f;
        

        public Action<ILuaPanelItem, int> OnLoopGridValueChanged;
        public Action<ILuaPanelItem, int, ILuaPanelItem, int> OnDragStart;
        public Action<ILuaPanelItem, int, ILuaPanelItem, int> OnDrag;
        public Action<ILuaPanelItem, int, ILuaPanelItem, int> OnDragEnd;

        protected RectTransform rectTrans;

        protected float m_PlaneWidth;
        protected float m_PlaneHeight;

        protected float m_ContentWidth;
        protected float m_ContentHeight;

        protected float m_CellObjectWidth;
        protected float m_CellObjectHeight;

        protected GameObject m_Content;
        protected RectTransform m_ContentRectTrans;

        private bool m_isInited = false;

        protected struct CellInfo
        {
            public Vector3 pos;
            public ULuaPanelItem obj;
        };
        protected CellInfo[] m_CellInfos;

        protected bool m_IsInited = false;

        protected ScrollRect m_ScrollRect;

        protected int m_MaxCount = -1;

        protected int m_MinIndex = -1;
        protected int m_MaxIndex = -1;

        protected bool m_IsClearList = false;

        public virtual void Init()
        {
            DisposeAll();

            if (m_isInited)
                return;

            m_Content = this.GetComponent<ScrollRect>().content.gameObject;

            if (m_CellGameObject == null)
            {
                if (m_Content.transform.childCount > 0)
                {
                    m_CellGameObject = m_Content.transform.GetChild(0).gameObject;
                }
                if (!m_CellGameObject && m_CellPrefab != null)
                {
                    GameObject go = Instantiate(m_CellPrefab) as GameObject;
                    m_CellGameObject = go;
                }
                if (!m_CellGameObject)
                {
                    return;
                }
            }

            RectTransform cellRectTrans = m_CellGameObject.GetComponent<RectTransform>();
            cellRectTrans.pivot = new Vector2(0f, 1f);
            CheckAnchor(cellRectTrans);
            cellRectTrans.anchoredPosition = Vector2.zero;

            m_CellObjectHeight = cellRectTrans.rect.height;
            m_CellObjectWidth = cellRectTrans.rect.width;

            rectTrans = GetComponent<RectTransform>();
            Rect planeRect = rectTrans.rect;
            m_PlaneHeight = planeRect.height;
            m_PlaneWidth = planeRect.width;

            m_ContentRectTrans = m_Content.GetComponent<RectTransform>();
            Rect contentRect = m_ContentRectTrans.rect;
            m_ContentHeight = contentRect.height;
            m_ContentWidth = contentRect.width;

            m_ContentRectTrans.pivot = new Vector2(0f, 1f);
            //m_ContentRectTrans.sizeDelta = new Vector2 (planeRect.width, planeRect.height);
            //m_ContentRectTrans.anchoredPosition = Vector2.zero;
            CheckAnchor(m_ContentRectTrans);

            m_ScrollRect = this.GetComponent<ScrollRect>();

            m_ScrollRect.onValueChanged.RemoveAllListeners();

            m_ScrollRect.onValueChanged.AddListener(delegate (Vector2 value) { ScrollRectListener(value); });

            if (m_IsShowArrow)
            {
                m_ScrollRect.onValueChanged.AddListener(delegate (Vector2 value) { OnDragListener(value); });
                OnDragListener(Vector2.zero);
            }

            m_isInited = true;

        }

        private void CheckAnchor(RectTransform rectTrans)
        {
            if (m_Direction == e_Direction.Vertical)
            {
                if (!((rectTrans.anchorMin == new Vector2(0, 1) && rectTrans.anchorMax == new Vector2(0, 1)) ||
                         (rectTrans.anchorMin == new Vector2(0, 1) && rectTrans.anchorMax == new Vector2(1, 1))))
                {
                    rectTrans.anchorMin = new Vector2(0, 1);
                    rectTrans.anchorMax = new Vector2(1, 1);
                }
            }
            else
            {
                if (!((rectTrans.anchorMin == new Vector2(0, 1) && rectTrans.anchorMax == new Vector2(0, 1)) ||
                         (rectTrans.anchorMin == new Vector2(0, 0) && rectTrans.anchorMax == new Vector2(0, 1))))
                {
                    rectTrans.anchorMin = new Vector2(0, 0);
                    rectTrans.anchorMax = new Vector2(0, 1);
                }
            }
        }

        public virtual void UpdateList()
        {
            for (int i = 0, length = m_CellInfos.Length; i < length; i++)
            {
                CellInfo cellInfo = m_CellInfos[i];
                if (cellInfo.obj != null)
                {
                    float rangePos = m_Direction == e_Direction.Vertical ? cellInfo.pos.y : cellInfo.pos.x;
                    if (!IsOutRange(rangePos))
                    {
                        Func(OnLoopGridValueChanged, cellInfo.obj, true);
                    }
                }
            }
        }

        public void UpdateCell(int index)
        {
            CellInfo cellInfo = m_CellInfos[index - 1];
            if (cellInfo.obj != null)
            {
                float rangePos = m_Direction == e_Direction.Vertical ? cellInfo.pos.y : cellInfo.pos.x;
                if (!IsOutRange(rangePos))
                {
                    Func(OnLoopGridValueChanged, cellInfo.obj);
                }
            }
        }

        public virtual void ShowList(int num)
        {
            m_MinIndex = -1;
            m_MaxIndex = -1;

            if (m_Direction == e_Direction.Vertical)
            {
                float contentSize = (m_Spacing + m_CellObjectHeight) * Mathf.CeilToInt((float)num / m_Row);
                m_ContentHeight = contentSize;
                m_ContentWidth = m_ContentRectTrans.sizeDelta.x;
                contentSize = contentSize < rectTrans.rect.height ? rectTrans.rect.height : contentSize;
                m_ContentRectTrans.sizeDelta = new Vector2(m_ContentWidth, contentSize);
                if (num != m_MaxCount)
                {
                    m_ContentRectTrans.anchoredPosition = new Vector2(m_ContentRectTrans.anchoredPosition.x, 0);
                }
            }
            else
            {
                float contentSize = (m_Spacing + m_CellObjectWidth) * Mathf.CeilToInt((float)num / m_Row);
                m_ContentWidth = contentSize;
                m_ContentHeight = m_ContentRectTrans.sizeDelta.x;
                contentSize = contentSize < rectTrans.rect.width ? rectTrans.rect.width : contentSize;
                m_ContentRectTrans.sizeDelta = new Vector2(contentSize, m_ContentHeight);
                if (num != m_MaxCount)
                {
                    m_ContentRectTrans.anchoredPosition = new Vector2(0, m_ContentRectTrans.anchoredPosition.y);
                }
            }

            int lastEndIndex = 0;

            if (m_IsInited)
            {
                lastEndIndex = num - m_MaxCount > 0 ? m_MaxCount : num;
                lastEndIndex = m_IsClearList ? 0 : lastEndIndex;

                int count = m_IsClearList ? m_CellInfos.Length : m_MaxCount;
                for (int i = lastEndIndex; i < count; i++)
                {
                    if (m_CellInfos[i].obj != null)
                    {
                        SetPoolsObj(m_CellInfos[i].obj);
                        m_CellInfos[i].obj = null;
                    }
                }
            }

            CellInfo[] tempCellInfos = m_CellInfos;
            m_CellInfos = new CellInfo[num];

            for (int i = 0; i < num; i++)
            {
                if (m_MaxCount != -1 && i < lastEndIndex)
                {
                    CellInfo tempCellInfo = tempCellInfos[i];
                    float rPos = m_Direction == e_Direction.Vertical ? tempCellInfo.pos.y : tempCellInfo.pos.x;
                    if (!IsOutRange(rPos))
                    {
                        m_MinIndex = m_MinIndex == -1 ? i : m_MinIndex;
                        m_MaxIndex = i;

                        if (tempCellInfo.obj == null)
                        {
                            tempCellInfo.obj = GetPoolsObj();
                        }
                        tempCellInfo.obj.transform.GetComponent<RectTransform>().anchoredPosition = tempCellInfo.pos;
                        tempCellInfo.obj.name = i.ToString();
                        tempCellInfo.obj.gameObject.SetActive(true);

                        Func(OnLoopGridValueChanged, tempCellInfo.obj);
                    }
                    else
                    {
                        SetPoolsObj(tempCellInfo.obj);
                        tempCellInfo.obj = null;
                    }
                    m_CellInfos[i] = tempCellInfo;
                    continue;
                }

                CellInfo cellInfo = new CellInfo();

                float pos = 0;
                float rowPos = 0;

                if (m_Direction == e_Direction.Vertical)
                {
                    pos = m_CellObjectHeight * Mathf.FloorToInt(i / m_Row) + m_Spacing * Mathf.FloorToInt(i / m_Row);
                    rowPos = m_CellObjectWidth * (i % m_Row) + m_Spacing * (i % m_Row);
                    cellInfo.pos = new Vector3(rowPos, -pos, 0);
                }
                else
                {
                    pos = m_CellObjectWidth * Mathf.FloorToInt(i / m_Row) + m_Spacing * Mathf.FloorToInt(i / m_Row);
                    rowPos = m_CellObjectHeight * (i % m_Row) + m_Spacing * (i % m_Row);
                    cellInfo.pos = new Vector3(pos, -rowPos, 0);
                }

                float cellPos = m_Direction == e_Direction.Vertical ? cellInfo.pos.y : cellInfo.pos.x;
                if (IsOutRange(cellPos))
                {
                    cellInfo.obj = null;
                    m_CellInfos[i] = cellInfo;
                    continue;
                }

                m_MinIndex = m_MinIndex == -1 ? i : m_MinIndex;
                m_MaxIndex = i;

                ULuaPanelItem cell = GetPoolsObj();
                cell.transform.GetComponent<RectTransform>().anchoredPosition = cellInfo.pos;
                cell.gameObject.name = i.ToString();

                cellInfo.obj = cell;
                m_CellInfos[i] = cellInfo;

                Func(OnLoopGridValueChanged, cell);
            }

            m_MaxCount = num;
            m_IsInited = true;

            OnDragListener(Vector2.zero);

        }

        public void UpdateSize()
        {
            Rect rect = GetComponent<RectTransform>().rect;
            m_PlaneHeight = rect.height;
            m_PlaneWidth = rect.width;
        }

        protected virtual void ScrollRectListener(Vector2 value)
        {
            UpdateCheck();
        }

        private void UpdateCheck()
        {
            if (m_CellInfos == null)
                return;

            for (int i = 0, length = m_CellInfos.Length; i < length; i++)
            {
                CellInfo cellInfo = m_CellInfos[i];
                ULuaPanelItem obj = cellInfo.obj;
                Vector3 pos = cellInfo.pos;

                float rangePos = m_Direction == e_Direction.Vertical ? pos.y : pos.x;
                if (IsOutRange(rangePos))
                {
                    if (obj != null)
                    {
                        SetPoolsObj(obj);
                        m_CellInfos[i].obj = null;
                    }
                }
                else
                {
                    if (obj == null)
                    {
                        ULuaPanelItem cell = GetPoolsObj();
                        cell.transform.localPosition = pos;
                        cell.gameObject.name = i.ToString();
                        m_CellInfos[i].obj = cell;

                        Func(OnLoopGridValueChanged, cell);
                    }
                }
            }
        }

        protected bool IsOutRange(float pos)
        {
            Vector3 listP = m_ContentRectTrans.anchoredPosition;
            if (m_Direction == e_Direction.Vertical)
            {
                if (pos + listP.y > m_CellObjectHeight || pos + listP.y < -rectTrans.rect.height)
                {
                    return true;
                }
            }
            else
            {
                if (pos + listP.x < -m_CellObjectWidth || pos + listP.x > rectTrans.rect.width)
                {
                    return true;
                }
            }
            return false;
        }

        protected Stack<ULuaPanelItem> poolsObj = new Stack<ULuaPanelItem>();
        protected virtual ULuaPanelItem GetPoolsObj()
        {
            ULuaPanelItem cell = null;
            if (poolsObj.Count > 0)
            {
                cell = poolsObj.Pop();
            }

            if (cell == null)
            {
                GameObject _itemObj = Instantiate(m_CellGameObject) as GameObject;
                cell = _itemObj.GetComponent<ULuaPanelItem>();
                cell.BuildControl();

                RectTransform rect = cell.transform as RectTransform;
                PanelMgr.AddUIChild(rect, m_Content.transform as RectTransform);

                cell.OnCreate();
                cell.OnOpen();
            }

            cell.gameObject.SetActive(true);

            return cell;
        }

        protected virtual void SetPoolsObj(ULuaPanelItem cell)
        {
            if (cell != null)
            {
                poolsObj.Push(cell);
                cell.gameObject.SetActive(false);
            }
        }

        protected void Func(Action<ILuaPanelItem, int> func, ULuaPanelItem selectObject, bool isUpdate = false)
        {
            int num = int.Parse(selectObject.name) + 1;
            if (func != null)
            {
                func(selectObject.LuaPanelItem, num);
            }

        }

        public void DisposeAll()
        {
            OnLoopGridValueChanged = null;
            m_CellInfos = null;
            poolsObj.Clear();
        }

        protected void OnDestroy()
        {
            DisposeAll();
        }

        protected void OnDragListener(Vector2 value)
        {
            if (!m_IsShowArrow) return;
            float normalizedPos = m_Direction == e_Direction.Vertical ? m_ScrollRect.verticalNormalizedPosition : m_ScrollRect.horizontalNormalizedPosition;
            if (true)
            {

            }
            if (m_Direction == e_Direction.Vertical)
            {
                if (m_ContentHeight - rectTrans.rect.height < 10)
                {
                    m_PointingFirstArrow.SetActive(false);
                    m_PointingEndArrow.SetActive(false);
                    return;
                }
            }
            else
            {
                if (m_ContentWidth - rectTrans.rect.width < 10)
                {
                    m_PointingFirstArrow.SetActive(false);
                    m_PointingEndArrow.SetActive(false);
                    return;
                }
            }

            if (normalizedPos >= 0.9)
            {
                m_PointingFirstArrow.SetActive(false);
                m_PointingEndArrow.SetActive(true);
            }
            else if (normalizedPos <= 0.1)
            {
                m_PointingFirstArrow.SetActive(true);
                m_PointingEndArrow.SetActive(false);
            }
            else
            {
                m_PointingFirstArrow.SetActive(true);
                m_PointingEndArrow.SetActive(true);
            }
        }

    }

}