print("------------- init lua -------------")

supercline = {}
supercline.Prefab = {}

require("script.util.LuaPanda").start("127.0.0.1",8818);
require("script.cs")
require("script.load")
require("script.bridge")