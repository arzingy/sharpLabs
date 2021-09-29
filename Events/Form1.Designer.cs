namespace events
{
    partial class autonumbers
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
            this.lb_relax = new System.Windows.Forms.Label();
            this.relaxbox = new System.Windows.Forms.TextBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.tb_numbers = new System.Windows.Forms.TextBox();
            this.lb_numbers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_relax
            // 
            this.lb_relax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_relax.AutoSize = true;
            this.lb_relax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_relax.Location = new System.Drawing.Point(38, 77);
            this.lb_relax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_relax.Name = "lb_relax";
            this.lb_relax.Size = new System.Drawing.Size(118, 20);
            this.lb_relax.TabIndex = 0;
            this.lb_relax.Text = "Время отдыха";
            this.lb_relax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // relaxbox
            // 
            this.relaxbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.relaxbox.Location = new System.Drawing.Point(35, 99);
            this.relaxbox.Margin = new System.Windows.Forms.Padding(2);
            this.relaxbox.Name = "relaxbox";
            this.relaxbox.Size = new System.Drawing.Size(121, 26);
            this.relaxbox.TabIndex = 1;
            this.relaxbox.TextChanged += new System.EventHandler(this.relaxbox_TextChanged);
            // 
            // bt_start
            // 
            this.bt_start.Enabled = false;
            this.bt_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_start.Location = new System.Drawing.Point(35, 170);
            this.bt_start.Margin = new System.Windows.Forms.Padding(2);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(121, 53);
            this.bt_start.TabIndex = 2;
            this.bt_start.Text = "Начать вычисления";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.Enabled = false;
            this.bt_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_stop.Location = new System.Drawing.Point(35, 254);
            this.bt_stop.Margin = new System.Windows.Forms.Padding(2);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(121, 53);
            this.bt_stop.TabIndex = 3;
            this.bt_stop.Text = "Завершить вычисления";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // tb_numbers
            // 
            this.tb_numbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_numbers.Location = new System.Drawing.Point(189, 68);
            this.tb_numbers.Margin = new System.Windows.Forms.Padding(2);
            this.tb_numbers.Multiline = true;
            this.tb_numbers.Name = "tb_numbers";
            this.tb_numbers.ReadOnly = true;
            this.tb_numbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_numbers.Size = new System.Drawing.Size(459, 288);
            this.tb_numbers.TabIndex = 0;
            this.tb_numbers.TabStop = false;
            // 
            // lb_numbers
            // 
            this.lb_numbers.AutoSize = true;
            this.lb_numbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_numbers.Location = new System.Drawing.Point(124, 18);
            this.lb_numbers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_numbers.Name = "lb_numbers";
            this.lb_numbers.Size = new System.Drawing.Size(409, 37);
            this.lb_numbers.TabIndex = 4;
            this.lb_numbers.Text = "АВТОМОРФНЫЕ ЧИСЛА";
            // 
            // autonumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 366);
            this.Controls.Add(this.lb_numbers);
            this.Controls.Add(this.tb_numbers);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.relaxbox);
            this.Controls.Add(this.lb_relax);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(675, 405);
            this.MinimumSize = new System.Drawing.Size(675, 405);
            this.Name = "autonumbers";
            this.Text = "Борсуков Арсений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.autonumbers_FormClosing);
            this.Load += new System.EventHandler(this.autonumbers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_relax;
        private System.Windows.Forms.TextBox relaxbox;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.TextBox tb_numbers;
        private System.Windows.Forms.Label lb_numbers;
    }
}

