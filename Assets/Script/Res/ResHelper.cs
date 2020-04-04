/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Script\Res\ResHelper.cs
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
    using System.IO;

    public static class ResHelper
    {
        public static string RootResource
        {
            get { return "assets/resource"; }
        }

        public static string RootMedia
        {
            get { return "assets/media"; }
        }

        public static string RootCurrent
        {
            get { return Directory.GetCurrentDirectory() + "/"; }
        }

        public static string GetAssetRelativePath(string name)
        {
            string formatName = name.ToLower();
            return formatName.Replace(RootResource, "");
        }

        public static string GetAssetFullPath(string name)
        {
            return RootResource + name;
        }

    }
}