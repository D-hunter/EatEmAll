using UnityEngine;
using System.Xml.Linq;

namespace Assets.Scripts.Game.Sprites
{
    [ExecuteInEditMode]
    public class SpriteContainer : MonoBehaviour
    {
        public MySprite sprite = new MySprite();

        private void Start()
        {
        }

        private void Update()
        {
        }
    }


  
    [ExecuteInEditMode]
    [System.Serializable]
    public class MySprite
    {
        /// <summary>
        /// The description of the sprite-atlas frames.
        /// </summary>

        public string ContainerName;
        public Texture2D SpriteAtlas;
        public Object SpriteMeta;
        public SpritesMeta[] SpritesData;
    }

    
    [System.Serializable]
    public class SpritesMeta
    {
        /// <summary>
        /// The meta-description of the sprite.
        /// </summary>
        
        public string SpriteName;
        public Position Position;
        public Size Size;
    }

   
    [System.Serializable]
    public class Position
    {
        /// <summary>
        /// The position of the frame in sprite atlas.
        /// </summary>

        public int PositionX;
        public int PositionY;
    }

    
    [System.Serializable]
    public class Size
    {
        /// <summary>
        /// The size of current frame in sprite atlas.
        /// </summary>

        public int SizeX;
        public int SizeY;
    }
}