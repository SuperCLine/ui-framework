local PanelLoginItem = supercline.class("PanelLoginItem", supercline.PanelBase)

function PanelLoginItem:Ctor(transform, gameObject)
    
    self.ui = {}
end

function PanelLoginItem:OnOpen(controls)

    self.ui.Text = controls:get_Item("Text_Item")
    self.ui.Button = controls:get_Item("Button_Item")
end

function PanelLoginItem:OnClose()

end

function PanelLoginItem:OnShow()
    
end

function PanelLoginItem:OnHide()

end

function PanelLoginItem:OnClick(btn)

    print(string.format("<color=cyan> PanelLoginItem:OnClick: %s </color>", btn.name))

    supercline.Singleton.PanelMgr:GetPanel(supercline.Prefab.PanelLogin).LoopGridLogin:ShowList(10)
end

function PanelLoginItem:SetData(index)
    self.ui.Text.text = index
    self.ui.Button.name = index
end

return PanelLoginItem