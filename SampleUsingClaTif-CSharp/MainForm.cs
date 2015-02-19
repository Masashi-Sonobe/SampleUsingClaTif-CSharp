/////////////////////////////////////////////////////////////////////////////////////////
// Sample Using ClaTif
//
//  Copyright (c) 2015  Masashi Sonobe
//
//  This class library is released under the MIT License. 
//
//  http://opensource.org/licenses/MIT
//
/////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

using Snb.Image.TifRW;
using Snb.Image;

namespace SampleUsingClaTif_CSharp
{
    public partial class MainForm : Form
    {
        ClaTif tif;

        public MainForm()
        {
            InitializeComponent();

            tif = new ClaTif();
        }

        /// <summary>
        /// Using ClaTif, Open tif file
        /// ClaTifを使ってTifファイルを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdForTiff = new OpenFileDialog();

            // 初期ファイル名・フォルダ指定 
            //  Set folder and file name
            ofdForTiff.FileName = "default.tif";
            ofdForTiff.InitialDirectory = @"C:\";
            
            // Tif指定 
            // Extension Tif only
            ofdForTiff.Filter = "TIF(*.tif;*.TIF)|*.tif;*.TIF";

            // [ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            ofdForTiff.FilterIndex = 2;
            
            // タイトルを設定する
            // Set title
            ofdForTiff.Title = "Select Tif Image";

            // ダイアログを表示する
            // Show Dialog
            if (ofdForTiff.ShowDialog() == DialogResult.OK)
            {

                tif.optionForTagInterpreter = "UseTagInterpreter";
                int res = tif.ReadTiff(ofdForTiff.FileName, (int)ClaTiffSuspendFlag.ReadTif_No_Suspend);

                if ((int)ClaTiffErr.NoError == res)
                {
                    // 画像保存ボタンを有効化
                    button_SaveBmp.Enabled = true;

                    // 画像のビット数を表示する
                    // Check image Bit
                    switch (tif.imgData[0].iImgType)
                    {
                        case ImgType.bilevelImg:
                            radioButton_1bitMono.Checked = true;
                            break;
                        case ImgType.gryImg_8:
                            radioButton_8bitGray.Checked = true;
                            break;
                        case ImgType.gryImg_16:
                            radioButton_16bitGray.Checked = true;
                            break;
                        case ImgType.gryImg_Sgl:
                            radioButton_32bitGray.Checked = true;
                            break;
                    }
                }
            }

        }

        /// <summary>
        /// Save Bmp Image Using ImageUtil from ClaTif memory array.
        /// ImageUtilを使って,ClaTifのメモリ配列をBmp画像として保存する 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SaveBmp_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdForBmp = new SaveFileDialog();


            // 初期ファイル名・フォルダ指定 
            //  Set folder and file name
            sfdForBmp.FileName = "default.bmp";
            sfdForBmp.InitialDirectory = @"C:\";
            
            // Bmp 指定 
            // Extension Bmp only
            sfdForBmp.Filter = "Bmp(*.bmp;*.BMP)|*.bmp;*.BMP";

            // [ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            sfdForBmp.FilterIndex = 2;
            
            // タイトルを設定する
            // Set title
            sfdForBmp.Title = "Save Image as bmp";

            // ダイアログを表示する
            // Show Dialog
            if (sfdForBmp.ShowDialog() == DialogResult.OK)
            {
                // Save Image From memory
                switch (tif.imgData[0].iImgType)
                {
                    case ImgType.bilevelImg:
                        ImageUtil.Save8bitBitmapFromMemory(sfdForBmp.FileName,
                                                           tif.imgData[0].blvImg,
                                                           (int)tif.imgData[0].imageWidth, (int)tif.imgData[0].imageLength);
                        break;
                    case ImgType.gryImg_8:
                        ImageUtil.Save8bitBitmapFromMemory(sfdForBmp.FileName,
                                                           tif.imgData[0].gryImg_8,
                                                           (int)tif.imgData[0].imageWidth, (int)tif.imgData[0].imageLength);
                        break;
                    case ImgType.gryImg_16:
                        ImageUtil.Save8bitBitmapFrom16bitMemory(sfdForBmp.FileName,
                                                                tif.imgData[0].gryImg_16,
                                                                (int)tif.imgData[0].imageWidth, (int)tif.imgData[0].imageLength);
                        break;
                    case ImgType.gryImg_Sgl:
                        ImageUtil.Save8bitBitmapFrom32bitMemory(sfdForBmp.FileName,
                                                                tif.imgData[0].gryImg_Sgl,
                                                                (int)tif.imgData[0].imageWidth, (int)tif.imgData[0].imageLength);
                        break;
                }
            }

        }
    }
}
