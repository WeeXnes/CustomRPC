using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading;
using DiscordRPC;
using DiscordRPC.Logging;
using Nocksoft.IO.ConfigFiles;
using System.IO;

namespace CustomRPC
{
    public partial class Form1 : MaterialForm
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CustomRPC");
        INIFile iniFile = new INIFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CustomRPC") + "\\settings.ini");
        public Form1()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
            this.notifyIcon1.MouseClick += new MouseEventHandler(this.notifyIcon_MouseClick);
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Purple400, Primary.Purple500,
                Primary.Purple700, Accent.Purple200,
                TextShade.BLACK
            );
            Config();
        }
        public DiscordRpcClient client2;
        bool runningOrNah2 = false;
        bool initalized2 = false;
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void Config()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + "\\settings.ini"))
            {
                using (StreamWriter sw = File.CreateText(path + "\\settings.ini"))
                {
                    sw.WriteLine("[Settings]");
                    sw.WriteLine("line1=1");
                    sw.WriteLine("line2=1");
                    sw.WriteLine("line3=1");
                    sw.WriteLine("line4=1");
                    sw.WriteLine("line5=1");
                    sw.WriteLine("line6=1");
                    sw.WriteLine("[RPC]");
                    sw.WriteLine("line0=");
                    sw.WriteLine("line1=");
                    sw.WriteLine("line2=");
                    sw.WriteLine("line3=");
                    sw.WriteLine("line4=");
                    sw.WriteLine("line5=");
                    sw.WriteLine("line6=");
                }
            }
            if (iniFile.GetValue("Settings", "line1") == "1")
            {
                materialSingleLineTextField2.Enabled = true;
                materialCheckBox1.Checked = true;
            }
            else
            {
                materialSingleLineTextField2.Enabled = false;
                materialCheckBox1.Checked = false;
            }
            if (iniFile.GetValue("Settings", "line2") == "1")
            {
                materialSingleLineTextField3.Enabled = true;
                materialCheckBox2.Checked = true;
            }
            else
            {
                materialSingleLineTextField3.Enabled = false;
                materialCheckBox2.Checked = false;
            }
            if (iniFile.GetValue("Settings", "line3") == "1")
            {
                materialSingleLineTextField4.Enabled = true;
                materialCheckBox3.Checked = true;
            }
            else
            {
                materialSingleLineTextField4.Enabled = false;
                materialCheckBox3.Checked = false;
            }
            if (iniFile.GetValue("Settings", "line4") == "1")
            {
                materialSingleLineTextField5.Enabled = true;
                materialCheckBox4.Checked = true;
            }
            else
            {
                materialSingleLineTextField5.Enabled = false;
                materialCheckBox4.Checked = false;
            }
            if (iniFile.GetValue("Settings", "line5") == "1")
            {
                materialSingleLineTextField6.Enabled = true;
                materialCheckBox5.Checked = true;
            }
            else
            {
                materialSingleLineTextField6.Enabled = false;
                materialCheckBox5.Checked = false;
            }
            if (iniFile.GetValue("Settings", "line6") == "1")
            {
                materialSingleLineTextField7.Enabled = true;
                materialCheckBox6.Checked = true;
            }
            else
            {
                materialSingleLineTextField7.Enabled = false;
                materialCheckBox6.Checked = false;
            }
            materialSingleLineTextField1.Text = iniFile.GetValue("RPC", "line0");
            materialSingleLineTextField2.Text = iniFile.GetValue("RPC", "line1");
            materialSingleLineTextField3.Text = iniFile.GetValue("RPC", "line2");
            materialSingleLineTextField4.Text = iniFile.GetValue("RPC", "line3");
            materialSingleLineTextField5.Text = iniFile.GetValue("RPC", "line4");
            materialSingleLineTextField6.Text = iniFile.GetValue("RPC", "line5");
            materialSingleLineTextField7.Text = iniFile.GetValue("RPC", "line6");
        }




        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();

                notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;

            notifyIcon1.Visible = false;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            iniFile.SetValue("RPC", "line0", materialSingleLineTextField1.Text);
            iniFile.SetValue("RPC", "line1", materialSingleLineTextField2.Text);
            iniFile.SetValue("RPC", "line2", materialSingleLineTextField3.Text);
            iniFile.SetValue("RPC", "line3", materialSingleLineTextField4.Text);
            iniFile.SetValue("RPC", "line4", materialSingleLineTextField5.Text);
            iniFile.SetValue("RPC", "line5", materialSingleLineTextField6.Text);
            iniFile.SetValue("RPC", "line6", materialSingleLineTextField7.Text);
            string CacheDetails = "";
            string CacheState = "";
            string CacheLargeImageKey = "";
            string CacheLargeImageText = "";
            string CacheSmallImageKey = "";
            string CacheSmallImageText = "";
            if(materialCheckBox1.Checked == true)
            {
                CacheDetails = materialSingleLineTextField2.Text;
            }
            if (materialCheckBox2.Checked == true)
            {
                CacheState = materialSingleLineTextField3.Text;
            }
            if (materialCheckBox3.Checked == true)
            {
                CacheLargeImageKey = materialSingleLineTextField4.Text;
            }
            if (materialCheckBox4.Checked == true)
            {
                CacheLargeImageText = materialSingleLineTextField5.Text;
            }
            if (materialCheckBox5.Checked == true)
            {
                CacheSmallImageKey = materialSingleLineTextField6.Text;
            }
            if (materialCheckBox6.Checked == true)
            {
                CacheSmallImageText = materialSingleLineTextField6.Text;
            }
            if (initalized2 == false)
            {
                initalized2 = true;
                client2 = new DiscordRpcClient(materialSingleLineTextField1.Text);
                client2.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
                client2.Initialize();
                client2.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = CacheDetails,
                    State = CacheState,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = CacheLargeImageKey,
                        LargeImageText = CacheLargeImageText,
                        SmallImageKey = CacheSmallImageKey,
                        SmallImageText = CacheSmallImageText
                    }
                });
            }
            else
            {
                client2.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = CacheDetails,
                    State = CacheState,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = CacheLargeImageKey,
                        LargeImageText = CacheLargeImageText,
                        SmallImageKey = CacheSmallImageKey,
                        SmallImageText = CacheSmallImageText
                    }
                });
            }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            iniFile.SetValue("RPC", "line0", materialSingleLineTextField1.Text);
            iniFile.SetValue("RPC", "line1", materialSingleLineTextField2.Text);
            iniFile.SetValue("RPC", "line2", materialSingleLineTextField3.Text);
            iniFile.SetValue("RPC", "line3", materialSingleLineTextField4.Text);
            iniFile.SetValue("RPC", "line4", materialSingleLineTextField5.Text);
            iniFile.SetValue("RPC", "line5", materialSingleLineTextField6.Text);
            iniFile.SetValue("RPC", "line6", materialSingleLineTextField7.Text);
            string CacheDetails = "";
            string CacheState = "";
            string CacheLargeImageKey = "";
            string CacheLargeImageText = "";
            string CacheSmallImageKey = "";
            string CacheSmallImageText = "";
            if (materialCheckBox1.Checked == true)
            {
                CacheDetails = materialSingleLineTextField2.Text;
            }
            if (materialCheckBox2.Checked == true)
            {
                CacheState = materialSingleLineTextField3.Text;
            }
            if (materialCheckBox3.Checked == true)
            {
                CacheLargeImageKey = materialSingleLineTextField4.Text;
            }
            if (materialCheckBox4.Checked == true)
            {
                CacheLargeImageText = materialSingleLineTextField5.Text;
            }
            if (materialCheckBox5.Checked == true)
            {
                CacheSmallImageKey = materialSingleLineTextField6.Text;
            }
            if (materialCheckBox6.Checked == true)
            {
                CacheSmallImageText = materialSingleLineTextField6.Text;
            }
            client2.SetPresence(new DiscordRPC.RichPresence()
            {
                Details = CacheDetails,
                State = CacheState,
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = CacheLargeImageKey,
                    LargeImageText = CacheLargeImageText,
                    SmallImageKey = CacheSmallImageKey,
                    SmallImageText = CacheSmallImageText
                }
            });
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Deinitialize();
        }
        void Deinitialize()
        {
            if(client2 != null)
            {
                client2.Dispose();
            }
            
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(materialCheckBox1.Checked == true)
            {
                materialSingleLineTextField2.Enabled = true;
                iniFile.SetValue("Settings", "line1", "1");
            }
            else
            {
                materialSingleLineTextField2.Enabled = false;
                iniFile.SetValue("Settings", "line1", "0");
            }
        }

        private void materialCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox2.Checked == true)
            {
                materialSingleLineTextField3.Enabled = true;
                iniFile.SetValue("Settings", "line2", "1");
            }
            else
            {
                materialSingleLineTextField3.Enabled = false;
                iniFile.SetValue("Settings", "line2", "0");
            }
        }

        private void materialCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox3.Checked == true)
            {
                materialSingleLineTextField4.Enabled = true;
                iniFile.SetValue("Settings", "line3", "1");
            }
            else
            {
                materialSingleLineTextField4.Enabled = false;
                iniFile.SetValue("Settings", "line3", "0");
            }
        }

        private void materialCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox4.Checked == true)
            {
                materialSingleLineTextField5.Enabled = true;
                iniFile.SetValue("Settings", "line4", "1");
            }
            else
            {
                materialSingleLineTextField5.Enabled = false;
                iniFile.SetValue("Settings", "line4", "0");
            }
        }

        private void materialCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox5.Checked == true)
            {
                materialSingleLineTextField6.Enabled = true;
                iniFile.SetValue("Settings", "line5", "1");
            }
            else
            {
                materialSingleLineTextField6.Enabled = false;
                iniFile.SetValue("Settings", "line5", "0");
            }
        }

        private void materialCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox6.Checked == true)
            {
                materialSingleLineTextField7.Enabled = true;
                iniFile.SetValue("Settings", "line6", "1");
            }
            else
            {
                materialSingleLineTextField7.Enabled = false;
                iniFile.SetValue("Settings", "line6", "0");
            }
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }
    }
}
