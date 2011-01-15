namespace LibFrobulous

open Microsoft.Xna.Framework

type IAttractor =
    abstract member Attract : 'a -> (GameTime -> unit)
