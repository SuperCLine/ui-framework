local PanelMgr = supercline.class("PanelMgr")

function PanelMgr:Ctor()
    
    self.panels = {}
end

function PanelMgr:AwakePanel(panelName, transform, gameObject)
    
    assert(not self.panels[panelName], "duplicate panel: "..panelName)

    local cls = supercline.classes[panelName]
    local obj = cls.New(transform, gameObject)
    self.panels[panelName] = obj

    obj:Awake()
end

function PanelMgr:AwakePanelItem(itemName, transform, gameObject)

    local cls = supercline.classes[itemName]
    local obj = cls.New(transform, gameObject)

    obj:Awake()

    return obj
end

function PanelMgr:OnOpen(panelName, panelItem, controls)

    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnOpen(controls)
    else
        panelItem:OnOpen(controls)
    end
end

function PanelMgr:OnShow(panelName)
    self.panels[panelName]:OnShow()
end

function PanelMgr:OnHide(panelName)
    self.panels[panelName]:OnHide()
end

function PanelMgr:OnClose(panelName)
    self.panels[panelName]:OnClose()
end



function PanelMgr:OnEnable(panelName, panelItem)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnEnable()
    else
        panelItem:OnEnable()
    end
end

function PanelMgr:Start(panelName, panelItem)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:Start()
    else
        panelItem:Start()
    end
end

function PanelMgr:OnDisable(panelName, panelItem)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnDisable()
    else
        panelItem:OnDisable()
    end
end

function PanelMgr:OnDestroy(panelName, panelItem)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnDestroy()
    else
        panelItem:OnDestroy()
    end
end

function PanelMgr:OnClick(panelName, panelItem, btn)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnClick(btn)
    else
        panelItem:OnClick(btn)
    end
end

function PanelMgr:OnInputValueChanged(panelName, panelItem, input, val)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnInputValueChanged(input, val)
    else
        panelItem:OnInputValueChanged(input, val)
    end
end

function PanelMgr:OnInputEndEdit(panelName, panelItem, input, val)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnInputEndEdit(input, val)
    else
        panelItem:OnInputEndEdit(input, val)
    end
end

function PanelMgr:OnToggleValueChanged(panelName, panelItem, tog, val)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnToggleValueChanged(tog, val)
    else
        panelItem:OnToggleValueChanged(tog, val)
    end
end

function PanelMgr:OnSliderValueChanged(panelName, panelItem, slider, val)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnSliderValueChanged(slider, val)
    else
        panelItem:OnSliderValueChanged(slider, val)
    end
end

function PanelMgr:OnDown(panelName, panelItem, go)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnDown(go)
    else
        panelItem:OnDown(go)
    end
end

function PanelMgr:OnUp(panelName, panelItem, go)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnUp(go)
    else
        panelItem:OnUp(go)
    end
end

function PanelMgr:OnEnter(panelName, panelItem, go)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnEnter(go)
    else
        panelItem:OnEnter(go)
    end
end

function PanelMgr:OnExit(panelName, panelItem, go)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnExit(go)
    else
        panelItem:OnExit(go)
    end
end

function PanelMgr:OnLongPress(panelName, panelItem, go)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnLongPress(go)
    else
        panelItem:OnLongPress(go)
    end
end

function PanelMgr:OnLongPressEnd(panelName, panelItem, go)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnLongPressEnd(go)
    else
        panelItem:OnLongPressEnd(go)
    end
end

function PanelMgr:OnDragStart(panelName, panelItem, go, eventData)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnDragStart(go, eventData)
    else
        panelItem:OnDragStart(go, eventData)
    end
end

function PanelMgr:OnDrag(panelName, panelItem, go, eventData)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnDrag(go, eventData)
    else
        panelItem:OnDrag(go, eventData)
    end
end

function PanelMgr:OnDragEnd(panelName, panelItem, go, eventData)
    if panelName ~= "" and panelItem == nil then
        self.panels[panelName]:OnDragEnd(go, eventData)
    else
        panelItem:OnDragEnd(go, eventData)
    end
end

function PanelMgr:Main()
    -- supercline.cPanelMgr.Open(supercline.PanelLogin.Prefab())
    supercline.cPanelMgr:Open("/Prefabs/UI/PanelLogin.prefab")
end

return PanelMgr