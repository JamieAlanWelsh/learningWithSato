using System;
using System.Data;
using System.Diagnostics;
using System.Net.Security;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LearningWithSato;

public class Map
{
    public Texture2D tileSet;
    public int mapSize;
    public Rectangle[] grassTiles;
    public int[,] mapArray;
    private Random r;

    public Map()
    {
        r = new Random();
        tileSet = assetManager.textures["Sato Assets\\tileset"];
        mapSize = 30;
        mapArray = new int[mapSize, mapSize];

        grassTiles = new Rectangle[4];
        grassTiles[0] = new Rectangle(224,16,16,16);
        grassTiles[1] = new Rectangle(240,16,16,16);
        grassTiles[2] = new Rectangle(224,32,16,16);
        grassTiles[3] = new Rectangle(240,32,16,16);

        for(int x=0; x < mapSize; x++)
        {
            for(int y=0; y < mapSize; y++)
            {
                int i = r.Next(4); 
                mapArray[x,y] = i; 
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for(int x=0; x < mapSize; x++)
        {
            for(int y=0; y < mapSize; y++)
            {
                spriteBatch.Draw(tileSet, new Rectangle(x*16,y*16,16,16), grassTiles[mapArray[x,y]], Color.White);
                // spriteBatch.DrawString(assetManager.fonts["BaseFont"], mapArray[x,y].ToString(), new Vector2(x*16,y*16), Color.White);
            }
        }
    }
}