﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Painter
{
    public class Cannon : ThreeColorGameObject
    {
        protected Texture2D cannonBarrel;
        protected float angle;                //////
        //give color to barrel and draw the sprite(color)
        public Cannon(ContentManager content)
        : base(content.Load<Texture2D>("spr_cannon_red"),
        content.Load<Texture2D>("spr_cannon_green"),
        content.Load<Texture2D>("spr_cannon_blue"))
        {
            cannonBarrel = content.Load<Texture2D>("spr_cannon_barrel");
            currentColor = colorBlue;
            position = new Vector2(72, 405);
            
        }

        public override void HandleInput(InputHelper inputHelper)
        {

            if (inputHelper.KeyPressed(Keys.R))
                Color = Color.Red;
            else if (inputHelper.KeyPressed(Keys.G))
                Color = Color.Green;
            else if (inputHelper.KeyPressed(Keys.B))
                Color = Color.Blue;

            double opposite = inputHelper.MousePosition.Y - position.Y;
            double adjacent = inputHelper.MousePosition.X - position.X;
            angle = (float)Math.Atan2(opposite, adjacent);
        }

        //draw the barrel using the overwrite function
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cannonBarrel, position, null, Color.White, angle, new Vector2(34, 34), 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(currentColor, position - new Vector2(currentColor.Width,currentColor.Height) / 2, Color.White);
        }
        //overrite reset emthode
        public override void Reset()
        {
            base.Reset();
            angle = 0f;
        }
        //bereken bal startpunt
        public Vector2 BallPosition
        {
            get
            {
                float opposite = (float)Math.Sin(angle) * cannonBarrel.Width * 0.6f;
                float adjacent = (float)Math.Cos(angle) * cannonBarrel.Width * 0.6f;
                return position + new Vector2(adjacent, opposite);
            }
        }
    }
}
