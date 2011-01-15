namespace LibFrobulous
open System;
open System.Diagnostics;
open Microsoft.Xna.Framework;
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open System.Collections.Generic

   
type public Orb(target : IEntity, _radius : float32) as this =
    let radius = _radius
    let mutable angle = 0.0f
    let mutable position = new Vector2(radius * float32(Math.Cos(float(angle))), radius * float32(Math.Sin(float(angle))))
    let mutable center = fun () -> new Vector2(0.0f,0.0f)
    do
        this.Orbit target

    new(target : IEntity) = Orb(target, 30.0f)
    member this.Position
        with set(_position : Vector2) =
                position <- _position
    

    member this.Tick(gameTime:GameTime) =
        angle <- angle + float32 gameTime.ElapsedGameTime.TotalMilliseconds * 0.18f
        position <- new Vector2(radius * float32(Math.Cos(float(angle))), radius * float32(Math.Sin(float(angle)))) + center()
//        Trace.WriteLine(String.Format("{0} {1}", "tick", position))

    member this.Orbit(entity : IEntity) =
        center <- fun () -> entity.Position


    interface IEntity with
        member this.Position
            with get() = position
