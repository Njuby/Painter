using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Painter
{
    
    public class Painter : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static GameWorld gameWorld;
        InputHelper inputHelper;

        //get color from cannon
        /*static public Color colortype { get 
            { 
                return gameWorld.Cannon.Color; 
            }
                }
                */

        


        public Painter()
        {
            IsMouseVisible = true;
           
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        static public GameWorld GameWorld { get { return gameWorld; } }

    
        protected override void Initialize()
        {
            inputHelper = new InputHelper();
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            gameWorld.HandleInput(inputHelper);
            inputHelper.Update();
            base.Update(gameTime);
            
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            gameWorld = new GameWorld(this.Content);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            gameWorld.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
