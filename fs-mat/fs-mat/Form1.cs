using SoulsFormats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SoulsFormats.MATBIN;

namespace fs_mat
{
    public partial class Form1 : Form
    {
        private static string matbinFile = "";
        private static BND4 allmat = new BND4();
        public static MATBIN currentMat = new MATBIN();
        public static MATBIN currentMatBackup = new MATBIN();
        public static int currentMatIndex = -1;
        private static Dictionary<string, List<string>> matByCategory = new Dictionary<string, List<string>>();
        public static int selectedRowParam = -1;
        public static string multiParamName = "";
        private static List<string> shaders = new List<string>();
        private int shaderIndex = -1;

        //private static Dictionary<string, List<string>> shaderParams = new Dictionary<string, List<string>>();
        //private static Dictionary<string, List<string>> shaderSamplers = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            yeToolStripMenuItem.Text = config.Default.lastMATBINFile;
            if (config.Default.lastMATBINFile != "" || config.Default.lastMATBINFile != String.Empty || File.Exists(config.Default.lastMATBINFile))
            {
                matbinFile = config.Default.lastMATBINFile;
                preSetUp();
            }

        }

        private async void preSetUp(string s = "")
        {
            try
            {
                cb_Shaders.Items.Clear();
                cB_matCategory.Items.Clear();
                cB_allmat.Items.Clear();
                progressBar1.Maximum = 100;
                progressBar1.Step = 1;
                var progress = new Progress<int>(v =>
                {
                    progressBar1.Value = v;
                });
                //Task t1 = new Task(() => setUp(progress));
                setControls(false);
                await Task.Run(() => setUp(progress));
                if (s != "")
                {
                    MessageBox.Show(s);
                }
                setControls(true);
                cb_Shaders.Items.AddRange(shaders.ToArray());
                cB_matCategory.Items.AddRange(matByCategory.Keys.ToArray());
                cB_matCategory.SelectedIndex = 0;
                progressBar1.Value = 0;
            }
            catch (Exception)
            {
                MessageBox.Show($"An error occured while reading the file -- is the path correct?: {matbinFile}");
                resetForm();
            }

        }

        private void setUp(IProgress<int> progress)
        {
            allmat = BND4.Read(matbinFile);
            matByCategory.Clear();
            shaders.Clear();
            for (int i = 0; i < allmat.Files.Count; i++)
            {
                MATBIN temp = MATBIN.Read(allmat.Files[i].Bytes);
                if (!shaders.Contains(temp.ShaderPath))
                {
                    shaders.Add(temp.ShaderPath);
                    //cb_Shaders.Items.Add(temp.ShaderPath);
                }
                /*if (!shaderParams.ContainsKey(temp.ShaderPath))
                {
                    shaderParams.Add(temp.ShaderPath, new List<string>());
                    shaderSamplers.Add(temp.ShaderPath, new List<string>());
                    foreach (var item in temp.Params)
                    {
                        if (!shaderParams[temp.ShaderPath].Contains(item.Name))
                        {
                            shaderParams[temp.ShaderPath].Add(item.Name);
                        }
                    }
                    foreach (var item in temp.Samplers)
                    {
                        if (!shaderSamplers[temp.ShaderPath].Contains(item.Type))
                        {
                            shaderSamplers[temp.ShaderPath].Add(item.Type);
                        }
                    }
                    //cb_Shaders.Items.Add(temp.ShaderPath);
                }*/
                var fullname = allmat.Files[i].Name.Split('\\');
                string final = "\\";

                if (!matByCategory.ContainsKey(fullname[6]))
                {
                    matByCategory.Add(fullname[6], new List<string>());
                    //cB_matCategory.Items.Add(fullname[6]);
                }

                for (int j = 7; j < fullname.Length - 1; j++)
                {
                    final += fullname[j] + "\\";
                }
                final += fullname[fullname.Length - 1];
                matByCategory[fullname[6]].Add(final);
                progress.Report((i + 1) * 100 / allmat.Files.Count);
            }
            shaders.Sort();

            System.GC.Collect();
        }

