using System;
using System.Drawing;
using System.Windows.Forms;

using NAudio.Wave;
using System.Collections.Generic;
using NAudio.Mixer;
using System.Configuration;

namespace MicVolume
{
    public partial class Form1 : Form
    {
        private Icon icon;
        private List<string> deviceNames = new List<string>();
        private Configuration configManager;
        private KeyValueConfigurationCollection configCollection;
        private int selectedDevice = 0;
        private bool running = true;

        private int lastVolume;
        private int lastSpeed;
        private string lastDevice;


        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.Visible = false;
            

            //Create menu
            MenuItem quitMenuItem = new MenuItem("Quit");
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(quitMenuItem);
            trayIcon.ContextMenu = contextMenu;

            quitMenuItem.Click += QuitMenuItem_Click;

            icon = new Icon("icon.ico");
            trayIcon.Icon = icon;

            //Get devices and fill combobox
            int waveInDevices = WaveIn.DeviceCount;
            for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                deviceNames.Add(deviceInfo.ProductName);
            }

            deviceComboBox.DataSource = deviceNames;

            LoadConfig();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            running = false;
            this.Close();
        }

        
       private void LoadConfig()
       {
            configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configCollection = configManager.AppSettings.Settings;

            if (int.TryParse(configCollection["volume"].Value, out lastVolume))
            {
                lastVolume = Math.Min(Math.Max(0, lastVolume), 100);
            }
            else
            {
                throw new ArgumentException("Config volume must be an integer.");
            }

            if (int.TryParse(configCollection["speed"].Value, out lastSpeed))
            {
                lastSpeed = Math.Min(Math.Max(1, lastSpeed), 10000);
            }
            else
            {
                throw new ArgumentException("Config speed must be an integer.");
            }

            setVolumeTimer.Interval = lastSpeed;
            volumeSlider.Value = lastVolume;
            speedTextBox.Text = lastSpeed.ToString();
            volumeLabel.Text = lastVolume.ToString() + "%";
       }

        private void setVolumeTimer_Tick(object sender, EventArgs e)
        {
            int speed;
            if (int.TryParse(speedTextBox.Text, out speed))
            {
                speed = Math.Min(Math.Max(1, speed), 10000);
                speedTextBox.Text = speed.ToString();
                setVolumeTimer.Interval = speed;
            }

            int volume = volumeSlider.Value;

            string device = deviceComboBox.SelectedItem as string;
            int waveInDeviceNumber = deviceComboBox.SelectedIndex;
            MixerLine mixerLine = new MixerLine((IntPtr)waveInDeviceNumber, 0, MixerFlags.WaveIn);
            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == MixerControlType.Volume)
                {
                    var volumeControl = control as UnsignedMixerControl;
                    volumeControl.Percent = volume;
                    break;
                }
            }

            bool needsSave = false;
            if (lastSpeed != speed || lastVolume != volume)
            {
                needsSave = true;
            }

            lastSpeed = speed;
            lastVolume = volume;
            lastDevice = device;

            if (needsSave)
            {
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
            configCollection["volume"].Value = lastVolume.ToString();
            configCollection["speed"].Value = lastSpeed.ToString();
            configManager.Save();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.BringToFront();
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = running;
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;

            if (!running)
            {
                setVolumeTimer.Dispose();
                trayIcon.Dispose();
            }
        }

        private void volumeSlider_Scroll(object sender, EventArgs e)
        {
            volumeLabel.Text = volumeSlider.Value.ToString() + "%";
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }
    }
}
