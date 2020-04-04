/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\Res\Native\NativeResourceMgr.cs
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
    using System.IO;
    using UnityEditor;
    using System.Collections.Generic;

#if UNITY_EDITOR
    public sealed class NativeResourceMgr : IResourceMgr
    {
        public static NativeResourceMgr Instance { get; } = Activator.CreateInstance<NativeResourceMgr>();

        public void Init()
        {

        }

        public void Destroy()
        {

        }

        public T LoadAsset<T>(string path) where T : UnityEngine.Object
        {
            string assetPath = ResHelper.GetAssetFullPath(path);
            T obj = AssetDatabase.LoadAssetAtPath<T>(assetPath);

            return obj;
        }

        public UnityEngine.Object LoadAsset(string path, Type type)
        {
            string assetPath = ResHelper.GetAssetFullPath(path);
            return AssetDatabase.LoadAssetAtPath(assetPath, type);
        }

    }
#endif

}