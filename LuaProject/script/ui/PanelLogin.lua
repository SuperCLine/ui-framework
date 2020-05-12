local PanelLogin = supercline.class("PanelLogin", supercline.PanelBase)

supercline.Prefab.PanelLogin = "/Prefabs/UI/PanelLogin.prefab"

function PanelLogin:Ctor(transform, gameObject)
    
    self.LoopGridLogin = false
end

function PanelLogin:OnOpen(controls)
    
    supercline.cDebug.Log("<color=yellow> all control </color>")
    for _, v in pairs(controls) do
        print(string.format("<color=cyan> %s </color>", v.gameObject.name))
    end

    self.LoopGridLogin = controls:get_Item("LoopGrid_Login")
    self.LoopGridLogin:ShowList(20)
end

function PanelLogin:OnClose()
    print("<color=yellow>PanelLogin OnClose</color>")
end

function PanelLogin:OnShow()
    
end

function PanelLogin:OnHide()

end

function PanelLogin:OnClick(btn)
    print(string.format("<color=yellow>%s clicked.</color>", btn.gameObject.name))
end

function PanelLogin:OnInputEndEdit(input, val)
    print(string.format("<color=yellow>%s input end, val %s.</color>", input.gameObject.name, val))
end

function PanelLogin:OnLoopGridValueChanged(loopGrid, item, index)

    item:SetData(index)
end

return PanelLogin