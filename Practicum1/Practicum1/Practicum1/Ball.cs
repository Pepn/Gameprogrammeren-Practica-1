using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Practicum1
{
    class Ball : Object
    {
        Random random = new Random();
        double direction, speed;
        
        public Ball(Texture2D sprite, Vector2 position, double speed)
            : base(sprite, position)
        {
            direction = random.NextDouble()*2*Math.PI;
            this.speed = 175;
            
        }
        public override void Update(GameTime gameTime)
        {
            velocity.X = (float)(speed * Math.Cos(direction));
            velocity.Y = (float)(speed * Math.Sin(direction));
            
            if((position.Y < 0 && direction > Math.PI && direction < 2*Math.PI)
                || (position.Y > Practicum1.Screen.Y-sprite.Height && direction < Math.PI && direction > 0))
            {
                Bounce();
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // debugging
            spriteBatch.DrawString(Practicum1.GameFont, "velocity: " + velocity, new Vector2(100, 60), Color.Black);
            spriteBatch.DrawString(Practicum1.GameFont, "position: " + position, new Vector2(100, 80), Color.Black);
            spriteBatch.DrawString(Practicum1.GameFont, "direction: " + direction, new Vector2(100, 100), Color.Black);
            base.Draw(gameTime, spriteBatch);
        }

        public void Bounce()
        {
            direction = 2 * Math.PI - direction;
        }
    }
}