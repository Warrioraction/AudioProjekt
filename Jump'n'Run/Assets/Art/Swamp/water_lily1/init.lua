dirname = path.dirname(__file__)

world:new_immovable_type{
   name = "water_lily1",
   descname = _ "Water Lily",
   editor_category = "miscellaneous",
   size = "none",
   attributes = {},
   programs = {},
   animations = {
      idle = {
         pictures = path.list_files(dirname .. "idle_??.png"),
         hotspot = { 9, 3 },
      },
   }
}