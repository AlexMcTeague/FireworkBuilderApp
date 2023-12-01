namespace FireworkDisplay {
    partial class DrawForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            menuStrip1 = new MenuStrip();
            addToolStripMenuItem = new ToolStripMenuItem();
            addRocketToolStripMenuItem = new ToolStripMenuItem();
            addPayloadToolStripMenuItem = new ToolStripMenuItem();
            addFireworkToolStripMenuItem = new ToolStripMenuItem();
            listToolStripMenuItem = new ToolStripMenuItem();
            editRocketToolStripMenuItem = new ToolStripMenuItem();
            editPayloadToolStripMenuItem = new ToolStripMenuItem();
            editFireworkToolStripMenuItem = new ToolStripMenuItem();
            previewToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, listToolStripMenuItem, previewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addRocketToolStripMenuItem, addPayloadToolStripMenuItem, addFireworkToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(51, 24);
            addToolStripMenuItem.Text = "Add";
            // 
            // addRocketToolStripMenuItem
            // 
            addRocketToolStripMenuItem.Name = "addRocketToolStripMenuItem";
            addRocketToolStripMenuItem.Size = new Size(224, 26);
            addRocketToolStripMenuItem.Text = "Add Rocket";
            addRocketToolStripMenuItem.Click += addRocketToolStripMenuItem_Click;
            // 
            // addPayloadToolStripMenuItem
            // 
            addPayloadToolStripMenuItem.Name = "addPayloadToolStripMenuItem";
            addPayloadToolStripMenuItem.Size = new Size(180, 26);
            addPayloadToolStripMenuItem.Text = "Add Payload";
            // 
            // addFireworkToolStripMenuItem
            // 
            addFireworkToolStripMenuItem.Name = "addFireworkToolStripMenuItem";
            addFireworkToolStripMenuItem.Size = new Size(180, 26);
            addFireworkToolStripMenuItem.Text = "Add Firework";
            // 
            // listToolStripMenuItem
            // 
            listToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editRocketToolStripMenuItem, editPayloadToolStripMenuItem, editFireworkToolStripMenuItem });
            listToolStripMenuItem.Name = "listToolStripMenuItem";
            listToolStripMenuItem.Size = new Size(49, 24);
            listToolStripMenuItem.Text = "Edit";
            // 
            // editRocketToolStripMenuItem
            // 
            editRocketToolStripMenuItem.Name = "editRocketToolStripMenuItem";
            editRocketToolStripMenuItem.Size = new Size(224, 26);
            editRocketToolStripMenuItem.Text = "Edit Rocket";
            // 
            // editPayloadToolStripMenuItem
            // 
            editPayloadToolStripMenuItem.Name = "editPayloadToolStripMenuItem";
            editPayloadToolStripMenuItem.Size = new Size(224, 26);
            editPayloadToolStripMenuItem.Text = "Edit Payload";
            // 
            // editFireworkToolStripMenuItem
            // 
            editFireworkToolStripMenuItem.Name = "editFireworkToolStripMenuItem";
            editFireworkToolStripMenuItem.Size = new Size(224, 26);
            editFireworkToolStripMenuItem.Text = "Edit Firework";
            // 
            // previewToolStripMenuItem
            // 
            previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            previewToolStripMenuItem.Size = new Size(115, 24);
            previewToolStripMenuItem.Text = "Quick Preview";
            previewToolStripMenuItem.DropDownOpening += previewToolStripMenuItem_DropDownOpening;
            // 
            // DrawForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.Black;
            ClientSize = new Size(1264, 977);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "DrawForm";
            Text = "Firework Builder";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem;
        private ToolStripMenuItem previewToolStripMenuItem;
        private ToolStripMenuItem addRocketToolStripMenuItem;
        private ToolStripMenuItem addPayloadToolStripMenuItem;
        private ToolStripMenuItem addFireworkToolStripMenuItem;
        private ToolStripMenuItem editRocketToolStripMenuItem;
        private ToolStripMenuItem editPayloadToolStripMenuItem;
        private ToolStripMenuItem editFireworkToolStripMenuItem;
    }
}