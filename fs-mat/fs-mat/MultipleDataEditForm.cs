using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SoulsFormats.MATBIN;


namespace fs_mat
{
    public partial class MultipleDataEditForm : Form
    {
        List<TextBox> tbs = new List<TextBox>() { new TextBox() };
        public MultipleDataEditForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = Form1.currentMat.Params[Form1.selectedRowParam].Type.ToString() + " | " +Form1.multiParamName;
            loadData();
        }

        private void loadData()
        {
            switch (Form1.currentMat.Params[Form1.selectedRowParam].Type)
            {
                default:
                    break;
                case ParamType.Int2:
                    textBox1.Text = ((int[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0].ToString();
                    textBox2.Text = ((int[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1].ToString();
                    break;
                case ParamType.Float2:
                    textBox1.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0].ToString();
                    textBox2.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1].ToString();
                    break;
                case ParamType.Float4:
                    textBox1.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0].ToString();
                    textBox2.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1].ToString();
                    textBox3.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[2].ToString();
                    textBox4.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[3].ToString();
                    break;
                case ParamType.Float5:
                    textBox1.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0].ToString();
                    textBox2.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1].ToString();
                    textBox3.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[2].ToString();
                    textBox4.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[3].ToString();
                    textBox5.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[4].ToString();
                    break;
                case ParamType.Float3:
                    textBox1.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0].ToString();
                    textBox2.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1].ToString();
                    textBox3.Text = ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[2].ToString();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Form1.currentMat.Params[Form1.selectedRowParam].Type)
                {
                    default:
                        break;
                    case ParamType.Int2:
                        ((int[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0] = int.Parse(textBox1.Text);
                        ((int[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1] = int.Parse(textBox2.Text);
                        break;
                    case ParamType.Float2:
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0] = float.Parse(textBox1.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1] = float.Parse(textBox2.Text);
                        break;
                    case ParamType.Float4:
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0] = float.Parse(textBox1.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1] = float.Parse(textBox2.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[2] = float.Parse(textBox3.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[3] = float.Parse(textBox4.Text);
                        break;
                    case ParamType.Float5:
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0] = float.Parse(textBox1.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1] = float.Parse(textBox2.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[2] = float.Parse(textBox3.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[3] = float.Parse(textBox4.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[4] = float.Parse(textBox5.Text);
                        break;
                    case ParamType.Float3:
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[0] = float.Parse(textBox1.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[1] = float.Parse(textBox2.Text);
                        ((float[])Form1.currentMat.Params[Form1.selectedRowParam].Value)[2] = float.Parse(textBox3.Text);
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                Form1.currentMat.Params[Form1.selectedRowParam].Value = Form1.currentMatBackup.Params[Form1.selectedRowParam].Value;
                loadData();
                MessageBox.Show("Couldn't modify value! Resetting...");
            }
            
        }
    }
}
