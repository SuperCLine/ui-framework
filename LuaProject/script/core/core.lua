supercline.classes = {}

local function Construct(cls, obj, ...)
    if cls.super then
        Construct(cls.super, obj, ...)
    end

    if cls.Ctor then
        cls.Ctor(obj, ...)
    end
end

local function class(classname, super)
    assert(classname, "class name is null.")
    assert(not supercline.classes[classname], "duplicate class name: "..classname)

    local cls = {}
    cls.classname = classname
    cls.super = super
    cls.Ctor = false
    
    local vtbl = {}
    cls.vtbl = vtbl

    cls.obj_meta = 
    {
        __index = vtbl,
        __newindex = function (tb, k, v)
            local val = v or "nil"
            print("instance don't allow to add field."..cls.classname.."["..k.."]="..tostring(val))
        end
    }

    cls.New = function (...)
        local obj = {}
        obj.classname = cls.classname
        Construct(cls,obj,...)
        setmetatable(obj, cls.obj_meta)
        return obj
    end

    setmetatable(cls, 
    {
        __newindex = function (tb, k, v)
            if type(v) ~= "function" then
                print("not a funton")
                return
            end
            tb.vtbl[k] = v
        end
    })

    if super then
        setmetatable(vtbl, {
            __index = function (_, k)
                local val = super.vtbl[k]
                vtbl[k] = val
                return val
            end
        })
    end

    supercline.classes[classname] = cls
    return cls
end

return class