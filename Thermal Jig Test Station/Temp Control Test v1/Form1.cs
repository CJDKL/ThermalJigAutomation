using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Temp_Control_Test_v1
{
    public partial class Form1 : Form
    {
        //This is the region where all the variables are declared
        #region variables
        List<double> readHistory = new List<double>();
        List<double> readHistory2 = new List<double>();
        List<TextBox> name = new List<TextBox>();
        Boolean nameSaved = false;
        double tempHistory1 = 0;
        double tempHistory2 = 0;
        Form3 progress;
        public int timeOutMax = 0;
        public int timeOutCount = 0;

        //these 2 are all the same
        public int ch1TempSetting = 0; // 0 = Celcius, 1 = Farenheit
        public int ch2TempSetting = 0; // 0 = Celcius, 1 = Farenheit
        public int ch1TimeSetting = 0; // 0 = Seconds, 1 = Minutes, 2 = Hours
        public int ch2TimeSetting = 0; // 0 = Seconds, 1 = Minutes, 2 = Hours

        public double startHoldTime = 0;
        public double peakHoldTime = 0;
        public double rampUpTime = 0;
        public double rampDownTime = 0;
        public double rampSetMin = 0;
        public double rampSetMax = 0;
        public double rampUpMin = 0;
        public double rampUpMax = 0;
        public double rampDownMin = 0;
        public double rampDownMax = 0;
        public double startHoldTime2 = 0;
        public double peakHoldTime2 = 0;
        public double rampUpTime2 = 0;
        public double rampDownTime2 = 0;
        public double rampSetMin2 = 0;
        public double rampSetMax2 = 0;
        public double rampUpMin2 = 0;
        public double rampUpMax2 = 0;
        public double rampDownMin2 = 0;
        public double rampDownMax2 = 0;

        public double startHoldTimeC = 0;
        public double peakHoldTimeC = 0;
        public double rampUpTimeC = 0;
        public double rampDownTimeC = 0;
        public double rampSetMinC = 0;
        public double rampSetMaxC = 0;
        public double rampUpMinC = 0;
        public double rampUpMaxC = 0;
        public double rampDownMinC = 0;
        public double rampDownMaxC = 0;
        public double startHoldTime2C = 0;
        public double peakHoldTime2C = 0;
        public double rampUpTime2C = 0;
        public double rampDownTime2C = 0;
        public double rampSetMin2C = 0;
        public double rampSetMax2C = 0;
        public double rampUpMin2C = 0;
        public double rampUpMax2C = 0;
        public double rampDownMin2C = 0;
        public double rampDownMax2C = 0;

        public double ch1TempTarget = 0;
        public double ch2TempTarget = 0;

        SerialPort serialPort1;

        Boolean connectionBo = false;
        Boolean test1Running = false;
        Boolean test2Running = false;
        Boolean testAllRunning = false;

        BackgroundWorker test1 = new BackgroundWorker();
        BackgroundWorker test2 = new BackgroundWorker();
        BackgroundWorker verify = new BackgroundWorker();

        String fileName;
        String fileName2;
        #endregion

        //This is the region where the constructors are
        #region constructor
        public Form1()
        {
            serialPort1 = new SerialPort();
            serialPort1.ReadTimeout = 1000;

            InitializeComponent();
            InitializeBackgroundWorker();
            InitializePortSelection();
            InitializeGraphs();
            InitializeNameBox();
            FreshStart();
        }
        #endregion

        //This is the region where all the things are initialized as global variables
        #region initializations
        private void InitializePortSelection()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox_port.Items.Add(port);
            }
            comboBox_port.SelectedIndex = 0;

            //shows a list of the Baudrates, defaulted to 9600
            string[] baudrates = { "230400", "115200", "57600", "38400", "19200", "9600" };

            foreach (string baudrate in baudrates)
            {
                comboBox_baudrate.Items.Add(baudrate);
            }

            comboBox_baudrate.SelectedIndex = 5;
        } //Loads a list of valid ports and baudrates to the combo box for user selection
        private void InitializeBackgroundWorker()
        {
            test1.WorkerReportsProgress = true;
            test1.WorkerSupportsCancellation = true;
            test1.DoWork += new DoWorkEventHandler(test1_DoWork);
            test1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(test1_WorkCompleted);
            
            test2.WorkerReportsProgress = true;
            test2.WorkerSupportsCancellation = true;
            test2.DoWork += new DoWorkEventHandler(test2_DoWork);
            test2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(test2_WorkCompleted);

            verify.WorkerReportsProgress = true;
            verify.WorkerSupportsCancellation = true;
            verify.DoWork += new DoWorkEventHandler(verify_DoWork);
            verify.ProgressChanged += new ProgressChangedEventHandler(verify_ReportProgress);
            verify.RunWorkerCompleted += new RunWorkerCompletedEventHandler(verify_WorkCompleted);
        }
        private void InitializeGraphs()
        {
            chart_ch1.Series.Add("Temp CH1");
            chart_ch1.Series.Add("Ramp Up (Min)");
            chart_ch1.Series.Add("Ramp Up (Max)");
            chart_ch1.Series.Add("Ramp Down (Max)");
            chart_ch1.Series.Add("Ramp Down (Min)");
            chart_ch1.Series.Add("Ramp Set (Max)");
            chart_ch1.Series.Add("Ramp Set (Min)");
            chart_ch1.Series["Temp CH1"].ChartType = SeriesChartType.Line;
            chart_ch1.Series["Ramp Up (Min)"].ChartType = SeriesChartType.Line;
            chart_ch1.Series["Ramp Up (Max)"].ChartType = SeriesChartType.Line;
            chart_ch1.Series["Ramp Down (Max)"].ChartType = SeriesChartType.Line;
            chart_ch1.Series["Ramp Down (Min)"].ChartType = SeriesChartType.Line;
            chart_ch1.Series["Ramp Set (Max)"].ChartType = SeriesChartType.Line;
            chart_ch1.Series["Ramp Set (Min)"].ChartType = SeriesChartType.Line;
            chart_ch1.Series["Temp CH1"].BorderWidth = 3;
            chart_ch1.Series["Ramp Up (Min)"].BorderWidth = 1;
            chart_ch1.Series["Ramp Up (Max)"].BorderWidth = 1;
            chart_ch1.Series["Ramp Down (Max)"].BorderWidth = 1;
            chart_ch1.Series["Ramp Down (Min)"].BorderWidth = 1;
            chart_ch1.Series["Ramp Set (Max)"].BorderWidth = 2;
            chart_ch1.Series["Ramp Set (Min)"].BorderWidth = 2;
            chart_ch1.Series["Temp CH1"].Color = Color.Blue;
            chart_ch1.Series["Ramp Up (Min)"].Color = Color.LightBlue;
            chart_ch1.Series["Ramp Up (Max)"].Color = Color.LightBlue;
            chart_ch1.Series["Ramp Down (Max)"].Color = Color.LightSalmon;
            chart_ch1.Series["Ramp Down (Min)"].Color = Color.LightSalmon;
            chart_ch1.Series["Ramp Set (Max)"].Color = Color.DarkRed;
            chart_ch1.Series["Ramp Set (Min)"].Color = Color.DarkBlue;
            chart_ch1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart_ch1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
            chart_ch1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart_ch1.Series["Temp CH1"].IsXValueIndexed = false;
            chart_ch1.ChartAreas[0].Axes[0].Title = ("Time (Seconds)");
            chart_ch1.ChartAreas[0].Axes[1].Title = ("Temp (C)");

            chart_ch2.Series.Add("Temp CH2");
            chart_ch2.Series.Add("Ramp Up (Min)");
            chart_ch2.Series.Add("Ramp Up (Max)");
            chart_ch2.Series.Add("Ramp Down (Max)");
            chart_ch2.Series.Add("Ramp Down (Min)");
            chart_ch2.Series.Add("Ramp Set (Max)");
            chart_ch2.Series.Add("Ramp Set (Min)");
            chart_ch2.Series["Temp CH2"].ChartType = SeriesChartType.Line;
            chart_ch2.Series["Ramp Up (Min)"].ChartType = SeriesChartType.Line;
            chart_ch2.Series["Ramp Up (Max)"].ChartType = SeriesChartType.Line;
            chart_ch2.Series["Ramp Down (Max)"].ChartType = SeriesChartType.Line;
            chart_ch2.Series["Ramp Down (Min)"].ChartType = SeriesChartType.Line;
            chart_ch2.Series["Ramp Set (Max)"].ChartType = SeriesChartType.Line;
            chart_ch2.Series["Ramp Set (Min)"].ChartType = SeriesChartType.Line;
            chart_ch2.Series["Temp CH2"].BorderWidth = 3;
            chart_ch2.Series["Ramp Up (Min)"].BorderWidth = 2;
            chart_ch2.Series["Ramp Up (Max)"].BorderWidth = 2;
            chart_ch2.Series["Ramp Down (Max)"].BorderWidth = 2;
            chart_ch2.Series["Ramp Down (Min)"].BorderWidth = 2;
            chart_ch2.Series["Temp CH2"].Color = Color.Blue;
            chart_ch2.Series["Ramp Up (Min)"].Color = Color.LightBlue;
            chart_ch2.Series["Ramp Up (Max)"].Color = Color.LightBlue;
            chart_ch2.Series["Ramp Down (Max)"].Color = Color.LightSalmon;
            chart_ch2.Series["Ramp Down (Min)"].Color = Color.LightSalmon;
            chart_ch2.Series["Ramp Set (Max)"].Color = Color.DarkRed;
            chart_ch2.Series["Ramp Set (Min)"].Color = Color.DarkBlue;
            chart_ch2.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart_ch2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
            chart_ch2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart_ch2.Series["Temp CH2"].IsXValueIndexed = false;
            chart_ch2.ChartAreas[0].Name = "Channel 2";
            chart_ch2.ChartAreas[0].Axes[0].Title = ("Time (Seconds)");
            chart_ch2.ChartAreas[0].Axes[1].Title = ("Temp (C)");
        }
        private void InitializeNameBox()
        {
            name.Add(textBox_part1);
            name.Add(textBox_part2);
            name.Add(textBox_part3);
            name.Add(textBox_part4);
            name.Add(textBox_part5);
            name.Add(textBox_part6);
            name.Add(textBox_part7);
            name.Add(textBox_part8);
            name.Add(textBox_part9);
            name.Add(textBox_part10);
            name.Add(textBox_part11);
            name.Add(textBox_part12);
            name.Add(textBox_part13);
            name.Add(textBox_part14);
            name.Add(textBox_part15);
            name.Add(textBox_part16);
        }
        private void FreshStart()
        {
            foreach (Control p in this.Controls)
            {
                if (p is Panel)
                {
                    foreach(Control b in p.Controls)
                    {
                        if (b is Button)
                        {
                            b.Enabled = false;
                        }
                        if( b is TextBox)
                        {
                            b.BackColor = Color.White;
                            b.Text = "";
                            b.Enabled = false;
                        }
                        if( b is CheckBox)
                        {
                            b.Enabled = false;
                        }
                    }
                }
            }
            clearNameBox();
            enableNameBox(true);
            checkNameBox();
            connectionBo = false;
            checkBox_manualSync.Checked = false;
            test1Running = false;
            test2Running = false;
            textBox_outputStatus.BackColor = Color.LightSalmon;
            textBox_outputStatus.Text = "False";
            button_saveName.Enabled = true;
            button_exit.Enabled = true;
            button_connect.Enabled = true;
            button_settings.Enabled = true;
            button_connect.Text = "Connect";
            button_startTest1.Text = "Start CH1";
            button_startTest2.Text = "Start CH2";
            button_startTestAll.Text = "Start All";
            button_verifyChannels.Text = "Verify Channels";
            chart_ch1.Series["Temp CH1"].Points.Clear();
            chart_ch2.Series["Temp CH2"].Points.Clear();
            

            test1.CancelAsync();
            test2.CancelAsync();
            verify.CancelAsync();
            Thread.Sleep(100);
        } //Refreshs most of the interface and variables
        #endregion

        //This is the region where all the buttons are defined
        #region Buttons
        //When clicked, the program attempts to connect to the machine. If it fails to establish a connection, calls freshstart
        private void button_connect_Click(object sender, EventArgs e)
        {
            button_connect.Enabled = false;
            //If connected when button is pressed
            if (connectionBo)
            {
                setTempChannel1Power(false);    //Turn off the power
                Thread.Sleep(100);
                setTempChannel2Power(false);
                serialPort1.Close();    //Close Port
                button_connect.Text = "Connect";
                label_connectionStatus.BackColor = Color.Salmon;
                label_connectionStatus.Text = "Disconnected";
                connectionBo = false;
                FreshStart();
                timer_general.Stop(); //Stop Timer
            }
            //If not connected when button is pressed
            else
            {
                serialPort1.PortName = (String)comboBox_port.SelectedItem;
                serialPort1.BaudRate = Convert.ToInt32(comboBox_baudrate.SelectedItem);
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                try
                {
                    label_connectionStatus.Text = "Connecting";
                    label_connectionStatus.BackColor = Color.LightGreen;
                    button_connect.Text = "Disconnect";
                    serialPort1.Open(); //Open Port
                    connectionBo = true;
                    String connectionCheck = getTempChannelx(1); //Check Connection
                    label_connectionStatus.Text = "Connected";
                    setTempChannel1Power(false);    //Set power to false
                    Thread.Sleep(100);
                    setTempChannel2Power(false);
                    timer_general.Start();  //Start Timer
                    button_channelOn1.Enabled = true;
                    button_channelOn2.Enabled = true;

                }catch(Exception err) //if something goes wrong
                {
                    label_connectionStatus.BackColor = Color.Salmon;
                    label_connectionStatus.Text = "No Connection";
                    button_connect.Text = "Connect";
                    serialPort1.Close();    //Close the serial port
                    FreshStart();   //Refresh the GUI
                    connectionBo = false;   
                    timer_general.Stop();   //Stop Timer
                    Console.WriteLine(err.ToString());
                }
            }
            button_connect.Enabled = true;
        }
        //When clicked, this establishes a connection with channel 1 and unlock some other buttons
        private void button_channelOn1_Click(object sender, EventArgs e)
        {
            button_channelOff1.Enabled = true;
            button_channelOn1.Enabled = false;
            button_startTest1.Enabled = true;
            button_manualSetTemp1.Enabled = true;
            button_verifyChannels.Enabled = true;
            textBox_manualSetTemp1.Enabled = true;
            if (button_channelOff2.Enabled)
            {
                checkBox_manualSync.Enabled = true;
                button_startTestAll.Enabled = true;
            }
            setTempChannel1Power(true);
        }
        //When clicked, this disconnects the connection with channel 1 and lock some other buttons
        private void button_channelOff1_Click(object sender, EventArgs e)
        {
            checkBox_manualSync.Enabled = false;
            checkBox_manualSync.Checked = false;
            button_channelOff1.Enabled = false;
            button_channelOn1.Enabled = true;
            button_startTest1.Enabled = false;
            button_manualSetTemp1.Enabled = false;
            button_startTestAll.Enabled = false;
            textBox_manualSetTemp1.Enabled = false;
            textBox_manualSetTemp1.Text = "";
            setTempChannel1Power(false);
            if (button_channelOn2.Enabled)
            {
                button_verifyChannels.Enabled = false;
            }
        }
        //When clicked, this establishes a connection with channel 2 and unlock some other buttons
        private void button_channelOn2_Click(object sender, EventArgs e)
        {
            button_channelOff2.Enabled = true;
            button_channelOn2.Enabled = false;
            button_startTest2.Enabled = true;
            button_verifyChannels.Enabled = true;
            if (button_channelOff1.Enabled)
            {
                checkBox_manualSync.Enabled = true;
                button_startTestAll.Enabled = true;
            }
            if (!checkBox_manualSync.Checked)
            {
                button_manualSetTemp2.Enabled = true;
                textBox_manualSetTemp2.Enabled = true;
            }
            setTempChannel2Power(true);
        }
        //When clicked, this disconnects the connection with channel 2 and lock some other buttons
        private void button_channelOff2_Click(object sender, EventArgs e)
        {
            checkBox_manualSync.Enabled = false;
            checkBox_manualSync.Checked = false;
            button_channelOff2.Enabled = false;
            button_channelOn2.Enabled = true;
            button_startTest2.Enabled = false;
            button_manualSetTemp2.Enabled = false;
            button_startTestAll.Enabled = false;
            textBox_manualSetTemp2.Enabled = false;
            textBox_manualSetTemp2.Text = "";
            setTempChannel2Power(false);
            if (button_channelOn1.Enabled)
            {
                button_verifyChannels.Enabled = false;
            }
        }
        //When clicked, this runs a test the verify the channels
        private void button_verifyChannels_Click(object sender, EventArgs e)
        {
            if (!verify.IsBusy)
            {
                progress = new Form3();
                button_verifyChannels.Text = "Testing in Progress";
                verify.RunWorkerAsync();
                progress.ShowDialog();
                verify.CancelAsync();
            }
        }
        //When clicked, this toggles the status on rather channel 1 and 2 are manually synced
        private void checkBox_manualSync_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_manualSync.Checked == false && test2Running == false && button_channelOff2.Enabled == true)
            {
                textBox_manualSetTemp2.Enabled = true;
                button_manualSetTemp2.Enabled = true;
            }
            else if (checkBox_manualSync.Checked == true)
            {
                textBox_manualSetTemp2.Enabled = false;
                button_manualSetTemp2.Enabled = false;
            }
        }
        //When clicked, this manually sets the temperature for channel 1
        private void button_manualSetTemp1_Click(object sender, EventArgs e)
        {
            double n;
            if (Double.TryParse(textBox_manualSetTemp1.Text, out n))
            {
                setTempChannel(1, (float)toCelcius(n, ch1TempSetting));
                textBox_manualSetTemp1.BackColor = Color.White;
                if (checkBox_manualSync.Checked)
                {
                    Thread.Sleep(100);
                    if (button_channelOff2.Enabled == true)
                    {
                        textBox_manualSetTemp2.Text = textBox_manualSetTemp1.Text;
                        setTempChannel(2, (float)toCelcius(n, ch1TempSetting));
                        textBox_manualSetTemp2.BackColor = Color.White;
                    }
                    else
                    {
                        textBox_manualSetTemp2.BackColor = Color.LightSalmon;
                    }
                }
            }
            else
            {
                textBox_manualSetTemp1.BackColor = Color.LightSalmon;
            }
        }
        //When clicked, this manually sets the temperature for channel 2
        private void button_manualSetTemp2_Click(object sender, EventArgs e)
        {
            double n;
            if (Double.TryParse(textBox_manualSetTemp2.Text, out n))
            {
                setTempChannel(2, (float)toCelcius(n, ch2TempSetting));
                textBox_manualSetTemp2.BackColor = Color.White;  
            }
            else
            {
                textBox_manualSetTemp2.BackColor = Color.LightSalmon;
            }
        }
        //When clicked, this opens up the setting menu in a popup window
        private void button_settings_Click(object sender, EventArgs e)
        {
            Form2 settings = new Form2(test1Running, test2Running);
            settings.frm1 = this;
            settings.ShowDialog();
            if (settings.saved)
            {
                startHoldTime = Convert.ToDouble(settings.startHoldTime.Text);
                rampSetMax = Convert.ToDouble(settings.rampSetMax.Text);
                rampSetMin = Convert.ToDouble(settings.rampSetMin.Text);
                rampUpTime = Convert.ToDouble(settings.rampUpTime.Text);
                rampDownTime = Convert.ToDouble(settings.rampDownTime.Text);
                rampUpMin = Convert.ToDouble(settings.rampUpMin.Text);
                rampUpMax = Convert.ToDouble(settings.rampUpMax.Text);
                rampDownMax = Convert.ToDouble(settings.rampDownMax.Text);
                rampDownMin = Convert.ToDouble(settings.rampDownMin.Text);
                peakHoldTime = Convert.ToDouble(settings.peakHoldTime.Text);

                startHoldTime2 = Convert.ToDouble(settings.startHoldTime2.Text);
                rampSetMax2 = Convert.ToDouble(settings.rampSetMax2.Text);
                rampSetMin2 = Convert.ToDouble(settings.rampSetMin2.Text);
                rampUpTime2 = Convert.ToDouble(settings.rampUpTime2.Text);
                rampDownTime2 = Convert.ToDouble(settings.rampDownTime2.Text);
                rampUpMin2 = Convert.ToDouble(settings.rampUpMin2.Text);
                rampUpMax2 = Convert.ToDouble(settings.rampUpMax2.Text);
                rampDownMax2 = Convert.ToDouble(settings.rampDownMax2.Text);
                rampDownMin2 = Convert.ToDouble(settings.rampDownMin2.Text);
                peakHoldTime2 = Convert.ToDouble(settings.peakHoldTime2.Text);

                ch1TimeSetting = settings.ch1TimeSetting.SelectedIndex;
                ch2TimeSetting = settings.ch1TimeSetting.SelectedIndex;
                ch1TempSetting = settings.ch1TempSetting.SelectedIndex;
                ch2TempSetting = settings.ch1TempSetting.SelectedIndex;
                switchTime();
                switchTemp();
                convertUnits();
        }
    }
        //When clicked, this starts/stops the ramp-up/ramp-down test on channel 1
        private void button_startTest1_Click(object sender, EventArgs e)
        {
            if (test1Running)
            {
                if (!test2Running && button_channelOff2.Enabled)
                {
                    button_startTestAll.Enabled = true;
                }
                test1.CancelAsync();
                button_startTest1.Text = "Start CH1";
                test1Running = false;
            }else
            {
                if (!test1.IsBusy)
                {
                    clearTestStatus(1);
                    convertUnits();
                    button_startTestAll.Enabled = false;
                    button_manualSetTemp1.Enabled = false;
                    button_verifyChannels.Enabled = false;
                    chart_ch1.Series["Temp CH1"].Points.Clear();
                    button_startTest1.Text = "Stop CH1";
                    if (nameSaved)
                    {
                        updateFileName(ref fileName);
                        using (StreamWriter file = new StreamWriter(fileName, true))
                        {
                            if(ch1TempSetting == 0)
                            {
                                file.WriteLine("");
                            }else
                            {
                                file.WriteLine("");
                            }
                            file.Close();
                        }
                    }
                    button_saveName.Enabled = false;
                    button_editName.Enabled = false;
                    test1.RunWorkerAsync();
                    test1Running = true;
                }
            }
        }
        //When clicked, this starts/stops the ramp-up/ramp-down test on channel 2
        private void button_startTest2_Click(object sender, EventArgs e)
        {
            if (test2Running)
            {
                if (!test1Running && button_channelOff1.Enabled)
                {
                    button_startTestAll.Enabled = true;
                }
                test2.CancelAsync();
                button_startTest2.Text = "Start CH2";
                test2Running = false;
            }
            else
            {
                if (!test2.IsBusy)
                {
                    clearTestStatus(2);
                    convertUnits();
                    button_startTestAll.Enabled = false;
                    button_manualSetTemp2.Enabled = false;
                    button_verifyChannels.Enabled = false;
                    chart_ch2.Series["Temp CH2"].Points.Clear();
                    button_startTest2.Text = "Stop CH2";
                    if (nameSaved)
                    {
                        updateFileName(ref fileName2);
                        using (StreamWriter file = new StreamWriter(fileName2, true))
                        {
                            if (ch2TempSetting == 0)
                            {
                                file.WriteLine("");
                            }
                            else
                            {
                                file.WriteLine("");
                            }
                            file.Close();
                        }
                    }
                    button_saveName.Enabled = false;
                    button_editName.Enabled = false;
                    test2.RunWorkerAsync();
                    test2Running = true;
                }
            }
        }
        //When clicked, this starts/stops the ramp-up/ramp-down test on all the channels
        private void button_startTestAll_Click(object sender, EventArgs e)
        { 
            if(testAllRunning)
            {
                test1.CancelAsync();
                test2.CancelAsync();
                button_startTest1.Enabled = true;
                button_startTest2.Enabled = true;
                button_verifyChannels.Enabled = true;
                button_startTestAll.Text = "Start All";
                test1Running = false;
                test2Running = false;
                testAllRunning = false;
            }
            else
            {
                clearTestStatus(1);
                clearTestStatus(2);
                convertUnits();
                button_startTestAll.Text = "Stop All";
                chart_ch1.Series["Temp CH1"].Points.Clear();
                chart_ch2.Series["Temp CH2"].Points.Clear();
                if (nameSaved)
                {
                    updateFileName(ref fileName2);
                    using (StreamWriter file = new StreamWriter(fileName2, true))
                    {
                        if (ch2TempSetting == 0)
                        {
                            file.WriteLine("");
                        }
                        else
                        {
                            file.WriteLine("");
                        }
                        file.Close();
                    }
                }
                button_verifyChannels.Enabled = false;
                button_saveName.Enabled = false;
                button_editName.Enabled = false;
                button_startTest1.Enabled = false;
                button_startTest2.Enabled = false;
                button_manualSetTemp1.Enabled = false;
                button_manualSetTemp2.Enabled = false;
                test1Running = true;
                test2Running = true;
                testAllRunning = true;
                test1.RunWorkerAsync();
                test2.RunWorkerAsync();
            }
        }
        //When clicked, this edits the name that is going to be used to name the file
        private void button_editName_Click(object sender, EventArgs e)
        {
            enableNameBox(true);
            nameSaved = false;
            button_editName.Enabled = false;
            button_saveName.Enabled = true;
            textBox_outputStatus.BackColor = Color.LightSalmon;
            textBox_outputStatus.Text = "False";
        }
        //When clicked, this save the name that is going to be used to name the file
        private void button_saveName_Click(object sender, EventArgs e)
        {
            if (checkNameBox())
            {
                enableNameBox(false);
                nameSaved = true;
                button_editName.Enabled = true;
                button_saveName.Enabled = false;
                textBox_outputStatus.BackColor = Color.LightGreen;
                textBox_outputStatus.Text = "True";
            };
        }
        //When clicked, this exits the application
        private void button_exit_Click(object sender, EventArgs e)
        {
            test1.CancelAsync();
            test2.CancelAsync();
            Thread.Sleep(100);
            setTempChannel1Power(false);
            Thread.Sleep(100);
            setTempChannel2Power(false);
            Thread.Sleep(100);
            serialPort1.Close();
            Application.Exit();
        }
        #endregion

        //This is the region where all the background workers are
        #region BackgroundWorkers
        private void verify_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Boolean on = !button_channelOn1.Enabled;
            Boolean on2 = !button_channelOn2.Enabled;
            double history1 = 0;
            double history2 = 0;
            worker.ReportProgress(0);
            this.Invoke((MethodInvoker)delegate ()
            {
                textBox_channelValidity1.Text = "Testing";
                textBox_channelValidity1.BackColor = Color.LightGreen;
                textBox_channelValidity2.Text = "Testing";
                textBox_channelValidity2.BackColor = Color.LightGreen;
            });
            try
            {
                if (!on || getTemp(1) > 1000 && !worker.CancellationPending)
                {
                    on = false;
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        textBox_channelValidity1.Text = "Channel is not on";
                        textBox_channelValidity1.BackColor = Color.LightSalmon;
                    });
                }
                if (!on2 || getTemp(2) > 1000 && !worker.CancellationPending)
                {
                    on2 = false;
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        textBox_channelValidity2.Text = "Channel is not on";
                        textBox_channelValidity2.BackColor = Color.LightSalmon;
                    });
                }

                if (on || on2 && !worker.CancellationPending)
                {
                    if (on && !worker.CancellationPending)
                    {
                        history1 = toCelcius(getTemp(1), ch1TempSetting);
                        setTempChannel(1, (float)history1 + 20);
                        Thread.Sleep(100);
                    }
                    if (on2 && !worker.CancellationPending)
                    {
                        history2 = toCelcius(getTemp(2), ch2TempSetting);
                        setTempChannel(2, (float)history2 + 20);
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        if (worker.CancellationPending)
                            break;
                        Thread.Sleep(1000);
                        worker.ReportProgress((int)(2.7 * i));
                    }
                    if (on && history1 > toCelcius(getTemp(1), ch1TempSetting) && !worker.CancellationPending)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            on = false;
                            textBox_channelValidity1.Text = "Failed";
                            textBox_channelValidity1.BackColor = Color.LightSalmon;
                        });
                    }
                    if (on2 && history2 > toCelcius(getTemp(2), ch2TempSetting) && !worker.CancellationPending)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            on2 = false;
                            textBox_channelValidity2.Text = "Failed";
                            textBox_channelValidity2.BackColor = Color.LightSalmon;
                        });
                    }

                    if ((on || on2) && history1 < toCelcius(getTemp(1), ch1TempSetting) || history2 < toCelcius(getTemp(2), ch2TempSetting) && !worker.CancellationPending)
                    {
                        if (on && !worker.CancellationPending)
                        {
                            setTempChannel(1, (float)history1 - 50);
                            Thread.Sleep(100);
                        }
                        if (on2 && !worker.CancellationPending)
                        {
                            setTempChannel(2, (float)history2 - 50);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            if (worker.CancellationPending)
                                break;
                            Thread.Sleep(1000);
                            worker.ReportProgress((int)(2.7 * 6) + (int)(2.7 * i));
                        }
                        history1 = toCelcius(getTemp(1), ch1TempSetting);
                        history2 = toCelcius(getTemp(2), ch2TempSetting);
                        for (int i = 0; i < 10; i++)
                        {
                            if (worker.CancellationPending)
                                break;
                            Thread.Sleep(1000);
                            worker.ReportProgress((int)(2.7 * 26) + (int)(3 * i));
                        }
                        if (on && history1 < toCelcius(getTemp(1), ch1TempSetting) && !worker.CancellationPending)
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                on = false;
                                textBox_channelValidity1.Text = "Failed";
                                textBox_channelValidity1.BackColor = Color.LightSalmon;
                            });
                        }
                        if (on && !worker.CancellationPending)
                        {

                            this.Invoke((MethodInvoker)delegate ()
                            {
                                textBox_channelValidity1.Text = "Passed";
                                textBox_channelValidity1.BackColor = Color.LightGreen;
                            });
                        }
                        if (on2 && history2 < toCelcius(getTemp(2), ch2TempSetting) && !worker.CancellationPending)
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                on2 = false;
                                textBox_channelValidity2.Text = "Failed";
                                textBox_channelValidity2.BackColor = Color.LightSalmon;
                            });
                        }
                        if (on2 && !worker.CancellationPending)
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                textBox_channelValidity2.Text = "Passed";
                                textBox_channelValidity2.BackColor = Color.LightGreen;
                            });
                        }
                    }
                }
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                if (on)
                {
                    setTempChannel(1, 25);
                    Thread.Sleep(100);
                }
                if (on2)
                {
                    setTempChannel(2, 25);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("BAAAAAA: " + err.ToString());
            }
        }
        private void verify_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                textBox_channelValidity1.Text = "Test Cancelled";
                textBox_channelValidity1.BackColor = Color.LightSalmon;
                textBox_channelValidity2.Text = "Test Cancelled";
                textBox_channelValidity2.BackColor = Color.LightSalmon;
            }
            else
            {
                progress.Close();
            }
            button_verifyChannels.Text = "Verify Channels";
        }
        private void verify_ReportProgress(object sender, ProgressChangedEventArgs e)
        {
            progress.setProgressBar(e.ProgressPercentage);
        }

        private void test1_DoWork(object sender, DoWorkEventArgs e)
        {
            long time;
            double stdv;
            this.Invoke((MethodInvoker)delegate ()
            {
                timer_graph1.Start();
                testStatus1.Text = "Running";
            });
            time = test1GoToSetPoint((float)rampSetMinC);
            this.Invoke((MethodInvoker)delegate ()
            {
                switch (ch1TimeSetting)
                {
                    case 0:
                        testStatus1.Text = "" + (time / 1000.0); break;
                    case 1:
                        testStatus1.Text = "" + (time / 1000.0 / 60.0); break;
                    case 2:
                        testStatus1.Text = "" + (time / 1000.0 / 60.0 / 60.0); break;
                }
                testStatus1.BackColor = Color.LightGreen;
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                testStatus2.Text = "Stabilizing";
            });
            wait(startHoldTimeC, 1);
            this.Invoke((MethodInvoker)delegate ()
            {
                testStatus2.Text = "Running";
            });
            stdv = -1;
            while (stdv < 0 || stdv > 0.3)
            {
                stdv = test1HoldAtSetPoint((float)rampSetMinC);
                if (test1.CancellationPending || (stdv >= 0 && stdv <= 0.3))
                    break;
                Popup pop = new Popup();
                DialogResult dialogResult = pop.ShowDialog();
                if (dialogResult == DialogResult.Retry)
                {
                    continue;
                }
                else if (dialogResult == DialogResult.Abort)
                {
                    test1.CancelAsync();
                    break;
                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    break;
                }
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                if (stdv > 0.3 || stdv < 0)
                {
                    testStatus2.Text = stdv + "";
                    testStatus2.BackColor = Color.LightSalmon;
                }
                else
                {
                    testStatus2.Text = stdv + "";
                    testStatus2.BackColor = Color.LightGreen;
                }
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                testStatus3.Text = "Rising";
                testStatus4.Text = "Running";
            });
            time = test1RiseToSetPointWithMeasurement((float)rampSetMaxC, (float)rampUpMinC, (float)rampUpMaxC, (float)rampUpTimeC);
            if (time == -1)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    testStatus3.Text = "Failed";
                    testStatus3.BackColor = Color.LightSalmon;
                });
                return;
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                switch (ch1TimeSetting)
                {
                    case 0:
                        testStatus4.Text = "" + (time / 1000.0); break;
                    case 1:
                        testStatus4.Text = "" + (time / 1000.0 / 60.0); break;
                    case 2:
                        testStatus4.Text = "" + (time / 1000.0 / 60.0 / 60.0); break;
                }
                testStatus4.BackColor = Color.LightGreen;
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                testStatus5.Text = "Stabilizing";
            });
            wait(peakHoldTimeC, 1);
            this.Invoke((MethodInvoker)delegate ()
            {
                testStatus5.Text = "Running";
            });
            stdv = -1;
            while (stdv > 0.3 || stdv < 0)
            {
                stdv = test1HoldAtSetPoint((float)rampSetMaxC);
                if (test1.CancellationPending || (stdv >= 0 && stdv <= 0.3))
                    break;
                Popup pop = new Popup();
                DialogResult dialogResult = pop.ShowDialog();
                if (dialogResult == DialogResult.Retry)
                {
                    continue;
                }
                else if (dialogResult == DialogResult.Abort)
                {
                    test1.CancelAsync();
                    break;
                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    break;
                }
            }
            this.Invoke((MethodInvoker)delegate ()
            {                
                if (stdv > 0.3 || stdv < 0)
                {
                    testStatus5.Text = stdv + "";
                    testStatus5.BackColor = Color.LightSalmon;
                }
                else
                {
                    testStatus5.Text = stdv + "";
                    testStatus5.BackColor = Color.LightGreen;
                }
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                testStatus6.Text = "Dropping";
            });
            time = test1DropToSetPointWithMeasurement((float)rampSetMinC, (float)rampDownMaxC, (float)rampDownMinC, (float)rampDownTimeC);
            if (test1.CancellationPending)
            {
                e.Cancel = true;
            }

        }
        private void test2_DoWork(object sender, DoWorkEventArgs e)
        {
            long time;
            double stdv;
            Thread.Sleep(100);
            this.Invoke((MethodInvoker)delegate ()
            {
                timer_graph2.Start();
                test2Status1.Text = "Running";
            });
            time = test2GoToSetPoint((float)rampSetMin2C);
            this.Invoke((MethodInvoker)delegate ()
            {
                switch (ch2TimeSetting)
                {
                    case 0:
                        test2Status1.Text = "" + (time / 1000.0); break;
                    case 1:
                        test2Status1.Text = "" + (time / 1000.0 / 60.0); break;
                    case 2:
                        test2Status1.Text = "" + (time / 1000.0 / 60.0 / 60.0); break;
                }
                test2Status1.BackColor = Color.LightGreen;
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                test2Status2.Text = "Stabilizing";
            });
            wait(startHoldTime2C, 2);
            this.Invoke((MethodInvoker)delegate ()
            {
                test2Status2.Text = "Running";
            });
            stdv = -1;
            while (stdv > 0.3 || stdv < 0)
            {
                stdv = test2HoldAtSetPoint((float)rampSetMin2C);
                if (test2.CancellationPending || (stdv >= 0 && stdv <= 0.3))
                    break;
                Popup2 pop = new Popup2();
                DialogResult dialogResult = pop.ShowDialog();
                if (dialogResult == DialogResult.Retry)
                {
                    continue;
                }
                else if (dialogResult == DialogResult.Abort)
                {
                    test2.CancelAsync();
                    break;
                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    break;
                }
            }
            this.Invoke((MethodInvoker)delegate ()
            {
              
                if (stdv > 0.3 || stdv < 0)
                {
                    test2Status2.Text = stdv + "";
                    test2Status2.BackColor = Color.LightSalmon;
                }
                else
                {
                    test2Status2.Text = stdv + "";
                    test2Status2.BackColor = Color.LightGreen;
                }
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                test2Status3.Text = "Rising";
                test2Status4.Text = "Running";
            });
            time = test2RiseToSetPointWithMeasurement((float)rampSetMax2C, (float)rampUpMin2C, (float)rampUpMax2C, (float)rampUpTime2C);
            if (time == -1)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    test2Status3.Text = "Failed";
                    test2Status3.BackColor = Color.LightSalmon;
                });
                return;
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                switch (ch2TimeSetting)
                {
                    case 0:
                        test2Status4.Text = "" + (time / 1000.0); break;
                    case 1:
                        test2Status4.Text = "" + (time / 1000.0 / 60.0); break;
                    case 2:
                        test2Status4.Text = "" + (time / 1000.0 / 60.0 / 60.0); break;
                }
                test2Status4.BackColor = Color.LightGreen;
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                test2Status5.Text = "Stabilizing";
            });
            wait(peakHoldTime2C, 2);
            this.Invoke((MethodInvoker)delegate ()
            {
                test2Status5.Text = "Running";
            });
            stdv = -1;
            while (stdv < 0 || stdv > 0.3)
            {
                stdv = test2HoldAtSetPoint((float)rampSetMax2C);
                if (test2.CancellationPending || (stdv >= 0 && stdv <= 0.3))
                    break;
                Popup2 pop = new Popup2();
                DialogResult dialogResult = pop.ShowDialog();
                if (dialogResult == DialogResult.Retry)
                {
                    continue;
                }
                else if (dialogResult == DialogResult.Abort)
                {
                    test2.CancelAsync();
                    break;
                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    break;
                }
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                if (stdv > 0.3 || stdv < 0)
                {
                    test2Status5.Text = stdv + "";
                    test2Status5.BackColor = Color.LightSalmon;
                }
                else
                {
                    test2Status5.Text = stdv + "";
                    test2Status5.BackColor = Color.LightGreen;
                }
            });
            this.Invoke((MethodInvoker)delegate ()
            {
                test2Status6.Text = "Dropping";
            });
            time = test2DropToSetPointWithMeasurement((float)rampSetMin2C, (float)rampDownMax2C, (float)rampDownMin2C, (float)rampDownTime2C);
            if (test2.CancellationPending)
            {
                e.Cancel = true;
            }

        }

        private void wait(double ms, int i)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (i == 1)
            {
                while (stopwatch.ElapsedMilliseconds < ms * 1000 && !test1.CancellationPending)
                {
                }
            }else
            {
                while (stopwatch.ElapsedMilliseconds < ms * 1000 && !test2.CancellationPending)
                {
                }
            }
        }
        //test 1 procedures
        private long test1GoToSetPoint(float x)
        {
            Boolean taskCompleted = false;
            Stopwatch stopwatch = new Stopwatch();
            setTempChannel(1, x);
            stopwatch.Start();
            while (!taskCompleted)
            {
                if (test1.CancellationPending)
                {
                    Console.WriteLine("Test Cancelled");
                    break;
                }
                if (!test1.CancellationPending && Math.Abs(toCelcius(getTemp(1), ch1TempSetting) - x) < 0.1)
                {
                    taskCompleted = true;
                }
            }
            return stopwatch.ElapsedMilliseconds;
        }
        private double test1HoldAtSetPoint(float x)
        {
            int trials = 0;
            double stdv = -1;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            readHistory.Clear();
            while (!test1.CancellationPending)
            {
                if (readHistory.Count >= 10)
                {
                    trials++;
                    stdv = calculateSTDV(readHistory);
                    if (calculateSTDV(readHistory) <= 0.3)
                    {
                        return stdv;
                    }
                    else
                    {
                        readHistory.Clear();
                    }
                }
                else if (trials >= 2)
                {
                    return stdv;
                }
            }
            return -1;
        }
        private long test1RiseToSetPointWithMeasurement(float temp, float start, float end, float targetTime)
        {
            Boolean taskCompleted = false;
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch measurement = new Stopwatch();
            setTempChannel(1, temp);
            stopwatch.Start();
            while (!taskCompleted)
            {
                if (test1.CancellationPending)
                {
                    break;
                }
                if (!test1.CancellationPending && toCelcius(getTemp(1), ch1TempSetting) >= start && toCelcius(getTemp(1), ch1TempSetting) < end && !measurement.IsRunning)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        testStatus3.Text = "Running";
                    });
                    measurement.Start();
                }
                else if (!test1.CancellationPending && toCelcius(getTemp(1), ch1TempSetting) >= end && measurement.IsRunning)
                {
                    double timeTaken = measurement.ElapsedMilliseconds;
                    measurement.Stop();
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        switch (ch1TimeSetting)
                        {
                            case 0:
                                testStatus3.Text = "" + (timeTaken / 1000.0); break;
                            case 1:
                                testStatus3.Text = "" + (timeTaken / 1000.0 / 60.0); break;
                            case 2:
                                testStatus3.Text = "" + (timeTaken / 1000.0 / 60.0 / 60.0); break;
                        }
                        if (timeTaken >= targetTime * 1000)
                        {
                            testStatus3.BackColor = Color.LightSalmon;
                        }
                        else
                        {
                            testStatus3.BackColor = Color.LightGreen;
                        }
                    });
                }
                if (!test1.CancellationPending && toCelcius(getTemp(1), ch1TempSetting) >= temp)
                {
                    taskCompleted = true;
                }
            }
            return stopwatch.ElapsedMilliseconds;
        }
        private long test1DropToSetPointWithMeasurement(float temp, float start, float end, float targetTime)
        {
            Boolean taskCompleted = false;
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch measurement = new Stopwatch();
            setTempChannel(1, temp);
            stopwatch.Start();
            while (!taskCompleted)
            {
                if (test1.CancellationPending)
                {
                    Console.WriteLine("Test Cancelled");
                    break;
                }
                if (!test1.CancellationPending && toCelcius(getTemp(1), ch1TempSetting) <= start && toCelcius(getTemp(1), ch1TempSetting) > end && !measurement.IsRunning)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        testStatus6.Text = "Running";
                    });
                    measurement.Start();
                }
                else if (!test1.CancellationPending && toCelcius(getTemp(1), ch1TempSetting) <= end && measurement.IsRunning)
                {
                    double timeTaken = measurement.ElapsedMilliseconds;
                    measurement.Stop();
                    taskCompleted = true;
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        switch (ch1TimeSetting)
                        {
                            case 0:
                                testStatus6.Text = "" + (timeTaken / 1000.0); break;
                            case 1:
                                testStatus6.Text = "" + (timeTaken / 1000.0 / 60.0); break;
                            case 2:
                                testStatus6.Text = "" + (timeTaken / 1000.0 / 60.0 / 60.0); break;
                        }
                        if (timeTaken >= targetTime * 1000)
                        {
                            testStatus6.BackColor = Color.LightSalmon;
                        }
                        else
                        {
                            testStatus6.BackColor = Color.LightGreen;
                        }
                    });
                }
            }
            return stopwatch.ElapsedMilliseconds;
        }
        private void test1_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (testStatus1.BackColor != Color.LightGreen ||
                testStatus2.BackColor != Color.LightGreen ||
                testStatus3.BackColor != Color.LightGreen ||
                testStatus4.BackColor != Color.LightGreen ||
                testStatus5.BackColor != Color.LightGreen ||
                testStatus6.BackColor != Color.LightGreen)
            {
                testStatus7.Text = "Failed";
                testStatus7.BackColor = Color.LightSalmon;
            }
            else
            {
                testStatus7.Text = "Passed";
                testStatus7.BackColor = Color.LightGreen;
            }
            if ((e.Cancelled == true))
            {
                testStatus1.BackColor = Color.White;
                testStatus2.BackColor = Color.White;
                testStatus3.BackColor = Color.White;
                testStatus4.BackColor = Color.White;
                testStatus5.BackColor = Color.White;
                testStatus6.BackColor = Color.White;
                testStatus7.Text = "Cancelled";
                testStatus7.BackColor = Color.LightSalmon;
            }
            else
            {
            }
            if (connectionBo)
            {
                if (!test2Running)
                {
                    button_verifyChannels.Enabled = true;
                }
                button_manualSetTemp1.Enabled = true;
            }
            button_startTest1.Text = "Start CH1";
            timer_graph1.Stop();
            if(testAllRunning && !test2Running)
            {
                testAllRunning = false;
                button_startTestAll.Text = "Start All";
                button_startTestAll.Enabled = true;
                button_startTest1.Enabled = true;
                button_startTest2.Enabled = true;
                button_manualSetTemp1.Enabled = true;
                button_manualSetTemp2.Enabled = true;
                button_verifyChannels.Enabled = true;
                timer_graph2.Stop();
            }
            test1Running = false;
            if (!test2Running)
            {
                button_editName.Enabled = true;
            }
        }

        //test 2 procedures
        private long test2GoToSetPoint(float x)
        {
            Boolean taskCompleted = false;
            Stopwatch stopwatch = new Stopwatch();
            setTempChannel(2, x);
            stopwatch.Start();
            while (!taskCompleted)
            {
                if (test2.CancellationPending)
                {
                    Console.WriteLine("Test Cancelled");
                    break;
                }
                if (!test2.CancellationPending && Math.Abs(toCelcius(getTemp(2), ch2TempSetting) - x) < 0.1)
                {
                    taskCompleted = true;
                }
            }
            Console.WriteLine("Done Running");
            return stopwatch.ElapsedMilliseconds;
        }
        private double test2HoldAtSetPoint(float x)
        {
            int trials = 0;
            double stdv = -1;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            readHistory2.Clear();
            while (!test2.CancellationPending)
            {
                if (readHistory2.Count >= 10)
                {
                    trials++;
                    stdv = calculateSTDV(readHistory2);
                    if (stdv <= 0.3)
                    {
                        return stdv;
                    }
                    else
                    {
                        readHistory2.Clear();
                    }
                }
                else if (trials >= 2)
                {
                    return stdv;
                }
            }
            return -1;
        }
        private long test2RiseToSetPointWithMeasurement(float temp, float start, float end, float targetTime)
        {
            Boolean taskCompleted = false;
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch measurement = new Stopwatch();
            setTempChannel(2, temp);
            stopwatch.Start();
            while (!taskCompleted)
            {
                if (test2.CancellationPending)
                {
                    break;
                }
                if (!test2.CancellationPending && toCelcius(getTemp(2), ch2TempSetting) >= start && toCelcius(getTemp(2), ch2TempSetting) < end && !measurement.IsRunning)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        test2Status3.Text = "Running";
                    });
                    measurement.Start();
                }
                else if (!test2.CancellationPending && toCelcius(getTemp(2), ch2TempSetting) >= end && measurement.IsRunning)
                {
                    double timeTaken = measurement.ElapsedMilliseconds;
                    measurement.Stop();
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        switch (ch2TimeSetting)
                        {
                            case 0:
                                test2Status3.Text = "" + (timeTaken / 1000.0); break;
                            case 1:
                                test2Status3.Text = "" + (timeTaken / 1000.0 / 60.0); break;
                            case 2:
                                test2Status3.Text = "" + (timeTaken / 1000.0 / 60.0 / 60.0); break;
                        }
                        if (timeTaken >= targetTime * 1000)
                        {
                            test2Status3.BackColor = Color.LightSalmon;
                        }
                        else
                        {
                            test2Status3.BackColor = Color.LightGreen;
                        }
                    });
                }
                if (!test2.CancellationPending && toCelcius(getTemp(2), ch2TempSetting) >= temp)
                {
                    taskCompleted = true;
                }
            }
            return stopwatch.ElapsedMilliseconds;
        }
        private long test2DropToSetPointWithMeasurement(float temp, float start, float end, float targetTime)
        {
            Boolean taskCompleted = false;
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch measurement = new Stopwatch();
            setTempChannel(2, temp);
            stopwatch.Start();
            while (!taskCompleted)
            {
                if (test2.CancellationPending)
                {
                    Console.WriteLine("Test Cancelled");
                    break;
                }
                if (!test2.CancellationPending && toCelcius(getTemp(2), ch2TempSetting) <= start && toCelcius(getTemp(2), ch1TempSetting) > end && !measurement.IsRunning)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        test2Status6.Text = "Running";
                    });
                    measurement.Start();
                }
                else if (!test2.CancellationPending && toCelcius(getTemp(2), ch1TempSetting) <= end && measurement.IsRunning)
                {
                    double timeTaken = measurement.ElapsedMilliseconds;
                    measurement.Stop();
                    taskCompleted = true;
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        switch (ch1TimeSetting)
                        {
                            case 0:
                                test2Status6.Text = "" + (timeTaken / 1000.0); break;
                            case 1:
                                test2Status6.Text = "" + (timeTaken / 1000.0 / 60.0); break;
                            case 2:
                                test2Status6.Text = "" + (timeTaken / 1000.0 / 60.0 / 60.0); break;
                        }
                        if (timeTaken >= targetTime * 1000)
                        {
                            test2Status6.BackColor = Color.LightSalmon;
                        }
                        else
                        {
                            test2Status6.BackColor = Color.LightGreen;
                        }
                    });
                }
            }
            Console.WriteLine("Done Running");
            return stopwatch.ElapsedMilliseconds;
        }
        private void test2_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (test2Status1.BackColor != Color.LightGreen ||
                test2Status2.BackColor != Color.LightGreen ||
                test2Status3.BackColor != Color.LightGreen ||
                test2Status4.BackColor != Color.LightGreen ||
                test2Status5.BackColor != Color.LightGreen ||
                test2Status6.BackColor != Color.LightGreen)
            {
                test2Status7.Text = "Failed";
                test2Status7.BackColor = Color.LightSalmon;
            }
            else
            {
                test2Status7.Text = "Passed";
                test2Status7.BackColor = Color.LightGreen;
            }
            if ((e.Cancelled == true))
            {
                test2Status1.BackColor = Color.White;
                test2Status2.BackColor = Color.White;
                test2Status3.BackColor = Color.White;
                test2Status4.BackColor = Color.White;
                test2Status5.BackColor = Color.White;
                test2Status6.BackColor = Color.White;
                test2Status7.Text = "Cancelled";
                test2Status7.BackColor = Color.LightSalmon;
            }
            else
            {
            }
            if (connectionBo)
            {
                if (!test1Running)
                {
                    button_verifyChannels.Enabled = true;
                }
                button_manualSetTemp2.Enabled = true;
            }
            button_startTest2.Text = "Start CH2";
            timer_graph2.Stop();
            if (testAllRunning && !test1Running)
            {            
                testAllRunning = false;
                button_startTestAll.Text = "Start All";
                button_verifyChannels.Enabled = true;
                button_startTestAll.Enabled = true;
                button_startTest1.Enabled = true;
                button_startTest2.Enabled = true;
                button_manualSetTemp1.Enabled = true;
                button_manualSetTemp2.Enabled = true;
                timer_graph1.Stop();
            }
            test2Running = false;
            if (!test1Running)
            {
                button_editName.Enabled = true;
            }
        }
        #endregion

        //This is the region where all the communications with the device happens
        #region Getting and Setting Temperatures
        //This is used by timer to get temperature from the channel indicated by num, the return string updates the display
        private String getTempChannel(int num)
        {
            String output = "";
            try
            {
                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();
                byte[] response = new byte[9];
                int[] intSend = new int[8];
                intSend[0] = 1;
                intSend[1] = 3;
                switch (num)
                {
                    case 1:
                        intSend[2] = 0x01;
                        intSend[3] = 0x68;
                        break;
                    case 2:
                        intSend[2] = 0x01;
                        intSend[3] = 0xB8;
                        break;
                }
                intSend[4] = 0x00;
                intSend[5] = 0x02;

                int int_crc = 0xFFFF;
                int int_lsb;
                int int_crc_byte_a, int_crc_byte_b;
                for (int i = 0; i < intSend.Length - 2; i++)
                {
                    int_crc = int_crc ^ intSend[i];
                    for (int j = 0; j < 8; j++)
                    {
                        int_lsb = int_crc & 0x0001;
                        int_crc = int_crc >> 1;
                        int_crc = int_crc & 0x7FFFF;
                        if (int_lsb == 1)
                            int_crc = int_crc ^ 0xA001;
                    }
                }
                int_crc_byte_a = int_crc & 0x00FF;
                int_crc_byte_b = (int_crc >> 8) & 0x00FF;

                byte[] byteSend = new byte[8];
                byte byteTransfer;
                for (int i = 0; i <= intSend.Length - 2; i++)
                {
                    byteSend[i] = (byte)intSend[i];
                }
                byteTransfer = (byte)int_crc_byte_a;
                byteSend[intSend.Length - 2] = byteTransfer;

                byteTransfer = (byte)int_crc_byte_b;
                byteSend[intSend.Length - 1] = byteTransfer;

                serialPort1.Write(byteSend, 0, byteSend.Length);
                for (int i = 0; i < response.Length; i++)
                {
                    response[i] = (byte)(serialPort1.ReadByte());
                }
                ushort[] values = new ushort[8];
                for (int i = 0; i < (response.Length - 5) / 2; i++)
                {
                    values[i] = response[2 * i + 3];
                    values[i] <<= 8;
                    values[i] += response[2 * i + 4];
                }
                output = "";
                for (int i = 0; i < (2 / 2); i++)
                {
                    int intValue = (int)values[2 * i + 1];
                    intValue <<= 16;
                    intValue += (int)values[2 * i];
                    output = BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0).ToString();
                }
            }
            catch (TimeoutException err)
            {
                timeOutCount++;
                Console.WriteLine(timeOutCount);
                if (timeOutCount >= timeOutMax)
                {
                    Console.WriteLine("get temp: " + err.ToString());
                    timer_general.Stop();
                    timer_graph1.Stop();
                    timer_graph2.Stop();
                    serialPort1.Close();
                    label_connectionStatus.BackColor = Color.Salmon;
                    label_connectionStatus.Text = "No Connection";
                    timeOutCount = 0;
                    FreshStart();
                }
                return output;
            }
            catch (System.IO.IOException err2)
            { }
            catch (InvalidOperationException err3)
            { } //not proud of using catches but this elimates hardware issues
            timeOutCount = 0;
            return output;
        }
        //This is just a decoy to check connection, does not catch any exceptions
        private String getTempChannelx(int num)
        {
            String output = "";
            serialPort1.DiscardOutBuffer();
            serialPort1.DiscardInBuffer();
            byte[] response = new byte[9];
            int[] intSend = new int[8];
            intSend[0] = 1;
            intSend[1] = 3;
            switch (num)
            {
                case 1:
                    intSend[2] = 0x01;
                    intSend[3] = 0x68;
                    break;
                case 2:
                    intSend[2] = 0x01;
                    intSend[3] = 0xB8;
                    break;
            }
            intSend[4] = 0x00;
            intSend[5] = 0x02;

            int int_crc = 0xFFFF;
            int int_lsb;
            int int_crc_byte_a, int_crc_byte_b;
            for (int i = 0; i < intSend.Length - 2; i++)
            {
                int_crc = int_crc ^ intSend[i];
                for (int j = 0; j < 8; j++)
                {
                    int_lsb = int_crc & 0x0001;
                    int_crc = int_crc >> 1;
                    int_crc = int_crc & 0x7FFFF;
                    if (int_lsb == 1)
                        int_crc = int_crc ^ 0xA001;
                }
            }
            int_crc_byte_a = int_crc & 0x00FF;
            int_crc_byte_b = (int_crc >> 8) & 0x00FF;

            byte[] byteSend = new byte[8];
            byte byteTransfer;
            for (int i = 0; i <= intSend.Length - 2; i++)
            {
                byteSend[i] = (byte)intSend[i];
            }
            byteTransfer = (byte)int_crc_byte_a;
            byteSend[intSend.Length - 2] = byteTransfer;

            byteTransfer = (byte)int_crc_byte_b;
            byteSend[intSend.Length - 1] = byteTransfer;

            serialPort1.Write(byteSend, 0, byteSend.Length);
            for (int i = 0; i < response.Length; i++)
            {
                response[i] = (byte)(serialPort1.ReadByte());
            }
            ushort[] values = new ushort[8];
            for (int i = 0; i < (response.Length - 5) / 2; i++)
            {
                values[i] = response[2 * i + 3];
                values[i] <<= 8;
                values[i] += response[2 * i + 4];
            }
            output = "";
            for (int i = 0; i < (2 / 2); i++)
            {
                int intValue = (int)values[2 * i + 1];
                intValue <<= 16;
                intValue += (int)values[2 * i];
                output = BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0).ToString();
            }
            return output;
        } 
        //This is used to get the temperature at a given channel based on the string display
        //Contains error checking to filter out invalid string values
        private double getTemp(int num)
        {
            if (num == 1)
            {
                try
                {
                    tempHistory1 = Convert.ToDouble(textBox_actualTemp1.Text);
                    return Convert.ToDouble(textBox_actualTemp1.Text);
                }
                catch (FormatException err) { 
                    return tempHistory1;
                }catch(Win32Exception oops)
                {
                    return tempHistory1;
                }
            }
            else
            {
                try
                {
                    tempHistory2 = Convert.ToDouble(textBox_actualTemp2.Text);
                    return Convert.ToDouble(textBox_actualTemp2.Text);
                }
                catch (FormatException err)
                {
                    return tempHistory2;
                }
                catch (Win32Exception oops)
                {
                    return tempHistory2;
                }
            }
        }
        //This is used to set the temperature at a given channel for specific temperatures
        private void setTempChannel(int channel, float target)
        {
            try
            {
                Byte[] bits = BitConverter.GetBytes(target);
                Array.Reverse(bits);
                string hex = BitConverter.ToString(bits).Replace("-", string.Empty); ;
                string hex1 = hex.Substring(0, 2);
                string hex2 = hex.Substring(2, 2);
                string hex3 = hex.Substring(4, 2);
                string hex4 = hex.Substring(6, 2);

                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();
                byte[] response = new byte[9];
                int[] intSend = new int[13];
                intSend[0] = 0x01;
                intSend[1] = 0x10;
                switch (channel)
                {
                    case 1:
                        intSend[2] = 0x08;
                        intSend[3] = 0x70;
                        break;
                    case 2:
                        intSend[2] = 0x08;
                        intSend[3] = 0xC0;
                        break;
                }
                intSend[4] = 0x00;
                intSend[5] = 0x02;
                intSend[6] = 0x04;
                intSend[7] = Convert.ToInt32(hex3, 16);
                intSend[8] = Convert.ToInt32(hex4, 16);
                intSend[9] = Convert.ToInt32(hex1, 16);
                intSend[10] = Convert.ToInt32(hex2, 16);
                intSend[11] = 0x00;
                intSend[12] = 0x04;

                int int_crc = 0xFFFF;
                int int_lsb;
                int int_crc_byte_a, int_crc_byte_b;
                for (int i = 0; i < intSend.Length - 2; i++)
                {
                    int_crc = int_crc ^ intSend[i];
                    for (int j = 0; j < 8; j++)
                    {
                        int_lsb = int_crc & 0x0001;
                        int_crc = int_crc >> 1;
                        int_crc = int_crc & 0x7FFFF;
                        if (int_lsb == 1)
                            int_crc = int_crc ^ 0xA001;
                    }
                }
                int_crc_byte_a = int_crc & 0x00FF;
                int_crc_byte_b = (int_crc >> 8) & 0x00FF;

                byte[] byteSend = new byte[13];
                byte byteTransfer;
                for (int i = 0; i <= intSend.Length - 2; i++)
                {
                    byteSend[i] = (byte)intSend[i];
                }

                byteTransfer = (byte)int_crc_byte_a;
                byteSend[intSend.Length - 2] = byteTransfer;

                byteTransfer = (byte)int_crc_byte_b;
                byteSend[intSend.Length - 1] = byteTransfer;
                serialPort1.Write(byteSend, 0, byteSend.Length);
                if(channel == 1)
                {
                    ch1TempTarget = target;                    
                }else if(channel == 2)
                {
                    ch2TempTarget = target;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        } 
        //This is used to turn on/off channel 1 by inputting true or false
        private void setTempChannel1Power(Boolean a)
        {
            try
            {
                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();
                int[] intSend = new int[11];
                intSend[0] = 0x01;
                intSend[1] = 0x10;
                intSend[2] = 0x07;
                intSend[3] = 0x58;
                intSend[4] = 0x00;
                intSend[5] = 0x01;
                intSend[6] = 0x02;
                intSend[7] = 0x00;
                if (a)
                {
                    intSend[8] = 0x0A;
                }
                else
                {
                    intSend[8] = 0x3E;
                }
                intSend[9] = 0x00;
                intSend[10] = 0x04;

                int int_crc = 0xFFFF;
                int int_lsb;
                int int_crc_byte_a, int_crc_byte_b;
                for (int i = 0; i < intSend.Length - 2; i++)
                {
                    int_crc = int_crc ^ intSend[i];
                    for (int j = 0; j < 8; j++)
                    {
                        int_lsb = int_crc & 0x0001;
                        int_crc = int_crc >> 1;
                        int_crc = int_crc & 0x7FFFF;
                        if (int_lsb == 1)
                            int_crc = int_crc ^ 0xA001;
                    }
                }
                int_crc_byte_a = int_crc & 0x00FF;
                int_crc_byte_b = (int_crc >> 8) & 0x00FF;

                byte[] byteSend = new byte[11];
                byte byteTransfer;
                for (int i = 0; i <= intSend.Length - 2; i++)
                {
                    byteSend[i] = (byte)intSend[i];
                }

                byteTransfer = (byte)int_crc_byte_a;
                byteSend[intSend.Length - 2] = byteTransfer;

                byteTransfer = (byte)int_crc_byte_b;
                byteSend[intSend.Length - 1] = byteTransfer;
                serialPort1.Write(byteSend, 0, byteSend.Length);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error Setting CH1 Power");
                Console.WriteLine(err.ToString());
            }
        } 
        //This is used to turn on/off channel 2 by inputting true or false
        private void setTempChannel2Power(Boolean a)
        {
            try
            {
                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();
                int[] intSend = new int[11];
                intSend[0] = 0x01;
                intSend[1] = 0x10;
                intSend[2] = 0x07;
                intSend[3] = 0x9E;
                intSend[4] = 0x00;
                intSend[5] = 0x01;
                intSend[6] = 0x02;
                intSend[7] = 0x00;
                if (a)
                {
                    intSend[8] = 0x0A;
                }
                else
                {
                    intSend[8] = 0x3E;
                }
                intSend[9] = 0x00;
                intSend[10] = 0x04;

                int int_crc = 0xFFFF;
                int int_lsb;
                int int_crc_byte_a, int_crc_byte_b;
                for (int i = 0; i < intSend.Length - 2; i++)
                {
                    int_crc = int_crc ^ intSend[i];
                    for (int j = 0; j < 8; j++)
                    {
                        int_lsb = int_crc & 0x0001;
                        int_crc = int_crc >> 1;
                        int_crc = int_crc & 0x7FFFF;
                        if (int_lsb == 1)
                            int_crc = int_crc ^ 0xA001;
                    }
                }
                int_crc_byte_a = int_crc & 0x00FF;
                int_crc_byte_b = (int_crc >> 8) & 0x00FF;

                byte[] byteSend = new byte[11];
                byte byteTransfer;
                for (int i = 0; i <= intSend.Length - 2; i++)
                {
                    byteSend[i] = (byte)intSend[i];
                }

                byteTransfer = (byte)int_crc_byte_a;
                byteSend[intSend.Length - 2] = byteTransfer;

                byteTransfer = (byte)int_crc_byte_b;
                byteSend[intSend.Length - 1] = byteTransfer;
                serialPort1.Write(byteSend, 0, byteSend.Length);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error Setting CH2 Power");
                Console.WriteLine(err.ToString());
            }
        } 
        #endregion

        //This is the region where the timer actions are monitored and executed
        #region Timers
        //This is the timer that keeps ticking every 1 second when program is ran to constantly read the temperature
        private void timer_general_Tick(object sender, EventArgs e)
        {
            double n;
            try
            {               
                if(Double.TryParse(getTempChannel(1), out n)){
                    switch (ch1TempSetting)
                    {
                        case 0: textBox_actualTemp1.Text = "" + string.Format("{0:0.00}", n); break;
                        case 1: textBox_actualTemp1.Text = "" + string.Format("{0:0.00}", n * 9.0 / 5.0 + 32); break;
                    }
                }
                if(Double.TryParse(getTempChannel(2), out n))
                {
                    switch (ch2TempSetting)
                    {
                        case 0: textBox_actualTemp2.Text = "" + string.Format("{0:0.00}",n); break;
                        case 1: textBox_actualTemp2.Text = "" + string.Format("{0:0.00}", n * 9.0 / 5.0 + 32); break;
                    }
                }
            }
            catch (TimeoutException err)
            {
                Console.WriteLine("timer: " + err.ToString());
                timer_general.Stop();
                timer_graph1.Stop();
                timer_graph2.Stop();
                serialPort1.Close();
                label_connectionStatus.BackColor = Color.Salmon;
                label_connectionStatus.Text = "No Connection";
                FreshStart();
            }
        }
        //This is the timer that ticks to update graph 1 and write files
        private void timer_graph1_Tick(object sender, EventArgs e)
        {
            double val = getTemp(1);
            if (val > rampSetMax + 50 || val < rampSetMin - 50)
            {
                test1.CancelAsync();
            }
            else
            {
                chart_ch1.Series["Temp CH1"].Points.AddY(val);
                readHistory.Add(val);
                if (nameSaved && !testAllRunning)
                {
                    using (StreamWriter file = new StreamWriter(fileName, true))
                    {
                        file.WriteLine("");
                        file.Close();
                    }
                }
            }
        }
        //This is the timer that ticks to update graph 2 and write files, if both test is ran, this also writes for both as well
        private void timer_graph2_Tick(object sender, EventArgs e)
        {
            double val = getTemp(2);
            if (val > rampSetMax2 + 50 || val < rampSetMin2 - 50)
            {
                test2.CancelAsync();
            }
            else
            {
                if (test2Running)
                {
                    chart_ch2.Series["Temp CH2"].Points.AddY(val);
                    readHistory2.Add(val);
                }
                if (nameSaved)
                {
                    if (testAllRunning)
                    {
                        if(test1Running && test2Running)
                        {
                            double val2 = getTemp(1);
                            using (StreamWriter file2 = new StreamWriter(fileName2, true))
                            {
                                file2.WriteLine("");
                                file2.Close();
                            }
                        }else if (test1Running)
                        {
                            double val2 = getTemp(1);
                            using (StreamWriter file2 = new StreamWriter(fileName2, true))
                            {
                                file2.WriteLine("");
                                file2.Close();
                            }
                        }else if (test2Running)
                        {
                            using (StreamWriter file2 = new StreamWriter(fileName2, true))
                            {
                                file2.WriteLine("");
                                file2.Close();
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter file2 = new StreamWriter(fileName2, true))
                        {
                            file2.WriteLine("");
                            file2.Close();
                        }
                    }
                }
            }
        }
        #endregion

        //This is the region that contains all the functions involving file naming
        #region file naming
        //Whenever a text changes in the textbox, this triggers and selects the next textbox
        private void textBoxFocus1(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.TextLength == 0)
            {
                txt.Text = " ";
                this.GetNextControl((Control)sender, false).Focus();
                txt.SelectionStart = 0;
                txt.SelectionLength = 1;
            } else
            if (txt.TextLength == txt.MaxLength)
            {
                this.GetNextControl((Control)sender,true).Focus();
                txt.SelectionStart = 0;
                txt.SelectionLength = 1;
            }
        }
        //Whenever a naming textbox is clicked, highlight the whole thing for convienence
        private void textBoxFocus(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectionStart = 0;
            txt.SelectionLength = 1;
        }
        //given a string, this updates the file name by changing string itself
        private void updateFileName(ref string f)
        {
         
        }
        //This clears the name box and replaces all the words with a blank space
        private void clearNameBox()
        {
            foreach(TextBox t in name)
            {
                t.Text = " ";
            }
        }
        //This enables/disables name box for typing depending on the boolean b
        private void enableNameBox(Boolean b)
        {
            foreach (TextBox t in name)
            {
                t.Enabled = b;
            }
        }
        //This checks the name box for validity, highlights components red if it is invalid
        private Boolean checkNameBox()
        {
            Boolean flag = true;
            double a;
            for(int i = 0; i < name.Count; i++)
            {
                if (i == 11)
                {
                    if (name[i].Text != " ")
                    {
                        textBox_part12.BackColor = Color.LightGreen;
                    }else
                    {
                        flag = false;
                        textBox_part12.BackColor = Color.LightSalmon;
                    }
                }
                else
                {
                    if (double.TryParse(name[i].Text, out a))
                    {
                        name[i].BackColor = Color.LightGreen;
                    }
                    else
                    {
                        flag = false;
                        name[i].BackColor = Color.LightSalmon;
                    }
                }
            }
            return flag;
        }
        #endregion

        //This is the region that contains some bite sized function that helps with the overall program
        #region Helper Methods
        //Given a list of values, this method returns the standard deviation       
        private double calculateSTDV(List<double> values)
        {
            double ret = 1;
            if (values.Count() < 10)
            {
                return 1;
            }
            else
            {
                double avg = values.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
        //This takes in the temperature and the tempsetting number and returns the temperature in celcius
        private double toCelcius(double x, int s)
        {
            if (s == 0)
                return x;
            return (x - 32) * 5.0 / 9.0;
        }
        //This switches the time labels after user changes the setting
        private void switchTime()
        {
            string s = "Sec";
            switch (ch1TimeSetting)
            {
                case 0: s = "Sec"; break;
                case 1: s = "Min"; break;
                case 2: s = "Hour"; break;
            }
            label_time1.Text = s;
            label_time3.Text = s;
            label_time4.Text = s;
            label_time6.Text = s;
            label_time7.Text = s;
            label_time9.Text = s;
            label_time10.Text = s;
            label_time12.Text = s;
        }
        //This switches the temperature labels after the user changes the setting
        private void switchTemp()
        {
            string t = "";
            switch (ch1TempSetting)
            {
                case 0: t = "CH1 Temp (C)"; break;
                case 1: t = "CH1 Temp (F)"; break;
            }
            label_actualTemp1.Text = t;
            switch (ch1TempSetting)
            {
                case 0: t = "CH2 Temp (C)"; break;
                case 1: t = "CH2 Temp (F)"; break;
            }
            label_actualTemp2.Text = t;
        }
        //Since the box only takes in celcius, this is done to convert the users desire unit to celcius and seconds.
        private void convertUnits()
        {
            switch (ch1TimeSetting)
            {
                case 0:
                    startHoldTimeC = startHoldTime;
                    peakHoldTimeC = peakHoldTime;
                    rampUpTimeC = rampUpTime;
                    rampDownTimeC = rampUpTime;
                    startHoldTime2C = startHoldTime2;
                    peakHoldTime2C = peakHoldTime2;
                    rampUpTime2C = rampUpTime2;
                    rampDownTime2C = rampUpTime2;
                    break;
                case 1:
                    startHoldTimeC = startHoldTime * 60.0;
                    peakHoldTimeC = peakHoldTime * 60.0;
                    rampUpTimeC = rampUpTime * 60.0;
                    rampDownTimeC = rampUpTime * 60.0;
                    startHoldTime2C = startHoldTime2 * 60.0;
                    peakHoldTime2C = peakHoldTime2 * 60.0;
                    rampUpTime2C = rampUpTime2 * 60.0;
                    rampDownTime2C = rampUpTime2 * 60.0;
                    break;
                case 2:
                    startHoldTimeC = startHoldTime * 60.0 * 60.0;
                    peakHoldTimeC = peakHoldTime * 60.0 * 60.0;
                    rampUpTimeC = rampUpTime * 60.0 * 60.0;
                    rampDownTimeC = rampUpTime * 60.0 * 60.0;
                    startHoldTime2C = startHoldTime2 * 60.0 * 60.0;
                    peakHoldTime2C = peakHoldTime2 * 60.0 * 60.0;
                    rampUpTime2C = rampUpTime2 * 60.0 * 60.0;
                    rampDownTime2C = rampUpTime2 * 60.0 * 60.0;
                    break;
            }
            switch (ch1TempSetting)
            {
                case 0:
                    rampSetMinC = rampSetMin;
                    rampSetMaxC = rampSetMax;
                    rampUpMinC = rampUpMin;
                    rampUpMaxC = rampUpMax;
                    rampDownMinC = rampDownMin;
                    rampDownMaxC = rampDownMax;
                    rampSetMin2C = rampSetMin2;
                    rampSetMax2C = rampSetMax2;
                    rampUpMin2C = rampUpMin2;
                    rampUpMax2C = rampUpMax2;
                    rampDownMin2C = rampDownMin2;
                    rampDownMax2C = rampDownMax2;
                    chart_ch1.ChartAreas[0].Axes[1].Title = ("Temp (C)");
                    chart_ch2.ChartAreas[0].Axes[1].Title = ("Temp (C)");
                    break;
                case 1:
                    rampSetMinC = (rampSetMin - 32) * 5.0 / 9.0;
                    rampSetMaxC = (rampSetMax - 32) * 5.0 / 9.0;
                    rampUpMinC = (rampUpMin - 32) * 5.0 / 9.0;
                    rampUpMaxC = (rampUpMax - 32) * 5.0 / 9.0;
                    rampDownMinC = (rampDownMin - 32) * 5.0 / 9.0;
                    rampDownMaxC = (rampDownMax - 32) * 5.0 / 9.0;
                    rampSetMin2C = (rampSetMin2 - 32) * 5.0 / 9.0;
                    rampSetMax2C = (rampSetMax2 - 32) * 5.0 / 9.0;
                    rampUpMin2C = (rampUpMin2 - 32) * 5.0 / 9.0;
                    rampUpMax2C = (rampUpMax2 - 32) * 5.0 / 9.0;
                    rampDownMin2C = (rampDownMin2 - 32) * 5.0 / 9.0;
                    rampDownMax2C = (rampDownMax2 - 32) * 5.0 / 9.0;
                    chart_ch1.ChartAreas[0].Axes[1].Title = ("Temp (F)");
                    chart_ch2.ChartAreas[0].Axes[1].Title = ("Temp (F)");
                    break;
            }
        }
        //This clears test status on channel 1 or 2 based on int i
        private void clearTestStatus(int i)
        {
            switch (i)
            {
                case 1:
                    testStatus1.Text = "";
                    testStatus2.Text = "";
                    testStatus3.Text = "";
                    testStatus4.Text = "";
                    testStatus5.Text = "";
                    testStatus6.Text = "";
                    testStatus7.Text = "";
                    testStatus1.BackColor = Color.White;
                    testStatus2.BackColor = Color.White;
                    testStatus3.BackColor = Color.White;
                    testStatus4.BackColor = Color.White;
                    testStatus5.BackColor = Color.White;
                    testStatus6.BackColor = Color.White;
                    testStatus7.BackColor = Color.White;
                    break;
                case 2:
                    test2Status1.Text = "";
                    test2Status2.Text = "";
                    test2Status3.Text = "";
                    test2Status4.Text = "";
                    test2Status5.Text = "";
                    test2Status6.Text = "";
                    test2Status7.Text = "";
                    test2Status1.BackColor = Color.White;
                    test2Status2.BackColor = Color.White;
                    test2Status3.BackColor = Color.White;
                    test2Status4.BackColor = Color.White;
                    test2Status5.BackColor = Color.White;
                    test2Status6.BackColor = Color.White;
                    test2Status7.BackColor = Color.White;
                    break;
            }
        }
        #endregion
    }
}
