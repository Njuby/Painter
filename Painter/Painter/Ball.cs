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
    class Ball : ThreeColorGameObject
    {
        protected bool shooting;
        protected SoundEffect ballShot;
        public Ball(ContentManager Content)
        : base(Content.Load<Texture2D>("spr_ball_red"),
        Content.Load<Texture2D>("spr_ball_green"),
        Content.Load<Texture2D>("spr_ball_blue"))
        {
            ballShot = Content.Load<SoundEffect>("snd_shoot_paint");
        }
    }
}
