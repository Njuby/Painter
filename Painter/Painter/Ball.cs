using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Painter
{
    public class Ball : ThreeColorGameObject
    {
        protected bool shooting;
        protected SoundEffect ballShot;
        public Ball(ContentManager Content)
        : base(Content.Load<Texture2D>("spr_ball_red"),
        Content.Load<Texture2D>("spr_ball_green"),
        Content.Load<Texture2D>("spr_ball_blue"))
        {
            ballShot = Content.Load<SoundEffect>("snd_shoot_paint");
        }        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed() && !shooting)
            {
                //when fired
                shooting = true;
                //go towards position with 1.2f speed
                velocity = (inputHelper.MousePosition - position) * 1.2f;
                //shoot ball
                ballShot.Play();
                //adjust color to color of the cannon
                Color = Painter.GameWorld.Cannon.Color;
            }
        }        public override void Reset()
        {
            base.Reset();
            velocity = Vector2.Zero;
            position = new Vector2(65, 390);
            shooting = false;
        }        public override void Update(GameTime gameTime)
        {
            if (shooting)
            {
                velocity.X *= 0.99f;
                velocity.Y += 6;
            }

            if (Painter.GameWorld.IsOutsideWorld(position))
            {
                Reset();
            }

            base.Update(gameTime);
        }
    }
}
