/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\GameManager.cs
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

    public sealed class GameManager : MonoBehaviour
    {
        private static GameManager ms_instance = null;
        public static GameManager Instance
        {
            get { return ms_instance; }
        }

        private void Awake()
        {
            ms_instance = this;
            DontDestroyOnLoad(gameObject);

            ResourceMgr.Instance.Init();

            UIMgr.Instance.Init();

            PanelMgr.Instance.Init();
            LuaMgr.Instance.Init();
            
        }

        private void OnEnable()
        {

        }

        private void Start()
        {
            
        }

        private void OnDisable()
        {

        }

        private void OnDestroy()
        {
            PanelMgr.Instance.Destroy();
            LuaMgr.Instance.Destroy();

            UIMgr.Instance.Destroy();
            ResourceMgr.Instance.Destroy();
        }

        private void FixedUpdate()
        {

        }

        private void Update()
        {

        }

        private void LateUpdate()
        {

        }

        private void OnApplicationPause(bool pause)
        {

        }

        private void OnApplicationFocus(bool focus)
        {

        }

        private void OnApplicationQuit()
        {
            ms_instance = null;
        }
    }
}