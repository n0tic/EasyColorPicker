using System;
using System.Collections.Generic;

namespace EasyColorPicker.Data
{
    [Serializable]
    public class PalletData
    {
        /// <summary>
        /// Pallet name
        /// </summary>
        public string Name { get; set; } = "";

        // Saved color list
        private List<string> savedColors = new List<string>();

        /// <summary>
        /// Return name
        /// </summary>
        /// <returns></returns>
        public string GetName() => Name;

        /// <summary>
        /// Set name and save pallet data.
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.Name = name;

            Core.SavePallet(EasyColorPickerForm.instance.settings.GetSavePath(), this);
        }

        /// <summary>
        /// Return saved color list
        /// </summary>
        /// <returns></returns>
        public List<string> GetSavedColorsList() => savedColors;

        /// <summary>
        /// Add color to list and save pallet data.
        /// </summary>
        /// <param name="newColor"></param>
        public void AddSavedColor(string newColor)
        {
            savedColors.Add(newColor);

            Core.SavePallet(EasyColorPickerForm.instance.settings.GetSavePath(), this);
        }

        /// <summary>
        /// Remove saved color from list and save pallet data.
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool RemoveSavedColor(string match)
        {
            var tmp = savedColors.Remove(match);
            if (tmp)
            {
                Core.SavePallet(EasyColorPickerForm.instance.settings.GetSavePath(), this);
                return tmp;
            }
            return false;
        }

        /// <summary>
        /// Set new list of colors and save pallet data.
        /// </summary>
        /// <param name="savedColors"></param>
        public void SetSavedColors(List<string> savedColors)
        {
            this.savedColors = savedColors;

            Core.SavePallet(EasyColorPickerForm.instance.settings.GetSavePath(), this);
        }
    }
}