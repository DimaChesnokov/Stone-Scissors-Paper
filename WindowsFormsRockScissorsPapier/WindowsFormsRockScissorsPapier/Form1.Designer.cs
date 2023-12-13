
namespace WindowsFormsRockScissorsPapier
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radio_server = new System.Windows.Forms.RadioButton();
            this.radio_client = new System.Windows.Forms.RadioButton();
            this.text_ip = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label_result = new System.Windows.Forms.Label();
            this.text_debug = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radio_server
            // 
            this.radio_server.AutoSize = true;
            this.radio_server.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radio_server.Location = new System.Drawing.Point(29, 33);
            this.radio_server.Name = "radio_server";
            this.radio_server.Size = new System.Drawing.Size(106, 31);
            this.radio_server.TabIndex = 0;
            this.radio_server.TabStop = true;
            this.radio_server.Text = "Сервер";
            this.radio_server.UseVisualStyleBackColor = true;
            this.radio_server.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radio_client
            // 
            this.radio_client.AutoSize = true;
            this.radio_client.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radio_client.Location = new System.Drawing.Point(29, 70);
            this.radio_client.Name = "radio_client";
            this.radio_client.Size = new System.Drawing.Size(108, 31);
            this.radio_client.TabIndex = 1;
            this.radio_client.TabStop = true;
            this.radio_client.Text = "Клиент";
            this.radio_client.UseVisualStyleBackColor = true;
            // 
            // text_ip
            // 
            this.text_ip.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_ip.Location = new System.Drawing.Point(29, 114);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(108, 34);
            this.text_ip.TabIndex = 2;
            this.text_ip.Text = "127.0.0.1";
            this.text_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(151, 114);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(133, 36);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Старт";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(290, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Бумага";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Камень";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(151, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Ножницы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_result
            // 
            this.label_result.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_result.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_result.Location = new System.Drawing.Point(12, 254);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(411, 63);
            this.label_result.TabIndex = 7;
            this.label_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_debug
            // 
            this.text_debug.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.text_debug.Location = new System.Drawing.Point(466, 33);
            this.text_debug.Multiline = true;
            this.text_debug.Name = "text_debug";
            this.text_debug.ReadOnly = true;
            this.text_debug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_debug.Size = new System.Drawing.Size(309, 265);
            this.text_debug.TabIndex = 8;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button_clear
            // 
            this.button_clear.Enabled = false;
            this.button_clear.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_clear.Location = new System.Drawing.Point(765, 33);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(10, 11);
            this.button_clear.TabIndex = 9;
            this.button_clear.Text = "Очистить";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.text_debug);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.text_ip);
            this.Controls.Add(this.radio_client);
            this.Controls.Add(this.radio_server);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Камень-Ножницы-Бумага";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_server;
        private System.Windows.Forms.RadioButton radio_client;
        private System.Windows.Forms.TextBox text_ip;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.TextBox text_debug;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button_clear;
    }
}

