using System.Collections;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LearningWithSato;

public class Player
{
    // player needs to have a texture
    private Texture2D playerSprite;

    // player needs to have a position (vector2)
    public Vector2 position;

    // if we want to change the colour we need to define here
    private Color color = Color.White;

    private Color customColor = new Color(100,105,150);
    private bool isRed = false;

    // player needs to have a rotation variable in order to rotate and stuff
    private float rotation;

    // player should have an animation class
    

    // needs a constructor
    public Player(Texture2D spriteSheet, Vector2 position)
    {
        playerSprite = spriteSheet;
        this.position = position;

        // great way to display certain elements/variables onscreen for debug, but uses up a lot of memory
        Debug.WriteLine("Player created");
    }

    public void Update(GameTime gameTime)
    {
        if(Keyboard.GetState().IsKeyDown(Keys.D))
            position.X += 1;
        if(Keyboard.GetState().IsKeyDown(Keys.A))
            position.X -= 1;
        if(Keyboard.GetState().IsKeyDown(Keys.W))
            position.Y -= 1;
        if(Keyboard.GetState().IsKeyDown(Keys.S))
            position.Y += 1;
        if(Keyboard.GetState().IsKeyDown(Keys.R))
            rotation += 0.1f;

        // change color if key pressed
        if(Keyboard.GetState().IsKeyDown(Keys.Q))
            isRed = !isRed;

        // you should have an input manager class to know whether we are holding key
        if(isRed)
            color = Color.Red;
        else
            color = Color.White;
    }

    // Draw needs to have spriteBatch as a parameter to draw anything
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture: playerSprite,
                         position: position,
                         sourceRectangle: new Rectangle(0,0,32,32),
                         color: color,
                         rotation: rotation,
                         origin: new Vector2(16,24),
                         scale: Vector2.One,
                         effects: SpriteEffects.None,
                         layerDepth: 0);
    }
}
