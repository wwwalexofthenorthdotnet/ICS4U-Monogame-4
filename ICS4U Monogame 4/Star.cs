using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Star(Texture2D texture, Rectangle window)
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


            _location = new Rectangle(_generator.Next(window.Width), _generator.Next(window.Height), size, size);
            _speed = new Vector2(-size, 0);    
        }

        public void Update(Rectangle window)
        {
            
            _location.Offset(_speed);
            if (_location.X < 0)
            {
                _location.X = window.Width + 5;
                _location.Y = _generator.Next(window.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color starColor)
        {
            spriteBatch.Draw(_texture, _location, starColor);
        }
    }

    
}
