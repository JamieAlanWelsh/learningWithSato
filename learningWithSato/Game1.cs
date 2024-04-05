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

    public Player player;

    public Collider collider;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        Window.IsBorderless = true;
        _graphics.IsFullScreen = false;
        // below code needed for shaders etc
        // _graphics.ApplyChanges();
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
        
        assetManager.load_textures(Content);
        assetManager.load_fonts(Content);

        player = new Player(new Vector2(100,100));

        collider = new Collider(new Rectangle(300,150,32,32));
    }

    // runs once every tick (constantly)
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Update(gameTime);
        collider.Update(player);

        base.Update(gameTime);
    }

    // runs once every tick (constantly)
    // draw your textures/images/effects to the screen
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // sampler state point clamp makes pixel art sharp
        _spriteBatch.Begin(transformMatrix: Matrix.CreateScale(4), samplerState: SamplerState.PointClamp);

        player.Draw(_spriteBatch, gameTime);
        collider.Draw(_spriteBatch);

        _spriteBatch.End();
        
        _spriteBatch.Begin();

        // drawing text to the screen can be useful for texting and debugging
        _spriteBatch.DrawString(assetManager.fonts["BaseFont"], player.position.ToString(), Vector2.One, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}