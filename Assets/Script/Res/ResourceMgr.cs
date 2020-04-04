/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\Res\ResourceMgr.cs
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
    using System;
    using UnityEngine;

    public sealed class ResourceMgr
    {
        private IResourceMgr mMgr = null;
        public static ResourceMgr Instance { get; } = Activator.CreateInstance<ResourceMgr>();

        public void Init()
        {
#if UNITY_EDITOR
            mMgr = NativeResourceMgr.Instance;
#else
            mMgr = ABResourceMgr.Instance;
#endif

        }

        public void Destroy()
        {
            mMgr = null;
        }

        public GameObject LoadGameObject(string path)
        {
            return mMgr.LoadAsset<GameObject>(path);
        }

        public TextAsset LoadTextAsset(string path)
        {
            return mMgr.LoadAsset<TextAsset>(path);
        }

    }
}