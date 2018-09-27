using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpriteClass
{
    class Sprite
    {
        private Texture2D texture;
        private Vector2 position;
        public List<Sprite> sprites;

        
        public Sprite(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;
        }

        public List<Sprite> getSprites
        {
            get
            {
                return sprites;
            }
        }
            

        public void Draw(SpriteBatch spriteBatch, List<Sprite> sprites)
           
        {
            foreach (var item in sprites)
            {
                spriteBatch.Draw(texture, item.position, Color.White);
            }

            
        }
    }
}
