/////////////////////////////////////////////////////////////////////////////////////////
// ImageUtil Class Library (for Function)
//
//  Copyright (c) 2015  Masashi Sonobe
//
//  This class library is released under the MIT License. 
//
//  http://opensource.org/licenses/MIT
//
/////////////////////////////////////////////////////////////////////////////////////////

using System;

using System.Drawing;                 // Bitmap用
using System.Drawing.Imaging;         // Encoder用
using System.Runtime.InteropServices; // Marshal用

namespace Snb
{
namespace Image
{
    /// <summary>
    /// 画像を扱うための関数郡
    /// </summary>
    public class ImageUtil
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //　1bpp圧縮画像作成・保存
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 指定されたメモリ画像から1bpp(1bit per 1pixel)のBitmapイメージを作成する(memory byte[]→ mono 1bpp image)
        /// </summary>
        /// <param name="imgOri">基になる画像(メモリ)</param>
        /// <param name="imgWidth">基になる画像の幅</param>
        /// <param name="imgHeight">基になる画像の長さ</param>
        /// <returns>1bppに変換されたイメージ</returns>
        public static Bitmap Create1bppImageFromMemory(byte[] imgOri, int imgWidth, int imgHeight)
        {
            //1bppイメージを作成する
            Bitmap newImg = new Bitmap(imgWidth, imgHeight, PixelFormat.Format1bppIndexed);

            //Bitmapをロックする
            BitmapData bmpData = newImg.LockBits(
                new Rectangle(0, 0, newImg.Width, newImg.Height),
                ImageLockMode.WriteOnly, newImg.PixelFormat);

            //新しい画像のピクセルデータを作成する
            // (元画像の8バイトを新しい画像の1バイトの中に収める)
            byte[] pixels = new byte[bmpData.Stride * bmpData.Height];

            //imgOri → pixelsに書き込み
            for (int y = 0; y < bmpData.Height; y++)
            {
                for (int x = 0; x < bmpData.Width; x++)
                {
                    //元画像の明るさが255のときは白として書き込む
                    if (255 == imgOri[x + y * imgWidth])
                    {
                        //ピクセルデータの位置(元画像の8byte分までを，書き込み先の画像の1byteの中に書き込む)
                        int pos = (x >> 3) + bmpData.Stride * y;

                        //白くする目的の位置のバイトの中の，さらに目的のビットを立てる。
                        pixels[pos] |= (byte)(0x80 >> (x & 0x7));
                    }
                }
            }

            //作成したピクセルデータ(pixels)をnewImgにコピーする
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(pixels, 0, ptr, pixels.Length);

            //ロックを解除する
            newImg.UnlockBits(bmpData);

            return newImg;
        }

        /// <summary>
        /// 1bppの画像(Bitmap)から中身のメモリ画像を抽出する (mono 1bpp image→memory byte[])
        /// </summary>
        /// <param name="img">中身を取り出したい画像</param>
        /// <param name="imgOut">中身のメモリ画像(out)</param>
        public static void ExtractMemoryFrom1bppImage(Bitmap img, byte[] imgOut)
        {
            //Bitmapをロックする
            BitmapData bmpData = img.LockBits(
                new Rectangle(0, 0, img.Width, img.Height),
                ImageLockMode.WriteOnly, img.PixelFormat);

            //中身を取り出すためのバッファを用意する
            byte[] pixels = new byte[bmpData.Stride * bmpData.Height];

            //作成したピクセルデータをコピーする
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(ptr, pixels, 0, pixels.Length);

            //新しい画像のピクセルデータを作成する
            // (元画像の8バイトを新しい画像の1バイトの中に収める)
            for (int y = 0; y < bmpData.Height; ++y)
            {
                for (int x = 0; x < bmpData.Width; ++x)
                {
                    //ピクセルデータの位置(元画像の8byte分までを，書き込み先の画像の1byteの中に書き込む)を計算する
                    int pos = (x >> 3) + bmpData.Stride * y;

                    //目的のビットが立っているかどうか
                    if ((pixels[pos] & (byte)(0x80 >> (x & 0x7))) == (byte)(0x80 >> (x & 0x7)))
                    {
                        //目的のビットが立っていれば白に
                        imgOut[x + y * bmpData.Width] = 255;
                    }
                    else
                    {
                        //目的のビットが立っていなければ黒に
                        imgOut[x + y * bmpData.Width] = 0;
                    }

                }
            }

            //ロックを解除する
            img.UnlockBits(bmpData);
        }


