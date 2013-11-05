using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Other
{
    public class AtlasBuilder: ScriptableWizard
    {
        public int quantity = 4;
        public Texture2D[] images = new Texture2D[16];
        public WWW img;
        public bool forceSquare = false;

        [MenuItem("AtlasBuilder/Create/Sprite Atlas")]
        public static void SpriteAtlas()
        {
            ScriptableWizard.DisplayWizard("Create Sprite Atlas", typeof(AtlasBuilder), "Create");
        }

        public void OnEnable() { }

        public void OnWizardCreate()
        {
            if (images.Length == 0)
            {
                EditorUtility.DisplayDialog("Result", "No images were selected", "Ok");
            }

            for (int i = 0; i < images.Length; i++)
            {
                Texture2D img = images[i];
                if (img == null)
                {
                    img = new Texture2D(0, 0, TextureFormat.RGB24, false);
                    img.Apply();
                }
            }

            Texture2D outTexture = new Texture2D(0, 0, TextureFormat.RGB24, false);
            outTexture.PackTextures(images, 0, 1024);

            Texture2D forcedSquareTexture = null;
            if (forceSquare)
            {
                if (outTexture.width < outTexture.height)
                {
                    Texture2D temptex = new Texture2D(outTexture.height - outTexture.width, outTexture.height, TextureFormat.RGB24, false);
                    forcedSquareTexture = new Texture2D(0, 0, TextureFormat.RGB24, false);
                    forcedSquareTexture.PackTextures(new Texture2D[] { outTexture, forcedSquareTexture }, 0, 1024);
                }
                else if (outTexture.width > outTexture.height)
                {
                    Texture2D temptex = new Texture2D(outTexture.width, outTexture.width - outTexture.height, TextureFormat.RGB24, false);
                    forcedSquareTexture = new Texture2D(0, 0, TextureFormat.RGB24, false);
                    forcedSquareTexture.PackTextures(new Texture2D[] { outTexture, forcedSquareTexture }, 0, 1024);
                }
                else
                {
                    forcedSquareTexture = null;
                }
            }
            if (outTexture == null)
            {
                EditorUtility.DisplayDialog("Error", "There was a problem creating the atlas.", "Ok");
                return;
            }

            string outPath = EditorUtility.SaveFilePanel("Where would you like to save the new sprite atlas?", Application.dataPath, "SpriteAtlas.png", "png");
            FileStream fs = new FileStream(outPath, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            if (forcedSquareTexture != null)
            {
                w.Write(forcedSquareTexture.EncodeToPNG());
            }
            else
            {
                w.Write(outTexture.EncodeToPNG());
            }

            w.Close();
            fs.Close();

            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Result", "Texture was saved successfully.", "Ok");
        }

        public void OnWizardUpdate()
        {
            helpString = "Please select all the images that will make up the sprite atlas.";
            KeepCurrentSelection();
        }

        private void KeepCurrentSelection()
        {
            if (quantity == images.Length)
                return;

            Texture2D[] tmp_images = new Texture2D[quantity];
            int total_quantity_to_copy = images.Length > quantity ? quantity : images.Length;
            for (int i = 0; i < total_quantity_to_copy; i++)
            {
                tmp_images[i] = images[i];
            }
            images = tmp_images;
        }
    }
}