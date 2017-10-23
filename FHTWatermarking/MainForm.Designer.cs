namespace FHTWatermarking
{
    partial class MainForm
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tab_Embed = new System.Windows.Forms.TabPage();
            this.GrpBoxInfo = new System.Windows.Forms.GroupBox();
            this.LblCapacity = new System.Windows.Forms.Label();
            this.LblCapacityDesc = new System.Windows.Forms.Label();
            this.LblWatermarkSize = new System.Windows.Forms.Label();
            this.LblCoverImageSize = new System.Windows.Forms.Label();
            this.LblWatermarkS = new System.Windows.Forms.Label();
            this.LblCoverImageS = new System.Windows.Forms.Label();
            this.BtnEmbed = new System.Windows.Forms.Button();
            this.LblComputationTimeValue = new System.Windows.Forms.Label();
            this.LblWatermarkStatus = new System.Windows.Forms.Label();
            this.LblCoverImageStatus = new System.Windows.Forms.Label();
            this.LblComputationTime = new System.Windows.Forms.Label();
            this.LblWatermark = new System.Windows.Forms.Label();
            this.LblCoverImage = new System.Windows.Forms.Label();
            this.GrpBoxParameters = new System.Windows.Forms.GroupBox();
            this.LblEmbeddingRecommended = new System.Windows.Forms.Label();
            this.TxtBoxEmbeddingStrength = new System.Windows.Forms.TextBox();
            this.LblEmbedding = new System.Windows.Forms.Label();
            this.CmbBoxStrategy = new System.Windows.Forms.ComboBox();
            this.LblStrategy = new System.Windows.Forms.Label();
            this.LblFibonacci = new System.Windows.Forms.Label();
            this.CmbBoxFibonacci = new System.Windows.Forms.ComboBox();
            this.GrpBoxWatermarkedImage = new System.Windows.Forms.GroupBox();
            this.BtnWatermarkedImageSave = new System.Windows.Forms.Button();
            this.ImgWatermarkedImage = new System.Windows.Forms.PictureBox();
            this.GrpBoxCoverImage = new System.Windows.Forms.GroupBox();
            this.TxtBoxCoverImagePath = new System.Windows.Forms.TextBox();
            this.BtnCoverImageLoad = new System.Windows.Forms.Button();
            this.ImgCoverImage = new System.Windows.Forms.PictureBox();
            this.GrpBoxWatermark = new System.Windows.Forms.GroupBox();
            this.RTxtBoxWatermarkManual = new System.Windows.Forms.RichTextBox();
            this.TxtBoxWatermarkPath = new System.Windows.Forms.TextBox();
            this.ImgWatermark = new System.Windows.Forms.PictureBox();
            this.BtnWatermarkLoad = new System.Windows.Forms.Button();
            this.tab_Recover = new System.Windows.Forms.TabPage();
            this.GrpBoxInfo2 = new System.Windows.Forms.GroupBox();
            this.LblNCC = new System.Windows.Forms.Label();
            this.LblNCCText = new System.Windows.Forms.Label();
            this.BtnRecover = new System.Windows.Forms.Button();
            this.LblComputationTimeValue2 = new System.Windows.Forms.Label();
            this.LblComputation2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblBER = new System.Windows.Forms.Label();
            this.LblBERText = new System.Windows.Forms.Label();
            this.LblPSNR = new System.Windows.Forms.Label();
            this.LblPSNRText = new System.Windows.Forms.Label();
            this.GrpBoxAttacks = new System.Windows.Forms.GroupBox();
            this.GrpBoxAttackParameter2 = new System.Windows.Forms.GroupBox();
            this.chkBoxAxisY = new System.Windows.Forms.CheckBox();
            this.chkBoxAxisX = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpBoxAttackParameter = new System.Windows.Forms.GroupBox();
            this.LblAttackParameter = new System.Windows.Forms.Label();
            this.TxtBoxAttackParameter = new System.Windows.Forms.TextBox();
            this.CmbBoxAttacks = new System.Windows.Forms.ComboBox();
            this.BtnApplyAttack = new System.Windows.Forms.Button();
            this.GrpBoxAttackedImage = new System.Windows.Forms.GroupBox();
            this.ImgAttackedImage = new System.Windows.Forms.PictureBox();
            this.GrpBoxWatermarkedImage2 = new System.Windows.Forms.GroupBox();
            this.ImgWatermarkedImage2 = new System.Windows.Forms.PictureBox();
            this.GrpBoxRecoveredWatermark = new System.Windows.Forms.GroupBox();
            this.BtnRecoveredWatermarkSave = new System.Windows.Forms.Button();
            this.ImgRecoveredWatermark = new System.Windows.Forms.PictureBox();
            this.tab.SuspendLayout();
            this.tab_Embed.SuspendLayout();
            this.GrpBoxInfo.SuspendLayout();
            this.GrpBoxParameters.SuspendLayout();
            this.GrpBoxWatermarkedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWatermarkedImage)).BeginInit();
            this.GrpBoxCoverImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCoverImage)).BeginInit();
            this.GrpBoxWatermark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWatermark)).BeginInit();
            this.tab_Recover.SuspendLayout();
            this.GrpBoxInfo2.SuspendLayout();
            this.GrpBoxAttacks.SuspendLayout();
            this.GrpBoxAttackParameter2.SuspendLayout();
            this.GrpBoxAttackParameter.SuspendLayout();
            this.GrpBoxAttackedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAttackedImage)).BeginInit();
            this.GrpBoxWatermarkedImage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWatermarkedImage2)).BeginInit();
            this.GrpBoxRecoveredWatermark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgRecoveredWatermark)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tab_Embed);
            this.tab.Controls.Add(this.tab_Recover);
            this.tab.Location = new System.Drawing.Point(12, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1074, 698);
            this.tab.TabIndex = 2;
            // 
            // tab_Embed
            // 
            this.tab_Embed.Controls.Add(this.GrpBoxInfo);
            this.tab_Embed.Controls.Add(this.GrpBoxParameters);
            this.tab_Embed.Controls.Add(this.GrpBoxWatermarkedImage);
            this.tab_Embed.Controls.Add(this.GrpBoxCoverImage);
            this.tab_Embed.Controls.Add(this.GrpBoxWatermark);
            this.tab_Embed.Location = new System.Drawing.Point(4, 25);
            this.tab_Embed.Name = "tab_Embed";
            this.tab_Embed.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Embed.Size = new System.Drawing.Size(1066, 669);
            this.tab_Embed.TabIndex = 0;
            this.tab_Embed.Text = "Embed";
            this.tab_Embed.UseVisualStyleBackColor = true;
            // 
            // GrpBoxInfo
            // 
            this.GrpBoxInfo.Controls.Add(this.LblCapacity);
            this.GrpBoxInfo.Controls.Add(this.LblCapacityDesc);
            this.GrpBoxInfo.Controls.Add(this.LblWatermarkSize);
            this.GrpBoxInfo.Controls.Add(this.LblCoverImageSize);
            this.GrpBoxInfo.Controls.Add(this.LblWatermarkS);
            this.GrpBoxInfo.Controls.Add(this.LblCoverImageS);
            this.GrpBoxInfo.Controls.Add(this.BtnEmbed);
            this.GrpBoxInfo.Controls.Add(this.LblComputationTimeValue);
            this.GrpBoxInfo.Controls.Add(this.LblWatermarkStatus);
            this.GrpBoxInfo.Controls.Add(this.LblCoverImageStatus);
            this.GrpBoxInfo.Controls.Add(this.LblComputationTime);
            this.GrpBoxInfo.Controls.Add(this.LblWatermark);
            this.GrpBoxInfo.Controls.Add(this.LblCoverImage);
            this.GrpBoxInfo.Location = new System.Drawing.Point(420, 472);
            this.GrpBoxInfo.Name = "GrpBoxInfo";
            this.GrpBoxInfo.Size = new System.Drawing.Size(643, 173);
            this.GrpBoxInfo.TabIndex = 29;
            this.GrpBoxInfo.TabStop = false;
            this.GrpBoxInfo.Text = "Info";
            // 
            // LblCapacity
            // 
            this.LblCapacity.AutoSize = true;
            this.LblCapacity.Location = new System.Drawing.Point(257, 135);
            this.LblCapacity.Name = "LblCapacity";
            this.LblCapacity.Size = new System.Drawing.Size(13, 17);
            this.LblCapacity.TabIndex = 12;
            this.LblCapacity.Text = "-";
            // 
            // LblCapacityDesc
            // 
            this.LblCapacityDesc.AutoSize = true;
            this.LblCapacityDesc.Location = new System.Drawing.Point(18, 135);
            this.LblCapacityDesc.Name = "LblCapacityDesc";
            this.LblCapacityDesc.Size = new System.Drawing.Size(212, 17);
            this.LblCapacityDesc.TabIndex = 11;
            this.LblCapacityDesc.Text = "Capacity for current parameters:";
            // 
            // LblWatermarkSize
            // 
            this.LblWatermarkSize.AutoSize = true;
            this.LblWatermarkSize.Location = new System.Drawing.Point(160, 81);
            this.LblWatermarkSize.Name = "LblWatermarkSize";
            this.LblWatermarkSize.Size = new System.Drawing.Size(13, 17);
            this.LblWatermarkSize.TabIndex = 10;
            this.LblWatermarkSize.Text = "-";
            // 
            // LblCoverImageSize
            // 
            this.LblCoverImageSize.AutoSize = true;
            this.LblCoverImageSize.Location = new System.Drawing.Point(160, 29);
            this.LblCoverImageSize.Name = "LblCoverImageSize";
            this.LblCoverImageSize.Size = new System.Drawing.Size(13, 17);
            this.LblCoverImageSize.TabIndex = 9;
            this.LblCoverImageSize.Text = "-";
            // 
            // LblWatermarkS
            // 
            this.LblWatermarkS.AutoSize = true;
            this.LblWatermarkS.Location = new System.Drawing.Point(17, 81);
            this.LblWatermarkS.Name = "LblWatermarkS";
            this.LblWatermarkS.Size = new System.Drawing.Size(112, 17);
            this.LblWatermarkS.TabIndex = 8;
            this.LblWatermarkS.Text = "Watermark Size:";
            this.LblWatermarkS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblCoverImageS
            // 
            this.LblCoverImageS.AutoSize = true;
            this.LblCoverImageS.Location = new System.Drawing.Point(17, 29);
            this.LblCoverImageS.Name = "LblCoverImageS";
            this.LblCoverImageS.Size = new System.Drawing.Size(122, 17);
            this.LblCoverImageS.TabIndex = 7;
            this.LblCoverImageS.Text = "Cover Image Size:";
            // 
            // BtnEmbed
            // 
            this.BtnEmbed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnEmbed.Location = new System.Drawing.Point(450, 123);
            this.BtnEmbed.Name = "BtnEmbed";
            this.BtnEmbed.Size = new System.Drawing.Size(105, 38);
            this.BtnEmbed.TabIndex = 6;
            this.BtnEmbed.Text = "Embed";
            this.BtnEmbed.UseVisualStyleBackColor = true;
            this.BtnEmbed.Click += new System.EventHandler(this.BtnEmbed_Click);
            // 
            // LblComputationTimeValue
            // 
            this.LblComputationTimeValue.AutoSize = true;
            this.LblComputationTimeValue.Location = new System.Drawing.Point(560, 29);
            this.LblComputationTimeValue.Name = "LblComputationTimeValue";
            this.LblComputationTimeValue.Size = new System.Drawing.Size(13, 17);
            this.LblComputationTimeValue.TabIndex = 5;
            this.LblComputationTimeValue.Text = "-";
            // 
            // LblWatermarkStatus
            // 
            this.LblWatermarkStatus.AutoSize = true;
            this.LblWatermarkStatus.Location = new System.Drawing.Point(160, 108);
            this.LblWatermarkStatus.Name = "LblWatermarkStatus";
            this.LblWatermarkStatus.Size = new System.Drawing.Size(13, 17);
            this.LblWatermarkStatus.TabIndex = 4;
            this.LblWatermarkStatus.Text = "-";
            // 
            // LblCoverImageStatus
            // 
            this.LblCoverImageStatus.AutoSize = true;
            this.LblCoverImageStatus.Location = new System.Drawing.Point(160, 55);
            this.LblCoverImageStatus.Name = "LblCoverImageStatus";
            this.LblCoverImageStatus.Size = new System.Drawing.Size(13, 17);
            this.LblCoverImageStatus.TabIndex = 3;
            this.LblCoverImageStatus.Text = "-";
            // 
            // LblComputationTime
            // 
            this.LblComputationTime.AutoSize = true;
            this.LblComputationTime.Location = new System.Drawing.Point(419, 29);
            this.LblComputationTime.Name = "LblComputationTime";
            this.LblComputationTime.Size = new System.Drawing.Size(121, 17);
            this.LblComputationTime.TabIndex = 2;
            this.LblComputationTime.Text = "Computation time:";
            // 
            // LblWatermark
            // 
            this.LblWatermark.AutoSize = true;
            this.LblWatermark.Location = new System.Drawing.Point(17, 108);
            this.LblWatermark.Name = "LblWatermark";
            this.LblWatermark.Size = new System.Drawing.Size(52, 17);
            this.LblWatermark.TabIndex = 1;
            this.LblWatermark.Text = "Status:";
            // 
            // LblCoverImage
            // 
            this.LblCoverImage.AutoSize = true;
            this.LblCoverImage.Location = new System.Drawing.Point(17, 55);
            this.LblCoverImage.Name = "LblCoverImage";
            this.LblCoverImage.Size = new System.Drawing.Size(52, 17);
            this.LblCoverImage.TabIndex = 0;
            this.LblCoverImage.Text = "Status:";
            // 
            // GrpBoxParameters
            // 
            this.GrpBoxParameters.Controls.Add(this.LblEmbeddingRecommended);
            this.GrpBoxParameters.Controls.Add(this.TxtBoxEmbeddingStrength);
            this.GrpBoxParameters.Controls.Add(this.LblEmbedding);
            this.GrpBoxParameters.Controls.Add(this.CmbBoxStrategy);
            this.GrpBoxParameters.Controls.Add(this.LblStrategy);
            this.GrpBoxParameters.Controls.Add(this.LblFibonacci);
            this.GrpBoxParameters.Controls.Add(this.CmbBoxFibonacci);
            this.GrpBoxParameters.Location = new System.Drawing.Point(9, 472);
            this.GrpBoxParameters.Name = "GrpBoxParameters";
            this.GrpBoxParameters.Size = new System.Drawing.Size(402, 173);
            this.GrpBoxParameters.TabIndex = 28;
            this.GrpBoxParameters.TabStop = false;
            this.GrpBoxParameters.Text = "Parameters";
            // 
            // LblEmbeddingRecommended
            // 
            this.LblEmbeddingRecommended.AutoSize = true;
            this.LblEmbeddingRecommended.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblEmbeddingRecommended.Location = new System.Drawing.Point(23, 147);
            this.LblEmbeddingRecommended.Name = "LblEmbeddingRecommended";
            this.LblEmbeddingRecommended.Size = new System.Drawing.Size(0, 17);
            this.LblEmbeddingRecommended.TabIndex = 6;
            // 
            // TxtBoxEmbeddingStrength
            // 
            this.TxtBoxEmbeddingStrength.Location = new System.Drawing.Point(211, 120);
            this.TxtBoxEmbeddingStrength.Name = "TxtBoxEmbeddingStrength";
            this.TxtBoxEmbeddingStrength.Size = new System.Drawing.Size(173, 22);
            this.TxtBoxEmbeddingStrength.TabIndex = 5;
            this.TxtBoxEmbeddingStrength.TextChanged += new System.EventHandler(this.TxtBoxEmbeddingStrength_TextChanged);
            this.TxtBoxEmbeddingStrength.Leave += new System.EventHandler(this.TxtBoxEmbeddingStrength_Leave);
            // 
            // LblEmbedding
            // 
            this.LblEmbedding.AutoSize = true;
            this.LblEmbedding.Location = new System.Drawing.Point(28, 123);
            this.LblEmbedding.Name = "LblEmbedding";
            this.LblEmbedding.Size = new System.Drawing.Size(139, 17);
            this.LblEmbedding.TabIndex = 4;
            this.LblEmbedding.Text = "Embedding strength:";
            // 
            // CmbBoxStrategy
            // 
            this.CmbBoxStrategy.FormattingEnabled = true;
            this.CmbBoxStrategy.Location = new System.Drawing.Point(211, 30);
            this.CmbBoxStrategy.Name = "CmbBoxStrategy";
            this.CmbBoxStrategy.Size = new System.Drawing.Size(173, 24);
            this.CmbBoxStrategy.TabIndex = 3;
            this.CmbBoxStrategy.SelectedIndexChanged += new System.EventHandler(this.CmbBoxStrategy_SelectedIndexChanged);
            // 
            // LblStrategy
            // 
            this.LblStrategy.AutoSize = true;
            this.LblStrategy.Location = new System.Drawing.Point(28, 33);
            this.LblStrategy.Name = "LblStrategy";
            this.LblStrategy.Size = new System.Drawing.Size(155, 17);
            this.LblStrategy.TabIndex = 2;
            this.LblStrategy.Text = "Watermarking strategy:";
            // 
            // LblFibonacci
            // 
            this.LblFibonacci.AutoSize = true;
            this.LblFibonacci.Location = new System.Drawing.Point(28, 78);
            this.LblFibonacci.Name = "LblFibonacci";
            this.LblFibonacci.Size = new System.Drawing.Size(151, 17);
            this.LblFibonacci.TabIndex = 1;
            this.LblFibonacci.Text = "Fibonacci p-sequence:";
            // 
            // CmbBoxFibonacci
            // 
            this.CmbBoxFibonacci.FormattingEnabled = true;
            this.CmbBoxFibonacci.Location = new System.Drawing.Point(211, 75);
            this.CmbBoxFibonacci.Name = "CmbBoxFibonacci";
            this.CmbBoxFibonacci.Size = new System.Drawing.Size(173, 24);
            this.CmbBoxFibonacci.TabIndex = 0;
            this.CmbBoxFibonacci.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFibonacci_SelectedIndexChanged);
            // 
            // GrpBoxWatermarkedImage
            // 
            this.GrpBoxWatermarkedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBoxWatermarkedImage.Controls.Add(this.BtnWatermarkedImageSave);
            this.GrpBoxWatermarkedImage.Controls.Add(this.ImgWatermarkedImage);
            this.GrpBoxWatermarkedImage.Location = new System.Drawing.Point(658, 6);
            this.GrpBoxWatermarkedImage.Name = "GrpBoxWatermarkedImage";
            this.GrpBoxWatermarkedImage.Size = new System.Drawing.Size(402, 442);
            this.GrpBoxWatermarkedImage.TabIndex = 22;
            this.GrpBoxWatermarkedImage.TabStop = false;
            this.GrpBoxWatermarkedImage.Text = "Watermarked Image";
            // 
            // BtnWatermarkedImageSave
            // 
            this.BtnWatermarkedImageSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnWatermarkedImageSave.Location = new System.Drawing.Point(9, 414);
            this.BtnWatermarkedImageSave.Name = "BtnWatermarkedImageSave";
            this.BtnWatermarkedImageSave.Size = new System.Drawing.Size(384, 23);
            this.BtnWatermarkedImageSave.TabIndex = 7;
            this.BtnWatermarkedImageSave.Text = "Save Watermarked Image";
            this.BtnWatermarkedImageSave.UseVisualStyleBackColor = false;
            this.BtnWatermarkedImageSave.Click += new System.EventHandler(this.BtnWatermarkedImageSave_Click);
            // 
            // ImgWatermarkedImage
            // 
            this.ImgWatermarkedImage.Image = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgWatermarkedImage.InitialImage = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgWatermarkedImage.Location = new System.Drawing.Point(9, 21);
            this.ImgWatermarkedImage.Name = "ImgWatermarkedImage";
            this.ImgWatermarkedImage.Size = new System.Drawing.Size(384, 384);
            this.ImgWatermarkedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgWatermarkedImage.TabIndex = 15;
            this.ImgWatermarkedImage.TabStop = false;
            // 
            // GrpBoxCoverImage
            // 
            this.GrpBoxCoverImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBoxCoverImage.Controls.Add(this.TxtBoxCoverImagePath);
            this.GrpBoxCoverImage.Controls.Add(this.BtnCoverImageLoad);
            this.GrpBoxCoverImage.Controls.Add(this.ImgCoverImage);
            this.GrpBoxCoverImage.Location = new System.Drawing.Point(9, 6);
            this.GrpBoxCoverImage.Name = "GrpBoxCoverImage";
            this.GrpBoxCoverImage.Size = new System.Drawing.Size(402, 442);
            this.GrpBoxCoverImage.TabIndex = 20;
            this.GrpBoxCoverImage.TabStop = false;
            this.GrpBoxCoverImage.Text = "Cover Image";
            // 
            // TxtBoxCoverImagePath
            // 
            this.TxtBoxCoverImagePath.Location = new System.Drawing.Point(9, 414);
            this.TxtBoxCoverImagePath.Name = "TxtBoxCoverImagePath";
            this.TxtBoxCoverImagePath.ReadOnly = true;
            this.TxtBoxCoverImagePath.Size = new System.Drawing.Size(352, 22);
            this.TxtBoxCoverImagePath.TabIndex = 6;
            // 
            // BtnCoverImageLoad
            // 
            this.BtnCoverImageLoad.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCoverImageLoad.Location = new System.Drawing.Point(367, 414);
            this.BtnCoverImageLoad.Name = "BtnCoverImageLoad";
            this.BtnCoverImageLoad.Size = new System.Drawing.Size(29, 23);
            this.BtnCoverImageLoad.TabIndex = 7;
            this.BtnCoverImageLoad.Text = "...";
            this.BtnCoverImageLoad.UseVisualStyleBackColor = false;
            this.BtnCoverImageLoad.Click += new System.EventHandler(this.BtnCoverImageLoad_Click);
            // 
            // ImgCoverImage
            // 
            this.ImgCoverImage.Image = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgCoverImage.InitialImage = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgCoverImage.Location = new System.Drawing.Point(9, 21);
            this.ImgCoverImage.Name = "ImgCoverImage";
            this.ImgCoverImage.Size = new System.Drawing.Size(384, 384);
            this.ImgCoverImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgCoverImage.TabIndex = 15;
            this.ImgCoverImage.TabStop = false;
            // 
            // GrpBoxWatermark
            // 
            this.GrpBoxWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBoxWatermark.Controls.Add(this.RTxtBoxWatermarkManual);
            this.GrpBoxWatermark.Controls.Add(this.TxtBoxWatermarkPath);
            this.GrpBoxWatermark.Controls.Add(this.ImgWatermark);
            this.GrpBoxWatermark.Controls.Add(this.BtnWatermarkLoad);
            this.GrpBoxWatermark.Location = new System.Drawing.Point(417, 6);
            this.GrpBoxWatermark.Name = "GrpBoxWatermark";
            this.GrpBoxWatermark.Size = new System.Drawing.Size(235, 442);
            this.GrpBoxWatermark.TabIndex = 21;
            this.GrpBoxWatermark.TabStop = false;
            this.GrpBoxWatermark.Text = "Watermark";
            // 
            // RTxtBoxWatermarkManual
            // 
            this.RTxtBoxWatermarkManual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTxtBoxWatermarkManual.Location = new System.Drawing.Point(20, 315);
            this.RTxtBoxWatermarkManual.Name = "RTxtBoxWatermarkManual";
            this.RTxtBoxWatermarkManual.Size = new System.Drawing.Size(192, 62);
            this.RTxtBoxWatermarkManual.TabIndex = 18;
            this.RTxtBoxWatermarkManual.Text = "";
            // 
            // TxtBoxWatermarkPath
            // 
            this.TxtBoxWatermarkPath.Location = new System.Drawing.Point(20, 414);
            this.TxtBoxWatermarkPath.Name = "TxtBoxWatermarkPath";
            this.TxtBoxWatermarkPath.ReadOnly = true;
            this.TxtBoxWatermarkPath.Size = new System.Drawing.Size(157, 22);
            this.TxtBoxWatermarkPath.TabIndex = 6;
            // 
            // ImgWatermark
            // 
            this.ImgWatermark.Image = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgWatermark.InitialImage = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgWatermark.Location = new System.Drawing.Point(20, 117);
            this.ImgWatermark.MaximumSize = new System.Drawing.Size(192, 192);
            this.ImgWatermark.Name = "ImgWatermark";
            this.ImgWatermark.Size = new System.Drawing.Size(192, 192);
            this.ImgWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgWatermark.TabIndex = 17;
            this.ImgWatermark.TabStop = false;
            // 
            // BtnWatermarkLoad
            // 
            this.BtnWatermarkLoad.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnWatermarkLoad.Location = new System.Drawing.Point(183, 414);
            this.BtnWatermarkLoad.Name = "BtnWatermarkLoad";
            this.BtnWatermarkLoad.Size = new System.Drawing.Size(29, 23);
            this.BtnWatermarkLoad.TabIndex = 7;
            this.BtnWatermarkLoad.Text = "...";
            this.BtnWatermarkLoad.UseVisualStyleBackColor = false;
            this.BtnWatermarkLoad.Click += new System.EventHandler(this.BtnWatermarkLoad_Click);
            // 
            // tab_Recover
            // 
            this.tab_Recover.Controls.Add(this.GrpBoxInfo2);
            this.tab_Recover.Controls.Add(this.GrpBoxAttacks);
            this.tab_Recover.Controls.Add(this.GrpBoxAttackedImage);
            this.tab_Recover.Controls.Add(this.GrpBoxWatermarkedImage2);
            this.tab_Recover.Controls.Add(this.GrpBoxRecoveredWatermark);
            this.tab_Recover.Location = new System.Drawing.Point(4, 25);
            this.tab_Recover.Name = "tab_Recover";
            this.tab_Recover.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Recover.Size = new System.Drawing.Size(1066, 669);
            this.tab_Recover.TabIndex = 1;
            this.tab_Recover.Text = "Recover";
            this.tab_Recover.UseVisualStyleBackColor = true;
            // 
            // GrpBoxInfo2
            // 
            this.GrpBoxInfo2.Controls.Add(this.LblNCC);
            this.GrpBoxInfo2.Controls.Add(this.LblNCCText);
            this.GrpBoxInfo2.Controls.Add(this.BtnRecover);
            this.GrpBoxInfo2.Controls.Add(this.LblComputationTimeValue2);
            this.GrpBoxInfo2.Controls.Add(this.LblComputation2);
            this.GrpBoxInfo2.Controls.Add(this.label7);
            this.GrpBoxInfo2.Controls.Add(this.LblBER);
            this.GrpBoxInfo2.Controls.Add(this.LblBERText);
            this.GrpBoxInfo2.Controls.Add(this.LblPSNR);
            this.GrpBoxInfo2.Controls.Add(this.LblPSNRText);
            this.GrpBoxInfo2.Location = new System.Drawing.Point(415, 429);
            this.GrpBoxInfo2.Name = "GrpBoxInfo2";
            this.GrpBoxInfo2.Size = new System.Drawing.Size(645, 224);
            this.GrpBoxInfo2.TabIndex = 27;
            this.GrpBoxInfo2.TabStop = false;
            this.GrpBoxInfo2.Text = "Info";
            // 
            // LblNCC
            // 
            this.LblNCC.AutoSize = true;
            this.LblNCC.Location = new System.Drawing.Point(348, 106);
            this.LblNCC.Name = "LblNCC";
            this.LblNCC.Size = new System.Drawing.Size(13, 17);
            this.LblNCC.TabIndex = 22;
            this.LblNCC.Text = "-";
            // 
            // LblNCCText
            // 
            this.LblNCCText.AutoSize = true;
            this.LblNCCText.Location = new System.Drawing.Point(25, 106);
            this.LblNCCText.Name = "LblNCCText";
            this.LblNCCText.Size = new System.Drawing.Size(308, 17);
            this.LblNCCText.TabIndex = 21;
            this.LblNCCText.Text = "Watermark NCC(Normalized Cross-Correlation):";
            this.LblNCCText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnRecover
            // 
            this.BtnRecover.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnRecover.Location = new System.Drawing.Point(517, 167);
            this.BtnRecover.Name = "BtnRecover";
            this.BtnRecover.Size = new System.Drawing.Size(105, 38);
            this.BtnRecover.TabIndex = 20;
            this.BtnRecover.Text = "Recover";
            this.BtnRecover.UseVisualStyleBackColor = true;
            this.BtnRecover.Click += new System.EventHandler(this.BtnRecover_Click);
            // 
            // LblComputationTimeValue2
            // 
            this.LblComputationTimeValue2.AutoSize = true;
            this.LblComputationTimeValue2.Location = new System.Drawing.Point(348, 179);
            this.LblComputationTimeValue2.Name = "LblComputationTimeValue2";
            this.LblComputationTimeValue2.Size = new System.Drawing.Size(13, 17);
            this.LblComputationTimeValue2.TabIndex = 19;
            this.LblComputationTimeValue2.Text = "-";
            // 
            // LblComputation2
            // 
            this.LblComputation2.AutoSize = true;
            this.LblComputation2.Location = new System.Drawing.Point(25, 179);
            this.LblComputation2.Name = "LblComputation2";
            this.LblComputation2.Size = new System.Drawing.Size(121, 17);
            this.LblComputation2.TabIndex = 18;
            this.LblComputation2.Text = "Computation time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(24, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Statistics:";
            // 
            // LblBER
            // 
            this.LblBER.AutoSize = true;
            this.LblBER.Location = new System.Drawing.Point(348, 139);
            this.LblBER.Name = "LblBER";
            this.LblBER.Size = new System.Drawing.Size(13, 17);
            this.LblBER.TabIndex = 16;
            this.LblBER.Text = "-";
            // 
            // LblBERText
            // 
            this.LblBERText.AutoSize = true;
            this.LblBERText.Location = new System.Drawing.Point(25, 139);
            this.LblBERText.Name = "LblBERText";
            this.LblBERText.Size = new System.Drawing.Size(209, 17);
            this.LblBERText.TabIndex = 14;
            this.LblBERText.Text = "Watermark BER(Bit Error Rate):";
            this.LblBERText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblPSNR
            // 
            this.LblPSNR.AutoSize = true;
            this.LblPSNR.Location = new System.Drawing.Point(348, 73);
            this.LblPSNR.Name = "LblPSNR";
            this.LblPSNR.Size = new System.Drawing.Size(13, 17);
            this.LblPSNR.TabIndex = 12;
            this.LblPSNR.Text = "-";
            // 
            // LblPSNRText
            // 
            this.LblPSNRText.AutoSize = true;
            this.LblPSNRText.Location = new System.Drawing.Point(25, 73);
            this.LblPSNRText.Name = "LblPSNRText";
            this.LblPSNRText.Size = new System.Drawing.Size(270, 17);
            this.LblPSNRText.TabIndex = 11;
            this.LblPSNRText.Text = "Image PSNR(Peak Signal to Noise Ratio):";
            // 
            // GrpBoxAttacks
            // 
            this.GrpBoxAttacks.Controls.Add(this.GrpBoxAttackParameter2);
            this.GrpBoxAttacks.Controls.Add(this.GrpBoxAttackParameter);
            this.GrpBoxAttacks.Controls.Add(this.CmbBoxAttacks);
            this.GrpBoxAttacks.Controls.Add(this.BtnApplyAttack);
            this.GrpBoxAttacks.Location = new System.Drawing.Point(6, 428);
            this.GrpBoxAttacks.Name = "GrpBoxAttacks";
            this.GrpBoxAttacks.Size = new System.Drawing.Size(402, 225);
            this.GrpBoxAttacks.TabIndex = 26;
            this.GrpBoxAttacks.TabStop = false;
            this.GrpBoxAttacks.Text = "Image Attacks";
            // 
            // GrpBoxAttackParameter2
            // 
            this.GrpBoxAttackParameter2.Controls.Add(this.chkBoxAxisY);
            this.GrpBoxAttackParameter2.Controls.Add(this.chkBoxAxisX);
            this.GrpBoxAttackParameter2.Controls.Add(this.label1);
            this.GrpBoxAttackParameter2.Location = new System.Drawing.Point(35, 83);
            this.GrpBoxAttackParameter2.Name = "GrpBoxAttackParameter2";
            this.GrpBoxAttackParameter2.Size = new System.Drawing.Size(343, 75);
            this.GrpBoxAttackParameter2.TabIndex = 5;
            this.GrpBoxAttackParameter2.TabStop = false;
            this.GrpBoxAttackParameter2.Text = "Attack Parameters";
            this.GrpBoxAttackParameter2.Visible = false;
            // 
            // chkBoxAxisY
            // 
            this.chkBoxAxisY.AutoSize = true;
            this.chkBoxAxisY.Location = new System.Drawing.Point(238, 35);
            this.chkBoxAxisY.Name = "chkBoxAxisY";
            this.chkBoxAxisY.Size = new System.Drawing.Size(65, 21);
            this.chkBoxAxisY.TabIndex = 5;
            this.chkBoxAxisY.Text = "Flip Y";
            this.chkBoxAxisY.UseVisualStyleBackColor = true;
            // 
            // chkBoxAxisX
            // 
            this.chkBoxAxisX.AutoSize = true;
            this.chkBoxAxisX.Location = new System.Drawing.Point(38, 35);
            this.chkBoxAxisX.Name = "chkBoxAxisX";
            this.chkBoxAxisX.Size = new System.Drawing.Size(65, 21);
            this.chkBoxAxisX.TabIndex = 4;
            this.chkBoxAxisX.Text = "Flip X";
            this.chkBoxAxisX.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            // 
            // GrpBoxAttackParameter
            // 
            this.GrpBoxAttackParameter.Controls.Add(this.LblAttackParameter);
            this.GrpBoxAttackParameter.Controls.Add(this.TxtBoxAttackParameter);
            this.GrpBoxAttackParameter.Location = new System.Drawing.Point(35, 83);
            this.GrpBoxAttackParameter.Name = "GrpBoxAttackParameter";
            this.GrpBoxAttackParameter.Size = new System.Drawing.Size(343, 75);
            this.GrpBoxAttackParameter.TabIndex = 4;
            this.GrpBoxAttackParameter.TabStop = false;
            this.GrpBoxAttackParameter.Text = "Attack Parameters";
            // 
            // LblAttackParameter
            // 
            this.LblAttackParameter.AutoSize = true;
            this.LblAttackParameter.Location = new System.Drawing.Point(6, 36);
            this.LblAttackParameter.Name = "LblAttackParameter";
            this.LblAttackParameter.Size = new System.Drawing.Size(0, 17);
            this.LblAttackParameter.TabIndex = 2;
            // 
            // TxtBoxAttackParameter
            // 
            this.TxtBoxAttackParameter.Location = new System.Drawing.Point(238, 33);
            this.TxtBoxAttackParameter.Name = "TxtBoxAttackParameter";
            this.TxtBoxAttackParameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBoxAttackParameter.Size = new System.Drawing.Size(99, 22);
            this.TxtBoxAttackParameter.TabIndex = 3;
            this.TxtBoxAttackParameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CmbBoxAttacks
            // 
            this.CmbBoxAttacks.FormattingEnabled = true;
            this.CmbBoxAttacks.Location = new System.Drawing.Point(35, 41);
            this.CmbBoxAttacks.Name = "CmbBoxAttacks";
            this.CmbBoxAttacks.Size = new System.Drawing.Size(343, 24);
            this.CmbBoxAttacks.TabIndex = 1;
            this.CmbBoxAttacks.SelectedIndexChanged += new System.EventHandler(this.CmbBoxAttacks_SelectedIndexChanged);
            // 
            // BtnApplyAttack
            // 
            this.BtnApplyAttack.Location = new System.Drawing.Point(139, 174);
            this.BtnApplyAttack.Name = "BtnApplyAttack";
            this.BtnApplyAttack.Size = new System.Drawing.Size(119, 28);
            this.BtnApplyAttack.TabIndex = 0;
            this.BtnApplyAttack.Text = "Apply Attack";
            this.BtnApplyAttack.UseVisualStyleBackColor = true;
            this.BtnApplyAttack.Click += new System.EventHandler(this.BtnApplyAttack_Click);
            // 
            // GrpBoxAttackedImage
            // 
            this.GrpBoxAttackedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBoxAttackedImage.Controls.Add(this.ImgAttackedImage);
            this.GrpBoxAttackedImage.Location = new System.Drawing.Point(417, 6);
            this.GrpBoxAttackedImage.Name = "GrpBoxAttackedImage";
            this.GrpBoxAttackedImage.Size = new System.Drawing.Size(402, 416);
            this.GrpBoxAttackedImage.TabIndex = 25;
            this.GrpBoxAttackedImage.TabStop = false;
            this.GrpBoxAttackedImage.Text = "Attacked Watermarked Image";
            // 
            // ImgAttackedImage
            // 
            this.ImgAttackedImage.Image = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgAttackedImage.InitialImage = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgAttackedImage.Location = new System.Drawing.Point(9, 21);
            this.ImgAttackedImage.Name = "ImgAttackedImage";
            this.ImgAttackedImage.Size = new System.Drawing.Size(384, 384);
            this.ImgAttackedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgAttackedImage.TabIndex = 15;
            this.ImgAttackedImage.TabStop = false;
            // 
            // GrpBoxWatermarkedImage2
            // 
            this.GrpBoxWatermarkedImage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBoxWatermarkedImage2.Controls.Add(this.ImgWatermarkedImage2);
            this.GrpBoxWatermarkedImage2.Location = new System.Drawing.Point(6, 6);
            this.GrpBoxWatermarkedImage2.Name = "GrpBoxWatermarkedImage2";
            this.GrpBoxWatermarkedImage2.Size = new System.Drawing.Size(402, 416);
            this.GrpBoxWatermarkedImage2.TabIndex = 23;
            this.GrpBoxWatermarkedImage2.TabStop = false;
            this.GrpBoxWatermarkedImage2.Text = "Watermarked Image";
            // 
            // ImgWatermarkedImage2
            // 
            this.ImgWatermarkedImage2.Image = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgWatermarkedImage2.InitialImage = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgWatermarkedImage2.Location = new System.Drawing.Point(9, 21);
            this.ImgWatermarkedImage2.Name = "ImgWatermarkedImage2";
            this.ImgWatermarkedImage2.Size = new System.Drawing.Size(384, 384);
            this.ImgWatermarkedImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgWatermarkedImage2.TabIndex = 15;
            this.ImgWatermarkedImage2.TabStop = false;
            // 
            // GrpBoxRecoveredWatermark
            // 
            this.GrpBoxRecoveredWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBoxRecoveredWatermark.Controls.Add(this.BtnRecoveredWatermarkSave);
            this.GrpBoxRecoveredWatermark.Controls.Add(this.ImgRecoveredWatermark);
            this.GrpBoxRecoveredWatermark.Location = new System.Drawing.Point(825, 6);
            this.GrpBoxRecoveredWatermark.Name = "GrpBoxRecoveredWatermark";
            this.GrpBoxRecoveredWatermark.Size = new System.Drawing.Size(235, 416);
            this.GrpBoxRecoveredWatermark.TabIndex = 24;
            this.GrpBoxRecoveredWatermark.TabStop = false;
            this.GrpBoxRecoveredWatermark.Text = "Watermark";
            // 
            // BtnRecoveredWatermarkSave
            // 
            this.BtnRecoveredWatermarkSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnRecoveredWatermarkSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnRecoveredWatermarkSave.Location = new System.Drawing.Point(20, 382);
            this.BtnRecoveredWatermarkSave.Name = "BtnRecoveredWatermarkSave";
            this.BtnRecoveredWatermarkSave.Size = new System.Drawing.Size(192, 23);
            this.BtnRecoveredWatermarkSave.TabIndex = 18;
            this.BtnRecoveredWatermarkSave.Text = "Save Recovered Watermark";
            this.BtnRecoveredWatermarkSave.UseVisualStyleBackColor = false;
            this.BtnRecoveredWatermarkSave.Click += new System.EventHandler(this.BtnRecoveredWatermarkSave_Click);
            // 
            // ImgRecoveredWatermark
            // 
            this.ImgRecoveredWatermark.Image = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgRecoveredWatermark.InitialImage = global::FHTWatermarking.Properties.Resources.placholder;
            this.ImgRecoveredWatermark.Location = new System.Drawing.Point(20, 108);
            this.ImgRecoveredWatermark.Name = "ImgRecoveredWatermark";
            this.ImgRecoveredWatermark.Size = new System.Drawing.Size(192, 192);
            this.ImgRecoveredWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgRecoveredWatermark.TabIndex = 17;
            this.ImgRecoveredWatermark.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 720);
            this.Controls.Add(this.tab);
            this.MaximumSize = new System.Drawing.Size(1112, 767);
            this.MinimumSize = new System.Drawing.Size(1112, 767);
            this.Name = "MainForm";
            this.Text = "FHT Watermarking";
            this.tab.ResumeLayout(false);
            this.tab_Embed.ResumeLayout(false);
            this.GrpBoxInfo.ResumeLayout(false);
            this.GrpBoxInfo.PerformLayout();
            this.GrpBoxParameters.ResumeLayout(false);
            this.GrpBoxParameters.PerformLayout();
            this.GrpBoxWatermarkedImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgWatermarkedImage)).EndInit();
            this.GrpBoxCoverImage.ResumeLayout(false);
            this.GrpBoxCoverImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCoverImage)).EndInit();
            this.GrpBoxWatermark.ResumeLayout(false);
            this.GrpBoxWatermark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWatermark)).EndInit();
            this.tab_Recover.ResumeLayout(false);
            this.GrpBoxInfo2.ResumeLayout(false);
            this.GrpBoxInfo2.PerformLayout();
            this.GrpBoxAttacks.ResumeLayout(false);
            this.GrpBoxAttackParameter2.ResumeLayout(false);
            this.GrpBoxAttackParameter2.PerformLayout();
            this.GrpBoxAttackParameter.ResumeLayout(false);
            this.GrpBoxAttackParameter.PerformLayout();
            this.GrpBoxAttackedImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgAttackedImage)).EndInit();
            this.GrpBoxWatermarkedImage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgWatermarkedImage2)).EndInit();
            this.GrpBoxRecoveredWatermark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgRecoveredWatermark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tab_Embed;
        private System.Windows.Forms.TabPage tab_Recover;
        private System.Windows.Forms.GroupBox GrpBoxWatermarkedImage;
        private System.Windows.Forms.Button BtnWatermarkedImageSave;
        private System.Windows.Forms.PictureBox ImgWatermarkedImage;
        private System.Windows.Forms.GroupBox GrpBoxCoverImage;
        private System.Windows.Forms.TextBox TxtBoxCoverImagePath;
        private System.Windows.Forms.Button BtnCoverImageLoad;
        private System.Windows.Forms.PictureBox ImgCoverImage;
        private System.Windows.Forms.GroupBox GrpBoxWatermark;
        private System.Windows.Forms.TextBox TxtBoxWatermarkPath;
        private System.Windows.Forms.PictureBox ImgWatermark;
        private System.Windows.Forms.Button BtnWatermarkLoad;
        private System.Windows.Forms.GroupBox GrpBoxAttackedImage;
        private System.Windows.Forms.PictureBox ImgAttackedImage;
        private System.Windows.Forms.GroupBox GrpBoxWatermarkedImage2;
        private System.Windows.Forms.PictureBox ImgWatermarkedImage2;
        private System.Windows.Forms.GroupBox GrpBoxRecoveredWatermark;
        private System.Windows.Forms.Button BtnRecoveredWatermarkSave;
        private System.Windows.Forms.PictureBox ImgRecoveredWatermark;
        private System.Windows.Forms.GroupBox GrpBoxInfo;
        private System.Windows.Forms.Button BtnEmbed;
        private System.Windows.Forms.Label LblComputationTimeValue;
        private System.Windows.Forms.Label LblWatermarkStatus;
        private System.Windows.Forms.Label LblCoverImageStatus;
        private System.Windows.Forms.Label LblComputationTime;
        private System.Windows.Forms.Label LblWatermark;
        private System.Windows.Forms.Label LblCoverImage;
        private System.Windows.Forms.GroupBox GrpBoxParameters;
        private System.Windows.Forms.ComboBox CmbBoxStrategy;
        private System.Windows.Forms.Label LblStrategy;
        private System.Windows.Forms.Label LblFibonacci;
        private System.Windows.Forms.ComboBox CmbBoxFibonacci;
        private System.Windows.Forms.GroupBox GrpBoxAttacks;
        private System.Windows.Forms.GroupBox GrpBoxInfo2;
        private System.Windows.Forms.Label LblWatermarkS;
        private System.Windows.Forms.Label LblCoverImageS;
        private System.Windows.Forms.Label LblWatermarkSize;
        private System.Windows.Forms.Label LblCoverImageSize;
        private System.Windows.Forms.RichTextBox RTxtBoxWatermarkManual;
        private System.Windows.Forms.Label LblCapacityDesc;
        private System.Windows.Forms.Label LblCapacity;
        private System.Windows.Forms.Button BtnApplyAttack;
        private System.Windows.Forms.ComboBox CmbBoxAttacks;
        private System.Windows.Forms.TextBox TxtBoxAttackParameter;
        private System.Windows.Forms.Label LblAttackParameter;
        private System.Windows.Forms.GroupBox GrpBoxAttackParameter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblBER;
        private System.Windows.Forms.Label LblBERText;
        private System.Windows.Forms.Label LblPSNR;
        private System.Windows.Forms.Label LblPSNRText;
        private System.Windows.Forms.Button BtnRecover;
        private System.Windows.Forms.Label LblComputationTimeValue2;
        private System.Windows.Forms.Label LblComputation2;
        private System.Windows.Forms.Label LblNCC;
        private System.Windows.Forms.Label LblNCCText;
        private System.Windows.Forms.Label LblEmbeddingRecommended;
        private System.Windows.Forms.TextBox TxtBoxEmbeddingStrength;
        private System.Windows.Forms.Label LblEmbedding;
        private System.Windows.Forms.GroupBox GrpBoxAttackParameter2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBoxAxisY;
        private System.Windows.Forms.CheckBox chkBoxAxisX;
    }
}