        private void cB_allmat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cB_allmat.SelectedItem == null)
                return;
            try
            {
                currentMatIndex = allmat.Files.IndexOf(allmat.Files.First(x => x.Name.Contains(cB_allmat.SelectedItem.ToString())));
                currentMat = MATBIN.Read(allmat.Files[currentMatIndex].Bytes);
                currentMatBackup = MATBIN.Read(allmat.Files[currentMatIndex].Bytes);
                shaderIndex = shaders.IndexOf(currentMat.ShaderPath);
                cb_Shaders.SelectedIndex = shaderIndex;

                label1.Text = allmat.Files[currentMatIndex].Name;
                dGV_Params.Columns.Clear();
                dGV_Samplers.Columns.Clear();
                //dGV_Params.Rows.Clear();

                dGV_Params.DataSource = currentMat.Params;
                dGV_Params.Columns["Key"].Visible = false;
                dGV_Params.Columns["Name"].ReadOnly = true;
                dGV_Params.Columns["Key"].ReadOnly = true;
                dGV_Params.Columns["Type"].ReadOnly = true;
                dGV_Params.Columns["Name"].Width = 626;
                dGV_Params.Columns["Value"].Width = 95;
                dGV_Params.Columns["Key"].Width = 70;
                dGV_Params.Columns["Type"].Width = 55;
                dGV_Params.Columns["Type"].DisplayIndex = 0;
                dGV_Params.Columns["Name"].DisplayIndex = 1;
                dGV_Params.Columns["Value"].DisplayIndex = 2;
                dGV_Params.Columns["Key"].DisplayIndex = 3;


                dGV_Samplers.DataSource = currentMat.Samplers;
                dGV_Samplers.Columns["Key"].Visible = false;
                dGV_Samplers.Columns["Key"].ReadOnly = true;
                dGV_Samplers.Columns["Type"].ReadOnly = true;
                dGV_Samplers.Columns["Path"].Width = 356;
                dGV_Samplers.Columns["Type"].Width = 362;
                dGV_Samplers.Columns["Key"].Width = 30;
                dGV_Samplers.Columns["Unk14"].Width = 75;
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot open MATBINs from binderfile. Did you browse for the correct file?");
                resetForm();
            }

            System.GC.Collect();

        }
        private void cB_matCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var kvp in matByCategory)
            {
                if (kvp.Key == cB_matCategory.SelectedItem.ToString())
                {
                    cB_allmat.Items.Clear();
                    foreach (var item in kvp.Value)
                    {
                        cB_allmat.Items.Add(item);
                    }
                    cB_allmat.SelectedIndex = 0;
                    return;
                }

            }
        }
        private void dGV_Params_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MATBIN.Param test = dGV_Params.SelectedRows[0].DataBoundItem as MATBIN.Param;
            try
            {
                switch (test.Type)
                {
                    case ParamType.Bool:
                        test.Value = bool.Parse((string)test.Value);
                        break;
                    case ParamType.Int:
                        test.Value = int.Parse((string)test.Value);
                        break;
                    case ParamType.Float:
                        test.Value = float.Parse((string)test.Value);
                        break;
                    default:
                        break;
                }
                currentMat.Params[dGV_Params.CurrentCell.RowIndex] = test;
            }
            catch (Exception)
            {
                currentMat.Params[dGV_Params.CurrentCell.RowIndex].Value = currentMatBackup.Params[dGV_Params.CurrentCell.RowIndex].Value;
                MessageBox.Show("Couldn't modify value! Resetting...");
            }

            //MessageBox.Show("test");
        }
        private void dGV_Params_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGV_Params.CurrentCellAddress.X == 1)
            {
                MATBIN.Param test = dGV_Params.SelectedRows[0].DataBoundItem as MATBIN.Param;
                switch (test.Type)
                {
                    case ParamType.Bool:
                    case ParamType.Int:
                    case ParamType.Float:
                    default:
                        break;
                    case ParamType.Int2:
                    case ParamType.Float2:
                    case ParamType.Float4:
                    case ParamType.Float5:
                    case ParamType.Float3:
                        multiParamName = test.Name;
                        selectedRowParam = dGV_Params.CurrentCell.RowIndex;
                        MultipleDataEditForm mdef = new MultipleDataEditForm();
                        mdef.ShowDialog();
                        break;
                }
            }
        }
        private void dGV_Samplers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MATBIN.Sampler test = dGV_Samplers.SelectedRows[0].DataBoundItem as MATBIN.Sampler;
            currentMat.Samplers[dGV_Params.CurrentCell.RowIndex] = test;
        }
        private void dGV_Samplers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGV_Samplers.CurrentCellAddress.X == 3)
            {
                MATBIN.Sampler test = dGV_Samplers.SelectedRows[0].DataBoundItem as MATBIN.Sampler;
                multiParamName = test.Type;
                selectedRowParam = dGV_Samplers.CurrentCell.RowIndex;
                MultipleDataEditForm mdef = new MultipleDataEditForm(false);
                mdef.ShowDialog();
            }
        }
        private void SaveMaterial(IProgress<int> progress)
        {
            progress.Report(20);
            allmat.Files[currentMatIndex].Bytes = currentMat.Write();
            progress.Report(40);
            allmat.Write(matbinFile + "0");
            progress.Report(70);
            File.Delete(matbinFile);
            progress.Report(90);
            File.Move(matbinFile + "0", matbinFile);
            progress.Report(100);
        }
        private async void b_Save_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 10;
            var progress = new Progress<int>(v =>
            {
                progressBar1.Value = v;
            });
            setControls(false);
            await Task.Run(() => SaveMaterial(progress));
            setControls(true);
            System.GC.Collect();
            MessageBox.Show("Saved!");
            progressBar1.Value = 0;
        }
        private void loadmatbinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "dcx compressed MATBIN (*.dcx)|*.dcx|MATBIN BinderFile (*.matbinbnd)|*.matbinbnd";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    matbinFile = openFileDialog.FileName;
                    config.Default.lastMATBINFile = matbinFile;
                    config.Default.Save();
                    createBackup();
                    preSetUp();
                }
            }
        }
        private void b_ResetMat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Reset material {cB_allmat.SelectedItem}?", "Reset", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < currentMat.Params.Count; i++)
                {
                    currentMat.Params[i].Value = currentMatBackup.Params[i].Value;
                }
                for (int i = 0; i < currentMat.Samplers.Count; i++)
                {
                    currentMat.Samplers[i].Path = currentMatBackup.Samplers[i].Path;
                    currentMat.Samplers[i].Unk14 = currentMatBackup.Samplers[i].Unk14;
                }
                currentMat.ShaderPath = currentMatBackup.ShaderPath;
                int save = cB_allmat.SelectedIndex;
                cB_allmat.SelectedIndex = -1;
                cB_allmat.SelectedIndex = save;
                MessageBox.Show("Material Reset!");
            }
        }
        private void fromDefaultLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(matbinFile + @".backup"))
            {
                if (MessageBox.Show($"This will overwrite the allmaterial file with the default backup file. Continue?", "Restore backup", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Move(matbinFile, matbinFile + "1");
                    File.Copy(matbinFile + @".backup", matbinFile);
                    File.Delete(matbinFile + "1");
                    preSetUp("Backup Restored!");
                }
            }
            else
            {
                MessageBox.Show($"Backup file doesn't exist at the default location! ({matbinFile + @".backup"})");
            }

        }
        private void withDefaultFilenamelocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(matbinFile + @".backup"))
            {
                if (MessageBox.Show($"This will overwrite the backup found at the default location. Continue?", "New backup", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    createBackup();
                }
                else return;
            }
            else
            {
                createBackup();
            }
            MessageBox.Show("Backup Created!");
        }
        private void createBackup()
        {
            File.Copy(matbinFile, matbinFile + ".backup0");
            if (File.Exists(matbinFile + @".backup"))
            {
                File.Delete(matbinFile + @".backup");
            }
            File.Move(matbinFile + ".backup0", matbinFile + @".backup");
            File.SetLastWriteTime(matbinFile + @".backup", DateTime.Now);
        }
        private void resetForm()
        {
            dGV_Params.Columns.Clear();
            dGV_Samplers.Columns.Clear();
            matByCategory.Clear();
            cB_allmat.Items.Clear();
            cB_matCategory.Items.Clear();
        }
        private void setControls(bool enabled)
        {
            dGV_Params.Enabled = enabled;
            dGV_Params.Enabled = enabled;
            cb_Shaders.Enabled = enabled;
            cB_allmat.Enabled = enabled;
            cB_matCategory.Enabled = enabled;
            b_ResetMat.Enabled = enabled;
            b_saveShader.Enabled = enabled;
            fileMenu.Enabled = enabled;
        }
        private void b_saveShader_Click(object sender, EventArgs e)
        {
            currentMat.ShaderPath = shaders[cb_Shaders.SelectedIndex];
        }
    }
}