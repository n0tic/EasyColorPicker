using EasyColorPicker.Data;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Windows.Forms;

namespace EasyColorPicker
{
    public static class Core
    {
        public static string Name { get; private set; } = "Easy Color Picker";

        public static void SaveSettings(Settings data)
        {
            using (FileStream dataStream = new FileStream("settings", FileMode.Create))
            {
                BinaryFormatter converter = new BinaryFormatter();

                try { converter.Serialize(dataStream, data); }
                catch (ArgumentNullException x) { MessageBox.Show(x.Message); }
                catch (SerializationException x) { MessageBox.Show(x.Message); }
                catch (SecurityException x) { MessageBox.Show(x.Message); }
            }
        }

        public static Settings LoadSettings()
        {
            if (File.Exists("settings"))
            {
                using (FileStream dataStream = new FileStream("settings", FileMode.Open))
                {
                    try
                    {
                        BinaryFormatter converter = new BinaryFormatter();
                        Settings data = converter.Deserialize(dataStream) as Settings;
                        return data;
                    }
                    catch (ArgumentNullException x) { MessageBox.Show(x.Message); return null; }
                    catch (SerializationException x) { MessageBox.Show("Settings data is corrupt and could not be loaded.\n\rSettings file will automatically be overwritten on next save. \n\r\n\r" + x.Message, "Load Data Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
                    catch (SecurityException x) { MessageBox.Show(x.Message); return null; }
                }
            }
            else return null;
        }

        public static void SavePallet(string savepath, PalletData data)
        {
            using (FileStream dataStream = new FileStream(savepath, FileMode.Create))
            {
                BinaryFormatter converter = new BinaryFormatter();
                try
                {
                    converter.Serialize(dataStream, data);
                }
                catch (ArgumentNullException x) { MessageBox.Show(x.Message); }
                catch (SerializationException x) { MessageBox.Show(x.Message); }
                catch (SecurityException x) { MessageBox.Show(x.Message); }
            }
        }

        public static T Load<T>(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream dataStream = new FileStream(path, FileMode.Open))
                {
                    try
                    {
                        BinaryFormatter converter = new BinaryFormatter();
                        T data = (T)converter.Deserialize(dataStream);
                        return data;
                    }
                    catch (ArgumentNullException x) { MessageBox.Show(x.Message); return default; }
                    catch (SerializationException x) { MessageBox.Show("Saved pallet data is corrupt and could not be loaded.\n\rCould not load data. \n\r\n\r" + x.Message, "Load Data Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return default; }
                    catch (SecurityException x) { MessageBox.Show(x.Message); return default; }
                }
            }
            else return default;
        }
    }
}