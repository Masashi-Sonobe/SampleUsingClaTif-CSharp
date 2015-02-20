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
            this.groupBox_LoadImageData = new System.Windows.Forms.GroupBox();
            this.radioButton_32bitGray = new System.Windows.Forms.RadioButton();
            this.radioButton_16bitGray = new System.Windows.Forms.RadioButton();
            this.radioButton_8bitGray = new System.Windows.Forms.RadioButton();
            this.radioButton_1bitMono = new System.Windows.Forms.RadioButton();
            this.button_SaveBmp = new System.Windows.Forms.Button();
            this.numericUpDown_posX = new System.Windows.Forms.NumericUpDown();
            this.label_arrIndex = new System.Windows.Forms.Label();
            this.label_posX = new System.Windows.Forms.Label();
            this.label_posY = new System.Windows.Forms.Label();
            this.label_pixel = new System.Windows.Forms.Label();
            this.numericUpDown_posY = new System.Windows.Forms.NumericUpDown();
            this.label_ArrayIndex = new System.Windows.Forms.Label();
            this.label_PixelValue = new System.Windows.Forms.Label();
            this.groupBox_LoadImageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_posX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_posY)).BeginInit();
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
            // groupBox_LoadImageData
            // 
            this.groupBox_LoadImageData.Controls.Add(this.label_PixelValue);
            this.groupBox_LoadImageData.Controls.Add(this.label_ArrayIndex);
            this.groupBox_LoadImageData.Controls.Add(this.numericUpDown_posY);
            this.groupBox_LoadImageData.Controls.Add(this.label_pixel);
            this.groupBox_LoadImageData.Controls.Add(this.label_posY);
            this.groupBox_LoadImageData.Controls.Add(this.label_posX);
            this.groupBox_LoadImageData.Controls.Add(this.label_arrIndex);
            this.groupBox_LoadImageData.Controls.Add(this.numericUpDown_posX);
            this.groupBox_LoadImageData.Controls.Add(this.radioButton_32bitGray);
            this.groupBox_LoadImageData.Controls.Add(this.radioButton_16bitGray);
            this.groupBox_LoadImageData.Controls.Add(this.radioButton_8bitGray);
            this.groupBox_LoadImageData.Controls.Add(this.radioButton_1bitMono);
            this.groupBox_LoadImageData.Location = new System.Drawing.Point(16, 63);
            this.groupBox_LoadImageData.Name = "groupBox_LoadImageData";
            this.groupBox_LoadImageData.Size = new System.Drawing.Size(201, 145);
            this.groupBox_LoadImageData.TabIndex = 1;
            this.groupBox_LoadImageData.TabStop = false;
            this.groupBox_LoadImageData.Text = "Load Image Data";
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
            this.button_SaveBmp.Location = new System.Drawing.Point(16, 227);
            this.button_SaveBmp.Name = "button_SaveBmp";
            this.button_SaveBmp.Size = new System.Drawing.Size(89, 33);
            this.button_SaveBmp.TabIndex = 2;
            this.button_SaveBmp.Text = "Save bmp (loaded image)";
            this.button_SaveBmp.UseVisualStyleBackColor = true;
            this.button_SaveBmp.Click += new System.EventHandler(this.button_SaveBmp_Click);
            // 
            // numericUpDown_posX
            // 
            this.numericUpDown_posX.Enabled = false;
            this.numericUpDown_posX.Location = new System.Drawing.Point(40, 71);
            this.numericUpDown_posX.Name = "numericUpDown_posX";
            this.numericUpDown_posX.Size = new System.Drawing.Size(48, 19);
            this.numericUpDown_posX.TabIndex = 4;
            this.numericUpDown_posX.ValueChanged += new System.EventHandler(this.numericUpDown_posX_ValueChanged);
            // 
            // label_arrIndex
            // 
            this.label_arrIndex.AutoSize = true;
            this.label_arrIndex.Enabled = false;
            this.label_arrIndex.Location = new System.Drawing.Point(19, 100);
            this.label_arrIndex.Name = "label_arrIndex";
            this.label_arrIndex.Size = new System.Drawing.Size(70, 12);
            this.label_arrIndex.TabIndex = 5;
            this.label_arrIndex.Text = "Array Index :";
            // 
            // label_posX
            // 
            this.label_posX.AutoSize = true;
            this.label_posX.Enabled = false;
            this.label_posX.Location = new System.Drawing.Point(16, 74);
            this.label_posX.Name = "label_posX";
            this.label_posX.Size = new System.Drawing.Size(13, 12);
            this.label_posX.TabIndex = 6;
            this.label_posX.Text = "x:";
            // 
            // label_posY
            // 
            this.label_posY.AutoSize = true;
            this.label_posY.Enabled = false;
            this.label_posY.Location = new System.Drawing.Point(104, 74);
            this.label_posY.Name = "label_posY";
            this.label_posY.Size = new System.Drawing.Size(13, 12);
            this.label_posY.TabIndex = 7;
            this.label_posY.Text = "y:";
            // 
            // label_pixel
            // 
            this.label_pixel.AutoSize = true;
            this.label_pixel.Enabled = false;
            this.label_pixel.Location = new System.Drawing.Point(19, 122);
            this.label_pixel.Name = "label_pixel";
            this.label_pixel.Size = new System.Drawing.Size(63, 12);
            this.label_pixel.TabIndex = 8;
            this.label_pixel.Text = "Pixel value:";
            // 
            // numericUpDown_posY
            // 
            this.numericUpDown_posY.Enabled = false;
            this.numericUpDown_posY.Location = new System.Drawing.Point(124, 70);
            this.numericUpDown_posY.Name = "numericUpDown_posY";
            this.numericUpDown_posY.Size = new System.Drawing.Size(48, 19);
            this.numericUpDown_posY.TabIndex = 9;
            this.numericUpDown_posY.ValueChanged += new System.EventHandler(this.numericUpDown_posY_ValueChanged);
            // 
            // label_ArrayIndex
            // 
            this.label_ArrayIndex.AutoSize = true;
            this.label_ArrayIndex.Enabled = false;
            this.label_ArrayIndex.Location = new System.Drawing.Point(98, 99);
            this.label_ArrayIndex.Name = "label_ArrayIndex";
            this.label_ArrayIndex.Size = new System.Drawing.Size(11, 12);
            this.label_ArrayIndex.TabIndex = 10;
            this.label_ArrayIndex.Text = "0";
            // 
            // label_PixelValue
            // 
            this.label_PixelValue.AutoSize = true;
            this.label_PixelValue.Enabled = false;
            this.label_PixelValue.Location = new System.Drawing.Point(98, 122);
            this.label_PixelValue.Name = "label_PixelValue";
            this.label_PixelValue.Size = new System.Drawing.Size(11, 12);
            this.label_PixelValue.TabIndex = 11;
            this.label_PixelValue.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 275);
            this.Controls.Add(this.button_SaveBmp);
            this.Controls.Add(this.groupBox_LoadImageData);
            this.Controls.Add(this.button_OpenFile);
            this.Name = "MainForm";
            this.Text = "ClaTif Sample";
            this.groupBox_LoadImageData.ResumeLayout(false);
            this.groupBox_LoadImageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_posX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_posY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.GroupBox groupBox_LoadImageData;
        private System.Windows.Forms.RadioButton radioButton_32bitGray;
        private System.Windows.Forms.RadioButton radioButton_16bitGray;
        private System.Windows.Forms.RadioButton radioButton_8bitGray;
        private System.Windows.Forms.RadioButton radioButton_1bitMono;
        private System.Windows.Forms.Button button_SaveBmp;
        private System.Windows.Forms.Label label_PixelValue;
        private System.Windows.Forms.Label label_ArrayIndex;
        private System.Windows.Forms.NumericUpDown numericUpDown_posY;
        private System.Windows.Forms.Label label_pixel;
        private System.Windows.Forms.Label label_posY;
        private System.Windows.Forms.Label label_posX;
        private System.Windows.Forms.Label label_arrIndex;
        private System.Windows.Forms.NumericUpDown numericUpDown_posX;
    }
}

