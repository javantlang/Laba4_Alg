namespace Laba4_Alg
{
    partial class Form1
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
            this.graphBox = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.RadioButton();
            this.btnConnect = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEiler = new System.Windows.Forms.RadioButton();
            this.btnWidth = new System.Windows.Forms.RadioButton();
            this.txtAttention = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphBox
            // 
            this.graphBox.BackColor = System.Drawing.Color.BurlyWood;
            this.graphBox.Location = new System.Drawing.Point(-1, 56);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(945, 570);
            this.graphBox.TabIndex = 0;
            this.graphBox.TabStop = false;
            this.graphBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphBox_MouseClick);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Silver;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClear.Location = new System.Drawing.Point(808, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 25);
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Очистить поле";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Checked = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(6, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(149, 20);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Добавить вершину";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.CheckedChanged += new System.EventHandler(this.ChangeStateRadioButton);
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConnect.Location = new System.Drawing.Point(161, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(158, 20);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Соединить вершины";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.CheckedChanged += new System.EventHandler(this.ChangeStateRadioButton);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.btnEiler);
            this.groupBox1.Controls.Add(this.btnWidth);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(-1, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(945, 34);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnEiler
            // 
            this.btnEiler.AutoSize = true;
            this.btnEiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEiler.Location = new System.Drawing.Point(461, 11);
            this.btnEiler.Name = "btnEiler";
            this.btnEiler.Size = new System.Drawing.Size(162, 20);
            this.btnEiler.TabIndex = 5;
            this.btnEiler.TabStop = true;
            this.btnEiler.Text = "Найти Эйлеров цикл";
            this.btnEiler.UseVisualStyleBackColor = true;
            this.btnEiler.CheckedChanged += new System.EventHandler(this.btnEiler_CheckedChanged);
            // 
            // btnWidth
            // 
            this.btnWidth.AutoSize = true;
            this.btnWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWidth.Location = new System.Drawing.Point(326, 11);
            this.btnWidth.Name = "btnWidth";
            this.btnWidth.Size = new System.Drawing.Size(129, 20);
            this.btnWidth.TabIndex = 4;
            this.btnWidth.TabStop = true;
            this.btnWidth.Text = "Поиск в ширину";
            this.btnWidth.UseVisualStyleBackColor = true;
            this.btnWidth.CheckedChanged += new System.EventHandler(this.ChangeStateRadioButton);
            // 
            // txtAttention
            // 
            this.txtAttention.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtAttention.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAttention.Location = new System.Drawing.Point(-1, 34);
            this.txtAttention.Name = "txtAttention";
            this.txtAttention.ReadOnly = true;
            this.txtAttention.Size = new System.Drawing.Size(945, 24);
            this.txtAttention.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 624);
            this.Controls.Add(this.txtAttention);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.graphBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Ежов Илья ПРО-223";
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphBox;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton btnAdd;
        private System.Windows.Forms.RadioButton btnConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAttention;
        private System.Windows.Forms.RadioButton btnWidth;
        private System.Windows.Forms.RadioButton btnEiler;
    }
}

