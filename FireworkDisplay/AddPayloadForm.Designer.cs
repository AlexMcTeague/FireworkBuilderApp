namespace FireworkDisplay {
    partial class AddPayloadForm {
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
            shapeLabel = new Label();
            speedBox = new TextBox();
            sizeBox = new TextBox();
            sizeLabel = new Label();
            shapeBox = new ComboBox();
            submitButton = new Button();
            countTip = new Label();
            colorLabel = new Label();
            countLabel = new Label();
            sizeTip = new Label();
            colorBox = new ComboBox();
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
            // shapeLabel
            // 
            shapeLabel.AutoSize = true;
            shapeLabel.Location = new Point(12, 42);
            shapeLabel.Name = "shapeLabel";
            shapeLabel.Size = new Size(53, 20);
            shapeLabel.TabIndex = 2;
            shapeLabel.Text = "Shape:";
            // 
            // speedBox
            // 
            speedBox.Location = new Point(121, 105);
            speedBox.Name = "speedBox";
            speedBox.Size = new Size(52, 27);
            speedBox.TabIndex = 3;
            speedBox.KeyPress += countBox_KeyPress;
            // 
            // sizeBox
            // 
            sizeBox.Location = new Point(74, 72);
            sizeBox.Name = "sizeBox";
            sizeBox.Size = new Size(58, 27);
            sizeBox.TabIndex = 5;
            sizeBox.KeyPress += sizeBox_KeyPress;
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Location = new Point(12, 75);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(39, 20);
            sizeLabel.TabIndex = 6;
            sizeLabel.Text = "Size:";
            // 
            // shapeBox
            // 
            shapeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            shapeBox.FormattingEnabled = true;
            shapeBox.Location = new Point(74, 39);
            shapeBox.Name = "shapeBox";
            shapeBox.Size = new Size(145, 28);
            shapeBox.TabIndex = 9;
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
            // countTip
            // 
            countTip.AutoSize = true;
            countTip.Location = new Point(179, 108);
            countTip.Name = "countTip";
            countTip.Size = new Size(293, 20);
            countTip.TabIndex = 12;
            countTip.Text = "Affects performance. Recommended: <100";
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.Location = new Point(12, 141);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(48, 20);
            colorLabel.TabIndex = 13;
            colorLabel.Text = "Color:";
            // 
            // countLabel
            // 
            countLabel.AutoSize = true;
            countLabel.Location = new Point(12, 108);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(103, 20);
            countLabel.TabIndex = 14;
            countLabel.Text = "Particle Count:";
            // 
            // sizeTip
            // 
            sizeTip.AutoSize = true;
            sizeTip.Location = new Point(138, 75);
            sizeTip.Name = "sizeTip";
            sizeTip.Size = new Size(272, 20);
            sizeTip.TabIndex = 15;
            sizeTip.Text = "Radius in pixels. Recommended: 50-300";
            // 
            // colorBox
            // 
            colorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            colorBox.FormattingEnabled = true;
            colorBox.Location = new Point(74, 138);
            colorBox.Name = "colorBox";
            colorBox.Size = new Size(151, 28);
            colorBox.TabIndex = 16;
            colorBox.DrawItem += colorBox_DrawItem;
            // 
            // AddPayloadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 217);
            Controls.Add(colorBox);
            Controls.Add(sizeTip);
            Controls.Add(countLabel);
            Controls.Add(colorLabel);
            Controls.Add(countTip);
            Controls.Add(submitButton);
            Controls.Add(shapeBox);
            Controls.Add(sizeLabel);
            Controls.Add(sizeBox);
            Controls.Add(speedBox);
            Controls.Add(shapeLabel);
            Controls.Add(nameBox);
            Controls.Add(nameLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddPayloadForm";
            Text = "AddPayloadForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox nameBox;
        private Label shapeLabel;
        private TextBox speedBox;
        private Label speedTip;
        private TextBox sizeBox;
        private Label sizeLabel;
        private Label countLabel;
        private Label TrailColorLabel;
        private ComboBox shapeBox;
        private Button submitButton;
        private ComboBox colorBox;
        private Label countTip;
        private Label colorLabel;
        private Label sizeTip;
    }
}