namespace shooting
{
    partial class shooting_form
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
            this.bigtable = new System.Windows.Forms.TableLayoutPanel();
            this.target = new System.Windows.Forms.PictureBox();
            this.smalltable = new System.Windows.Forms.TableLayoutPanel();
            this.x = new System.Windows.Forms.Label();
            this.radlabel = new System.Windows.Forms.Label();
            this.shootlabel = new System.Windows.Forms.Label();
            this.radbox = new System.Windows.Forms.TextBox();
            this.shootbox = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.ybox = new System.Windows.Forms.TextBox();
            this.y = new System.Windows.Forms.Label();
            this.xbox = new System.Windows.Forms.TextBox();
            this.goalslabel = new System.Windows.Forms.Label();
            this.misseslabel = new System.Windows.Forms.Label();
            this.shootslabel = new System.Windows.Forms.Label();
            this.shootbutton = new System.Windows.Forms.Button();
            this.bigtable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.target)).BeginInit();
            this.smalltable.SuspendLayout();
            this.SuspendLayout();
            // 
            // bigtable
            // 
            this.bigtable.ColumnCount = 1;
            this.bigtable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bigtable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bigtable.Controls.Add(this.target, 0, 1);
            this.bigtable.Controls.Add(this.smalltable, 0, 0);
            this.bigtable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigtable.Location = new System.Drawing.Point(0, 0);
            this.bigtable.Name = "bigtable";
            this.bigtable.RowCount = 2;
            this.bigtable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.026031F));
            this.bigtable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.97397F));
            this.bigtable.Size = new System.Drawing.Size(684, 661);
            this.bigtable.TabIndex = 0;
            // 
            // target
            // 
            this.target.Dock = System.Windows.Forms.DockStyle.Fill;
            this.target.Location = new System.Drawing.Point(3, 56);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(678, 602);
            this.target.TabIndex = 0;
            this.target.TabStop = false;
            this.target.Click += new System.EventHandler(this.target_Click);
            // 
            // smalltable
            // 
            this.smalltable.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.smalltable.ColumnCount = 13;
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.smalltable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.smalltable.Controls.Add(this.x, 5, 0);
            this.smalltable.Controls.Add(this.radlabel, 0, 0);
            this.smalltable.Controls.Add(this.shootlabel, 2, 0);
            this.smalltable.Controls.Add(this.radbox, 1, 0);
            this.smalltable.Controls.Add(this.shootbox, 3, 0);
            this.smalltable.Controls.Add(this.button, 4, 0);
            this.smalltable.Controls.Add(this.ybox, 8, 0);
            this.smalltable.Controls.Add(this.y, 7, 0);
            this.smalltable.Controls.Add(this.xbox, 6, 0);
            this.smalltable.Controls.Add(this.goalslabel, 12, 0);
            this.smalltable.Controls.Add(this.misseslabel, 11, 0);
            this.smalltable.Controls.Add(this.shootslabel, 10, 0);
            this.smalltable.Controls.Add(this.shootbutton, 9, 0);
            this.smalltable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smalltable.Location = new System.Drawing.Point(3, 3);
            this.smalltable.Name = "smalltable";
            this.smalltable.RowCount = 1;
            this.smalltable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smalltable.Size = new System.Drawing.Size(678, 47);
            this.smalltable.TabIndex = 1;
            // 
            // x
            // 
            this.x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.x.AutoSize = true;
            this.x.Location = new System.Drawing.Point(356, 17);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(17, 13);
            this.x.TabIndex = 15;
            this.x.Text = "X:";
            this.x.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.x.Visible = false;
            // 
            // radlabel
            // 
            this.radlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radlabel.AutoSize = true;
            this.radlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radlabel.Location = new System.Drawing.Point(3, 17);
            this.radlabel.Name = "radlabel";
            this.radlabel.Size = new System.Drawing.Size(46, 13);
            this.radlabel.TabIndex = 0;
            this.radlabel.Text = "Радиус:";
            this.radlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // shootlabel
            // 
            this.shootlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.shootlabel.AutoSize = true;
            this.shootlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shootlabel.Location = new System.Drawing.Point(95, 17);
            this.shootlabel.Name = "shootlabel";
            this.shootlabel.Size = new System.Drawing.Size(62, 13);
            this.shootlabel.TabIndex = 1;
            this.shootlabel.Text = "Выстрелы:";
            this.shootlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radbox
            // 
            this.radbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radbox.Location = new System.Drawing.Point(55, 13);
            this.radbox.Name = "radbox";
            this.radbox.Size = new System.Drawing.Size(34, 20);
            this.radbox.TabIndex = 6;
            this.radbox.TextChanged += new System.EventHandler(this.radbox_TextChanged);
            // 
            // shootbox
            // 
            this.shootbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.shootbox.Location = new System.Drawing.Point(163, 13);
            this.shootbox.Name = "shootbox";
            this.shootbox.Size = new System.Drawing.Size(34, 20);
            this.shootbox.TabIndex = 7;
            this.shootbox.TextChanged += new System.EventHandler(this.shootbox_TextChanged);
            // 
            // button
            // 
            this.button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button.Enabled = false;
            this.button.Location = new System.Drawing.Point(224, 7);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(105, 33);
            this.button.TabIndex = 8;
            this.button.Text = "Начать стрельбу";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // ybox
            // 
            this.ybox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ybox.Enabled = false;
            this.ybox.Location = new System.Drawing.Point(433, 13);
            this.ybox.Name = "ybox";
            this.ybox.Size = new System.Drawing.Size(25, 20);
            this.ybox.TabIndex = 12;
            this.ybox.Visible = false;
            this.ybox.TextChanged += new System.EventHandler(this.ybox_TextChanged);
            // 
            // y
            // 
            this.y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.y.AutoSize = true;
            this.y.Location = new System.Drawing.Point(410, 17);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(17, 13);
            this.y.TabIndex = 13;
            this.y.Text = "Y:";
            this.y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.y.Visible = false;
            // 
            // xbox
            // 
            this.xbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.xbox.Enabled = false;
            this.xbox.Location = new System.Drawing.Point(379, 13);
            this.xbox.Name = "xbox";
            this.xbox.Size = new System.Drawing.Size(25, 20);
            this.xbox.TabIndex = 14;
            this.xbox.Visible = false;
            this.xbox.TextChanged += new System.EventHandler(this.xbox_TextChanged);
            // 
            // goalslabel
            // 
            this.goalslabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.goalslabel.AutoSize = true;
            this.goalslabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.goalslabel.Location = new System.Drawing.Point(651, 17);
            this.goalslabel.Name = "goalslabel";
            this.goalslabel.Size = new System.Drawing.Size(24, 13);
            this.goalslabel.TabIndex = 5;
            this.goalslabel.Text = "0";
            this.goalslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.goalslabel.Visible = false;
            // 
            // misseslabel
            // 
            this.misseslabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.misseslabel.AutoSize = true;
            this.misseslabel.ForeColor = System.Drawing.Color.Red;
            this.misseslabel.Location = new System.Drawing.Point(621, 17);
            this.misseslabel.Name = "misseslabel";
            this.misseslabel.Size = new System.Drawing.Size(24, 13);
            this.misseslabel.TabIndex = 4;
            this.misseslabel.Text = "0";
            this.misseslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.misseslabel.Visible = false;
            // 
            // shootslabel
            // 
            this.shootslabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.shootslabel.AutoSize = true;
            this.shootslabel.Location = new System.Drawing.Point(573, 10);
            this.shootslabel.Name = "shootslabel";
            this.shootslabel.Size = new System.Drawing.Size(42, 26);
            this.shootslabel.TabIndex = 11;
            this.shootslabel.Text = "999 из 999";
            this.shootslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shootslabel.Visible = false;
            // 
            // shootbutton
            // 
            this.shootbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.shootbutton.Location = new System.Drawing.Point(464, 7);
            this.shootbutton.Name = "shootbutton";
            this.shootbutton.Size = new System.Drawing.Size(103, 33);
            this.shootbutton.TabIndex = 16;
            this.shootbutton.Text = "Сделать выстрел";
            this.shootbutton.UseVisualStyleBackColor = true;
            this.shootbutton.Visible = false;
            this.shootbutton.Click += new System.EventHandler(this.shootbutton_Click);
            // 
            // shooting_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.bigtable);
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "shooting_form";
            this.Text = "Мишень";
            this.Load += new System.EventHandler(this.shooting_form_Load);
            this.bigtable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.target)).EndInit();
            this.smalltable.ResumeLayout(false);
            this.smalltable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel bigtable;
        private System.Windows.Forms.PictureBox target;
        private System.Windows.Forms.TableLayoutPanel smalltable;
        private System.Windows.Forms.Label radlabel;
        private System.Windows.Forms.Label shootlabel;
        private System.Windows.Forms.Label misseslabel;
        private System.Windows.Forms.Label goalslabel;
        private System.Windows.Forms.TextBox radbox;
        private System.Windows.Forms.TextBox shootbox;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label shootslabel;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.TextBox ybox;
        private System.Windows.Forms.Label y;
        private System.Windows.Forms.TextBox xbox;
        private System.Windows.Forms.Button shootbutton;
    }
}

