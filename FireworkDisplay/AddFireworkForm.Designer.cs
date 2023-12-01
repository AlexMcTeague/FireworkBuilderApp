namespace FireworkDisplay {
    partial class AddFireworkForm {
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
            rocketLabel = new Label();
            payloadsLabel = new Label();
            rocketBox = new ComboBox();
            submitButton = new Button();
            payloadsChecklist = new CheckedListBox();
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
            // rocketLabel
            // 
            rocketLabel.AutoSize = true;
            rocketLabel.Location = new Point(12, 42);
            rocketLabel.Name = "rocketLabel";
            rocketLabel.Size = new Size(57, 20);
            rocketLabel.TabIndex = 2;
            rocketLabel.Text = "Rocket:";
            // 
            // payloadsLabel
            // 
            payloadsLabel.AutoSize = true;
            payloadsLabel.Location = new Point(12, 75);
            payloadsLabel.Name = "payloadsLabel";
            payloadsLabel.Size = new Size(70, 20);
            payloadsLabel.TabIndex = 6;
            payloadsLabel.Text = "Payloads:";
            // 
            // rocketBox
            // 
            rocketBox.DropDownStyle = ComboBoxStyle.DropDownList;
            rocketBox.FormattingEnabled = true;
            rocketBox.Location = new Point(74, 39);
            rocketBox.Name = "rocketBox";
            rocketBox.Size = new Size(145, 28);
            rocketBox.TabIndex = 9;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(74, 283);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(94, 29);
            submitButton.TabIndex = 10;
            submitButton.Text = "Save";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // payloadsChecklist
            // 
            payloadsChecklist.FormattingEnabled = true;
            payloadsChecklist.Location = new Point(88, 75);
            payloadsChecklist.Name = "payloadsChecklist";
            payloadsChecklist.Size = new Size(222, 202);
            payloadsChecklist.TabIndex = 12;
            // 
            // AddFireworkForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 324);
            Controls.Add(payloadsChecklist);
            Controls.Add(submitButton);
            Controls.Add(rocketBox);
            Controls.Add(payloadsLabel);
            Controls.Add(rocketLabel);
            Controls.Add(nameBox);
            Controls.Add(nameLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddFireworkForm";
            Text = "AddFireworkForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox nameBox;
        private Label rocketLabel;
        private Label speedTip;
        private Label payloadsLabel;
        private Label TrailColorLabel;
        private ComboBox rocketBox;
        private Button submitButton;
        private CheckedListBox payloadsChecklist;
    }
}