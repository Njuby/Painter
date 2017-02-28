using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Painter
{
    class Cannon : ThreeColorGameObject
    {
        protected Texture2D cannonBarrel;
        protected float angle;        //////
        //give color to barrel and draw the sprite(color)
        public Cannon(ContentManager content)
        : base(content.Load<Texture2D>("spr_cannon_red"),
        content.Load<Texture2D>("spr_cannon_green"),
        content.Load<Texture2D>("spr_cannon_blue"))
        {
            cannonBarrel = content.Load<Texture2D>("spr_cannon_barrel");
            position = new Vector2(72, 405);
        }
        //draw the barrel using the overwrite function
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cannonBarrel, position, null, Color.White, angle,
            new Vector2(34, 34), 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(currentColor, position - new Vector2(currentColor.Width,
            currentColor.Height) / 2, Color.White);
        }

    }
}
