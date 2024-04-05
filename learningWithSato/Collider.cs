using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LearningWithSato;

public class Collider
{
    Rectangle hitbox;
    Texture2D texture;

    public Collider(Rectangle hitbox)
    {
        texture = assetManager.textures["Sprite Pack 4\\8 - Roach_Hurt (32 x 32)"];
        this.hitbox = hitbox;
    }

    public void Update(Player player)
    {
        if (player.hitbox.Intersects(hitbox))
        {
            Debug.WriteLine("COLLISION!");
        }
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, new Vector2(hitbox.X, hitbox.Y), Color.White);
        Primitives.DrawRectangle(spriteBatch, hitbox, Color.Red);
    }
}
