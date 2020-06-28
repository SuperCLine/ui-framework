/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\Res\AB\ABResourceMgr.cs
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

    public sealed class ABResourceMgr : IResourceMgr
    {
        public static ABResourceMgr Instance { get; } = Activator.CreateInstance<ABResourceMgr>();

        public void Init()
        {

        }

        public void Destroy()
        {

        }

        public T LoadAsset<T>(string path) where T : UnityEngine.Object
        {
            return null;
        }

        public UnityEngine.Object LoadAsset(string path, Type type)
        {
            return null;
        }

    }
}