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
        /// <summary>
        /// Application name
        /// </summary>
        public static string Name { get; private set; } = "Easy Color Picker";

        /// <summary>
        /// Save settings data
        /// </summary>
        /// <param name="data"></param>
        public static void SaveSettings(Settings data)
        {
            // Initialize filestream
            using (FileStream dataStream = new FileStream("settings", FileMode.Create))
            {
                // Create formatter
                BinaryFormatter converter = new BinaryFormatter();

                // Try converting and saving.
                try { converter.Serialize(dataStream, data); }
                catch (ArgumentNullException x) { MessageBox.Show(x.Message); }
                catch (SerializationException x) { MessageBox.Show(x.Message); }
                catch (SecurityException x) { MessageBox.Show(x.Message); }
            }
        }

        /// <summary>
        /// Load settings data
        /// </summary>
        /// <returns></returns>
        public static Settings LoadSettings()
        {
            if (File.Exists("settings"))
            {
                // Initialize filestream
                using (FileStream dataStream = new FileStream("settings", FileMode.Open))
                {
                    try
                    {
                        // Create formatter
                        BinaryFormatter converter = new BinaryFormatter();
                        // Try converting and setting.
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

        /// <summary>
        /// Save pallet data
        /// </summary>
        /// <param name="savepath"></param>
        /// <param name="data"></param>
        public static void SavePallet(string savepath, PalletData data)
        {
            // Initialize filestream
            using (FileStream dataStream = new FileStream(savepath, FileMode.Create))
            {
                // Create formatter
                BinaryFormatter converter = new BinaryFormatter();
                try
                {
                    // Try converting and saving.
                    converter.Serialize(dataStream, data);
                }
                catch (ArgumentNullException x) { MessageBox.Show(x.Message); }
                catch (SerializationException x) { MessageBox.Show(x.Message); }
                catch (SecurityException x) { MessageBox.Show(x.Message); }
            }
        }

        /// <summary>
        /// Load pallet data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Load<T>(string path)
        {
            if (File.Exists(path))
            {
                // Initialize filestream
                using (FileStream dataStream = new FileStream(path, FileMode.Open))
                {
                    try
                    {
                        // Create formatter
                        BinaryFormatter converter = new BinaryFormatter();
                        // Try converting and setting.
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