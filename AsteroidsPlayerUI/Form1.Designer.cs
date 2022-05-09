
namespace AsteroidsPlayerUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRight = new System.Windows.Forms.Button();
            this.btnHyperspace = new System.Windows.Forms.Button();
            this.btnShot = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnSchub = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(196, 235);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(112, 34);
            this.btnRight.TabIndex = 0;
            this.btnRight.Text = "Rechts";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnHyperspace
            // 
            this.btnHyperspace.Location = new System.Drawing.Point(658, 195);
            this.btnHyperspace.Name = "btnHyperspace";
            this.btnHyperspace.Size = new System.Drawing.Size(118, 34);
            this.btnHyperspace.TabIndex = 1;
            this.btnHyperspace.Text = "Hyperspace";
            this.btnHyperspace.UseVisualStyleBackColor = true;
            this.btnHyperspace.Click += new System.EventHandler(this.btnHyperspace_Click);
            // 
            // btnShot
            // 
            this.btnShot.Location = new System.Drawing.Point(542, 152);
            this.btnShot.Name = "btnShot";
            this.btnShot.Size = new System.Drawing.Size(112, 34);
            this.btnShot.TabIndex = 2;
            this.btnShot.Text = "Schuss";
            this.btnShot.UseVisualStyleBackColor = true;
            this.btnShot.Click += new System.EventHandler(this.btnShot_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(55, 235);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(112, 34);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "Links";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnSchub
            // 
            this.btnSchub.Location = new System.Drawing.Point(422, 195);
            this.btnSchub.Name = "btnSchub";
            this.btnSchub.Size = new System.Drawing.Size(112, 34);
            this.btnSchub.TabIndex = 4;
            this.btnSchub.Text = "Schub";
            this.btnSchub.UseVisualStyleBackColor = true;
            this.btnSchub.Click += new System.EventHandler(this.btnSchub_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSchub);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnShot);
            this.Controls.Add(this.btnHyperspace);
            this.Controls.Add(this.btnRight);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnHyperspace;
        private System.Windows.Forms.Button btnShot;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnSchub;
    }
}

