namespace Task4
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rocketAdd_btn = new System.Windows.Forms.Button();
            this.agentAdd_btn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rocketAdd_btn
            // 
            this.rocketAdd_btn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rocketAdd_btn.Location = new System.Drawing.Point(1302, 13);
            this.rocketAdd_btn.Name = "rocketAdd_btn";
            this.rocketAdd_btn.Size = new System.Drawing.Size(123, 72);
            this.rocketAdd_btn.TabIndex = 0;
            this.rocketAdd_btn.Text = "Запустить ракету";
            this.rocketAdd_btn.UseVisualStyleBackColor = true;
            this.rocketAdd_btn.Click += new System.EventHandler(this.rocketAdd_btn_Click);
            // 
            // agentAdd_btn
            // 
            this.agentAdd_btn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.agentAdd_btn.Location = new System.Drawing.Point(1302, 91);
            this.agentAdd_btn.Name = "agentAdd_btn";
            this.agentAdd_btn.Size = new System.Drawing.Size(123, 74);
            this.agentAdd_btn.TabIndex = 1;
            this.agentAdd_btn.Text = "Добавить страхового агента";
            this.agentAdd_btn.UseVisualStyleBackColor = true;
            this.agentAdd_btn.Click += new System.EventHandler(this.agentAdd_btn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1283, 721);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 10;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 746);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.agentAdd_btn);
            this.Controls.Add(this.rocketAdd_btn);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rocketAdd_btn;
        private System.Windows.Forms.Button agentAdd_btn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer updateTimer;
    }
}

