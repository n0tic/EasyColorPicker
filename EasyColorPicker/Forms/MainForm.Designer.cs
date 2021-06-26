
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
            this.LivePreviewColorBox = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.LivePreviewBox)).BeginInit();
            this.CurrentGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LivePreviewColorBox
            // 
            this.LivePreviewColorBox.Location = new System.Drawing.Point(6, 125);
            this.LivePreviewColorBox.Name = "LivePreviewColorBox";
            this.LivePreviewColorBox.Size = new System.Drawing.Size(20, 20);
            this.LivePreviewColorBox.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.CurrentGroup.Location = new System.Drawing.Point(12, 12);
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
            this.groupBox2.Location = new System.Drawing.Point(130, 12);
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
            this.ClearSavedColorsButton.Click += new System.EventHandler(this.button1_Click);
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
            this.SavedColorsListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.SavedColorsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
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
            this.groupBox1.Location = new System.Drawing.Point(264, 12);
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
            this.CopySelectedColorsButton.Text = "Copy";
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
            // EasyColorPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 199);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CurrentGroup);
            this.Name = "EasyColorPickerForm";
            this.Text = "Easy Color Picker";
            ((System.ComponentModel.ISupportInitialize)(this.LivePreviewBox)).EndInit();
            this.CurrentGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LivePreviewColorBox;
        private System.Windows.Forms.Timer timer1;
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
    }
}

