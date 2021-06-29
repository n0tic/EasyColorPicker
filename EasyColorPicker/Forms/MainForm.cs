using EasyColorPicker.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace EasyColorPicker
{
    public partial class EasyColorPickerForm : Form
    {
        // Set this instance accessable from PalletData.
        public static EasyColorPickerForm instance = null;

        //Settings and pallet data
        public Settings settings;

        public PalletData pallet;

        // Global keyhandler (hook)
        private KeyHandler keyhandler;

        // Current color
        private Color color;

        // These are for selecting a pixel and resizing the captured imagepreview.
        private Point point = new Point();

        private const int zoomFactor = 4;
        private Size newSize = new Size((int)(100 * zoomFactor), (int)(100 * zoomFactor));

        // Constructor
        public EasyColorPickerForm()
        {
            InitializeComponent();

            //Set instance
            instance = this;

            //Load settings and pallet data
            LoadSettings();
            LoadPalletData();

            // This is to hide the horizontal scrollbar
            SavedColorsListView.Columns[0].Width = SavedColorsListView.Width - 22;

            // Register the hook / Global handler
            keyhandler = new KeyHandler(Keys.End, this);
            keyhandler.Register();

            // Start capture-timer
            CaptureTimer.Start();
        }

        /// <summary>
        /// Load settings data
        /// </summary>
        private void LoadSettings()
        {
            settings = Core.LoadSettings();

            if (settings == null) settings = new Settings();

            SetSettings();
        }

        /// <summary>
        /// Set data in application from settings data
        /// </summary>
        private void SetSettings()
        {
            ColorType.DataSource = Enum.GetValues(typeof(Settings.ColorType));
            ColorType.SelectedItem = settings.GetColorType();
        }

        /// <summary>
        /// Load pallet data
        /// </summary>
        private void LoadPalletData()
        {
            pallet = Core.Load<PalletData>(settings.GetSavePath());

            if (pallet == null) pallet = new PalletData();

            SetPalletData();
        }

        /// <summary>
        /// Set data in application from pallet data
        /// </summary>
        private void SetPalletData()
        {
            //Clear list
            SavedColorsListView.Items.Clear();

            //Set title
            if (pallet.GetName() != "") Text = $"{Core.Name} - {pallet.GetName()}";

            //Check if we have saved colors in the list
            if (pallet.GetSavedColorsList().Count > 0)
            {
                // Run this for each color in list
                foreach (var saved in pallet.GetSavedColorsList())
                {
                    //Temporary variable
                    var tmpColor = Color.FromArgb(0, 0, 0);

                    // If RGB
                    if (settings.GetColorType() == Settings.ColorType.RGB)
                    {
                        //Split string
                        string[] split = saved.Split(',');

                        //Remove whitespace (spaces)
                        for (int i = 0; i < split.Length; i++) split[i] = split[i].Trim();

                        try
                        {
                            //Try converting and setting color data
                            tmpColor = Color.FromArgb(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]));
                        }
                        catch { }
                    }
                    else if (settings.GetColorType() == Settings.ColorType.HTML) // If HTML
                    {
                        //Convert color
                        tmpColor = ColorTranslator.FromHtml(saved);
                    }

                    //Create item, update item.
                    ListViewItem item = new ListViewItem(saved);
                    SavedColorsListView.Items.Add(item);
                    SavedColorsListView.Items[SavedColorsListView.Items.Count - 1].BackColor = tmpColor;
                }
            }
        }

        /// <summary>
        /// Timer to update live preview box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            // Get color from cursor aimed pixel
            color = PixelColor.GetCursorPixelColor(sender, e);

            // Set caught color as color and text
            LivePreviewColorBox.BackColor = color;
            LivePreviewLabelBox.Text = ConvertColor(color, settings.GetColorType());

            // We dispose of the image (optimization)
            if (LivePreviewBox.Image != null)
                LivePreviewBox.Image.Dispose();

            //Update point with cursor position
            PixelColor.GetCursorPos(ref point);
            // Set rect size and position from cursor position.
            Rectangle rect = new Rectangle(point.X - 12, point.Y - 12, 100, 100);

            // Create initial bitmap
            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb))
            {
                //Create new bitmap with new size (zoom)
                using (Bitmap image = new Bitmap(bmp, newSize))
                {
                    // Update graphics with data captured from screen.
                    Graphics.FromImage(bmp).CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                    //Create crosshair on live preview box
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        bmp.SetPixel(i, 12, Color.Red);
                        bmp.SetPixel(12, i, Color.Red);
                    }

                    //Set bitmap data as image.
                    LivePreviewBox.Image = new Bitmap(bmp, newSize);
                }
            }

            // Clean up
            GC.Collect();
        }

        /// <summary>
        /// Convert color to string related to request
        /// </summary>
        /// <param name="color">Color Object</param>
        /// <param name="colorType">Enum Object</param>
        /// <returns>string</returns>
        private string ConvertColor(Color color, Settings.ColorType colorType)
        {
            switch (colorType)
            {
                case Settings.ColorType.RGB:
                    return $"{color.R}, {color.G}, {color.B}";

                case Settings.ColorType.HTML:
                    return ColorTranslator.ToHtml(color);

                default:
                    return $"{color.R}, {color.G}, {color.B}";
            }
        }

        /// <summary>
        /// Update data depending on selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavedColorsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check if there is any selection made
            if (SavedColorsListView.SelectedIndices.Count <= 0) return;

            // Grab selection
            int intselectedindex = SavedColorsListView.SelectedIndices[0];

            // Check if it has data
            if (intselectedindex >= 0)
            {
                // If RGB
                if (settings.GetColorType() == Settings.ColorType.RGB)
                {
                    //Split string
                    string[] split = SavedColorsListView.Items[intselectedindex].Text.Split(',');
                    //Remove whitespace (spaces)
                    for (int i = 0; i < split.Length; i++) split[i] = split[i].Trim();

                    try
                    {
                        //Set text
                        SelectedPreviewTextBox.Text = SavedColorsListView.Items[intselectedindex].Text;
                        //Try converting and setting color data
                        SelectedPreviewColorBox.BackColor = Color.FromArgb(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]));
                    }
                    catch { }
                }
                else if (settings.GetColorType() == Settings.ColorType.HTML) // If HTML
                {
                    try
                    {
                        //Set text
                        SelectedPreviewTextBox.Text = SavedColorsListView.Items[intselectedindex].Text;
                        //Try converting and setting color data
                        SelectedPreviewColorBox.BackColor = ColorTranslator.FromHtml(SavedColorsListView.Items[intselectedindex].Text);
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// If global hook fired - Run this
        /// </summary>
        private void HandleHotkey()
        {
            // Check if pallet is default - Force new pallet creation
            if (pallet.GetName() == "")
            {
                MessageBox.Show("To save colors the application needs a save file.", "No Save File!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NewPalletButton_Click(null, EventArgs.Empty); // Show new pallet dialogue
                return;
            }

            // Convert color
            var save = ConvertColor(color, settings.GetColorType());

            //Create item, update item.
            ListViewItem item = new ListViewItem(save);
            SavedColorsListView.Items.Add(item);
            SavedColorsListView.Items[SavedColorsListView.Items.Count - 1].BackColor = color;

            // Add new color to the list
            pallet.AddSavedColor(save);
        }

        /// <summary>
        /// Hook to catch key - Handle key
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            // Catch keybind - Handle function
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID) HandleHotkey();

            // Process message
            base.WndProc(ref m);
        }

        /// <summary>
        /// Clear SavedColorsListView items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearSavedColorsButton_Click(object sender, EventArgs e) => SavedColorsListView.Items.Clear();

        /// <summary>
        /// Delete selected color when delete button is detected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavedColorsListView_KeyDown(object sender, KeyEventArgs e)
        {
            // Detect delete key pressed while having a saved color selected.
            if (e.KeyCode == Keys.Delete)
            {
                // Check if we have a selection
                if (SavedColorsListView.SelectedIndices.Count <= 0) return;

                // Send removal request to pallet data
                pallet.RemoveSavedColor(SavedColorsListView.Items[SavedColorsListView.SelectedIndices[0]].Text);

                // Remove selected item from list
                if (SavedColorsListView.SelectedIndices[0] >= 0) SavedColorsListView.Items[SavedColorsListView.SelectedIndices[0]].Remove();
            }
        }

        /// <summary>
        /// Copy text from selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopySelectedColorsButton_Click(object sender, EventArgs e)
        {
            // Check if we have a saved color selected - Copy accessable
            if (SelectedPreviewTextBox.Text != "") Clipboard.SetText(SelectedPreviewTextBox.Text);
        }

        /// <summary>
        /// Unregister global hook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EasyColorPickerForm_FormClosed(object sender, FormClosedEventArgs e) => keyhandler.Unregiser();

        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e) => Environment.Exit(0);

        /// <summary>
        /// Convert color object to string
        /// </summary>
        /// <param name="i"></param>
        /// <param name="tmp"></param>
        /// <param name="colorType"></param>
        private void ConvertColorString(int i, Settings.ColorType tmp, Settings.ColorType colorType)
        {
            // Temporary color var
            var tmpColor = new Color();

            // If RGB
            if (tmp == Settings.ColorType.RGB)
            {
                // If HTML
                if (colorType == Settings.ColorType.HTML)
                {
                    //Split string
                    string[] split = SavedColorsListView.Items[i].Text.Split(',');
                    //Remove whitespace (spaces)
                    for (int x = 0; x < split.Length; x++) split[x] = split[x].Trim();

                    try
                    {
                        //Try converting and setting color data
                        tmpColor = Color.FromArgb(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]));
                    }
                    catch { }
                    SavedColorsListView.Items[i].Text = ColorTranslator.ToHtml(tmpColor);
                }
            }
            else if (tmp == Settings.ColorType.HTML)// If HTML
            {
                // If RGB
                if (colorType == Settings.ColorType.RGB)
                {
                    // Convert color
                    tmpColor = ColorTranslator.FromHtml(SavedColorsListView.Items[i].Text);
                    // Set text
                    SavedColorsListView.Items[i].Text = ConvertColor(tmpColor, colorType);
                }
            }
        }

        /// <summary>
        /// Update data related to selection of color type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Temporary color var
            var tmp = settings.GetColorType();

            // Change settings for selected color type
            settings.SetColorType((Settings.ColorType)Enum.Parse(typeof(Settings.ColorType), ColorType.SelectedItem.ToString()));

            // For each item in list, update to new type.
            for (int i = 0; i < SavedColorsListView.Items.Count; i++) ConvertColorString(i, tmp, settings.GetColorType());

            // Temporary list of colors
            List<string> tmpList = new List<string>();

            // Add information to list
            for (int i = 0; i < SavedColorsListView.Items.Count; i++)
            {
                tmpList.Add(SavedColorsListView.Items[i].Text);
            }

            // Update list
            pallet.SetSavedColors(tmpList);
        }

        /// <summary>
        /// Open new pallet data dialogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPalletButton_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog instance
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                // Limit filter to xpallet files
                sfd.Filter = "xpallet file (*.xpallet)|*.xpallet";

                // Show dialogue, expect OK result
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Set save path
                    settings.SetSavePath(sfd.FileName);

                    // Create new pallet
                    pallet = new PalletData();
                    // Update pallet name with the name of the file
                    pallet.SetName(Path.GetFileNameWithoutExtension(sfd.FileName));

                    // Clear list
                    SavedColorsListView.Items.Clear();

                    // Update title
                    Text = $"{Core.Name} - {pallet.GetName()}";
                }
            }
        }

        /// <summary>
        /// Open load pallet data file dialogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadPalletButton_Click(object sender, EventArgs e)
        {
            // Create a OpenFileDialog instance
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Limit filter to xpallet files
                ofd.Filter = "xpallet file (*.xpallet)|*.xpallet";

                // Show dialogue, expect OK result and file exist
                if (ofd.ShowDialog() == DialogResult.OK && ofd.CheckFileExists)
                {
                    // Set save path
                    settings.SetSavePath(ofd.FileName);

                    // Load pallet data
                    LoadPalletData();
                }
            }
        }

        /// <summary>
        /// Toggle always on top feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlwaysOnTopToggle_CheckedChanged(object sender, EventArgs e) => TopMost = AlwaysOnTopToggle.Checked;
    }
}