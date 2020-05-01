supercline.lua = {}

supercline.lua.PanelMgr = function ()
    
    supercline.Singleton.PanelMgr = supercline.PanelMgr.New()

    return supercline.Singleton.PanelMgr
end