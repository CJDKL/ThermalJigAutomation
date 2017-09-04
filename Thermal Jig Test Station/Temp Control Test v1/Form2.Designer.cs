namespace Temp_Control_Test_v1
{
    partial class Form2
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
            this.ch1TempSetting = new System.Windows.Forms.ComboBox();
            this.ch1TimeSetting = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.revert = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.save_exit = new System.Windows.Forms.Button();
            this.rampSetMin2 = new System.Windows.Forms.TextBox();
            this.rampSetMax2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rampSetMin = new System.Windows.Forms.TextBox();
            this.rampSetMax = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.peakHoldTime2 = new System.Windows.Forms.TextBox();
            this.startHoldTime2 = new System.Windows.Forms.TextBox();
            this.rampDownTime2 = new System.Windows.Forms.TextBox();
            this.rampUpTime2 = new System.Windows.Forms.TextBox();
            this.rampDownMin2 = new System.Windows.Forms.TextBox();
            this.rampDownMax2 = new System.Windows.Forms.TextBox();
            this.rampUpMax2 = new System.Windows.Forms.TextBox();
            this.rampUpMin2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.peakHoldTime = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.startHoldTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rampDownTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rampUpTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rampDownMin = new System.Windows.Forms.TextBox();
            this.rampDownMax = new System.Windows.Forms.TextBox();
            this.rampUpMax = new System.Windows.Forms.TextBox();
            this.rampUpMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ch1TempSetting
            // 
            this.ch1TempSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ch1TempSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ch1TempSetting.FormattingEnabled = true;
            this.ch1TempSetting.Location = new System.Drawing.Point(195, 573);
            this.ch1TempSetting.Name = "ch1TempSetting";
            this.ch1TempSetting.Size = new System.Drawing.Size(211, 32);
            this.ch1TempSetting.TabIndex = 141;
            this.ch1TempSetting.SelectedIndexChanged += new System.EventHandler(this.ch1TempSetting_SelectedIndexChanged);
            // 
            // ch1TimeSetting
            // 
            this.ch1TimeSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ch1TimeSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ch1TimeSetting.FormattingEnabled = true;
            this.ch1TimeSetting.Location = new System.Drawing.Point(195, 539);
            this.ch1TimeSetting.Name = "ch1TimeSetting";
            this.ch1TimeSetting.Size = new System.Drawing.Size(211, 32);
            this.ch1TimeSetting.TabIndex = 140;
            this.ch1TimeSetting.SelectedIndexChanged += new System.EventHandler(this.ch1TimeSetting_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(42, 576);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 139;
            this.label3.Text = "Temperature:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(108, 547);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 138;
            this.label2.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(19, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 137;
            this.label1.Text = "Units";
            // 
            // clear
            // 
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.clear.Location = new System.Drawing.Point(59, 658);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(142, 36);
            this.clear.TabIndex = 136;
            this.clear.TabStop = false;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // revert
            // 
            this.revert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.revert.Location = new System.Drawing.Point(59, 616);
            this.revert.Name = "revert";
            this.revert.Size = new System.Drawing.Size(142, 36);
            this.revert.TabIndex = 135;
            this.revert.TabStop = false;
            this.revert.Text = "Revert";
            this.revert.UseVisualStyleBackColor = true;
            this.revert.MouseClick += new System.Windows.Forms.MouseEventHandler(this.revert_Click);
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.exit.Location = new System.Drawing.Point(237, 616);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(142, 36);
            this.exit.TabIndex = 134;
            this.exit.TabStop = false;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exit_Click);
            // 
            // save_exit
            // 
            this.save_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.save_exit.Location = new System.Drawing.Point(237, 658);
            this.save_exit.Name = "save_exit";
            this.save_exit.Size = new System.Drawing.Size(142, 36);
            this.save_exit.TabIndex = 96;
            this.save_exit.TabStop = false;
            this.save_exit.Text = "Save and Exit";
            this.save_exit.UseVisualStyleBackColor = true;
            this.save_exit.Click += new System.EventHandler(this.save_exit_Click);
            // 
            // rampSetMin2
            // 
            this.rampSetMin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampSetMin2.Location = new System.Drawing.Point(315, 148);
            this.rampSetMin2.Name = "rampSetMin2";
            this.rampSetMin2.Size = new System.Drawing.Size(92, 29);
            this.rampSetMin2.TabIndex = 109;
            // 
            // rampSetMax2
            // 
            this.rampSetMax2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampSetMax2.Location = new System.Drawing.Point(315, 117);
            this.rampSetMax2.Name = "rampSetMax2";
            this.rampSetMax2.Size = new System.Drawing.Size(92, 29);
            this.rampSetMax2.TabIndex = 108;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label19.Location = new System.Drawing.Point(18, 98);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 24);
            this.label19.TabIndex = 133;
            this.label19.Text = "Limits";
            // 
            // rampSetMin
            // 
            this.rampSetMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampSetMin.Location = new System.Drawing.Point(196, 148);
            this.rampSetMin.Name = "rampSetMin";
            this.rampSetMin.Size = new System.Drawing.Size(93, 29);
            this.rampSetMin.TabIndex = 99;
            // 
            // rampSetMax
            // 
            this.rampSetMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampSetMax.Location = new System.Drawing.Point(196, 117);
            this.rampSetMax.Name = "rampSetMax";
            this.rampSetMax.Size = new System.Drawing.Size(93, 29);
            this.rampSetMax.TabIndex = 98;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label20.Location = new System.Drawing.Point(68, 151);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 24);
            this.label20.TabIndex = 132;
            this.label20.Text = "Ramp Min:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label21.Location = new System.Drawing.Point(63, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 24);
            this.label21.TabIndex = 131;
            this.label21.Text = "Ramp Max:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label18.Location = new System.Drawing.Point(311, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 24);
            this.label18.TabIndex = 130;
            this.label18.Text = "Channel 2";
            // 
            // peakHoldTime2
            // 
            this.peakHoldTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.peakHoldTime2.Location = new System.Drawing.Point(315, 345);
            this.peakHoldTime2.Name = "peakHoldTime2";
            this.peakHoldTime2.Size = new System.Drawing.Size(92, 29);
            this.peakHoldTime2.TabIndex = 113;
            // 
            // startHoldTime2
            // 
            this.startHoldTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.startHoldTime2.Location = new System.Drawing.Point(314, 56);
            this.startHoldTime2.Name = "startHoldTime2";
            this.startHoldTime2.Size = new System.Drawing.Size(92, 29);
            this.startHoldTime2.TabIndex = 107;
            // 
            // rampDownTime2
            // 
            this.rampDownTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampDownTime2.Location = new System.Drawing.Point(314, 475);
            this.rampDownTime2.Name = "rampDownTime2";
            this.rampDownTime2.Size = new System.Drawing.Size(92, 29);
            this.rampDownTime2.TabIndex = 116;
            // 
            // rampUpTime2
            // 
            this.rampUpTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampUpTime2.Location = new System.Drawing.Point(314, 278);
            this.rampUpTime2.Name = "rampUpTime2";
            this.rampUpTime2.Size = new System.Drawing.Size(92, 29);
            this.rampUpTime2.TabIndex = 112;
            // 
            // rampDownMin2
            // 
            this.rampDownMin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampDownMin2.Location = new System.Drawing.Point(314, 444);
            this.rampDownMin2.Name = "rampDownMin2";
            this.rampDownMin2.Size = new System.Drawing.Size(92, 29);
            this.rampDownMin2.TabIndex = 115;
            // 
            // rampDownMax2
            // 
            this.rampDownMax2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampDownMax2.Location = new System.Drawing.Point(314, 413);
            this.rampDownMax2.Name = "rampDownMax2";
            this.rampDownMax2.Size = new System.Drawing.Size(92, 29);
            this.rampDownMax2.TabIndex = 114;
            // 
            // rampUpMax2
            // 
            this.rampUpMax2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampUpMax2.Location = new System.Drawing.Point(314, 247);
            this.rampUpMax2.Name = "rampUpMax2";
            this.rampUpMax2.Size = new System.Drawing.Size(92, 29);
            this.rampUpMax2.TabIndex = 111;
            // 
            // rampUpMin2
            // 
            this.rampUpMin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampUpMin2.Location = new System.Drawing.Point(314, 216);
            this.rampUpMin2.Name = "rampUpMin2";
            this.rampUpMin2.Size = new System.Drawing.Size(92, 29);
            this.rampUpMin2.TabIndex = 110;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label17.Location = new System.Drawing.Point(193, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 24);
            this.label17.TabIndex = 117;
            this.label17.Text = "Channel 1";
            // 
            // peakHoldTime
            // 
            this.peakHoldTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.peakHoldTime.Location = new System.Drawing.Point(196, 345);
            this.peakHoldTime.Name = "peakHoldTime";
            this.peakHoldTime.Size = new System.Drawing.Size(93, 29);
            this.peakHoldTime.TabIndex = 103;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label15.Location = new System.Drawing.Point(64, 348);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 24);
            this.label15.TabIndex = 129;
            this.label15.Text = "Hold Time:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label16.Location = new System.Drawing.Point(19, 324);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 24);
            this.label16.TabIndex = 128;
            this.label16.Text = "Peak";
            // 
            // startHoldTime
            // 
            this.startHoldTime.BackColor = System.Drawing.SystemColors.Window;
            this.startHoldTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.startHoldTime.Location = new System.Drawing.Point(195, 56);
            this.startHoldTime.Name = "startHoldTime";
            this.startHoldTime.Size = new System.Drawing.Size(93, 29);
            this.startHoldTime.TabIndex = 97;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label14.Location = new System.Drawing.Point(63, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 24);
            this.label14.TabIndex = 127;
            this.label14.Text = "Hold Time:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label13.Location = new System.Drawing.Point(17, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 24);
            this.label13.TabIndex = 126;
            this.label13.Text = "Start";
            // 
            // rampDownTime
            // 
            this.rampDownTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampDownTime.Location = new System.Drawing.Point(195, 475);
            this.rampDownTime.Name = "rampDownTime";
            this.rampDownTime.Size = new System.Drawing.Size(93, 29);
            this.rampDownTime.TabIndex = 106;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label12.Location = new System.Drawing.Point(56, 477);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 24);
            this.label12.TabIndex = 125;
            this.label12.Text = "Ramp Time:";
            // 
            // rampUpTime
            // 
            this.rampUpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampUpTime.Location = new System.Drawing.Point(195, 278);
            this.rampUpTime.Name = "rampUpTime";
            this.rampUpTime.Size = new System.Drawing.Size(93, 29);
            this.rampUpTime.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(55, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 24);
            this.label5.TabIndex = 124;
            this.label5.Text = "Ramp Time:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label11.Location = new System.Drawing.Point(95, 447);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 24);
            this.label11.TabIndex = 123;
            this.label11.Text = "End Pt:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.Location = new System.Drawing.Point(17, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 24);
            this.label10.TabIndex = 122;
            this.label10.Text = "Ramp Up";
            // 
            // rampDownMin
            // 
            this.rampDownMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampDownMin.Location = new System.Drawing.Point(195, 444);
            this.rampDownMin.Name = "rampDownMin";
            this.rampDownMin.Size = new System.Drawing.Size(93, 29);
            this.rampDownMin.TabIndex = 105;
            // 
            // rampDownMax
            // 
            this.rampDownMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampDownMax.Location = new System.Drawing.Point(195, 413);
            this.rampDownMax.Name = "rampDownMax";
            this.rampDownMax.Size = new System.Drawing.Size(93, 29);
            this.rampDownMax.TabIndex = 104;
            // 
            // rampUpMax
            // 
            this.rampUpMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampUpMax.Location = new System.Drawing.Point(195, 247);
            this.rampUpMax.Name = "rampUpMax";
            this.rampUpMax.Size = new System.Drawing.Size(93, 29);
            this.rampUpMax.TabIndex = 101;
            // 
            // rampUpMin
            // 
            this.rampUpMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rampUpMin.Location = new System.Drawing.Point(195, 216);
            this.rampUpMin.Name = "rampUpMin";
            this.rampUpMin.Size = new System.Drawing.Size(93, 29);
            this.rampUpMin.TabIndex = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label9.Location = new System.Drawing.Point(17, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 24);
            this.label9.TabIndex = 121;
            this.label9.Text = "Ramp Down ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label8.Location = new System.Drawing.Point(94, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 24);
            this.label8.TabIndex = 120;
            this.label8.Text = "Start Pt:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(97, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 119;
            this.label7.Text = "End Pt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(96, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 118;
            this.label6.Text = "Start Pt:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 714);
            this.Controls.Add(this.ch1TempSetting);
            this.Controls.Add(this.ch1TimeSetting);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.save_exit);
            this.Controls.Add(this.rampSetMin2);
            this.Controls.Add(this.rampSetMax2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.rampSetMin);
            this.Controls.Add(this.rampSetMax);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.peakHoldTime2);
            this.Controls.Add(this.startHoldTime2);
            this.Controls.Add(this.rampDownTime2);
            this.Controls.Add(this.rampUpTime2);
            this.Controls.Add(this.rampDownMin2);
            this.Controls.Add(this.rampDownMax2);
            this.Controls.Add(this.rampUpMax2);
            this.Controls.Add(this.rampUpMin2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.peakHoldTime);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.startHoldTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rampDownTime);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.rampUpTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rampDownMin);
            this.Controls.Add(this.rampDownMax);
            this.Controls.Add(this.rampUpMax);
            this.Controls.Add(this.rampUpMin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.form_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Form1 frm1;
        public System.Windows.Forms.ComboBox ch1TempSetting;
        public System.Windows.Forms.ComboBox ch1TimeSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button revert;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button save_exit;
        public System.Windows.Forms.TextBox rampSetMin2;
        public System.Windows.Forms.TextBox rampSetMax2;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox rampSetMin;
        public System.Windows.Forms.TextBox rampSetMax;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox peakHoldTime2;
        public System.Windows.Forms.TextBox startHoldTime2;
        public System.Windows.Forms.TextBox rampDownTime2;
        public System.Windows.Forms.TextBox rampUpTime2;
        public System.Windows.Forms.TextBox rampDownMin2;
        public System.Windows.Forms.TextBox rampDownMax2;
        public System.Windows.Forms.TextBox rampUpMax2;
        public System.Windows.Forms.TextBox rampUpMin2;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox peakHoldTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox startHoldTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox rampDownTime;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox rampUpTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox rampDownMin;
        public System.Windows.Forms.TextBox rampDownMax;
        public System.Windows.Forms.TextBox rampUpMax;
        public System.Windows.Forms.TextBox rampUpMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}