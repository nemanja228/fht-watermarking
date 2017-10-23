using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace FHTWatermarking
{
    public partial class MainForm : Form
    {
        Bitmap _coverImage;
        Bitmap _watermark;
        Bitmap _watermarkedImage;

        Bitmap _attackedImage;
        Bitmap _recoveredWatermark;

        WatermarkingStrategy _strategyAndChecker;


        public MainForm()
        {
            InitializeComponent();

            #region Initialization

            BtnEmbed.Enabled = false;

            //Strategies combobox
            string[] watermarkingStrategies = new string[] { "Blind FHT + DCT", "Informed FHT + SVD" };
            CmbBoxStrategy.Items.Clear();
            for (int i = 0; i < watermarkingStrategies.Length; i++)
            {
                CmbBoxStrategy.Items.Add(watermarkingStrategies[i]);
            }
            CmbBoxStrategy.SelectedIndex = 0;

            //Attacks combobox
            string[] imageAttacks = new string[]
            {
                "No Attack",
                "Salt and Pepper",
                "Dithering",
                "Sharpen",
                "Blur",
                "Histogram Equalization",
                "Median Filter",
                "JPEG Compression",
                "Rotation",
                "Flip"
            };
            CmbBoxAttacks.Items.Clear();
            for (int i = 0; i < imageAttacks.Length; i++)
            {
                CmbBoxAttacks.Items.Add(imageAttacks[i]);
            }
            CmbBoxAttacks.SelectedIndex = 0;

            //CmbBoxFibonacci.Items.Clear();
            //CmbBoxFibonacci.Items.Add(0);
            //CmbBoxFibonacci.SelectedIndex = 0;

            RefreshStatus();

            #endregion
        }

        private void RefreshFibonacci()
        {
            CmbBoxFibonacci.Items.Clear();
            if (ImgCoverImage.Image.Width > 0 && ImgCoverImage.Image.Width == ImgCoverImage.Image.Height)
            {
                var fibSequence = FibonacciSequence.UsableSequences(ImgCoverImage.Image.Width);
                List<int> filteredFib = new List<int>(fibSequence);
                if(_coverImage.Width > 7)
                    filteredFib = fibSequence.Select(x => x).Where(x => x < _coverImage.Width - (int) Math.Pow(2, (int) Math.Log(_coverImage.Width, 2) - 2)).ToList();
                for (int i = 0; i < filteredFib.Count; i++)
                {
                    CmbBoxFibonacci.Items.Add(filteredFib[i]);
                }
                CmbBoxFibonacci.SelectedIndex = 0;
            }
        }

        private void RefreshStatus()
        {
            bool flagCover = false, flagWatermark = false, flagAlpha = false;

            if (double.TryParse(TxtBoxEmbeddingStrength.Text, out double alpha))
                flagAlpha = true;
            if(_strategyAndChecker != null)
                LblEmbeddingRecommended.Text = String.Format("(Recommended value is {0})", _strategyAndChecker.GetRecommendedAlpha().ToString());

            //Cover image
            if (_coverImage != null)
            {
                if (_coverImage.Width == _coverImage.Height)
                {
                    LblCoverImageStatus.Text = "OK";
                    flagCover = true;
                }
                else if (_coverImage == null)
                    LblCoverImageStatus.Text = "-";
                else
                    LblCoverImageStatus.Text = "Image dimensions not square!";
            }

            //Watermark
            if (_watermark != null && _strategyAndChecker != null)
            {
                if (_coverImage != null)
                {
                    int capacity = _strategyAndChecker.MaximumCapacity();
                    if (ImageUtility.WatermarkInformationSize(_watermark, CmbBoxStrategy.SelectedIndex == 2 ? false : true) <= capacity)
                    {
                        LblWatermarkStatus.Text = "OK";
                        flagWatermark = true;
                    }
                    else
                        LblWatermarkStatus.Text = "Watermark too big!";
                    LblCapacity.Text = capacity.ToString();
                }
                LblWatermarkSize.Text = _watermark.Width.ToString() + "x" + _watermark.Height.ToString() + "px  " + _strategyAndChecker.GetWatermarkSizeMessageUnit(_watermark.Width * _watermark.Height);
            }

            if (flagCover && flagWatermark && flagAlpha)
                BtnEmbed.Enabled = true;
            else
                BtnEmbed.Enabled = false;
        }


        private void BtnCoverImageLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePath = new OpenFileDialog();
            filePath.Filter = "Image|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff";
            DialogResult result = filePath.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtBoxCoverImagePath.Text = filePath.FileName;

                var sizeCheck = new Bitmap(TxtBoxCoverImagePath.Text);
                if (sizeCheck.Width != sizeCheck.Height)
                {
                    LblCoverImageStatus.Text = "Image dimensions not square!";
                    TxtBoxCoverImagePath.Text = "";
                    return;
                }

                ImgCoverImage.Image.Dispose();

                _coverImage = sizeCheck;
                ImgCoverImage.Image = _coverImage;

                LblCoverImageSize.Text = _coverImage.Width.ToString() + "x" + _coverImage.Height.ToString() + "px";
                RefreshFibonacci();
                if (_strategyAndChecker == null)
                    NewStrategy();
                TxtBoxEmbeddingStrength.Text = _strategyAndChecker.GetRecommendedAlpha().ToString();
                RefreshStatus();
            }
        }

        private void BtnWatermarkLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePath = new OpenFileDialog();
            filePath.Filter = "Image|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff";
            DialogResult result = filePath.ShowDialog();
            if (result == DialogResult.OK)
            {
                ImgWatermark.Image.Dispose();

                TxtBoxWatermarkPath.Text = filePath.FileName;
                _watermark = new Bitmap(TxtBoxWatermarkPath.Text);
                var tmp = new Bitmap(ImgWatermark.Width, ImgWatermark.Height);
                using (Graphics g = Graphics.FromImage(tmp))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(_watermark, 0, 0, ImgWatermark.Width, ImgWatermark.Height);
                }
                ImgWatermark.Image = tmp;

                RefreshStatus();
            }
        }

        private void BtnWatermarkedImageSave_Click(object sender, EventArgs e)
        {
            if (_watermarkedImage == null)
                return;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPEG|*.jpg|PNG|*.png;|BMP|*.bmp;|GIF|*.gif;|TIFF|*.tiff";
            dialog.AddExtension = true;
            String destinationPath = null;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                destinationPath = dialog.FileName;
                try
                {
                    _watermarkedImage.Save(destinationPath, ImageUtility.GetImageFormat(destinationPath));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

        }

        private void BtnRecoveredWatermarkSave_Click(object sender, EventArgs e)
        {
            //if (_recoveredWatermark == null)
            //    return;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPEG|*.jpg|PNG|*.png;|BMP|*.bmp;|GIF|*.gif;|TIFF|*.tiff";
            dialog.AddExtension = true;
            String destinationPath = null;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                destinationPath = dialog.FileName;
                try
                {
                    _recoveredWatermark.Save(destinationPath, ImageUtility.GetImageFormat(destinationPath));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }


        private void BtnEmbed_Click(object sender, EventArgs e)
        {
            if (CmbBoxStrategy.SelectedIndex == 0)//BlindDCT
            {
                _strategyAndChecker = new BlindDCT((int)CmbBoxFibonacci.Items[CmbBoxFibonacci.SelectedIndex], _coverImage.Width, double.Parse(TxtBoxEmbeddingStrength.Text));
                LblBER.Visible = true;
                LblBERText.Visible = true;
            }
            else if (CmbBoxStrategy.SelectedIndex == 1)//InformedSVD
            {
                _strategyAndChecker = new InformedSVD((int)CmbBoxFibonacci.Items[CmbBoxFibonacci.SelectedIndex], _coverImage.Width, double.Parse(TxtBoxEmbeddingStrength.Text));
                LblBER.Visible = false;
                LblBERText.Visible = false;
            }


            var sw = Stopwatch.StartNew();
            _watermarkedImage = _strategyAndChecker.EmbedWatermark(_coverImage, _watermark);
            sw.Stop();

            ImgWatermarkedImage.Image = _watermarkedImage;
            ImgWatermarkedImage2.Image = _watermarkedImage;

            LblComputationTimeValue.Text = String.Format("{0}ms", sw.ElapsedMilliseconds);

            CmbBoxAttacks.SelectedIndex = 0;
            ApplyAttack();
        }

        private void BtnRecover_Click(object sender, EventArgs e)
        {
            if (_attackedImage == null || _watermark == null)
                return;

            var sw = Stopwatch.StartNew();
            _recoveredWatermark = _strategyAndChecker.RecoverWatermark(_attackedImage);
            sw.Stop();

            var tmp = new Bitmap(ImgRecoveredWatermark.Width, ImgRecoveredWatermark.Height);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(_recoveredWatermark, 0, 0, ImgRecoveredWatermark.Width, ImgRecoveredWatermark.Height);
            }
            ImgRecoveredWatermark.Image = tmp;

            var ber = Statistics.BER(_watermark, _recoveredWatermark);
            LblBER.Text = String.Format("{0:N9}%", ber);

            var ncc = Statistics.NCC(_watermark, _recoveredWatermark);
            LblNCC.Text = String.Format("{0:N9}", ncc);

            LblComputationTimeValue2.Text = String.Format("{0}ms", sw.ElapsedMilliseconds);
        }

        private void BtnApplyAttack_Click(object sender, EventArgs e)
        {
            ApplyAttack();
        }

        public void ApplyAttack()
        {
            if (_watermarkedImage == null)
            {
                _watermarkedImage = new Bitmap(_coverImage);
                ImgWatermarkedImage2.Image = _watermarkedImage;
            }

            ComboBox combobox = CmbBoxAttacks;

            if (combobox.SelectedIndex == 0)//No Attack
            {
                _attackedImage = _watermarkedImage;
            }
            else if (combobox.SelectedIndex == 1)//Salt and Pepper
            {
                int noiseAmount = 5;
                int.TryParse(TxtBoxAttackParameter.Text, out noiseAmount);
                if (noiseAmount < 0 || noiseAmount > 100)
                {
                    noiseAmount = 5;
                    TxtBoxAttackParameter.Text = noiseAmount.ToString();
                }
                _attackedImage = ImageAttacks.SaltAndPepper(_watermarkedImage, noiseAmount);
            }
            else if (combobox.SelectedIndex == 2)//Dithering
            {
                int paletteSize = 8;
                int.TryParse(TxtBoxAttackParameter.Text, out paletteSize);
                if (paletteSize < 2 || paletteSize > 256)
                {
                    paletteSize = 8;
                    TxtBoxAttackParameter.Text = paletteSize.ToString();
                }
                _attackedImage = ImageAttacks.BurkesColorDithering(_watermarkedImage, paletteSize);
            }
            else if (combobox.SelectedIndex == 3)//Sharpen
            {
                _attackedImage = ImageAttacks.Sharpen(_watermarkedImage);
            }
            else if (combobox.SelectedIndex == 4)//Blur
            {
                _attackedImage = ImageAttacks.Blur(_watermarkedImage);
            }
            else if (combobox.SelectedIndex == 5)//Histogram Equalization
            {
                _attackedImage = ImageAttacks.HistogramEqualization(_watermarkedImage);
            }
            else if (combobox.SelectedIndex == 6)//Median
            {
                int size = 3;
                int.TryParse(TxtBoxAttackParameter.Text, out size);
                if (size % 2 == 0)
                {
                    size = 3;
                    TxtBoxAttackParameter.Text = size.ToString();
                }
                _attackedImage = ImageAttacks.MedianFilter(_watermarkedImage, size);
            }
            else if (combobox.SelectedIndex == 7)//JPEG Compression
            {
                int quality = 50;
                int.TryParse(TxtBoxAttackParameter.Text, out quality);
                if (quality < 1 || quality > 100)
                {
                    quality = 50;
                    TxtBoxAttackParameter.Text = quality.ToString();
                }
                _attackedImage = ImageAttacks.JPEGCompression(_watermarkedImage, quality);
            }
            else if (combobox.SelectedIndex == 8)//Rotation
            {
                double angle = 5;
                double.TryParse(TxtBoxAttackParameter.Text, out angle);
                _attackedImage = ImageAttacks.Rotation(_watermarkedImage, angle, true);
            }
            else if (combobox.SelectedIndex == 9)//Flip
            {
                _attackedImage = ImageAttacks.Flip(_watermarkedImage, chkBoxAxisX.Checked, chkBoxAxisY.Checked);
            }

            ImgAttackedImage.Image = _attackedImage;

            var psnr = Statistics.PSNR(_coverImage, _attackedImage).ToString();
            LblPSNR.Text = psnr.Length > 7 ? psnr.Substring(0, 7) : psnr;
        }

        private void NewStrategy()
        {
            if (CmbBoxStrategy.SelectedIndex == 0)//BlindDCT
            {
                _strategyAndChecker = new BlindDCT((int)CmbBoxFibonacci.Items[CmbBoxFibonacci.SelectedIndex], _coverImage.Width);
            }
            else if (CmbBoxStrategy.SelectedIndex == 1)//InformedSVD
            {
                _strategyAndChecker = new InformedSVD((int)CmbBoxFibonacci.Items[CmbBoxFibonacci.SelectedIndex], _coverImage.Width);
            }

        }

        private void CmbBoxStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_coverImage != null)
            {
                NewStrategy();

                TxtBoxEmbeddingStrength.Text = _strategyAndChecker.GetRecommendedAlpha().ToString();
                RTxtBoxWatermarkManual.Text = "Watermark should be " + _strategyAndChecker.GetWatermarkManualMessage();

                RefreshStatus();
            }
            
        }

        private void CmbBoxFibonacci_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewStrategy();

            RefreshStatus();
        }

        private void CmbBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (combobox.SelectedIndex == 0)//No Attack
            {
                GrpBoxAttackParameter.Visible = false;
                GrpBoxAttackParameter2.Visible = false;
            }
            else if (combobox.SelectedIndex == 1)//Salt and Pepper
            {
                LblAttackParameter.Text = "Noise Amount( Integer, [0-100] ):";
                TxtBoxAttackParameter.Text = "5";
                GrpBoxAttackParameter2.Visible = false;
                GrpBoxAttackParameter.Visible = true;
            }
            else if (combobox.SelectedIndex == 2)//Dithering
            {
                LblAttackParameter.Text = "Color palette size( Integer, [2-256] ):";
                TxtBoxAttackParameter.Text = "8";
                GrpBoxAttackParameter2.Visible = false;
                GrpBoxAttackParameter.Visible = true;
            }
            else if (combobox.SelectedIndex == 3)//Sharpen
            {
                GrpBoxAttackParameter.Visible = false;
                GrpBoxAttackParameter2.Visible = false;
            }
            else if (combobox.SelectedIndex == 4)//Blur
            {
                GrpBoxAttackParameter.Visible = false;
                GrpBoxAttackParameter2.Visible = false;
            }
            else if (combobox.SelectedIndex == 5)//Histogram Equalization
            {
                GrpBoxAttackParameter.Visible = false;
                GrpBoxAttackParameter2.Visible = false;
            }
            else if (combobox.SelectedIndex == 6)//Median
            {
                LblAttackParameter.Text = "Square size( Integer (Odd), [3-25] ):";
                TxtBoxAttackParameter.Text = "3";
                GrpBoxAttackParameter2.Visible = false;
                GrpBoxAttackParameter.Visible = true;
            }
            else if (combobox.SelectedIndex == 7)//JPEG Compression
            {
                LblAttackParameter.Text = "JPEG Quality( Integer, [1-100] ):";
                TxtBoxAttackParameter.Text = "50";
                GrpBoxAttackParameter2.Visible = false;
                GrpBoxAttackParameter.Visible = true;
            }
            else if (combobox.SelectedIndex == 8)//Rotation
            {
                LblAttackParameter.Text = "Rotation angle( Decimal, [0-360] ):";
                TxtBoxAttackParameter.Text = "5";
                GrpBoxAttackParameter2.Visible = false;
                GrpBoxAttackParameter.Visible = true;
            }
            else if (combobox.SelectedIndex == 9)//Flip
            {
                GrpBoxAttackParameter.Visible = false;
                chkBoxAxisX.Checked = false;
                chkBoxAxisY.Checked = false;
                GrpBoxAttackParameter2.Visible = true;
            }
        }

        private void TxtBoxEmbeddingStrength_Leave(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private void TxtBoxEmbeddingStrength_TextChanged(object sender, EventArgs e)
        {
            RefreshStatus();
        }
    }
}
