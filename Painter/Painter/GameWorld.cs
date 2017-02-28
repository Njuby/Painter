using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;


namespace Painter
{
    
    class GameWorld
    {
        public Texture2D background;

        ///////////////
        public GameWorld(ContentManager contentmanager)
        {
            background = contentmanager.Load<Texture2D>("spr_background");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }

    
}
