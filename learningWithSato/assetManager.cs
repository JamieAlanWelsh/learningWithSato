

using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LearningWithSato;

// for loading and managing assets
public static class assetManager
{
    public static Dictionary<string, Texture2D> textures;
    public static Dictionary<string, SpriteFont> fonts;


   

    public static void load_textures(ContentManager contentManager)
    {
        textures = new Dictionary<string, Texture2D>();
        List<string> textureNames = new List<string>()
        {
            "Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)",
            "Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)",
            "Sprite Pack 4\\8 - Roach_Hurt (32 x 32)"
        };

        foreach(string textureName in textureNames)
        {
            textures.Add(textureName, contentManager.Load<Texture2D>(textureName));
        }
    } 
    public static void load_fonts(ContentManager contentManager)
    {
        fonts = new Dictionary<string, SpriteFont>();
        List<string> fontNames = new List<string>()
        {
            "BaseFont"
        };

        foreach(string fontName in fontNames)
        {
            fonts.Add(fontName, contentManager.Load<SpriteFont>(fontName));
        }
    } 
}
