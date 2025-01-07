using System;
using System.Collections;
using UnityEngine;


    public static class SaveScreenShotRemake 
    {
        [HideInInspector] public static string spriteBase64String;

        public static string ConvertSprToBase64(Sprite sprite, string str)
        {
            Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height, TextureFormat.ARGB32, false);
            texture.SetPixels(sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                      (int)sprite.textureRect.y,
                                                      (int)sprite.textureRect.width,
                                                      (int)sprite.textureRect.height));
            texture.Apply();
            byte[] bytes = texture.EncodeToPNG();
            spriteBase64String = System.Convert.ToBase64String(bytes);
            PlayerPrefs.SetString(str, spriteBase64String);
            return spriteBase64String;
        }

        public static Sprite ConvertBase64ToSprite(string base64String, float pixelsPerUnit = 100f)
        {
            if (base64String == null)
                return null;
            else
            {
                var texture = Base64ToTexture2D(base64String);
                Rect rec = new Rect(0, 0, texture.width, texture.height);
                Sprite spr = Sprite.Create(texture, rec, new Vector2(0, 0), 1);
                return spr;
            }
        }
        public static Texture2D Base64ToTexture2D(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] texByte = System.Convert.FromBase64String(text);
                Texture2D tex = new Texture2D(380, 380);
                if (tex.LoadImage(texByte))
                {
                    return tex;
                }
            }
            return null;
        }

        private static IEnumerator TakeScreenShot()
        {
            yield return new WaitForEndOfFrame();
            Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
            Texture2D newScreenshot = new Texture2D(screenshot.width, screenshot.height, TextureFormat.RGB24, false);
            newScreenshot.SetPixels(screenshot.GetPixels());
            newScreenshot.Apply();
            Sprite screenshotSpriteShowed = Sprite.Create(newScreenshot, new Rect(0, 600, Screen.width, Screen.height * 0.4f), new Vector2(0.5f, 0.7f));
            ConvertSprToBase64(screenshotSpriteShowed, "PlayerPrefsString");
        }
    }

