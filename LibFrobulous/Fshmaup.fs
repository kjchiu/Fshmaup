namespace LibFrobulous

open System;
open System.Diagnostics;
open Microsoft.Xna.Framework;
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open System.Collections.Generic

   
   



type public Fshmaup() as this = 
    inherit Microsoft.Xna.Framework.Game()

    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = null
    

    let mutable texture = null
    let mutable player = new Player(0.0f)
    let worldOrbs = new List<Orb>()

    do
        this.Content.RootDirectory <- "Content"
        

    override Game.LoadContent() =
        spriteBatch <- new SpriteBatch(this.GraphicsDevice)
        player <- new Player(0.0f)
        texture <- this.Content.Load<Texture2D>("bullet")

    member this.HandleInput(key : Keys, gameTime : GameTime) =
        match key with
        | Keys.D ->
            player.Move(Direction.Right, gameTime)
        | Keys.A -> 
            player.Move(Direction.Left, gameTime)
        | Keys.W -> 
            player.Move(Direction.Up, gameTime)
        | Keys.S -> 
            player.Move(Direction.Down, gameTime)
        | Keys.Space ->
            let orb = new Orb(player)
            worldOrbs.Add(orb)
        | _ -> ()                     
    
    override this.Update(gameTime : GameTime) =        
        for key in Keyboard.GetState().GetPressedKeys() do
            this.HandleInput(key, gameTime)
        player.Tick(gameTime)
        
        for orb in worldOrbs do
            orb.Tick(gameTime)



    override this.Draw(gameTime : GameTime) =
        this.GraphicsDevice.Clear(Color.CornflowerBlue)
        spriteBatch.Begin()
        spriteBatch.Draw(texture, player.Position, Color.Black)
        for orb in player.Orbs do
            spriteBatch.Draw(texture, (orb :> IEntity).Position, Color.Red)
        for orb in worldOrbs do
            spriteBatch.Draw(texture, (orb :> IEntity).Position, Color.Green)
        spriteBatch.End()
        
        
    

            
    




   