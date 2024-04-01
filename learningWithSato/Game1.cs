using System.Globalization;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LearningWithSato;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D playerSpriteIdle;
    private Texture2D playerSpriteRun;

    private SpriteFont baseFont;

    public Player player;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    // runs once when the game starts
    // for loading contents such as textures and stuff and classes
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        playerSpriteIdle = Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)");
        playerSpriteRun = Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)");

        baseFont = Content.Load<SpriteFont>("BaseFont");

        player = new Player(playerSpriteIdle, playerSpriteRun, new Vector2(100,100));
    }

    // runs once every tick (constantly)
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Update(gameTime);

        base.Update(gameTime);
    }

    // runs once every tick (constantly)
    // draw your textures/images/effects to the screen
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        player.Draw(_spriteBatch, gameTime);

        // drawing text to the screen can be useful for texting and debugging
        _spriteBatch.DrawString(baseFont, player.position.ToString(), Vector2.One, Color.White);

        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
