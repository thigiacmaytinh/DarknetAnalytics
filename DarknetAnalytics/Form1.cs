using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace DarknetAnalytics
{
    public partial class Form1 : Form
    {
        Stopwatch m_stopwatch = new Stopwatch();
        List<List<DarknetObj>> m_results = new List<List<DarknetObj>>();
        List<DarknetObj> m_currentObjects;
        List<string> m_files = new List<string>();
        List<string> m_classes;
        string m_report = "";
        string m_currentImagePath;
        double mScaleX, mScaleY;
        double mAspect;
        List<Rectangle> m_rects = new List<Rectangle>();
        Size mPictureBoxMaxSize;

        Font myFont = new Font("Arial", 14);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);

        TGMTdarknet darknet;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            TGMTregistry.GetInstance().Init("DarknetAnalytics");
            txtFolder.Text = TGMTregistry.GetInstance().ReadString("folderPath", "");
            cb_classes.Text = TGMTregistry.GetInstance().ReadString("classesPath", "");
            cb_config.Text = TGMTregistry.GetInstance().ReadString("configPath", "");
            cb_weight.Text = TGMTregistry.GetInstance().ReadString("weightPath", "");

            txtMoveFile1.Text = TGMTregistry.GetInstance().ReadString("txtMoveFile1", "");
            txtMoveFile2.Text = TGMTregistry.GetInstance().ReadString("txtMoveFile2", "");

            this.KeyPreview = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = message;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_load_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;

            if (cb_classes.Text == "" || cb_config.Text == "" || cb_weight.Text == "")
            {
                MessageBox.Show("You must fill all input field");
                return;
            }
                
            if(!File.Exists(cb_classes.Text))
            {
                errorProvider1.SetError(cb_classes, "Missing field");
                return;
            }

            if (!File.Exists(cb_config.Text))
            {
                errorProvider1.SetError(cb_config, "Missing field");
                return;
            }

            if (!File.Exists(cb_weight.Text))
            {
                errorProvider1.SetError(cb_weight, "Missing field");
                return;
            }

            timerClear.Start();



            darknet = new TGMTdarknet(cb_classes.Text, cb_config.Text, cb_weight.Text);
            if (darknet.IsLoaded())
            {
                TGMTregistry.GetInstance().SaveValue("classesPath", cb_classes.Text);
                TGMTregistry.GetInstance().SaveValue("configPath", cb_config.Text);
                TGMTregistry.GetInstance().SaveValue("weightPath", cb_weight.Text);


                if (!cb_classes.Items.Contains(cb_classes.Text))
                {
                    cb_classes.Items.Add(cb_classes.Text);
                }
                if (listView1.Items.Count > 0)
                {
                    btnAnalytics.Enabled = true;
                }
            }
            else
            {
                PrintError("Can not load darknet");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            btnExport.Enabled = false;
            btnAnalytics.Enabled = false;
            bgLoadFile.RunWorkerAsync();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.ShowDialog();
            txtFolder.Text = ofd.SelectedPath;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnLoadClasses_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Classes file (*.names) |*.names;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                cb_classes.Text = ofd.FileName;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_loadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Config file (*.cfg) |*.cfg;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
                cb_config.Text = ofd.FileName;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_loadWeight_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Weight file (*.weights) |*.weights;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
                cb_weight.Text = ofd.FileName;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveFileDetected_CheckedChanged(object sender, EventArgs e)
        {
            txtMoveFile1.Enabled = chkMoveFileDetected.Checked;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveFileNotDetect_CheckedChanged(object sender, EventArgs e)
        {
            txtMoveFile2.Enabled = chkMoveFileNotDetect.Checked;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDefault.Checked)
            {
                txt_probability.Text = "1.1";

            }
            txt_probability.Enabled = !chkDefault.Checked;
        }        

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            if (chkMoveFileDetected.Checked)
            {
                if (txtMoveFile1.Text == "")
                {
                    PrintError("Textbox is empty");
                    txtMoveFile1.Focus();
                    return;
                }
                else
                {
                    Directory.CreateDirectory(txtMoveFile1.Text);                    
                }
            }

            if (chkMoveFileNotDetect.Checked)
            {
                if (txtMoveFile2.Text == "")
                {
                    PrintError("Textbox is empty");
                    txtMoveFile2.Focus();
                    return;
                }
                else
                {
                    Directory.CreateDirectory(txtMoveFile2.Text);                    
                }
            }

            if (!bgAnalytics.IsBusy)
            {
                bgAnalytics.RunWorkerAsync();
                btnAnalytics.Text = "Stop";
                txtFolder.Enabled = false;
                cb_classes.Enabled = false;
                cb_config.Enabled = false;
                cb_weight.Enabled = false;
                btnExport.Enabled = false;
                chkDefault.Enabled = false;
                chkMoveFileDetected.Enabled = false;
                chkMoveFileNotDetect.Enabled = false;
                txtMoveFile1.Enabled = false;
                txtMoveFile2.Enabled = false;
            }
            else
            {
                bgAnalytics.CancelAsync();
                btnAnalytics.Text = "Analytics";
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                PrintError("You must analytics before export result");
                return;
            }


            
            for (int i = 0; i < m_results.Count; i++)
            {
                List<DarknetObj> objects = m_results[i];

                Bitmap bmp = new Bitmap(listView1.Items[i].Text);
                double bmpW = bmp.Width;
                double bmpH = bmp.Height;



                string[] lines = new string[objects.Count];
                for(int j=0; j<objects.Count; j++)
                {
                    DarknetObj obj = objects[j];
                    Rectangle r = obj.rect;

                    double w = r.Width / bmpW;
                    double h = r.Height / bmpH;
                    double x = r.X / bmpW + w / 2;
                    double y = r.Y / bmpH + h / 2;

                    lines[j] = String.Format("{0} {1} {2} {3} {4}", obj.classID, x, y, w, h);
                }

                string filePath = listView1.Items[i].SubItems[0].Text;
                filePath = filePath.Replace(Path.GetExtension(filePath), ".txt");
                File.WriteAllLines(filePath, lines);
            }

            
            MessageBox.Show("Write all files success");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgAnalytics_DoWork(object sender, DoWorkEventArgs e)
        {
            m_stopwatch.Restart();
            m_results.Clear();
            m_report = "File path, Num rect\n";
            lblTotal.Text = "";

            string dir1 = "";
            if (chkMoveFileDetected.Checked)
                dir1 = TGMTfile.CorrectPath(txtMoveFile1.Text);
            string dir2 = "";
            if (chkMoveFileNotDetect.Checked)
                dir2 = TGMTfile.CorrectPath(txtMoveFile2.Text);

            int count = 0;


            Stopwatch watch = new Stopwatch();
            float probability = (float)Convert.ToDouble(txt_probability.Text);

            string text = "";
            string strCount = "";

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                watch.Restart();
                if (bgAnalytics.CancellationPending)
                {
                    e.Result = count;
                    return;
                }

                m_report += Path.GetFileName(listView1.Items[i].Text);

                string fileName = listView1.Items[i].Text;
                List<DarknetObj> objects = darknet.Detect(fileName, probability);

                listView1.EnsureVisible(i);

                if (objects.Count > 0)
                {
                    count += objects.Count;
                    if (chkMoveFileDetected.Checked)
                    {
                        string newPath = dir1 + Path.GetFileName(listView1.Items[i].Text);
                        TGMTfile.MoveFileAsync(listView1.Items[i].Text, newPath);
                        listView1.Items[i].Text = newPath;
                    }

                    text = "Found";
                    strCount = objects.Count.ToString();
                    listView1.Items[i].ForeColor = Color.Blue;

                    string line = objects.Count.ToString();
                    m_report += "," + line;
                    //for (int j = 0; j < objects.Count; j++)
                    //{
                    //    DarknetObj obj = objects[j];                        
                    //    line += "," + obj.rect.X.ToString() + "," + obj.rect.Y.ToString() + "," + obj.rect.Width.ToString() + "," + obj.rect.Height.ToString();
                    //}
                    m_results.Add(objects);
                }
                else
                {
                    if (chkMoveFileNotDetect.Checked)
                    {
                        string newPath = dir2 + Path.GetFileName(listView1.Items[i].Text);
                        TGMTfile.MoveFileAsync(listView1.Items[i].Text, newPath);
                        listView1.Items[i].Text = newPath;
                    }
                    text = "Not found";
                    strCount = "0";
                    listView1.Items[i].ForeColor = Color.Red;


                    m_results.Add(new List<DarknetObj>());
                }

                if (listView1.Items[i].SubItems.Count == 1)
                {
                    listView1.Items[i].SubItems.Add(text);
                    listView1.Items[i].SubItems.Add(strCount);
                    listView1.Items[i].SubItems.Add(watch.ElapsedMilliseconds.ToString());
                }
                else
                {
                    listView1.Items[i].SubItems[1].Text = text;
                    listView1.Items[i].SubItems[2].Text = strCount;
                    listView1.Items[i].SubItems[3].Text = watch.ElapsedMilliseconds.ToString();
                }

                watch.Stop();
                m_report += "\n";

                ((BackgroundWorker)sender).ReportProgress((int)(i * 100 / listView1.Items.Count));
            }
        

            e.Result = count;
        }

        private void bgAnalytics_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Minimum;
            m_stopwatch.Stop();
            PrintMessage("Detected " + e.Result + " objects on " + listView1.Items.Count + " images (" + m_stopwatch.ElapsedMilliseconds + " ms)");
            lblTotal.Text = "Total: " + e.Result;

            //export csv
            m_report += "Elapsed (ms): " + m_stopwatch.ElapsedMilliseconds;
            File.WriteAllText(TGMTfile.CorrectPath(txtFolder.Text) + "_" + Path.GetFileNameWithoutExtension(cb_classes.Text) + ".csv", m_report);



            btnExport.Enabled = true;
            btnAnalytics.Text = "Analytics";
            txtFolder.Enabled = true;
            cb_classes.Enabled = true;
            cb_config.Enabled = true;
            cb_weight.Enabled = true;
            chkMoveFileDetected.Enabled = true;
            chkMoveFileNotDetect.Enabled = true;
            chkDefault.Enabled = true;
            txtMoveFile1.Enabled = chkMoveFileDetected.Checked;
            txtMoveFile2.Enabled = chkMoveFileNotDetect.Checked;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            PrintMessage("Loading files...");

            if (txtFolder.Text == "" || !Directory.Exists(txtFolder.Text))
                return;

            m_files.Clear();
            foreach(string filePath in Directory.GetFiles(txtFolder.Text, "*.jpg", SearchOption.TopDirectoryOnly))
        
    {
                m_files.Add(filePath);
            }
            foreach(string filePath in Directory.GetFiles(txtFolder.Text, "*.png", SearchOption.TopDirectoryOnly))
        
    {
                m_files.Add(filePath);
            }
            foreach(string filePath in Directory.GetFiles(txtFolder.Text, "*.bmp", SearchOption.TopDirectoryOnly))
        
    {
                m_files.Add(filePath);
            }


            TGMTregistry.GetInstance().SaveValue("folderPath", txtFolder.Text);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 0; i < m_files.Count; i++)
                listView1.Items.Add(new ListViewItem(m_files[i]));

            PrintMessage("Loaded " + listView1.Items.Count + " images");
            if (listView1.Items.Count > 0)
            {
                btnBrowseDir.Enabled = true;
                if (darknet != null && darknet.IsLoaded())
                {
                    btnAnalytics.Enabled = true;
                }
            }

            m_files.Clear();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            TGMTutil.OnlyInputNumber(sender, e);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtNeighbors_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            if (mAspect > 1)
            {
                pictureBox1.Height = (int)(pictureBox1.Width / mAspect);
                if (pictureBox1.Height > mPictureBoxMaxSize.Height)
                    pictureBox1.Height = mPictureBoxMaxSize.Height;
            }
            else
            {
                pictureBox1.Width = (int)(pictureBox1.Height / mAspect);
                if (pictureBox1.Width > mPictureBoxMaxSize.Width)
                    pictureBox1.Width = mPictureBoxMaxSize.Width;
            }
            pictureBox1.Refresh();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnCopyPath_Click(object sender, EventArgs e)
        {
            ListViewItem focusedItem = listView1.FocusedItem;
            Clipboard.SetText(focusedItem.Text);
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            ListViewItem focusedItem = listView1.FocusedItem;
            Process.Start(focusedItem.Text);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem focusedItem = listView1.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextListview.Show(listView1, e.Location);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            PrintMessage("");

            lblIndex.Text = "Select " + (listView1.SelectedIndices[0] + 1).ToString() + "/" + listView1.Items.Count.ToString();
            m_currentImagePath = listView1.SelectedItems[0].Text;

            if (!File.Exists(m_currentImagePath))
            {
                PrintError("File not exist");
                return;
            }


            if (this.Width < 1200)
                this.Width = 1200;


            byte[] bytes = File.ReadAllBytes(m_currentImagePath);
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bmp = (Bitmap)Image.FromStream(ms);


            pictureBox1.Image = bmp;
            mScaleX = (float)bmp.Width / pictureBox1.Width;
            mScaleY = (float)bmp.Height / pictureBox1.Height;
            mAspect = (float)bmp.Width / bmp.Height;


            m_rects.Clear();


            if (m_results.Count > 0 && listView1.SelectedIndices[0] < m_results.Count)
            {
                m_currentObjects = m_results[listView1.SelectedIndices[0]];                
            }

            pictureBox1.Refresh();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgAnalytics_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PrintMessage(e.ProgressPercentage + "%");
            progressBar1.Value = e.ProgressPercentage;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (m_currentObjects == null || m_currentObjects.Count == 0)
                return;

            Pen pen = new Pen(Color.Red);
            for (int j = 0; j < m_currentObjects.Count; j++)
            {
                DarknetObj obj = m_currentObjects[j];
                Rectangle rect = obj.rect;
                int x = (int)(rect.X / mScaleX);
                int y = (int)(rect.Y / mScaleY);
                int w = (int)(rect.Width / mScaleX);
                int h = (int)(rect.Height / mScaleY);

                e.Graphics.DrawRectangle(pen, new Rectangle(x, y, w, h));
                string className = m_classes[obj.classID];
                e.Graphics.DrawString(className, myFont, redBrush, x, y - 20);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerClear_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            errorProvider1.Clear();
            timerClear.Stop();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_classes_TextChanged(object sender, EventArgs e)
        {
            if (cb_classes.Text == "")
                return;
            if (!File.Exists(cb_classes.Text))
                return;

            string[] lines = File.ReadAllLines(cb_classes.Text);
            if (lines.Length == 0)
                return;
            m_classes = new List<string>(lines);
            btnAnalytics.Enabled = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_config_TextChanged(object sender, EventArgs e)
        {
            btnAnalytics.Enabled = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_weight_TextChanged(object sender, EventArgs e)
        {
            btnAnalytics.Enabled = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void txtMoveFile1_TextChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("txtMoveFile1", txtMoveFile1.Text);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtMoveFile2_TextChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("txtMoveFile2", txtMoveFile2.Text);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            PrintMessage("");

            if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    if (listView1.SelectedIndices.Count > 0)
                    {
                        Clipboard.SetText(listView1.SelectedItems[0].Text);
                        PrintSuccess("Copied path to clipboard");
                    }
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                Process.Start("http://thigiacmaytinh.com");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (listView1.SelectedIndices.Count > 0)
                {
                    Process.Start(listView1.SelectedItems[0].Text);
                }
            }
        }
    }
}
