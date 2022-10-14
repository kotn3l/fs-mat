using SoulsFormats;
using static SoulsFormats.MATBIN;

namespace fs_mat
{
    public partial class Form1 : Form
    {
        private static string ERdir = @"Z:\ER_modengine\mattest";
        private static BND4 allmat;
        public static MATBIN currentMat;
        public static MATBIN currentMatBackup;
        public static int currentMatIndex = -1;
        private static Dictionary<string, List<string>> matByCategory;
        public static int selectedRowParam = -1;
        public Form1()
        {
            InitializeComponent();
            matByCategory = new Dictionary<string, List<string>>();
            allmat = BND4.Read(ERdir + @"\material\allmaterial.matbinbnd.dcx");
            if (!File.Exists(ERdir + @"\material\allmaterial.matbinbnd.dcx.backup"))
            {
                File.Copy(ERdir + @"\material\allmaterial.matbinbnd.dcx", ERdir + @"\material\allmaterial.matbinbnd.dcx.backup");
            }
            cB_matCategory.Items.Clear();
            cB_allmat.Items.Clear();
            foreach (var mat in allmat.Files)
            {
                var fullname = mat.Name.Split('\\');
                string final = "\\";

                if (!matByCategory.ContainsKey(fullname[6]))
                {
                    matByCategory.Add(fullname[6], new List<string>());
                    cB_matCategory.Items.Add(fullname[6]);
                }

                for (int i = 7; i < fullname.Length-1; i++)
                {
                    final += fullname[i] + "\\";
                }
                final += fullname[fullname.Length-1];
                matByCategory[fullname[6]].Add(final);

                //cB_allmat.Items.Add(final);
            }
            cB_matCategory.SelectedIndex = 0;
        }

        private void cB_allmat_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMatIndex = allmat.Files.IndexOf(allmat.Files.Where(x => x.Name.Contains(cB_allmat.SelectedItem.ToString())).First());
            label1.Text = allmat.Files[currentMatIndex].Name;
            currentMat = MATBIN.Read(allmat.Files[currentMatIndex].Bytes);
            //currentMatBackup = MATBIN.Read(allmat.Files[currentMatIndex].Bytes);


            tb_ShaderPath.Text = currentMat.ShaderPath;
            dGV_Params.Columns.Clear();
            //dGV_Params.Rows.Clear();

            dGV_Params.DataSource = currentMat.Params;
            dGV_Params.Columns["Name"].ReadOnly = true;
            dGV_Params.Columns["Key"].ReadOnly = true;
            dGV_Params.Columns["Type"].ReadOnly = true;
            dGV_Params.Columns["Name"].Width = 421;
            dGV_Params.Columns["Value"].Width = 205;
            dGV_Params.Columns["Key"].Width = 70;
            dGV_Params.Columns["Type"].Width = 40;

            dGV_Samplers.DataSource = currentMat.Samplers;
            dGV_Samplers.Columns["Key"].ReadOnly = true;
            dGV_Samplers.Columns["Path"].Width = 325;
            dGV_Samplers.Columns["Type"].Width = 325;
            dGV_Samplers.Columns["Key"].Width = 35;
            dGV_Samplers.Columns["Unk14"].Width = 70;


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
                        selectedRowParam = dGV_Params.CurrentCell.RowIndex;
                        MultipleDataEditForm mdef = new MultipleDataEditForm();
                        mdef.ShowDialog();
                        break;
                }
            }
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            allmat.Files[currentMatIndex].Bytes = currentMat.Write();
            allmat.Write(ERdir + @"\material\allmaterial.matbinbnd.dcx0");
            File.Delete(ERdir + @"\material\allmaterial.matbinbnd.dcx");
            File.Move(ERdir + @"\material\allmaterial.matbinbnd.dcx0", ERdir + @"\material\allmaterial.matbinbnd.dcx");
            System.GC.Collect();

        }
    }
}