namespace C1L3WindowsFormsApplication
{
    partial class Form1
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
            this.progressBarGen = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblgeneric = new System.Windows.Forms.Label();
            this.progressBarObj = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblObject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarGen
            // 
            this.progressBarGen.Location = new System.Drawing.Point(12, 12);
            this.progressBarGen.Name = "progressBarGen";
            this.progressBarGen.Size = new System.Drawing.Size(286, 27);
            this.progressBarGen.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time elapsed:";
            // 
            // lblgeneric
            // 
            this.lblgeneric.AutoSize = true;
            this.lblgeneric.Location = new System.Drawing.Point(88, 88);
            this.lblgeneric.Name = "lblgeneric";
            this.lblgeneric.Size = new System.Drawing.Size(0, 13);
            this.lblgeneric.TabIndex = 3;
            // 
            // progressBarObj
            // 
            this.progressBarObj.Location = new System.Drawing.Point(404, 12);
            this.progressBarObj.Name = "progressBarObj";
            this.progressBarObj.Size = new System.Drawing.Size(286, 27);
            this.progressBarObj.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time elapsed:";
            // 
            // lblObject
            // 
            this.lblObject.AutoSize = true;
            this.lblObject.Location = new System.Drawing.Point(480, 88);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(0, 13);
            this.lblObject.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 290);
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBarObj);
            this.Controls.Add(this.lblgeneric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBarGen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarGen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblgeneric;
        private System.Windows.Forms.ProgressBar progressBarObj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblObject;
    }
}

