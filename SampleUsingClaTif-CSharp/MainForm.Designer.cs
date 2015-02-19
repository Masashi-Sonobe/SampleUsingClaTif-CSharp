namespace SampleUsingClaTif_CSharp
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            tif.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.groupBox_LoadImageBit = new System.Windows.Forms.GroupBox();
            this.radioButton_32bitGray = new System.Windows.Forms.RadioButton();
            this.radioButton_16bitGray = new System.Windows.Forms.RadioButton();
            this.radioButton_8bitGray = new System.Windows.Forms.RadioButton();
            this.radioButton_1bitMono = new System.Windows.Forms.RadioButton();
            this.button_SaveBmp = new System.Windows.Forms.Button();
            this.groupBox_LoadImageBit.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(12, 12);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(90, 34);
            this.button_OpenFile.TabIndex = 0;
            this.button_OpenFile.Text = "Open Tif";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // groupBox_LoadImageBit
            // 
            this.groupBox_LoadImageBit.Controls.Add(this.radioButton_32bitGray);
            this.groupBox_LoadImageBit.Controls.Add(this.radioButton_16bitGray);
            this.groupBox_LoadImageBit.Controls.Add(this.radioButton_8bitGray);
            this.groupBox_LoadImageBit.Controls.Add(this.radioButton_1bitMono);
            this.groupBox_LoadImageBit.Location = new System.Drawing.Point(16, 63);
            this.groupBox_LoadImageBit.Name = "groupBox_LoadImageBit";
            this.groupBox_LoadImageBit.Size = new System.Drawing.Size(201, 70);
            this.groupBox_LoadImageBit.TabIndex = 1;
            this.groupBox_LoadImageBit.TabStop = false;
            this.groupBox_LoadImageBit.Text = "Load Image Bit";
            // 
            // radioButton_32bitGray
            // 
            this.radioButton_32bitGray.AutoSize = true;
            this.radioButton_32bitGray.Enabled = false;
            this.radioButton_32bitGray.Location = new System.Drawing.Point(107, 40);
            this.radioButton_32bitGray.Name = "radioButton_32bitGray";
            this.radioButton_32bitGray.Size = new System.Drawing.Size(76, 16);
            this.radioButton_32bitGray.TabIndex = 3;
            this.radioButton_32bitGray.TabStop = true;
            this.radioButton_32bitGray.Text = "32bit Gray";
            this.radioButton_32bitGray.UseVisualStyleBackColor = true;
            // 
            // radioButton_16bitGray
            // 
            this.radioButton_16bitGray.AutoSize = true;
            this.radioButton_16bitGray.Enabled = false;
            this.radioButton_16bitGray.Location = new System.Drawing.Point(12, 40);
            this.radioButton_16bitGray.Name = "radioButton_16bitGray";
            this.radioButton_16bitGray.Size = new System.Drawing.Size(76, 16);
            this.radioButton_16bitGray.TabIndex = 2;
            this.radioButton_16bitGray.TabStop = true;
            this.radioButton_16bitGray.Text = "16bit Gray";
            this.radioButton_16bitGray.UseVisualStyleBackColor = true;
            // 
            // radioButton_8bitGray
            // 
            this.radioButton_8bitGray.AutoSize = true;
            this.radioButton_8bitGray.Enabled = false;
            this.radioButton_8bitGray.Location = new System.Drawing.Point(107, 18);
            this.radioButton_8bitGray.Name = "radioButton_8bitGray";
            this.radioButton_8bitGray.Size = new System.Drawing.Size(70, 16);
            this.radioButton_8bitGray.TabIndex = 1;
            this.radioButton_8bitGray.TabStop = true;
            this.radioButton_8bitGray.Text = "8bit Gray";
            this.radioButton_8bitGray.UseVisualStyleBackColor = true;
            // 
            // radioButton_1bitMono
            // 
            this.radioButton_1bitMono.AutoSize = true;
            this.radioButton_1bitMono.Enabled = false;
            this.radioButton_1bitMono.Location = new System.Drawing.Point(12, 18);
            this.radioButton_1bitMono.Name = "radioButton_1bitMono";
            this.radioButton_1bitMono.Size = new System.Drawing.Size(73, 16);
            this.radioButton_1bitMono.TabIndex = 0;
            this.radioButton_1bitMono.TabStop = true;
            this.radioButton_1bitMono.Text = "1bit Mono";
            this.radioButton_1bitMono.UseVisualStyleBackColor = true;
            // 
            // button_SaveBmp
            // 
            this.button_SaveBmp.Enabled = false;
            this.button_SaveBmp.Location = new System.Drawing.Point(14, 149);
            this.button_SaveBmp.Name = "button_SaveBmp";
            this.button_SaveBmp.Size = new System.Drawing.Size(89, 33);
            this.button_SaveBmp.TabIndex = 2;
            this.button_SaveBmp.Text = "Save bmp (loaded image)";
            this.button_SaveBmp.UseVisualStyleBackColor = true;
            this.button_SaveBmp.Click += new System.EventHandler(this.button_SaveBmp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 262);
            this.Controls.Add(this.button_SaveBmp);
            this.Controls.Add(this.groupBox_LoadImageBit);
            this.Controls.Add(this.button_OpenFile);
            this.Name = "MainForm";
            this.Text = "ClaTif Sample";
            this.groupBox_LoadImageBit.ResumeLayout(false);
            this.groupBox_LoadImageBit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.GroupBox groupBox_LoadImageBit;
        private System.Windows.Forms.RadioButton radioButton_32bitGray;
        private System.Windows.Forms.RadioButton radioButton_16bitGray;
        private System.Windows.Forms.RadioButton radioButton_8bitGray;
        private System.Windows.Forms.RadioButton radioButton_1bitMono;
        private System.Windows.Forms.Button button_SaveBmp;
    }
}