        /// <summary>
        /// 8bppの画像(Bitmap)から中身のメモリ画像を抽出する (gray 8bpp image→memory byte[])
        /// </summary>
        /// <param name="img">中身を取り出したい画像</param>
        /// <param name="imgOut">中身のメモリ画像(out)</param>
        public static void ExtractMemoryFrom8bppImage(Bitmap img, byte[] imgOut)
        {
            //Bitmapをロックする
            BitmapData bmpData = img.LockBits(
                new Rectangle(0, 0, img.Width, img.Height),
                ImageLockMode.WriteOnly, img.PixelFormat);

            //中身を取り出すためのバッファを用意する
            byte[] pixels = new byte[bmpData.Stride * bmpData.Height];

            //作成したピクセルデータをコピーする
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(ptr, pixels, 0, pixels.Length);

            //新しい画像のピクセルデータを作成する
            for (int y = 0; y < bmpData.Height; ++y)
            {
                for (int x = 0; x < bmpData.Width; ++x)
                {
                    int pos = x + bmpData.Stride * y;

                    imgOut[x + y * bmpData.Width] = pixels[pos];
                }
            }

            //ロックを解除する
            img.UnlockBits(bmpData);
        }


        /// <summary>
        /// 1bppのイメージを圧縮してTifで保存する ( mono 1bpp image(uncompressed)→ save mono 1bpp .bmp(compressed))
        /// </summary>
        /// <param name="img">圧縮保存する画像s</param>
        /// <param name="fimeName">ファイル名</param>
        /// <param name="compressionScheme">圧縮方法指定パラメータ</param>
        public static void SaveComp1bppTif(Bitmap img, string fileName, EncoderValue compressionScheme)
        {
            if (compressionScheme != EncoderValue.CompressionCCITT3 &&
                    compressionScheme != EncoderValue.CompressionCCITT4 &&
                    compressionScheme != EncoderValue.CompressionLZW &&
                    compressionScheme != EncoderValue.CompressionNone &&
                    compressionScheme != EncoderValue.CompressionRle)
            {
                throw new ArgumentException("compressionScheme");
            }

            //TIFFのImageCodecInfoを取得する
            ImageCodecInfo ici = GetEncoderInfo("image/tiff");
            if (ici == null)
            {
                return;
            }

            //圧縮方法指定
            EncoderParameters encParam = new EncoderParameters(1);
            encParam.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressionScheme);

            //画像保存
            img.Save(fileName, ici, encParam);

            //後片付け
            encParam.Dispose();
            encParam = null;

            return;

        }

        /// <summary>
        /// MimeTypeで指定されたImageCodecInfoを探して返す
        /// 元ネタ msdn
        /// </summary>
        /// <param name="mimeType">指定したMimeType</param>
        /// <returns>指定したTypeが存在すれば</returns>
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            //イメージエンコーダを全て取得
            ImageCodecInfo[] endcorders = ImageCodecInfo.GetImageEncoders();

            //指定されたMimeTypeを探して見つかれば返す
            foreach (ImageCodecInfo curEnc in endcorders)
            {
                if (curEnc.MimeType == mimeType)
                {
                    return curEnc;
                }
            }
            return null;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //　画像保存
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 16bit(ushort)グレーの配列要素を256で割って，8bitグレーのBitmapで保存する (memory ushort[]/256 → save 8bit gray .bmp)
        /// Convert 16bit to 8bit dividing by 256, Save 8bit Image
        /// </summary>
        /// <param name="saveFileName">保存ファイル名</param>
        /// <param name="imgGry16">ushort(16bit)配列</param>
        /// <param name="imgWidth">画像幅</param>
        /// <param name="imgHeight">画像高さ</param>
        public static void Save8bitBitmapFrom16bitMemory(string saveFileName, ushort[] imgGry16, int imgWidth, int imgHeight)
        {

            //変換された画像
            using (Bitmap convertedImg = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
            {

                //パレット作成
                ColorPalette pal = convertedImg.Palette;

                for (int i = 0; i < 256; ++i)
                {
                    pal.Entries[i] = Color.FromArgb(i, i, i);
                }

                convertedImg.Palette = pal;

                //BitmapDataの作成
                BitmapData bmpdata = null;

                bmpdata = convertedImg.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
                                        ImageLockMode.WriteOnly,
                                        PixelFormat.Format8bppIndexed);

                //バッファを用意
                byte[] buf = new byte[imgWidth * imgHeight];

                //画像の変換とBitmap内への書き込み
                try
                {

                    for (int j = 0; j < imgWidth * imgHeight; ++j)
                    {
                        buf[j] = (byte)(imgGry16[j] / 256);
                    }


                    for (int j = 0; j < imgHeight; ++j)
                    {
                        IntPtr dst_line = (IntPtr)((Int64)bmpdata.Scan0 + j * bmpdata.Stride);
                        Marshal.Copy(buf, j * imgWidth, dst_line, imgWidth);
                    }

                }
                finally
                {
                    if (bmpdata != null)
                    {
                        convertedImg.UnlockBits(bmpdata);
                    }
                }

                //画像保存
                convertedImg.Save(saveFileName, ImageFormat.Bmp);

            }
        }

