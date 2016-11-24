using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Wii_U_Zip
{
    public partial class Form1 : Form
    {
        public Form1(string file)
        {
            InitializeComponent();
            filename = file;
        }

        public Form1()
        {
            InitializeComponent();
            filename = null;
        }

        private string filename;

        private void openFile(string file)
        {
            treeView1.Nodes.Clear();
            filename = file;
            Text = file;
            if (Path.GetExtension(file).Equals(".szs"))
            {
                byte[] szs = YAZ0.Decompress(File.ReadAllBytes(file));
                if ((new FileData(szs)).readString(0, 4).Equals("SARC"))
                {
                    SARC sarc = new SARC();
                    sarc.Read(szs);
                    foreach (string name in sarc.files.Keys)
                    {
                        treeView1.Nodes.Add(new TreeNode(name) { Tag = sarc.files[name] });
                    }
                }
                else
                {
                    treeView1.Nodes.Add(new TreeNode("contents.bin") { Tag = szs });
                }
            }
            else if (Path.GetExtension(file).Equals(".pck"))
            {
                PCK p = new PCK(file);
            }
            else
            {
                SARC sarc = new SARC(file);
                foreach (string name in sarc.files.Keys)
                {
                    treeView1.Nodes.Add(new TreeNode(name) { Tag = sarc.files[name] });
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(filename != null)
                openFile(filename);
        }

        private void extract_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = treeView1.SelectedNode;
            if (currentNode != null)
            {
                if (!String.IsNullOrWhiteSpace(Path.GetDirectoryName(treeView1.SelectedNode.Text)))
                    Directory.CreateDirectory(Path.GetDirectoryName(treeView1.SelectedNode.Text));
                File.WriteAllBytes(treeView1.SelectedNode.Text, (byte[])treeView1.SelectedNode.Tag);
            }
        }

        private void extractAll_Click(object sender, EventArgs e)
        {
            foreach(TreeNode t in treeView1.Nodes)
            {
                if (!String.IsNullOrWhiteSpace(Path.GetDirectoryName(t.Text)))
                    Directory.CreateDirectory(Path.GetDirectoryName(t.Text));
                File.WriteAllBytes(t.Text, (byte[])t.Tag);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Filter = "All supported Filetypes (.szs, .sarc, .arc, .pack, .bars, .bgenv)|*.szs;*.sarc;*.arc;*.pack;*.bars;*.bgenv|" +
                             "YAZ0 compressed File (.szs)|*.szs|" +
                             "SARC archive (.sarc, .arc, .pack, .bars, .bgenv)|*.sarc;*.arc;*.pack;*.bars;*.bgenv|" +
                             "All Files|*.*";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    openFile(ofd.FileName);
                }
            }
        }

        private void setupFiletypeAssociationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = Application.ExecutablePath;
            if (System.Environment.OSVersion.Version.Major >= 6)
            {
                p.StartInfo.Verb = "runas";
            }
            p.Start();
        }

        private void sARCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "All supported Filetypes (.sarc, .arc, .pack, .bars, .bgenv)|*.sarc;*.arc;*.pack;*.bars;*.bgenv|" +
                             "SARC archive (.sarc, .arc, .pack, .bars, .bgenv)|*.sarc;*.arc;*.pack;*.bars;*.bgenv";

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    SARC sarc = new SARC();
                    foreach (TreeNode t in treeView1.Nodes)
                    {
                        sarc.files.Add(t.Text, (byte[])t.Tag);
                    }
                    File.WriteAllBytes(sfd.FileName, sarc.Rebuild());
                }
            }
        }

        private void yAZ0SARCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "YAZ0 Compressed SARC (.szs)|*.szs";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SARC sarc = new SARC();
                    foreach (TreeNode t in treeView1.Nodes)
                    {
                        sarc.files.Add(t.Text, (byte[])t.Tag);
                    }
                    File.WriteAllBytes(sfd.FileName, YAZ0.LazyCompress(sarc.Rebuild()));
                }
            }
        }

        private void yAZ0FileszsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.Nodes.Count > 0)
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "YAZ0 Compressed SARC (.szs)|*.szs";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (treeView1.SelectedNode != null)
                            File.WriteAllBytes(sfd.FileName, YAZ0.LazyCompress((byte[])treeView1.SelectedNode.Tag));
                        else
                            File.WriteAllBytes(sfd.FileName, YAZ0.LazyCompress((byte[])treeView1.Nodes[0].Tag));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//replace
        {
            if (treeView1.SelectedNode != null)
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.CheckFileExists = true;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        treeView1.SelectedNode.Tag = File.ReadAllBytes(ofd.FileName);
                    }
                }
            }
        }

        private void addFile(string filename)
        {
            treeView1.Nodes.Add(new TreeNode(Path.GetFileName(filename)) { Tag = File.ReadAllBytes(filename) });
        }

        private void button2_Click(object sender, EventArgs e)//add
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    addFile(ofd.FileName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//delete
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
        }

        private void Form1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;

        }

        private void Form1_DragDrop_1(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                addFile(file);
        }
    }
}
