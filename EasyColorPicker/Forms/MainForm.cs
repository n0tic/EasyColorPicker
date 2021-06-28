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
        public static EasyColorPickerForm instance = null;

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

            instance = this;

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

        private void SetPalletData()
        {
            if (pallet.GetName() != "") Text = $"{Core.Name} - {pallet.GetName()}";
            if (pallet.GetSavedColorsList().Count > 0)
            {
                foreach (var saved in pallet.GetSavedColorsList())
                {
                    var tmpColor = Color.FromArgb(0, 0, 0);

                    if (settings.GetColorType() == Settings.ColorType.RGB)
                    {
                        string[] split = saved.Split(',');
                        for (int i = 0; i < split.Length; i++) split[i] = split[i].Trim();

                        try
                        {
                            tmpColor = Color.FromArgb(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]));
                        }
                        catch { }
                    }
                    else if (settings.GetColorType() == Settings.ColorType.HTML)
                    {
                        tmpColor = ColorTranslator.FromHtml(saved);
                    }

                    ListViewItem item = new ListViewItem(saved);
                    SavedColorsListView.Items.Add(item);
                    SavedColorsListView.Items[SavedColorsListView.Items.Count - 1].BackColor = tmpColor;
                }
            }
        }

        private void SetSettings()
        {
            ColorType.DataSource = Enum.GetValues(typeof(Settings.ColorType));
            ColorType.SelectedItem = settings.GetColorType();
        }

        private void LoadSettings()
        {
            settings = Core.LoadSettings();

            if (settings == null) settings = new Settings();

            SetSettings();
        }

        private void LoadPalletData()
        {
            pallet = Core.Load<PalletData>(settings.GetSavePath());

            if (pallet == null) pallet = new PalletData();

            SetPalletData();
        }

        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            color = PixelColor.GetCursorPixelColor(sender, e);
            LivePreviewColorBox.BackColor = color;
            LivePreviewLabelBox.Text = ConvertColor(color, settings.GetColorType());

            if (LivePreviewBox.Image != null)
                LivePreviewBox.Image.Dispose();

            PixelColor.GetCursorPos(ref point);
            Rectangle rect = new Rectangle(point.X - 12, point.Y - 12, 100, 100);

            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb))
            {
                using (Bitmap image = new Bitmap(bmp, newSize))
                {
                    Graphics.FromImage(bmp).CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                    for (int i = 0; i < bmp.Width; i++)
                    {
                        bmp.SetPixel(i, 12, Color.Red);
                        bmp.SetPixel(12, i, Color.Red);
                    }

                    LivePreviewBox.Image = new Bitmap(bmp, newSize);
                }
            }

            GC.Collect();
        }

        private string ConvertColor(Color color, Settings.ColorType colorType)
        {
            switch (colorType)
            {
                case Settings.ColorType.RGB: return $"{color.R}, {color.G}, {color.B}";
                case Settings.ColorType.HTML: return ColorTranslator.ToHtml(color);
                default: return $"{color.R}, {color.G}, {color.B}";
            }
        }

        private void SavedColorsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SavedColorsListView.SelectedIndices.Count <= 0) return;

            int intselectedindex = SavedColorsListView.SelectedIndices[0];

            if (intselectedindex >= 0)
            {
                if (settings.GetColorType() == Settings.ColorType.RGB)
                {
                    string[] split = SavedColorsListView.Items[intselectedindex].Text.Split(',');
                    for (int i = 0; i < split.Length; i++) split[i] = split[i].Trim();

                    try
                    {
                        SelectedPreviewTextBox.Text = SavedColorsListView.Items[intselectedindex].Text;
                        SelectedPreviewColorBox.BackColor = Color.FromArgb(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]));
                    }
                    catch { }
                }
                else if (settings.GetColorType() == Settings.ColorType.HTML)
                {
                    try
                    {
                        SelectedPreviewTextBox.Text = SavedColorsListView.Items[intselectedindex].Text;
                        SelectedPreviewColorBox.BackColor = ColorTranslator.FromHtml(SavedColorsListView.Items[intselectedindex].Text);
                    }
                    catch { }
                }
            }
        }

        private void HandleHotkey()
        {
            if (pallet.GetName() == "")
            {
                MessageBox.Show("To save colors the application needs a save file.", "No Save File!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NewPalletButton_Click(null, EventArgs.Empty);
                return;
            }
            var save = ConvertColor(color, settings.GetColorType());

            ListViewItem item = new ListViewItem(save);
            SavedColorsListView.Items.Add(item);
            SavedColorsListView.Items[SavedColorsListView.Items.Count - 1].BackColor = color;

            pallet.AddSavedColor(save);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID) HandleHotkey();

            base.WndProc(ref m);
        }

        private void ClearSavedColorsButton_Click(object sender, EventArgs e)
        {
            SavedColorsListView.Items.Clear();
        }

        private void SavedColorsListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (SavedColorsListView.SelectedIndices.Count <= 0) return;

                pallet.RemoveSavedColor(SavedColorsListView.Items[SavedColorsListView.SelectedIndices[0]].Text);

                if (SavedColorsListView.SelectedIndices[0] >= 0) SavedColorsListView.Items[SavedColorsListView.SelectedIndices[0]].Remove();
            }
        }

        private void CopySelectedColorsButton_Click(object sender, EventArgs e)
        {
            if (SelectedPreviewTextBox.Text != "") Clipboard.SetText(SelectedPreviewTextBox.Text);
        }

        private void EasyColorPickerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            keyhandler.Unregiser();
        }

        private void ExitButton_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void ConvertColorString(int i, Settings.ColorType tmp, Settings.ColorType colorType)
        {
            Color tmpColor = new Color();

            if (tmp == Settings.ColorType.RGB)
            {
                if (colorType == Settings.ColorType.HTML)
                {
                    string[] split = SavedColorsListView.Items[i].Text.Split(',');

                    for (int x = 0; x < split.Length; x++) split[x] = split[x].Trim();

                    try
                    {
                        tmpColor = Color.FromArgb(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]));
                    }
                    catch { }
                    SavedColorsListView.Items[i].Text = ColorTranslator.ToHtml(tmpColor);
                }
            }
            else if (tmp == Settings.ColorType.HTML)
            {
                if (colorType == Settings.ColorType.RGB)
                {
                    tmpColor = ColorTranslator.FromHtml(SavedColorsListView.Items[i].Text);
                    SavedColorsListView.Items[i].Text = ConvertColor(tmpColor, colorType);
                }
            }
        }

        private void ColorType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var tmp = settings.GetColorType();

            settings.SetColorType((Settings.ColorType)Enum.Parse(typeof(Settings.ColorType), ColorType.SelectedItem.ToString()));

            for (int i = 0; i < SavedColorsListView.Items.Count; i++)
            {
                ConvertColorString(i, tmp, settings.GetColorType());
            }

            List<string> tmpList = new List<string>();

            for (int i = 0; i < SavedColorsListView.Items.Count; i++)
            {
                tmpList.Add(SavedColorsListView.Items[i].Text);
            }

            pallet.SetSavedColors(tmpList);
        }

        private void NewPalletButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "xpallet file (*.xpallet)|*.xpallet";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    settings.SetSavePath(sfd.FileName);

                    pallet = new PalletData();
                    pallet.SetName(Path.GetFileNameWithoutExtension(sfd.FileName));

                    Core.SavePallet(sfd.FileName, pallet);

                    SavedColorsListView.Items.Clear();

                    Text = $"{Core.Name} - {pallet.GetName()}";
                }
            }
        }

        private void LoadPalletButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "xpallet file (*.xpallet)|*.xpallet";

                if (ofd.ShowDialog() == DialogResult.OK && ofd.CheckFileExists)
                {
                    settings.SetSavePath(ofd.FileName);

                    LoadPalletData();
                }
            }
        }

        private void AlwaysOnTopToggle_CheckedChanged(object sender, EventArgs e) => TopMost = AlwaysOnTopToggle.Checked;
    }
}