        /// <summary>
        /// 32bit(float)グレーの配列要素を256かけて，8bitグレーのBitmapで保存する (memory float[]*256 → save 8bit gray .bmp)
        /// Convert 32bit to 8bit by multiplying 256, Save 8bit Image
        /// </summary>
        /// <param name="saveFileName">保存ファイル名</param>
        /// <param name="imgGry16">ushort(16bit)配列</param>
        /// <param name="imgWidth">画像幅</param>
        /// <param name="imgHeight">画像高さ</param>
        public static void Save8bitBitmapFrom32bitMemory(string saveFileName, float[] imgGry32, int imgWidth, int imgHeight)
        {

            //変換された画像
            using (Bitmap convertedImg = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
            {

                //パレット作成
                ColorPalette pal = convertedImg.Palette;

                for (int i = 0; i < 256; ++i)
                {
                    pal.Entries[i] = Color.FromArgb(i, i, i);
                }

                convertedImg.Palette = pal;

                //BitmapDataの作成
                BitmapData bmpdata = null;

                bmpdata = convertedImg.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
                                        ImageLockMode.WriteOnly,
                                        PixelFormat.Format8bppIndexed);

                //バッファを用意
                byte[] buf = new byte[imgWidth * imgHeight];

                //画像の変換とBitmap内への書き込み
                try
                {

                    for (int j = 0; j < imgWidth * imgHeight; ++j)
                    {
                        buf[j] = (byte)(imgGry32[j] * 256);
                    }


                    for (int j = 0; j < imgHeight; ++j)
                    {
                        IntPtr dst_line = (IntPtr)((Int64)bmpdata.Scan0 + j * bmpdata.Stride);
                        Marshal.Copy(buf, j * imgWidth, dst_line, imgWidth);
                    }

                }
                finally
                {
                    if (bmpdata != null)
                    {
                        convertedImg.UnlockBits(bmpdata);
                    }
                }

                //画像保存
                convertedImg.Save(saveFileName, ImageFormat.Bmp);

            }
        }

        /// <summary>
        /// 8bitのグレーの配列からBitmapを作成して保存 (memory byte[] → save 8bit gray .bmp)
        /// Save 8bit Bitmap
        /// </summary>
        /// <param name="saveFileName">保存ファイル名</param>
        /// <param name="imgGry8">byte(8bit)配列</param>
        /// <param name="imgWidth">画像幅</param>
        /// <param name="imgHeight">画像高さ</param>
        public static void Save8bitBitmapFromMemory(string saveFileName, byte[] imgGry8, int imgWidth, int imgHeight)
        {

            //変換された画像
            using (Bitmap convertedImg = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
            {

                //パレット作成
                ColorPalette pal = convertedImg.Palette;

                for (int i = 0; i < 256; ++i)
                {
                    pal.Entries[i] = Color.FromArgb(i, i, i);
                }

                convertedImg.Palette = pal;

                //BitmapDataの作成
                BitmapData bmpdata = null;

                bmpdata = convertedImg.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
                                        ImageLockMode.WriteOnly,
                                        PixelFormat.Format8bppIndexed);

                //画像の変換とBitmap内への書き込み
                try
                {
                    for (int j = 0; j < imgHeight; ++j)
                    {
                        IntPtr dst_line = (IntPtr)((Int64)bmpdata.Scan0 + j * bmpdata.Stride);
                        Marshal.Copy(imgGry8, j * imgWidth, dst_line, imgWidth);
                    }

                }
                finally
                {
                    if (bmpdata != null)
                    {
                        convertedImg.UnlockBits(bmpdata);
                    }
                }

                //画像保存
                convertedImg.Save(saveFileName, ImageFormat.Bmp);
            }
        }


