
namespace EasyColorPicker
{
    partial class EasyColorPickerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyColorPickerForm));
            this.LivePreviewColorBox = new System.Windows.Forms.Panel();
            this.CaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.LivePreviewLabelBox = new System.Windows.Forms.Label();
            this.LivePreviewBox = new System.Windows.Forms.PictureBox();
            this.CurrentGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClearSavedColorsButton = new System.Windows.Forms.Button();
            this.SavedColorsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelectedPreviewColorBox = new System.Windows.Forms.Panel();
            this.CopySelectedColorsButton = new System.Windows.Forms.Button();
            this.SelectedPreviewTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.NewPalletButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPalletButton = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ColorType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.LivePreviewBox)).BeginInit();
            this.CurrentGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LivePreviewColorBox
            // 
            this.LivePreviewColorBox.Location = new System.Drawing.Point(6, 125);
            this.LivePreviewColorBox.Name = "LivePreviewColorBox";
            this.LivePreviewColorBox.Size = new System.Drawing.Size(20, 20);
            this.LivePreviewColorBox.TabIndex = 0;
            // 
            // CaptureTimer
            // 
            this.CaptureTimer.Tick += new System.EventHandler(this.CaptureTimer_Tick);
            // 
            // LivePreviewLabelBox
            // 
            this.LivePreviewLabelBox.Location = new System.Drawing.Point(6, 151);
            this.LivePreviewLabelBox.Name = "LivePreviewLabelBox";
            this.LivePreviewLabelBox.Size = new System.Drawing.Size(100, 20);
            this.LivePreviewLabelBox.TabIndex = 1;
            this.LivePreviewLabelBox.Text = "label1";
            this.LivePreviewLabelBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LivePreviewBox
            // 
            this.LivePreviewBox.Location = new System.Drawing.Point(6, 19);
            this.LivePreviewBox.Name = "LivePreviewBox";
            this.LivePreviewBox.Size = new System.Drawing.Size(100, 100);
            this.LivePreviewBox.TabIndex = 2;
            this.LivePreviewBox.TabStop = false;
            // 
            // CurrentGroup
            // 
            this.CurrentGroup.Controls.Add(this.LivePreviewBox);
            this.CurrentGroup.Controls.Add(this.LivePreviewColorBox);
            this.CurrentGroup.Controls.Add(this.LivePreviewLabelBox);
            this.CurrentGroup.Location = new System.Drawing.Point(12, 26);
            this.CurrentGroup.Name = "CurrentGroup";
            this.CurrentGroup.Size = new System.Drawing.Size(112, 180);
            this.CurrentGroup.TabIndex = 4;
            this.CurrentGroup.TabStop = false;
            this.CurrentGroup.Text = "Current";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClearSavedColorsButton);
            this.groupBox2.Controls.Add(this.SavedColorsListView);
            this.groupBox2.Location = new System.Drawing.Point(130, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 180);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saved";
            // 
            // ClearSavedColorsButton
            // 
            this.ClearSavedColorsButton.Location = new System.Drawing.Point(6, 151);
            this.ClearSavedColorsButton.Name = "ClearSavedColorsButton";
            this.ClearSavedColorsButton.Size = new System.Drawing.Size(116, 23);
            this.ClearSavedColorsButton.TabIndex = 7;
            this.ClearSavedColorsButton.Text = "Clear";
            this.ClearSavedColorsButton.UseVisualStyleBackColor = true;
            this.ClearSavedColorsButton.Click += new System.EventHandler(this.ClearSavedColorsButton_Click);
            // 
            // SavedColorsListView
            // 
            this.SavedColorsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.SavedColorsListView.AutoArrange = false;
            this.SavedColorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.SavedColorsListView.FullRowSelect = true;
            this.SavedColorsListView.GridLines = true;
            this.SavedColorsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SavedColorsListView.HideSelection = false;
            this.SavedColorsListView.LabelWrap = false;
            this.SavedColorsListView.Location = new System.Drawing.Point(6, 19);
            this.SavedColorsListView.MultiSelect = false;
            this.SavedColorsListView.Name = "SavedColorsListView";
            this.SavedColorsListView.Size = new System.Drawing.Size(116, 126);
            this.SavedColorsListView.TabIndex = 6;
            this.SavedColorsListView.UseCompatibleStateImageBehavior = false;
            this.SavedColorsListView.View = System.Windows.Forms.View.Details;
            this.SavedColorsListView.SelectedIndexChanged += new System.EventHandler(this.SavedColorsListView_SelectedIndexChanged);
            this.SavedColorsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SavedColorsListView_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Saved Colors";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectedPreviewColorBox);
            this.groupBox1.Controls.Add(this.CopySelectedColorsButton);
            this.groupBox1.Controls.Add(this.SelectedPreviewTextBox);
            this.groupBox1.Location = new System.Drawing.Point(264, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 101);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected";
            // 
            // SelectedPreviewColorBox
            // 
            this.SelectedPreviewColorBox.Location = new System.Drawing.Point(6, 19);
            this.SelectedPreviewColorBox.Name = "SelectedPreviewColorBox";
            this.SelectedPreviewColorBox.Size = new System.Drawing.Size(20, 20);
            this.SelectedPreviewColorBox.TabIndex = 1;
            // 
            // CopySelectedColorsButton
            // 
            this.CopySelectedColorsButton.Location = new System.Drawing.Point(6, 71);
            this.CopySelectedColorsButton.Name = "CopySelectedColorsButton";
            this.CopySelectedColorsButton.Size = new System.Drawing.Size(116, 23);
            this.CopySelectedColorsButton.TabIndex = 6;
            this.CopySelectedColorsButton.Text = "Copy Value";
            this.CopySelectedColorsButton.UseVisualStyleBackColor = true;
            this.CopySelectedColorsButton.Click += new System.EventHandler(this.CopySelectedColorsButton_Click);
            // 
            // SelectedPreviewTextBox
            // 
            this.SelectedPreviewTextBox.Location = new System.Drawing.Point(6, 45);
            this.SelectedPreviewTextBox.Name = "SelectedPreviewTextBox";
            this.SelectedPreviewTextBox.ReadOnly = true;
            this.SelectedPreviewTextBox.Size = new System.Drawing.Size(116, 20);
            this.SelectedPreviewTextBox.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(404, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitButton});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(81, 22);
            this.toolStripDropDownButton2.Text = "Application";
            // 
            // ExitButton
            // 
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(180, 22);
            this.ExitButton.Text = "Exit Application";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewPalletButton,
            this.LoadPalletButton});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton1.Text = "Project";
            // 
            // NewPalletButton
            // 
            this.NewPalletButton.Name = "NewPalletButton";
            this.NewPalletButton.Size = new System.Drawing.Size(180, 22);
            this.NewPalletButton.Text = "New Color Palette";
            this.NewPalletButton.Click += new System.EventHandler(this.NewPalletButton_Click);
            // 
            // LoadPalletButton
            // 
            this.LoadPalletButton.Name = "LoadPalletButton";
            this.LoadPalletButton.Size = new System.Drawing.Size(180, 22);
            this.LoadPalletButton.Text = "Load Color Palette";
            this.LoadPalletButton.Click += new System.EventHandler(this.LoadPalletButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ColorType
            // 
            this.ColorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorType.FormattingEnabled = true;
            this.ColorType.Location = new System.Drawing.Point(6, 19);
            this.ColorType.Name = "ColorType";
            this.ColorType.Size = new System.Drawing.Size(116, 21);
            this.ColorType.TabIndex = 9;
            this.ColorType.SelectionChangeCommitted += new System.EventHandler(this.ColorType_SelectionChangeCommitted);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ColorType);
            this.groupBox3.Location = new System.Drawing.Point(264, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 50);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quick Settings";
            // 
            // EasyColorPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 214);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CurrentGroup);
            this.Name = "EasyColorPickerForm";
            this.Text = "Easy Color Picker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EasyColorPickerForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LivePreviewBox)).EndInit();
            this.CurrentGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LivePreviewColorBox;
        private System.Windows.Forms.Timer CaptureTimer;
        private System.Windows.Forms.Label LivePreviewLabelBox;
        private System.Windows.Forms.PictureBox LivePreviewBox;
        private System.Windows.Forms.GroupBox CurrentGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView SavedColorsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel SelectedPreviewColorBox;
        private System.Windows.Forms.Button CopySelectedColorsButton;
        private System.Windows.Forms.TextBox SelectedPreviewTextBox;
        private System.Windows.Forms.Button ClearSavedColorsButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem NewPalletButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem LoadPalletButton;
        private System.Windows.Forms.ComboBox ColorType;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

