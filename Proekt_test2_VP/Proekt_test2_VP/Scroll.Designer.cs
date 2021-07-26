
namespace Proekt_test2_VP
{
    partial class Scroll
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
            this.SpinButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ParadiseButton = new System.Windows.Forms.Button();
            this.info_box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.info_box)).BeginInit();
            this.SuspendLayout();
            // 
            // SpinButton
            // 
            this.SpinButton.Location = new System.Drawing.Point(434, 434);
            this.SpinButton.Margin = new System.Windows.Forms.Padding(4);
            this.SpinButton.Name = "SpinButton";
            this.SpinButton.Size = new System.Drawing.Size(100, 28);
            this.SpinButton.TabIndex = 8;
            this.SpinButton.Text = "Spin";
            this.SpinButton.UseVisualStyleBackColor = true;
            this.SpinButton.Click += new System.EventHandler(this.SpinButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(365, 224);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "img";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(64, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(828, 117);
            this.label1.TabIndex = 9;
            this.label1.Text = "          Congratulations! You Won 10 Free Spins!\r\n\r\nClick The Button Bellow to P" +
    "ick your Bonus Character\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParadiseButton
            // 
            this.ParadiseButton.BackColor = System.Drawing.Color.Red;
            this.ParadiseButton.Enabled = false;
            this.ParadiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ParadiseButton.ForeColor = System.Drawing.Color.Yellow;
            this.ParadiseButton.Location = new System.Drawing.Point(268, 591);
            this.ParadiseButton.Name = "ParadiseButton";
            this.ParadiseButton.Size = new System.Drawing.Size(440, 55);
            this.ParadiseButton.TabIndex = 10;
            this.ParadiseButton.Text = "Proceed To Panda Paradise";
            this.ParadiseButton.UseVisualStyleBackColor = false;
            this.ParadiseButton.Click += new System.EventHandler(this.ParadiseButton_Click);
            // 
            // info_box
            // 
            this.info_box.BackColor = System.Drawing.Color.Transparent;
            this.info_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.info_box.Image = global::Proekt_test2_VP.Properties.Resources.info;
            this.info_box.Location = new System.Drawing.Point(925, 25);
            this.info_box.Name = "info_box";
            this.info_box.Size = new System.Drawing.Size(44, 43);
            this.info_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.info_box.TabIndex = 25;
            this.info_box.TabStop = false;
            // 
            // Scroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proekt_test2_VP.Properties.Resources.PandaScroll;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(996, 683);
            this.Controls.Add(this.info_box);
            this.Controls.Add(this.ParadiseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpinButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scroll";
            this.Text = "Scroll";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.info_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SpinButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ParadiseButton;
        private System.Windows.Forms.PictureBox info_box;
    }
}