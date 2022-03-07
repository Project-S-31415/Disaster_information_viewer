namespace Disaster_information_viewer
{
     partial class DIV_Kyoshin
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DIV_Kyoshin));
            this.Kyoshin = new System.Windows.Forms.Timer(this.components);
            this.Level = new System.Windows.Forms.Label();
            this.Red = new System.Windows.Forms.Label();
            this.Yellow = new System.Windows.Forms.Label();
            this.Green = new System.Windows.Forms.Label();
            this.ShindouLevel = new System.Windows.Forms.Timer(this.components);
            this.PSWave1 = new System.Windows.Forms.PictureBox();
            this.KyoshinMap1 = new System.Windows.Forms.PictureBox();
            this.KyoshinMap2 = new System.Windows.Forms.PictureBox();
            this.Chitenmei1 = new System.Windows.Forms.Label();
            this.Chitenshindo1 = new System.Windows.Forms.Label();
            this.Chitenmei2 = new System.Windows.Forms.Label();
            this.Chitenshindo2 = new System.Windows.Forms.Label();
            this.PSWave2 = new System.Windows.Forms.PictureBox();
            this.ErrorText = new System.Windows.Forms.Label();
            this.Chosyuuki = new System.Windows.Forms.Label();
            this.RealTimeShindo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PSWave1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyoshinMap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyoshinMap2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSWave2)).BeginInit();
            this.SuspendLayout();
            // 
            // Kyoshin
            // 
            this.Kyoshin.Enabled = true;
            this.Kyoshin.Interval = 1000;
            this.Kyoshin.Tick += new System.EventHandler(this.Kyoshin_Tick);
            // 
            // Level
            // 
            this.Level.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Level.Font = new System.Drawing.Font("Roboto", 20F);
            this.Level.ForeColor = System.Drawing.Color.White;
            this.Level.Location = new System.Drawing.Point(594, 369);
            this.Level.Margin = new System.Windows.Forms.Padding(0);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(110, 30);
            this.Level.TabIndex = 6;
            this.Level.Text = "Lv. - - - -";
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Red.Font = new System.Drawing.Font("Roboto", 20F);
            this.Red.ForeColor = System.Drawing.Color.Red;
            this.Red.Location = new System.Drawing.Point(644, 279);
            this.Red.Margin = new System.Windows.Forms.Padding(0);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(60, 30);
            this.Red.TabIndex = 7;
            this.Red.Text = "- - -";
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Yellow.Font = new System.Drawing.Font("Roboto", 20F);
            this.Yellow.ForeColor = System.Drawing.Color.Yellow;
            this.Yellow.Location = new System.Drawing.Point(644, 309);
            this.Yellow.Margin = new System.Windows.Forms.Padding(0);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(60, 30);
            this.Yellow.TabIndex = 8;
            this.Yellow.Text = "- - -";
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Green.Font = new System.Drawing.Font("Roboto", 20F);
            this.Green.ForeColor = System.Drawing.Color.Lime;
            this.Green.Location = new System.Drawing.Point(644, 339);
            this.Green.Margin = new System.Windows.Forms.Padding(0);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(60, 30);
            this.Green.TabIndex = 9;
            this.Green.Text = "- - -";
            // 
            // ShindouLevel
            // 
            this.ShindouLevel.Enabled = true;
            this.ShindouLevel.Interval = 2000;
            this.ShindouLevel.Tick += new System.EventHandler(this.ShindouLevel_Tick);
            // 
            // PSWave1
            // 
            this.PSWave1.BackColor = System.Drawing.Color.Black;
            this.PSWave1.Enabled = false;
            this.PSWave1.Location = new System.Drawing.Point(0, 0);
            this.PSWave1.Margin = new System.Windows.Forms.Padding(0);
            this.PSWave1.Name = "PSWave1";
            this.PSWave1.Size = new System.Drawing.Size(0, 0);
            this.PSWave1.TabIndex = 3;
            this.PSWave1.TabStop = false;
            // 
            // KyoshinMap1
            // 
            this.KyoshinMap1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.KyoshinMap1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("KyoshinMap1.BackgroundImage")));
            this.KyoshinMap1.Location = new System.Drawing.Point(0, 0);
            this.KyoshinMap1.Margin = new System.Windows.Forms.Padding(0);
            this.KyoshinMap1.Name = "KyoshinMap1";
            this.KyoshinMap1.Size = new System.Drawing.Size(352, 400);
            this.KyoshinMap1.TabIndex = 1;
            this.KyoshinMap1.TabStop = false;
            // 
            // KyoshinMap2
            // 
            this.KyoshinMap2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.KyoshinMap2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("KyoshinMap2.BackgroundImage")));
            this.KyoshinMap2.Location = new System.Drawing.Point(353, 0);
            this.KyoshinMap2.Margin = new System.Windows.Forms.Padding(0);
            this.KyoshinMap2.Name = "KyoshinMap2";
            this.KyoshinMap2.Size = new System.Drawing.Size(352, 400);
            this.KyoshinMap2.TabIndex = 18;
            this.KyoshinMap2.TabStop = false;
            // 
            // Chitenmei1
            // 
            this.Chitenmei1.Font = new System.Drawing.Font("Koruri Regular", 11F);
            this.Chitenmei1.ForeColor = System.Drawing.Color.White;
            this.Chitenmei1.Location = new System.Drawing.Point(180, 358);
            this.Chitenmei1.Margin = new System.Windows.Forms.Padding(0);
            this.Chitenmei1.Name = "Chitenmei1";
            this.Chitenmei1.Size = new System.Drawing.Size(172, 21);
            this.Chitenmei1.TabIndex = 10;
            this.Chitenmei1.Text = "　　　　　　　　　　　";
            // 
            // Chitenshindo1
            // 
            this.Chitenshindo1.Font = new System.Drawing.Font("Roboto", 14F);
            this.Chitenshindo1.ForeColor = System.Drawing.Color.White;
            this.Chitenshindo1.Location = new System.Drawing.Point(310, 358);
            this.Chitenshindo1.Margin = new System.Windows.Forms.Padding(0);
            this.Chitenshindo1.Name = "Chitenshindo1";
            this.Chitenshindo1.Size = new System.Drawing.Size(42, 22);
            this.Chitenshindo1.TabIndex = 11;
            // 
            // Chitenmei2
            // 
            this.Chitenmei2.AutoSize = true;
            this.Chitenmei2.Font = new System.Drawing.Font("Koruri Regular", 11F);
            this.Chitenmei2.ForeColor = System.Drawing.Color.White;
            this.Chitenmei2.Location = new System.Drawing.Point(180, 379);
            this.Chitenmei2.Margin = new System.Windows.Forms.Padding(0);
            this.Chitenmei2.Name = "Chitenmei2";
            this.Chitenmei2.Size = new System.Drawing.Size(145, 21);
            this.Chitenmei2.TabIndex = 13;
            this.Chitenmei2.Text = "　　　　　　　　　";
            // 
            // Chitenshindo2
            // 
            this.Chitenshindo2.Font = new System.Drawing.Font("Roboto", 14F);
            this.Chitenshindo2.ForeColor = System.Drawing.Color.White;
            this.Chitenshindo2.Location = new System.Drawing.Point(310, 378);
            this.Chitenshindo2.Margin = new System.Windows.Forms.Padding(0);
            this.Chitenshindo2.Name = "Chitenshindo2";
            this.Chitenshindo2.Size = new System.Drawing.Size(42, 22);
            this.Chitenshindo2.TabIndex = 14;
            // 
            // PSWave2
            // 
            this.PSWave2.BackColor = System.Drawing.Color.Black;
            this.PSWave2.Enabled = false;
            this.PSWave2.Location = new System.Drawing.Point(353, 0);
            this.PSWave2.Margin = new System.Windows.Forms.Padding(0);
            this.PSWave2.Name = "PSWave2";
            this.PSWave2.Size = new System.Drawing.Size(0, 0);
            this.PSWave2.TabIndex = 17;
            this.PSWave2.TabStop = false;
            // 
            // ErrorText
            // 
            this.ErrorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ErrorText.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.ErrorText.ForeColor = System.Drawing.Color.White;
            this.ErrorText.Location = new System.Drawing.Point(353, 42);
            this.ErrorText.Margin = new System.Windows.Forms.Padding(0);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(227, 40);
            this.ErrorText.TabIndex = 19;
            // 
            // Chosyuuki
            // 
            this.Chosyuuki.AutoSize = true;
            this.Chosyuuki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.Chosyuuki.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Chosyuuki.ForeColor = System.Drawing.Color.Black;
            this.Chosyuuki.Location = new System.Drawing.Point(356, 4);
            this.Chosyuuki.Name = "Chosyuuki";
            this.Chosyuuki.Size = new System.Drawing.Size(138, 16);
            this.Chosyuuki.TabIndex = 20;
            this.Chosyuuki.Text = "長周期地震動モニタ";
            // 
            // RealTimeShindo
            // 
            this.RealTimeShindo.AutoSize = true;
            this.RealTimeShindo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.RealTimeShindo.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.RealTimeShindo.ForeColor = System.Drawing.Color.Black;
            this.RealTimeShindo.Location = new System.Drawing.Point(4, 4);
            this.RealTimeShindo.Name = "RealTimeShindo";
            this.RealTimeShindo.Size = new System.Drawing.Size(217, 16);
            this.RealTimeShindo.TabIndex = 21;
            this.RealTimeShindo.Text = "リアルタイム震度(地表)　　　　　　";
            // 
            // DIV_Kyoshin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(704, 400);
            this.Controls.Add(this.RealTimeShindo);
            this.Controls.Add(this.Chosyuuki);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.Chitenshindo2);
            this.Controls.Add(this.Chitenshindo1);
            this.Controls.Add(this.Chitenmei2);
            this.Controls.Add(this.Chitenmei1);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Yellow);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.PSWave2);
            this.Controls.Add(this.PSWave1);
            this.Controls.Add(this.KyoshinMap2);
            this.Controls.Add(this.KyoshinMap1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "DIV_Kyoshin";
            this.Text = "DIV_Kyoshin";
            ((System.ComponentModel.ISupportInitialize)(this.PSWave1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyoshinMap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyoshinMap2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSWave2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox KyoshinMap1;
        private System.Windows.Forms.PictureBox KyoshinMap2;
        private System.Windows.Forms.Timer Kyoshin;
        private System.Windows.Forms.PictureBox PSWave1;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.Label Red;
        private System.Windows.Forms.Label Yellow;
        private System.Windows.Forms.Label Green;
        private System.Windows.Forms.Timer ShindouLevel;
        private System.Windows.Forms.Label Chitenmei1;
        private System.Windows.Forms.Label Chitenshindo1;
        private System.Windows.Forms.Label Chitenmei2;
        private System.Windows.Forms.Label Chitenshindo2;
        private System.Windows.Forms.PictureBox PSWave2;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.Label Chosyuuki;
        private System.Windows.Forms.Label RealTimeShindo;
    }
}

