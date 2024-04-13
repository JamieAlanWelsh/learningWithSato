using System.Collections;
using System.Diagnostics;
using System.Windows.Markup;
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

    // this is an array of animations
    public PlayerAnimation[] playerAnimation;
    // these are our player states
    public enum currentState { idle, run, }
    // we use this to represent whatever state the player is in
    public currentState playerAnimationController;
    // we use this to represent whatever animation is currently playing
    public PlayerAnimation currentAnimation; 

    // used to turn sprite around
    public SpriteEffects spriteEffects = SpriteEffects.None;

    public Rectangle hitbox;

    public Vector2 prevPosition;


    // needs a constructor
    public Player(Vector2 position)
    {
        this.position = position;

        // we will cycle through our array of player animations using enum states
        playerAnimation = new PlayerAnimation[2];
        playerAnimation[0] = new PlayerAnimation(assetManager.textures["Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)"], 32);
        playerAnimation[1] = new PlayerAnimation(assetManager.textures["Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)"], 32);
        currentAnimation = playerAnimation[0];
        // playerAnimationController = currentState.idle;

        hitbox = new Rectangle((int)position.X-16, (int)position.Y-24, 32, 32);

        // great way to display certain elements/variables onscreen for debug, but uses up a lot of memory
        Debug.WriteLine("Player created");
    }

    // pressing keys will update the player state and dictate the animation
    public void Update(GameTime gameTime, Collider collider)
    {
        KeyboardState keyboard=Keyboard.GetState();

        // prevPosition = position;

        // hitbox = new Rectangle((int)position.X-16, (int)position.Y-16, 32, 32);

        playerAnimationController = currentState.idle;

        float changeX = 0;

        // UPDATE X POSITION
        if(keyboard.IsKeyDown(Keys.D))
        {
            // position.X += speed;
            changeX += speed;
            playerAnimationController = currentState.run;
            spriteEffects = SpriteEffects.None;
        }
        if(keyboard.IsKeyDown(Keys.A))
        {
            // position.X -= speed;
            changeX -= speed;
            playerAnimationController = currentState.run;
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
        position.X += changeX;
        hitbox.X += (int)changeX;

        // check for X collisions
        if (collider.hitbox.Intersects(hitbox))
        {
            // position = prevPosition;
            position.X -= changeX;
            hitbox.X -= (int)changeX;
            Debug.WriteLine("COLLISION!");
        }

        // UPDATE Y POSITION
        float changeY = 0;
        if(keyboard.IsKeyDown(Keys.W))
        {
            // position.Y -= speed;
            changeY -= speed;
            playerAnimationController = currentState.run;
        }
        if(keyboard.IsKeyDown(Keys.S))
        {
            // position.Y += speed;
            changeY += speed;
            playerAnimationController = currentState.run;
        }
        position.Y += changeY;
        hitbox.Y += (int)changeY;

        // check for Y collisions
        if (collider.hitbox.Intersects(hitbox))
        {
            // position = prevPosition;
            position.Y -= changeY;
            hitbox.Y -= (int)changeY;
            Debug.WriteLine("COLLISION!");
        }

        // rotate if R is held
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

        // control animations
        switch (playerAnimationController)
        {
            case currentState.idle:
                currentAnimation = playerAnimation[0];
                break;
            case currentState.run:
                currentAnimation = playerAnimation[1];
                break;
        }
    }

    // Draw needs to have spriteBatch as a parameter to draw anything
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        currentAnimation.Draw(spriteBatch, position, color, rotation, gameTime, spriteEffects: spriteEffects);
        Primitives.DrawRectangle(spriteBatch, hitbox, Color.Red);
    }
}
