using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LearningWithSato;

// the animation class will break down a spritesheet into frames
public class playerAnimation
{  
    // need a spritesheet with frames
    public Texture2D playerSpriteSheet;

    // the number of frames
    int numFrames;

    // a counter to iterate through the frames
    int frameCounter = 0;

    // constructor that takes the player spritesheet
    // we also take the width of a frame, this will be needed to split the frames
    public playerAnimation(Texture2D spriteSheet, float frameWidth)
    {
        numFrames = (int)(spriteSheet.Width/frameWidth);
        spriteSheet = playerSpriteSheet;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        // iterate through the number of frames
        if (frameCounter < numFrames)
        {
            // get frame using rectangle
            var spriteFrameRect = new Rectangle(x: 32*frameCounter,
                                                y: 0,
                                                height: 32,
                                                width: 32);

            spriteBatch.Draw(texture: playerSpriteSheet,
                             position: position,
                             sourceRectangle: spriteFrameRect,
                             color: Color.White
                             );

            frameCounter++;
        }
    }
}
