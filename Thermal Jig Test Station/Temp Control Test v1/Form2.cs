using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temp_Control_Test_v1
{
    public partial class Form2 : Form
    {
        Boolean runningTest1;
        Boolean runningTest2;
        List<TextBox> temp = new List<TextBox>();
        List<TextBox> time = new List<TextBox>();
        
        int tempSet;
        int timeSet;
        public Boolean saved = false;
        public Form2(Boolean test1Running, Boolean test2Running)
        {
            InitializeComponent();
            runningTest1 = test1Running;
            runningTest2 = test2Running;

            time.Add(startHoldTime);
            temp.Add(rampSetMax);
            temp.Add(rampSetMin);
            temp.Add(rampUpTime);
            time.Add(rampDownTime);
            temp.Add(rampUpMax);
            temp.Add(rampUpMin);
            temp.Add(rampDownMax);
            temp.Add(rampDownMin);
            time.Add(peakHoldTime);
            time.Add(startHoldTime2);
            temp.Add(rampSetMax2);
            temp.Add(rampSetMin2);
            temp.Add(rampUpTime2);
            time.Add(rampDownTime2);
            temp.Add(rampUpMax2);
            temp.Add(rampUpMin2);
            temp.Add(rampDownMax2);
            temp.Add(rampDownMin2);
            time.Add(peakHoldTime2);
            string[] times = { "Second", "Minute", "Hour" };
            foreach (string time in times)
            {
                ch1TimeSetting.Items.Add(time);
            }
            string[] temps = { "Celcius", "Farenheit" };
            foreach (string temp in temps)
            {
                ch1TempSetting.Items.Add(temp);
            }

            if (test1Running)
            {
                startHoldTime.Enabled = false;
                rampSetMax.Enabled = false;
                rampSetMin.Enabled = false;
                rampUpTime.Enabled = false;
                rampDownTime.Enabled = false;
                rampUpMax.Enabled = false;
                rampUpMin.Enabled = false;
                rampDownMax.Enabled = false;
                rampDownMin.Enabled = false;
                peakHoldTime.Enabled = false;
                ch1TimeSetting.Enabled = false;
                ch1TempSetting.Enabled = false;
            }
            if (test2Running)
            {
                startHoldTime2.Enabled = false;
                rampSetMax2.Enabled = false;
                rampSetMin2.Enabled = false;
                rampUpTime2.Enabled = false;
                rampDownTime2.Enabled = false;
                rampUpMax2.Enabled = false;
                rampUpMin2.Enabled = false;
                rampDownMax2.Enabled = false;
                rampDownMin2.Enabled = false;
                peakHoldTime2.Enabled = false;
                ch1TimeSetting.Enabled = false;
                ch1TempSetting.Enabled = false;
            }
        }

        private void form_load(object sender, EventArgs e)
        {
            startHoldTime.Text = "" + frm1.startHoldTime;
            rampSetMax.Text = "" + frm1.rampSetMax;
            rampSetMin.Text = "" + frm1.rampSetMin;
            rampUpTime.Text = "" + frm1.rampUpTime;
            rampDownTime.Text = "" + frm1.rampDownTime;
            rampUpMin.Text = "" + frm1.rampUpMin;
            rampUpMax.Text = "" + frm1.rampUpMax;
            rampDownMax.Text = "" + frm1.rampDownMax;
            rampDownMin.Text = "" + frm1.rampDownMin;
            peakHoldTime.Text = "" + frm1.peakHoldTime;
            startHoldTime2.Text = "" + frm1.startHoldTime2;
            rampSetMax2.Text = "" + frm1.rampSetMax2;
            rampSetMin2.Text = "" + frm1.rampSetMin2;
            rampUpTime2.Text = "" + frm1.rampUpTime2;
            rampDownTime2.Text = "" + frm1.rampDownTime2;
            rampUpMin2.Text = "" + frm1.rampUpMin2;
            rampUpMax2.Text = "" + frm1.rampUpMax2;
            rampDownMax2.Text = "" + frm1.rampDownMax2;
            rampDownMin2.Text = "" + frm1.rampDownMin2;
            peakHoldTime2.Text = "" + frm1.peakHoldTime2;
            timeSet = frm1.ch1TimeSetting;
            tempSet = frm1.ch1TempSetting;
            ch1TimeSetting.SelectedIndex = frm1.ch1TimeSetting;
            ch1TempSetting.SelectedIndex = frm1.ch1TempSetting;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            startHoldTime.Text = "" + frm1.startHoldTime;
            rampSetMax.Text = "" + frm1.rampSetMax;
            rampSetMin.Text = "" + frm1.rampSetMin;
            rampUpTime.Text = "" + frm1.rampUpTime;
            rampDownTime.Text = "" + frm1.rampDownTime;
            rampUpMin.Text = "" + frm1.rampUpMin;
            rampUpMax.Text = "" + frm1.rampUpMax;
            rampDownMax.Text = "" + frm1.rampDownMax;
            rampDownMin.Text = "" + frm1.rampDownMin;
            peakHoldTime.Text = "" + frm1.peakHoldTime;
            startHoldTime2.Text = "" + frm1.startHoldTime2;
            rampSetMax2.Text = "" + frm1.rampSetMax2;
            rampSetMin2.Text = "" + frm1.rampSetMin2;
            rampUpTime2.Text = "" + frm1.rampUpTime2;
            rampDownTime2.Text = "" + frm1.rampDownTime2;
            rampUpMin2.Text = "" + frm1.rampUpMin2;
            rampUpMax2.Text = "" + frm1.rampUpMax2;
            rampDownMax2.Text = "" + frm1.rampDownMax2;
            rampDownMin2.Text = "" + frm1.rampDownMin2;
            peakHoldTime2.Text = "" + frm1.peakHoldTime2;
            ch1TimeSetting.SelectedIndex = frm1.ch1TimeSetting;
            ch1TempSetting.SelectedIndex = frm1.ch1TempSetting;
            this.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (!runningTest1)
            {
                startHoldTime.Text = "";
                rampSetMax.Text = "";
                rampSetMin.Text = "";
                rampUpTime.Text = "";
                rampDownTime.Text = "";
                rampUpMin.Text = "";
                rampUpMax.Text = "";
                rampDownMax.Text = "";
                rampDownMin.Text = "";
                peakHoldTime.Text = "";
            }
            if (!runningTest2)
            {
                startHoldTime2.Text = "";
                rampSetMax2.Text = "";
                rampSetMin2.Text = "";
                rampUpTime2.Text = "";
                rampDownTime2.Text = "";
                rampUpMin2.Text = "";
                rampUpMax2.Text = "";
                rampDownMax2.Text = "";
                rampDownMin2.Text = "";
                peakHoldTime2.Text = "";
            }
        }

        private void revert_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    x.BackColor = SystemColors.Window;
                }
            }
            timeSet = frm1.ch1TempSetting;
            tempSet = frm1.ch1TimeSetting;
            ch1TimeSetting.SelectedIndex = frm1.ch1TimeSetting;
            ch1TempSetting.SelectedIndex = frm1.ch1TempSetting;
            startHoldTime.Text = "" + frm1.startHoldTime;
            rampSetMax.Text = "" + frm1.rampSetMax;
            rampSetMin.Text = "" + frm1.rampSetMin;
            rampUpTime.Text = "" + frm1.rampUpTime;
            rampDownTime.Text = "" + frm1.rampDownTime;
            rampUpMin.Text = "" + frm1.rampUpMin;
            rampUpMax.Text = "" + frm1.rampUpMax;
            rampDownMax.Text = "" + frm1.rampDownMax;
            rampDownMin.Text = "" + frm1.rampDownMin;
            peakHoldTime.Text = "" + frm1.peakHoldTime;
            startHoldTime2.Text = "" + frm1.startHoldTime2;
            rampSetMax2.Text = "" + frm1.rampSetMax2;
            rampSetMin2.Text = "" + frm1.rampSetMin2;
            rampUpTime2.Text = "" + frm1.rampUpTime2;
            rampDownTime2.Text = "" + frm1.rampDownTime2;
            rampUpMin2.Text = "" + frm1.rampUpMin2;
            rampUpMax2.Text = "" + frm1.rampUpMax2;
            rampDownMax2.Text = "" + frm1.rampDownMax2;
            rampDownMin2.Text = "" + frm1.rampDownMin2;
            peakHoldTime2.Text = "" + frm1.peakHoldTime2;
        }

        private void save_exit_Click(object sender, EventArgs e)
        {
            double n;
            Boolean valid_form = true;
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (!Double.TryParse(x.Text, out n))
                    {
                        x.BackColor = Color.Salmon;
                        valid_form = false;
                    }else
                    {
                        x.BackColor = Color.White;
                    }
                }
            }
            if (valid_form)
            {
                if (Convert.ToDouble(rampSetMax.Text) < Convert.ToDouble(rampUpMax.Text))
                {
                    rampSetMax.BackColor = Color.LightSalmon;
                    rampUpMax.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampUpMax.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMax.Text) < Convert.ToDouble(rampDownMax.Text))
                {
                    rampSetMax.BackColor = Color.LightSalmon;
                    rampDownMax.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampSetMax.BackColor = Color.White;
                    rampDownMax.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMin.Text) > Convert.ToDouble(rampDownMin.Text))
                {
                    rampSetMin.BackColor = Color.LightSalmon;
                    rampDownMin.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampDownMin.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMin.Text) > Convert.ToDouble(rampUpMin.Text))
                {
                    rampSetMin.BackColor = Color.LightSalmon;
                    rampUpMin.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampSetMin.BackColor = Color.White;
                    rampUpMin.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMax2.Text) < Convert.ToDouble(rampUpMax2.Text))
                {
                    rampSetMax2.BackColor = Color.LightSalmon;
                    rampUpMax2.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampUpMax2.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMax2.Text) < Convert.ToDouble(rampDownMax2.Text))
                {
                    rampSetMax2.BackColor = Color.LightSalmon;
                    rampDownMax2.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampSetMax2.BackColor = Color.White;
                    rampDownMax2.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMin2.Text) > Convert.ToDouble(rampDownMin2.Text))
                {
                    rampSetMin2.BackColor = Color.LightSalmon;
                    rampDownMin2.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampDownMin2.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMin2.Text) > Convert.ToDouble(rampUpMin2.Text))
                {
                    rampSetMin2.BackColor = Color.LightSalmon;
                    rampUpMin2.BackColor = Color.LightSalmon;
                    valid_form = false;
                }
                else
                {
                    rampSetMin2.BackColor = Color.White;
                    rampUpMin2.BackColor = Color.White;
                }
                if (Convert.ToDouble(rampSetMax.Text) <= Convert.ToDouble(rampSetMin.Text))
                {
                    valid_form = false;
                    rampSetMin.BackColor = Color.LightSalmon;
                    rampSetMax.BackColor = Color.LightSalmon;
                }
                else
                {
                }
                if (Convert.ToDouble(rampSetMax2.Text) <= Convert.ToDouble(rampSetMin2.Text))
                {
                    valid_form = false;
                    rampSetMin2.BackColor = Color.LightSalmon;
                    rampSetMax2.BackColor = Color.LightSalmon;
                }
                else
                {
                }
            }
            if (valid_form)
            {
                tempSet = ch1TempSetting.SelectedIndex;
                timeSet = ch1TimeSetting.SelectedIndex;
                saved = true;
                this.Close();
            }
        }

        private void ch1TempSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            double b;
            foreach (TextBox t in temp)
            {
                if (double.TryParse(t.Text, out b))
                {
                    if (ch1TempSetting.SelectedIndex == 0 && tempSet != 0)
                    {
                        t.Text = ((Convert.ToDouble(t.Text) - 32) * 5.0 / 9.0).ToString();
                    }
                    else if (ch1TempSetting.SelectedIndex == 1 && tempSet != 1)
                    {
                        t.Text = ((Convert.ToDouble(t.Text) * 9.0 / 5.0) + 32).ToString();
                    }
                }
            }
            tempSet = ch1TempSetting.SelectedIndex;
        }

        private void ch1TimeSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            double b;
            foreach (TextBox t in time)
            {
                if (double.TryParse(t.Text, out b))
                {
                    if (ch1TimeSetting.SelectedIndex == 0 && timeSet != 0)
                    {
                        if (timeSet == 1)
                        {
                            t.Text = (Convert.ToDouble(t.Text) * 60.0).ToString();
                        }
                        else if (timeSet == 2)
                        {
                            t.Text = (Convert.ToDouble(t.Text) * 60.0 * 60.0).ToString();
                        }
                    }
                    else if (ch1TimeSetting.SelectedIndex == 1 && timeSet != 1)
                    {
                        if (timeSet == 0)
                        {
                            t.Text = (Convert.ToDouble(t.Text) / 60.0).ToString();
                        }
                        else if (timeSet == 2)
                        {
                            t.Text = (Convert.ToDouble(t.Text) * 60.0).ToString();
                        }
                    }
                    else if (ch1TimeSetting.SelectedIndex == 2 && timeSet != 2)
                    {
                        if (timeSet == 0)
                        {
                            t.Text = (Convert.ToDouble(t.Text) / 60.0 / 60.0).ToString();
                        }
                        else if (timeSet == 1)
                        {
                            t.Text = (Convert.ToDouble(t.Text) / 60.0).ToString();
                        }
                    }
                }
            }
            timeSet = ch1TimeSetting.SelectedIndex;
        }
    }
}
