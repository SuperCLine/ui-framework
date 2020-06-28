#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    
    public class UnityEnginePlayModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.PlayMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.PlayMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.PlayMode), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "StopSameLayer", UnityEngine.PlayMode.StopSameLayer);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "StopAll", UnityEngine.PlayMode.StopAll);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.PlayMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEnginePlayMode(L, (UnityEngine.PlayMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "StopSameLayer"))
                {
                    translator.PushUnityEnginePlayMode(L, UnityEngine.PlayMode.StopSameLayer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "StopAll"))
                {
                    translator.PushUnityEnginePlayMode(L, UnityEngine.PlayMode.StopAll);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.PlayMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.PlayMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineScreenOrientationWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.ScreenOrientation), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.ScreenOrientation), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.ScreenOrientation), L, null, 8, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Portrait", UnityEngine.ScreenOrientation.Portrait);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PortraitUpsideDown", UnityEngine.ScreenOrientation.PortraitUpsideDown);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LandscapeLeft", UnityEngine.ScreenOrientation.LandscapeLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LandscapeRight", UnityEngine.ScreenOrientation.LandscapeRight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutoRotation", UnityEngine.ScreenOrientation.AutoRotation);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Landscape", UnityEngine.ScreenOrientation.Landscape);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.ScreenOrientation), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineScreenOrientation(L, (UnityEngine.ScreenOrientation)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Portrait"))
                {
                    translator.PushUnityEngineScreenOrientation(L, UnityEngine.ScreenOrientation.Portrait);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PortraitUpsideDown"))
                {
                    translator.PushUnityEngineScreenOrientation(L, UnityEngine.ScreenOrientation.PortraitUpsideDown);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LandscapeLeft"))
                {
                    translator.PushUnityEngineScreenOrientation(L, UnityEngine.ScreenOrientation.LandscapeLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LandscapeRight"))
                {
                    translator.PushUnityEngineScreenOrientation(L, UnityEngine.ScreenOrientation.LandscapeRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoRotation"))
                {
                    translator.PushUnityEngineScreenOrientation(L, UnityEngine.ScreenOrientation.AutoRotation);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Landscape"))
                {
                    translator.PushUnityEngineScreenOrientation(L, UnityEngine.ScreenOrientation.Landscape);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.ScreenOrientation!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.ScreenOrientation! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineTouchPhaseWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.TouchPhase), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.TouchPhase), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.TouchPhase), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Began", UnityEngine.TouchPhase.Began);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Moved", UnityEngine.TouchPhase.Moved);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Stationary", UnityEngine.TouchPhase.Stationary);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ended", UnityEngine.TouchPhase.Ended);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Canceled", UnityEngine.TouchPhase.Canceled);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.TouchPhase), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineTouchPhase(L, (UnityEngine.TouchPhase)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Began"))
                {
                    translator.PushUnityEngineTouchPhase(L, UnityEngine.TouchPhase.Began);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Moved"))
                {
                    translator.PushUnityEngineTouchPhase(L, UnityEngine.TouchPhase.Moved);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Stationary"))
                {
                    translator.PushUnityEngineTouchPhase(L, UnityEngine.TouchPhase.Stationary);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ended"))
                {
                    translator.PushUnityEngineTouchPhase(L, UnityEngine.TouchPhase.Ended);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Canceled"))
                {
                    translator.PushUnityEngineTouchPhase(L, UnityEngine.TouchPhase.Canceled);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.TouchPhase!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.TouchPhase! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineEventTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.EventType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.EventType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.EventType), L, null, 33, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MouseDown", UnityEngine.EventType.MouseDown);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MouseUp", UnityEngine.EventType.MouseUp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MouseMove", UnityEngine.EventType.MouseMove);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MouseDrag", UnityEngine.EventType.MouseDrag);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "KeyDown", UnityEngine.EventType.KeyDown);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "KeyUp", UnityEngine.EventType.KeyUp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScrollWheel", UnityEngine.EventType.ScrollWheel);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Repaint", UnityEngine.EventType.Repaint);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layout", UnityEngine.EventType.Layout);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DragUpdated", UnityEngine.EventType.DragUpdated);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DragPerform", UnityEngine.EventType.DragPerform);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DragExited", UnityEngine.EventType.DragExited);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ignore", UnityEngine.EventType.Ignore);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Used", UnityEngine.EventType.Used);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ValidateCommand", UnityEngine.EventType.ValidateCommand);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ExecuteCommand", UnityEngine.EventType.ExecuteCommand);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ContextClick", UnityEngine.EventType.ContextClick);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MouseEnterWindow", UnityEngine.EventType.MouseEnterWindow);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MouseLeaveWindow", UnityEngine.EventType.MouseLeaveWindow);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.EventType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineEventType(L, (UnityEngine.EventType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "MouseDown"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.MouseDown);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MouseUp"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.MouseUp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MouseMove"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.MouseMove);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MouseDrag"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.MouseDrag);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "KeyDown"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.KeyDown);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "KeyUp"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.KeyUp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScrollWheel"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.ScrollWheel);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Repaint"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.Repaint);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layout"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.Layout);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DragUpdated"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.DragUpdated);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DragPerform"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.DragPerform);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DragExited"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.DragExited);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ignore"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.Ignore);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Used"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.Used);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ValidateCommand"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.ValidateCommand);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ExecuteCommand"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.ExecuteCommand);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ContextClick"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.ContextClick);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MouseEnterWindow"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.MouseEnterWindow);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MouseLeaveWindow"))
                {
                    translator.PushUnityEngineEventType(L, UnityEngine.EventType.MouseLeaveWindow);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.EventType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.EventType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}