        /// <summary>
        /// 8bitのグレーの配列からTifを作成して圧縮して保存 (memory byte[] → save 8bit gray .tif)
        /// Save 8bit Tif 
        /// </summary>
        /// <param name="saveFileName">保存ファイル名</param>
        /// <param name="imgGry8">byte(8bit)配列</param>
        /// <param name="imgWidth">画像幅</param>
        /// <param name="imgHeight">画像高さ</param>
        /// <param name="compressionSchemet">圧縮方法</param>
        public static void Save8bitTifFromMemory(string saveFileName, byte[] imgGry8, int imgWidth, int imgHeight, EncoderValue compressionScheme)
        {

            //変換された画像
            using (Bitmap convertedImg = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
            {
                //パレット作成
                ColorPalette pal = convertedImg.Palette;

                for (int i = 0; i < 256; ++i)
                {
                    pal.Entries[i] = Color.FromArgb(i, i, i);
                }

                convertedImg.Palette = pal;

                //BitmapDataの作成
                BitmapData bmpdata = null;

                bmpdata = convertedImg.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
                                        ImageLockMode.WriteOnly,
                                        PixelFormat.Format8bppIndexed);

                //画像の変換とBitmap内への書き込み
                try
                {
                    for (int j = 0; j < imgHeight; ++j)
                    {
                        IntPtr dst_line = (IntPtr)((Int64)bmpdata.Scan0 + j * bmpdata.Stride);
                        Marshal.Copy(imgGry8, j * imgWidth, dst_line, imgWidth);
                    }

                }
                finally
                {
                    if (bmpdata != null)
                    {
                        convertedImg.UnlockBits(bmpdata);
                    }
                }

                if (compressionScheme != EncoderValue.CompressionLZW &&
                        compressionScheme != EncoderValue.CompressionNone &&
                        compressionScheme != EncoderValue.CompressionRle)
                {
                    throw new ArgumentException("compressionScheme");
                }

                //TIFFのImageCodecInfoを取得する
                ImageCodecInfo ici = GetEncoderInfo("image/tiff");
                if (ici == null)
                {
                    return;
                }

                //圧縮方法指定
                EncoderParameters encParam = new EncoderParameters(1);
                encParam.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressionScheme);


                //画像保存
                convertedImg.Save(saveFileName, ici, encParam);
            }
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //テストパターンを作成する関数
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// テストパターン001 市松模様的なパターンを作成する(白黒 白:255 黒:0)
        /// </summary>
        /// <param name="imgWidth">画像の幅</param>
        /// <param name="imgHeight">画像の高さ</param>
        /// <param name="img">メモリ画像(in/out)</param>
        public static void TestPattern001(int imgWidth, int imgHeight, byte[] img)
        {

            for (int j = 0; j < imgHeight; ++j)
            {
                for (int i = 0; i < imgWidth; ++i)
                {
                    if (j % 2 == 0)
                    {
                        if (i % 2 == 0)
                        {
                            img[i + j * imgWidth] = 255;
                        }
                        else
                        {
                            img[i + j * imgWidth] = 0;
                        }
                    }
                    else
                    {
                        if (i % 3 == 0)
                        {
                            img[i + j * imgWidth] = 255;
                        }
                        else
                        {
                            img[i + j * imgWidth] = 0;
                        }
                    }

                }
            }

        }

