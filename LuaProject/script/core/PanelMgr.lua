local cPanelMgr = CS.CAE.Core.PanelMgr.Instance
local PanelMgr = supercline.class("PanelMgr")

function PanelMgr:Ctor()

    self.panels = {}
end

function PanelMgr:Open(prefabPath, show)
    if self.panels[prefabPath] then
        print(string.format("PanelMgr:Open//%s is exist.", prefabPath))
        return
    end

    self.panels[prefabPath] = {}

    cPanelMgr:Open(prefabPath, show)
end

function PanelMgr:Close(prefabPath)
    if not self.panels[prefabPath] then
        print(string.format("PanelMgr:Close//%s not exist.", prefabPath))
        return
    end

    cPanelMgr:Close(prefabPath)

    self.panels[prefabPath] = nil
end

function PanelMgr:Show(prefabPath)
    if not self.panels[prefabPath] then
        print(string.format("PanelMgr:Show//%s not exist.", prefabPath))
        return
    end

    cPanelMgr:Show(prefabPath)
end

function PanelMgr:Hide(prefabPath)
    if not self.panels[prefabPath] then
        print(string.format("PanelMgr:Hide//%s not exist.", prefabPath))
        return
    end

    cPanelMgr:Hide(prefabPath)
end

function PanelMgr:GetPanel(prefabPath)
    if not self.panels[prefabPath] then
        print(string.format("PanelMgr:GetPanel//%s not exist.", prefabPath))
        return
    end

    return self.panels[prefabPath].Instance
end


-- lua interface
function PanelMgr:NewPanel(panelName, prefabPath, transform, gameObject)

    assert(supercline.classes[panelName], "unknown panel class: "..panelName)

    local cls = supercline.classes[panelName]
    local obj = cls.New(transform, gameObject)
    
    self.panels[prefabPath].Instance = obj
end

function PanelMgr:NewPanelItem(itemName, transform, gameObject)

    assert(supercline.classes[itemName], "unknown panel item class: "..itemName)

    local cls = supercline.classes[itemName]
    local obj = cls.New(transform, gameObject)

    return obj
end

function PanelMgr:OnOpen(prefabPath, controls)
    self.panels[prefabPath].Instance:OnOpen(controls)
end

function PanelMgr:OnShow(prefabPath)
    self.panels[prefabPath].Instance:OnShow()
end

function PanelMgr:OnHide(prefabPath)
    self.panels[prefabPath].Instance:OnHide()
end

function PanelMgr:OnClose(prefabPath)
    self.panels[prefabPath].Instance:OnClose()
end


function PanelMgr:OnClick(prefabPath, btn)
    self.panels[prefabPath].Instance:OnClick(btn)
end

function PanelMgr:OnInputValueChanged(prefabPath, input, val)
    self.panels[prefabPath].Instance:OnInputValueChanged(input, val)
end

function PanelMgr:OnInputEndEdit(prefabPath, input, val)
    self.panels[prefabPath].Instance:OnInputEndEdit(input, val)
end

function PanelMgr:OnToggleValueChanged(prefabPath, tog, val)
    self.panels[prefabPath].Instance:OnToggleValueChanged(tog, val)
end

function PanelMgr:OnSliderValueChanged(prefabPath, slider, val)
    self.panels[prefabPath].Instance:OnSliderValueChanged(slider, val)
end

function PanelMgr:OnLoopGridValueChanged(prefabPath, grid, item, index)
    self.panels[prefabPath].Instance:OnLoopGridValueChanged(grid, item, index)
end

function PanelMgr:OnDown(prefabPath, go)
    self.panels[prefabPath].Instance:OnDown(go)
end

function PanelMgr:OnUp(prefabPath, go)
    self.panels[prefabPath].Instance:OnUp(go)
end

function PanelMgr:OnEnter(prefabPath, go)
    self.panels[prefabPath].Instance:OnEnter(go)
end

function PanelMgr:OnExit(prefabPath, go)
    self.panels[prefabPath].Instance:OnExit(go)
end

function PanelMgr:OnLongPress(prefabPath, go)
    self.panels[prefabPath].Instance:OnLongPress(go)
end

function PanelMgr:OnLongPressEnd(prefabPath, go)
    self.panels[prefabPath].Instance:OnLongPressEnd(go)
end

function PanelMgr:OnDragStart(prefabPath, go, eventData)
    self.panels[prefabPath].Instance:OnDragStart(go, eventData)
end

function PanelMgr:OnDrag(prefabPath, go, eventData)
    self.panels[prefabPath].Instance:OnDrag(go, eventData)
end

function PanelMgr:OnDragEnd(prefabPath, go, eventData)
    self.panels[prefabPath].Instance:OnDragEnd(go, eventData)
end

function PanelMgr:Main()
    supercline.Singleton.PanelMgr:Open(supercline.Prefab.PanelLogin, true)
end

return PanelMgr