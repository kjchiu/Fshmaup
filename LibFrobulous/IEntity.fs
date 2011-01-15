namespace LibFrobulous

open Microsoft.Xna.Framework
type IEntity =
    abstract member Position : Vector2
        with get