using System.Collections;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LearningWithSato;

public class Player
{
    // player needs to have a position and speed
    public Vector2 position;
    public float speed = 2;

    // if we want to change the colour we need to define here
    private Color color = Color.White;
    private bool isRed = false;

    // player needs to have a rotation variable in order to rotate and stuff
    private float rotation;

    // Needs an array of animations, and a state controller
    public PlayerAnimation[] playerAnimation;
    public enum currentAnimation { idle, run }
    public currentAnimation playerAnimationController;


    // needs a constructor
    public Player(Texture2D idleSprite, Texture2D runSprite, Vector2 position)
    {
        this.position = position;

        // we will cycle through our array of player animations using enum states
        playerAnimation = new PlayerAnimation[2];
        playerAnimation[0] = new PlayerAnimation(idleSprite, 32);
        playerAnimation[1] = new PlayerAnimation(runSprite, 32);

        // great way to display certain elements/variables onscreen for debug, but uses up a lot of memory
        Debug.WriteLine("Player created");
    }

    // pressing keys will update the player state and dictate the animation
    public void Update(GameTime gameTime)
    {
        KeyboardState keyboard=Keyboard.GetState();

        playerAnimationController = currentAnimation.idle;

        if(keyboard.IsKeyDown(Keys.D))
        {
            position.X += speed;
            playerAnimationController = currentAnimation.run;
        }
        if(keyboard.IsKeyDown(Keys.A))
        {
            position.X -= speed;
            playerAnimationController = currentAnimation.run;
        }
        if(keyboard.IsKeyDown(Keys.W))
        {
            position.Y -= speed;
            playerAnimationController = currentAnimation.run;
        }
        if(keyboard.IsKeyDown(Keys.S))
        {
            position.Y += speed;
            playerAnimationController = currentAnimation.run;
        }
        if(keyboard.IsKeyDown(Keys.R))
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
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        // the update function will update the animation state, but we need to draw it here
        switch (playerAnimationController)
        {
            case currentAnimation.idle:
                playerAnimation[0].Draw(spriteBatch, position, color, rotation, gameTime);
                break;
            case currentAnimation.run:
                playerAnimation[1].Draw(spriteBatch, position, color, rotation, gameTime);
                break;
        }
        
    }
}
