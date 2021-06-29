using System;

namespace EasyColorPicker.Data
{
    [Serializable]
    public class Settings
    {
        /// <summary>
        /// Pallet data path
        /// </summary>
        public string path { get; set; } = "";

        /// <summary>
        /// Color type
        /// </summary>
        public enum ColorType
        {
            RGB,
            HTML
        }

        //Color type
        private ColorType colorType = ColorType.RGB;

        /// <summary>
        /// Color related region
        /// </summary>
        /// <returns></returns>

        #region Color

        // Return ColorType
        public ColorType GetColorType() => colorType;

        // Set ColorType, save settings.
        public void SetColorType(ColorType colorType)
        {
            this.colorType = colorType;

            Core.SaveSettings(this);
        }

        #endregion Color

        /// <summary>
        /// Path related region
        /// </summary>
        /// <returns></returns>

        #region Path

        // Return path
        public string GetSavePath() => path;

        //// Set path, save settings.
        public void SetSavePath(string path)
        {
            this.path = path;

            Core.SaveSettings(this);
        }

        #endregion Path
    }
}