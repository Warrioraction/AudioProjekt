dirname = path.dirname(__file__)

world:new_immovable_type{
   name = "water_lily7",
   descname = _ "Water Lily",
   editor_category = "miscellaneous",
   size = "none",
   attributes = {},
   programs = {},
   animations = {
      idle = {
         pictures = path.list_files(dirname .. "idle_??.png"),
         hotspot = { 29, 17 },
      },
   }
}
