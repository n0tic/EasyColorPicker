using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyColorPicker
{
    public partial class EasyColorPickerForm : Form
    {
        KeyHandler keyhandler;

        Color color;

        Point point = new Point();
        const int zoomFactor = 4;
        Size newSize = new Size((int)(100 * zoomFactor), (int)(100 * zoomFactor));

        [DllImport("user32.dll")]
        static public extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);

        private const uint SB_HORZ = 0;

        private const uint SB_VERT = 1;

        private const uint ESB_DISABLE_BOTH = 0x3;

        private const uint ESB_ENABLE_BOTH = 0x0;

        public EasyColorPickerForm()
        {
            InitializeComponent();

            SavedColorsListView.Columns[0].Width = SavedColorsListView.Width - 18;

            keyhandler = new KeyHandler(Keys.End, this);
            keyhandler.Register();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            color = PixelColor.GetCursorPixelColor(sender, e);
            LivePreviewColorBox.BackColor = color;
            LivePreviewLabelBox.Text = $"{color.R}, {color.G}, {color.B}";

            if (LivePreviewBox.Image != null)
            LivePreviewBox.Image.Dispose();
            
            PixelColor.GetCursorPos(ref point);
            Rectangle rect = new Rectangle(point.X - 12, point.Y - 12, 100, 100);

            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb))
            {
                using(Bitmap image = new Bitmap(bmp , newSize))
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SavedColorsListView.SelectedIndices.Count <= 0) return;

            int intselectedindex = SavedColorsListView.SelectedIndices[0];

            if (intselectedindex >= 0)
            {
                string[] split = SavedColorsListView.Items[intselectedindex].Text.Split(',');
                int[] x = new int[split.Length];
                for (int i = 0; i < split.Length; i++)
                {
                    try
                    {
                        x[i] = Int32.Parse(split[i]);
                    }
                    catch { }
                }

                try
                {
                    SelectedPreviewTextBox.Text = SavedColorsListView.Items[intselectedindex].Text;
                    SelectedPreviewColorBox.BackColor = Color.FromArgb(x[0], x[1], x[2]);
                }
                catch { }
            }
        }

        private void HandleHotkey()
        {
            ListViewItem item = new ListViewItem($"{color.R}, {color.G}, {color.B}");
            SavedColorsListView.Items.Add(item);
            SavedColorsListView.Items[SavedColorsListView.Items.Count - 1].BackColor = color;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID) HandleHotkey();

            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavedColorsListView.Items.Clear();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (SavedColorsListView.SelectedIndices.Count <= 0) return;

                if (SavedColorsListView.SelectedIndices[0] >= 0) SavedColorsListView.Items[SavedColorsListView.SelectedIndices[0]].Remove();
            }
        }

        private void CopySelectedColorsButton_Click(object sender, EventArgs e)
        {
            if(SelectedPreviewTextBox.Text != "") Clipboard.SetText(SelectedPreviewTextBox.Text);
        }
    }
}
