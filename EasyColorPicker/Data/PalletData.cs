using System;
using System.Collections.Generic;

namespace EasyColorPicker.Data
{
    [Serializable]
    public class PalletData
    {
        private string name = "";
        private List<string> savedColors = new List<string>();

        public string GetName() => name;

        public void SetName(string name)
        {
            this.name = name;

            Core.SavePallet(EasyColorPickerForm.instance.settings.GetSavePath(), this);
        }

        public List<string> GetSavedColorsList() => savedColors;

        public void AddSavedColor(string newColor)
        {
            savedColors.Add(newColor);

            Core.SavePallet(EasyColorPickerForm.instance.settings.GetSavePath(), this);
        }

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

        public void SetSavedColors(List<string> savedColors)
        {
            this.savedColors = savedColors;

            Core.SavePallet(EasyColorPickerForm.instance.settings.GetSavePath(), this);
        }
    }
}