        /// <summary>
        /// テストパターン002 市松模様的なパターンを作成する (白黒 白:255 黒:0)
        /// </summary>
        /// <param name="imgWidth">画像の幅</param>
        /// <param name="imgHeight">画像の高さ</param>
        /// <param name="img">メモリ画像(in/out)</param>
        public static void TestPattern002(int imgWidth, int imgHeight, byte[] img)
        {

            for (int j = 0; j < imgHeight; ++j)
            {
                for (int i = 0; i < imgWidth; ++i)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            img[i + j * imgWidth] = 255;
                        }
                        else
                        {
                            img[i + j * imgWidth] = 0;
                        }
                    }
                    else
                    {
                        if (j % 3 == 0)
                        {
                            img[i + j * imgWidth] = 255;
                        }
                        else
                        {
                            img[i + j * imgWidth] = 0;
                        }
                    }

                }
            }

        }

        /// <summary>
        /// テストパターン003 縦線・右に行くほど太くなるバーコード (白黒 白:255 黒:0)
        /// </summary>
        /// <param name="imgWidth">画像の幅</param>
        /// <param name="imgHeight">画像の高さ</param>
        /// <param name="img">メモリ画像(in/out)</param>
        public static void TestPattern003(int imgWidth, int imgHeight, byte[] img)
        {

            for (int j = 0; j < imgHeight; ++j)
            {
                bool bLoop = true;
                int curPosImg = 0;
                int lengthOfBar = 1;

                while (bLoop)
                {
                    for (int i = 0; i < lengthOfBar; ++i)
                    {
                        img[curPosImg + j * imgWidth] = 255;

                        ++curPosImg;

                        if (curPosImg >= imgWidth)
                        {
                            bLoop = false;
                            break;
                        }
                    }

                    //ループを抜ける
                    if (false == bLoop)
                    {
                        break;
                    }

                    for (int i = 0; i < lengthOfBar; ++i)
                    {
                        img[curPosImg + j * imgWidth] = 0;

                        ++curPosImg;

                        if (curPosImg >= imgWidth)
                        {
                            bLoop = false;
                            break;
                        }
                    }

                    //ループを抜ける
                    if (false == bLoop)
                    {
                        break;
                    }

                    ++lengthOfBar;

                }

            }
        }

        /// <summary>
        /// テストパターン004  横線・下に行くほど太くなるバーコード(白黒 白:255 黒:0)
        /// </summary>
        /// <param name="imgWidth">画像の幅</param>
        /// <param name="imgHeight">画像の高さ</param>
        /// <param name="img">メモリ画像(in/out)</param>
        public static void TestPattern004(int imgWidth, int imgHeight, byte[] img)
        {

            bool bLoop = true;
            int curPosImg = 0;
            int lengthOfBar = 1;

            while (bLoop)
            {
                for (int i = 0; i < lengthOfBar; ++i)
                {
                    for (int j = 0; j < imgWidth; ++j)
                    {
                        img[j + curPosImg * imgWidth] = 255;
                    }

                    ++curPosImg;

                    if (curPosImg >= imgHeight)
                    {
                        bLoop = false;
                        break;
                    }
                }

                //ループを抜ける
                if (false == bLoop)
                {
                    break;
                }

                for (int i = 0; i < lengthOfBar; ++i)
                {
                    for (int j = 0; j < imgWidth; ++j)
                    {
                        img[j + curPosImg * imgWidth] = 0;
                    }

                    ++curPosImg;

                    if (curPosImg >= imgHeight)
                    {
                        bLoop = false;
                        break;
                    }
                }

                //ループを抜ける
                if (false == bLoop)
                {
                    break;
                }

                ++lengthOfBar;

            }

        }

        /// <summary>
        /// テストパターン005  線形合同法による乱数画像(白黒 白:255 黒:0)
        /// </summary>
        /// <param name="imgWidht"></param>
        /// <param name="imgHeight"></param>
        /// <param name="img"></param>
        public static void TestPattern005(int imgWidht, int imgHeight, byte[] img)
        {
            MyRandum rand = new MyRandum();

            for (int i = 0; i < imgHeight * imgWidht; ++i)
            {
                double getRandum = rand.UniformRandum();

                if (getRandum < 0.5000001)
                {
                    img[i] = 0;
                }
                else
                {
                    img[i] = 255;
                }

            }
        }


        /// <summary>
        /// テストパターン006  真っ黒 (白黒 白:255 黒:0)
        /// </summary>
        /// <param name="imgWidht"></param>
        /// <param name="imgHeight"></param>
        /// <param name="img"></param>
        public static void TestPattern006(int imgWidht, int imgHeight, byte[] img)
        {
            for (int i = 0; i < imgHeight * imgWidht; ++i)
            {
                img[i] = 0;
            }
        }

        /// <summary>
        /// テストパターン007  真っ白 (白黒 白:255 黒:0)
        /// </summary>
        /// <param name="imgWidht"></param>
        /// <param name="imgHeight"></param>
        /// <param name="img"></param>
        public static void TestPattern007(int imgWidht, int imgHeight, byte[] img)
        {
            for (int i = 0; i < imgHeight * imgWidht; ++i)
            {
                img[i] = 255;
            }
        }

    }

    /// <summary>
    /// 乱数発生クラス
    /// </summary>
    public class MyRandum
    {
        int randomSeed = 10;
        int randomRange = 1681213581;

        /// <summary>
        /// 線形合同法による乱数
        /// </summary>
        /// <returns></returns>
        public double UniformRandum()
        {
            int a = 1383125132, b = 65478;
            randomSeed = (a * randomSeed + b) & randomRange;

            return ((double)randomSeed + 1.0) / ((double)randomRange + 2.0);
        }
    }

}//namespace Image
}//namespace Snb