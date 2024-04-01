using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LearningWithSato;

// the animation class will break down a spritesheet into frames
public class PlayerAnimation
{  
    // need a spritesheet with frames
    public Texture2D playerSpriteSheet;

    // the number of frames
    int numFrames;

    // a counter to iterate through the frames
    int frameCounter = 0;

    // a float to keep track of time elapsed between frames
    float timeSinceLastFrame = 0;

    // constructor that takes the player spritesheet
    // we also take the width of a frame, this will be needed to split the frames
    public PlayerAnimation(Texture2D playerSpriteSheet, float frameWidth)
    {
        this.playerSpriteSheet = playerSpriteSheet;
        numFrames = (int)(playerSpriteSheet.Width/frameWidth);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, GameTime gameTime, float millisecondsPerFrame=100)
    {
        // iterate through the number of frames
        if (frameCounter < numFrames)
        {
            // get frame using rectangle
            var spriteFrameRect = new Rectangle(x: frameCounter*32, y: 0,
                                                height: 32, width: 32);

            spriteBatch.Draw(texture: playerSpriteSheet,
                            position: position,
                            sourceRectangle: spriteFrameRect,
                            color: color,
                            rotation: rotation,
                            origin: new Vector2(16,24),
                            scale: Vector2.One,
                            effects: SpriteEffects.None,
                            layerDepth: 0);

            timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {   
                // we can do millisecondsPerFrame = 0, but it is better to
                timeSinceLastFrame -= millisecondsPerFrame;
                frameCounter++;
                if (frameCounter == numFrames)
                {
                    frameCounter = 0;
                }
            }
        }
    }
}
