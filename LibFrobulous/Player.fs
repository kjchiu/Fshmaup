namespace LibFrobulous

open System;
open System.Diagnostics;
open Microsoft.Xna.Framework;
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open System.Collections.Generic

type Direction =
    | Up = 1
    | Right = 2
    | Down = 3
    | Left = 4 

type public Player(x) as this = class
    
    let mutable position = new Vector2(x, 0.0f)
    let orbs = new List<Orb>([Orb(this);])


    member this.Orbs
        with get() = orbs :> IEnumerable<Orb>
    
    member this.Tick(gameTime:GameTime) =
        for orb in this.Orbs do
            orb.Tick(gameTime)

    member this.Position 
        with get() =
            position
        and set(value) =
            position <- value

    member this.Speed
        with get() = 0.10f

    member this.Move (dir : Direction, gameTime : GameTime) =
        match dir, gameTime with
        | Direction.Right, _ ->
            this.Position <- Vector2(this.Position.X + float32 gameTime.ElapsedGameTime.TotalMilliseconds * this.Speed, this.Position.Y)
        | Direction.Left, _ -> 
            this.Position <- Vector2(this.Position.X - float32 gameTime.ElapsedGameTime.TotalMilliseconds * this.Speed, this.Position.Y)
        | Direction.Up, _ -> 
            this.Position <- Vector2(this.Position.X, this.Position.Y - float32 gameTime.ElapsedGameTime.TotalMilliseconds * this.Speed)
        | Direction.Down, _ -> 
            this.Position <- Vector2(this.Position.X, this.Position.Y + float32 gameTime.ElapsedGameTime.TotalMilliseconds * this.Speed)
        | _,_ ->
            raise (InvalidOperationException("Unknown direction!"))

    interface IAttractor with
        member this.Attract(entity : 'a) =
            fun (gameTime : GameTime) -> ()

    interface IEntity with
        member this.Position
            with get() = this.Position
end