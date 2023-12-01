namespace FireworkDisplay {
    partial class AddRocketForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            nameLabel = new Label();
            nameBox = new TextBox();
            speedLabel = new Label();
            speedBox = new TextBox();
            speedTip = new Label();
            targetAltitudeBox = new TextBox();
            targetAltitudeLabel = new Label();
            label1 = new Label();
            TrailColorLabel = new Label();
            colorBox = new ComboBox();
            submitButton = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(56, 20);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name: ";
            // 
            // nameBox
            // 
            nameBox.Location = new Point(74, 6);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(236, 27);
            nameBox.TabIndex = 1;
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.Location = new Point(12, 42);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(58, 20);
            speedLabel.TabIndex = 2;
            speedLabel.Text = "Speed: ";
            // 
            // speedBox
            // 
            speedBox.Location = new Point(74, 39);
            speedBox.Name = "speedBox";
            speedBox.Size = new Size(44, 27);
            speedBox.TabIndex = 3;
            speedBox.KeyPress += speedBox_KeyPress;
            // 
            // speedTip
            // 
            speedTip.AutoSize = true;
            speedTip.Location = new Point(124, 42);
            speedTip.Name = "speedTip";
            speedTip.Size = new Size(249, 20);
            speedTip.TabIndex = 4;
            speedTip.Text = "Integer only. Recommended: 5 to 40";
            // 
            // targetAltitudeBox
            // 
            targetAltitudeBox.Location = new Point(124, 72);
            targetAltitudeBox.Name = "targetAltitudeBox";
            targetAltitudeBox.Size = new Size(62, 27);
            targetAltitudeBox.TabIndex = 5;
            targetAltitudeBox.KeyPress += targetAltitudeBox_KeyPress;
            // 
            // targetAltitudeLabel
            // 
            targetAltitudeLabel.AutoSize = true;
            targetAltitudeLabel.Location = new Point(12, 75);
            targetAltitudeLabel.Name = "targetAltitudeLabel";
            targetAltitudeLabel.Size = new Size(110, 20);
            targetAltitudeLabel.TabIndex = 6;
            targetAltitudeLabel.Text = "Target Altitude:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(192, 75);
            label1.Name = "label1";
            label1.Size = new Size(265, 20);
            label1.TabIndex = 7;
            label1.Text = "Integer only. Recommended: 400-1000";
            // 
            // TrailColorLabel
            // 
            TrailColorLabel.AutoSize = true;
            TrailColorLabel.Location = new Point(12, 108);
            TrailColorLabel.Name = "TrailColorLabel";
            TrailColorLabel.Size = new Size(80, 20);
            TrailColorLabel.TabIndex = 8;
            TrailColorLabel.Text = "Trail Color:";
            // 
            // colorBox
            // 
            colorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            colorBox.FormattingEnabled = true;
            colorBox.Location = new Point(98, 105);
            colorBox.Name = "colorBox";
            colorBox.Size = new Size(212, 28);
            colorBox.TabIndex = 9;
            colorBox.DrawItem += colorBox_DrawItem;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(74, 176);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(94, 29);
            submitButton.TabIndex = 10;
            submitButton.Text = "Save";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // AddRocketForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 217);
            Controls.Add(submitButton);
            Controls.Add(colorBox);
            Controls.Add(TrailColorLabel);
            Controls.Add(label1);
            Controls.Add(targetAltitudeLabel);
            Controls.Add(targetAltitudeBox);
            Controls.Add(speedTip);
            Controls.Add(speedBox);
            Controls.Add(speedLabel);
            Controls.Add(nameBox);
            Controls.Add(nameLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddRocketForm";
            Text = "AddRocketForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox nameBox;
        private Label speedLabel;
        private TextBox speedBox;
        private Label speedTip;
        private TextBox targetAltitudeBox;
        private Label targetAltitudeLabel;
        private Label label1;
        private Label TrailColorLabel;
        private ComboBox colorBox;
        private Button submitButton;
    }
}