/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Editor\LuaBinder.cs
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
    using System.Collections.Generic;
    using XLua;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public static class LuaBinder
    {
        [LuaCallCSharp]
        public static List<Type> LuaCallCSharp = new List<Type>()
        {
            // Unity
            typeof(object),
            typeof(UnityEngine.Mathf),
            typeof(UnityEngine.Object),
            typeof(Application),
            typeof(GameObject),
            typeof(Component),
            typeof(Behaviour),
            typeof(Transform),
            typeof(Vector2),
            typeof(Vector3),
            typeof(Vector4),
            typeof(Quaternion),
            typeof(Resources),
            typeof(TextAsset),
            typeof(Renderer),
            typeof(Collider),
            typeof(BoxCollider),
            typeof(BoxCollider2D),
            typeof(MeshRenderer),
            typeof(Bounds),
            typeof(Texture),
            typeof(Texture2D),
            typeof(RenderTexture),
            typeof(Color),
            typeof(PlayerPrefs),
            typeof(Time),
            typeof(Input),
            typeof(Collider2D),
            typeof(Animation),
            typeof(PlayMode),
            typeof(AnimationCurve),
            typeof(ParticleSystem),
            typeof(ParticleSystem.MainModule),
            typeof(ParticleSystem.ShapeModule),
            typeof(SkinnedMeshRenderer),
            typeof(Camera),
            typeof(Screen),
            typeof(ScreenOrientation),
            typeof(Animator),
            typeof(RaycastHit),
            typeof(Material),
            typeof(Texture),
            typeof(Texture2D),
            typeof(MaterialPropertyBlock),
            //
            typeof(SpriteRenderer),
            typeof(Sprite),
            typeof(Input),
            typeof(TouchPhase),
            typeof(Touch),
            typeof(Application),
            typeof(Camera),
            typeof(GameObject),
            typeof(UnityEngine.Object),
            typeof(UnityEngine.Random),
            typeof(RectTransform),
            typeof(Image),
            typeof(Text),
            typeof(Button),
            typeof(UnityAction),
            typeof(UnityEvent),
            typeof(UnityEvent<bool>),
            typeof(UnityEvent<float>),
            typeof(Toggle),
            typeof(Toggle.ToggleEvent),
            typeof(Canvas),
            typeof(GraphicRaycaster),
            typeof(Slider),
            typeof(ScrollRect),
            typeof(InputField),
            typeof(CanvasGroup),
            typeof(AnimationCurve),
            typeof(Animation),
            typeof(AnimatorControllerParameter),
            typeof(TextMesh),
            typeof(ParticleSystem),
            typeof(ParticleSystemRenderer),

            typeof(Physics),
            typeof(Ray),
            typeof(RaycastHit),
            typeof(Physics2D),
            typeof(Ray2D),
            typeof(RaycastHit2D),
            typeof(ValueType),
            typeof(PointerEventData),

            typeof(PlayerPrefs),
            typeof(BoxCollider2D),
            typeof(Bounds),
            typeof(UnityEngine.Event),
            typeof(EventType),
            typeof(Mathf),
            typeof(System.DateTime),
            typeof(Ray),
            typeof(RaycastHit),

            typeof(UnityEvent<PointerEventData>),
            typeof(UnityEventBase),
            typeof(UnityEvent),
            typeof(Slider.SliderEvent),

            typeof(PanelMgr),
            typeof(UILoopGrid),

        };

        [CSharpCallLua]
        public static List<Type> CSharpCallLua = new List<Type>()
        {
            typeof(Action),
            typeof(Action<int>),
            typeof(Action<float>),
            typeof(Action<bool>),
            typeof(Action<string>),
            typeof(Action<int, string>),
            typeof(System.Action<int,bool>),
            typeof(Action<bool,float>),
            typeof(Action<Vector2>),
            typeof(Action<Collider,Vector3>),
            typeof(UnityAction<int>),
            typeof(UnityAction<bool>),
            typeof(UnityAction<int,int>),
            typeof(UnityAction<float>),
            typeof(UnityAction<PointerEventData>),
            typeof(Action<UnityEngine.Object,UnityEngine.Object>),
            typeof(Action<string, Texture>),
            typeof(Action<string, Transform>),
            typeof(Action<string,string>),

            typeof(NewLuaPanelMgr),
            typeof(ILuaPanelItem),
            typeof(ILuaPanelMgr),
        };

        [BlackList]
        public static List<List<string>> BlackList = new List<List<string>>()
        {
            new List<string>{"UnityEngine.Texture2D", "alphaIsTransparency"},
            new List<string>{"UnityEngine.Input", "IsJoystickPreconfigured","System.String"},
            new List<string>{"UnityEngine.Texture", "imageContentsHash"},
            new List<string>{"UnityEngine.UI.Text","OnRebuildRequested"},
            new List<string>{"UnityEngine.UI.Graphic","OnRebuildRequested"},
            new List<string>{ "UnityEngine.AnimatorControllerParameter", "name"},
            new List<string>{ "UnityEngine.WWW", "GetMovieTexture"},
            new List<string>{ "RenderHeads.Media.AVProVideo.MediaPlayer", "GetPlatformOptions"},
            new List<string>{ "RenderHeads.Media.AVProVideo.MediaPlayer", "GetPlatformOptionsVariable"}
        };
    }

}