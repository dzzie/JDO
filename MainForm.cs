using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
/* 
 * todo:
 *       convert method prototypes into standard source notation
 *       batch renamer interface  ex: class_0 -> myCLass
 *                                    myClass.sub_0 -> doDownload
 * 
 */ 
namespace JavaDeObfuscator
{
	public class MainForm : System.Windows.Forms.Form
	{
		TDeObfuscator DeObfuscator = null;
		ArrayList Files = null;
        RenameDatabase RenameStore = null;
        private OpenFileDialog OpenFileDialog;
		private TreeView TreeClassView;
		private Button ProcessButton;
		private ToolTip ToolTip;
		private CheckBox RenameClassCheckBox;
		private CheckBox SmartRenameMethods;
		private ProgressBar Progress;
		private TextBox txtOutput;
		private Button btnOutput;
		private Label label2;
		private FolderBrowserDialog dlgOutput;
        private CheckBox chkUseUniqueNums;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem classesToolStripMenuItem1;
        private ToolStripMenuItem directoryToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem sequentiallyRenameToolStripMenuItem;
        private ToolStripMenuItem classesToolStripMenuItem2;
        private ToolStripMenuItem methodsTypesToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolStripMenuItem clearAllToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem readmeToolStripMenuItem;
        private ToolStripMenuItem changelogToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mnuSequentiallyRenamePopup;
        private ToolStripMenuItem copySelectedDataToolStripMenuItem;
        private ToolStripMenuItem copyAllSubNodesToolStripMenuItem;
        private ToolStripMenuItem batchRenamerToolStripMenuItem;
        private ToolStripMenuItem extractImportsToolStripMenuItem;
		private IContainer components;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new MainForm());
            Properties.Settings.Default.Reload();
		}


		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.TreeClassView = new System.Windows.Forms.TreeView();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RenameClassCheckBox = new System.Windows.Forms.CheckBox();
            this.SmartRenameMethods = new System.Windows.Forms.CheckBox();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dlgOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.chkUseUniqueNums = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequentiallyRenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.methodsTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllSubNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchRenamerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSequentiallyRenamePopup = new System.Windows.Forms.ToolStripMenuItem();
            this.extractImportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeClassView
            // 
            this.TreeClassView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeClassView.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeClassView.Location = new System.Drawing.Point(8, 53);
            this.TreeClassView.Name = "TreeClassView";
            this.TreeClassView.ShowNodeToolTips = true;
            this.TreeClassView.Size = new System.Drawing.Size(610, 346);
            this.TreeClassView.TabIndex = 4;
            this.TreeClassView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeClassView_NodeMouseClick);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "Class Files|*.class";
            this.OpenFileDialog.Multiselect = true;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessButton.Location = new System.Drawing.Point(518, 405);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(100, 23);
            this.ProcessButton.TabIndex = 8;
            this.ProcessButton.Text = "Deobfuscate";
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // ToolTip
            // 
            this.ToolTip.IsBalloon = true;
            // 
            // RenameClassCheckBox
            // 
            this.RenameClassCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenameClassCheckBox.AutoSize = true;
            this.RenameClassCheckBox.Checked = true;
            this.RenameClassCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RenameClassCheckBox.Location = new System.Drawing.Point(12, 409);
            this.RenameClassCheckBox.Name = "RenameClassCheckBox";
            this.RenameClassCheckBox.Size = new System.Drawing.Size(105, 17);
            this.RenameClassCheckBox.TabIndex = 6;
            this.RenameClassCheckBox.Text = "Rename Classes";
            // 
            // SmartRenameMethods
            // 
            this.SmartRenameMethods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SmartRenameMethods.AutoSize = true;
            this.SmartRenameMethods.Checked = true;
            this.SmartRenameMethods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SmartRenameMethods.Enabled = false;
            this.SmartRenameMethods.Location = new System.Drawing.Point(252, 410);
            this.SmartRenameMethods.Name = "SmartRenameMethods";
            this.SmartRenameMethods.Size = new System.Drawing.Size(140, 17);
            this.SmartRenameMethods.TabIndex = 7;
            this.SmartRenameMethods.Text = "Smart Rename Methods";
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(12, 433);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(610, 15);
            this.Progress.Step = 1;
            this.Progress.TabIndex = 9;
            this.Progress.Visible = false;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(78, 27);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(512, 20);
            this.txtOutput.TabIndex = 2;
            // 
            // btnOutput
            // 
            this.btnOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutput.Location = new System.Drawing.Point(596, 26);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(24, 20);
            this.btnOutput.TabIndex = 3;
            this.btnOutput.Text = "...";
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Output Dir:";
            // 
            // dlgOutput
            // 
            this.dlgOutput.Description = "Select output folder";
            // 
            // chkUseUniqueNums
            // 
            this.chkUseUniqueNums.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUseUniqueNums.AutoSize = true;
            this.chkUseUniqueNums.Checked = true;
            this.chkUseUniqueNums.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseUniqueNums.Location = new System.Drawing.Point(123, 409);
            this.chkUseUniqueNums.Name = "chkUseUniqueNums";
            this.chkUseUniqueNums.Size = new System.Drawing.Size(123, 17);
            this.chkUseUniqueNums.TabIndex = 7;
            this.chkUseUniqueNums.Text = "Use unique numbers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classesToolStripMenuItem1,
            this.directoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearAllToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // classesToolStripMenuItem1
            // 
            this.classesToolStripMenuItem1.Name = "classesToolStripMenuItem1";
            this.classesToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.classesToolStripMenuItem1.Text = "Classes";
            this.classesToolStripMenuItem1.Click += new System.EventHandler(this.classesToolStripMenuItem1_Click);
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.directoryToolStripMenuItem.Text = "Directory";
            this.directoryToolStripMenuItem.Click += new System.EventHandler(this.directoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.clearAllToolStripMenuItem.Text = "Start Over";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequentiallyRenameToolStripMenuItem,
            this.copySelectedDataToolStripMenuItem,
            this.copyAllSubNodesToolStripMenuItem,
            this.batchRenamerToolStripMenuItem,
            this.extractImportsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sequentiallyRenameToolStripMenuItem
            // 
            this.sequentiallyRenameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classesToolStripMenuItem2,
            this.methodsTypesToolStripMenuItem});
            this.sequentiallyRenameToolStripMenuItem.Name = "sequentiallyRenameToolStripMenuItem";
            this.sequentiallyRenameToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.sequentiallyRenameToolStripMenuItem.Text = "Sequentially Rename";
            // 
            // classesToolStripMenuItem2
            // 
            this.classesToolStripMenuItem2.Name = "classesToolStripMenuItem2";
            this.classesToolStripMenuItem2.Size = new System.Drawing.Size(163, 22);
            this.classesToolStripMenuItem2.Text = "Classes";
            this.classesToolStripMenuItem2.Click += new System.EventHandler(this.classesToolStripMenuItem2_Click);
            // 
            // methodsTypesToolStripMenuItem
            // 
            this.methodsTypesToolStripMenuItem.Name = "methodsTypesToolStripMenuItem";
            this.methodsTypesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.methodsTypesToolStripMenuItem.Text = "Methods / Fields";
            this.methodsTypesToolStripMenuItem.Click += new System.EventHandler(this.methodsTypesToolStripMenuItem_Click);
            // 
            // copySelectedDataToolStripMenuItem
            // 
            this.copySelectedDataToolStripMenuItem.Name = "copySelectedDataToolStripMenuItem";
            this.copySelectedDataToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.copySelectedDataToolStripMenuItem.Text = "Copy Sub Nodes";
            this.copySelectedDataToolStripMenuItem.Click += new System.EventHandler(this.copySelectedDataToolStripMenuItem_Click);
            // 
            // copyAllSubNodesToolStripMenuItem
            // 
            this.copyAllSubNodesToolStripMenuItem.Name = "copyAllSubNodesToolStripMenuItem";
            this.copyAllSubNodesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.copyAllSubNodesToolStripMenuItem.Text = "Copy All SubNodes";
            this.copyAllSubNodesToolStripMenuItem.Click += new System.EventHandler(this.copyAllSubNodesToolStripMenuItem_Click);
            // 
            // batchRenamerToolStripMenuItem
            // 
            this.batchRenamerToolStripMenuItem.Name = "batchRenamerToolStripMenuItem";
            this.batchRenamerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.batchRenamerToolStripMenuItem.Text = "Batch Renamer";
            this.batchRenamerToolStripMenuItem.Click += new System.EventHandler(this.batchRenamerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readmeToolStripMenuItem,
            this.changelogToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // readmeToolStripMenuItem
            // 
            this.readmeToolStripMenuItem.Name = "readmeToolStripMenuItem";
            this.readmeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.readmeToolStripMenuItem.Text = "Readme";
            this.readmeToolStripMenuItem.Click += new System.EventHandler(this.readmeToolStripMenuItem_Click);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSequentiallyRenamePopup});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 26);
            // 
            // mnuSequentiallyRenamePopup
            // 
            this.mnuSequentiallyRenamePopup.Name = "mnuSequentiallyRenamePopup";
            this.mnuSequentiallyRenamePopup.Size = new System.Drawing.Size(185, 22);
            this.mnuSequentiallyRenamePopup.Text = "Sequentially Rename";
            this.mnuSequentiallyRenamePopup.Click += new System.EventHandler(this.sequentiallyRenamePopup_Click);
            // 
            // extractImportsToolStripMenuItem
            // 
            this.extractImportsToolStripMenuItem.Name = "extractImportsToolStripMenuItem";
            this.extractImportsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.extractImportsToolStripMenuItem.Text = "Extract Imports";
            this.extractImportsToolStripMenuItem.Click += new System.EventHandler(this.extractImportsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(629, 451);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.chkUseUniqueNums);
            this.Controls.Add(this.SmartRenameMethods);
            this.Controls.Add(this.RenameClassCheckBox);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.TreeClassView);
            this.Controls.Add(this.btnOutput);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Java DeObfuscator v1.6b2_dz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void UpdateTree()
		{
			TreeClassView.Nodes.Clear();

			DeObfuscator = new TDeObfuscator(Files);

			foreach (string fn in Files)
			{
				TClassFile ClassFile = new TClassFile(fn);

				if (!ClassFile.Open())
				{
					TreeClassView.Nodes.Add("Invalid class file: " + fn);
					continue;
				}

				if (ClassFile != null)
				{
					TreeNode bigroot;

					// check if the user wants to rename the class file
					string original_class_name = ClassFile.ThisClassName + " : " + ClassFile.SuperClassName;
					string class_name = RenameStore.GetNewClassName(original_class_name);

					if (class_name == null)
					{
						class_name = original_class_name;
						bigroot = TreeClassView.Nodes.Add(class_name);
					}
					else
					{
						bigroot = TreeClassView.Nodes.Add(class_name);
						bigroot.BackColor = Color.DodgerBlue;
					}

					bigroot.Tag = original_class_name;

					TreeNode root = bigroot.Nodes.Add("Constants");
					TreeNode methodsroot = root.Nodes.Add("Methods/Interfaces/Fields");
					TreeNode methods = methodsroot.Nodes.Add("Methods");
					TreeNode interfaces = methodsroot.Nodes.Add("Interfaces");
					TreeNode fields = methodsroot.Nodes.Add("Fields");
					TreeNode variables = root.Nodes.Add("Values");
					TreeNode classes = root.Nodes.Add("Classes");

					for (int i = 0; i < ClassFile.ConstantPool.MaxItems(); i++)
					{
						ConstantPoolInfo cc = ClassFile.ConstantPool.Item(i);

						if (cc is ConstantPoolMethodInfo)
						{
							if (cc is ConstantMethodrefInfo)
							{
								TreeNode temp = methods.Nodes.Add("\"" + ((ConstantMethodrefInfo)cc).NameAndType.Name + "\"");
								temp.Nodes.Add("Descriptor = " + ((ConstantMethodrefInfo)cc).NameAndType.Descriptor);
								temp.Nodes.Add("Parent = " + ((ConstantMethodrefInfo)cc).ParentClass.Name);

								if (DeObfuscator.DoRename(((ConstantMethodrefInfo)cc).NameAndType.Name))
									temp.BackColor = Color.Red;

								continue;
							}

							if (cc is ConstantInterfaceMethodrefInfo)
							{
								TreeNode temp = interfaces.Nodes.Add("\"" + ((ConstantInterfaceMethodrefInfo)cc).NameAndType.Name + "\"");
								temp.Nodes.Add("Descriptor = " + ((ConstantInterfaceMethodrefInfo)cc).NameAndType.Descriptor);
								temp.Nodes.Add("Parent = " + ((ConstantInterfaceMethodrefInfo)cc).ParentClass.Name);

								if (DeObfuscator.DoRename(((ConstantInterfaceMethodrefInfo)cc).NameAndType.Name))
									temp.BackColor = Color.Red;

								continue;
							}

							if (cc is ConstantFieldrefInfo)
							{
								TreeNode temp = fields.Nodes.Add("\"" + ((ConstantFieldrefInfo)cc).NameAndType.Name + "\"");
								temp.Nodes.Add("Descriptor = " + ((ConstantFieldrefInfo)cc).NameAndType.Descriptor);
								if (((ConstantFieldrefInfo)cc).ParentClass != null)
									temp.Nodes.Add("Parent = " + ((ConstantFieldrefInfo)cc).ParentClass.Name);

								if (DeObfuscator.DoRename(((ConstantFieldrefInfo)cc).NameAndType.Name))
									temp.BackColor = Color.Red;

								continue;
							}
						}
						else
							if (cc is ConstantPoolVariableInfo)
							{
								TreeNode temp = variables.Nodes.Add("\"" + ((ConstantPoolVariableInfo)cc).Value.ToString() + "\"");
								temp.Nodes.Add("References = " + cc.References);
							}
							else
								if (cc is ConstantClassInfo)
								{
									TreeNode temp = classes.Nodes.Add("\"" + ((ConstantClassInfo)cc).Name + "\"");
									temp.Nodes.Add("References = " + cc.References);
								}
					}

					root = bigroot.Nodes.Add("Interfaces");
					foreach (InterfaceInfo ii in ClassFile.Interfaces.Items)
					{
						root.Nodes.Add(ii.Interface.Name);
					}

					root = bigroot.Nodes.Add("Fields");
					foreach (FieldInfo fi in ClassFile.Fields.Items)
					{
						RenameData rd = RenameStore.GetNewFieldInfo(
							original_class_name,
							fi.Descriptor,
							fi.Name.Value);
						if (rd != null)
						{
							TreeNode temp = root.Nodes.Add(rd.FieldName);
							temp.Nodes.Add(rd.FieldType);
							temp.BackColor = Color.DodgerBlue;
						}
						else
						{
							TreeNode temp = root.Nodes.Add(fi.Name.Value);
							temp.Nodes.Add(fi.Descriptor);
							temp.Tag = fi.Name.Value;

							if (DeObfuscator.DoRename(fi.Name.Value))
								temp.BackColor = Color.Red;
						}
					}

					root = bigroot.Nodes.Add("Methods");
					foreach (MethodInfo mi in ClassFile.Methods.Items)
					{
						RenameData rd = RenameStore.GetNewMethodInfo(
							original_class_name,
							mi.Descriptor,
							mi.Name.Value);
						if (rd != null)
						{
							TreeNode temp = root.Nodes.Add(rd.FieldName);
							temp.Nodes.Add(rd.FieldType);
							temp.BackColor = Color.DodgerBlue;
						}
						else
						{
							TreeNode temp = root.Nodes.Add(mi.Name.Value);
							temp.Nodes.Add(mi.Descriptor);
							temp.Tag = mi.Name.Value;
							//temp.Nodes.Add(String.Format("Offset = {0:X}", mi.Offset));

							if (DeObfuscator.DoRename(mi.Name.Value))
								temp.BackColor = Color.Red;
						}
					}
				}
			}
		}

		private void ProcessButton_Click(object sender, EventArgs e)
		{
			if (Files == null)
				return;

			if (!Directory.Exists(txtOutput.Text))
			{
                try { Directory.CreateDirectory(txtOutput.Text); }
                catch (Exception ex) { }

                if (!Directory.Exists(txtOutput.Text))
                {
                    MessageBox.Show("Output dir doesn't exists!", "Output", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
			}


			DeObfuscator = new TDeObfuscator(Files);
			DeObfuscator.RenameClasses = RenameClassCheckBox.Checked;
			
			DeObfuscator.OutputDir = txtOutput.Text;
			DeObfuscator.UseUniqueNums = chkUseUniqueNums.Checked;

			Progress.Maximum = Files.Count;
			Progress.Visible = true;

			TDeObfuscator.Progress += new TDeObfuscator.ProgressHandler(OnProgress);

			// update the classfile with the new deobfuscated version
			ArrayList NewFileList = DeObfuscator.DeObfuscateAll(RenameStore);
			if (NewFileList != null)
			{
				MessageBox.Show("DeObfuscated everything ok!", "DeObfuscator");
				Files = NewFileList;
			}
			else
				MessageBox.Show("Error!!!", "DeObfuscator");

			Progress.Visible = false;
			RenameStore = new RenameDatabase();
			UpdateTree();
		}

		private void OnProgress(int progress)
		{
			// Progress 
			if (progress > Progress.Maximum)
				Progress.Value = 0;

			Progress.Value = progress;
		}

		private void TreeClassView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{

            TreeClassView.SelectedNode = e.Node;

            if ((e.Node.Text == "Methods" || e.Node.Text == "Fields") && e.Node.Parent.Parent == null && e.Button == MouseButtons.Right )
            {
                contextMenuStrip1.Show(MousePosition); //sequential rename menu for individual class methods/fields lists
                return;
            }

			// detect right click on a valid member to popup a 'change name' box.
			if (e.Button == MouseButtons.Right && e.Node.Parent != null && e.Node.Parent.Parent != null)
			{
				ChangeName FChangeName = new ChangeName();
				FChangeName.NameBox.Text = e.Node.Text;                

				// get the full path of the node we clicked on, so we have all the information
				// relating to it
				// get parentmost node
				TreeNode pn = e.Node;
				while (pn.Parent != null)
				{
					pn = pn.Parent;
				}

				// get trailing node
				TreeNode tn = e.Node;
				while (tn.Nodes.Count > 0)
				{
					tn = tn.Nodes[0];
				}

                if (tn.Parent.Tag == null) return; //crash fix dz

				string class_name = pn.Tag.ToString();                   // classname

				string[] sl = tn.FullPath.Split('\\');
				string type = sl[1];
				string old_name = tn.Parent.Tag.ToString();

				if (class_name == null || type == null ||
					old_name == null)
				{
					return;
				}

				// check which subsection we are in, so we can add it to the right list
				if ((type == "Methods" || type == "Fields") &&            // section
					(FChangeName.ShowDialog() == DialogResult.OK))
				{
					string old_descriptor = sl[3];

					if (old_descriptor == null)
						return;

					if (type == "Methods")
					{
						RenameStore.AddRenameMethod(class_name, old_descriptor, old_name,
							old_descriptor, FChangeName.NameBox.Text);
					}
					else if (type == "Fields")
					{
						RenameStore.AddRenameField(class_name, old_descriptor, old_name,
							old_descriptor, FChangeName.NameBox.Text);
					}

					// update the tree without reloading it
					tn.Parent.Text = FChangeName.NameBox.Text;
					tn.Parent.ToolTipText = "was '" + tn.Parent.Tag.ToString() + "'";
					tn.Parent.BackColor = Color.DodgerBlue;
				}
			}
			else if (e.Button == MouseButtons.Right && e.Node.Parent == null)
			{
				ChangeName FChangeName = new ChangeName();
				string[] s = e.Node.Text.Split(':');

				string old_name = s[0].Trim();
				string old_descriptor = s[1].Trim();

				if (s.Length == 0)
					return;

				FChangeName.NameBox.Text = old_name;

				// change the class name, since its a root node
				if (FChangeName.ShowDialog() == DialogResult.OK)
				{
					string new_name_and_type = FChangeName.NameBox.Text + " : " + old_descriptor;
					RenameStore.AddRenameClass(e.Node.Tag.ToString(), new_name_and_type);

					e.Node.BackColor = Color.DodgerBlue;
					e.Node.Text = new_name_and_type;
					e.Node.ToolTipText = "was '" + e.Node.Tag.ToString() + "'";
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RenameStore = new RenameDatabase();
		}

		private void btnOutput_Click(object sender, EventArgs e)
		{
			if (dlgOutput.ShowDialog() == DialogResult.OK)
			{
				txtOutput.Text = dlgOutput.SelectedPath;
			}
		}


        //--------------------------------- sequential rename additions -------------------------

        private void ChangeMethodOrFieldName(TreeNode Node, string newName)
        {

            try
            {
                // get the full path of the node we clicked on, so we have all the information
                // relating to it
                // get parentmost node
                TreeNode pn = Node;
                while (pn.Parent != null)
                {
                    pn = pn.Parent;
                }

                // get trailing node
                TreeNode tn = Node;
                while (tn.Nodes.Count > 0)
                {
                    tn = tn.Nodes[0];
                }

                string class_name = pn.Tag.ToString();                   // classname

                string[] sl = tn.FullPath.Split('\\');
                string type = sl[1];
                string old_name = tn.Parent.Tag.ToString();

                if (class_name == null || type == null ||
                    old_name == null)
                {
                    return;
                }

                // check which subsection we are in, so we can add it to the right list
                if (type == "Methods" || type == "Fields")
                {
                    string old_descriptor = sl[3];

                    if (old_descriptor == null)
                        return;

                    if (type == "Methods")
                    {
                        RenameStore.AddRenameMethod(class_name, old_descriptor, old_name,
                            old_descriptor, newName);
                    }
                    else if (type == "Fields")
                    {
                        RenameStore.AddRenameField(class_name, old_descriptor, old_name,
                            old_descriptor, newName);
                    }

                    // update the tree without reloading it
                    tn.Parent.Text = newName;
                    tn.Parent.ToolTipText = "was '" + tn.Parent.Tag.ToString() + "'";
                    tn.Parent.BackColor = Color.DodgerBlue;
                }


            }
            catch (Exception e)
            {

            }

        }

        private void ChangeClassName(TreeNode Node, string newName)
        {

            try
            {
                string[] s = Node.Text.Split(':');

                string old_name = s[0].Trim();
                string old_descriptor = s[1].Trim();

                if (s.Length == 0)
                    return;

                string new_name_and_type = newName + " : " + old_descriptor;
                RenameStore.AddRenameClass(Node.Tag.ToString(), new_name_and_type);

                Node.BackColor = Color.DodgerBlue;
                Node.Text = new_name_and_type;
                Node.ToolTipText = "was '" + Node.Tag.ToString() + "'";

            }
            catch (Exception e)
            {

            }

        }

        private void GetAllNodes(TreeNode treeNode, List<TreeNode> lst)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                lst.Add(tn);
                GetAllNodes(tn, lst);
            }
        }

        private void classesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Files == null)
                    Files = new ArrayList();

                foreach (String fn in OpenFileDialog.FileNames)
                {
                    Files.Add(fn);
                }

                if (txtOutput.Text.Length == 0 || !Directory.Exists(txtOutput.Text))
                {
                    try { txtOutput.Text = Directory.GetParent(Files[0].ToString()).FullName + "\\output\\"; }
                    catch (Exception ex) { }
                }

                UpdateTree();
            }
        }

        private void directoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string foldername = Properties.Settings.Default.lastDir;
            if (Directory.Exists(foldername)) folderBrowserDialog1.SelectedPath = foldername;

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                if (Files == null)
                    Files = new ArrayList();

                foldername = this.folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.lastDir = foldername;

                foreach (string f in Directory.GetFiles(foldername))
                {
                    if(f.ToLower().EndsWith(".class")) Files.Add(f);
                }

                if (txtOutput.Text.Length == 0 || !Directory.Exists(txtOutput.Text))
                {
                    try { txtOutput.Text = Directory.GetParent(Files[0].ToString()).FullName + "\\output\\"; }
                    catch (Exception ex) { }
                }

                UpdateTree();
            }
        }

        private void classesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (TreeNode nn in TreeClassView.Nodes)
            {
                if (nn.Text.IndexOf(">") < 1)
                {
                    ChangeClassName(nn, "class_" + i.ToString());
                    i++;
                }
            }
        }

        private void methodsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TreeNode> allNodes = new List<TreeNode>();
            foreach (TreeNode n in TreeClassView.Nodes)
            {
                allNodes.Add(n);
                GetAllNodes(n, allNodes);
            }

            Progress.Value = 0;
            Progress.Maximum = allNodes.Count;
            Progress.Visible = true;

            foreach (TreeNode pn in allNodes)
            {
                if (pn.Text == "Methods" || pn.Text == "Fields")
                {
                    int i = 0;
                    foreach (TreeNode cn in pn.Nodes)
                    {
                        if (cn.Text.IndexOf(">") < 1)
                        {
                            string nom = (pn.Text == "Methods" ? "sub_" : "field_");
                            ChangeMethodOrFieldName(cn, nom + i.ToString());
                            i++;
                        }
                    }

                }
                Progress.Value += 1;
            }

            Progress.Visible = false;
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Files = new ArrayList();
            TreeClassView.Nodes.Clear();
            RenameStore = new RenameDatabase();
        }

        private void findAndShow(string filename){
            string pth = AppDomain.CurrentDomain.BaseDirectory;
            for (int i = 0; i < 7; i++)
            {
                if (File.Exists(pth + "\\" + filename))
                {
                    Process.Start("notepad.exe", pth + "\\" + filename);
                    return;
                }
                pth = Directory.GetParent(pth).ToString();
            }
        }

        private void readmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findAndShow("readme");
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findAndShow("changelog.txt");
        }

        private void sequentiallyRenamePopup_Click(object sender, EventArgs e)
        {

            TreeNode selNode = TreeClassView.SelectedNode;
            if (selNode == null) return;

            if (selNode.Text == "Methods" || selNode.Text == "Fields")
            {
                int i = 0;
                foreach (TreeNode nn in selNode.Nodes)
                {
                    if (nn.Text.IndexOf(">") < 1)
                    {
                        string nom = (selNode.Text == "Methods" ? "sub_" : "field_");
                        ChangeMethodOrFieldName(nn, nom + i.ToString());
                        i++;
                    }
                }

            }
        }

        private void CopySubTree(TreeNode pn, ArrayList al, int nesting, int limit)
        {
            string tabs = new string('\t', nesting);
            foreach (TreeNode n in pn.Nodes)
            {
                al.Add(tabs + n.Text);
                if(limit < nesting || limit == -1) CopySubTree(n, al, nesting+1, limit);
            }
        }

        private void copySelectedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selNode = TreeClassView.SelectedNode;
            if (selNode == null)
            {
                MessageBox.Show("Select a node to copy...");
                return;
            }
            ArrayList dat = new ArrayList();
            dat.Add(selNode.Text);
            CopySubTree(selNode, dat, 1, 1);

            string tmp = "";
            foreach (String x in dat) tmp += x + "\r\n";
            Clipboard.SetText(tmp);
             
        }

        private void copyAllSubNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selNode = TreeClassView.SelectedNode;
            if (selNode == null)
            {
                MessageBox.Show("Select a node to copy...");
                return;
            }
            ArrayList dat = new ArrayList();
            dat.Add(selNode.Text);
            CopySubTree(selNode, dat, 1, -1);

            string tmp = "";
            foreach (String x in dat) tmp += x + "\r\n";
            Clipboard.SetText(tmp);
            //MessageBox.Show(tmp.Length.ToString("x") + " bytes copied.");
        }

        private void batchRenamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To do..");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void extractImportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList x = new ArrayList();
            foreach (TreeNode n in TreeClassView.Nodes)
            {
                //cycle through each class entry..
                if (n.Text.Contains("/"))
                {
                    string tmp = n.Text.Substring(n.Text.IndexOf("/") + 1);
                    tmp = tmp.Replace(": java/lang/Object","").Replace('/','.').Replace(":","\t\t\tExtends:").Trim();
                    x.Add("Class: " + tmp);
                }
                else
                {
                    x.Add("Class: " + n.Text);
                }

                TreeNode consts = n.FirstNode;
                TreeNode classes = consts.Nodes[2];
                List<String> imports = new List<string>();
                foreach (TreeNode nn in classes.Nodes)
                {
                    if (nn.Index > 0) //skip first entry which is dup of current class name
                    {
                        string tmp = nn.Text.Replace("\"","").Replace('/','.');
                        imports.Add(tmp);
                    }
                }

                imports.Sort();
                string last = "";
                foreach (String s in imports)
                {
                    if(s != last) x.Add("\t" + s);
                    last = s;
                }
                x.Add("");

            }

            DisplayData(x);


        }

        private void DisplayData(ArrayList al)
        {
            string tmp = "";
            foreach (String y in al) tmp += y + "\r\n";
            DisplayData(tmp);
        }

        private void DisplayData(string tmp)
        {
            string pth = Path.GetTempPath() + "\\" + Path.GetRandomFileName();
            File.WriteAllText(pth, tmp);
            Process.Start("notepad.exe",  pth );
        }
	}


}
