using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ICS4U_Monogame_4
{
    public class Star
    {
        private Rectangle _location;
        private Texture2D _texture;
        private Vector2 _speed;
        private Random _generator;

        public Star(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _location = location;
            _texture = texture;
            _speed = speed;
            _generator = new Random();

        }

        public Star(Texture2D texture, Rectangle frame)
        {
            _generator = new Random();

            double sizeProbability = _generator.NextDouble();
            int size;
            _texture = texture;

            if (sizeProbability < 0.1)
                size = 3;
            else if (sizeProbability < 0.3)
                size = 2;
            else
                size = 1;


            _location = new Rectangle(_generator.Next(frame.Width), _generator.Next(frame.Height), size, size);
            _speed = new Vector2(-size, 0);    
        }

        public void Update(Rectangle frame, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _location.Offset(_speed * 2);
            }
            else
            {
                _location.Offset(_speed);
            }

            if (_location.X < 0)
            {
                _location.X = frame.Width;
                _location.Y = _generator.Next(frame.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color starColor)
        {
            spriteBatch.Draw(_texture, _location, starColor);
        }
    }

    
}
