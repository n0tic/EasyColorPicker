using System;

namespace EasyColorPicker.Data
{
    [Serializable]
    public class Settings
    {
        private string path = "";

        public enum ColorType
        {
            RGB,
            HTML
        }

        private ColorType colorType = ColorType.RGB;

        #region Color

        public ColorType GetColorType() => colorType;

        public void SetColorType(ColorType colorType)
        {
            this.colorType = colorType;

            Core.SaveSettings(this);
        }

        #endregion Color

        #region Path

        public string GetSavePath() => path;

        public void SetSavePath(string path)
        {
            this.path = path;

            Core.SaveSettings(this);
        }

        #endregion Path
    }
}