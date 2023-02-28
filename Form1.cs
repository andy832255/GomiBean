using BeanfunLogin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.ModifyRegistry;

namespace GomiBean
{
    public partial class Form1 : Form
    {
        enum LoginMethod : int
        {
            Regular = 0,
            QRCode = 1
        };

        private AccountManager accountManager = null;

        public BeanfunClient bfClient;

        public BeanfunClient.QRCodeClass qrcodeClass;

        private string service_code = "600309", service_region = "A2", service_name = "新瑪奇mabinogi";

        public List<GameService> gameList = new List<GameService>();

        private GamePathDB gamePaths = new GamePathDB();
        private string otp;

        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine("init start");
            init();
            Debug.WriteLine("init end");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(passwdInput.Text)) { lblMessage.Text = "請輸入密碼"; return; }
                Sleep.SleepTime = 0;
                Login();
                GetSleepLbl();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnGamestart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(passwdInput.Text)) { lblMessage.Text = "請輸入密碼"; return; }
                Sleep.SleepTime = 0;
                GameStart();
                GetSleepLbl();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnOneClick_Click(object sender, EventArgs e)
        {
            try
            {
                //讀取
                if (accounts.SelectedIndex != -1)
                {
                    string account = accounts.SelectedItem.ToString();
                    string passwd = accountManager.getPasswordByAccount(account);
                    int method = accountManager.getMethodByAccount(account);

                    if (passwd == null || method == -1) { lblMessage.Text = "帳號記錄讀取失敗。"; }
                    accountInput.Text = account;
                    passwdInput.Text = passwd;
                }

                Sleep.SleepTime = 0;
                //登入
                Login();
                GameStart();
                GetSleepLbl();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void GetSleepLbl()
        {
            lblTime.Text = Sleep.SleepTime.ToString();
        }

        #region Login
        private void Login()
        {
            Debug.WriteLine("Login");

            this.UseWaitCursor = true;

            this.loginButton.Text = "請稍後...";

            try
            {
                this.bfClient = new BeanfunClient();
                this.bfClient.Login(this.accountInput.Text, this.passwdInput.Text, this.qrcodeClass, this.service_code, this.service_region);
                if (this.bfClient.errmsg != null)
                {
                    Debug.Write(this.bfClient.errmsg); lblMessage.Text = "登入失敗 : \n" + this.bfClient.errmsg;
                    this.loginButton.Text = "重新登入";
                    this.UseWaitCursor = false;
                    return;
                }
                else
                {
                    // Login completed.
                    this.bfClient.GetAccounts(service_code, service_region);
                    this.loginButton.Text = "重新登入";
                    this.UseWaitCursor = false;
                    lblMessage.Text = accountInput.Text + "\n登入成功";
                }

            }
            catch (Exception ex)
            {
                Debug.Write("登入失敗，未知的錯誤。\n\n" + ex.Message + "\n" + ex.StackTrace);
                lblMessage.Text = "登入失敗，未知的錯誤。\n\n" + ex.Message + "\n" + ex.StackTrace;
            }
        }
        #endregion

        #region GameStart
        private void GameStart()
        {
            Debug.WriteLine("GameStart");
            lblMessage.Text = accountInput.Text + "\n啟動中。。。";

            // The get OTP button.
            if (Properties.Settings.Default.autoSelect == true)
            {
                Properties.Settings.Default.Save();
            }

            //this.getOtpWorker.RunWorkerAsync(listView1.SelectedItems[0].Index);

            // getOTP do work.
            Debug.WriteLine("getOtpWorker start");


            Debug.WriteLine("call GetOTP");
            this.otp = this.bfClient.GetOTP(this.bfClient.accountList[0], this.service_code, this.service_region);
            Debug.WriteLine("call GetOTP done");
            if (this.otp == null)
            {
                //e.Result = -1;
                Debug.Write("otp == null");
                return;
            }

            string procPath = gamePaths.Get(service_name);
            procPath = procPath.ToLower(); //Mabinogi.exe
            string sacc = this.bfClient.accountList[0].sacc;
            string otp = new string(this.otp.Where(c => char.IsLetter(c) || char.IsDigit(c)).ToArray());

            if (!File.Exists(procPath)) { MessageBox.Show("請設定遊戲路徑!"); return; }

            Debug.WriteLine("invalid path:" + procPath);

            if (procPath.Contains("elsword.exe"))
            {
                processStart(procPath, sacc + " " + otp + " TW");
            }
            else if (procPath.Contains("KartRider.exe"))
            {
                processStart(procPath, "-id:" + sacc + " -password:" + otp + " -region:1");
            }
            else if (procPath.Contains("MapleStory.exe"))
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName == "MapleStory")
                    {
                        Debug.WriteLine("find game");
                        return;
                    }
                }
                processStart(procPath, "tw.login.maplestory.gamania.com 8484 BeanFun " + sacc + " " + otp);
            }
            else // fallback to default strategy
            {
                processStart(procPath, "/N:" + sacc + " /V:" + otp + " /T:gamania");
            }
            lblMessage.Text = accountInput.Text + "\n啟動遊戲成功";
            return;
        }
        #endregion

        #region init
        public bool init()
        {
            try
            {
                //this.Text = $"BeanfunLogin - v{ currentVersion.Major }.{ currentVersion.Minor }.{ currentVersion.Build } ({ currentVersion.Revision })";
                this.AcceptButton = this.loginButton;
                this.bfClient = null;
                this.accountManager = new AccountManager();

                bool res = accountManager.init();
                if (res == false)
                    Debug.Write("帳號記錄初始化失敗，未知的錯誤。");

                refreshAccountList();
                // Handle settings.
                if (Properties.Settings.Default.rememberAccount == true)
                    this.accountInput.Text = Properties.Settings.Default.AccountID;
                if (Properties.Settings.Default.rememberPwd == true)
                {
                    //this.rememberAccount.Enabled = false;
                    // Load password.
                    if (File.Exists("UserState.dat"))
                    {
                        try
                        {
                            Byte[] cipher = File.ReadAllBytes("UserState.dat");
                            string entropy = Properties.Settings.Default.entropy;
                            byte[] plaintext = ProtectedData.Unprotect(cipher, Encoding.UTF8.GetBytes(entropy), DataProtectionScope.CurrentUser);
                            this.passwdInput.Text = System.Text.Encoding.UTF8.GetString(plaintext);
                        }
                        catch
                        {
                            File.Delete("UserState.dat");
                        }
                    }
                }

                if (gamePaths.Get("新楓之谷") == "")
                {
                    ModifyRegistry myRegistry = new ModifyRegistry();
                    myRegistry.BaseRegistryKey = Registry.CurrentUser;
                    myRegistry.SubKey = "Software\\Gamania\\MapleStory";
                    if (myRegistry.Read("Path") != "")
                    {
                        gamePaths.Set("新楓之谷", myRegistry.Read("Path"));
                        gamePaths.Save();
                    }
                }

                if (this.accountInput.Text == "")
                    this.ActiveControl = this.accountInput;
                else if (this.passwdInput.Text == "")
                    this.ActiveControl = this.passwdInput;

                return true;
            }
            catch (Exception e)
            {
                Debug.Write("初始化失敗，未知的錯誤。" + e.Message);
                lblMessage.Text = "初始化失敗，未知的錯誤。\n" + e.Message;
                return false;
            }
        }
        #endregion

        private void refreshAccountList()
        {
            string[] accArray = accountManager.getAccountList();
            accounts.Items.Clear();
            accounts.Items.AddRange(accArray);
        }

        // Building ciphertext by 3DES.
        private byte[] ciphertext(string plaintext, string key)
        {
            byte[] plainByte = Encoding.UTF8.GetBytes(plaintext);
            byte[] entropy = Encoding.UTF8.GetBytes(key);
            return ProtectedData.Protect(plainByte, entropy, DataProtectionScope.CurrentUser);
        }

        private void import_Click(object sender, EventArgs e)
        {
            // Only Regular login is working, QRCode doesn't need to keep account or password.
            bool res = accountManager.addAccount(accountInput.Text, passwdInput.Text, (int)LoginMethod.Regular);
            if (res == false)
                lblMessage.Text = "帳號記錄新增失敗";
            refreshAccountList();
        }
        /// <summary>
        ///  Read account from account manager and fill in to account/password input box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void export_Click(object sender, EventArgs e)
        {
            if (accounts.SelectedIndex != -1)
            {
                string account = accounts.SelectedItem.ToString();
                string passwd = accountManager.getPasswordByAccount(account);
                int method = accountManager.getMethodByAccount(account);

                if (passwd == null || method == -1)
                {
                    lblMessage.Text = "帳號記錄讀取失敗。";
                }

                accountInput.Text = account;
                passwdInput.Text = passwd;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(accounts);
            selectedItems = accounts.SelectedItems;

            if (accounts.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    accountManager.removeAccount(accounts.GetItemText(selectedItems[i]));
                    refreshAccountList();
                }
            }
        }


        private void processStart(string prog, string arg)
        {
            try
            {
                Debug.WriteLine("try open game");
                ProcessStartInfo psInfo = new ProcessStartInfo();
                psInfo.FileName = prog;
                psInfo.Arguments = arg;
                psInfo.WorkingDirectory = Path.GetDirectoryName(prog);
                Process.Start(psInfo);
                Debug.WriteLine("try open game done");
            }
            catch
            {
                Debug.Write("啟動失敗，請嘗試手動以系統管理員身分啟動遊戲。");
            }
        }

        //設定遊戲路徑
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string identName = "新瑪奇mabinogi";
            string binaryName = gamePaths.GetAlias(identName);
            if (binaryName == identName) binaryName = "*.exe";
            openFileDialog.Filter = String.Format("{0} ({1})|{1}|All files (*.*)|*.*", identName, binaryName);
            openFileDialog.Title = "Set Path.";
            openFileDialog.InitialDirectory = gamePaths.Get(identName);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                gamePaths.Set(identName, file);
                gamePaths.Save();
            }
        }

    }
}
