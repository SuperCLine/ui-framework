local PanelLogin = supercline.class("PanelLogin", supercline.PanelBase)

function PanelLogin.Prefab()
    return "/Prefabs/UI/PanelLogin.prefab"
end

function PanelLogin:Ctor(transform, gameObject)
    
end

function PanelLogin:OnOpen(controls)
    
    supercline.cDebug.Log("<color=yellow> all control </color>")
    for _, v in pairs(controls) do
        print(string.format("<color=cyan> %s </color>", v.gameObject.name))
    end
end

function PanelLogin:Awake()
    print("<color=yellow>PanelLogin awake</color>")
end

function PanelLogin:OnEnable()
    
end

function PanelLogin:Start()

end

function PanelLogin:OnDisable()
    
end

function PanelLogin:OnDestroy()
    
end

function PanelLogin:OnClick(btn)
    print(string.format("<color=yellow>%s clicked.</color>", btn.gameObject.name))
end

function PanelLogin:OnInputEndEdit(input, val)
    print(string.format("<color=yellow>%s input end, val %s.</color>", input.gameObject.name, val))
end

return PanelLogin